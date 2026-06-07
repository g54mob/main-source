using System.Runtime.InteropServices;
using Aux;
using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RewiredCursor : ActiveComponent
{
	private JoyWtlInput input;

	private Vector3 pos = Vector3.one;

	private Rect rect;

	public Image curImg;

	public LayerMask uI;

	private RayCast rayController;

	private Camera mainCam;

	public float moveCursorMulti = 5.75f;

	public GameObject curGo;

	private IPointerEnterHandler[] curPointerEnterHandler;

	private IPointerExitHandler[] curPointerExitHandler;

	private IPointerUpHandler[] curPointerUpHandler;

	private IPointerDownHandler[] curPointerDownHandler;

	private IBeginDragHandler[] curBeginDragHandler;

	private IEndDragHandler[] curEndDragHandler;

	private IDragHandler[] curDragHandler;

	private IPointerEnterHandler[] pointerEnterHandler;

	private IPointerExitHandler[] pointerExitHandler;

	private IPointerUpHandler[] pointerUpHandler;

	private IPointerDownHandler[] pointerDownHandler;

	private Vector2 delta = Vector2.zero;

	public GameObject currentCanvas;

	private RectTransform curCanvasRect;

	public Rect curWorldRect = Rect.zero;

	private GameObject defaultCanvas;

	private bool ignoreUpClick;

	private GameObject prevCanvas;

	private Scrollbar curBar;

	private Slider curSlider;

	private float sliderDx;

	private float sliderDy;

	private RectTransform curHandler;

	private Dropdown curDropdown;

	private RectTransform curRect;

	private int checkRate = 10;

	private int checkCounter;

	private float vibrateStart;

	public float vibrateTime = 0.1f;

	public float lastConnection = float.MinValue;

	public Texture2D cursorSprite;

	public Texture2D emptyCursorSprite;

	[DllImport("user32.dll")]
	private static extern bool SetCursorPos(int X, int Y);

	public bool Visible()
	{
		if (Model.steamDeckRunning)
		{
			return false;
		}
		return curImg.enabled;
	}

	protected override void OnInit()
	{
		base.OnInit();
		RectTransform component = base.gameObject.transform.transform.parent.GetComponent<RectTransform>();
		rect = Helper.GetWorldRect(component);
		curImg = base.gameObject.GetComponentInChildren<Image>();
		curImg.enabled = false;
		defaultCanvas = base.transform.root.gameObject;
		currentCanvas = defaultCanvas;
		SetCanvas(defaultCanvas);
		mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
		rayController = currentCanvas.GetComponent<RayCast>();
		curCanvasRect = currentCanvas.GetComponent<RectTransform>();
		curWorldRect = Helper.GetWorldRect(curCanvasRect);
		if (Logic.IsSteamDeckRunning())
		{
			Object.DestroyImmediate(base.gameObject);
		}
		ReInput.ControllerConnectedEvent += OnControllerConnected;
		ReInput.ControllerDisconnectedEvent += OnControllerDisconnected;
		ReInput.ControllerPreDisconnectEvent += OnControllerPreDisconnect;
	}

	private void OnControllerConnected(ControllerStatusChangedEventArgs args)
	{
		if (ActiveComponent.Model.globalSaves.ForcedDisableController && !Logic.IsSteamDeckRunning())
		{
			Logic.GetModel().InputDeviceChanged.Invoke("PC");
			Logic.GetModel().CurInputDevice = "PC";
			Debug.LogError("C");
			Logic.GetModel().CurInputDeviceIsController = false;
			Cursor.SetCursor(cursorSprite, Vector2.zero, CursorMode.Auto);
			curImg.enabled = false;
			Cursor.visible = true;
			return;
		}
		if (args.controllerType == ControllerType.Keyboard)
		{
			Logic.GetModel().InputDeviceChanged.Invoke("PC");
			Logic.GetModel().CurInputDevice = "PC";
			Debug.LogError("C");
			Logic.GetModel().CurInputDeviceIsController = false;
			return;
		}
		if (args.controllerType == ControllerType.Mouse)
		{
			Logic.GetModel().InputDeviceChanged.Invoke("PC");
			Logic.GetModel().CurInputDevice = "PC";
			Debug.LogError("C");
			Logic.GetModel().CurInputDeviceIsController = false;
			return;
		}
		lastConnection = Time.unscaledTime;
		string text = "CONTROLLER";
		string text2 = args.controller.name.ToLowerInvariant();
		Debug.LogError(text2 + " Connected");
		if (text2.Contains("xinput") || text2.Contains("xbox"))
		{
			text = "XBOX";
		}
		else if (text2.Contains("sony") || text2.Contains("dualshock") || text2.Contains("ps3"))
		{
			text = "PS";
		}
		if (!ActiveComponent.Model.CurInputDeviceIsController)
		{
			Vector2 screenPosition = (ActiveComponent.Program.joyInput as JoyWtlPC).Mouse.screenPosition;
			Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, 1f));
			base.transform.position = position;
		}
		Logic.GetModel().CurInputDeviceIsController = true;
		Logic.GetModel().InputDeviceChanged.Invoke(text);
		Logic.GetModel().CurInputDevice = text;
		Cursor.SetCursor(emptyCursorSprite, Vector2.zero, CursorMode.Auto);
		curImg.enabled = true;
	}

	private void OnControllerDisconnected(ControllerStatusChangedEventArgs args)
	{
		if (!Logic.GetModel().globalSaves.ForcedDisableController || Logic.IsSteamDeckRunning())
		{
			if (ActiveComponent.Model.CurInputDeviceIsController)
			{
				Vector2Int vector2Int = MonitorUtils.WorldToMonitorPoint(base.transform.position);
				SetCursorPos(vector2Int.x, vector2Int.y);
				Cursor.SetCursor(cursorSprite, Vector2.zero, CursorMode.Auto);
				curImg.enabled = false;
				Cursor.visible = true;
			}
			Logic.GetModel().InputDeviceChanged.Invoke("PC");
			Logic.GetModel().CurInputDevice = "PC";
			Logic.GetModel().CurInputDeviceIsController = false;
			Debug.LogError("D");
		}
	}

	private void OnControllerPreDisconnect(ControllerStatusChangedEventArgs args)
	{
		if (!Logic.GetModel().globalSaves.ForcedDisableController || Logic.IsSteamDeckRunning())
		{
			if (ActiveComponent.Model.CurInputDeviceIsController)
			{
				Vector2Int vector2Int = MonitorUtils.WorldToMonitorPoint(base.transform.position);
				SetCursorPos(vector2Int.x, vector2Int.y);
				Cursor.SetCursor(cursorSprite, Vector2.zero, CursorMode.Auto);
				curImg.enabled = false;
				Cursor.visible = true;
			}
			Logic.GetModel().InputDeviceChanged.Invoke("PC");
			Logic.GetModel().CurInputDevice = "PC";
			Logic.GetModel().CurInputDeviceIsController = false;
		}
	}

	private void UpdateCurGo(GameObject go)
	{
		new PointerEventData(EventSystem.current).position = mainCam.WorldToScreenPoint(base.transform.position);
		if (!(go != curGo))
		{
			return;
		}
		if (curGo != null && curPointerExitHandler != null)
		{
			IPointerExitHandler[] array = curPointerExitHandler;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnPointerExit(null);
			}
		}
		curPointerEnterHandler = null;
		curPointerExitHandler = null;
		curBar = null;
		curRect = null;
		curSlider = null;
		curDropdown = null;
		if (go != null)
		{
			curBar = go.GetComponent<Scrollbar>();
			if (curBar != null)
			{
				curHandler = curBar.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
			}
			curRect = go.GetComponent<RectTransform>();
			curSlider = go.GetComponent<Slider>();
			if (curSlider != null && go.GetComponent<BoundedSlider>() == null)
			{
				curHandler = curSlider.transform.GetChild(curSlider.transform.childCount - 1).GetChild(0).GetComponent<RectTransform>();
				Vector3[] worldCorners = Helper.GetWorldCorners(curRect);
				Vector3[] worldCorners2 = Helper.GetWorldCorners(curHandler);
				sliderDx = mainCam.WorldToScreenPoint(worldCorners[2]).x - mainCam.WorldToScreenPoint(worldCorners[1]).x;
				sliderDx -= mainCam.WorldToScreenPoint(worldCorners2[2]).x - mainCam.WorldToScreenPoint(worldCorners2[1]).x;
				sliderDy = mainCam.WorldToScreenPoint(worldCorners[1]).y - mainCam.WorldToScreenPoint(worldCorners[0]).y;
				sliderDy -= mainCam.WorldToScreenPoint(worldCorners2[1]).y - mainCam.WorldToScreenPoint(worldCorners2[0]).y;
			}
			curDropdown = go.GetComponent<Dropdown>();
			pointerEnterHandler = go.GetComponents<IPointerEnterHandler>();
			pointerExitHandler = go.GetComponents<IPointerExitHandler>();
			IPointerEnterHandler[] array2 = pointerEnterHandler;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].OnPointerEnter(null);
			}
			curPointerEnterHandler = pointerEnterHandler;
			curPointerExitHandler = pointerExitHandler;
			if (go.layer != 12)
			{
				Selectable component = go.GetComponent<Selectable>();
				if (component != null && component.enabled && ActiveComponent.Model.globalSaves.vibration > 0)
				{
					bool flag = false;
					switch (ActiveComponent.Model.globalSaves.vibration)
					{
					case 1:
						flag = go.GetComponent<Socket>() != null;
						break;
					case 2:
						flag = go.GetComponent<Socket>() != null || curDropdown != null;
						break;
					case 3:
						flag = OnDefaultCanvas() && curDropdown == null;
						break;
					case 4:
						flag = true;
						break;
					}
					if (flag)
					{
						vibrateStart = Time.unscaledTime;
						ActiveComponent.Program.joyInputPC.Player.SetVibration(1, 0.011f, vibrateTime);
					}
				}
			}
		}
		curGo = go;
	}

	public void SetActive(bool state)
	{
		if (!Model.steamDeckRunning && ActiveComponent.Model.CurInputDeviceIsController)
		{
			curImg.enabled = state;
		}
	}

	public void SetPosition(Vector3 pos)
	{
		if (!Model.steamDeckRunning && !(this == null) && !(base.transform == null))
		{
			pos.y -= Helper.GetWorldRect(base.transform.root.GetComponent<RectTransform>()).height * 0.015f;
			pos.z = 0f;
			base.transform.position = pos;
		}
	}

	public bool OnDefaultCanvas()
	{
		return defaultCanvas == currentCanvas;
	}

	public void SetCanvas(GameObject canvas)
	{
		if (Model.steamDeckRunning || ActiveComponent.Model == null || (ActiveComponent.Model.construction != null && (ActiveComponent.Model.construction.attached != null || ActiveComponent.Model.currentChain != null)))
		{
			return;
		}
		if (!curImg.enabled)
		{
			canvas = null;
		}
		if (Input.touchCount > 0)
		{
			canvas = null;
		}
		if ((!(canvas != null) || !(canvas != defaultCanvas) || !(Logic.currentBlocker == null)) && !(canvas == currentCanvas))
		{
			if (canvas == null)
			{
				currentCanvas = defaultCanvas;
			}
			else
			{
				currentCanvas = canvas;
			}
			base.gameObject.transform.SetParent(currentCanvas.transform);
			rayController = currentCanvas.GetComponent<RayCast>();
			curCanvasRect = currentCanvas.GetComponent<RectTransform>();
			curWorldRect = Helper.GetWorldRect(curCanvasRect);
		}
	}

	public void HideAndResetCanvas()
	{
		if (!OnDefaultCanvas())
		{
			Dropdown component = currentCanvas.transform.parent.GetComponent<Dropdown>();
			SetCanvas(null);
			component.Hide();
			curGo = null;
			UpdateCurGo(curGo);
		}
	}

	private void UpdateCursorVisibility()
	{
		if (Logic.IsSteamDeckRunning() || (Logic.GetModel().globalSaves.ForcedDisableController && !Logic.IsSteamDeckRunning()))
		{
			return;
		}
		bool flag = false;
		if (ActiveComponent.Model.CurInputDeviceIsController)
		{
			if (lastConnection > ActiveComponent.Program.joyInputPC.LastInputTimer)
			{
				flag = false;
				return;
			}
			switch (ReInput.controllers.GetLastActiveControllerType())
			{
			case ControllerType.Mouse:
				flag = true;
				break;
			case ControllerType.Keyboard:
				flag = true;
				break;
			}
		}
		else
		{
			switch (ReInput.controllers.GetLastActiveControllerType())
			{
			case ControllerType.Mouse:
				flag = true;
				break;
			case ControllerType.Keyboard:
				flag = true;
				break;
			}
		}
		if (flag || (!Logic.Controller.Transition.gameObject.activeInHierarchy && !ActiveComponent.Model.LoadingSave))
		{
			ActiveComponent.Model.CurInputDeviceIsController = !flag;
			if (!curImg.enabled && !flag)
			{
				Vector2 screenPosition = (ActiveComponent.Program.joyInput as JoyWtlPC).Mouse.screenPosition;
				Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, 1f));
				base.transform.position = position;
				Cursor.SetCursor(emptyCursorSprite, Vector2.zero, CursorMode.Auto);
			}
			if (curImg.enabled && flag)
			{
				Vector2Int vector2Int = MonitorUtils.WorldToMonitorPoint(base.transform.position);
				SetCursorPos(vector2Int.x, vector2Int.y);
				Cursor.SetCursor(cursorSprite, Vector2.zero, CursorMode.Auto);
			}
			curImg.enabled = !flag;
			Cursor.visible = flag;
		}
	}

	private void LateUpdate()
	{
		if (base.IsInited && !(ActiveComponent.Program == null) && ActiveComponent.Model != null && ActiveComponent.Model.globalSaves != null)
		{
			UpdateCursorVisibility();
		}
	}

	private void Update()
	{
		if (!base.IsInited || ActiveComponent.Program == null || ActiveComponent.Model == null || ActiveComponent.Model.globalSaves == null || (Logic.GetModel().globalSaves.ForcedDisableController && !Logic.IsSteamDeckRunning()))
		{
			return;
		}
		UpdateCursorVisibility();
		if (!ActiveComponent.Model.CurInputDeviceIsController)
		{
			return;
		}
		if (currentCanvas == null || !currentCanvas.gameObject.activeInHierarchy)
		{
			SetCanvas(null);
		}
		if (input == null)
		{
			if (ActiveComponent.Program.joyInput != null && ActiveComponent.Program.joyInput.inited)
			{
				input = ActiveComponent.Program.joyInput;
			}
			return;
		}
		if (currentCanvas == null || !currentCanvas.gameObject.activeInHierarchy)
		{
			Dropdown dropdown = curDropdown;
			SetCanvas(defaultCanvas);
			if (dropdown != null)
			{
				dropdown.Hide();
			}
		}
		if (input.cursorMove && Logic.openedDropdown != null && OnDefaultCanvas())
		{
			SetCanvas(Logic.openedCanvas);
		}
		if (input.areaMove)
		{
			HideAndResetCanvas();
		}
		if (input.cursorMove)
		{
			if (!curImg.enabled)
			{
				curImg.enabled = true;
				Cursor.SetCursor(emptyCursorSprite, Vector2.zero, CursorMode.Auto);
			}
			Vector3 position = base.transform.position;
			Vector3 cursorDelta = input.cursorDelta;
			if (curGo != null && !input.dragStart && !input.drag && !input.dragEnd && ActiveComponent.Program.joyInput.GetCurCursorMulty() > 1f)
			{
				cursorDelta /= ActiveComponent.Program.joyInput.GetCurCursorMulty();
				cursorDelta *= 0.9f;
			}
			base.transform.localPosition += cursorDelta * moveCursorMulti;
			pos = base.transform.position;
			pos.x = Mathf.Max(rect.xMin, Mathf.Min(pos.x, rect.xMax));
			pos.y = Mathf.Max(rect.yMin, Mathf.Min(pos.y, rect.yMax));
			base.transform.position = pos;
			Vector3 vector = mainCam.WorldToScreenPoint(base.transform.position);
			delta = vector - mainCam.WorldToScreenPoint(position);
			if (!input.dragStart && !input.drag && !input.dragEnd)
			{
				GameObject go = rayController.RayCastFromPoint(vector);
				UpdateCurGo(go);
			}
			Vector3 zero = Vector3.zero;
			if (curGo != null && !input.dragStart && !input.drag && !input.dragEnd)
			{
				Vector3 vector2 = curGo.transform.position - base.transform.position;
				Vector3 vector3 = mainCam.WorldToScreenPoint(curGo.transform.position) - mainCam.WorldToScreenPoint(base.transform.position);
				vector3.z = 0f;
				float num = 150f;
				if (vector3.magnitude < num)
				{
					Vector3 vector4 = pos - position;
					if ((double)((vector2.x * vector4.x + vector2.y * vector4.y) / vector2.magnitude / vector4.magnitude) > 0.2)
					{
						zero = vector2 / vector2.magnitude * vector4.magnitude;
						pos = position + vector4 * 0.5f + zero * 0.5f;
						pos.z = 0f;
						pos.x = Mathf.Max(rect.xMin, Mathf.Min(pos.x, rect.xMax));
						pos.y = Mathf.Max(rect.yMin, Mathf.Min(pos.y, rect.yMax));
						base.transform.position = pos;
					}
				}
			}
		}
		else
		{
			if (curImg.enabled && !input.dragStart && !input.drag && !input.dragEnd)
			{
				if (checkCounter % checkRate == 0 && OnDefaultCanvas())
				{
					Vector3 position2 = mainCam.WorldToScreenPoint(base.transform.position);
					GameObject go2 = rayController.RayCastFromPoint(position2);
					UpdateCurGo(go2);
					checkCounter = 1;
				}
				checkCounter++;
			}
			delta = Vector2.zero;
		}
		if ((input.dragStart || input.drag || input.dragEnd) && OnDefaultCanvas())
		{
			if (curBar == null && curSlider == null && ActiveComponent.Model.currentChain != null && ActiveComponent.Model.construction.attached == null)
			{
				Vector3 position3 = mainCam.WorldToScreenPoint(base.transform.position);
				GameObject go3 = rayController.RayCastFromPoint(position3, dragCheck: true);
				UpdateCurGo(go3);
			}
			if (curGo != null)
			{
				if (curBar == null && curSlider == null)
				{
					if (input.dragStart)
					{
						PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
						pointerEventData.position = mainCam.WorldToScreenPoint(base.transform.position);
						ExecuteEvents.Execute(curGo, pointerEventData, ExecuteEvents.beginDragHandler);
						curDragHandler = curGo.GetComponents<IDragHandler>();
						curEndDragHandler = curGo.GetComponents<IEndDragHandler>();
					}
					if (input.drag && curDragHandler != null)
					{
						PointerEventData pointerEventData2 = new PointerEventData(EventSystem.current);
						pointerEventData2.position = mainCam.WorldToScreenPoint(base.transform.position);
						pointerEventData2.delta = delta;
						IDragHandler[] array = curDragHandler;
						for (int i = 0; i < array.Length; i++)
						{
							array[i].OnDrag(pointerEventData2);
						}
					}
					if (input.dragEnd && curEndDragHandler != null)
					{
						PointerEventData pointerEventData3 = new PointerEventData(EventSystem.current);
						pointerEventData3.position = mainCam.WorldToScreenPoint(base.transform.position);
						IEndDragHandler[] array2 = curEndDragHandler;
						for (int i = 0; i < array2.Length; i++)
						{
							array2[i].OnEndDrag(pointerEventData3);
						}
					}
				}
				else
				{
					if (!input.drag)
					{
						return;
					}
					if (curHandler != null && curSlider != null)
					{
						if (curSlider.direction == Slider.Direction.BottomToTop)
						{
							curSlider.value += delta.y / sliderDy * (curSlider.maxValue - curSlider.minValue);
						}
						if (curSlider.direction == Slider.Direction.LeftToRight)
						{
							curSlider.value += delta.x / sliderDx * (curSlider.maxValue - curSlider.minValue);
						}
					}
					else if (curBar != null)
					{
						if (curBar.direction == Scrollbar.Direction.BottomToTop)
						{
							curBar.value += delta.y / curRect.rect.height;
						}
						if (curBar.direction == Scrollbar.Direction.LeftToRight)
						{
							curBar.value += delta.x / curRect.rect.width;
						}
					}
				}
			}
			else if (curGo == null && input.dragEnd && ActiveComponent.Model.currentChain != null && ActiveComponent.Model.currentChain.GetComponent<Chain>().BufferObject == null)
			{
				ActiveComponent.Model.currentChain.GetComponent<Chain>().DestroyGameObject();
			}
		}
		else
		{
			if (!curImg.enabled || !(ActiveComponent.Model.currentChain == null))
			{
				return;
			}
			if (ActiveComponent.Program.joyInput.bDown)
			{
				HideAndResetCanvas();
			}
			else if (ActiveComponent.Program.joyInput.lmbDown)
			{
				if (curGo != null)
				{
					LidarBinarySwitch component = curGo.GetComponent<LidarBinarySwitch>();
					if (component != null)
					{
						component.OnPointerClick(new PointerEventData(EventSystem.current));
						ignoreUpClick = true;
					}
					else if (curDropdown == null || OnDefaultCanvas())
					{
						PointerEventData pointerEventData4 = new PointerEventData(EventSystem.current);
						pointerEventData4.button = PointerEventData.InputButton.Left;
						pointerEventData4.position = mainCam.WorldToScreenPoint(base.transform.position);
						ExecuteEvents.Execute(curGo, pointerEventData4, ExecuteEvents.pointerEnterHandler);
						if (!OnDefaultCanvas())
						{
							ExecuteEvents.Execute(curGo, pointerEventData4, ExecuteEvents.submitHandler);
							_ = curDropdown;
							SetCanvas(defaultCanvas);
							curGo = null;
							ignoreUpClick = true;
						}
					}
					else
					{
						Dropdown dropdown2 = curDropdown;
						SetCanvas(defaultCanvas);
						if (dropdown2 != null)
						{
							dropdown2.Hide();
						}
						ignoreUpClick = true;
					}
				}
				else if (!OnDefaultCanvas() && !Helper.GetWorldRect(curCanvasRect).Contains(Logic.GetMouseInWorld()))
				{
					Dropdown component2 = curCanvasRect.gameObject.transform.parent.GetComponent<Dropdown>();
					SetCanvas(defaultCanvas);
					if (component2 != null)
					{
						component2.Hide();
					}
					ignoreUpClick = true;
				}
			}
			else
			{
				if (!ActiveComponent.Program.joyInput.lmbUp)
				{
					return;
				}
				if (!ignoreUpClick)
				{
					if (curGo != null)
					{
						if (currentCanvas != defaultCanvas)
						{
							Dropdown dropdown3 = curDropdown;
							SetCanvas(defaultCanvas);
							if (dropdown3 != null)
							{
								dropdown3.Hide();
							}
							ignoreUpClick = true;
						}
						PointerEventData pointerEventData5 = new PointerEventData(EventSystem.current);
						pointerEventData5.button = PointerEventData.InputButton.Left;
						pointerEventData5.position = mainCam.WorldToScreenPoint(base.transform.position);
						if (curSlider != null)
						{
							Vector3[] worldCorners = Helper.GetWorldCorners(curRect);
							float num2 = (base.transform.position.x - worldCorners[1].x) / (worldCorners[2].x - worldCorners[1].x);
							curSlider.value = curSlider.minValue + num2 * (curSlider.maxValue - curSlider.minValue);
							return;
						}
						if (curBar != null)
						{
							Vector3[] worldCorners2 = Helper.GetWorldCorners(curRect);
							Vector3[] worldCorners3 = Helper.GetWorldCorners(curHandler);
							float num3 = worldCorners3[1].y - worldCorners3[0].y;
							float value = 1f - (worldCorners2[1].y - base.transform.position.y) / (worldCorners2[1].y - worldCorners2[0].y - num3 / 2f);
							curBar.value = value;
							return;
						}
						if (!OnDefaultCanvas())
						{
							Dropdown dropdown4 = curDropdown;
							SetCanvas(defaultCanvas);
							if (dropdown4 != null)
							{
								dropdown4.Hide();
							}
							curGo = null;
						}
						else if (curGo.activeInHierarchy)
						{
							if (curGo.name.Contains("Chain"))
							{
								curGo.GetComponent<Chain>().OnPointerClick(pointerEventData5);
							}
							else if (ActiveComponent.Model.construction == null || !ActiveComponent.Model.construction.testMode || curDropdown == null)
							{
								ExecuteEvents.Execute(curGo, pointerEventData5, ExecuteEvents.submitHandler);
								ExecuteEvents.Execute(curGo, pointerEventData5, ExecuteEvents.pointerExitHandler);
							}
						}
					}
					else if (!OnDefaultCanvas() && !Helper.GetWorldRect(curCanvasRect).Contains(Logic.GetMouseInWorld()))
					{
						Dropdown dropdown5 = curDropdown;
						SetCanvas(defaultCanvas);
						if (dropdown5 != null)
						{
							dropdown5.Hide();
						}
					}
				}
				ignoreUpClick = false;
			}
		}
	}
}
