using System.Collections.Generic;

public class Quantum : Card
{
	public override void CardSetUp()
	{
		cost = "aabb";
		card_txt = "Quantum Computer\nCost: two pairs in a row\nClick: Reroll all selected basic dice";
		card_txt_cn = "量子计算机\n费用：二连对\n点击：重投所有选择的基础骰";
		cardType = CardType.Building;
		maxenergy = 1;
	}

	public override void Activate()
	{
		bool flag = false;
		List<Dice> list = new List<Dice>();
		foreach (Dice item in gm.selected_dice)
		{
			if (item.diceType == DiceType.Basic)
			{
				flag = true;
				list.Add(item);
			}
		}
		if (!flag)
		{
			gm.SetMessage("No basic dice selected", "未选择基础骰");
			return;
		}
		foreach (Dice item2 in list)
		{
			item2.Reroll();
		}
		gm.WhenReroll();
		energy--;
	}
}
