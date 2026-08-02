using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Polarith.Utils;
using UnityEngine;

namespace Polarith.AI.Criteria
{
	public class ConstraintSolver<T> : ISolver<T> where T : IComparable, IComparable<T>
	{
		[Tooltip("The index of the unrestricted objective.")]
		public int Unlimited;

		[Tooltip("Specifies the epsilon-constraints for each corresponding objective.")]
		public List<T> Epsilons = new List<T>();

		private readonly List<int> solutionIndices = new List<int> { 0 };

		private ReadOnlyCollection<int> readOnlySolutionIndices;

		private List<ReadOnlyCollection<T>> data = new List<ReadOnlyCollection<T>>();

		private int index;

		private int i;

		private int j;

		private bool flag;

		public ConstraintSolver()
		{
			readOnlySolutionIndices = solutionIndices.AsReadOnly();
		}

		public ReadOnlyCollection<int> Solve(IProblem<T> problem)
		{
			if (Epsilons.Count < problem.ObjectiveCount)
			{
				solutionIndices[0] = 0;
				throw new IndexOutOfRangeException("There are not enough 'Epsilons' to match the number of objectives");
			}
			Collections.ResizeListDefault(data, problem.ObjectiveCount);
			for (i = 0; i < problem.ObjectiveCount; i++)
			{
				data[i] = problem.GetObjective(i);
			}
			index = -1;
			flag = true;
			for (i = 0; i < problem.ValueCount; i++)
			{
				flag = true;
				for (j = 0; j < problem.ObjectiveCount; j++)
				{
					if (j != Unlimited && (problem.IsObjectiveMinimized(j) ? (data[j][i].CompareTo(Epsilons[j]) > 0) : (data[j][i].CompareTo(Epsilons[j]) < 0)))
					{
						flag = false;
					}
				}
				if (flag)
				{
					if (index == -1)
					{
						index = i;
					}
					else if (problem.IsObjectiveMinimized(Unlimited) ? (data[Unlimited][i].CompareTo(data[Unlimited][index]) < 0) : (data[Unlimited][i].CompareTo(data[Unlimited][index]) > 0))
					{
						index = i;
					}
				}
			}
			if (index < 0)
			{
				index = 0;
				for (i = 1; i < problem.ValueCount; i++)
				{
					flag = true;
					for (j = 0; j < problem.ObjectiveCount; j++)
					{
						if (problem.IsObjectiveMinimized(j) ? (data[j][i].CompareTo(data[j][index]) > 0) : (data[j][i].CompareTo(data[j][index]) < 0))
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						index = i;
					}
				}
			}
			solutionIndices[0] = index;
			return readOnlySolutionIndices;
		}
	}
}
