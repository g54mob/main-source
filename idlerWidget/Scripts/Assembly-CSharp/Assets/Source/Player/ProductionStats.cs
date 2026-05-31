using System.Collections.Generic;
using Assets.Source.Item;

namespace Assets.Source.Player
{
	public class ProductionStats
	{
		public const float UpdateWindow = 1f;

		public const int StatsCount = 30;

		private int[] _currentProduction;

		private int[] _currentConsumption;

		private float _updateTime;

		private List<int[]> _productionStats;

		private List<int[]> _consumptionStats;

		public ProductionStats()
		{
			_productionStats = new List<int[]>();
			_consumptionStats = new List<int[]>();
			_resetCurrent();
		}

		public void AddProduction(ItemType type, int count)
		{
			_currentProduction[type.Ordinal] += count;
		}

		public void AddConsumption(ItemType type, int count)
		{
			_currentConsumption[type.Ordinal] += count;
		}

		public float GetConsumption(ItemType type)
		{
			if (_consumptionStats.Count == 0)
			{
				return 0f;
			}
			float num = 0f;
			for (int i = 0; i < _consumptionStats.Count; i++)
			{
				num += (float)_consumptionStats[i][type.Ordinal];
			}
			return num / (float)_consumptionStats.Count;
		}

		public float GetProduction(ItemType type)
		{
			if (_productionStats.Count == 0)
			{
				return 0f;
			}
			float num = 0f;
			for (int i = 0; i < _productionStats.Count; i++)
			{
				num += (float)_productionStats[i][type.Ordinal];
			}
			return num / (float)_productionStats.Count;
		}

		public void Update(float delta)
		{
			_updateTime += delta;
			if (_updateTime > 1f)
			{
				_updateTime = 0f;
				_productionStats.Add(_currentProduction);
				_consumptionStats.Add(_currentConsumption);
				_resetCurrent();
				if (_productionStats.Count > 30)
				{
					_productionStats.RemoveAt(0);
					_consumptionStats.RemoveAt(0);
				}
			}
		}

		private void _resetCurrent()
		{
			_currentProduction = new int[ItemType.Count];
			_currentConsumption = new int[ItemType.Count];
		}
	}
}
