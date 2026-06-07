using UnityEngine;

public class MonoPole2 : Card
{
	public override void CardSetUp()
	{
		cost = "xyz";
		card_txt = "Monopole\nCost: three odd. All your other dice must be odd.\nStart of turn: Gain a fixed die of odd value";
		card_txt_cn = "磁单极\n费用: 三个奇数。你的其他骰子必须均为奇数\n回合开始：获得一个奇数固定骰";
		cardType = CardType.Building;
	}

	public override bool SpecialCost()
	{
		foreach (Dice die in gm.dice)
		{
			if (die.val % 2 == 0)
			{
				return false;
			}
		}
		foreach (Dice item in gm.preserved_dice)
		{
			if (item.val % 2 == 0)
			{
				return false;
			}
		}
		return true;
	}

	public override void StartOfTurn()
	{
		int num = Random.Range(1, 4);
		gm.GenerateDice(num * 2 - 1, DiceType.Fixed, preserve: false);
		Shine();
	}
}
