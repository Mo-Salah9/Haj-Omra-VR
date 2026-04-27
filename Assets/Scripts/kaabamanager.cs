using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.UI;

public class kaabamanager : MonoBehaviour
{
    public GameObject player;
    public Image image1, image2, image3;

    public Transform[] pathPoints;
    public float moveDuration = 20f;

    void Start()
    {
        player.transform.rotation = new Quaternion(0f, 0.793353379f, 0, 0.60876143f);
        StartCoroutine(enumerator());
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

        // HERE 👇 Move player using LOCAL path safely
        yield return MovePlayerAlongLocalPath();
    }

    private IEnumerator MovePlayerAlongLocalPath()
    {
        if (pathPoints == null || pathPoints.Length == 0)
            yield break;

        Vector3[] path = new Vector3[pathPoints.Length];

        for (int i = 0; i < pathPoints.Length; i++)
        {
            // convert world positions into player's local space
            path[i] = player.transform.parent.InverseTransformPoint(pathPoints[i].position);
        }

        Tween moveTween = player.transform.DOLocalPath(
            path,
            moveDuration,
            PathType.Linear
        )
        .SetEase(Ease.Linear);
        // 🔥 FIX: prevents upside-down flipping
        //.SetLookAt(0.01f, Vector3.up);

        yield return moveTween.WaitForCompletion();
    }
}