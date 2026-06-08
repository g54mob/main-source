using UnityEngine;

public class KiCrystalIcon : AsciiSprite
{
	public string itemId = "ki_crystal";

	public int[] frameThresholds;

	private string itemGroupId;

	private float cooldownSearch;

	private void Update()
	{
		cooldownSearch -= Time.deltaTime;
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		UpdateIconForAmount();
		base.Draw(r, offsetX, offsetY);
	}

	private void UpdateIconForAmount()
	{
		if (cooldownSearch > 0f || Inventory.Singleton == null)
		{
			return;
		}
		Item item;
		if (itemGroupId != null)
		{
			item = Inventory.Singleton.GetItem(itemGroupId);
			if (item == null)
			{
				cooldownSearch = 2f;
			}
		}
		else
		{
			item = Inventory.Singleton.GetFirstItemWithId(itemId);
			if (!(item != null))
			{
				cooldownSearch = 2f;
				return;
			}
			itemGroupId = item.GetGroupId();
		}
		int num = ((item != null) ? item.count : 0);
		int num2 = 0;
		for (int num3 = base.FrameCount - 1; num3 >= 1; num3--)
		{
			if (num3 <= frameThresholds.Length && num > frameThresholds[num3 - 1])
			{
				num2 = num3;
				break;
			}
		}
		SetFrameIndex(num2);
	}
}
