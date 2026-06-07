using Rewired;
using UnityEngine;

public class RewiredActions
{
	private static Player _player;

	public static Vector2 ReturnWorldCameraMovementInput()
	{
		if (HasNoValidPlayer())
		{
			return default(Vector2);
		}
		return new Vector2(0f - _player.GetAxisRaw(31) + _player.GetAxisRaw(32), 0f - _player.GetAxisRaw(1) + _player.GetAxisRaw(0));
	}

	public static Vector2 ReturnMapCameraMovementInput()
	{
		if (HasNoValidPlayer())
		{
			return default(Vector2);
		}
		return new Vector2(0f - _player.GetAxisRaw(81) + _player.GetAxisRaw(82), 0f - _player.GetAxisRaw(80) + _player.GetAxisRaw(79));
	}

	public static float ReturnCameraRotation()
	{
		if (HasNoValidPlayer())
		{
			return 0f;
		}
		return ApplyDeadzone(_player.GetAxisRaw(2) - _player.GetAxisRaw(33), 0.3f);
	}

	public static float ReturnCameraZoom()
	{
		if (HasNoValidPlayer())
		{
			return 0f;
		}
		return ApplyDeadzone(_player.GetAxisRaw(89), 0.5f);
	}

	public static Vector2 ReturnTownheartMovementInput()
	{
		if (HasNoValidPlayer())
		{
			return default(Vector2);
		}
		return new Vector2(0f - _player.GetAxisRaw(71) + _player.GetAxisRaw(72), 0f - _player.GetAxisRaw(70) + _player.GetAxisRaw(69));
	}

	public static bool ReturnToggleMapInput()
	{
		if (!HasNoValidPlayer())
		{
			return _player.GetButtonDown(83);
		}
		return false;
	}

	public static bool ReturnHasTownheartInput()
	{
		if (!_player.GetButton(69))
		{
			return _player.GetButton(70);
		}
		return true;
	}

	public static bool IsContinuousBuilding()
	{
		return _player.GetButton(75);
	}

	private static float ApplyDeadzone(float value, float deadzone)
	{
		deadzone = Mathf.Clamp01(deadzone);
		if (deadzone < 1f)
		{
			float num = 1f - deadzone;
			if (value > deadzone)
			{
				return Mathf.Clamp01(value - deadzone) / num;
			}
			if (value < 0f - deadzone)
			{
				return Mathf.Clamp(value + deadzone, -1f, 0f) / num;
			}
		}
		return 0f;
	}

	private static bool HasNoValidPlayer()
	{
		if (_player == null)
		{
			_player = FlotsamInputManager.RewiredPlayer;
			if (_player == null)
			{
				return true;
			}
		}
		return false;
	}
}
