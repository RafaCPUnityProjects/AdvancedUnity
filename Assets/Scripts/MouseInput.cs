using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour {
	
	public float depthIntoScene = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		MoveToMouseAtObjectDepth();
	}

	void MoveToMouseAtObjectDepth()
	{
		Vector3 mouseScreenPosition = Input.mousePosition;

		Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);

		float depth;
		RaycastHit hitInfo;

		if (Physics.Raycast(ray, out hitInfo))
		{
			this.transform.position = hitInfo.point;
		}
		else
		{
			depth = depthIntoScene;
			return;
		}
	}
}
