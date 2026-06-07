using System.Collections.Generic;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.Flight.UI.Targeting;
using Assets.Scripts.Settings;
using Jundroo.Common.Extensions;
using Jundroo.Common.Pool;
using UnityEngine;

namespace Assets.Scripts.Flight.Combat.Predictor
{
	public class GroundPredictor
	{
		private BombEntity _bombPredictor = new BombEntity();

		private CannonEntity _cannonPredictor = new CannonEntity();

		private PredictorEntity _entity;

		public PredictorControllerScript Controller { get; set; }

		public LayerMask LayerMask { get; set; }

		public LineRenderer LineRenderer { get; set; }

		public TargetingScript TargetingScript { get; set; }

		private bool UseLine => PredictorSettings.Visuals.HasFlag(PredictorSettings.PredictorVisuals.DrawLine);

		private bool UseProjector
		{
			get
			{
				if (PredictorSettings.Visuals.HasFlag(PredictorSettings.PredictorVisuals.DrawTargetProjection))
				{
					return !(_entity is CannonEntity);
				}
				return false;
			}
		}

		private bool UseUIReticle
		{
			get
			{
				if (PredictorSettings.Visuals.HasFlag(PredictorSettings.PredictorVisuals.DrawUIReticle))
				{
					return !(_entity is CannonEntity);
				}
				return false;
			}
		}

		public (Vector3 Point, Vector3 Normal, int Layer, float Time)? PredictTrajectory(PredictorEntity weapon, LineRenderer line = null)
		{
			_entity = weapon;
			Vector3 position = weapon.Position;
			List<Vector3> value;
			using (CollectionPool<List<Vector3>, Vector3>.Get(out value))
			{
				int num = 0;
				float? floatingOriginSeaLevel = GameWorld.Instance.FloatingOriginSeaLevel;
				if (weapon.Position.y < floatingOriginSeaLevel)
				{
					return null;
				}
				while (weapon.SimTime < PredictorSettings.MaxSimTime)
				{
					Vector3 vector = weapon.Position - position;
					(Vector3, Vector3, int, float)? result = null;
					if (floatingOriginSeaLevel.HasValue && weapon.Position.y < floatingOriginSeaLevel)
					{
						Vector3 vector2 = position + vector * ((floatingOriginSeaLevel.Value - position.y) / vector.y);
						value.Add(vector2);
						result = (vector2, Vector3.up, 4, weapon.SimTime);
					}
					else
					{
						var (direction, maxDistance) = vector.GetNormalizedAndMagnitude();
						if (Physics.Raycast(position, direction, out var hitInfo, maxDistance, LayerMask, QueryTriggerInteraction.Ignore))
						{
							result = (hitInfo.point, hitInfo.normal, hitInfo.transform.gameObject.layer, weapon.SimTime);
							value.Add(hitInfo.point);
						}
					}
					if (result.HasValue)
					{
						if (line != null)
						{
							AnimationCurve widthCurve = line.widthCurve;
							Keyframe key = widthCurve[1];
							key.value = Mathf.Clamp((result.Value.Item1 - Camera.main.transform.position).magnitude / 100f, 0.4f, 1f);
							widthCurve.MoveKey(1, key);
							line.widthCurve = widthCurve;
							line.positionCount = value.Count;
							line.SetPositions(value.GetInternalArray());
						}
						return result;
					}
					if ((float)num % PredictorSettings.UpdatesPerVertex == 0f)
					{
						value.Add(weapon.Position);
					}
					num++;
					position = weapon.Position;
					weapon.FixedUpdate(PredictorSettings.DeltaTime);
				}
				if (line != null)
				{
					line.enabled = false;
				}
				return null;
			}
		}

		public void Update()
		{
			if ((PhysicsQualitySettings.PredictorQualityLevel)Game.Instance.Settings.Quality.Physics.PredictorQuality == PhysicsQualitySettings.PredictorQualityLevel.Off || FlightUIScript.UIHidden)
			{
				return;
			}
			PredictorEntity entityForCurrentWeapon = Controller.GetEntityForCurrentWeapon();
			if (entityForCurrentWeapon == null)
			{
				return;
			}
			(Vector3, Vector3, int, float)? tuple = PredictTrajectory(entityForCurrentWeapon, UseLine ? LineRenderer : null);
			if (tuple.HasValue)
			{
				if (UseLine)
				{
					Controller.LineEnabled = true;
				}
				if (UseProjector)
				{
					Controller.AimProjectorPos = tuple.Value.Item1;
					Controller.AimProjectorLayer = tuple.Value.Item3;
				}
				if (UseUIReticle)
				{
					Controller.AimIndicatorPos = tuple.Value.Item1;
				}
			}
			Target target = TargetingScript.Aircraft?.TargetingSystem.CurrentTarget;
			if (target == null || !tuple.HasValue || Mathf.Approximately(target.Velocity.magnitude, 0f))
			{
				return;
			}
			Vector3 vector = target.Position + target.Velocity * tuple.Value.Item4;
			if (UseUIReticle)
			{
				Controller.TargetIndicatorPos = vector;
			}
			if (UseProjector)
			{
				if (Physics.Raycast(vector + Vector3.up * 50f, Vector3.down, out var hitInfo, 100f, LayerMask))
				{
					Controller.TargetProjectorPos = hitInfo.point;
					Controller.TargetProjectorLayer = hitInfo.transform.gameObject.layer;
				}
				else
				{
					Controller.TargetProjectorPos = vector;
				}
			}
		}
	}
}
