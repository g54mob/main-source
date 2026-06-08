using UnityEngine;
using UnityEngine.InputSystem;

public class HotkeyControls : MonoBehaviour
{
	[SerializeField]
	private Transform canvas;

	public readonly int PANEL_START_INDEX = 2;

	private void Start()
	{
		GetComponent<PlayerInput>().actions["Switch Windows"].performed += delegate
		{
			SwitchWindow();
		};
		GetComponent<PlayerInput>().actions["Close Window"].performed += delegate
		{
			CloseWindow();
		};
	}

	public void SwitchWindow()
	{
		Panel topWindow = GetTopWindow();
		if (topWindow != null)
		{
			topWindow.transform.SetSiblingIndex(PANEL_START_INDEX);
			TaskbarManager.SetTaskbarInactive(topWindow.gameObject);
			TaskbarManager.SetTaskbarActive(GetTopWindow().gameObject);
		}
	}

	public void CloseWindow()
	{
		Panel topWindow = GetTopWindow();
		if (topWindow != null)
		{
			topWindow.GetComponentInChildren<Toolbar>().Close();
		}
	}

	public Panel GetTopWindow()
	{
		for (int num = canvas.childCount - 1; num > 0; num--)
		{
			GameObject gameObject = canvas.GetChild(num).gameObject;
			Panel component = gameObject.GetComponent<Panel>();
			if (gameObject.activeSelf && component != null && !component.IsClosing())
			{
				Toolbar componentInChildren = component.GetComponentInChildren<Toolbar>();
				if (componentInChildren != null && componentInChildren.transform.Find("Close") != null)
				{
					Debug.Log($"Top Window {gameObject}");
					return component;
				}
			}
		}
		return null;
	}
}
