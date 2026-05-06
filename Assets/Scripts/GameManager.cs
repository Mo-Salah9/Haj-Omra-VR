using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.XR;


public class GameManager : MonoBehaviour
{
    private List<InputDevice> devices = new List<InputDevice>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public Image image1, image2, image3, imagem;
    public GameObject Videobject;
    public VideoPlayer clip;
    //public void step1()
    //{
    //    player.transform.position = new Vector3(0.365471601f, 0.295673728f, -0.584015489f);
    //    player.transform.rotation = new Quaternion(0, 0.707106829f, 0, 0.707106829f);
    private void Start()
    {
        StartCoroutine(step1());
    }

    //}
    public void step2()
    {

    }

    void Update()
    {
        // 🔁 Re-fetch if lost / not initialized
        if (devices == null || devices.Count == 0)
        {
            InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devices);
        }

        if (devices.Count > 0)
        {
            bool aButtonPressed;

            if (devices[0].TryGetFeatureValue(CommonUsages.primaryButton, out aButtonPressed) && aButtonPressed)
            {
                Debug.Log("A button pressed");
                LoadScene();
            }
        }
    }
    void LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public IEnumerator step1()
    {
        //player.transform.position = new Vector3(0.365471601f, 0.295673728f, -0.584015489f);
        //player.transform.rotation = new Quaternion(0, 0.707106829f, 0, 0.707106829f);
        yield return new WaitForSeconds(1);
        AudioManager.Instance.PlayAlone("1");
        image1.GetComponent<CanvasGroup>().DOFade(1, 2);
        yield return new WaitForSeconds(22);
        image1.GetComponent<CanvasGroup>().alpha = 0;
        AudioManager.Instance.PlayAlone("mq");
        imagem.GetComponent<CanvasGroup>().DOFade(1, 2);
        yield return new WaitForSeconds(25);
        imagem.GetComponent<CanvasGroup>().alpha = 0;
        AudioManager.Instance.PlayAlone("2");
        image2.GetComponent<CanvasGroup>().DOFade(1, 2);
        yield return new WaitForSeconds(32);
        image2.GetComponent<CanvasGroup>().alpha = 0;
        image3.GetComponent<CanvasGroup>().DOFade(1, 2);
        AudioManager.Instance.PlayAlone("3");
        yield return new WaitForSeconds(26);
        image3.GetComponent<CanvasGroup>().alpha = 0;
        //Videobject.SetActive(true);
        //clip.Play();
        SceneManager.LoadScene(1);
    }
}
