using System;
using Timberborn.Multithreading;

namespace Timberborn.SoilContaminationSystem
{
	internal readonly struct ContaminationDataPreparationTask : IParallelizerSingleTask
	{
		private readonly float[] _contaminationCandidates;

		private readonly float[] _lastTickContaminationCandidates;

		private readonly bool[] _contaminationsChangedLastTick;

		public ContaminationDataPreparationTask(float[] contaminationCandidates, float[] lastTickContaminationCandidates, bool[] contaminationsChangedLastTick)
		{
			_contaminationCandidates = contaminationCandidates;
			_lastTickContaminationCandidates = lastTickContaminationCandidates;
			_contaminationsChangedLastTick = contaminationsChangedLastTick;
		}

		public void Run()
		{
			_contaminationCandidates.AsSpan().CopyTo(_lastTickContaminationCandidates);
			Array.Clear(_contaminationsChangedLastTick, 0, _contaminationsChangedLastTick.Length);
		}
	}
}
