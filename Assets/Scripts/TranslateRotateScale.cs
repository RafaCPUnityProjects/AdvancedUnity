using UnityEngine;
using System.Collections;

public class TranslateRotateScale : MonoBehaviour {

	public float x, y, z, speed;
	public Transform target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.Rotate(new Vector3(x, y, z), rotationSpeed * Time.deltaTime, Space.Self);

		//Vector3 topPoint = new Vector3(	this.transform.position.x + x,
		//								this.transform.position.y + y,
		//								this.transform.position.z + z);
		//Vector3 bottonPoint = new Vector3(	this.transform.position.x - x,
		//									this.transform.position.y - y,
		//									this.transform.position.z - z);

		//Debug.DrawLine(topPoint, bottonPoint);

		//MoveTowardsTarget(target.position);
		RotateTowardsTarget(target.position);
		PulseObject();
	}

	void MoveTowardsTarget(Vector3 targetPosition)
	{
		Vector3 currentPosition = this.transform.position;

		if (Vector3.Distance(targetPosition, currentPosition) > 1)
		{
			Vector3 directionOfTravel = targetPosition - currentPosition;
			directionOfTravel.Normalize();

			this.transform.Translate(directionOfTravel * speed * Time.deltaTime, Space.World);
		}
	}

	void RotateTowardsTarget(Vector3 targetPosition)
	{
		Vector3 currentPosition = this.transform.position;
		Quaternion currentRotation = this.transform.rotation;

		Vector3 directionOfLook = targetPosition - currentPosition;

		Quaternion targetRotation = Quaternion.LookRotation(directionOfLook);

		transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, Time.deltaTime * speed);
	}

	void PulseObject()
	{
		float scale = (Mathf.Sin(Time.time * (speed * 2 * Mathf.PI)) + 1f) / 2f;

		scale = Mathf.Lerp(x, y, scale);

		transform.localScale = Vector3.one * scale;
	}
}
