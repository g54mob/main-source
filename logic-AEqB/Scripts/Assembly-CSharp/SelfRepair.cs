public class SelfRepair : Card
{
	public override void CardSetUp()
	{
		cost = "aaaa";
		card_txt = "Selfrepair Material\nCost: four of a kind\nEnd of turn: If you have no non-preserved dice, roll two more in the next turn";
		card_txt_cn = "自我修复材料\n费用：四同\n回合结束：如果你没有未被保存的骰子，下回合多两个骰子";
		cardType = CardType.Building;
		special_num = 0;
	}

	public override void EndOfTurn()
	{
		if (gm.dice.Count == 0)
		{
			special_num = 2;
		}
	}

	public override void StartOfTurn()
	{
		if (special_num != 0)
		{
			Shine();
			special_num = 0;
			gm.GenerateDice(0, DiceType.Basic, preserve: false);
			gm.GenerateDice(0, DiceType.Basic, preserve: false);
		}
	}
}
