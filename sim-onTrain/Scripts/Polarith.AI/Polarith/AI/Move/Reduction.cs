using System;
using System.Collections.Generic;
using Polarith.AI.Criteria;
using Polarith.Utils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public class Reduction : PerceptBehaviour<SteeringPercept>
	{
		[Tooltip("Sets the type for writing objective values.")]
		public ValueWritingType ValueWriting = ValueWritingType.AssignLesser;

		[Tooltip("If true, the Vector Projection is determined by the sensor attached to the context. Otherwise, the control element below can be used to set the Vector Projection mode.")]
		public bool UseSensorProjection = true;

		[Tooltip("Sets the type for projecting the perceived vector data into a plane.")]
		public VectorProjectionType VectorProjection;

		[Tooltip("Determines how the resulting magnitude is mapped according to the set 'MaxDistance'.")]
		public MappingType DistanceMapping = MappingType.InverseQuadratic;

		[Tooltip("Defines the objective for writing values.")]
		[TargetObjective(false)]
		public int TargetObjective;

		[Tooltip("Is multiplied to the resulting magnitude.")]
		public float MagnitudeMultiplier = 1f;

		[Tooltip("The maximum radius for considering percepts. If a percept lies above this threshold, it is ignored by this behaviour.")]
		public float MaxDistance = 5f;

		[Tooltip("This value is added to the final result.\n\nIt functions as the lower bound for the resulting magnitude. If the character controller is dependent on the decision magnitude, this can be used to avoid deadlocks.")]
		public float MinMagnitude;

		[Tooltip("The result of this behaviour depends on two conditions. First, the proximity to the current percept. Second, the angle between an agent's movement direction and the direction towards the current percept. This parameter determines how these two conditions are combined. If 'AngleWeight' is 0, only the proximity is considered. If 'AngleWeight' is 1, only the angle is considered.")]
		[Range(0f, 1f)]
		public float AngleWeight = 0.25f;

		[Tooltip("If enabled, a game object's rotation and preset forward direction is used to approximate its actual velocity. This is especially useful for velocity-dependent behaviours like 'AIMAvoid' and if no other sources for a valid velocity vector can be provided. Moreover, such preset forward direction has the advantage to be more stable in contrast to other possible velocity sources.\n\nOther valid sources for obtaining a movement velocity are the 'AIMSteeringTag.TrackVelocity' optionor to make use of a 'Rigidbody' respectively a 'Rigidbody2D'.")]
		public bool UsePresetVelocity;

		[Tooltip("Specifies the forward direction the agent moves towards and/or looks at by default.")]
		public PresetVelocityType PresetVelocity = PresetVelocityType.Automatic;

		[Tooltip("If set to anything other than 'None', the position of the 'Self' percept is updated according to the given velocity. Hence, for the behaviour, it is possible to predict and use the future position of an agent.")]
		public PredictionType Prediction;

		[Tooltip("Scales the velocity vector used for predicting the possible future position of an agent if 'Prediction' is set to 'Span'.")]
		public float PredictionMagnitude;

		protected Vector3 velocity = Vector3.forward;

		private readonly SteeringPercept self = new SteeringPercept();

		private readonly SteeringPercept percept = new SteeringPercept();

		private IProblem<float> problem;

		private IList<float> objective;

		private ISensor<Structure> sensor;

		private Vector3 direction;

		private Vector3 normVelocity;

		private float result;

		private float bestResult;

		private float sqrDistance;

		private float sqrOuterRadius;

		private float value;

		private int i;

		public override SteeringPercept Self
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
			problem = Context.Problem;
			objective = problem.GetObjective(TargetObjective);
			sensor = Context.Sensor;
			if (TargetObjective < 0 || TargetObjective >= problem.ObjectiveCount)
			{
				return;
			}
			bestResult = 0f;
			if (UseSensorProjection && sensor is Sensor)
			{
				VectorProjection = (sensor as Sensor).ProjectionMode;
			}
			if (UsePresetVelocity)
			{
				DetermineVelocity();
				self.Velocity = self.Rotation * velocity;
				if (Prediction == PredictionType.PredictionMagnitude)
				{
					self.Position += self.Velocity * PredictionMagnitude;
				}
			}
			else if (Prediction == PredictionType.PredictionMagnitude)
			{
				self.Position += self.Velocity.normalized * PredictionMagnitude;
			}
			else if (Prediction == PredictionType.VelocityMagnitude)
			{
				self.Position += self.Velocity;
			}
			if (VectorProjection == VectorProjectionType.PlaneXY)
			{
				self.Position.z = 0f;
				self.Velocity.z = 0f;
			}
			else if (VectorProjection == VectorProjectionType.PlaneXZ)
			{
				self.Position.y = 0f;
				self.Velocity.y = 0f;
			}
			normVelocity = self.Velocity.normalized;
			for (i = 0; i < Percepts.Count; i++)
			{
				if (Percepts[i] != null && Percepts[i].Active && !Percepts[i].IsEqual(self))
				{
					percept.Copy(Percepts[i]);
					if (VectorProjection == VectorProjectionType.PlaneXY)
					{
						percept.Position.z = 0f;
						percept.Velocity.z = 0f;
						percept.Rotation.eulerAngles.Set(0f, 0f, percept.Rotation.eulerAngles.z);
					}
					else if (VectorProjection == VectorProjectionType.PlaneXZ)
					{
						percept.Position.y = 0f;
						percept.Velocity.y = 0f;
						percept.Rotation.eulerAngles.Set(0f, percept.Rotation.eulerAngles.y, 0f);
					}
					direction = percept.Position - self.Position;
					sqrDistance = direction.sqrMagnitude;
					sqrOuterRadius = MaxDistance * MaxDistance;
					if (!(sqrDistance <= 1E-06f) && !(sqrDistance >= sqrOuterRadius))
					{
						direction.Normalize();
						result = (1f - AngleWeight) * MoveBehaviour.MapSpecial(DistanceMapping, 0f, MaxDistance, Mathf.Sqrt(sqrDistance)) + AngleWeight * Vector3.Dot(direction, normVelocity);
						if (result > bestResult)
						{
							bestResult = result;
						}
					}
				}
			}
			for (i = 0; i < sensor.ReceptorCount; i++)
			{
				value = objective[i] - bestResult * MagnitudeMultiplier;
				if (Mathf2.Approximately(value, 0f) || value < 0f)
				{
					WriteValue(ValueWriting, TargetObjective, i, 0f + MinMagnitude);
				}
				else
				{
					WriteValue(ValueWriting, TargetObjective, i, value + MinMagnitude);
				}
			}
		}

		private void DetermineVelocity()
		{
			switch (PresetVelocity)
			{
			case PresetVelocityType.Automatic:
				if (VectorProjection == VectorProjectionType.PlaneXY)
				{
					velocity = Vector3.up;
				}
				else
				{
					velocity = Vector3.forward;
				}
				break;
			case PresetVelocityType.Up:
				velocity = Vector3.up;
				break;
			case PresetVelocityType.Down:
				velocity = Vector3.down;
				break;
			case PresetVelocityType.Forward:
				velocity = Vector3.forward;
				break;
			case PresetVelocityType.Back:
				velocity = Vector3.back;
				break;
			case PresetVelocityType.Left:
				velocity = Vector3.left;
				break;
			case PresetVelocityType.Right:
				velocity = Vector3.right;
				break;
			}
		}
	}
}
