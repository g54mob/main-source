using System;
using Timberborn.Multithreading;

namespace Timberborn.SoilMoistureSystem
{
	internal readonly struct MoistureDataPreparationTask : IParallelizerSingleTask
	{
		private readonly float[] _moistureLevels;

		private readonly float[] _lastTickMoistureLevels;

		private readonly bool[] _moistureLevelsChangedLastTick;

		public MoistureDataPreparationTask(float[] moistureLevels, float[] lastTickMoistureLevels, bool[] moistureLevelsChangedLastTick)
		{
			_moistureLevels = moistureLevels;
			_lastTickMoistureLevels = lastTickMoistureLevels;
			_moistureLevelsChangedLastTick = moistureLevelsChangedLastTick;
		}

		public void Run()
		{
			_moistureLevels.AsSpan().CopyTo(_lastTickMoistureLevels);
			Array.Clear(_moistureLevelsChangedLastTick, 0, _moistureLevelsChangedLastTick.Length);
		}
	}
}
