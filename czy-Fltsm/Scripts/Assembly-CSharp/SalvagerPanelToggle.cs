using I2.Loc;
using UnityEngine;

public class SalvagerPanelToggle : AnimatedToggle
{
	[SerializeField]
	private Localize _label;

	[SerializeField]
	private InventoryPanelItemSlot _itemSlot;

	[SerializeField]
	private string _emptyParameter = "IsEmpty";

	public void Initialize(Salvager.SalvageableCategory salvageableItem)
	{
		Initialize((IToggleable)salvageableItem);
		_label.SetTerm(salvageableItem.MainItemProperties.LocalizedNameTerm);
		_itemSlot.Initialize(salvageableItem.MainItemProperties, (!salvageableItem.Items.IsNullOrEmpty()) ? salvageableItem.Items.Count : 0);
		base.animator.SetBool(_emptyParameter, salvageableItem.Items.IsNullOrEmpty());
	}
}
