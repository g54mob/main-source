using System.Collections.ObjectModel;

namespace Polarith.AI.Criteria
{
	public interface IProblem<T>
	{
		int ObjectiveCount { get; }

		int ValueCount { get; }

		ReadOnlyCollection<T> this[int index] { get; }

		ReadOnlyCollection<T> AddObjective(bool minimized);

		void AddValues(T value);

		void AddValues(T[] values);

		ReadOnlyCollection<T> GetObjective(int index);

		T GetValue(int objectiveIndex, int valueIndex);

		bool IsObjectiveMinimized(int index);

		void SetObjectiveMinimized(int index, bool minimized);

		void SetValue(int objectiveIndex, int valueIndex, T value);

		void ResetValues();

		void ResetValues(T value);

		void RemoveObjectiveAt(int index);

		void RemoveValuesAt(int index);

		void ResizeObjectives(int valueCount);

		void ClearObjectives();

		void ClearValues();
	}
}
