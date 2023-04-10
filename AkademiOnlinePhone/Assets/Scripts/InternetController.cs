using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternetController : MonoBehaviour
{
    public GameObject InternetMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            InternetMenu.SetActive(true);
        }
        else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
        {
            InternetMenu.SetActive(false);
        }
        else if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            InternetMenu.SetActive(false);
        }
    }
}
