using System;
using UnityEngine;

namespace CTS.BBT
{
	internal sealed class StationSink : WorkerFurnitureInteractor
	{
		private int _dishCount;

		[SerializeField]
		private int _maxDishes = 10;

		public static Func<StationSink, int, bool> CapacityFilter { get; } = (StationSink p_sink, int p_count) => p_sink._dishCount + p_count <= p_sink._maxDishes;

		public void AddDishes(int p_count)
		{
			if (p_count >= 1)
			{
				_ = _dishCount;
				_ = 0;
				_dishCount += p_count;
			}
		}

		public void WashDishes()
		{
			_dishCount = 0;
		}
	}
}
