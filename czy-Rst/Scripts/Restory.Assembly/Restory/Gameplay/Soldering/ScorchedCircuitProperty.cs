using System;
using System.Collections.Generic;
using Restory.Gameplay.Elements;
using UnityEngine;

namespace Restory.Gameplay.Soldering
{
	[Serializable]
	public class ScorchedCircuitProperty : ElementAdditionalProperty
	{
		public int InitialBurntPointsCount { get; set; }

		public List<BurntTraceData> BurntTraces { get; set; }

		public bool IsResoldered
		{
			get
			{
				foreach (BurntTraceData burntTrace in BurntTraces)
				{
					if (burntTrace.SolderPoints.Count > 0)
					{
						return false;
					}
				}
				return true;
			}
		}

		public bool PreparedToSoldering()
		{
			foreach (BurntTraceData burntTrace in BurntTraces)
			{
				foreach (SolderPointData solderPoint in burntTrace.SolderPoints)
				{
					switch (solderPoint.State)
					{
					case SolderPointState.Sooty:
					case SolderPointState.Cleaned:
						return false;
					case SolderPointState.Burnt:
						return true;
					}
				}
			}
			return false;
		}

		public SolderingProgressInPercentage GetProgress()
		{
			if (InitialBurntPointsCount < 1)
			{
				Debug.LogError(string.Format("Not valid {0} value, it is {1}", "InitialBurntPointsCount", InitialBurntPointsCount));
				return SolderingProgressInPercentage.FullProgress;
			}
			int num = InitialBurntPointsCount;
			int num2 = InitialBurntPointsCount;
			foreach (BurntTraceData burntTrace in BurntTraces)
			{
				foreach (SolderPointData solderPoint in burntTrace.SolderPoints)
				{
					switch (solderPoint.State)
					{
					case SolderPointState.Sooty:
						num--;
						num2--;
						break;
					case SolderPointState.Burnt:
						num2--;
						break;
					}
				}
			}
			return new SolderingProgressInPercentage
			{
				Soot = (float)num / (float)InitialBurntPointsCount,
				Burnt = (float)num2 / (float)InitialBurntPointsCount
			};
		}
	}
}
