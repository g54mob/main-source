using UnityEngine;

public class OrderMarkerLightLookAt : MonoBehaviour
{
	private GameObject mainCamera;

	private void Start()
	{
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
	}

	private void Update()
	{
		Vector3 position = mainCamera.transform.parent.position;
		Vector3 worldPosition = new Vector3(position.x, base.transform.position.y, position.z);
		base.transform.LookAt(worldPosition);
	}
}
