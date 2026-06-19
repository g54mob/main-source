using OUSystems.Basics.DataStructures;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuotaItemStackUI : MonoBehaviour
{
	[SerializeField]
	private Image _itemIcon;

	[SerializeField]
	private Image _fullBar;

	[SerializeField]
	private TextMeshProUGUI _countText;

	[SerializeField]
	private TextMeshProUGUI _demandText;

	public QuotaItemStack QuotaStack;

	[SerializeField]
	private ItemStackAnimator _animator;

	[SerializeField]
	private ItemTooltipTrigger _tooltipTrigger;

	[SerializeField]
	private PickupSupplier _pickupSupplier;

	[SerializeField]
	private Color _unsatisfiedColor;

	[SerializeField]
	private Color _satisfiedColor;

	public void Initiate(QuotaItemStack capacityItemStack)
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
