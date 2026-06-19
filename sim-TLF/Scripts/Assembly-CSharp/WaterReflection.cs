using UnityEngine;

public class WaterReflection : MonoBehaviour
{
	private Camera mainCamera;

	private Camera reflectionCamera;

	[Tooltip("The plane where the camera will be reflected, the water plane or any object with the same position and rotation")]
	public Transform reflectionPlane;

	[Tooltip("The texture used by the Water shader to display the reflection")]
	public RenderTexture outputTexture;

	public bool copyCameraParamerers;

	public float verticalOffset;

	private bool isReady;

	private Transform mainCamTransform;

	private Transform reflectionCamTransform;

	public void Awake()
	{
		mainCamera = Camera.main;
		reflectionCamera = GetComponent<Camera>();
		Validate();
	}

	private void Update()
	{
		if (isReady)
		{
			RenderReflection();
		}
	}

	private void RenderReflection()
	{
		Vector3 forward = mainCamTransform.forward;
		Vector3 up = mainCamTransform.up;
		Vector3 position = mainCamTransform.position;
		position.y += verticalOffset;
		Vector3 direction = reflectionPlane.InverseTransformDirection(forward);
		Vector3 direction2 = reflectionPlane.InverseTransformDirection(up);
		Vector3 position2 = reflectionPlane.InverseTransformPoint(position);
		direction.y *= -1f;
		direction2.y *= -1f;
		position2.y *= -1f;
		forward = reflectionPlane.TransformDirection(direction);
		up = reflectionPlane.TransformDirection(direction2);
		position = reflectionPlane.TransformPoint(position2);
		reflectionCamTransform.position = position;
		reflectionCamTransform.LookAt(position + forward, up);
	}

	private void Validate()
	{
		if (mainCamera != null)
		{
			mainCamTransform = mainCamera.transform;
			isReady = true;
		}
		else
		{
			isReady = false;
		}
		if (reflectionCamera != null)
		{
			reflectionCamTransform = reflectionCamera.transform;
			isReady = true;
		}
		else
		{
			isReady = false;
		}
		if (isReady && copyCameraParamerers)
		{
			copyCameraParamerers = !copyCameraParamerers;
			reflectionCamera.CopyFrom(mainCamera);
			reflectionCamera.targetTexture = outputTexture;
		}
	}
}
