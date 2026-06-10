using UnityEngine;

public class CursorManager : MonoBehaviour
{
	[Header("Cursors")]
	public Texture2D defaultCursor;

	public Texture2D hoverCursor;

	public Texture2D clickCursor;

	[Header("Hotspots")]
	public Vector2 defaultHotspot;

	public Vector2 hoverHotspot;

	public Vector2 clickHotspot;

	private bool isOverUI;

	private bool isClicking;

	public static CursorManager Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		Object.DontDestroyOnLoad(base.gameObject);
		ApplyCursor();
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
		{
			isClicking = true;
			ApplyCursor();
		}
		else if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
		{
			isClicking = false;
			ApplyCursor();
		}
	}

	public void SetOverUI(bool over)
	{
		if (isOverUI != over)
		{
			isOverUI = over;
			ApplyCursor();
		}
	}

	private void ApplyCursor()
	{
		Texture2D texture;
		Vector2 hotspot;
		if (isClicking && clickCursor != null)
		{
			texture = clickCursor;
			hotspot = clickHotspot;
		}
		else if (isOverUI && hoverCursor != null)
		{
			texture = hoverCursor;
			hotspot = hoverHotspot;
		}
		else
		{
			texture = defaultCursor;
			hotspot = defaultHotspot;
		}
		Cursor.SetCursor(texture, hotspot, CursorMode.Auto);
	}
}
