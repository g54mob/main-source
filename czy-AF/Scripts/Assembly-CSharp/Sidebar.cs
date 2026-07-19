using System.Collections.Generic;
using UnityEngine;

public class Sidebar : MonoBehaviour
{
	public List<Transform> panels = new List<Transform>();

	private float hiddenPosition = 400f;

	private Transform activePanel;

	public static Sidebar instance { get; private set; }

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		Vector2 anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
		GetComponent<RectTransform>().anchoredPosition = new Vector2(hiddenPosition, anchoredPosition.y);
		foreach (Transform panel in panels)
		{
			panel.gameObject.SetActive(value: false);
		}
	}

	public void Open(string p)
	{
		Global.control = false;
		Interface.Block();
		SetPanel(p);
		if (activePanel != null)
		{
			activePanel.gameObject.SendMessage("Open", SendMessageOptions.DontRequireReceiver);
		}
		RectTransform component = GetComponent<RectTransform>();
		iTween.ValueTo(base.gameObject, iTween.Hash("from", component.anchoredPosition, "to", new Vector2(0f, component.anchoredPosition.y), "time", 0.25f, "easetype", "easeOutExpo", "onupdatetarget", base.gameObject, "onupdate", "MovePanel"));
	}

	public void Close()
	{
		if (activePanel != null)
		{
			activePanel.gameObject.SendMessage("Close", SendMessageOptions.DontRequireReceiver);
		}
		SetPanel(null);
		RectTransform component = GetComponent<RectTransform>();
		iTween.ValueTo(base.gameObject, iTween.Hash("from", component.anchoredPosition, "to", new Vector2(hiddenPosition, component.anchoredPosition.y), "time", 0.25f, "easetype", "easeInSine", "onupdatetarget", base.gameObject, "onupdate", "MovePanel"));
		Global.control = true;
		Interface.Unblock();
	}

	public void MovePanel(Vector2 position)
	{
		GetComponent<RectTransform>().anchoredPosition = position;
	}

	public void SetPanel(string p)
	{
		foreach (Transform panel in panels)
		{
			panel.gameObject.SetActive(panel.name == p);
			if (panel.name == p)
			{
				activePanel = panel;
			}
		}
	}
}
