using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{

    public Transform[] backgrounds;  // List of back and foregrounds to be parallaxed
    public float[] parallaxScales;   //the proporrtion of the camera's movement to move the backgrounds by
    public float smoothing = 1f;     // Must be above 0

    private Transform cam;  //reference to the main cameras transform
    private Vector3 previousCamPos; //the position of the camera in the previous frame

    // Called before Start()
    void Awake()
    {
        // set up the camera reference
        cam = Camera.main.transform;
    }

    // Use this for initialization
    void Start()
    {
        // The previous frame had the current frame's camera position
        this.previousCamPos = cam.position;

        this.parallaxScales = new float[this.backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);

        }

        previousCamPos = cam.position;
    }
}
