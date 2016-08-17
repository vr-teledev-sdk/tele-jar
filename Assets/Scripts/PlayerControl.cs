using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {
    public float speed;
    public Text scoreText;
    public TelegramListener TelegramListener;

    private int score = 0;
    private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        TelegramListener.RepaintEvent.AddListener(color => GetComponent<MeshRenderer>().material.color = color);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate () {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        rigidBody.AddForce(horiz * speed, 0, vert * speed);
    }

    void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag("Pick Up"))
            other.gameObject.GetComponent<PickupObjectBehaviour>().Disappear();
        scoreText.text = "Score: " + ++score;
    }
}
