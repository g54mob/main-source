using System.Collections;
using UnityEngine;

public class CameraZoomAndMove : MonoBehaviour
{
	private Camera cam;

	public int scale = 2;

	private int PPU = 16;

	[SerializeField]
	private StickyCanvas stickyCanvas;

	[SerializeField]
	private RectTransform outOfFrameBarBottom;

	[SerializeField]
	private RectTransform outOfFrameBarSide;

	[SerializeField]
	private GameObject outOfFrameBars;

	[SerializeField]
	private DisplayChanger displayChanger;

	private Vector2 mouseClickPos;

	private Vector2 mouseCurrentPos;

	[SerializeField]
	private RectTransform tooltip;

	[SerializeField]
	private RectTransform icontip;

	[SerializeField]
	private RectTransform signtip;

	public void Start()
	{
		cam = GetComponent<Camera>();
		SaveData.ins.taskbarHeight = CheckTaskbarHeightIsWithinBounds(SaveData.ins.taskbarHeight);
		SaveData.ins.sidebarWidth = CheckSidebarWidthIsWithinBounds(SaveData.ins.sidebarWidth);
		CalculateInitialScale();
		UpdateCameraPosition(0);
		UpdateCameraPositionSidebar(0);
		CalculateZoom();
		CalculateMove();
	}

	public void Restart()
	{
		if (!SaveData.ins.verticalMode)
		{
			stickyCanvas.transform.position = new Vector3(0f, 0.25f, 90f);
		}
		else
		{
			stickyCanvas.transform.position = new Vector3(0f, 0f, 90f);
		}
		if (SaveData.ins.transparencyMode == 3)
		{
			stickyCanvas.transform.position = new Vector3(0f, 0f, 90f);
		}
		base.transform.position = new Vector3(0f, 0.5f, -10f);
		Start();
	}

	private IEnumerator DelayCalculations()
	{
		yield return 0;
		outOfFrameBars.SetActive(value: false);
		CalculateInitialScale();
		CalculateZoom();
		CalculateMove();
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
		{
			SetInitialDragAnchor();
		}
		if (Input.GetMouseButton(1) || Input.GetMouseButton(2))
		{
			DragCamera();
		}
		if (!GameManager.ins.qualityUpdate)
		{
			return;
		}
		if (GameManager.ins.canUseLetterShortcuts && Input.GetKeyDown(KeyCode.M))
		{
			ZoomIn(inOut: true);
		}
		if (GameManager.ins.canUseLetterShortcuts && Input.GetKeyDown(KeyCode.N))
		{
			ZoomIn(inOut: false);
		}
		if (SaveData.ins.verticalMode)
		{
			if (GameManager.ins.canUseLetterShortcuts && Input.GetKeyDown(KeyCode.LeftArrow) && !GameManager.ins.dev_mode)
			{
				ZoomIn(inOut: true);
			}
			if (GameManager.ins.canUseLetterShortcuts && Input.GetKeyDown(KeyCode.RightArrow) && !GameManager.ins.dev_mode)
			{
				ZoomIn(inOut: false);
			}
			if (Input.GetKey(KeyCode.UpArrow))
			{
				PanCamera(new Vector3(0f, 1f, 0f));
			}
			if (Input.GetKey(KeyCode.DownArrow))
			{
				PanCamera(new Vector3(0f, -1f, 0f));
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				ZoomIn(inOut: true);
			}
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				ZoomIn(inOut: false);
			}
			if (GameManager.ins.canUseLetterShortcuts && Input.GetKey(KeyCode.LeftArrow) && !GameManager.ins.dev_mode)
			{
				PanCamera(new Vector3(-1f, 0f, 0f));
			}
			if (GameManager.ins.canUseLetterShortcuts && Input.GetKey(KeyCode.RightArrow) && !GameManager.ins.dev_mode)
			{
				PanCamera(new Vector3(1f, 0f, 0f));
			}
		}
	}

	private void PanCamera(Vector3 dir)
	{
		int num = 16;
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			num = 48;
		}
		base.transform.position += dir * num * Time.deltaTime;
		stickyCanvas.transform.position += dir * num * Time.deltaTime;
		ClampCamera();
	}

	public void ZoomIn(bool inOut)
	{
		if (inOut)
		{
			scale++;
		}
		if (!inOut)
		{
			scale--;
		}
		if (scale > 5)
		{
			scale = 5;
		}
		if (scale < 1)
		{
			scale = 1;
		}
		CalculateZoom();
		CalculateMove();
	}

	private void CalculateInitialScale()
	{
		scale = Mathf.RoundToInt((float)Screen.height / 296f / 2f);
		if (scale < 2)
		{
			scale = 2;
		}
	}

	private IEnumerator SwitchCroppedWindowZoom()
	{
		GetComponent<PlainWindow>().SetZoom();
		yield return 0;
		stickyCanvas.SetCanvasSize(scale);
		yield return 0;
		CalculateMove();
	}

	private void CalculateZoom()
	{
		cam.orthographicSize = (float)Screen.height / (float)(scale * PPU) * 0.5f * (1f - cam.rect.y);
		if (SaveData.ins.transparencyMode == 3)
		{
			if (!SaveData.ins.verticalMode)
			{
				cam.orthographicSize = 5.22f;
			}
			StartCoroutine(SwitchCroppedWindowZoom());
			return;
		}
		stickyCanvas.SetCanvasSize(scale);
		if (SaveData.ins.verticalMode)
		{
			outOfFrameBarBottom.offsetMax = new Vector2(0f, (0f - (float)Screen.height) * 2f / (float)scale);
			outOfFrameBarSide.gameObject.SetActive(value: false);
		}
		else
		{
			outOfFrameBarSide.offsetMin = new Vector2((float)Screen.width * 2f / (float)scale, 0f);
		}
		float num = (float)scale * 0.5f;
		tooltip.localScale = new Vector2(num, num);
		icontip.localScale = new Vector2(num, num);
		signtip.localScale = new Vector2(num, num);
	}

	public void CalculateMove()
	{
		if (SaveData.ins.verticalMode)
		{
			CalculateMoveVertical();
		}
		else
		{
			CalculateMoveHorizontal();
		}
		stickyCanvas.SetCanvasSize(scale);
	}

	private void CalculateMoveHorizontal()
	{
		if (SaveData.ins.transparencyMode == 3)
		{
			cam.transform.position = new Vector3(0f, 0.83f, -10f);
			return;
		}
		float num = scale * PPU;
		float num2 = (float)Screen.height * 0.5f / num * (1f - cam.rect.y);
		float num3 = 140f * (float)scale * 0.5f / num;
		_ = (float)SaveData.ins.taskbarHeight / num;
		_ = (float)SaveData.ins.sidebarWidth / num;
		cam.transform.position = new Vector3(0f, num2 - num3, -10f);
		outOfFrameBarBottom.offsetMin = new Vector2(0f, (float)(-SaveData.ins.taskbarHeight) * 2f / (float)scale);
		outOfFrameBarSide.offsetMax = new Vector2((float)SaveData.ins.sidebarWidth * 2f / (float)scale, 0f);
	}

	private void CalculateMoveVertical()
	{
		float num = scale * PPU;
		float num2 = (float)Screen.width * 0.5f / num * (1f - Mathf.Abs(cam.rect.x));
		float num3 = 252f * (float)scale * 0.5f / num;
		float num4 = (float)SaveData.ins.taskbarHeight / num * 0.5f;
		_ = (float)SaveData.ins.sidebarWidth / num;
		cam.transform.position = new Vector3(0f - num2 + num3, (SaveData.ins.transparencyMode == 3) ? 0f : (0f - num4), -10f);
		outOfFrameBarBottom.offsetMin = new Vector2(0f, (float)(-SaveData.ins.taskbarHeight) * 2f / (float)scale);
		outOfFrameBarSide.offsetMax = new Vector2((float)SaveData.ins.sidebarWidth * 2f / (float)scale, 0f);
	}

	public void UpdateCameraPosition(int value)
	{
		int value2 = SaveData.ins.taskbarHeight + value;
		value2 = CheckTaskbarHeightIsWithinBounds(value2);
		SaveData.ins.taskbarHeight = value2;
		SaveData.ins.SetTaskbarHeightInUI(value2);
		if (SaveData.ins.transparencyMode != 3)
		{
			GameManager.ins.mainCam.rect = new Rect(GameManager.ins.mainCam.rect.x, (float)value2 / (float)Screen.height, GameManager.ins.mainCam.rect.width, GameManager.ins.mainCam.rect.height);
		}
		CalculateZoom();
		CalculateMove();
	}

	public void UpdateCameraPositionSidebar(int value)
	{
		int value2 = SaveData.ins.sidebarWidth + value;
		value2 = CheckSidebarWidthIsWithinBounds(value2);
		SaveData.ins.sidebarWidth = value2;
		SaveData.ins.SetSidebarWidthInUI(value2);
		if (SaveData.ins.transparencyMode != 3)
		{
			GameManager.ins.mainCam.rect = new Rect(0f - (float)value2 / (float)Screen.width, GameManager.ins.mainCam.rect.y, GameManager.ins.mainCam.rect.width, GameManager.ins.mainCam.rect.height);
		}
		CalculateZoom();
		CalculateMove();
	}

	public void UpdateCameraPosition(string value)
	{
		int result = 0;
		if (value == "")
		{
			result = 0;
		}
		else
		{
			int.TryParse(value, out result);
		}
		result = CheckTaskbarHeightIsWithinBounds(result);
		SaveData.ins.taskbarHeight = result;
		SaveData.ins.SetTaskbarHeightInUI(result);
		if (SaveData.ins.transparencyMode != 3)
		{
			GameManager.ins.mainCam.rect = new Rect(GameManager.ins.mainCam.rect.x, (float)result / (float)Screen.height, GameManager.ins.mainCam.rect.width, GameManager.ins.mainCam.rect.height);
		}
		CalculateZoom();
		CalculateMove();
	}

	public void UpdateCameraPositionSidebar(string value)
	{
		int result = 0;
		if (value == "")
		{
			result = 0;
		}
		else
		{
			int.TryParse(value, out result);
		}
		result = CheckSidebarWidthIsWithinBounds(result);
		SaveData.ins.sidebarWidth = result;
		SaveData.ins.SetSidebarWidthInUI(result);
		if (SaveData.ins.transparencyMode != 3)
		{
			GameManager.ins.mainCam.rect = new Rect(0f - (float)result / (float)Screen.width, GameManager.ins.mainCam.rect.y, GameManager.ins.mainCam.rect.width, GameManager.ins.mainCam.rect.height);
		}
		CalculateZoom();
		CalculateMove();
	}

	private int CheckTaskbarHeightIsWithinBounds(int value)
	{
		int num = value;
		if (num < 0)
		{
			num = 0;
		}
		if (num > Screen.currentResolution.height - 296)
		{
			num = Screen.currentResolution.height - 296;
		}
		return num;
	}

	private int CheckSidebarWidthIsWithinBounds(int value)
	{
		int num = value;
		if (num < 0)
		{
			num = 0;
		}
		if (num >= Screen.currentResolution.width - 504)
		{
			num = Screen.currentResolution.width - 504;
		}
		if (num >= Screen.currentResolution.width - 504 - 114)
		{
			if ((bool)BuildInfoPanel.ins)
			{
				BuildInfoPanel.ins.MoveToRightSide();
			}
			if ((bool)CropInfoPanel.ins)
			{
				CropInfoPanel.ins.MoveToRightSide();
			}
		}
		else
		{
			if ((bool)BuildInfoPanel.ins)
			{
				BuildInfoPanel.ins.MoveToLeftSide();
			}
			if ((bool)CropInfoPanel.ins)
			{
				CropInfoPanel.ins.MoveToLeftSide();
			}
		}
		return num;
	}

	private void SetInitialDragAnchor()
	{
		mouseClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	private void DragCamera()
	{
		mouseCurrentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 vector = mouseCurrentPos - mouseClickPos;
		if (SaveData.ins.verticalMode)
		{
			base.transform.position += new Vector3(0f, 0f - vector.y, 0f);
			stickyCanvas.transform.position += new Vector3(0f, 0f - vector.y, 0f);
		}
		else
		{
			base.transform.position += new Vector3(0f - vector.x, 0f, 0f);
			stickyCanvas.transform.position += new Vector3(0f - vector.x, 0f, 0f);
		}
		ClampCamera();
	}

	private void ClampCamera()
	{
		if (SaveData.ins.verticalMode)
		{
			base.transform.position = new Vector3(base.transform.position.x, Mathf.Clamp(base.transform.position.y, -46f, 46f), base.transform.position.z);
			stickyCanvas.transform.position = new Vector3(stickyCanvas.transform.position.x, Mathf.Clamp(stickyCanvas.transform.position.y, -46f + 1.25f / (float)scale, 46f + 1.25f / (float)scale), stickyCanvas.transform.position.z);
		}
		else
		{
			base.transform.position = new Vector3(Mathf.Clamp(base.transform.position.x, -81f, 81f), base.transform.position.y, base.transform.position.z);
			stickyCanvas.transform.position = new Vector3(Mathf.Clamp(stickyCanvas.transform.position.x, -81f, 81f), stickyCanvas.transform.position.y, stickyCanvas.transform.position.z);
		}
	}

	private void OnGUI()
	{
		if (Event.current.type == EventType.ScrollWheel)
		{
			Debug.Log("x: " + Event.current.delta.x);
			Debug.Log("y: " + Event.current.delta.y);
			int num = 16;
			Vector3 zero = Vector3.zero;
			zero = ((!SaveData.ins.verticalMode) ? new Vector3(Event.current.delta.x, 0f, 0f) : Vector3.zero);
			base.transform.position += zero * num * Time.deltaTime;
			stickyCanvas.transform.position += zero * num * Time.deltaTime;
			ClampCamera();
		}
	}
}
