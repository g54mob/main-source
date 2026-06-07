public class Recycling : Card
{
	public override void CardSetUp()
	{
		cost = "aaa";
		card_txt = "Recylcing\nCost: three of a kind.\nWhen you spend a wild die, roll an extra die at the start of next round.";
		card_txt_cn = "回收利用\n费用：三同\n每当你消耗一个百搭骰，在下回合开始时多投一个骰子";
		cardType = CardType.Building;
	}

	public override void EnterPlay()
	{
		gm.ability.Add("recycling");
	}

	public override void StartOfTurn()
	{
		for (int i = 0; i < special_num; i++)
		{
			gm.GenerateDice(0, DiceType.Basic, preserve: false);
		}
		if (special_num > 0)
		{
			Shine();
		}
		special_num = 0;
	}
}
