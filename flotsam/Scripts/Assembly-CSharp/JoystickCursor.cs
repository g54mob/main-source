using UnityEngine;
using UnityEngine.UI;

public class JoystickCursor : MonoBehaviour
{
	[SerializeField]
	private RawImage _cursorImage;

	private static JoystickCursor _instance;

	private RectTransform _rectTransform;

	private void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
			_rectTransform = base.transform as RectTransform;
			_cursorImage.enabled = FlotsamInputManager.IsJoystickMouse;
		}
		else if (_instance != this)
		{
			Object.Destroy(this);
		}
	}

	private void LateUpdate()
	{
		if (FlotsamInputManager.IsJoystickMouse)
		{
			_rectTransform.transform.position = FlotsamInputManager.MousePosition;
			_cursorImage.enabled = true;
		}
		else
		{
			_cursorImage.enabled = false;
		}
	}

	public static void SetCursor(Texture2D texture)
	{
		if ((bool)_instance)
		{
			_instance._cursorImage.texture = texture;
		}
	}
}
