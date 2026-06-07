using System;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class LuggageAblityCell : SideCounterCell
{
	[Header("Inspector系")]
	[SerializeField]
	private HorizontalLayoutGroup counterTextGroup;

	[SerializeField]
	private TMP_Text counterMaxText;

	[SerializeField]
	private TMP_Text counterText;

	[SerializeField]
	private Image[] levelStarList;

	[SerializeField]
	private Image[] counterBarList;

	[SerializeField]
	private TMP_Text battleOutputText;

	[SerializeField]
	private TMP_Text outputBonusText;

	private eLuggage luggageID;

	private int[] triggerCountList;

	private int GetTriggerCount(int level)
	{
		return 0;
	}

	private int GetMinusCount(int level)
	{
		return 0;
	}

	public override void InitComponent(eLuggage luggage, Action<eLuggage> onPointerEnter, Action onPointerExit)
	{
	}

	private void SetTriggerCountList()
	{
	}

	public override void UpdateCounter()
	{
	}

	public override void ResetCell()
	{
	}

	public override void OnPointerEnter()
	{
	}

	public override void OnPointerExit()
	{
	}
}
