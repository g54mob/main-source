using System.Collections.Generic;
using Assets.Scripts.Flight.Sim.Orbital.Interfaces;
using Assets.Scripts.Flight.Sim.Orbital.Pooling.Interfaces;
using ModApi.Flight.Sim;

namespace Assets.Scripts.Flight.Sim.Orbital.Pooling
{
	public class OrbitIteratorPool : IOrbitIteratorPool
	{
		private const int InitialSize = 10;

		private int _maxPoolIndex;

		private int _nextAvailableIndex;

		private List<IOrbitIterator> _pool;

		public OrbitIteratorPool()
		{
			_pool = new List<IOrbitIterator>(10);
			_nextAvailableIndex = 0;
			Expand(10);
		}

		public IOrbitIterator GetIterator(IOrbit orbit, double startEa, double endEa, double eaStep)
		{
			if (_nextAvailableIndex > _maxPoolIndex)
			{
				Expand(_pool.Capacity);
			}
			IOrbitIterator orbitIterator = _pool[_nextAvailableIndex++];
			orbitIterator.Prepare(orbit, startEa, endEa, eaStep);
			return orbitIterator;
		}

		public IOrbitIterator GetIterator(IOrbit orbit)
		{
			return GetIterator(orbit, double.NaN, double.NaN, double.NaN);
		}

		public IOrbitIterator GetIteratorFromNu(IOrbit orbit, double startNu, double endNu, double eaStep)
		{
			OrbitMath.GetEaIterators(orbit, startNu, endNu, out var startEa, out var endEa);
			return GetIterator(orbit, startEa, endEa, eaStep);
		}

		public void ReturnAll()
		{
			_nextAvailableIndex = 0;
		}

		private void Expand(int expandBy)
		{
			IOrbitIterator[] array = new IOrbitIterator[expandBy];
			for (int i = 0; i < expandBy; i++)
			{
				array[i] = new OrbitIterator();
			}
			_pool.AddRange(array);
			_maxPoolIndex = _pool.Capacity - 1;
		}
	}
}
