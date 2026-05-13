using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using System.Collections.Generic;
public class mozdalefah : MonoBehaviour
{

     // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    private List<InputDevice> devices = new List<InputDevice>();

    void Start()
    {
        StartCoroutine("mena");
        player.transform.rotation = new Quaternion(0, -0.00174538908f, 0, 0.99999851f);
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
        SceneManager.LoadScene(0);
    }

    private IEnumerator mena()
    {
        yield return new WaitForSeconds(1);
        player.transform.DOMove(new Vector3(-180.772995f, -1.86960971f, -440.600006f), 80);
        AudioManager.Instance.Play("mozda");
        yield return new WaitForSeconds(22);
        SceneManager.LoadScene("jamarat");
    }
}
