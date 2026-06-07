using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Controls.Keybinds;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.ResourceCollection;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.World.Terrain.Common;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MeleeWeapons
{
	public class Drill : MeleeWeapon, IEnergyConsumer
	{
		public string Sound;

		public float DiggingStrength;

		public float EnergyPerSecond;

		private KeyBinding _activate;

		private bool _isActive;

		public tk2dSprite OutputLed;

		public Transform DrillCenter;

		public tk2dSpriteAnimator Animator;

		public ParticleSystem HitParticleSystem;

		public ParticleSystem ResourceParticleSystem;

		private bool _hasImprovedDrill;

		private float _diggingStrength;

		private float _energyUsage;

		public override List<KeyBinding> GetKeyBindings()
		{
			_activate = new KeyBinding("Activate", BaseSingleton<KeybindManager>.Instance.GetKeyCode(EKeybinding.DefaultShootButton));
			return new List<KeyBinding> { _activate };
		}

		public override void InitDronePerkSettings(List<DroneEffect> effects)
		{
			base.InitDronePerkSettings(effects);
			_diggingStrength = DiggingStrength;
			_energyUsage = EnergyPerSecond;
			if (effects != null)
			{
				_hasImprovedDrill = effects.OfType<ImprovedDrill>().Any();
				_diggingStrength = DiggingStrength * 10f;
				_energyUsage = EnergyPerSecond * 0.2f;
			}
		}

		public void OnCollisionStay(Collision col)
		{
			if (_isActive && DealDamage(col.contacts[0].otherCollider.gameObject, Damage * Time.deltaTime) && !HitParticleSystem.isPlaying)
			{
				HitParticleSystem.Play(true);
			}
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (Rigidbody == null)
			{
				Rigidbody = GetComponentInParent<Rigidbody>();
			}
			OutputLed.color = ColorHelper.BlackAlpha0;
			if (IsBroken || !CanControlDrone)
			{
				_isActive = false;
				Animator.Stop();
				return;
			}
			if (!RuntimeGlobals.IsMovementBlocked && !RuntimeGlobals.IsGameLoading && !RuntimeGlobals.IsGamePaused && CanControlDrone)
			{
				if (_activate.IsPressed(KeyEventHub))
				{
					float amount = _energyUsage * Time.fixedDeltaTime;
					if (base.CurrentResourceHub.HasResource(EResourceType.Energy, amount))
					{
						base.CurrentResourceHub.UseResourceFromParts(EResourceType.Energy, amount);
						_isActive = true;
					}
					else
					{
						_isActive = false;
					}
				}
				else
				{
					_isActive = false;
				}
			}
			OutputLed.color = (_isActive ? Color.green : ColorHelper.BlackAlpha0);
			if (_isActive)
			{
				Animator.Play();
			}
			else
			{
				Animator.Stop();
			}
			ParticleSystem.EmissionModule emission = ResourceParticleSystem.emission;
			emission.enabled = false;
			if (_isActive)
			{
				StartSoundLoop(Sound);
				if (TerrainModificationHelper.IsTerrainInArea(DrillCenter.position, DrillCenter.right, 5f, 360f))
				{
					if (!HitParticleSystem.isPlaying)
					{
						HitParticleSystem.Play(true);
					}
				}
				else
				{
					HitParticleSystem.Stop(true);
				}
				if (_hasImprovedDrill)
				{
					ETerrainMaterial material;
					if (TerrainModificationHelper.IsCollectableMaterialInArea(DrillCenter.position, DrillCenter.right, 6f, 360f, out material) && base.CurrentResourceHub.HasCapacity(EnumHelper.ConvertEnum(material), 1f))
					{
						ParticleSystem.MainModule main = ResourceParticleSystem.main;
						main.startColor = SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.GetResourceSetting(material).ParticleColor;
						emission.enabled = true;
					}
					TerrainModificationHelper.LerpCollectResources(RuntimeGlobals.WorldController.ForeGroundTerrain, base.CurrentResourceHub, DrillCenter.position, 6, Time.fixedDeltaTime * _diggingStrength, null, true);
				}
				else
				{
					TerrainModificationHelper.LerpRemoveTerrainSphere(RuntimeGlobals.WorldController.ForeGroundTerrain, DrillCenter.position, 6f, Time.fixedDeltaTime * _diggingStrength);
				}
			}
			else
			{
				StopActiveSoundLoop();
				HitParticleSystem.Stop(true);
			}
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			if (_hasImprovedDrill)
			{
				text = text + LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("DronePartSettings/ImprovedDrill") + LabelHelper.NewLine;
			}
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/EnergyPerSecond") + ": " + LabelHelper.Orange + _energyUsage;
		}
	}
}
