public class CapacityUpgrade
{
	public float capacity;

	public ItemList costList;

	public CapacityUpgrade(float capacity, params (ItemType item, float amount)[] cost)
	{
		this.capacity = capacity;
		costList = new ItemList();
		if (cost != null)
		{
			for (int i = 0; i < cost.Length; i++)
			{
				(ItemType, float) tuple = cost[i];
				costList.AddItem(tuple.Item1, tuple.Item2);
			}
		}
	}
}
