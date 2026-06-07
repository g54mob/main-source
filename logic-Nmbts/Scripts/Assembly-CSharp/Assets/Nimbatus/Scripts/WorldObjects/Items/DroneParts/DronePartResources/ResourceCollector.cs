using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Controls.Keybinds;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.ResourceCollection;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.DronePartResources
{
	public class ResourceCollector : BindableDronePart, IEnergyConsumer
	{
		public ResourceCollectorTurret Turret;

		public float Range;

		public float EnergyPerSecond;

		[EnumSetting("DronePartSettings/Rotation", UndoManager.EStoreReason.WeaponRotation)]
		public EWeaponRotation RotationMode;

		public LayerMask CollisionLayer;

		public string CollectSound;

		private KeyBinding _startCollecting;

		private bool _isActive;

		private float _lastShootTime;

		protected override void Start()
		{
			base.Start();
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetPreconditions();
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			_startCollecting = new KeyBinding("Collect", BaseSingleton<KeybindManager>.Instance.GetKeyCode(EKeybinding.SecondaryShootButton));
			return new List<KeyBinding> { _startCollecting };
		}

		public override void FixedUpdate()
		{
			if (IsActive())
			{
				if (!NoInput)
				{
					UpdateRotation();
				}
				if (_startCollecting.IsPressed(KeyEventHub))
				{
					float amount = EnergyPerSecond * Time.fixedDeltaTime;
					if (base.CurrentResourceHub.HasResource(EResourceType.Energy, EnergyPerSecond))
					{
						_isActive = true;
						base.CurrentResourceHub.UseResourceFromParts(EResourceType.Energy, amount);
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
			else
			{
				_isActive = false;
			}
			if (_isActive)
			{
				StartSoundLoop(CollectSound);
				Turret.ShowParticles();
				if (IsReadyToShoot())
				{
					Turret.ShootBeams(Range, CollisionLayer, base.CurrentResourceHub);
				}
			}
			else
			{
				Turret.HideParticles();
				StopActiveSoundLoop();
			}
			base.FixedUpdate();
		}

		public void UpdateRotation()
		{
			EWeaponRotation rotationMode = RotationMode;
			if (rotationMode == EWeaponRotation.Cursor)
			{
				Turret.transform.rotation = TransformHelper.Get2DRotationTowardsMouse(base.transform.position, RuntimeGlobals.Camera.Camera);
			}
		}

		public bool IsReadyToShoot()
		{
			if (Time.time - _lastShootTime > 0.1f)
			{
				_lastShootTime = Time.time;
				return true;
			}
			return false;
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Range") + ": " + LabelHelper.Orange + Range + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/EnergyPerSecond") + ": " + LabelHelper.Orange + EnergyPerSecond;
		}

		public override NimbatusItemData CreateData()
		{
			return new ResourceCollectorData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			ResourceCollectorData resourceCollectorData = data as ResourceCollectorData;
			if (resourceCollectorData != null)
			{
				resourceCollectorData.RotationMode = RotationMode;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			ResourceCollectorData resourceCollectorData = data as ResourceCollectorData;
			if (resourceCollectorData != null)
			{
				RotationMode = resourceCollectorData.RotationMode;
			}
		}
	}
}
