public class TrainingCamp : Card
{
	public override void CardSetUp()
	{
		cost = "aabb";
		card_txt = "Training Camp\nCost: two pairs in a row\nClick: A die > flip it.";
		card_txt_cn = "训练营地\n费用：二连对\n点击：一个骰子 > 将其翻转";
		cardType = CardType.Building;
		maxenergy = 1;
	}

	public override void Activate()
	{
		if (Match("a"))
		{
			gm.selected_dice[0].val = 7 - gm.selected_dice[0].val;
			energy--;
		}
	}
}
