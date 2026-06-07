using UnityEngine;

public class Billboarder : MonoBehaviour
{
	private void Update()
	{
		base.gameObject.transform.forward = CameraController.Instance.Camera.transform.forward;
	}
}
