using UnityEngine;

public class Taskbar : MonoBehaviour
{
	private float width;

	private int maxButtons;

	public void Start()
	{
		RectTransform component = GetComponent<RectTransform>();
		width = (float)Screen.width * UIUtils.GetScreenFixedRatio();
		component.sizeDelta = new Vector2(width, component.sizeDelta.y);
		maxButtons = (int)(width / (float)TaskbarButton.MIN_TASKBAR_BUTTON_WIDTH);
		Debug.Log($"Maximum taskbar buttons is {maxButtons}");
	}

	public bool IsMaximumTaskbarButtons()
	{
		return base.transform.childCount >= maxButtons;
	}

	public void ResizeTaskbars()
	{
		int size = (int)(width / (float)base.transform.childCount);
		foreach (Transform item in base.transform)
		{
			item.GetComponent<TaskbarButton>().SetSize(size);
		}
	}
}
