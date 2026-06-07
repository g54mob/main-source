using System.Collections.Generic;

public class AICenter : Card
{
	public override void CardSetUp()
	{
		SetText("Command Center\nClick: Reroll all selected basic dice. (*2)", "指挥中心\n点击: 重投所有选中的基础骰。 (*2)");
		cardType = CardType.Basic;
		maxenergy = 2;
	}

	public override void StartOfTurn()
	{
		SetText("Command Center\nClick: Reroll all selected basic dice. (*" + energy + ")", "指挥中心\n点击: 重投所有选中的基础骰。 (*" + energy + ")");
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
		SetText("Command Center\nClick: Reroll all selected basic dice. (*" + energy + ")", "指挥中心\n点击: 重投所有选中的基础骰。 (*" + energy + ")");
	}
}
