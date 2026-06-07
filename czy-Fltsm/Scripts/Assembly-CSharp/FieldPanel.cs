using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldPanel : MonoBehaviour, IBuildablePanelElement
{
	[SerializeField]
	private GameObject _exportTitle;

	[SerializeField]
	private ChildBehaviourCache<InventoryPanelItemSlot> _exportSlotPrefab;

	[SerializeField]
	private GridLayoutGroup _gridLayoutGroup;

	[SerializeField]
	private ChildBehaviourCache<FieldSlot> _fieldSlotPrefab;

	[SerializeField]
	private BuildableCategory _cropsCategory;

	private DecorationSlots _field;

	public BuildablePanelElementId Id => BuildablePanelElementId.Field;

	public bool Activate(Buildable buildable, bool finished)
	{
		if ((bool)_field)
		{
			_field.DecorationInventoryUpdated.RemoveListener(UpdateExportSlots);
		}
		if (finished && buildable.TryReturnBuildableExtendable<DecorationSlots>(out _field) && _field.AcceptsDecorationType(DecorationType.Crop))
		{
			base.gameObject.SetActive(value: true);
			_gridLayoutGroup.constraintCount = _field.Width;
			_fieldSlotPrefab.Reset();
			_field.DecorationInventoryUpdated.AddListener(UpdateExportSlots);
			UpdateExportSlots();
			for (int i = 0; i < _field.Slots.Length; i++)
			{
				_fieldSlotPrefab.Get(active: true).InitializeSlot(_field.Slots[i], i);
			}
			_fieldSlotPrefab.Trim();
			foreach (Decoration decoration in _field.Decorations)
			{
				InitializeDecoration(decoration, _fieldSlotPrefab.Instances);
			}
			return true;
		}
		return false;
	}

	public void Deactivate()
	{
		if ((bool)_field)
		{
			_field.DecorationInventoryUpdated.RemoveListener(UpdateExportSlots);
		}
		base.gameObject.SetActive(value: false);
	}

	private void InitializeDecoration(Decoration decoration, IReadOnlyList<FieldSlot> slots)
	{
		using IEnumerator<FieldSlot> enumerator = slots.GetEnumerator();
		while (enumerator.MoveNext() && !enumerator.Current.TryInitializeDecoration(decoration))
		{
		}
	}

	private void UpdateExportSlots()
	{
		_exportSlotPrefab.Reset();
		_exportTitle.SetActive(value: false);
		foreach (InventoryAuditor.CountedItem countedItem in _field.ReturnAuditorCount().CountedItems)
		{
			if (0 < countedItem.UnreservedCount)
			{
				_exportTitle.SetActive(value: true);
				_exportSlotPrefab.Get(active: true).Initialize(countedItem);
			}
		}
		_exportSlotPrefab.Trim();
	}

	public void ToggleCropsPanel()
	{
		GameManager.UIManager.DisplayPanel(PanelID.DecorationCreation, _cropsCategory);
	}
}
