using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Camera Cam;
    [SerializeField] float cameraMoveSpeed;
    [SerializeField] float Big_Y_Pos, Size_Big, Size_Small;
    private float cameraMoveDirX, cameraMoveDirY;
    private float cameraSize;
    public bool Mer03On;
    public float Target;


    void Start()
    {
        Cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Mer03On == false)
        {
            SizeDown();
            CameraTrack();
        }
        if (Mer03On == true)
        {
            CameraTrack_BigM();
            SizeUp();
        }
    }

    void Ending()
    {
        cameraMoveDirX = Target - transform.position.x;
    }

    void CameraTrack()
    {
        cameraMoveDirX = Target - transform.position.x;
        cameraMoveDirY = 0 - transform.position.y;
        transform.position = new Vector3(transform.position.x + cameraMoveDirX * cameraMoveSpeed * Time.deltaTime, transform.position.y + cameraMoveDirY * cameraMoveSpeed * Time.deltaTime, transform.position.z);
    }


    void SizeUp()
    {
        cameraSize = Size_Big - Cam.orthographicSize;
        Cam.orthographicSize = Cam.orthographicSize + cameraSize * cameraMoveSpeed * Time.deltaTime;
    }
    void SizeDown()
    {
        cameraSize = Size_Small - Cam.orthographicSize;
        Cam.orthographicSize = Cam.orthographicSize + cameraSize * cameraMoveSpeed * Time.deltaTime;
    }
    void CameraTrack_BigM()
    {
        cameraMoveDirX = Target - transform.position.x;
        cameraMoveDirY = Big_Y_Pos - transform.position.y;
        transform.position = new Vector3(transform.position.x + cameraMoveDirX * cameraMoveSpeed * Time.deltaTime, transform.position.y + cameraMoveDirY * cameraMoveSpeed * Time.deltaTime, transform.position.z);
    }
}
