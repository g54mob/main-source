public class Freya : Card
{
	public override void CardSetUp()
	{
		cost = "aabbccdd";
		card_txt = "Freya Project\nCost: four pairs in a row";
		card_txt_cn = "芙蕾雅计划\n费用：连续四对";
		cardType = CardType.Project;
	}

	public override void EnterPlay()
	{
		Shine();
	}
}
