public class Dome : Card
{
	public override void CardSetUp()
	{
		cost = "xxxyy";
		card_txt = "Dome\nCost: Fullhouse\nStart of turn: Roll a basic dice and preserve it";
		card_txt_cn = "穹顶\n费用: 三带二\n回合开始：投一个基础骰并且将其保存";
		cardType = CardType.Building;
	}

	public override void StartOfTurn()
	{
		gm.GenerateDice(0, DiceType.Basic, preserve: true);
		Shine();
	}
}
