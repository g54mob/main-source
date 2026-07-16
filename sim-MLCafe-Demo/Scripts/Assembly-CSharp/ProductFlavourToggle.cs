using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductFlavourToggle : MonoBehaviour
{
	[SerializeField]
	public new AnomalyTag tag;

	[SerializeField]
	private TMP_Text labelToggleName;

	[SerializeField]
	private Toggle toggle;

	private ProductPricingSlot slot;

	private int flavourIndex;

	public void Init(ProductPricingSlot slot, int index)
	{
		this.slot = slot;
		flavourIndex = index;
		tag.anomalyFlags = 1 << index;
		labelToggleName.text = tag.GetFormattedLocalizedTags();
	}

	public void UpdateLocalization()
	{
		labelToggleName.text = tag.GetFormattedLocalizedTags();
	}

	public void OnToggleFlavour(bool add)
	{
		int value = slot.GetFlavours();
		AnomalyTag.SetBit(ref value, add, flavourIndex);
		slot.UpdateFlavourSelection(value);
	}

	public void SetToggle(bool value)
	{
		toggle.isOn = value;
		OnToggleFlavour(value);
	}

	public void SetToggleWithoutNotify(bool value)
	{
		toggle.SetIsOnWithoutNotify(value);
		OnToggleFlavourNoNotify(value);
	}

	public void OnToggleFlavourNoNotify(bool add)
	{
		int value = slot.GetFlavours();
		AnomalyTag.SetBit(ref value, add, flavourIndex);
		slot.UpdateFlavourDisplay(value);
	}
}
