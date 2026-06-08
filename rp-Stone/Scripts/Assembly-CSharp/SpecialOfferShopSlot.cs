using System.Collections.Generic;
using UnityEngine;

public class SpecialOfferShopSlot : UulaaShopSlot
{
	public AsciiSprite borderLeft;

	public AsciiSprite borderRight;

	public AsciiString specialOfferTitle;

	public AsciiString percentOffLabel;

	public override void SetContent(ShopData.Entry entryData)
	{
		base.SetContent(entryData);
		ShopData.SpecialOffer obj = (ShopData.SpecialOffer)entryData;
		specialOfferTitle.SetValue(" " + Te.xt("Special Offer") + " ");
		int value = obj.saleCost.GetValue();
		if (value > 0)
		{
			costLabel.SetValue("♦ " + Utils.FormatNumber(value));
			costLabel.SetColorMask(new List<Color> { Color.magenta });
		}
		int value2 = obj.baseCost.GetValue();
		if (value2 > 0)
		{
			int num = (value2 - value) * 100 / value2;
			percentOffLabel.SetValue(" -" + num + "% ");
		}
		else
		{
			percentOffLabel.Clear();
		}
		costLabel.PositionX = percentOffLabel.PositionX;
		if (percentOffLabel.Length > 0)
		{
			costLabel.PositionX += percentOffLabel.Length + 1;
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		borderLeft.Draw(r, offsetX, offsetY);
		borderRight.Draw(r, offsetX, offsetY);
		if (base.mode == Mode.Normal)
		{
			specialOfferTitle.Draw(r, offsetX, offsetY);
			if (!base.activated || !IsMouseInside())
			{
				percentOffLabel.Draw(r, offsetX, offsetY);
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		percentOffLabel.backgroundColor = new Color(0.29803923f, 0.41960785f, 2f / 15f);
	}
}
