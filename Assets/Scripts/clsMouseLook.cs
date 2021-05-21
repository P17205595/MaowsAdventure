using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class clsMouseLook : MonoBehaviour
{

    // Mouse direction.
    public Vector2 mDir;

    public Transform myBody;


    void Start()
    {
        myBody = this.transform.parent.transform;
    }


    void Update()
    {
        // How much has mouse moved across the screen
        Vector2 mc = new Vector2(Input.GetAxisRaw("Mouse X"),
            Input.GetAxisRaw("Mouse Y"));

        //if (this.transform.localEulerAngles.x < 84f ||
        //    this.transform.localEulerAngles.x > 275f)
        //{
        //    mDir += mc;
        //}
        //else
        //    mDir.y -= mc.y * 3f;


        // Better way to do what I did above in less lines and less jittery movement
        mDir += mc;
        mDir.y = Mathf.Clamp(mDir.y, -90f, 90f);


        // Rotate head up or down X axis
        this.transform.localRotation =
            Quaternion.AngleAxis(-mDir.y, Vector3.right);

        // Rotate body left or right on Y axis
        // This rotates the parent body (my cat capsule) but not the camera
        myBody.localRotation =
            Quaternion.AngleAxis(mDir.x, Vector3.up);
    }
}