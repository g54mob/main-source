using UnityEngine;

public class Herus : Card
{
	public override void CardSetUp()
	{
		card_txt = "Herus Project\nCost: six in a row\nCan't be purchased if you activated Command Center this turn.";
		card_txt_cn = "荷鲁斯计划\n费用：六连\n如果本回合你使用过指挥中心，无法购买";
		cardType = CardType.Project;
	}

	public override bool SpecialCost()
	{
		if (Match("abcdef"))
		{
			return Object.FindObjectOfType<AICenter>().energy >= 2;
		}
		return false;
	}

	public override void EnterPlay()
	{
		Shine();
	}
}
