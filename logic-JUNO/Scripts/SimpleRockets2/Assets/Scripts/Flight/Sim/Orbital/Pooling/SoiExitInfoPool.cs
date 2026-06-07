using System.Collections.Generic;
using Assets.Scripts.Flight.Sim.Orbital.Pooling.Interfaces;
using ModApi.Flight.Sim;

namespace Assets.Scripts.Flight.Sim.Orbital.Pooling
{
	public class SoiExitInfoPool : ISoiExitInfoPool
	{
		private const int InitialSize = 10;

		private int _maxPoolIndex;

		private int _nextAvailableIndex;

		private List<OrbitAnalyser.SoiExitInfo> _pool;

		public SoiExitInfoPool()
		{
			_pool = new List<OrbitAnalyser.SoiExitInfo>(10);
			_nextAvailableIndex = 0;
			Expand(10);
		}

		public OrbitAnalyser.SoiExitInfo Get(IOrbitNode nodeA, IOrbitNode nodeB, IOrbitPoint escapePointA, IOrbitPoint escapePointB)
		{
			if (_nextAvailableIndex > _maxPoolIndex)
			{
				Expand(_pool.Capacity);
			}
			OrbitAnalyser.SoiExitInfo soiExitInfo = _pool[_nextAvailableIndex++];
			soiExitInfo.Initialize(nodeA, nodeB, escapePointA, escapePointB);
			return soiExitInfo;
		}

		public void ReturnAll()
		{
			_nextAvailableIndex = 0;
		}

		private void Expand(int expandBy)
		{
			OrbitAnalyser.SoiExitInfo[] array = new OrbitAnalyser.SoiExitInfo[expandBy];
			for (int i = 0; i < expandBy; i++)
			{
				array[i] = new OrbitAnalyser.SoiExitInfo();
			}
			_pool.AddRange(array);
			_maxPoolIndex = _pool.Capacity - 1;
		}
	}
}
