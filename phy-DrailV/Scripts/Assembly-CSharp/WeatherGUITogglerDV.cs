using DV;
using DV.UI;
using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;

public class WeatherGUITogglerDV : MonoBehaviour
{
	public WeatherEditorGUI guiScript;

	private float lastKeyPressTime = -1f;

	private void Awake()
	{
		guiScript.enabled = false;
		if (!DevUtil.IsDevMachine())
		{
			Object.Destroy(this);
		}
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading)
		{
			SingletonBehaviour<CursorManager>.Instance.RemoveRequest(this);
			CustomFirstPersonController firstPersonController = GetFirstPersonController();
			if ((bool)firstPersonController)
			{
				firstPersonController.m_MouseLook.RemoveRequest(this);
			}
		}
	}

	private void Update()
	{
		bool keyDown = Input.GetKeyDown(KeyCode.F8);
		bool flag = false;
		if (guiScript.enabled && keyDown)
		{
			flag = true;
		}
		else if (keyDown)
		{
			if (Time.realtimeSinceStartup - lastKeyPressTime < 0.3f)
			{
				flag = true;
			}
			lastKeyPressTime = Time.realtimeSinceStartup;
		}
		if (flag)
		{
			lastKeyPressTime = -1f;
			SetState(!guiScript.enabled);
		}
	}

	private void SetState(bool enabled)
	{
		guiScript.enabled = enabled;
		if (enabled)
		{
			SingletonBehaviour<CursorManager>.Instance.RequestCursor(this, visible: true);
			CustomFirstPersonController firstPersonController = GetFirstPersonController();
			if ((bool)firstPersonController)
			{
				firstPersonController.m_MouseLook.RequestMouseSensitivityState(this, MouseSensitivityState.Locked, 1);
			}
		}
		else
		{
			SingletonBehaviour<CursorManager>.Instance.RemoveRequest(this);
			CustomFirstPersonController firstPersonController2 = GetFirstPersonController();
			if ((bool)firstPersonController2)
			{
				firstPersonController2.m_MouseLook.RemoveRequest(this);
			}
		}
	}

	private CustomFirstPersonController GetFirstPersonController()
	{
		if (!(PlayerManager.PlayerTransform != null))
		{
			return null;
		}
		return PlayerManager.PlayerTransform.GetComponent<CustomFirstPersonController>();
	}
}
