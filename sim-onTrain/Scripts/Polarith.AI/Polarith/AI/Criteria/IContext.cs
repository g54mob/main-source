using System.Collections.Generic;

namespace Polarith.AI.Criteria
{
	public interface IContext<TValue, TStructure>
	{
		IProblem<TValue> Problem { get; }

		IList<IBehaviour> Behaviours { get; }

		IDecision<TValue, TStructure> Decision { get; }

		ISolver<TValue> Solver { get; set; }

		ISensor<TStructure> Sensor { get; set; }

		void Evaluate();
	}
}
