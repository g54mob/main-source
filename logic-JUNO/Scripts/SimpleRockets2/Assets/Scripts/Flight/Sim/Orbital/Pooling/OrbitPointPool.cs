using System.Collections.Generic;
using Assets.Scripts.Flight.Sim.Orbital.Pooling.Interfaces;
using ModApi.Flight.Sim;

namespace Assets.Scripts.Flight.Sim.Orbital.Pooling
{
	public class OrbitPointPool : IOrbitPointPool
	{
		private const int InitialSize = 1;

		private int _maxPoolIndex;

		private int _nextAvailableIndex;

		private List<IOrbitPoint> _pool;

		public OrbitPointPool()
		{
			_pool = new List<IOrbitPoint>(1);
			_nextAvailableIndex = 0;
			Expand(1);
		}

		public IOrbitPoint Get()
		{
			if (_nextAvailableIndex > _maxPoolIndex)
			{
				Expand(_pool.Capacity);
			}
			return _pool[_nextAvailableIndex++];
		}

		public void ReturnAll()
		{
			_nextAvailableIndex = 0;
		}

		private void Expand(int expandBy)
		{
			IOrbitPoint[] array = new IOrbitPoint[expandBy];
			for (int i = 0; i < expandBy; i++)
			{
				array[i] = new OrbitPoint();
			}
			_pool.AddRange(array);
			_maxPoolIndex = _pool.Capacity - 1;
		}
	}
}
