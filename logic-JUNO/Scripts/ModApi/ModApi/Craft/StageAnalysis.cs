using System.Collections.Generic;

namespace ModApi.Craft
{
	public class StageAnalysis
	{
		public class Stage
		{
			public float AverageEngineIsp { get; set; }

			public float BurnTime { get; set; }

			public float DeltaV { get; set; }

			public float EndingMass { get; set; }

			public float EndingThrustToWeightRatio
			{
				get
				{
					if (EndingMass > 0f && Gravity > 0f)
					{
						return TotalThrust / (EndingMass * Gravity);
					}
					return 0f;
				}
			}

			public float Gravity { get; set; }

			public int NumEngines { get; set; }

			public int NumParts { get; set; }

			public float PropellantMass => StartingMass - EndingMass;

			public int StageNumber { get; set; }

			public float StartingMass { get; set; }

			public float StartingThrustToWeightRatio
			{
				get
				{
					if (StartingMass > 0f && Gravity > 0f)
					{
						return TotalThrust / (StartingMass * Gravity);
					}
					return 0f;
				}
			}

			public float TotalThrust { get; set; }
		}

		public float EndingThrustToWeightRatio { get; set; }

		public int NumEngines { get; set; }

		public float PropellantMass
		{
			get
			{
				float num = 0f;
				foreach (Stage stage in Stages)
				{
					num += stage.PropellantMass;
				}
				return num;
			}
		}

		public List<Stage> Stages { get; private set; }

		public float StartingThrustToWeightRatio { get; set; }

		public float TotalBurnTime { get; set; }

		public float TotalDeltaV { get; set; }

		public float TotalThrust { get; set; }

		public StageAnalysis()
		{
			Stages = new List<Stage>();
		}
	}
}
