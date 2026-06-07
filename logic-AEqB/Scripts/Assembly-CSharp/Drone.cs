public class Drone : Card
{
	public override void CardSetUp()
	{
		cost = special_num.ToString() + special_num + special_num;
		card_txt = "Drone\nCost: " + special_num + ", " + special_num + ", " + special_num + "\nStart of turn: Gain a fixed " + special_num;
		card_txt_cn = "无人机\n费用: " + special_num + ", " + special_num + ", " + special_num + "\n回合开始：获得一个固定的" + special_num;
		cardType = CardType.Building;
	}

	public override void StartOfTurn()
	{
		gm.GenerateDice(special_num, DiceType.Fixed, preserve: false);
		Shine();
	}
}
