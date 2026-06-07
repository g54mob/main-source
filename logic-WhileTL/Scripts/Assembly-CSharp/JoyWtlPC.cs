using Rewired;
using UnityEngine;

public class JoyWtlPC : JoyWtlInput
{
	public PlayerMouse Mouse;

	public string horizontalAction = "MouseX";

	public string verticalAction = "MouseY";

	public string leftButtonAction = "MouseLeftButton";

	public string rightButtonAction = "MouseRightButton";

	private Vector2 curPosition = Vector2.zero;

	public float distanceFromCamera = 1f;

	public Player Player;

	private float copyPressed;

	private float pastePressed;

	private bool plusPressed;

	private bool minusPressed;

	private bool aPressed;

	private bool xBtnPressed;

	private bool yBtnPressed;

	private bool bBtnPressed;

	private bool dragPressed;

	private bool dragFinished = true;

	private float pressSpeedMulti = 2f;

	private bool cursorMoving;

	private bool areaMoving;

	private bool hardMovingX;

	private bool hardMovingY;

	private int areaMoveCou;

	private int cursorMoveCou;

	public float defaultSpeed = 1f;

	public float maxSpeed = 0.5f;

	public float speedPerSec = 0.005f;

	private int clickCount;

	private float lastTimeClicked = -1f;

	public float LastInputTimer = float.MinValue;

	public override void Init()
	{
		inited = true;
		Mouse = PlayerMouse.Factory.Create();
		Mouse.playerId = 0;
		Mouse.xAxis.actionName = horizontalAction;
		Mouse.yAxis.actionName = verticalAction;
		Mouse.leftButton.actionName = leftButtonAction;
		Mouse.pointerSpeed = 1f;
		Mouse.screenPosition = new Vector2((float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
		curPosition = Mouse.screenPosition;
		Mouse.ScreenPositionChangedEvent += OnScreenPositionChanged;
		OnScreenPositionChanged(Mouse.screenPosition);
		Player = ReInput.players.GetPlayer(0);
		dragFinished = true;
	}

	private void OnScreenPositionChanged(Vector2 position)
	{
		if (Logic.GetModel() != null && !Logic.GetModel().CurInputDeviceIsController)
		{
			cursorDelta = position - curPosition;
			cursorMove = cursorDelta.sqrMagnitude > 0.01f;
			if (curPosition != position)
			{
				curPosition = position;
				Mouse.screenPosition = position;
			}
		}
	}

	private void ReadInput()
	{
		if (Logic.GetModel() == null || Logic.GetModel().globalSaves == null || (Logic.GetModel().globalSaves.ForcedDisableController && !Logic.IsSteamDeckRunning()))
		{
			return;
		}
		cursorDelta = Vector3.zero;
		cursorDelta.x = Player.GetAxis("MouseX");
		cursorDelta.y = Player.GetAxis("MouseY");
		float num = 0f;
		float num2 = 0f;
		bool buttonDown = Player.GetButtonDown("MouseLeftButton");
		bool buttonUp = Player.GetButtonUp("MouseLeftButton");
		bool button = Player.GetButton("MouseLeftButton");
		areaMoveDelta = Vector3.zero;
		areaMoveDelta.x = Player.GetAxis("RightStickX");
		areaMoveDelta.y = Player.GetAxis("RightStickY");
		bool flag = areaMoveDelta.sqrMagnitude > 0.01f;
		areaMoveStart = !areaMoving && flag;
		areaMove = areaMoving && flag;
		areaMoveEnd = areaMoving && !flag;
		areaMoving = flag;
		bool button2 = Player.GetButton("LeftStick");
		bool button3 = Player.GetButton("RightStick");
		bool button4 = Player.GetButton("PadUp");
		bool button5 = Player.GetButton("PadDown");
		bool button6 = Player.GetButton("PadLeft");
		bool button7 = Player.GetButton("PadRight");
		if (button3)
		{
			areaMoveDelta *= pressSpeedMulti;
		}
		if (button2)
		{
			cursorDelta *= pressSpeedMulti;
		}
		areaMoveDelta *= Logic.GetModel().globalSaves.cursorJoyConSens;
		cursorDelta *= Logic.GetModel().globalSaves.cursorJoyConSens;
		downArrow = button5;
		if (button5)
		{
			cursorDelta.y += -1f;
		}
		upArrow = button4;
		if (button4)
		{
			cursorDelta.y += 1f;
		}
		leftArrow = button6;
		if (button6)
		{
			cursorDelta.x += -1f;
		}
		rightArrow = button7;
		if (button7)
		{
			cursorDelta.x += 1f;
		}
		bool flag2 = cursorDelta.sqrMagnitude > 0.01f;
		cursorMove = cursorDelta.sqrMagnitude > 0.01f;
		areaMoveDelta *= Mathf.Min(maxSpeed, defaultSpeed + speedPerSec / (float)Application.targetFrameRate * (float)areaMoveCou);
		cursorDelta *= Mathf.Min(maxSpeed, defaultSpeed + speedPerSec / (float)Application.targetFrameRate * (float)cursorMoveCou);
		_ = areaMoveDelta.sqrMagnitude;
		bool flag3 = areaMoveDelta.sqrMagnitude > 0.01f;
		hardAreaMoveStartX = !hardMovingX && flag3 && Mathf.Abs(areaMoveDelta.x) > 0.4f;
		hardAreaMoveX = hardMovingX && flag3 && Mathf.Abs(areaMoveDelta.x) > 0.4f;
		hardMovingX = flag3 && Mathf.Abs(areaMoveDelta.x) > 0.4f;
		hardAreaMoveStartY = !hardMovingY && flag3 && Mathf.Abs(areaMoveDelta.y) > 0.4f;
		hardAreaMoveY = hardMovingY && flag3 && Mathf.Abs(areaMoveDelta.y) > 0.4f;
		hardMovingY = flag3 && (double)Mathf.Abs(areaMoveDelta.y) > 0.4;
		cursorMoveStart = !cursorMoving && flag2;
		cursorMove = cursorMoving && flag2;
		cursorMoveEnd = cursorMoving && !flag2;
		cursorMoving = flag2;
		if (flag2)
		{
			cursorMoveCou++;
		}
		else
		{
			cursorMoveCou = 0;
		}
		if (cursorDelta.sqrMagnitude > 0f)
		{
			LastInputTimer = Time.unscaledTime;
		}
		if (Input.GetAxis("Mouse X") != 0f || Input.GetAxis("Mouse Y") != 0f)
		{
			LastInputTimer = Time.unscaledTime;
		}
		if (Player.GetAnyButton())
		{
			LastInputTimer = Time.unscaledTime;
		}
		if (Logic.GetModel().CurInputDeviceIsController && Logic.GetProgram().cursor.lastConnection > LastInputTimer)
		{
			return;
		}
		lmbDown = buttonDown || (button && !lmbPressed);
		lmbUp = buttonUp || (!button && lmbPressed);
		lmbPressed = button;
		zoomIn = Player.GetAxis("ZoomIn");
		zoomOut = Player.GetAxis("ZoomOut");
		num = Player.GetAxis("Copy");
		num2 = Player.GetAxis("Paste");
		bool button8 = Player.GetButton("Undo");
		bool button9 = Player.GetButton("Redo");
		undo = !minusPressed && button8;
		redo = !plusPressed && button9;
		undo = undo || Player.GetButtonDown("Undo");
		redo = redo || Player.GetButtonDown("Redo");
		minusPressed = button8;
		plusPressed = button9;
		copy = Mathf.Abs(copyPressed) < 0.01f && Mathf.Abs(num) >= 0.01f;
		paste = Mathf.Abs(pastePressed) < 0.01f && Mathf.Abs(num2) >= 0.01f;
		pastePressed = num2;
		copyPressed = num;
		bool curPressed = Player.GetButton("Top");
		bool curPressed2 = Player.GetButton("Left");
		bool curPressed3 = Player.GetButton("Right");
		BtnPressLogic(ref xDown, ref xPressed, ref xUp, ref curPressed, ref xBtnPressed);
		BtnPressLogic(ref yDown, ref yPressed, ref yUp, ref curPressed2, ref yBtnPressed);
		if ((bBtnPressed && !curPressed3) || Player.GetButtonUp("Right"))
		{
			bPressed = false;
			bUp = false;
			bDown = false;
			if (Logic.GetModel().Keyboard.gameObject.activeSelf)
			{
				Logic.GetModel().Keyboard.Close();
				return;
			}
		}
		BtnPressLogic(ref bDown, ref bPressed, ref bUp, ref curPressed3, ref bBtnPressed);
		xDown = xDown || Player.GetButtonDown("Top");
		yDown = yDown || Player.GetButtonDown("Left");
		bDown = bDown || Player.GetButtonDown("Right");
		xUp = xUp || Player.GetButtonUp("Top");
		yUp = yUp || Player.GetButtonUp("Left");
		bUp = bUp || Player.GetButtonUp("Right");
		ControllerType lastActiveControllerType = ReInput.controllers.GetLastActiveControllerType();
		bool flag4 = false;
		switch (lastActiveControllerType)
		{
		case ControllerType.Mouse:
			flag4 = true;
			break;
		case ControllerType.Keyboard:
			flag4 = true;
			break;
		}
		string text = "PC";
		if (!flag4)
		{
			text = "CONTROLLER";
			string text2 = ReInput.controllers.GetLastActiveController().name.ToLowerInvariant();
			if (text2.Contains("xinput") || text2.Contains("xbox"))
			{
				text = "XBOX";
			}
			else if (text2.Contains("sony") || text2.Contains("dualshock") || text2.Contains("ps3"))
			{
				text = "PS";
			}
		}
		if (text != Logic.GetModel().CurInputDevice)
		{
			Logic.GetModel().InputDeviceChanged.Invoke(text);
		}
		Logic.GetModel().CurInputDevice = text;
		Logic.GetModel().CurInputDeviceIsController = !flag4;
		if (dragFinished)
		{
			dragEnd = false;
			dragStart = false;
			drag = false;
			if (lmbPressed && cursorMove)
			{
				dragFinished = false;
				dragStart = true;
			}
		}
		else
		{
			if (dragStart)
			{
				dragStart = false;
				drag = lmbPressed && cursorMove;
			}
			dragEnd = false;
			if (!lmbPressed)
			{
				dragEnd = true;
				drag = false;
				dragFinished = true;
			}
		}
		if (lmbUp)
		{
			if (Time.unscaledTime - lastTimeClicked <= multiTapWaitTime)
			{
				lastTimeClicked = Time.unscaledTime;
				clickCount++;
			}
			else
			{
				lastTimeClicked = Time.unscaledTime;
				clickCount = 1;
			}
			cursorDoubleClickUp = clickCount == 2;
		}
		if (Time.unscaledTime - lastTimeClicked > multiTapWaitTime)
		{
			cursorDoubleClickUp = false;
			clickCount = 0;
		}
	}

	private void BtnPressLogic(ref bool down, ref bool pressed, ref bool up, ref bool curPressed, ref bool globalPressed)
	{
		down = !globalPressed & curPressed;
		pressed = curPressed & globalPressed;
		up = globalPressed && !curPressed;
		globalPressed = curPressed;
	}

	private void LateUpdate()
	{
		if (inited)
		{
			cursorMove = false;
			ReadInput();
		}
	}
}
