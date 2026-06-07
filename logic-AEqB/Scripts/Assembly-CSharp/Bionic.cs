public class Bionic : Card
{
	public override void CardSetUp()
	{
		cost = "aaaa";
		card_txt = "Bionic Robot\nCost: four of a kind\nWhen reroll: If exactly one die is rerolled, gain a basic die";
		card_txt_cn = "仿生机器人\n费用: 四同\n重投时：如果恰好一个骰子被重投，获得一个基础骰";
		cardType = CardType.Building;
	}

	public override void WhenReroll()
	{
		if (gm.selected_dice.Count == 1)
		{
			gm.GenerateDice(0, DiceType.Basic, preserve: false);
			Shine();
		}
	}
}
