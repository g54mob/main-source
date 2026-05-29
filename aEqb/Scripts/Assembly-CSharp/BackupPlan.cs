public class BackupPlan : Card
{
	public override void CardSetUp()
	{
		cost = "aaa";
		card_txt = "Backup Plan\nCost: three of a kind\nEnter play: Gain a presevered wild.\nEnd turn: Gain a preserved wild if no card purchase in this round.";
		card_txt_cn = "后备计划\n费用：三同\n进场: 获得一个保存的百搭\n回合结束：如果本回合没有购买卡牌，获得一个保存的百搭";
		cardType = CardType.Building;
	}

	public override void EnterPlay()
	{
		gm.GenerateDice(1, DiceType.Wild, preserve: true);
		Shine();
	}

	public override void EndOfTurn()
	{
		if (gm.cardPurchase_cnt == 0)
		{
			gm.GenerateDice(1, DiceType.Wild, preserve: true);
			Shine();
		}
	}
}
