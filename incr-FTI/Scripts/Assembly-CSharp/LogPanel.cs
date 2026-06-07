using System.Collections.Generic;
using UnityEngine;

public class LogPanel : MenuListPanel
{
	public GameObject notificationListItemPrefab;

	private Dictionary<int, int> logAnimations = new Dictionary<int, int>();

	private const float flashSpeed = 2f;

	private float[] animationValues = new float[20];

	private List<int> keysToRemove = new List<int>();

	private Vector3 testVector;

	public override void Show()
	{
		base.Show();
		MenuPanel.m.navigationPanel.logButton.isSelected = true;
	}

	public override void Hide()
	{
		base.Hide();
		MenuPanel.m.navigationPanel.logButton.isSelected = false;
	}

	public override void Initialize()
	{
		base.Initialize();
		RemoveAutoLayout();
	}

	public void FlashLog(LogEntry e)
	{
		for (int i = 0; i < animationValues.Length; i++)
		{
			if (animationValues[i] <= 0f)
			{
				animationValues[i] = 1f;
				logAnimations[e.logIndex] = i;
				break;
			}
		}
	}

	public override void ResetPanel()
	{
		base.ResetPanel();
		logAnimations.Clear();
		keysToRemove.Clear();
	}

	public override void CreateLayoutForActiveTown()
	{
		base.CreateLayoutForActiveTown();
		foreach (LogEntry logEntry in displayedTown.logEntries)
		{
			primaryLayoutManager.AddItemWithHeight(logEntry, 38f);
		}
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		for (int i = 0; i < animationValues.Length; i++)
		{
			float num = animationValues[i];
			if (num > 0f)
			{
				animationValues[i] = num - 2f * TimeManager.MenuDelta;
			}
		}
		foreach (MonoBehaviour value in visibleListItems.Values)
		{
			if (value is LogListItem logListItem)
			{
				if (displayedTown.newLogs.Contains(logListItem.displayedLogEntry.logIndex))
				{
					displayedTown.newLogs.Remove(logListItem.displayedLogEntry.logIndex);
					FlashLog(logListItem.displayedLogEntry);
				}
				ApplyAnimation(logListItem);
			}
		}
		foreach (int item in keysToRemove)
		{
			logAnimations.Remove(item);
		}
		keysToRemove.Clear();
	}

	private void ApplyAnimation(LogListItem logListItem)
	{
		if (logAnimations.TryGetValue(logListItem.displayedLogEntry.logIndex, out var value))
		{
			float num = animationValues[value];
			logListItem.UpdateAnimationDisplay(num);
			if (num <= 0f)
			{
				keysToRemove.Add(logListItem.displayedLogEntry.logIndex);
			}
		}
		else
		{
			logListItem.UpdateAnimationDisplay(0f);
		}
	}

	protected override MonoBehaviour CreateListItemForPool()
	{
		return MenuManager.GetMenuObject(notificationListItemPrefab, layoutGroup.transform).GetComponent<LogListItem>();
	}

	protected override void AssignKeyToItem(object key, MonoBehaviour item)
	{
		if (key is LogEntry e && item is LogListItem logListItem)
		{
			logListItem.LoadLogEntry(e);
			ApplyAnimation(logListItem);
		}
	}

	protected override bool ShouldLayoutItemBeValid(LayoutItem layoutItem)
	{
		return true;
	}
}
