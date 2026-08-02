using System;
using Polarith.AI.Criteria;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public class Stabilization : MoveBehaviour
	{
		[Tooltip("Defines the objective for writing values.")]
		[TargetObjective(false)]
		public int TargetObjective;

		[Tooltip("Sets the mapping type for obtaining objective values.")]
		public MappingType AngleMapping = MappingType.InverseLinear;

		[Tooltip("Determines the maximum possible addition.")]
		public float MaxIncrease = 0.2f;

		[Tooltip("Determines the maximum possible deviation in degrees of the (local) decision direction.")]
		[Range(0f, 180f)]
		public float MaxAngle = 45f;

		private readonly SteeringPercept self = new SteeringPercept();

		public SteeringPercept Self
		{
			get
			{
				return self;
			}
			set
			{
				self.Copy(value);
			}
		}

		public override void Behave()
		{
			if (TargetObjective < 0 || TargetObjective >= Context.Problem.ObjectiveCount)
			{
				return;
			}
			ISensor<Structure> sensor = Context.Sensor;
			Vector3 vector = self.WorldToLocalMatrix.MultiplyVector(Context.DecidedDirection);
			for (int i = 0; i < sensor.ReceptorCount; i++)
			{
				float num = Vector3.Angle(vector, sensor[i].Structure.Direction);
				if (num <= MaxAngle)
				{
					WriteValue(ValueWritingType.Addition, TargetObjective, i, MoveBehaviour.MapSpecial(AngleMapping, 0f, MaxAngle, num) * MaxIncrease);
				}
			}
		}
	}
}
