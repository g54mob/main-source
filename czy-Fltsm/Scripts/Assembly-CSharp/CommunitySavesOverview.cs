using System.Collections.Generic;
using UnityEngine;

public class CommunitySavesOverview : MonoBehaviour
{
	[SerializeField]
	private ChildBehaviourCache<CommunitySavesOverviewSlot> _slots;

	[SerializeField]
	private SelectableGroup _selectableGroup;

	public PlayerRunEvent OnSelectedEvent { get; private set; } = new PlayerRunEvent();

	public void Open(List<PlayerRun> playerRuns)
	{
		Sorting.SlowSort(playerRuns);
		base.gameObject.SetActive(value: true);
		_slots.Reset();
		foreach (PlayerRun playerRun in playerRuns)
		{
			if (playerRun.MostRecentSave != null)
			{
				_slots.Get(active: true).Activate(this, playerRun);
			}
		}
		_slots.Trim();
		_selectableGroup.Initialize();
	}

	public void Select(PlayerRun playerRun)
	{
		OnSelectedEvent.Invoke(playerRun);
	}
}
