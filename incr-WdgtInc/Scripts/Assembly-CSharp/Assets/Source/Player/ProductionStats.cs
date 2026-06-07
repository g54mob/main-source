using System.Collections.Generic;
using System.Numerics;
using Assets.Source.Item;

namespace Assets.Source.Player
{
	public class ProductionStats
	{
		public const float UpdateWindow = 1f;

		public const int StatsCount = 30;

		private BigInteger[] _currentProduction;

		private BigInteger[] _currentConsumption;

		private float _updateTime;

		private List<BigInteger[]> _productionStats;

		private List<BigInteger[]> _consumptionStats;

		public ProductionStats()
		{
			_productionStats = new List<BigInteger[]>();
			_consumptionStats = new List<BigInteger[]>();
			_resetCurrent();
		}

		public void AddProduction(ItemType type, BigInteger count)
		{
			_currentProduction[type.Ordinal] += count;
		}

		public void AddConsumption(ItemType type, BigInteger count)
		{
			_currentConsumption[type.Ordinal] += count;
		}

		public double GetConsumption(ItemType type)
		{
			if (_consumptionStats.Count == 0)
			{
				return 0.0;
			}
			double num = 0.0;
			for (int i = 0; i < _consumptionStats.Count; i++)
			{
				num += (double)_consumptionStats[i][type.Ordinal];
			}
			return num / (double)_consumptionStats.Count;
		}

		public double GetProduction(ItemType type)
		{
			if (_productionStats.Count == 0)
			{
				return 0.0;
			}
			double num = 0.0;
			for (int i = 0; i < _productionStats.Count; i++)
			{
				num += (double)_productionStats[i][type.Ordinal];
			}
			return num / (double)_productionStats.Count;
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
			_currentProduction = new BigInteger[ItemType.Count];
			_currentConsumption = new BigInteger[ItemType.Count];
		}
	}
}
