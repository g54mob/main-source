public class UnstablePrototype : Card
{
	public override void CardSetUp()
	{
		cost = "abc";
		card_txt = "Prototype\nCost: three in a row\nStart of turn: Gain a fixed die of random value";
		card_txt_cn = "原型机\n费用: 三连\n回合开始：获得一个随机数值的固定骰";
		cardType = CardType.Building;
	}

	public override void StartOfTurn()
	{
		gm.GenerateDice(0, DiceType.Fixed, preserve: false);
		Shine();
	}
}
