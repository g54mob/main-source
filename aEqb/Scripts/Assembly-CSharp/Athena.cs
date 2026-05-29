public class Athena : Card
{
	public override void CardSetUp()
	{
		cost = "axyz";
		card_txt = "Athena Project\nCost: four wild";
		card_txt_cn = "雅典娜计划\n费用：四个百搭";
		cardType = CardType.Project;
	}

	public override bool SpecialCost()
	{
		foreach (Dice item in gm.selected_dice)
		{
			if (item.diceType != DiceType.Wild)
			{
				return false;
			}
		}
		return true;
	}

	public override void EnterPlay()
	{
		Shine();
	}
}
