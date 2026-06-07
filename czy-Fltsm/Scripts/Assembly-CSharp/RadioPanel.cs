using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RadioPanel : TMP_DropdownItemFormatter, IBuildablePanelElement
{
	[Header("Radio Panel")]
	[SerializeField]
	private Slider _progressSlider;

	[SerializeField]
	private Button _button;

	[Header("Debug")]
	[SerializeField]
	private bool _alwaysInteractable;

	private Radio _radio;

	private Dictionary<TMP_DropdownFormatableItem, AgentProfile> _dropdownItems;

	public BuildablePanelElementId Id => BuildablePanelElementId.Radio;

	public bool Activate(Buildable buildable, bool finished)
	{
		if (finished && buildable.TryReturnBuildableExtendable<Radio>(out _radio))
		{
			base.gameObject.SetActive(value: true);
			_progressSlider.value = Mathf.Lerp(_progressSlider.minValue, _progressSlider.maxValue, 0f);
			InitializeDropdown();
			_button.onClick.AddListener(OnButtonClick);
			UpdateButtonState(base.SelectedIndex);
			OnUpdateInteractable();
			GameEventDispatcher.AddListener(GameEventType.RadioMessageManagerStateUpdated, OnUpdateInteractable);
			GameEventDispatcher.AddListener(GameEventType.PanelClosed, OnUpdateInteractable);
			GameEventDispatcher.AddListener(GameEventType.AgentAddedToPlayerCommunity, OnGameEvent);
			GameEventDispatcher.AddListener(GameEventType.AgentRemovedFromPlayerCommunity, OnGameEvent);
			return true;
		}
		return false;
	}

	public void Deactivate()
	{
		_button.onClick.RemoveListener(OnButtonClick);
		GameEventDispatcher.RemoveListener(GameEventType.RadioMessageManagerStateUpdated, OnUpdateInteractable);
		GameEventDispatcher.RemoveListener(GameEventType.PanelClosed, OnUpdateInteractable);
		GameEventDispatcher.RemoveListener(GameEventType.AgentAddedToPlayerCommunity, OnGameEvent);
		GameEventDispatcher.RemoveListener(GameEventType.AgentRemovedFromPlayerCommunity, OnGameEvent);
		base.gameObject.SetActive(value: false);
	}

	private void InitializeDropdown()
	{
		if (!_dropdownItems.IsNullOrEmpty())
		{
			return;
		}
		using ListPool<string>.List list = ListPool<string>.Get();
		AgentProfile[] specialists = _radio.Specialists;
		foreach (AgentProfile agentProfile in specialists)
		{
			list.Add(agentProfile.PastBackground.Name);
		}
		Initialize(list);
	}

	private void UpdateButtonState(int selectedIndex)
	{
	}

	private void OnButtonClick()
	{
		if (!(_radio == null))
		{
			GameManager.UIManager.ClosePanel(PanelID.BuildablePanel);
			GameManager.UIManager.DisplayPanel(PanelID.RadioMessagePanel);
		}
	}

	protected override void AddItem(TMP_DropdownFormatableItem item)
	{
		if (_dropdownItems == null)
		{
			_dropdownItems = new Dictionary<TMP_DropdownFormatableItem, AgentProfile>();
		}
		AgentProfile agentProfile = ReturnSpecialist(_dropdownItems.Count);
		FormatDropdownItem(item, agentProfile, _dropdownItems.Count);
		_dropdownItems.Add(item, agentProfile);
	}

	protected override void RemoveItem(TMP_DropdownFormatableItem item)
	{
		if (!_dropdownItems.IsNullOrEmpty())
		{
			_dropdownItems.Remove(item);
		}
	}

	protected override void OnSelectedIndexChanged(int selectedIndex)
	{
		UpdateButtonState(selectedIndex);
	}

	private void FormatDropdownItem(TMP_DropdownFormatableItem item, AgentProfile specialist, int index)
	{
		if (IsInteractable(specialist))
		{
			item.Interactable = true;
			return;
		}
		item.Interactable = false;
		if (base.SelectedIndex == index)
		{
			ClearSelectedIndex();
		}
	}

	private AgentProfile ReturnSpecialist(int index)
	{
		return _radio.Specialists[index];
	}

	private void OnGameEvent(GameEvent gameEvent)
	{
		if (-1 < base.SelectedIndex && !IsInteractable(ReturnSpecialist(base.SelectedIndex)))
		{
			ClearSelectedIndex();
		}
	}

	private void OnUpdateInteractable(GameEvent gameEvent = null)
	{
		_button.interactable = ((Application.isEditor && _alwaysInteractable) || GameManager.RadioMessagesManager.IsReceivingRadioSignals) && !IsBlockedByPanel();
	}

	private bool IsInteractable(AgentProfile specialist)
	{
		if ((bool)specialist.PastBackground && !HasBackgroundInCommunity(specialist.PastBackground))
		{
			return !WorldMapCompass.HasBearingTo(specialist.PastBackground.ScoutingId);
		}
		return false;
	}

	private bool HasBackgroundInCommunity(DrifterAttributesEffect background)
	{
		foreach (Agent agent in Community.PlayerCommunity.Agents)
		{
			if (agent.Descriptor.PastBackground == background)
			{
				return true;
			}
		}
		return false;
	}

	private bool IsBlockedByPanel()
	{
		if (!GameManager.UIManager.IsPanelOpen(PanelID.DialoguePanel))
		{
			return GameManager.UIManager.IsPanelOpen(PanelID.RadioMessagePanel);
		}
		return true;
	}
}
