using TMPro;
using UnityEngine;

public class ScalingUpgradeGroup : MonoBehaviour
{
	public StatDisplayItem StatItem;

	public StatPropDisplayItem[] PropItems;

	public TextMeshProUGUI TxtScalingPrev;

	public TextMeshProUGUI TxtScalingNew;

	public CoolButton BtnPrev;

	public CoolButton BtnNext;

	private StatType _statType;

	private int _displayedStat;

	private StatScaling _prevScaling;

	private void Awake()
	{
	}

	public void Init(StatType statType, StatScaling prevScaling)
	{
	}

	private void SetDisplayedStat(int val)
	{
	}

	private void OnPrevClicked()
	{
	}

	private void OnNextClicked()
	{
	}

	private void RefreshBtns()
	{
	}
}
