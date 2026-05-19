using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.SceneManagement;

public class arafatmanger : MonoBehaviour
{
    public GameObject player , light , p1 ,p2 ,p3 ,p4, p5, ih;
     

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.transform.position = new Vector3(-159.199997f, -2.70000005f, -443.899994f);
        player.transform.rotation = new Quaternion(0, -0.903709233f, 0, 0.42814669f);
        StartCoroutine(enumerator());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator enumerator()
    {
        yield return new WaitForSeconds(1f);
        AudioManager.Instance.PlayAlone("arafat");
        yield return new WaitForSeconds(4f);
        player.transform.DOMove ((p1.transform.position), 7f);
        yield return new WaitForSeconds(7f);
        player.transform.DORotateQuaternion ( new Quaternion(0, -1, 0, 0), 1f);
        yield return new WaitForSeconds(1f);
        player.transform.DOMove((p2.transform.position), 6f);
        yield return new WaitForSeconds(6f);

        ih.SetActive(true);
      
        yield return new WaitForSeconds(4f);
        ih.SetActive(false);
        player.transform.DORotateQuaternion(new Quaternion(0, -0.815885365f, 0, 0.578213751f), 1f);
        yield return new WaitForSeconds(1f);
        player.transform.DOMove((p3.transform.position), 4f);
        
        player.transform.DORotateQuaternion(new Quaternion(0, -0.736097634f, 0, 0.676875412f), 1f);
        yield return new WaitForSeconds(11f);
        //light.transform.DORotateQuaternion(new Quaternion(-0.911074281f, -0.07994394f, -0.344902426f, 0.211175278f), 6f);
        AudioManager.Instance.PlayAlone("arafatq");
        player.transform.DORotateQuaternion(new Quaternion(0, -0.455467224f, 0, 0.89025259f), 1f);
        yield return new WaitForSeconds(1f);
        player.transform.DOMove((p4.transform.position), 3f);
        yield return new WaitForSeconds(3f);
        player.transform.DOMove((p5.transform.position), 2f);
        yield return new WaitForSeconds(2f);
        player.transform.DORotateQuaternion(new Quaternion(0, -0.114937216f, 0, 0.993372798f), 1f);
        yield return new WaitForSeconds(29);
        SceneManager.LoadScene("mozda");



        yield return null;  
    }

}
