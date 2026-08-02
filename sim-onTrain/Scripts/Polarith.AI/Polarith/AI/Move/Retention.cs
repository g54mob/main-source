using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Polarith.AI.Criteria;
using Polarith.Utils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public class Retention : MoveBehaviour
	{
		[Tooltip("Specifies all the objectives which are influenced by this behaviour.")]
		[TargetObjective(false)]
		public List<int> TargetObjectives = new List<int>();

		[Tooltip("Determines how long old objective values are being remembered in future AI updates. The higher this value, the longer it takes for new sampled values to occur within the problem objectives.")]
		[Range(0f, 1f)]
		public float Memory = 0.5f;

		private List<List<float>> oldObjectives = new List<List<float>>();

		public override void Behave()
		{
			IProblem<float> problem = Context.Problem;
			if (TargetObjectives.Count == 0 || problem.ObjectiveCount == 0 || problem.ValueCount == 0)
			{
				return;
			}
			if (TargetObjectives.Count != oldObjectives.Count || oldObjectives.Count == 0 || oldObjectives[0].Count == 0 || problem.ValueCount != oldObjectives[0].Count)
			{
				Collections.ResizeList(oldObjectives, TargetObjectives.Count);
				for (int i = 0; i < TargetObjectives.Count; i++)
				{
					Collections.ResizeList(oldObjectives[i], problem.ValueCount);
					if (TargetObjectives[i] >= 0 && TargetObjectives[i] < problem.ObjectiveCount)
					{
						for (int j = 0; j < problem.ValueCount; j++)
						{
							oldObjectives[i][j] = problem[TargetObjectives[i]][j];
						}
					}
				}
			}
			for (int k = 0; k < TargetObjectives.Count; k++)
			{
				if (TargetObjectives[k] >= 0 && TargetObjectives[k] < problem.ObjectiveCount)
				{
					ReadOnlyCollection<float> readOnlyCollection = problem[TargetObjectives[k]];
					List<float> list = oldObjectives[k];
					for (int l = 0; l < readOnlyCollection.Count; l++)
					{
						problem.SetValue(TargetObjectives[k], l, Mathf.Lerp(readOnlyCollection[l], list[l], Memory));
						list[l] = readOnlyCollection[l];
					}
				}
			}
		}
	}
}
