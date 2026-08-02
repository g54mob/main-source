using System.Collections.ObjectModel;
using Polarith.AI.Criteria;

namespace Polarith.AI.Move
{
	public sealed class Problem : Problem<float>
	{
		private ReadOnlyCollection<float> objective;

		private float oldMin;

		private float oldMax;

		private int i;

		public void NormalizeObjective(int index)
		{
			objective = GetObjective(index);
			oldMin = float.PositiveInfinity;
			oldMax = float.NegativeInfinity;
			for (i = 0; i < base.ValueCount; i++)
			{
				if (objective[i] < oldMin)
				{
					oldMin = objective[i];
				}
				if (objective[i] > oldMax)
				{
					oldMax = objective[i];
				}
			}
			oldMin = ((oldMin < 0f) ? oldMin : 0f);
			oldMax -= oldMin;
			oldMax = ((oldMax > 1f) ? oldMax : 1f);
			for (i = 0; i < base.ValueCount; i++)
			{
				SetValue(index, i, (objective[i] - oldMin) / oldMax);
			}
		}
	}
}
