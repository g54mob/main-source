using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MultitoolConsoleService : MultitoolService
{
	public ScrollRect scrollRect;

	public Transform linesRoot;

	public int columnsCount;

	public int maxLineCount;

	public Color infoColor;

	public Color warningColor;

	public Color errorColor;

	private LayoutHelper<MultitoolConsoleLine> layout;

	private Coroutine scrollBottomCoroutine;

	private Vector2Int _cursorPosition;

	private Vector2Int? savedCursorPosition;

	private static int defaultForegroundColor;

	private static int defaultBackgroundColor;

	private Color foregroundColor;

	private Color backgroundColor;

	public Vector2Int cursorPosition
	{
		get
		{
			return default(Vector2Int);
		}
		set
		{
		}
	}

	protected override void Awake()
	{
	}

	public override void Init(MultiTool multitool)
	{
	}

	protected override void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private MultitoolConsoleLine AddLine()
	{
		return null;
	}

	private IEnumerator ScrollToBottomCoroutine()
	{
		return null;
	}

	public void Log(MultiTool.LogType logType, string message)
	{
	}

	public void Write(string text)
	{
	}

	public void WriteLine(string text)
	{
	}

	public void Clear()
	{
	}

	public void ClearToEndOfLine()
	{
	}

	public void SetForegroundColor(int colorId)
	{
	}

	public void SetBackgroundColor(int colorId)
	{
	}

	public void ResetForegroundColor()
	{
	}

	public void ResetBackgroundColor()
	{
	}

	public void ResetColors()
	{
	}

	public void SaveCursorPosition()
	{
	}

	public void RestoreCursorPosition()
	{
	}
}
