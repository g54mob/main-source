using System;
using System.Collections.Generic;
using Data.FactoryFloor.Drones;
using UnityEngine;

namespace Data.FactoryFloor.Behaviours
{
	[Serializable]
	public class HarvesterPadDroneHeights
	{
		[SerializeField]
		private float _heightOffsetPerDrone = 1.5f;

		private readonly List<HarvestPadDroneBehaviour> _activeDroneHeights = new List<HarvestPadDroneBehaviour>(4);

		public float HeightOffsetPerDrone => _heightOffsetPerDrone;

		public void Reset()
		{
			_activeDroneHeights.Clear();
		}

		public int ClaimNextAvailableDroneHeight(HarvestPadDroneBehaviour droneBehaviour)
		{
			_activeDroneHeights.Add(droneBehaviour);
			return _activeDroneHeights.Count - 1;
		}

		public void SetHeightAvailable(HarvestPadDroneBehaviour droneBehaviour)
		{
			int num = _activeDroneHeights.IndexOf(droneBehaviour);
			if (num != -1)
			{
				_activeDroneHeights.RemoveAt(num);
				for (int i = num; i < _activeDroneHeights.Count; i++)
				{
					_activeDroneHeights[i].UpdateHeightIndex(i);
				}
			}
		}
	}
}
