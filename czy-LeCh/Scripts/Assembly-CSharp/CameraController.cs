using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
	public static CameraController Instance;

	private GameControls gameControls;

	[SerializeField]
	private float minOrtographicSize;

	[SerializeField]
	private float maxOrtographicSize;

	[SerializeField]
	private float zoomValue;

	[SerializeField]
	private float zoomSpeed;

	private void Awake()
	{
		Instance = this;
		gameControls = new GameControls();
	}

	private void OnEnable()
	{
		gameControls.Enable();
	}

	private void OnDisable()
	{
		gameControls.Disable();
	}

	private void Start()
	{
		Camera.main.orthographicSize = zoomValue;
	}

	private void Update()
	{
		if (IsPointerOverUIObject())
		{
			return;
		}
		try
		{
			if (TileUnlockController.Instance.TileUnlockCanvasActive())
			{
				return;
			}
		}
		catch
		{
		}
		zoomValue = Camera.main.orthographicSize;
		float num = gameControls.Game.Zoom.ReadValue<float>();
		if (num > 0f)
		{
			zoomValue -= zoomSpeed;
		}
		if (num < 0f)
		{
			zoomValue += zoomSpeed;
		}
		if (zoomValue < minOrtographicSize)
		{
			zoomValue = minOrtographicSize;
		}
		if (zoomValue > maxOrtographicSize)
		{
			zoomValue = maxOrtographicSize;
		}
		Camera.main.orthographicSize = zoomValue;
	}

	public void ResetZoomValue()
	{
		Camera.main.orthographicSize = 50f;
	}

	public bool IsPointerOverUIObject()
	{
		PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
		pointerEventData.position = GamepadCursor.Instance.GetRelevantCursorPosition();
		List<RaycastResult> list = new List<RaycastResult>();
		EventSystem.current.RaycastAll(pointerEventData, list);
		foreach (RaycastResult item in list)
		{
			if (item.gameObject.GetComponent<RectTransform>() != null)
			{
				return true;
			}
		}
		return false;
	}
}
