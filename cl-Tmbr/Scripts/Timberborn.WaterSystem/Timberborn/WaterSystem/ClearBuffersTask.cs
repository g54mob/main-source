using System;
using Timberborn.Multithreading;

namespace Timberborn.WaterSystem
{
	internal readonly struct ClearBuffersTask : IParallelizerSingleTask
	{
		private readonly float[] _contaminationsBuffer;

		private readonly byte[] _targetedDiffusionCount;

		private readonly WaterFlow[] _baseLevelFlows;

		private readonly Diffusions[] _baseLevelDiffusions;

		public ClearBuffersTask(float[] contaminationsBuffer, byte[] targetedDiffusionCount, WaterFlow[] baseLevelFlows, Diffusions[] baseLevelDiffusions)
		{
			_contaminationsBuffer = contaminationsBuffer;
			_targetedDiffusionCount = targetedDiffusionCount;
			_baseLevelFlows = baseLevelFlows;
			_baseLevelDiffusions = baseLevelDiffusions;
		}

		public void Run()
		{
			Array.Clear(_contaminationsBuffer, 0, _contaminationsBuffer.Length);
			Array.Clear(_targetedDiffusionCount, 0, _targetedDiffusionCount.Length);
			Array.Clear(_baseLevelFlows, 0, _baseLevelFlows.Length);
			Array.Clear(_baseLevelDiffusions, 0, _baseLevelDiffusions.Length);
		}
	}
}
