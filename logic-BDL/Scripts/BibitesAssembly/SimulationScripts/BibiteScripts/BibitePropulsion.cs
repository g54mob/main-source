using System;
using Newtonsoft.Json.Linq;
using SettingScripts;
using UnityEngine;

namespace SimulationScripts.BibiteScripts
{
	public class BibitePropulsion : BibiteSpatialOrgan
	{
		private Rigidbody2D rb2d;

		internal InternalClock clk;

		private FieldOfView fov;

		internal float SignedVelocity;

		internal float NormalizedVelocity;

		internal float AngularVelocity;

		internal float Angle;

		private float baseAccelerationCost;

		private float baseTurnCost;

		[NonSerialized]
		public float movementCost;

		[NonSerialized]
		public float movementPenalty;

		private Vector2 lastPos = Vector2.zero;

		[NonSerialized]
		public float totalTravel;

		private static readonly FloatSetting MusclePressure = ScenarioSettings.Instance.armMusclePressure;

		private static readonly FloatSetting ActivationCost = ScenarioSettings.Instance.moveMusclesCost;

		private static readonly FloatSetting ForwardForceSizePower = ScenarioSettings.Instance.forwardForceSizePower;

		private static readonly FloatSetting TurnForceSizePower = ScenarioSettings.Instance.turnForceSizePower;

		private static readonly BoolSetting DisableHerding = ScenarioSettings.Instance.disableHerding;

		private static readonly FloatSetting BackwardFraction = ScenarioSettings.Instance.backwardFraction;

		private static readonly BoolSetting WorldWrapping = ScenarioSettings.Instance.worldWrapping;

		private static readonly BoolSetting ShadeAvoidance = ScenarioSettings.Instance.shadeAvoidance;

		private static readonly BoolSetting ShadeEnabled = ScenarioSettings.Instance.shadeOutsideOfBounds;

		private static float musclePressure = MusclePressure.SubscribeTo<FloatSetting, float>(UpdateMusclePressure);

		private static float activationCost = ActivationCost.SubscribeTo<FloatSetting, float>(UpdateActivationCost);

		private static bool disableHerding = DisableHerding.SubscribeTo<BoolSetting, bool>(UpdateDisableHerding);

		private static bool avoidVoid = ScenarioSettings.Instance.voidAvoidance.SubscribeTo<BoolSetting, bool>(UpdateVoidAvoidance);

		private static float forwardForceSizePower = ForwardForceSizePower.SubscribeTo<FloatSetting, float>(UpdateForwardForceSizePower);

		private static float turnForceSizePower = TurnForceSizePower.SubscribeTo<FloatSetting, float>(UpdateTurnForceSizePower);

		private static float backwardFraction = BackwardFraction.SubscribeTo<FloatSetting, float>(UpdateBackwardFraction);

		private static bool worldWrapping = WorldWrapping.SubscribeTo<BoolSetting, bool>(UpdateWorldWrapping);

		private static bool shadeAvoidance = ShadeAvoidance.SubscribeTo<BoolSetting, bool>(UpdateShadeAvoidance);

		public static bool shadeEnabled = ShadeEnabled.SubscribeTo<BoolSetting, bool>(UpdateShadeEnabled);

		private static float OutOfBoundDist2 = simSize * simSize * 2.25f;

		private static float simSize = ScenarioIndependentSettings.Instance.SimulationSize.SubscribeTo<FloatSetting, float>(UpdateSimSize);

		[NonSerialized]
		public float muscleMoveStrength;

		[NonSerialized]
		public float muscleTurnStrength;

		public override float mass => 0f;

		protected override BibiteGenes.Genes apportionmentGene => BibiteGenes.Genes.MoveMusclesWAG;

		private float desireToAccelerate => brain.Output(NEATBrain.Outputs.Accelerate);

		private float desireToTurn => brain.Output(NEATBrain.Outputs.Rotate);

		private float desireToHerd => brain.Output(NEATBrain.Outputs.Herding);

		private static void UpdateMusclePressure(float val)
		{
			musclePressure = val;
		}

		private static void UpdateActivationCost(float val)
		{
			activationCost = val;
		}

		private static void UpdateDisableHerding(bool val)
		{
			disableHerding = val;
		}

		private static void UpdateVoidAvoidance(bool val)
		{
			avoidVoid = val;
		}

		private static void UpdateForwardForceSizePower(float val)
		{
			forwardForceSizePower = val;
		}

		private static void UpdateTurnForceSizePower(float val)
		{
			turnForceSizePower = val;
		}

		private static void UpdateBackwardFraction(float val)
		{
			backwardFraction = val;
		}

		private static void UpdateShadeAvoidance(bool val)
		{
			shadeAvoidance = val;
		}

		private static void UpdateShadeEnabled(bool val)
		{
			shadeEnabled = val;
		}

		private static void UpdateWorldWrapping(bool val)
		{
			worldWrapping = val;
		}

		private static void UpdateSimSize(float val)
		{
			simSize = val;
			OutOfBoundDist2 = simSize * simSize * 2.25f;
		}

		public override void InitOrgan(BibiteBody bibite)
		{
			base.InitOrgan(bibite);
			MusclePressure.Subscribe(UpdateMuscleStrength);
			ForwardForceSizePower.Subscribe(UpdateMuscleStrength);
			TurnForceSizePower.Subscribe(UpdateMuscleStrength);
			ActivationCost.Subscribe(UpdateMuscleCosts);
			UpdateMuscleStrength();
			rb2d = GetComponent<Rigidbody2D>();
			fov = body.fow;
			lastPos = base.transform.position;
		}

		protected override void OnGrowth(float val = 1f)
		{
			base.OnGrowth(val);
			UpdateMuscleStrength();
		}

		private void UpdateMuscleStrength(float val = 0f)
		{
			muscleMoveStrength = musclePressure * Mathf.Pow(area * metabolicRate, forwardForceSizePower / 2f);
			muscleTurnStrength = musclePressure / 4f * Mathf.Pow(area * metabolicRate, turnForceSizePower / 2f);
			UpdateMuscleCosts();
		}

		private void UpdateMuscleCosts()
		{
			baseAccelerationCost = activationCost * area;
			baseTurnCost = baseAccelerationCost / 2f;
		}

		public override void UpdateOrgan()
		{
			Vector2 vector = base.transform.position;
			totalTravel += (vector - lastPos).magnitude;
			lastPos = vector;
			Vector2 linearVelocity = rb2d.linearVelocity;
			AngularVelocity = rb2d.angularVelocity / 360f;
			Vector2 vector2 = base.transform.up;
			SignedVelocity = Vector2.Dot(linearVelocity, vector2);
			NormalizedVelocity = SignedVelocity / body.bodyLength;
			Angle = Vector2.Angle(linearVelocity, Vector2.right);
			if (Vector3.Cross(linearVelocity, Vector2.right).z > 0f)
			{
				Angle = 360f - Angle;
			}
			float num = desireToAccelerate;
			float num2 = desireToTurn;
			movementPenalty = Mathf.Sqrt(body.Health.fullness) * body.ageStrengthPenaltyFactor;
			if (fov.hasHerd && !disableHerding)
			{
				float num3 = desireToHerd;
				num2 = num2 * (1f - Mathf.Abs(num3)) + (float)Math.Tanh(fov.herdSumDirection / 90f) * num3;
				num += genes.genes[20] * fov.herdSeparationProjection * num3;
			}
			if (avoidVoid)
			{
				Zone zone = null;
				Vector2 vector3 = float.PositiveInfinity * Vector2.one;
				foreach (Zone zone2 in ZoneManager.instance.zones)
				{
					Vector2 vector4 = zone2.pos - (Vector2)base.transform.position;
					if (vector4.magnitude - zone2.radius < vector3.magnitude)
					{
						vector3 = vector4 - zone2.radius * vector4.normalized;
						zone = zone2;
					}
				}
				vector3 = zone.pos - (Vector2)base.transform.position;
				if (vector3.magnitude > zone.radius)
				{
					float a = (vector3.magnitude - zone.radius) / ScenarioSettings.Instance.voidAvoidanceDistance.val;
					a = Mathf.Min(a, 1f);
					num2 = num2 * (1f - a) + (float)Math.Tanh(Vector2.SignedAngle(vector2, vector3)) * a;
				}
			}
			if (shadeEnabled)
			{
				Vector2 vector5 = base.transform.position;
				float magnitude = vector5.magnitude;
				float sqrMagnitude = vector5.sqrMagnitude;
				if (shadeAvoidance && sqrMagnitude >= OutOfBoundDist2)
				{
					float num4 = Mathf.Clamp01(Mathf.InverseLerp(OutOfBoundDist2, OutOfBoundDist2 * 1.5f, sqrMagnitude));
					num2 = num2 * (1f - num4) + (float)Math.Tanh(Vector2.SignedAngle(vector2, -vector5)) * num4;
				}
				else if (worldWrapping && magnitude - body.bodyLength >= simSize * 1.5f + 1000f)
				{
					rb2d.position = -vector5.normalized * (simSize * 1.5f + 1000f - body.bodyLength * 0.95f);
				}
			}
			num = Mathf.Max(Mathf.Min(num, 1f), -1f) * movementPenalty;
			num2 = Mathf.Max(Mathf.Min(num2, 1f), -1f) * movementPenalty;
			if (num < 0f)
			{
				num *= backwardFraction;
			}
			rb2d.AddForce(base.transform.up * (num * muscleMoveStrength));
			movementCost = baseAccelerationCost * Mathf.Abs(num);
			rb2d.AddTorque(num2 * muscleTurnStrength);
			movementCost += baseTurnCost * Mathf.Abs(num2);
			body.UseEnergy(movementCost * Time.fixedDeltaTime);
		}

		private void OnDestroy()
		{
			MusclePressure.UnSubscribe(UpdateMuscleStrength);
			ForwardForceSizePower.UnSubscribe(UpdateMuscleStrength);
			TurnForceSizePower.UnSubscribe(UpdateMuscleStrength);
			ActivationCost.UnSubscribe(UpdateMuscleCosts);
			body = null;
		}

		public JObject SaveState()
		{
			return new JObject { ["totalTravel"] = totalTravel };
		}

		public void LoadState(JObject state)
		{
			if (state["totalTravel"] != null)
			{
				totalTravel = (float)state["totalTravel"];
			}
		}
	}
}
