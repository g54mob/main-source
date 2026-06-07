using System.Collections.Generic;

public static class eItemTypeExtension
{
	private const int TowerBaseId = 1000;

	private const int RelicBaseId = 4001;

	private const int BitsPerItem = 8;

	private const int BitsPerInt = 32;

	private const ulong IndexMask = 255uL;

	public static eCardType ToCardType(this eItemType itemType)
	{
		return default(eCardType);
	}

	public static int GetRuneActivateOrder(this eItemType itemType)
	{
		return 0;
	}

	public static int[] EncodeRelicToBit(List<eItemType> relics)
	{
		return null;
	}

	public static int[] EncodeTowerToBit(List<eItemType> relics)
	{
		return null;
	}

	public static int[] EncodeItemToBit(List<eItemType> items, int baseID)
	{
		return null;
	}

	public static List<eItemType> DecodeTowerFromBit(List<int> encoded, int itemCount)
	{
		return null;
	}

	public static List<eItemType> DecodeRelicFromBit(List<int> encoded, int itemCount)
	{
		return null;
	}

	public static List<eItemType> DecodeItemFromBit(List<int> encoded, int itemCount, int baseID)
	{
		return null;
	}
}
