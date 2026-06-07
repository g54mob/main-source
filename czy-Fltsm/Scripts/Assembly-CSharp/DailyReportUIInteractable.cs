using UnityEngine;

public class DailyReportUIInteractable : UIInteractable, DailyReportPanel.Context, IPanelContext
{
	[SerializeField]
	private GameObject _alert;

	public PanelID PanelID => PanelID.DailyReportPanel;

	public int DayIndex => GameManager.TimeManager.Days.Count - 1;

	protected override void Awake()
	{
		base.Awake();
		GameEventDispatcher.AddListener(GameEventType.DayEnded, OnDayEnded);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		GameEventDispatcher.RemoveListener(GameEventType.DayEnded, OnDayEnded);
	}

	private void OnDayEnded(GameEvent gameEvent)
	{
		if (!GameManager.UIManager.IsPanelOpen(PanelID.DailyReportPanel))
		{
			_alert.SetActive(value: true);
		}
	}

	public override void Interact()
	{
		base.Interact();
		if (GameManager.UIManager.IsPanelOpen(PanelID))
		{
			GameManager.UIManager.ClosePanel(PanelID);
		}
		else
		{
			GameManager.UIManager.DisplayPanel(this);
		}
		_alert.SetActive(value: false);
	}
}
