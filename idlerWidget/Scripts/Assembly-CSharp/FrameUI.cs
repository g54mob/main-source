using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;
using UnityEngine;

public class FrameUI : FullScreenUI
{
	[SerializeField]
	private List<Transform> _persistentElements;

	[SerializeField]
	private UITimerBar _timerPrefab;

	[SerializeField]
	private UIProgressBar _progressPrefab;

	[SerializeField]
	private UICraftedItem _itemTextPrefab;

	public static FrameUI Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
	}

	public override void OnFullScreenActivate()
	{
		GamePlayer.Current.RecentInOverview = false;
	}

	public bool ReturnToMap()
	{
		if (base.FullScreenActive)
		{
			GameUI.Instance.ShowFullScreenUI(OverviewUI.Instance);
			return true;
		}
		return false;
	}

	public void Clear()
	{
		foreach (Transform item in base.transform)
		{
			if (!_persistentElements.Contains(item))
			{
				Object.Destroy(item.gameObject);
			}
		}
	}

	public UITimerBar ShowTimer(Transform parent, float duration)
	{
		UITimerBar uITimerBar = Object.Instantiate(_timerPrefab, base.transform);
		uITimerBar.StartTimer(duration);
		((RectTransform)uITimerBar.transform).anchoredPosition = base.ActiveCamera.WorldToScreenPoint(parent.transform.position);
		uITimerBar.SetScale(parent.localScale);
		return uITimerBar;
	}

	public UICraftedItem ShowItemCrafted(Transform parent, ItemType type, int count)
	{
		UICraftedItem uICraftedItem = Object.Instantiate(_itemTextPrefab, base.transform);
		uICraftedItem.SetItem(type, count);
		((RectTransform)uICraftedItem.transform).anchoredPosition = base.ActiveCamera.WorldToScreenPoint(parent.transform.position);
		return uICraftedItem;
	}

	public UIProgressBar ShowProgress(Transform parent, float progress)
	{
		UIProgressBar uIProgressBar = Object.Instantiate(_progressPrefab, base.transform);
		uIProgressBar.UpdateProgress(progress);
		((RectTransform)uIProgressBar.transform).anchoredPosition = base.ActiveCamera.WorldToScreenPoint(parent.transform.position);
		uIProgressBar.SetScale(parent.localScale);
		return uIProgressBar;
	}
}
