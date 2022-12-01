using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{

    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, 5, 0);

        //Debug.Log((player.transform.rotation).eulerAngles + new Vector3(20, 0, 0));

        transform.rotation = Quaternion.Euler((player.transform.rotation).eulerAngles + new Vector3(20,0,0));
    }        
}