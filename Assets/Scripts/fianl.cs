using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class fianl : MonoBehaviour
{
    private List<InputDevice> devices = new List<InputDevice>();


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
    private void Start()
    {
        StartCoroutine(jamaratt());
    }

    private IEnumerator jamaratt()
    {
        AudioManager.Instance.PlayAlone("TALK");
        yield return new WaitForSeconds(66);
        AudioManager.Instance.PlayAlone("MUSIC");


        yield return null;

    }
}
