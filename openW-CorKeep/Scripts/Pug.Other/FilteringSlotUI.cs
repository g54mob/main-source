using System.Collections.Generic;
using UnityEngine;

public class FilteringSlotUI : SlotUIBase
{
	public GameObject noFilterObject;

	public ColorReplacer colorReplacer;

	private ObjectFilteringCD _lastObjectFilteringCD;

	public override void UpdateSlot()
	{
		base.UpdateSlot();
		background.gameObject.SetActive(value: false);
		EntityMonoBehaviour entityMonoBehaviour = Manager.main.player.GetActiveFilteringBuilding() as EntityMonoBehaviour;
		if (entityMonoBehaviour != null)
		{
			EntityUtility.TryGetComponentData<ObjectFilteringCD>(entityMonoBehaviour.entity, entityMonoBehaviour.world, out _lastObjectFilteringCD);
			if (_lastObjectFilteringCD.filterObject == ObjectID.None)
			{
				noFilterObject.SetActive(value: true);
				icon.sprite = null;
				return;
			}
			if (!PugDatabase.TryGetObjectInfo(_lastObjectFilteringCD.filterObject, out var objectInfo, _lastObjectFilteringCD.filterVariation) || objectInfo.icon == null)
			{
				noFilterObject.SetActive(value: false);
				SetMissingIcon();
				return;
			}
			noFilterObject.SetActive(value: false);
			ContainedObjectsBuffer containedObject = new ContainedObjectsBuffer
			{
				objectData = new ObjectDataCD
				{
					objectID = _lastObjectFilteringCD.filterObject,
					variation = _lastObjectFilteringCD.filterVariation
				}
			};
			Sprite iconOverride = Manager.ui.itemOverridesTable.GetIconOverride(containedObject.objectData, getSmallIcon: false);
			Sprite sprite = ((iconOverride != null) ? iconOverride : objectInfo.icon);
			if (colorReplacer != null)
			{
				colorReplacer.UpdateColorReplacerFromObjectData(containedObject);
			}
			icon.sprite = sprite;
			Manager.ui.ApplyAnyIconGradientMap(containedObject, icon);
			icon.transform.localPosition = objectInfo.iconOffset;
		}
		else
		{
			_lastObjectFilteringCD = default(ObjectFilteringCD);
		}
	}

	public bool TryGetFilteredObject(out ObjectID filteredObjectID, out int filterVariation)
	{
		filteredObjectID = ObjectID.None;
		filterVariation = 0;
		int num;
		if (_lastObjectFilteringCD.filterType != FilterType.None)
		{
			num = ((_lastObjectFilteringCD.filterObject != ObjectID.None) ? 1 : 0);
			if (num != 0)
			{
				filteredObjectID = _lastObjectFilteringCD.filterObject;
				filterVariation = _lastObjectFilteringCD.filterVariation;
			}
		}
		else
		{
			num = 0;
		}
		return (byte)num != 0;
	}

	public override TextAndFormatFields GetHoverTitle()
	{
		TextAndFormatFields textAndFormatFields = new TextAndFormatFields();
		if (TryGetFilteredObject(out var _, out var _))
		{
			textAndFormatFields.text = "WhitelistObjectFiltering";
		}
		else
		{
			textAndFormatFields.text = "NoFilter";
		}
		return textAndFormatFields;
	}

	public override List<TextAndFormatFields> GetHoverDescription()
	{
		ObjectID filteredObjectID;
		int filterVariation;
		TextAndFormatFields item = ((!TryGetFilteredObject(out filteredObjectID, out filterVariation)) ? new TextAndFormatFields
		{
			text = "NoFilterDesc",
			color = Color.white * 0.99f
		} : new TextAndFormatFields
		{
			text = "WhitelistObjectFilteringDesc",
			color = Color.white * 0.99f
		});
		return new List<TextAndFormatFields> { item };
	}

	public override void OnSelected()
	{
		OnSelectSlot();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		OnDeselectSlot();
	}
}
