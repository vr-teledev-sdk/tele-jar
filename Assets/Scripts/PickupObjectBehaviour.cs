using UnityEngine;
using System.Collections;

public class PickupObjectBehaviour : MonoBehaviour {

    public float frequency;
    public float disappearTime;

    private Vector3? disappScale = null;
    private float disappTime;

	// Use this for initialization
	void Start () {
	    
	}

    public void Disappear () {
        disappScale = transform.localScale;
        disappTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        if (disappScale == null) {
            float time = Time.time * 2 * Mathf.PI * frequency;
            float new_r = 0.25f + 0.025f * Mathf.Sin(time);
            transform.localScale = new Vector3(new_r, new_r, new_r);
            transform.rotation = Quaternion.EulerAngles(0, time, time);
        } else {
            if (Time.time > disappTime + disappearTime) {
                gameObject.SetActive (false);
            } else {
                transform.localScale = (Vector3) disappScale * (1 - (Time.time - disappTime) / disappearTime);
            }
        }
	}
}
