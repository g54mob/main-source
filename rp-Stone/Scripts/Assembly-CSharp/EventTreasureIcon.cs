using UnityEngine;

[RequireComponent(typeof(AsciiSprite))]
public class EventTreasureIcon : MonoBehaviour
{
	public AsciiString bonusLabel;

	public AsciiString levelLabel;

	private AsciiSprite mySprite;

	public void SetBonus(int value)
	{
		bonusLabel.SetValue("+" + value);
		bonusLabel.color = ((value > 0) ? ItemData.Rarity.GetColorForBonus(value) : ColorConstants.white);
		mySprite.colorOverride = bonusLabel.color;
	}

	public void SetLevel(int value)
	{
		string starRatingStringForDisplayLevel = ItemFactory.GetStarRatingStringForDisplayLevel(value);
		levelLabel.SetValue(starRatingStringForDisplayLevel);
	}

	private void HandleOnDraw(AsciiSprite sprite, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		bonusLabel.Draw(r, offsetX, offsetY);
		levelLabel.Draw(r, offsetX, offsetY);
	}

	private void Awake()
	{
		mySprite = GetComponent<AsciiSprite>();
		mySprite.OnDraw += HandleOnDraw;
	}
}
