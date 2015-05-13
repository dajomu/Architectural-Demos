using UnityEngine;
using System.Collections;

public class fpsControl : MonoBehaviour {

	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 2.0f;
	float rotUD = 0;
	public float UDRange = 60.0f;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {

		//Rotation
		float rotLR = Input.GetAxis("Mouse X") * mouseSensitivity;
		transform.Rotate(0, rotLR, 0);

		rotUD -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		rotUD = Mathf.Clamp(rotUD, -UDRange, UDRange);
		Camera.main.transform.localRotation = Quaternion.Euler(rotUD, 0, 0);

		//Movement
		float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
		float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

		Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);

		speed = transform.rotation * speed;

		CharacterController cc = GetComponent<CharacterController>();

		cc.SimpleMove(speed);
	}
}
