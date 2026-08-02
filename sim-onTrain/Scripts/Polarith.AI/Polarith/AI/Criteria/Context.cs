using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Polarith.AI.Criteria
{
	public abstract class Context<TValue, TStructure> : IContext<TValue, TStructure>
	{
		protected readonly IList<IBehaviour> behaviours = new List<IBehaviour>();

		protected ISolver<TValue> solver;

		protected ISensor<TStructure> sensor;

		protected ReadOnlyCollection<int> solutionIndices;

		private int i;

		private int index;

		public abstract IProblem<TValue> Problem { get; }

		public abstract IDecision<TValue, TStructure> Decision { get; }

		public IList<IBehaviour> Behaviours => behaviours;

		public ISolver<TValue> Solver
		{
			get
			{
				return solver;
			}
			set
			{
				solver = value;
			}
		}

		public ISensor<TStructure> Sensor
		{
			get
			{
				return sensor;
			}
			set
			{
				sensor = value;
			}
		}

		public virtual void Evaluate()
		{
			if (Problem.ObjectiveCount == 0 || sensor == null)
			{
				return;
			}
			Problem.ResizeObjectives(sensor.ReceptorCount);
			Problem.ResetValues();
			index = 0;
			i = 0;
			while (i < behaviours.Count && behaviours[i].Order < 2000)
			{
				if (behaviours[i].Enabled)
				{
					behaviours[i].Behave();
				}
				index++;
				i++;
			}
			MakeDecision();
			for (i = index; i < behaviours.Count; i++)
			{
				if (behaviours[i].Enabled)
				{
					behaviours[i].Behave();
				}
			}
		}

		protected virtual void MakeDecision()
		{
			solutionIndices = solver.Solve(Problem);
		}
	}
}
