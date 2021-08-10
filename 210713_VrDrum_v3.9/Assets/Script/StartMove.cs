using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMove : MonoBehaviour
{
    public Vector3 myNewXYZPosition;
    public float speed;
   
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(
        transform.localPosition,
        myNewXYZPosition,
        Time.deltaTime * speed);
    }
}
