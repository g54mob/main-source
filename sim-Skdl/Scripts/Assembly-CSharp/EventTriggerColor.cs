using ScheduleOne;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UISelectable))]
public class EventTriggerColor : MonoBehaviour
{
	public Image image;

	public Color SelectedColor;

	public Color DeselectedColor;

	private UISelectable selectable;

	private void Awake()
	{
	}

	public void OnSelected()
	{
	}

	public void OnDeselected()
	{
	}
}
