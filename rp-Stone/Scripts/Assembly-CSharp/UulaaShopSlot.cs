using System.Collections.Generic;
using UnityEngine;

public class UulaaShopSlot : GateShopSlot
{
	public int preferredNameWidth = 10;

	private int nameInitialX;

	private int iconInitialX;

	private bool isLost;

	protected override void SetupTitle(ShopData.Entry entryData, Item itemPrefab = null)
	{
		base.SetupTitle(entryData, itemPrefab);
		nameLabel0.PositionX = nameInitialX;
		nameLabel1.PositionX = nameInitialX;
		nameLabel2.PositionX = nameInitialX;
		nameLabel3.PositionX = nameInitialX;
		costLabel.PositionX = nameInitialX;
		iconPosX = iconInitialX;
		int num = Mathf.Max(nameLabel0.Value.Length, Mathf.Max(nameLabel1.Value.Length, nameLabel2.Value.Length));
		if (num >= preferredNameWidth + 2)
		{
			nameLabel0.PositionX -= 2;
			nameLabel1.PositionX -= 2;
			nameLabel2.PositionX -= 2;
			nameLabel3.PositionX -= 2;
			costLabel.PositionX -= 2;
			iconPosX--;
		}
		else if (num >= preferredNameWidth + 1)
		{
			nameLabel0.PositionX--;
			nameLabel1.PositionX--;
			nameLabel2.PositionX--;
			nameLabel3.PositionX--;
			costLabel.PositionX--;
		}
	}

	protected override void SetupIcon(ShopData.Entry entryData, Item itemPrefab = null)
	{
		base.SetupIcon(entryData, itemPrefab);
		isLost = itemPrefab != null && itemPrefab.isLost;
	}

	protected override void SetupCost(ShopData.Entry entryData)
	{
		int num = ShopController.ComputeKiCost(entryData);
		if (num <= 0)
		{
			costLabel.SetValue(Te.xt("tid_shop_5_free"));
			costLabel.ClearColorMask();
		}
		else
		{
			costLabel.SetValue("♦ " + Utils.FormatNumber(num));
			costLabel.SetColorMask(new List<Color> { Color.magenta });
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (icon != null && base.mode == Mode.Normal)
		{
			int offsetX2 = icon.lastDrawX + icon.pivotX;
			int offsetY2 = icon.lastDrawY + icon.pivotY;
			if (isLost)
			{
				IconLoader.Singleton.lostItemLaurels.Draw(r, offsetX2, offsetY2);
			}
			icon.Draw(r, offsetX2, offsetY2);
			DrawName(r, offsetX, offsetY);
		}
	}

	protected override void Start()
	{
		base.Start();
	}

	protected override void Awake()
	{
		base.Awake();
		nameInitialX = nameLabel0.PositionX;
		iconInitialX = iconPosX;
	}
}
