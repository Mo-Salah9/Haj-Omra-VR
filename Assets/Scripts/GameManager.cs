using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player; 

    public void step1()
    {
        player.transform.position = new Vector3(0.365471601f, 0.295673728f, -0.584015489f);
        player.transform.rotation = new Quaternion(0, 0.707106829f, 0, 0.707106829f);
       
    }
    public void step2() 
    { 
    
    }

   
}
