using System;
using System.Collections.Generic;

namespace ModApi.Craft
{
	public class StagingData
	{
		public List<ActivationStage> Stages { get; private set; }

		public StagingData()
		{
			Stages = new List<ActivationStage>();
		}

		public int GetStageIndex(ActivationStage stage)
		{
			int num = Stages.IndexOf(stage);
			if (num >= 0)
			{
				return num;
			}
			throw new ArgumentException("Could not find stage in staging data.");
		}
	}
}
