using System.Collections.Generic;
using Assets.Scripts.Flight.Sim.Orbital.Pooling.Interfaces;
using ModApi.Flight.Sim;

namespace Assets.Scripts.Flight.Sim.Orbital.Pooling
{
	public class SoiEnterInfoPool : ISoiEnterInfoPool
	{
		private const int InitialSize = 10;

		private int _maxPoolIndex;

		private int _nextAvailableIndex;

		private List<OrbitAnalyser.SoiEnterInfo> _pool;

		public SoiEnterInfoPool()
		{
			_pool = new List<OrbitAnalyser.SoiEnterInfo>(10);
			_nextAvailableIndex = 0;
			Expand(10);
		}

		public OrbitAnalyser.SoiEnterInfo Get(IOrbitNode nodeA, IOrbitNode nodeB, IOrbitPoint pointA, IOrbitPoint pointB)
		{
			if (_nextAvailableIndex > _maxPoolIndex)
			{
				Expand(_pool.Capacity);
			}
			OrbitAnalyser.SoiEnterInfo soiEnterInfo = _pool[_nextAvailableIndex++];
			soiEnterInfo.Initialize(nodeA, nodeB, pointA, pointB);
			return soiEnterInfo;
		}

		public void ReturnAll()
		{
			_nextAvailableIndex = 0;
		}

		private void Expand(int expandBy)
		{
			OrbitAnalyser.SoiEnterInfo[] array = new OrbitAnalyser.SoiEnterInfo[expandBy];
			for (int i = 0; i < expandBy; i++)
			{
				array[i] = new OrbitAnalyser.SoiEnterInfo();
			}
			_pool.AddRange(array);
			_maxPoolIndex = _pool.Capacity - 1;
		}
	}
}
