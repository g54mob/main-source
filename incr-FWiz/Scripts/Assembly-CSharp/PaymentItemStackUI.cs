using OUSystems.Basics.DataStructures;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PaymentItemStackUI : MonoBehaviour
{
	[SerializeField]
	private Image _itemIcon;

	[SerializeField]
	private Image _fullBar;

	[SerializeField]
	private TextMeshProUGUI _countText;

	[SerializeField]
	private TextMeshProUGUI _demandText;

	public PaymentItemStack PaymentStack;

	[SerializeField]
	private ItemStackAnimator animator;

	[SerializeField]
	private ItemTooltipTrigger _tooltipTrigger;

	public void Set(PaymentItemStack capacityItemStack)
	{
	}

	public void Clear()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnChange(ValueUpdateData<int> update)
	{
	}

	public void UpdateCount()
	{
	}
}
