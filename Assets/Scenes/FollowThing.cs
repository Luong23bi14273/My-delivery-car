using UnityEngine;

public class FollowThing : MonoBehaviour
{
    [SerializeField] GameObject followThing;
    [SerializeField] float CameraZ = 50;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = followThing.transform.position + new Vector3(0,0,-CameraZ);
    }
}
