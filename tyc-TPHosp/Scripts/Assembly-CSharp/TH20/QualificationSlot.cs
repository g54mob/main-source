using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class QualificationSlot
	{
		private bool _complete;

		public float TrainingPoints { get; private set; }

		public float FractionComplete => TrainingPoints / Definition.TrainingPoints;

		public QualificationDefinition Definition { get; private set; }

		public QualificationSlot(QualificationDefinition definition, bool complete)
		{
			_complete = complete;
			Definition = definition;
			TrainingPoints = (complete ? Definition.TrainingPoints : 0f);
		}

		public bool IsComplete()
		{
			return _complete;
		}

		public bool AddPoints(float points)
		{
			if (!_complete)
			{
				TrainingPoints = Mathf.Min(TrainingPoints + points, Definition.TrainingPoints);
				_complete = TrainingPoints.Equals(Definition.TrainingPoints);
			}
			return _complete;
		}
	}
}
