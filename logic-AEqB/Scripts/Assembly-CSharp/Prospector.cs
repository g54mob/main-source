using UnityEngine;

public class Prospector : Card
{
	public override void CardSetUp()
	{
		cost = "aaaa";
		card_txt = "Prospector\nCost: four of a kind\nStart of turn: Roll a die, fix and preserve it";
		card_txt_cn = "勘探者\n费用：四同\n回合开始：投一个固定骰，并将其保存";
		cardType = CardType.Building;
	}

	public override void StartOfTurn()
	{
		gm.GenerateDice(0, DiceType.Fixed, preserve: true);
		Shine();
		Debug.Log("Prosepctor, Shine");
	}
}
