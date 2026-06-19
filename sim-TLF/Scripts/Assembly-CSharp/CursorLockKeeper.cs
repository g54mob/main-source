using UnityEngine;

public class CursorLockKeeper : MonoBehaviour
{
	private CursorLockMode _desiredLock = CursorLockMode.Locked;

	private bool _desiredVisible;

	public static CursorLockKeeper Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(this);
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

	public static void Apply(CursorLockMode lockMode, bool visible)
	{
		if (Instance != null)
		{
			Instance._desiredLock = lockMode;
			Instance._desiredVisible = visible;
		}
		Cursor.lockState = lockMode;
		Cursor.visible = visible;
	}

	public static void Ensure()
	{
		if (!(Instance != null))
		{
			Instance = new GameObject("CursorLockKeeper").AddComponent<CursorLockKeeper>();
		}
	}

	private void LateUpdate()
	{
		Enforce();
	}

	private void OnApplicationFocus(bool hasFocus)
	{
		if (hasFocus)
		{
			Enforce();
		}
	}

	private void Enforce()
	{
		if (Cursor.lockState != _desiredLock)
		{
			Cursor.lockState = _desiredLock;
		}
		if (Cursor.visible != _desiredVisible)
		{
			Cursor.visible = _desiredVisible;
		}
	}
}
