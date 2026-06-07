using Rewired;
using Rewired.UI;
using UnityEngine;

public class JoystickMouseInputSource : IMouseInputSource
{
	public enum Mode
	{
		Mapped = 0,
		Cumulative = 1
	}

	private const int JOYSTICK_MOUSE_X = 85;

	private const int JOYSTICK_MOUSE_Y = 86;

	private const int JOYSTICK_MOUSE_BUTTON_LEFT = 87;

	private const int JOYSTICK_MOUSE_BUTTON_RIGHT = 88;

	private const int JOYSTICK_MOUSE_TOGGLE = 91;

	private Mode _mode;

	private Player _player;

	private Vector2 _mousePosition;

	private Vector2 _mousePositionPrevious;

	private int _lastUpdatedFrame = -1;

	private float _speed;

	private bool _enabled;

	public int playerId
	{
		get
		{
			TryUpdate();
			return 0;
		}
	}

	public bool enabled
	{
		get
		{
			TryUpdate();
			return _enabled;
		}
	}

	public bool locked
	{
		get
		{
			TryUpdate();
			return false;
		}
	}

	public int buttonCount
	{
		get
		{
			TryUpdate();
			return 2;
		}
	}

	public Vector2 screenPosition
	{
		get
		{
			TryUpdate();
			return _mousePosition;
		}
	}

	public Vector2 screenPositionDelta
	{
		get
		{
			TryUpdate();
			return _mousePosition - _mousePositionPrevious;
		}
	}

	public Vector2 wheelDelta => Vector2.zero;

	public JoystickMouseInputSource(Mode mode, float speed)
	{
		_mode = mode;
		_player = ReInput.players.GetPlayer(0);
		_mousePosition = new Vector2((float)Screen.width / 2f, (float)Screen.height / 2f);
		_speed = speed;
		_enabled = false;
	}

	public bool GetButton(int button)
	{
		TryUpdate();
		switch (button)
		{
		case 0:
			if (_enabled)
			{
				return _player.GetButton(87);
			}
			return false;
		case 1:
			if (_enabled)
			{
				return _player.GetButton(88);
			}
			return false;
		default:
			return false;
		}
	}

	public bool GetButtonDown(int button)
	{
		TryUpdate();
		switch (button)
		{
		case 0:
			if (_enabled)
			{
				return _player.GetButtonDown(87);
			}
			return false;
		case 1:
			if (_enabled)
			{
				return _player.GetButtonDown(88);
			}
			return false;
		default:
			return false;
		}
	}

	public bool GetButtonUp(int button)
	{
		TryUpdate();
		switch (button)
		{
		case 0:
			if (_enabled)
			{
				return _player.GetButtonUp(87);
			}
			return false;
		case 1:
			if (_enabled)
			{
				return _player.GetButtonUp(88);
			}
			return false;
		default:
			return false;
		}
	}

	private Vector2 GetMousePosition()
	{
		Vector2 axis2DRaw = _player.GetAxis2DRaw(85, 86);
		switch (_mode)
		{
		case Mode.Mapped:
			_mousePosition = GetMousePosition(axis2DRaw);
			break;
		case Mode.Cumulative:
		{
			float num = Time.unscaledDeltaTime * _speed;
			_mousePosition.x = Mathf.Clamp(_mousePosition.x + axis2DRaw.x * num, 0f, Screen.width);
			_mousePosition.y = Mathf.Clamp(_mousePosition.y + axis2DRaw.y * num, 0f, Screen.height);
			break;
		}
		}
		return _mousePosition;
	}

	private void TryUpdate()
	{
		if (Time.frameCount != _lastUpdatedFrame)
		{
			_lastUpdatedFrame = Time.frameCount;
			if (_player.GetButtonUp(91))
			{
				_enabled = !_enabled;
			}
			if (_enabled)
			{
				_mousePositionPrevious = _mousePosition;
				_mousePosition = GetMousePosition();
			}
		}
	}

	public static Vector2 GetMousePosition(Vector2 axis2D)
	{
		bool flag = Mathf.Approximately(0f, axis2D.x);
		bool flag2 = Mathf.Approximately(0f, axis2D.y);
		Vector2 vector;
		if (flag && flag2)
		{
			vector = Vector2.zero;
		}
		else if (flag)
		{
			vector = new Vector2(0f, axis2D.y);
		}
		else if (flag2)
		{
			vector = new Vector2(axis2D.x, 0f);
		}
		else
		{
			Vector2 vector2 = new Vector2(Mathf.Abs(axis2D.x), Mathf.Abs(axis2D.y));
			float num = Mathf.Clamp01(axis2D.magnitude);
			float num2 = ((!(vector2.y < vector2.x)) ? (num / vector2.y) : (num / vector2.x));
			vector = axis2D * num2;
		}
		vector += Vector2.one;
		vector /= 2f;
		float num3 = Screen.width;
		float num4 = Screen.height;
		return new Vector2(Mathf.Clamp(num3 * vector.x, 0f, num3), Mathf.Clamp(num4 * vector.y, 0f, num4));
	}
}
