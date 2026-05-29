public class Forge : Card
{
	public override void CardSetUp()
	{
		card_txt = "Forge\nClick: Three in a row > Gain a preserved Wild die";
		card_txt_cn = "锻炉\n点击: 三连 > 获得一个已保存的百搭骰";
		cardType = CardType.Basic;
		maxenergy = 1;
	}

	public override void Activate()
	{
		if (Match("abc"))
		{
			gm.RemoveSelectedDice();
			energy--;
			gm.GenerateDice(0, DiceType.Wild, preserve: true);
		}
	}
}
