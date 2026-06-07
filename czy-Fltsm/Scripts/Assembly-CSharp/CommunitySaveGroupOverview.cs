using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CommunitySaveGroupOverview : MonoBehaviour
{
	[SerializeField]
	private CommunitySaveGroupOverviewSlot _slotPrefab;

	[SerializeField]
	private Transform _slotParent;

	[SerializeField]
	private TextMeshProUGUI _communityName;

	[SerializeField]
	private SelectableGroup _selectableGroup;

	[SerializeField]
	private GameObject _backButton;

	[Header("Actions")]
	[SerializeField]
	private RewiredAction _selectAction = new RewiredAction(29, null);

	[SerializeField]
	private RewiredAction _removeAction = new RewiredAction(85, null);

	private List<CommunitySaveGroupOverviewSlot> _slots = new List<CommunitySaveGroupOverviewSlot>();

	private PlayerRun _run;

	public UnityEvent OnCloseEvent { get; private set; } = new UnityEvent();

	private void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.SaveAdded, OnSaveEvent);
		GameEventDispatcher.AddListener(GameEventType.SaveOverwritten, OnSaveEvent);
		GameEventDispatcher.AddListener(GameEventType.SaveRemoved, OnSaveEvent);
		RewiredAction.AddToActionInfoBar(_selectAction, _removeAction);
		_backButton.gameObject.SetActive(value: true);
	}

	private void LateUpdate()
	{
		if (_removeAction.GetButtonUp() && TryReturnSelectedSlot(out var slot))
		{
			slot.Remove();
		}
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.SaveAdded, OnSaveEvent);
		GameEventDispatcher.RemoveListener(GameEventType.SaveOverwritten, OnSaveEvent);
		GameEventDispatcher.RemoveListener(GameEventType.SaveRemoved, OnSaveEvent);
		RewiredAction.RemoveFromActionInfoBar(_selectAction, _removeAction);
		_backButton.gameObject.SetActive(value: false);
	}

	public void Open(PlayerRun run)
	{
		_run = run;
		_communityName.text = run.CommunityName;
		Sorting.SlowSort(run.Saves);
		int i;
		for (i = 0; i < run.Saves.Count; i++)
		{
			CommunitySaveGroupOverviewSlot communitySaveGroupOverviewSlot;
			if (i < _slots.Count)
			{
				communitySaveGroupOverviewSlot = _slots[i];
			}
			else
			{
				communitySaveGroupOverviewSlot = Object.Instantiate(_slotPrefab, _slotParent);
				_slots.Add(communitySaveGroupOverviewSlot);
			}
			communitySaveGroupOverviewSlot.Activate(run, run.Saves[i]);
		}
		for (; i < _slots.Count; i++)
		{
			_slots[i].gameObject.SetActive(value: false);
		}
		base.gameObject.SetActive(value: true);
		_selectableGroup.Initialize();
	}

	public void Close()
	{
		base.gameObject.SetActive(value: false);
		OnCloseEvent.Invoke();
	}

	private void OnSaveEvent(GameEvent gameEvent)
	{
		if (gameEvent.EventType == GameEventType.SaveRemoved && _run.Saves.Count <= 0)
		{
			Close();
		}
		else
		{
			Open(_run);
		}
	}

	private bool TryReturnSelectedSlot(out CommunitySaveGroupOverviewSlot slot)
	{
		slot = null;
		if (_selectableGroup == null || _selectableGroup.Selected == null)
		{
			return false;
		}
		for (int i = 0; i < _slots.Count; i++)
		{
			slot = _slots[i];
			if (slot.gameObject == _selectableGroup.Selected.gameObject)
			{
				return true;
			}
		}
		return false;
	}
}
