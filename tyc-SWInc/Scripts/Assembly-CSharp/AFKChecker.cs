using UnityEngine;

public class AFKChecker : MonoBehaviour
{
	public const int TimeLimit = 30;

	public static AFKChecker Instance;

	private static bool _active;

	private float _lastAction = -1f;

	private Vector3 _lastMouse;

	private bool _wasAFK;

	public static bool IsAFK()
	{
		if (_active && Instance._lastAction > 0f)
		{
			return Time.realtimeSinceStartup - Instance._lastAction > 30f;
		}
		return false;
	}

	public static void Pulse()
	{
		if (_active)
		{
			Instance._lastAction = Time.realtimeSinceStartup;
		}
	}

	private void Awake()
	{
		if (_active)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		_active = true;
	}

	private void OnDestroy()
	{
		_active = false;
		Instance = null;
	}

	private void Update()
	{
		if (Application.isFocused)
		{
			if (Input.anyKeyDown)
			{
				Pulse();
			}
			if (Input.mouseScrollDelta != Vector2.zero)
			{
				Pulse();
			}
			if (_lastMouse != Input.mousePosition)
			{
				_lastMouse = Input.mousePosition;
				Pulse();
			}
		}
		bool flag = IsAFK();
		if (_wasAFK != flag)
		{
			TimeOfDay.SyncPlayerTime();
			_wasAFK = flag;
		}
	}
}
