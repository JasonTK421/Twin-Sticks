using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private const int bufferFrames = 100;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody rigidbody;

	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	void Update () {
        Record();

    }

    void PlayBack() {
        rigidbody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;
        print("Reading frame: " + frame);
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }

    void Record() {
        rigidbody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
        print("Writing frame: " + frame);
        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}

/// <summary>
/// A structure for storing time, position and rotation.
/// </summary>
public struct MyKeyFrame {
    public float frameTime;
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame(float t, Vector3 pos, Quaternion rot) {
        frameTime = t;
        position = pos;
        rotation = rot;
    }
}