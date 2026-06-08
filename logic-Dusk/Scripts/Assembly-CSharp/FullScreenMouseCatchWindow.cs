using System.Collections.Generic;
using UnityEngine;

public class FullScreenMouseCatchWindow : MonoBehaviour
{
	public static FullScreenMouseCatchWindow Instance;

	public List<Rect> areasToIgnore;

	public void Start()
	{
		if (GameSaveFile.Get("WS_NOMOUSE_REQ", false))
		{
			Terminate();
		}
		else
		{
			Instance = this;
		}
	}

	public void Clear()
	{
		if (areasToIgnore != null)
		{
			areasToIgnore.Clear();
		}
	}

	public void Add(Rect rect)
	{
		if (areasToIgnore == null)
		{
			areasToIgnore = new List<Rect>();
		}
		areasToIgnore.Add(rect);
	}

	public void OnGUI()
	{
		Event current = Event.current;
		if (current.type != EventType.MouseDown)
		{
			return;
		}
		bool flag = true;
		if (GameplayManager.Instance.pauseMenu != null && GameplayManager.Instance.pauseMenu.IsLoaded)
		{
			flag = false;
		}
		foreach (Rect item in areasToIgnore)
		{
			if (item.Contains(current.mousePosition))
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			RectTransform component = ConsoleWindow3.Instance.gameObject.GetComponent<RectTransform>();
			Rect rect = new Rect(ConsoleWindow3.Instance.gameObject.transform.position.x - component.rect.width, (float)Screen.height - ConsoleWindow3.Instance.gameObject.transform.position.y - component.rect.height, component.rect.width, component.rect.height);
			if (rect.Contains(current.mousePosition))
			{
				flag = false;
			}
		}
		if (flag && GlobalSettings.cameraMode == CameraMode.Drone)
		{
			RectTransform component2 = DroneManager.Instance.DronesPanelGameObject.GetComponent<RectTransform>();
			Rect rect2 = new Rect(5f, 5f, component2.rect.width, component2.rect.height);
			if (rect2.Contains(current.mousePosition))
			{
				flag = false;
			}
		}
		if (flag)
		{
			Terminate();
			GameSaveFile.Save("WS_NOMOUSE_REQ", true);
		}
	}

	public void Terminate()
	{
		Instance = null;
		Object.Destroy(this);
	}
}
