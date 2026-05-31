using System.Collections.Generic;

public static class OnlineOrderPaperBagContainer
{
	private static List<OrderPaperBag> m_PaperBags;

	public static IReadOnlyList<OrderPaperBag> PaperBags => null;

	public static OrderPaperBag Prefab { get; set; }

	public static bool HasAttachedOrder(OrderListData data)
	{
		return false;
	}

	public static void SetPaperBagIndicators()
	{
	}

	public static void ClearPaperBagIndicators()
	{
	}

	public static OrderPaperBag Create()
	{
		return null;
	}

	public static void Despawn(OrderPaperBag instance)
	{
	}

	public static void Remove(OrderPaperBag instance)
	{
	}

	public static void Add(OrderPaperBag instance)
	{
	}

	public static void RefreshPaperBagList()
	{
	}
}
