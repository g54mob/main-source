public class OmniMachine : Card
{
	public override void CardSetUp()
	{
		cost = "xxxxx";
		card_txt = "O. M. N. I.\nCost: five of a kind\nStart of turn: gain and preserve a wild die.";
		card_txt_cn = "全能机\n费用: 五同\n回合开始：获得并且保存一个百搭骰";
		cardType = CardType.Building;
	}

	public override void StartOfTurn()
	{
		gm.GenerateDice(1, DiceType.Wild, preserve: true);
		Shine();
	}
}
