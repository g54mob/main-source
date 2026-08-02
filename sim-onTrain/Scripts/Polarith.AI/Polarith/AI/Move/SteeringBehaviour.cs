using System;
using System.Collections.Generic;
using Polarith.AI.Criteria;
using UnityEngine;

namespace Polarith.AI.Move
{
	public abstract class SteeringBehaviour : PerceptBehaviour<SteeringPercept>
	{
		[NonSerialized]
		public Vector3 ResultDirection;

		[NonSerialized]
		public float ResultMagnitude;

		[TargetObjective(false)]
		[Tooltip("Defines the objective for writing values.")]
		public int TargetObjective;

		[Tooltip("Is multiplied to the result magnitude in order to weight between different behaviours.")]
		public float MagnitudeMultiplier = 1f;

		[Tooltip("Is added to the sensitivity of a structure as threshold for writing objective values.")]
		public float SensitivityOffset;

		[Tooltip("Sets the type for writing objective values.")]
		public ValueWritingType ValueWriting;

		[Tooltip("Sets the operation for blending the behaviour results into the context. If set to a value other than 'None', this behaviour writes to an intermediate instead of writing directly to the context, whereby this parameter defines the operation used to apply the intermediate to the context.\n\nNote that the intermediate values are initialized with the neutral element with respect to the set'Value Writing' (1 for 'Multiplication' or 'Division' and 0 otherwise).")]
		public LayerBlendingType LayerBlending;

		[Tooltip("Sets the method for normalizing intermediate objective values while they are blended into the context. 'Intermediate' has an effect only if 'Layer Blending' has a value other than 'None'.")]
		public LayerNormalizationType LayerNormalization;

		[Tooltip("Sets the mapping type for obtaining objective values.")]
		public MappingType ValueMapping = MappingType.InverseLinear;

		[Tooltip("Determines if the significance of the perceived object (if there is a steering tag) is multiplied to the result magnitude in order to weight between different percepts.")]
		public bool UseSignificance = true;

		[Tooltip("If true, the Vector Projection is determined by the sensor attached to the context. Otherwise, the control element below can be used to set the Vector Projection mode.")]
		public bool UseSensorProjection = true;

		[Tooltip("Sets the type for projecting the perceived vector data into a plane.")]
		public VectorProjectionType VectorProjection;

		[Tooltip("If the value is anything other than 'None', a game object's rotation and default forward direction is used to approximate its actual velocity. This is especially useful for velocity-dependent behaviours like 'AIM Avoid' and if no other sources for a valid velocity vector can be provided. Moreover, such preset forward direction has the advantage to be more stable in contrast to other possible velocity sources. The other types specify another default forward direction: 'Automatic' chooses the forward vector based on the set 'Vector Projection' of the current 'Sensor'.\n\nOther valid sources for obtaining a movement velocity are the 'Track Velocity' option of an 'AIM Steering Tag' or to make use of a 'Rigidbody' respectively a 'Rigidbody 2D'.")]
		public PresetVelocityType PresetVelocity;

		[Tooltip("If set to anything other than 'None', the position of the 'Self' percept is updated according to the given velocity. Hence, for the behaviour, it is possible to predict and use the future position of an agent. This is, of course, only useful for behaviours that need the position. E.g., 'AIM Follow' and 'AIM Align' do not need any distances to the self percept. Thus, 'Prediction' has no effect on these behaviours.")]
		public PredictionType Prediction;

		[Tooltip("Scales the velocity vector used for predicting the possible future position of an agent if 'Prediction' is set to 'PredictionMagnitude'.")]
		public float PredictionMagnitude;

		protected readonly SteeringPercept self = new SteeringPercept();

		protected readonly SteeringPercept percept = new SteeringPercept();

		protected IList<float> objective;

		protected ISensor<Structure> sensor;

		protected IReceptor<Structure> receptor;

		protected Structure structure;

		protected Vector3 velocity = Vector3.forward;

		protected abstract bool forEachPercept { get; }

		protected abstract bool forEachReceptor { get; }

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
			if (TargetObjective < 0 || TargetObjective >= Context.Problem.ObjectiveCount)
			{
				return;
			}
			if (LayerBlending != LayerBlendingType.None)
			{
				if (intermediate.ObjectiveCount == 0)
				{
					intermediate.AddObjective(Context.Problem.IsObjectiveMinimized(TargetObjective));
				}
				intermediate.ResizeObjectives(Context.Problem.ValueCount);
				if (ValueWriting == ValueWritingType.Multiplication || ValueWriting == ValueWritingType.Division)
				{
					intermediate.ResetValues(1f);
				}
				else
				{
					intermediate.ResetValues();
				}
			}
			objective = Context.Problem.GetObjective(TargetObjective);
			sensor = Context.Sensor;
			if (UseSensorProjection && sensor is Sensor)
			{
				VectorProjection = (sensor as Sensor).ProjectionMode;
			}
			self.Project(VectorProjection);
			if (PresetVelocity != PresetVelocityType.None)
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
			for (int i = 0; i < Percepts.Count; i++)
			{
				if (Percepts[i] == null || !Percepts[i].Active || Percepts[i].IsEqual(self))
				{
					continue;
				}
				percept.Copy(Percepts[i]);
				percept.Project(VectorProjection);
				if (!StartSteering())
				{
					continue;
				}
				if (forEachPercept)
				{
					PerceptSteering();
				}
				for (int j = 0; j < sensor.ReceptorCount; j++)
				{
					receptor = sensor[j];
					structure = receptor.Structure;
					if (forEachReceptor)
					{
						ReceptorSteering();
					}
					float value = (UseSignificance ? percept.Significance : 1f) * MagnitudeMultiplier * structure.Magnitude * ResultMagnitude * MapBySensitivity(ValueMapping, structure, ResultDirection, SensitivityOffset);
					WriteValue(ValueWriting, TargetObjective, receptor.ID, value, LayerBlending != LayerBlendingType.None);
				}
			}
			if (LayerBlending != LayerBlendingType.None)
			{
				if (LayerNormalization == LayerNormalizationType.Intermediate)
				{
					intermediate.NormalizeObjective(0);
				}
				BlendValues(LayerBlending, TargetObjective);
			}
			if (LayerNormalization == LayerNormalizationType.Everything)
			{
				(Context.Problem as Problem).NormalizeObjective(TargetObjective);
			}
		}

		protected virtual bool StartSteering()
		{
			return true;
		}

		protected virtual void PerceptSteering()
		{
		}

		protected virtual void ReceptorSteering()
		{
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
