using System;
using UnityEngine;

public class BasicCameraMovement : MonoBehaviour
{
	private enum SlidingDirectionEnum
	{
		NotSliding = 0,
		SlidingLeft = 1,
		SlidingRight = 2,
		SlidingUp = 3,
		SlidingDown = 4
	}

	private const float SCREEN_BORDER_HORIZ = 300f;

	private const float SCREEN_BORDER_VERT = 100f;

	public float speed = 5f;

	private Vector3 prevPos = Vector3.zero;

	private float rot;

	private int prevAxis = -1;

	private Vector3 initMouseDown = Vector3.zero;

	public Vector3 Target = Vector3.zero;

	public bool DisableKBMovement { get; set; }

	public void Awake()
	{
		InputState.AltMouseDownStateChangeEvent += HandleInputStateAltMouseDownStateChangeEvent;
	}

	public void Start()
	{
	}

	public void Update()
	{
		float num = 0f;
		float num2 = 0f;
		if (!InputState.altDown && !InputState.shiftDown)
		{
			num = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
			num2 = Input.GetAxis("Vertical") * Time.deltaTime * speed;
		}
		float axis = Input.GetAxis("Mouse ScrollWheel");
		Vector3 mousePosition = Input.mousePosition;
		if (Input.GetMouseButtonUp(0))
		{
			rot = 0f;
		}
		float num3 = mousePosition.x - prevPos.x;
		float y = mousePosition.y - prevPos.y;
		if (InputState.altLMBDown)
		{
			Vector3 vector = mousePosition - initMouseDown;
			initMouseDown = mousePosition;
			float num4 = 65f * (vector.x / (float)Screen.width);
			float num5 = 55f * (vector.y / (float)Screen.height);
			num = (0f - num4) * 1f;
			num2 = (0f - num5) * 1f;
		}
		if (InputState.altRMBDown)
		{
			new Vector2(num3, y).Normalize();
			if (num3 > 0.3f)
			{
				rot = 3f;
			}
			else if (num3 < -0.3f)
			{
				rot = -3f;
			}
			else
			{
				rot = 0f;
			}
			Camera.main.transform.RotateAround(Target, Vector3.up, rot);
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			rot = -90f;
			Camera.main.transform.RotateAround(Target, Vector3.up, rot);
		}
		if (Input.GetKeyDown(KeyCode.Q))
		{
			rot = 90f;
			Camera.main.transform.RotateAround(Target, Vector3.up, rot);
		}
		if (InputState.altMMBDown)
		{
			Vector2 vector2 = new Vector2(num3, y);
			vector2.Normalize();
			float num6 = 0f;
			if (prevAxis != -1 && Math.Abs(Math.Abs(vector2.y) - Math.Abs(vector2.x)) <= 0.1f)
			{
				num6 = ((prevAxis != 0) ? ((0f - vector2.y) * 0.005f) : (vector2.x * 0.005f));
			}
			else
			{
				if (Math.Abs(vector2.y) >= Math.Abs(vector2.x))
				{
					prevAxis = 0;
				}
				else
				{
					prevAxis = 1;
				}
				num6 = ((prevAxis != 0) ? vector2.x : (0f - vector2.y)) * 0.005f;
			}
			if (num6 > 0f)
			{
				Camera.main.transform.Translate(0f, -0.375f, 0f, Space.World);
			}
			else if (num6 < 0f)
			{
				Camera.main.transform.Translate(0f, 0.375f, 0f, Space.World);
			}
			else
			{
				prevAxis = -1;
			}
		}
		if (axis != 0f)
		{
			if (axis > 0f)
			{
				Camera.main.transform.Translate(0f, -1f, 0f, Space.World);
			}
			else
			{
				Camera.main.transform.Translate(0f, 1f, 0f, Space.World);
			}
		}
		prevPos = mousePosition;
		if (num != 0f || num2 != 0f)
		{
			Quaternion rotation = Camera.main.transform.rotation;
			SetXRotation(0f);
			Camera.main.transform.Translate(num, 0f, num2, Space.Self);
			Camera.main.transform.rotation = rotation;
		}
		Target = Camera.main.transform.position + Camera.main.transform.forward * 10f;
		Camera.main.transform.LookAt(Target);
	}

	public void SetRotation(float angle)
	{
		Quaternion rotation = Camera.main.transform.rotation;
		Vector3 eulerAngles = rotation.eulerAngles;
		eulerAngles.y = angle;
		rotation.eulerAngles = eulerAngles;
		Camera.main.transform.rotation = rotation;
	}

	private void SetXRotation(float angle)
	{
		Quaternion rotation = Camera.main.transform.rotation;
		Vector3 eulerAngles = rotation.eulerAngles;
		eulerAngles.x = angle;
		rotation.eulerAngles = eulerAngles;
		Camera.main.transform.rotation = rotation;
	}

	public void SetRelativeRotation(float delta)
	{
		Camera.main.transform.RotateAround(Target, Vector3.up, delta);
	}

	public void SetPosition(Vector3 position)
	{
		GetComponent<Camera>().transform.position = position;
	}

	public void SetZoom(float zoom)
	{
		GetComponent<Camera>().transform.Translate(0f, zoom, 0f, Space.World);
	}

	public Vector3 GetPosition()
	{
		return GetComponent<Camera>().transform.position;
	}

	public float GetRotationAngle()
	{
		return Camera.main.transform.rotation.eulerAngles.y;
	}

	public void OnGUI()
	{
		if (InputState.shiftDown)
		{
			if (!InputState.ctrlDown)
			{
				GUI.Label(new Rect(10f, 10f, 100f, 20f), "PAN ON EDGES");
			}
			else
			{
				GUI.Label(new Rect(10f, 10f, 100f, 20f), "PAN ALWAYS");
			}
		}
	}

	private void HandleInputStateAltMouseDownStateChangeEvent(int ButtonType, bool state)
	{
		switch (ButtonType)
		{
		case 0:
			if (state)
			{
				Vector3 mousePosition = Input.mousePosition;
				initMouseDown = mousePosition;
			}
			break;
		}
		GlobalSettings.selectionEnabled = state;
	}
}
