using UnityEngine;

public class CursorManager : MonoBehaviour
{
	private static Texture2D cursor;

	private static Texture2D pointer;

	private static Texture2D ibeam;

	private static Texture2D ask;

	private static Texture2D open;

	private static Texture2D close;

	private static Texture2D expand;

	private static Texture2D[] loadingCursors;

	private static Vector2 POINTER_HOTSPOT = new Vector2(11f, 6f);

	private static int LOADING_CURSOR_FRAMES = 7;

	private static bool isLoading;

	private void Start()
	{
		cursor = ResourcesManager.GetTexture("UI/Cursor/pointer");
		pointer = ResourcesManager.GetTexture("UI/Cursor/finger");
		ibeam = ResourcesManager.GetTexture("UI/Cursor/ibeam");
		ask = ResourcesManager.GetTexture("UI/Cursor/ask");
		open = ResourcesManager.GetTexture("UI/Cursor/open");
		close = ResourcesManager.GetTexture("UI/Cursor/close");
		expand = ResourcesManager.GetTexture("UI/Cursor/expand");
		loadingCursors = new Texture2D[LOADING_CURSOR_FRAMES];
		for (int i = 0; i < LOADING_CURSOR_FRAMES; i++)
		{
			string text = ((i == 0) ? "" : $" {i + 1}");
			loadingCursors[i] = ResourcesManager.GetTexture("UI/Cursor/light" + text);
		}
		isLoading = false;
		SetCursorNormal();
	}

	public static void SetCursorPointer()
	{
		SetCursor(pointer);
	}

	public static void SetCursorExpand()
	{
		SetCursor(expand);
	}

	public static void SetCursorNormal()
	{
		SetCursor(cursor);
	}

	public static void SetCursorIBeam()
	{
		SetCursor(ibeam);
	}

	public static void SetCursorAsk()
	{
		SetCursor(ask);
	}

	public static void SetCursorOpen()
	{
		SetCursor(open);
	}

	public static void SetCursorClose()
	{
		SetCursor(close);
	}

	public static void SetLoading()
	{
		isLoading = true;
	}

	public static bool IsLoading()
	{
		return isLoading;
	}

	public static Texture2D[] GetLoadingCursors()
	{
		return loadingCursors;
	}

	public static void StopCursorLoading()
	{
		isLoading = false;
		SetCursorNormal();
	}

	public static void SetCursor(Texture2D cursor, bool forceCursor = false)
	{
		if (!isLoading || forceCursor)
		{
			Cursor.SetCursor(cursor, POINTER_HOTSPOT, CursorMode.Auto);
		}
	}
}
