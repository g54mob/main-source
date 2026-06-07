public class FoodRation
{
	public int Count;

	public int Capacity { get; private set; }

	public FoodRation(int capacity, int count = 0)
	{
		Capacity = capacity;
		Count = count;
	}

	public float ReturnProgress()
	{
		return (float)Count / (float)Capacity;
	}
}
