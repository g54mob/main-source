using System;
using System.Collections.Generic;
using UnityEngine;

public class RecordingCameraController : MonoBehaviour
{
	[Header("General")]
	[Tooltip("List of all the saved cameras.")]
	public List<CameraPresetProperties> SavedCameras = new List<CameraPresetProperties>();

	[Header("Speeds")]
	[Tooltip("Move speed of the camera.")]
	public float MoveSpeed = 50f;

	[Tooltip("Rotation speed of the camera.")]
	public float RotationSpeed = 50f;

	[SerializeField]
	[Tooltip("The speed at which speed gets incremented.")]
	private float _speedIncrement = 3f;

	[HideInInspector]
	public bool UseLocalUpAxis;

	[HideInInspector]
	public GameObject TurnaroundGameObject;

	[HideInInspector]
	public float TurnaroundVerticalAngle = 35f;

	[HideInInspector]
	public float TurnaroundSpeed = 10f;

	[HideInInspector]
	public float TurnaroundRadius = 50f;

	[HideInInspector]
	public float TurnaroundHeightOffset;

	private bool _controllerVerticalArrowPressed;

	private int _currentCameraSave;

	private float _turnaroundHorizontalAngle;

	public Camera Camera { get; private set; }

	public int CurrentCameraSave => _currentCameraSave;

	private void Awake()
	{
		Camera = GetComponent<Camera>();
	}

	private void Update()
	{
		if (GameManager.Gamepaused || CameraController.MainCamera != Camera)
		{
			return;
		}
		if (TurnaroundGameObject != null)
		{
			_turnaroundHorizontalAngle += Time.deltaTime * TurnaroundSpeed;
			float f = TurnaroundVerticalAngle * (MathF.PI / 180f);
			float f2 = _turnaroundHorizontalAngle * (MathF.PI / 180f);
			float num = Mathf.Sin(f) * TurnaroundRadius;
			float num2 = (1f - num / TurnaroundRadius) * TurnaroundRadius;
			float x = Mathf.Cos(f2) * num2 + TurnaroundGameObject.transform.position.x;
			float y = num + TurnaroundGameObject.transform.position.y;
			float z = Mathf.Sin(f2) * num2 + TurnaroundGameObject.transform.position.z;
			base.transform.position = new Vector3(x, y, z);
			base.transform.LookAt(TurnaroundGameObject.transform);
			base.transform.position += Vector3.up * TurnaroundHeightOffset;
		}
		else
		{
			CameraControls();
			CameraSaveControls();
			if (Input.GetButtonDown("Controller X&B") && Input.GetAxisRaw("Controller X&B") < 0f)
			{
				WaterManager.Instance.PauseWater();
			}
		}
	}

	public void CameraControls()
	{
		float axis = Input.GetAxis("Cinematic Horizontal");
		float axis2 = Input.GetAxis("Cinematic Forward");
		float num = Input.GetAxis("Cinematic Vertical Up") - Input.GetAxis("Cinematic Vertical Down");
		float axis3 = Input.GetAxis("Cinematic Horizontal Rotation");
		float axis4 = Input.GetAxis("Cinematic Vertical Rotation");
		float axis5 = Input.GetAxis("Controller Vertical Arrows");
		if (axis5 != 0f)
		{
			if (!_controllerVerticalArrowPressed)
			{
				_controllerVerticalArrowPressed = true;
				if (axis5 < 0f)
				{
					GameManager.UIManager.ToggleUIEnabled();
				}
				else
				{
					UseLocalUpAxis = !UseLocalUpAxis;
				}
			}
		}
		else
		{
			_controllerVerticalArrowPressed = false;
		}
		if (Input.GetButton("Cinematic Speed"))
		{
			MoveSpeed += Input.GetAxis("Cinematic Speed") * _speedIncrement;
			MoveSpeed = Mathf.Clamp(MoveSpeed, 0f, MoveSpeed);
		}
		RotationSpeed += Input.GetAxis("Controller Horizontal Arrows") * _speedIncrement;
		RotationSpeed = Mathf.Clamp(RotationSpeed, 0f, RotationSpeed);
		Vector3 zero = Vector3.zero;
		zero.x = axis * MoveSpeed * Time.deltaTime;
		zero.y = num * MoveSpeed * Time.deltaTime;
		zero.z = axis2 * MoveSpeed * Time.deltaTime;
		Vector3 zero2 = Vector3.zero;
		zero2.y = axis3 * RotationSpeed * Time.deltaTime;
		zero2.x = axis4 * RotationSpeed * Time.deltaTime;
		base.transform.Translate(zero.x, 0f, zero.z);
		base.transform.Translate(0f, zero.y, 0f, UseLocalUpAxis ? Space.Self : Space.World);
		base.transform.Rotate(Vector3.up, zero2.y, Space.World);
		base.transform.Rotate(Vector3.right, zero2.x, Space.Self);
	}

	private void CameraSaveControls()
	{
		if (Input.GetButtonDown("CycleSavedCameras"))
		{
			CycleSavedCamera((int)Input.GetAxisRaw("CycleSavedCameras"));
		}
		else if (Input.GetButtonDown("OverrideSavedCamera"))
		{
			OverwriteCurrentCamera();
		}
		else if (Input.GetButtonDown("ResetToCurrentSavedCamera"))
		{
			ResetCurrentCamera();
		}
	}

	public void ResetCurrentCamera()
	{
		UpdateCurrentCamera(GetCurrentSavedCamera());
	}

	public void OverwriteCurrentCamera()
	{
		CameraPresetProperties cameraPresetProperties = SavedCameras[_currentCameraSave];
		cameraPresetProperties.Position = base.transform.position;
		cameraPresetProperties.Rotation = base.transform.eulerAngles;
		cameraPresetProperties.FOV = Camera.fieldOfView;
	}

	public void CycleSavedCamera(int direction)
	{
		int num = _currentCameraSave + direction;
		if (num < 0)
		{
			num = SavedCameras.Count - 1;
		}
		else if (num >= SavedCameras.Count)
		{
			num = 0;
		}
		_currentCameraSave = num;
		UpdateCurrentCamera(GetCurrentSavedCamera());
	}

	public void SetSavedCamera(int index)
	{
		_currentCameraSave = index;
		UpdateCurrentCamera(GetCurrentSavedCamera());
	}

	private void UpdateCurrentCamera(CameraPresetProperties savedCamera)
	{
		base.transform.position = savedCamera.Position;
		base.transform.eulerAngles = savedCamera.Rotation;
		Camera.fieldOfView = savedCamera.FOV;
	}

	public CameraPresetProperties GetCurrentSavedCamera()
	{
		return SavedCameras[_currentCameraSave];
	}
}
