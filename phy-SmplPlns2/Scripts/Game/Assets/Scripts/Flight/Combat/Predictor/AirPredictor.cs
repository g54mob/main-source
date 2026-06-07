using System.Diagnostics;
using System.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons;
using Assets.Scripts.Flight.UI.Targeting;
using Assets.Scripts.Settings;
using UnityEngine;

namespace Assets.Scripts.Flight.Combat.Predictor
{
	public class AirPredictor
	{
		public PredictorControllerScript Controller { get; set; }

		public TargetingScript TargetingScript { get; set; }

		public void Update()
		{
			Controller.TargetIndicatorPos = null;
			Controller.AimIndicatorPos = null;
			TargetingSystem targetingSystem = TargetingScript.Aircraft?.TargetingSystem;
			if (targetingSystem == null)
			{
				return;
			}
			PredictorEntity entityForCurrentWeapon = Controller.GetEntityForCurrentWeapon();
			if (targetingSystem.GunsActive)
			{
				Target currentTarget = targetingSystem.CurrentTarget;
				if (currentTarget != null && currentTarget.TargetType == TargetType.Air)
				{
					float num = (from w in targetingSystem.GunsWeaponSystem.Weapons
						where w.IsActive
						select w.Part.GetModifier<GunScript>()).DefaultIfEmpty(null).Max((GunScript p) => p?.Gun.MuzzleVelocity ?? 0f);
					if (num > 0f)
					{
						AircraftScript aircraft = TargetingScript.Aircraft;
						Target currentTarget2 = aircraft.TargetingSystem.CurrentTarget;
						Vector3 vector = aircraft.Velocity + aircraft.MainCockpit.transform.forward * num;
						Vector3 vector2 = currentTarget2.Position + currentTarget2.Velocity * ((currentTarget2.Position - aircraft.Position).magnitude / vector.magnitude);
						for (int num2 = 0; num2 < 10; num2++)
						{
							vector2 = currentTarget2.Position + currentTarget2.Velocity * ((vector2 - aircraft.Position).magnitude / vector.magnitude);
						}
						Controller.GunAimReticlePos = vector2;
					}
				}
			}
			if ((PhysicsQualitySettings.PredictorQualityLevel)Game.Instance.Settings.Quality.Physics.PredictorQuality == PhysicsQualitySettings.PredictorQualityLevel.Off || entityForCurrentWeapon == null)
			{
				return;
			}
			Target currentTarget3 = targetingSystem.CurrentTarget;
			if (currentTarget3 == null || currentTarget3.TargetType != TargetType.Air)
			{
				return;
			}
			Target currentTarget4 = targetingSystem.CurrentTarget;
			float deltaTime = PredictorSettings.DeltaTime;
			_ = PredictorSettings.MaxSimTime;
			Vector3 position = currentTarget4.Position;
			Vector3 velocity = currentTarget4.Velocity;
			bool flag = false;
			Stopwatch stopwatch = Stopwatch.StartNew();
			while (Vector3.Dot(position - entityForCurrentWeapon.Position, entityForCurrentWeapon.Velocity - velocity) > 0f)
			{
				position += velocity * deltaTime;
				entityForCurrentWeapon.FixedUpdate(deltaTime);
				flag = true;
				if (stopwatch.ElapsedMilliseconds > 100)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				if (Controller.GunAimReticlePos.HasValue)
				{
					Controller.AimIndicatorPos = Controller.GunAimReticlePos.Value + entityForCurrentWeapon.Position - position;
					return;
				}
				Controller.TargetIndicatorPos = position;
				Controller.AimIndicatorPos = entityForCurrentWeapon.Position;
			}
		}
	}
}
