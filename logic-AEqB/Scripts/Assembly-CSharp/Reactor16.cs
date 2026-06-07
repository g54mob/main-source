public class Reactor16 : Card
{
	public override void CardSetUp()
	{
		sumCost = 16;
		card_txt = "Reactor\nCost: Sum=16\nClick: 2 dice > equally distribute their value";
		card_txt_cn = "反应堆\n费用：总和=16\n点击：两个骰子 > 平均分配二者的点数";
		cardType = CardType.Building;
		maxenergy = 1;
	}

	public override void Activate()
	{
		if (!Match("xy"))
		{
			return;
		}
		energy--;
		int val = gm.selected_dice[0].val;
		int val2 = gm.selected_dice[1].val;
		int num = (val + val2) / 2;
		if ((val + val2) % 2 == 1)
		{
			if (val > val2)
			{
				val = num + 1;
				val2 = num;
			}
			else
			{
				val = num;
				val2 = num + 1;
			}
		}
		else
		{
			val = num;
			val2 = num;
		}
		gm.selected_dice[0].SetValue(val);
		gm.selected_dice[1].SetValue(val2);
	}
}
