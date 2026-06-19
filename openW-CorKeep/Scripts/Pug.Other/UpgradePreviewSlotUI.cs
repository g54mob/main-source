using System.Collections.Generic;
using UnityEngine;

public class UpgradePreviewSlotUI : SlotUIBase
{
	private SlotUIBase _slotReference;

	public GameObject container;

	protected override ContainedObjectsBuffer GetSlotObject()
	{
		if (_slotReference != null && container.activeSelf)
		{
			return _slotReference.GetContainedObject();
		}
		return default(ContainedObjectsBuffer);
	}

	public void Show(bool value)
	{
		container.SetActive(value);
	}

	public void UpdatePreview(SlotUIBase slot)
	{
		LateUpdate();
		_slotReference = slot;
		if (isShowing)
		{
			ContainedObjectsBuffer containedObject = _slotReference.GetContainedObject();
			if (containedObject.objectID == ObjectID.None)
			{
				SetEmptyIcon();
				return;
			}
			if (!PugDatabase.TryGetObjectInfo(containedObject.objectID, out var objectInfo, containedObject.variation) || objectInfo.icon == null)
			{
				SetMissingIcon();
				return;
			}
			Sprite sprite = GetIcon(objectInfo, containedObject.objectData);
			icon.sprite = sprite;
			Manager.ui.ApplyAnyIconGradientMap(containedObject, icon);
			icon.transform.localPosition = objectInfo.iconOffset;
		}
	}

	public override List<TextAndFormatFields> GetHoverStats(bool previewReinforced)
	{
		return GetHoverStats(GetSlotObject(), previewReinforced, previewUpgraded: true);
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
