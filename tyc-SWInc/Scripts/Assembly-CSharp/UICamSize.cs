using UnityEngine;

public class UICamSize : MonoBehaviour
{
	public static UICamSize Instance;

	public Camera Cam;

	private int _screenHeight = -1;

	private int _screenWidth = -1;

	public static Camera GetUICam()
	{
		if (!(Instance != null))
		{
			return null;
		}
		return Instance.Cam;
	}

	public static Vector2 GetUICamOffset()
	{
		if (!(Instance != null))
		{
			return Vector2.zero;
		}
		return new Vector2((float)Screen.width / Options.UISize / 2f, (float)Screen.height / Options.UISize / 2f);
	}

	public static void OffsetUIPosition(ref Vector2 v)
	{
		v += GetUICamOffset();
	}

	private void Awake()
	{
		if (Instance != null)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	private void Update()
	{
		if (_screenHeight != Screen.height || _screenWidth != Screen.width)
		{
			Cam.orthographicSize = (float)Screen.height / 2f;
			_screenHeight = Screen.height;
			_screenWidth = Screen.width;
		}
	}
}
