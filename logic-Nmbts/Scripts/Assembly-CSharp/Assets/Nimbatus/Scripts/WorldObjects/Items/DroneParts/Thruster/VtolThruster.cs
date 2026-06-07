using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.ResourceCollection;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Thruster
{
	public class VtolThruster : BindableDronePart, IFuelConsumer, IThruster
	{
		[HideInInspector]
		[EnumSetting("DronePartSettings/Target", UndoManager.EStoreReason.VtolThrusterTarget)]
		public ESensorDirectionTarget DirectionTarget;

		[HideInInspector]
		[EnumSetting("DronePartSettings/FallbackTarget", UndoManager.EStoreReason.VtolThrusterTargetFallback)]
		public ESensorDirectionTarget DirectionTargetFallback;

		[HideInInspector]
		[EnumSetting("DronePartSettings/Mode", UndoManager.EStoreReason.VtolRotationMode)]
		public EThrusterRotationMode RotationMode;

		public float Force = 100f;

		public float FuelPerSecond = 1f;

		public ParticleSystem[] Particles;

		public string ThusterSound;

		public GameObject RotatingGameObject;

		private KeyBinding _giveThrust;

		private KeyBinding _flipDirection;

		private float _thrustModifier;

		private bool _useEnergyAsFuel;

		public override List<KeyBinding> GetKeyBindings()
		{
			_giveThrust = new KeyBinding("Activate", KeyCode.W);
			_flipDirection = new KeyBinding("Flip Direction", KeyCode.None, false);
			return new List<KeyBinding> { _giveThrust, _flipDirection };
		}

		public override void InitDronePerkSettings(List<DroneEffect> effects)
		{
			base.InitDronePerkSettings(effects);
			_thrustModifier = 1f;
			if (effects != null)
			{
				ThrusterEffect thrusterEffect = effects.OfType<ThrusterEffect>().FirstOrDefault();
				if (thrusterEffect != null)
				{
					_thrustModifier = (float)(100 + thrusterEffect.ThrustIncrease) / 100f;
				}
				_useEnergyAsFuel = effects.OfType<SuperchargedBatteries>().Any();
			}
		}

		public override void FixedUpdate()
		{
			if (Rigidbody == null)
			{
				Rigidbody = GetComponentInParent<Rigidbody>();
			}
			if (IsBroken || !CanControlDrone || HealthPool.CurrentState == EChemicalState.Frozen)
			{
				EnableParticles(false);
				return;
			}
			EThrusterRotationMode rotationMode = RotationMode;
			if (_flipDirection.IsPressed(KeyEventHub))
			{
				rotationMode = ((RotationMode != EThrusterRotationMode.Inverse) ? EThrusterRotationMode.Inverse : EThrusterRotationMode.Normal);
			}
			RotateToDirection(rotationMode);
			if (IsActive())
			{
				EResourceType mat = EResourceType.Fuel;
				if (_useEnergyAsFuel)
				{
					mat = EResourceType.Energy;
				}
				if (_giveThrust.IsPressed(KeyEventHub))
				{
					float amount = FuelPerSecond * Time.fixedDeltaTime;
					if (base.CurrentResourceHub.HasResource(mat, amount))
					{
						if (Rigidbody != null)
						{
							Rigidbody.AddForceAtPosition(RotatingGameObject.transform.right * Force * _thrustModifier * 20f, base.transform.position, ForceMode.Force);
						}
						base.CurrentResourceHub.UseResourceFromParts(mat, amount);
						EnableParticles(true);
					}
					else
					{
						EnableParticles(false);
					}
				}
				else
				{
					EnableParticles(false);
				}
			}
			else
			{
				EnableParticles(false);
			}
			base.FixedUpdate();
		}

		private void RotateToDirection(EThrusterRotationMode rotationMode)
		{
			Vector3 position = Input.mousePosition + new Vector3(0f, 0f, Mathf.Abs(Camera.main.transform.position.z));
			Vector2 mousePos = RuntimeGlobals.MainCamera.ScreenToWorldPoint(position);
			Vector2 myPos = new Vector2(base.transform.position.x, base.transform.position.y);
			Vector2 gravitydir;
			Vector2 vector;
			Vector2 gravitydir2;
			if (GetDirection(DirectionTarget, mousePos, myPos, out gravitydir))
			{
				vector = gravitydir;
				if (DirectionTarget == ESensorDirectionTarget.NextWaypoint)
				{
					TrackWaypoint(true);
				}
			}
			else if (GetDirection(DirectionTargetFallback, mousePos, myPos, out gravitydir2))
			{
				vector = gravitydir2;
				if (DirectionTargetFallback == ESensorDirectionTarget.NextWaypoint)
				{
					TrackWaypoint(true);
				}
			}
			else
			{
				vector = Vector3.zero;
			}
			if (rotationMode == EThrusterRotationMode.Inverse)
			{
				vector = -vector;
			}
			float angle = Mathf.Atan2(vector.y, vector.x) * 57.29578f;
			RotatingGameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}

		private void EnableParticles(bool enable, bool chargeUp = false)
		{
			ParticleSystem[] particles = Particles;
			for (int i = 0; i < particles.Length; i++)
			{
				ParticleSystem.EmissionModule emission = particles[i].emission;
				emission.enabled = enable;
			}
			if (enable || chargeUp)
			{
				StartSoundLoop(ThusterSound);
			}
			else
			{
				StopActiveSoundLoop();
			}
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/ThrustForce") + ": " + LabelHelper.Orange + Force + LabelHelper.NewLine;
			if (_useEnergyAsFuel)
			{
				return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/EnergyPerSecond") + ": " + LabelHelper.Orange + FuelPerSecond;
			}
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/FuelPerSecond") + ": " + LabelHelper.Orange + FuelPerSecond;
		}

		public override NimbatusItemData CreateData()
		{
			return new VtolThrusterData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			VtolThrusterData vtolThrusterData;
			if ((vtolThrusterData = data as VtolThrusterData) != null)
			{
				vtolThrusterData.DirectionTarget = DirectionTarget;
				vtolThrusterData.DirectionTargetFallback = DirectionTargetFallback;
				vtolThrusterData.RotationMode = RotationMode;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			VtolThrusterData vtolThrusterData;
			if ((vtolThrusterData = data as VtolThrusterData) != null)
			{
				DirectionTarget = vtolThrusterData.DirectionTarget;
				RotationMode = vtolThrusterData.RotationMode;
				DirectionTargetFallback = vtolThrusterData.DirectionTargetFallback;
			}
		}

		public bool IsThrusterAlive()
		{
			if (!IsBroken && !HealthPool.IsDead)
			{
				return HealthPool.CurrentState != EChemicalState.Frozen;
			}
			return false;
		}

		public float GetCurrentThrust()
		{
			return Force;
		}

		public void SetCurrentThrust(float thrust)
		{
			Force = thrust;
		}
	}
}
