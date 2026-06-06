using System.Collections.Generic;

public class RandomPool
{
	private List<RandomItem> _sourceList;

	private List<RandomItem> _shuffledList;

	public RandomPool(List<RandomItem> items)
	{
		_sourceList = items;
		ShufflePool();
	}

	private void ShufflePool()
	{
		_shuffledList = new List<RandomItem>(_sourceList);
		_shuffledList.Shuffle();
	}

	public RandomItem Return()
	{
		if (_shuffledList.Count == 0)
		{
			ShufflePool();
		}
		RandomItem result = _shuffledList[0];
		_shuffledList.RemoveAt(0);
		return result;
	}
}
