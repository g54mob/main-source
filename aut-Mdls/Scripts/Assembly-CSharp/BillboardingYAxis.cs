using Presentation.Locators;
using UnityEngine;

public class BillboardingYAxis : MonoBehaviour
{
	[SerializeField]
	private CameraLocator _cameraLocator;

	[SerializeField]
	private float _lerpRotationSpeed = 5f;

	[SerializeField]
	private float yOffset = 90f;

	private void Update()
	{
		Vector3 forward = _cameraLocator.Camera.transform.position - base.transform.position;
		forward.y = 0f;
		forward.Normalize();
		Quaternion b = Quaternion.LookRotation(forward);
		Quaternion quaternion = Quaternion.Euler(0f, yOffset, 0f);
		b *= quaternion;
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, _lerpRotationSpeed * Time.deltaTime);
	}
}
