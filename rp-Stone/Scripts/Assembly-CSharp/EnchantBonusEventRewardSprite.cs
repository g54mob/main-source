public class EnchantBonusEventRewardSprite : AsciiSprite
{
	public AsciiString enchantBonusLabel;

	public AsciiString levelLabel;

	private int lastRarityBonus = -1;

	private int lastDisplayLevel = -1;

	public string eventId { get; set; }

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		int num = ((eventId != null) ? EventController.singleton.GetEventRarityBonus(eventId) : EventController.singleton.GetCurrentEventRewardBonus());
		if (lastRarityBonus != num)
		{
			lastRarityBonus = num;
			enchantBonusLabel.SetValue("+" + num);
			enchantBonusLabel.color = ((num > 0) ? ItemData.Rarity.GetColorForBonus(num) : ColorConstants.white);
		}
		int num2 = ((eventId != null) ? EventController.singleton.GetEventRewardLevel(eventId) : EventController.singleton.GetCurrentEventRewardLevel());
		if (lastDisplayLevel != num2)
		{
			lastDisplayLevel = num2;
			string starRatingStringForDisplayLevel = ItemFactory.GetStarRatingStringForDisplayLevel(num2);
			levelLabel.SetValue(starRatingStringForDisplayLevel);
		}
		base.Draw(r, offsetX, offsetY, enchantBonusLabel.color);
		offsetX -= pivotX;
		offsetY -= pivotY;
		if (num > 0)
		{
			enchantBonusLabel.Draw(r, offsetX, offsetY);
		}
		if (num2 > 1)
		{
			levelLabel.Draw(r, offsetX, offsetY);
		}
	}
}
