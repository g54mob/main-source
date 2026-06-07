using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
	[Header("Forced Camera")]
	public Transform overrideCameraTarget;

	[HideInInspector]
	public float overrideZoom = -1f;

	private Transform cameraTarget;

	private Transform currentTarget;

	private Quaternion startRotation;

	[SerializeField]
	private float transitionSpeed = 1f;

	[SerializeField]
	private List<Camera> cameras = new List<Camera>();

	[SerializeField]
	private float[] zoomLevels = new float[4] { 20f, 15f, 10f, 5f };

	[SerializeField]
	private float zoomSpeed = 50f;

	private Player input;

	private int zoomLevel;

	private float targetOrthSize;

	private bool transitionRunning;

	private float DefaultOrthSize => zoomLevels[0];

	private void UpdateZoom()
	{
		if (input.GetButtonDown("Zoom"))
		{
			zoomLevel = (zoomLevel + 1) % zoomLevels.Length;
			targetOrthSize = zoomLevels[zoomLevel];
		}
		float a = ((overrideZoom > 0f) ? (overrideZoom * DefaultOrthSize) : targetOrthSize);
		foreach (Camera camera in cameras)
		{
			camera.orthographicSize = Mathf.Lerp(a, camera.orthographicSize, Mathf.Pow(0.5f, Time.deltaTime * zoomSpeed));
		}
	}

	private void Start()
	{
		startRotation = base.transform.rotation;
		cameraTarget = base.transform.parent;
		currentTarget = cameraTarget;
		base.transform.SetParent(null);
		input = ReInput.players.GetPlayer(0);
		targetOrthSize = zoomLevels[0];
	}

	private void Update()
	{
		if (transitionRunning)
		{
			return;
		}
		if (overrideCameraTarget != null && currentTarget != overrideCameraTarget)
		{
			StartCoroutine(TransitionToTarget(overrideCameraTarget, overrideZoom * DefaultOrthSize));
		}
		else if (overrideCameraTarget == null && currentTarget != cameraTarget)
		{
			targetOrthSize = DefaultOrthSize;
			StartCoroutine(TransitionToTarget(cameraTarget, targetOrthSize));
		}
		if (!transitionRunning)
		{
			UpdateZoom();
			if (overrideCameraTarget != null)
			{
				base.transform.position = overrideCameraTarget.position;
				base.transform.rotation = overrideCameraTarget.rotation;
			}
			else
			{
				base.transform.position = cameraTarget.position;
				base.transform.rotation = startRotation;
			}
		}
	}

	private IEnumerator TransitionToTarget(Transform newTarget, float targetCameraSize)
	{
		transitionRunning = true;
		Vector3 startPosition = base.transform.position;
		Quaternion startRotation = base.transform.rotation;
		float transitionTime = 0f;
		float startCameraSize = cameras[0].orthographicSize;
		while (transitionTime < 1f)
		{
			if (newTarget == null)
			{
				newTarget = cameraTarget;
				break;
			}
			transitionTime = Mathf.Clamp(transitionTime, 0f, 1f);
			float t = 3f * Mathf.Pow(transitionTime, 2f) - 2f * Mathf.Pow(transitionTime, 3f);
			base.transform.position = Vector3.Lerp(startPosition, newTarget.position, t);
			base.transform.rotation = Quaternion.Lerp(startRotation, newTarget.rotation, t);
			float orthographicSize = Mathf.Lerp(startCameraSize, targetCameraSize, t);
			foreach (Camera camera in cameras)
			{
				camera.orthographicSize = orthographicSize;
			}
			transitionTime += Time.deltaTime * transitionSpeed;
			yield return null;
		}
		base.transform.position = newTarget.position;
		base.transform.rotation = newTarget.rotation;
		foreach (Camera camera2 in cameras)
		{
			camera2.orthographicSize = targetCameraSize;
		}
		currentTarget = newTarget;
		transitionRunning = false;
		yield return null;
		base.transform.position = newTarget.position;
		base.transform.rotation = newTarget.rotation;
		foreach (Camera camera3 in cameras)
		{
			camera3.orthographicSize = targetCameraSize;
		}
	}
}
