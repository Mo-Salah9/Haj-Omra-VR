using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class PathPointData2
{
    public Transform point;
    public Vector3 rotation;
    public CanvasGroup ui;
    public AudioClip audioClip;
    public float stopDuration;
}
public class safamarwa : MonoBehaviour
{
    public GameObject player;
    public Image image1, image2, image3;
    public PathPointData2[] pathPoints;
    public float moveSpeed = 2f; // units per second — rename in Inspector too

    void Start()
    {
        player.transform.rotation = new Quaternion(0f, 0.793353379f, 0, 0.60876143f);
        StartCoroutine(MovePlayerAlongLocalPath());
    }

    public IEnumerator enumerator()
    {
        AudioManager.Instance.PlayAlone("k1");
        yield return new WaitForSeconds(10f);
        image1.GetComponent<CanvasGroup>().DOFade(1, 2);
        yield return new WaitForSeconds(10f);
        player.transform.DORotate(new Vector3(0, 175, 0), 1f);
        image1.GetComponent<CanvasGroup>().DOFade(0, 2);
        AudioManager.Instance.PlayAlone("k2");
        image2.GetComponent<CanvasGroup>().DOFade(1, 2);
        yield return new WaitForSeconds(13f);
        image2.GetComponent<CanvasGroup>().DOFade(0, 2);
        yield return MovePlayerAlongLocalPath();
    }

    private IEnumerator MovePlayerAlongLocalPath()
    {
        if (pathPoints == null || pathPoints.Length == 0)
            yield break;

        float playerLocalY = player.transform.localPosition.y;

        for (int i = 0; i < pathPoints.Length; i++)
        {
            PathPointData2 data = pathPoints[i];
            if (data.point == null) continue;

            // — Compute target local position —
            Vector3 localPoint = player.transform.parent != null
                ? player.transform.parent.InverseTransformPoint(data.point.position)
                : data.point.position;
            localPoint.y = playerLocalY;

            // — Duration based on distance and constant speed —
            float distance = Vector3.Distance(player.transform.localPosition, localPoint);
            float segmentDuration = distance / moveSpeed;

            Tween moveTween = player.transform
                .DOLocalMove(localPoint, segmentDuration)
                .SetEase(Ease.Linear);

            yield return moveTween.WaitForCompletion();

            // — Rotation —
            player.transform.DORotate(data.rotation, 0.5f);

            // — Audio —
            if (data.audioClip != null)
                AudioManager.Instance.PlayAlone(data.audioClip.name);

            // — UI Fade In —
            if (data.ui != null)
                data.ui.DOFade(1, 0.5f);

            // — Stop Duration —
            if (data.stopDuration > 0f)
                yield return new WaitForSeconds(data.stopDuration);

            // — UI Fade Out —
            if (data.ui != null)
                data.ui.DOFade(0, 0.5f);
        }
    }
}
