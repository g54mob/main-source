public class NanoBot : Card
{
	public override void CardSetUp()
	{
		cost = "abc";
		card_txt = "Nanobot\nCost: three in a row\nEnter play: Roll a die, fix and preserve it.\nClick: Reroll a basic or fixed die.";
		card_txt_cn = "纳米机器人\n费用: 三连\n进场：投一个骰子，将其固定并保存\n点击：重投一个基础或者固定骰。";
		cardType = CardType.Building;
		maxenergy = 1;
	}

	public override void EnterPlay()
	{
		gm.GenerateDice(0, DiceType.Fixed, preserve: true);
	}

	public override void Activate()
	{
		if (Match("x") && gm.selected_dice[0].diceType != DiceType.Wild)
		{
			gm.selected_dice[0].Reroll();
			gm.WhenReroll();
			energy--;
		}
	}
}
