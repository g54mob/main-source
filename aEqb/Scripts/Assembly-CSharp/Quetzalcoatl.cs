public class Quetzalcoatl : Card
{
	public override void CardSetUp()
	{
		card_txt = "Quetzalcoatl Project\nCost: ten even dice or ten odd dice.\nPreserved die counts as two dice.";
		card_txt_cn = "羽蛇神计划\n费用：十个奇数骰或者十个偶数骰。\n保存的骰子视为两个骰子。";
		cardType = CardType.Project;
	}

	public override void EnterPlay()
	{
		Shine();
	}

	public override bool SpecialCost()
	{
		int num = 0;
		int num2 = 2;
		foreach (Dice item in gm.selected_dice)
		{
			if (num2 == 2)
			{
				num2 = item.val % 2;
			}
			else if (item.val % 2 != num2)
			{
				return false;
			}
			num = ((!item.isPreserved) ? (num + 1) : (num + 2));
		}
		if (num == 10)
		{
			return true;
		}
		return false;
	}
}
