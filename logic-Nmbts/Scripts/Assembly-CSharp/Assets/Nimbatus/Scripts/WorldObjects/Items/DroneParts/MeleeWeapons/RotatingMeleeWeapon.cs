using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Controls.Keybinds;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.ResourceCollection;
using Assets.Nimbatus.Scripts.World.Terrain.Common;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MeleeWeapons
{
	public class RotatingMeleeWeapon : MeleeWeapon, IEnergyConsumer
	{
		public string Sound;

		public float RotatingSpeed;

		public float TorqueMultiplier;

		public float DiggingStrength;

		public float EnergyPerSecond;

		public ParticleSystem HitParticleSystem;

		public tk2dSprite RotatingSprite;

		[HideInInspector]
		[EnumSetting("DronePartSettings/Mode", UndoManager.EStoreReason.RotatingMeleeWeaponMode)]
		public ERotatingMeleeWeaponMode RotationMode;

		private KeyBinding _activate;

		private KeyBinding _flipMode;

		private ERotatingMeleeWeaponMode _rotationMode;

		private ERotatingMeleeWeaponMode _previousRotationMode;

		private bool _isActive;

		public override List<KeyBinding> GetKeyBindings()
		{
			_activate = new KeyBinding("Activate", BaseSingleton<KeybindManager>.Instance.GetKeyCode(EKeybinding.DefaultShootButton));
			_flipMode = new KeyBinding("Flip Rotation", KeyCode.None, false);
			return new List<KeyBinding> { _activate, _flipMode };
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/EnergyPerSecond") + ": " + LabelHelper.Orange + EnergyPerSecond;
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (Rigidbody == null)
			{
				Rigidbody = GetComponentInParent<Rigidbody>();
			}
			_rotationMode = RotationMode;
			CheckRotationMode();
			if (IsBroken || !CanControlDrone)
			{
				if (IsBroken)
				{
					StopActiveSoundLoop();
					HitParticleSystem.Stop(true);
				}
				return;
			}
			if (_flipMode.IsPressed(KeyEventHub))
			{
				if (RotationMode == ERotatingMeleeWeaponMode.Clockwise)
				{
					_rotationMode = ERotatingMeleeWeaponMode.Counterclockwise;
				}
				else
				{
					_rotationMode = ERotatingMeleeWeaponMode.Clockwise;
				}
			}
			CheckRotationMode();
			if (!RuntimeGlobals.IsMovementBlocked && !RuntimeGlobals.IsGameLoading && !RuntimeGlobals.IsGamePaused && CanControlDrone)
			{
				if (_activate.IsPressed(KeyEventHub))
				{
					float amount = EnergyPerSecond * Time.fixedDeltaTime;
					if (base.CurrentResourceHub.HasResource(EResourceType.Energy, EnergyPerSecond))
					{
						base.CurrentResourceHub.UseResourceFromParts(EResourceType.Energy, amount);
						RotateSprite();
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
			if (_isActive)
			{
				StartSoundLoop(Sound);
				TerrainModificationHelper.LerpRemoveTerrainSphere(RuntimeGlobals.WorldController.ForeGroundTerrain, base.transform.position, 3f, Time.fixedDeltaTime * DiggingStrength);
			}
			else
			{
				StopActiveSoundLoop();
				HitParticleSystem.Stop(true);
			}
		}

		private void RotateSprite()
		{
			Quaternion quaternion = Quaternion.Euler(0f, 0f, RotatingSpeed * Time.fixedDeltaTime);
			if (_rotationMode == ERotatingMeleeWeaponMode.Clockwise)
			{
				quaternion = Quaternion.Euler(-quaternion.eulerAngles);
			}
			RotatingSprite.transform.rotation = RotatingSprite.transform.rotation * quaternion;
		}

		private void CheckRotationMode()
		{
			if (_rotationMode != _previousRotationMode)
			{
				RotatingSprite.FlipX = !RotatingSprite.FlipX;
			}
			_previousRotationMode = _rotationMode;
		}

		public void OnTriggerStay(Collider col)
		{
			if (_isActive && !col.isTrigger)
			{
				if (DealDamage(col.gameObject, Damage * Time.deltaTime))
				{
					HitParticleSystem.Play(true);
					if (col.attachedRigidbody != null)
					{
						Vector3 vector = col.ClosestPointOnBounds(base.transform.position);
						Vector3 force = (Quaternion.Euler(0f, 0f, 90 * ((_rotationMode != ERotatingMeleeWeaponMode.Clockwise) ? 1 : (-1))) * (vector - base.transform.position)).normalized * RotatingSpeed * TorqueMultiplier * Time.deltaTime;
						col.attachedRigidbody.AddForceAtPosition(force, vector, ForceMode.Impulse);
					}
				}
			}
			else
			{
				HitParticleSystem.Stop(true);
			}
		}

		public void OnTriggerExit(Collider col)
		{
			HitParticleSystem.Stop(true);
		}

		public override NimbatusItemData CreateData()
		{
			return new RotatingMeleeWeaponData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			RotatingMeleeWeaponData rotatingMeleeWeaponData;
			if ((rotatingMeleeWeaponData = data as RotatingMeleeWeaponData) != null)
			{
				rotatingMeleeWeaponData.RotationMode = RotationMode;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			RotatingMeleeWeaponData rotatingMeleeWeaponData;
			if ((rotatingMeleeWeaponData = data as RotatingMeleeWeaponData) != null)
			{
				RotationMode = rotatingMeleeWeaponData.RotationMode;
			}
		}
	}
}
