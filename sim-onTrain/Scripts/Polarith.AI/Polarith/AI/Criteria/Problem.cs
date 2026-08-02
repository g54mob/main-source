using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Polarith.AI.Criteria
{
	public class Problem<T> : IProblem<T>
	{
		private sealed class Objective
		{
			public readonly List<T> Values = new List<T>();

			public ReadOnlyCollection<T> ReadOnlyValues;

			public bool Minimized = true;

			public Objective()
			{
				ReadOnlyValues = Values.AsReadOnly();
			}
		}

		private readonly IList<Objective> objectives = new List<Objective>();

		private int i;

		private int j;

		public int ObjectiveCount => objectives.Count;

		public int ValueCount
		{
			get
			{
				if (objectives.Count <= 0)
				{
					return 0;
				}
				return objectives[0].Values.Count;
			}
		}

		public ReadOnlyCollection<T> this[int index] => objectives[index].ReadOnlyValues;

		public ReadOnlyCollection<T> AddObjective(bool minimized)
		{
			Objective objective = new Objective();
			if (objectives.Count > 0)
			{
				for (i = 0; i < objectives[0].Values.Count; i++)
				{
					objective.Values.Add(default(T));
				}
			}
			objective.Minimized = minimized;
			objectives.Add(objective);
			return objective.ReadOnlyValues;
		}

		public void AddValues(T value)
		{
			for (i = 0; i < objectives.Count; i++)
			{
				objectives[i].Values.Add(value);
			}
		}

		public void AddValues(T[] values)
		{
			if (values.Length != objectives.Count)
			{
				throw new InvalidOperationException("The length of 'values' is not equal to the objective count");
			}
			for (i = 0; i < objectives.Count; i++)
			{
				objectives[i].Values.Add(values[i]);
			}
		}

		public ReadOnlyCollection<T> GetObjective(int index)
		{
			return objectives[index].ReadOnlyValues;
		}

		public T GetValue(int objectiveIndex, int valueIndex)
		{
			return objectives[objectiveIndex].Values[valueIndex];
		}

		public bool IsObjectiveMinimized(int index)
		{
			return objectives[index].Minimized;
		}

		public void SetObjectiveMinimized(int index, bool minimized)
		{
			objectives[index].Minimized = minimized;
		}

		public void SetValue(int objectiveIndex, int valueIndex, T value)
		{
			objectives[objectiveIndex].Values[valueIndex] = value;
		}

		public void ResetValues()
		{
			for (i = 0; i < objectives.Count; i++)
			{
				for (j = 0; j < objectives[i].Values.Count; j++)
				{
					objectives[i].Values[j] = default(T);
				}
			}
		}

		public void ResetValues(T value)
		{
			for (i = 0; i < objectives.Count; i++)
			{
				for (j = 0; j < objectives[i].Values.Count; j++)
				{
					objectives[i].Values[j] = value;
				}
			}
		}

		public void RemoveObjectiveAt(int index)
		{
			objectives.RemoveAt(index);
		}

		public void RemoveValuesAt(int index)
		{
			for (i = 0; i < objectives.Count; i++)
			{
				objectives[i].Values.RemoveAt(index);
			}
		}

		public void ResizeObjectives(int valueCount)
		{
			if (objectives.Count != 0)
			{
				while (ValueCount < valueCount)
				{
					AddValues(default(T));
				}
				while (ValueCount > valueCount)
				{
					RemoveValuesAt(ValueCount - 1);
				}
			}
		}

		public void ClearObjectives()
		{
			objectives.Clear();
		}

		public void ClearValues()
		{
			for (i = 0; i < objectives.Count; i++)
			{
				objectives[i].Values.Clear();
			}
		}
	}
}
