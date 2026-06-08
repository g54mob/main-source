using UnityEngine;

public class AsciiMouse : MonoBehaviour, IAsciiObject
{
	private AsciiRenderProcedural _renderer;

	public int x = 5;

	public int y = 5;

	public bool down0;

	public bool up0;

	public bool isDown0;

	public bool isDragging0;

	public bool down1;

	public bool up1;

	public bool isDown1;

	public float down0Duration;

	public float down1Duration;

	public int dragBeginX;

	public int dragBeginY;

	public int dragX;

	public int dragY;

	public int dragAccumulatedX;

	public int dragAccumulatedY;

	public int mouseDragBeginX;

	public int mouseDragBeginY;

	public int mouseDragX;

	public int mouseDragY;

	public int mouseDragAccumulatedX;

	public int mouseDragAccumulatedY;

	public bool subCellIsCursorTop;

	public bool subCellIsCursorBottom;

	public bool subCellIsCursorLeft;

	public bool subCellIsCursorRight;

	private bool down0Buffered;

	private bool up0Buffered;

	private bool down1Buffered;

	private bool up1Buffered;

	private float down0Timestamp;

	private float down1Timestamp;

	private int lastX;

	private int lastY;

	private int lastDragX;

	private int lastDragY;

	private int lastMouseDragX;

	private int lastMouseDragY;

	private bool platformDrawCursor;

	private float lastHyperlinkCheckTime;

	private string[] hyperlinkHand = new string[4] { "#||", "_||..,", "\\`   |", "#\\___/" };

	private string[] hyperlinkHandDown = new string[4] { "#,,", "_||..,", "\\`   |", "#\\___/" };

	private Vector3 lastMousePos;

	private bool firstTime = true;

	private float lastMouseX;

	private float lastMouseY;

	private float hideCursorTime = -1f;

	private static AsciiMouse _singleton;

	public bool isTouch { get; private set; }

	public bool isDrawingOnCurrentPlatform => platformDrawCursor;

	public bool isOverHyperlink { get; private set; }

	public static AsciiMouse singleton => _singleton;

	private void Start()
	{
		platformDrawCursor = Application.platform == RuntimePlatform.LinuxEditor || Application.platform == RuntimePlatform.LinuxPlayer || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.WebGLPlayer;
	}

	private void Update()
	{
		if (!(_renderer == null))
		{
			UpdateIsTouch();
			UpdateMouseHidden();
			UpdateCursorPosition();
			UpdateForHyperlinks();
			if (_getInputDown(0))
			{
				down0Buffered = true;
			}
			if (_getInputUp(0))
			{
				up0Buffered = true;
			}
			if (_getInputDown(1))
			{
				down1Buffered = true;
			}
			if (_getInputUp(1))
			{
				up1Buffered = true;
			}
			lastX = x;
			lastY = y;
		}
	}

	public void Clear()
	{
		down0 = false;
		up0 = false;
		isDown0 = false;
		isDragging0 = false;
		down0Buffered = false;
		up0Buffered = false;
		down1Buffered = false;
		up1Buffered = false;
	}

	public void UpdateTic()
	{
		down0 = false;
		up0 = false;
		down1 = false;
		up1 = false;
		if (down0Buffered)
		{
			down0Buffered = false;
			down0 = true;
			down0Timestamp = Time.realtimeSinceStartup;
			isDown0 = true;
			dragBeginX = x;
			dragBeginY = y;
			lastDragX = x;
			lastDragY = y;
			dragX = (dragY = (dragAccumulatedX = (dragAccumulatedY = 0)));
			mouseDragBeginX = GetMouseX();
			mouseDragBeginY = GetMouseY();
			lastMouseDragX = GetMouseX();
			lastMouseDragY = GetMouseY();
			mouseDragX = (mouseDragY = (mouseDragAccumulatedX = (mouseDragAccumulatedY = 0)));
		}
		if (down1Buffered)
		{
			down1Buffered = false;
			down1 = true;
			down1Timestamp = Time.realtimeSinceStartup;
			isDown1 = true;
		}
		if (isDown0)
		{
			down0Duration = Time.realtimeSinceStartup - down0Timestamp;
		}
		if (isDown1)
		{
			down1Duration = Time.realtimeSinceStartup - down1Timestamp;
		}
		if (!isDragging0 && isDown0 && (x != dragBeginX || y != dragBeginY))
		{
			isDragging0 = true;
		}
		if (isDragging0)
		{
			dragX = x - lastDragX;
			dragY = y - lastDragY;
			dragAccumulatedX += dragX;
			dragAccumulatedY += dragY;
			lastDragX = x;
			lastDragY = y;
			mouseDragX = GetMouseX() - lastMouseDragX;
			mouseDragY = GetMouseY() - lastMouseDragY;
			mouseDragAccumulatedX += mouseDragX;
			mouseDragAccumulatedY += mouseDragY;
			lastMouseDragX = GetMouseX();
			lastMouseDragY = GetMouseY();
		}
		else
		{
			dragX = (dragY = (dragAccumulatedX = (dragAccumulatedY = 0)));
			mouseDragX = (mouseDragY = (mouseDragAccumulatedX = (mouseDragAccumulatedY = 0)));
		}
		if (up0Buffered)
		{
			up0Buffered = false;
			up0 = true;
			isDown0 = false;
			isDragging0 = false;
		}
		if (up1Buffered)
		{
			up1Buffered = false;
			up1 = true;
			isDown1 = false;
		}
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		_renderer = r;
		if (isOverHyperlink)
		{
			DrawHyperlinkHand(r);
		}
		else if (platformDrawCursor && !IsHidden() && !isTouch)
		{
			AsciiCellProcedural cell = r.GetCell(x, y);
			if (cell != null)
			{
				r.SetCell(x, y, cell.GetValue(), cell.GetBackground(), r.defaultForegroundColor);
			}
		}
	}

	private void UpdateForHyperlinks()
	{
		if (lastX != x || lastY != y || Time.realtimeSinceStartup - lastHyperlinkCheckTime > 1f)
		{
			lastHyperlinkCheckTime = Time.realtimeSinceStartup;
			isOverHyperlink = false;
			AsciiCellProcedural cell = _renderer.GetCell(x, y);
			if (cell != null && cell.GetInteractionLayer() is HyperlinkButton)
			{
				isOverHyperlink = true;
			}
		}
	}

	private void DrawHyperlinkHand(AsciiRenderProcedural r)
	{
		string[] array = (isDown0 ? hyperlinkHandDown : hyperlinkHand);
		for (int i = 0; i < array.Length; i++)
		{
			string text = array[i];
			for (int j = 0; j < text.Length; j++)
			{
				char c = text[j];
				if (c != '#')
				{
					r.SetCell(x + j - 1, y + i, (int)c, r.defaultForegroundColor, r.defaultBackgroundColor, false);
				}
			}
		}
	}

	private void UpdateIsTouch()
	{
		if (Input.mousePresent)
		{
			Vector3 vector = Input.mousePosition - lastMousePos;
			lastMousePos = Input.mousePosition;
			if (vector != Vector3.zero)
			{
				isTouch = false;
			}
		}
		if (Input.touchCount > 0)
		{
			isTouch = true;
		}
	}

	private void UpdateMouseHidden()
	{
		float num = Input.mousePosition.x;
		float num2 = Input.mousePosition.y;
		if (!firstTime && (num != lastMouseX || num2 != lastMouseY || Input.GetMouseButtonDown(0)))
		{
			hideCursorTime = Time.realtimeSinceStartup + 2f;
		}
		firstTime = false;
		lastMouseX = num;
		lastMouseY = num2;
	}

	public bool IsHidden()
	{
		return hideCursorTime <= Time.realtimeSinceStartup;
	}

	public void Hide()
	{
		hideCursorTime = Time.realtimeSinceStartup;
	}

	private int GetMouseX()
	{
		return Mathf.RoundToInt(f_getMouseX());
	}

	private int GetMouseY()
	{
		return Mathf.RoundToInt(f_getMouseY());
	}

	private float f_getMouseX()
	{
		if (Input.touches.Length != 0)
		{
			return Input.GetTouch(0).position.x;
		}
		return Input.mousePosition.x;
	}

	private float f_getMouseY()
	{
		if (Input.touches.Length != 0)
		{
			return Input.GetTouch(0).position.y;
		}
		return Input.mousePosition.y;
	}

	private bool _getInputDown(int button)
	{
		if (Input.touches.Length > button)
		{
			return Input.GetTouch(button).phase == TouchPhase.Began;
		}
		return Input.GetMouseButtonDown(button);
	}

	private bool _getInputUp(int button)
	{
		if (Input.touches.Length > button)
		{
			return Input.GetTouch(button).phase == TouchPhase.Ended;
		}
		return Input.GetMouseButtonUp(button);
	}

	private void UpdateCursorPosition()
	{
		AsciiRenderProcedural.GridValue columnAt = _renderer.GetColumnAt(f_getMouseX());
		AsciiRenderProcedural.GridValue rowAt = _renderer.GetRowAt(f_getMouseY());
		x = columnAt.value;
		y = rowAt.value;
		subCellIsCursorLeft = columnAt.remainder < 0.5f;
		subCellIsCursorRight = !subCellIsCursorLeft;
		subCellIsCursorTop = rowAt.remainder < 0.5f;
		subCellIsCursorBottom = !subCellIsCursorTop;
	}

	private void Awake()
	{
		_singleton = this;
	}
}
