using OUSystems.Basics.DataStructures;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrafterOutputUI : MonoBehaviour
{
	[SerializeField]
	private Image _itemIcon;

	[SerializeField]
	private TextMeshProUGUI _countText;

	[SerializeField]
	private ItemStackAnimator _animator;

	private QuotaGroup _currentStandingQuota;

	[SerializeField]
	private ItemTooltipTrigger _tooltipTrigger;

	private ItemType _outcomeType;

	public void SetTo(ItemType outcomeType, QuotaGroup quota)
	{
	}

	private void Clear()
	{
	}

	private void UpdateMultiples(ValueUpdateData<int> multiplesUpdate)
	{
	}
}
