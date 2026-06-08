using System.Collections.Generic;
using UnityEngine;

public class TaskbarManager : MonoBehaviour
{
	[SerializeField]
	private GameObject taskbarButtonPrefab;

	[SerializeField]
	private Transform taskbarContainer;

	[SerializeField]
	private GameObject notificationPrefab;

	[SerializeField]
	private Notification notificationPlayer;

	private GameObject notificationPopup;

	private static Taskbar taskbar;

	private static Dictionary<GameObject, GameObject> windowsToTaskbars;

	public void Awake()
	{
		taskbar = GetTaskbar();
	}

	public void AddTaskbar(GameObject window, Sprite sprite, string name)
	{
		if (windowsToTaskbars == null)
		{
			windowsToTaskbars = new Dictionary<GameObject, GameObject>();
		}
		Taskbar component = taskbarContainer.GetComponent<Taskbar>();
		bool num = windowsToTaskbars.ContainsKey(window);
		GameObject gameObject = (num ? windowsToTaskbars[window] : Object.Instantiate(taskbarButtonPrefab, taskbarContainer));
		TaskbarButton component2 = gameObject.GetComponent<TaskbarButton>();
		component2.EnableImage();
		if (!num)
		{
			component2.SetIcon(sprite);
			component2.SetName(name);
			component2.SetWindow(window);
			windowsToTaskbars[window] = gameObject;
		}
		component.ResizeTaskbars();
		window.GetComponent<Panel>().SetCurrentPosition();
	}

	public static Taskbar GetTaskbar()
	{
		return GameObject.Find("/Canvas/Assistant Spawer + Taskbar/Taskbar").GetComponent<Taskbar>();
	}

	public bool IsMaximumTaskbarButtons(GameObject window = null)
	{
		if (windowsToTaskbars == null)
		{
			windowsToTaskbars = new Dictionary<GameObject, GameObject>();
		}
		if ((!(window != null) || !windowsToTaskbars.ContainsKey(window)) && taskbar.IsMaximumTaskbarButtons())
		{
			notificationPlayer.PlayError();
			if (notificationPopup == null)
			{
				notificationPopup = UIUtils.LaunchTextPopup(notificationPrefab, UIUtils.FindCanvasFromChild(base.transform), "Error", "Your taskbar is full.\nPlease close some windows.", NotificationHandler.Icon.ERROR);
			}
			PanelManager.OpenWindow(notificationPopup);
			return true;
		}
		return false;
	}

	public static void RemoveFromTaskbar(GameObject window)
	{
		if (windowsToTaskbars != null && windowsToTaskbars.ContainsKey(window))
		{
			windowsToTaskbars[window].GetComponent<TaskbarButton>().RemoveTaskbarButton();
			windowsToTaskbars.Remove(window);
			taskbar.ResizeTaskbars();
		}
	}

	public static GameObject SetTaskbarActive(GameObject window)
	{
		if (windowsToTaskbars == null)
		{
			return null;
		}
		if (!windowsToTaskbars.ContainsKey(window))
		{
			return null;
		}
		windowsToTaskbars[window].GetComponent<TaskbarButton>().EnableImage();
		return windowsToTaskbars[window];
	}

	public static GameObject SetTaskbarInactive(GameObject window)
	{
		if (windowsToTaskbars == null)
		{
			return null;
		}
		if (!windowsToTaskbars.ContainsKey(window))
		{
			return null;
		}
		windowsToTaskbars[window].GetComponent<TaskbarButton>().DisableImage();
		return windowsToTaskbars[window];
	}
}
