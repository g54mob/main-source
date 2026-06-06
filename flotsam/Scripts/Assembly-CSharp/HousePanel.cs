using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HousePanel : MonoBehaviour, IBuildablePanelElement
{
	[Header("Components")]
	[Tooltip("Parent GameObject to instantiate the inhabitant status prefab under.")]
	public GameObject Content;

	[SerializeField]
	private HouseSlot _slotPrefab;

	[SerializeField]
	private SelectableGroup _selectableGroup;

	private House _linkedHouse;

	private List<HouseSlot> _slots = new List<HouseSlot>(2);

	public BuildablePanelElementId Id => BuildablePanelElementId.House;

	private void OnDisable()
	{
		foreach (HouseSlot slot in _slots)
		{
			slot.OnAgentUpdated.RemoveListener(OnSlotUpdated);
		}
	}

	public bool Activate(Buildable buildable, bool finished)
	{
		Deactivate();
		if (finished && buildable.TryReturnBuildableExtendable<House>(out _linkedHouse))
		{
			base.gameObject.SetActive(value: true);
			_linkedHouse = buildable.GetComponent<House>();
			UpdateInhabitants();
			_linkedHouse.InhabitantsUpdated += UpdateInhabitants;
			_selectableGroup.Initialize(clearSelected: true);
			return true;
		}
		return false;
	}

	public void Deactivate()
	{
		if ((bool)_linkedHouse)
		{
			_linkedHouse.InhabitantsUpdated -= UpdateInhabitants;
		}
		base.gameObject.SetActive(value: false);
	}

	private void UpdateInhabitants()
	{
		int i;
		for (i = 0; i < _linkedHouse.Inhabitants.Length; i++)
		{
			HouseSlot houseSlot;
			if (i < _slots.Count)
			{
				houseSlot = _slots[i];
				houseSlot.OnAgentUpdated.RemoveListener(OnSlotUpdated);
			}
			else
			{
				houseSlot = Object.Instantiate(_slotPrefab, base.transform);
				_slots.Add(houseSlot);
			}
			houseSlot.Initialize(_linkedHouse, _linkedHouse.Inhabitants[i]);
			houseSlot.OnAgentUpdated.AddListener(OnSlotUpdated);
		}
		for (; i < _slots.Count; i++)
		{
			HouseSlot houseSlot = _slots[i];
			houseSlot.gameObject.SetActive(value: false);
			houseSlot.OnAgentUpdated.RemoveListener(OnSlotUpdated);
		}
		LayoutRebuilder.ForceRebuildLayoutImmediate(base.transform as RectTransform);
	}

	private void OnSlotUpdated(Agent previousAgent, Agent selectedAgent)
	{
		if ((bool)previousAgent)
		{
			_linkedHouse.RemoveAgent(previousAgent);
		}
		if ((bool)selectedAgent)
		{
			selectedAgent.ReservedHouse?.RemoveAgent(selectedAgent);
			_linkedHouse.AddAgent(selectedAgent);
		}
	}
}
