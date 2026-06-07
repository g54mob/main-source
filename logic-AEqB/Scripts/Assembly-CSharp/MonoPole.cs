using UnityEngine;

public class MonoPole : Card
{
	public override void CardSetUp()
	{
		cost = "xyz";
		card_txt = "Monopole\nCost: three even. All your other dice must be even.\nStart of turn: Gain a fixed die of even value";
		card_txt_cn = "磁单极\n费用: 三个偶数。你的其他骰子必须均为偶数\n回合开始：获得一个偶数固定骰";
		cardType = CardType.Building;
	}

	public override bool SpecialCost()
	{
		foreach (Dice die in gm.dice)
		{
			if (die.val % 2 == 1)
			{
				return false;
			}
		}
		foreach (Dice item in gm.preserved_dice)
		{
			if (item.val % 2 == 1)
			{
				return false;
			}
		}
		return true;
	}

	public override void StartOfTurn()
	{
		int num = Random.Range(1, 4);
		gm.GenerateDice(num * 2, DiceType.Fixed, preserve: false);
		Shine();
	}
}
