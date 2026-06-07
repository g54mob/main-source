using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Controls.Keybinds;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Ammunitions;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons
{
	[CustomDronePartEditor]
	public class Weapon : BindableDronePart, IWeapon, IEnergyConsumer
	{
		[HideInInspector]
		public Emitter Emitter;

		[HideInInspector]
		public Ammunition Ammunition;

		[HideInInspector]
		public WeaponPreset Preset;

		[HideInInspector]
		public int UpgradeSlots;

		public EWeaponRotation Rotation = EWeaponRotation.Cursor;

		private KeyBinding _shootKeyBind;

		protected override void Start()
		{
			base.Start();
			if (RootDrone != null)
			{
				Emitter.InitLayer(RootDrone.CollisionLayerMask, RootDrone.ProjectileLayer);
			}
		}

		public void ApplyWeaponPreset(WeaponPreset preset)
		{
			Preset = preset;
			Name = new TranslationTerm(preset.Name);
			Ammunition = preset.Ammunition;
			UpgradeSlots = preset.UpgradeSlots;
			if (Emitter != null)
			{
				Object.Destroy(Emitter.gameObject);
			}
			Emitter = Object.Instantiate(Preset.Emitter);
			Emitter.transform.parent = base.transform;
			Emitter.transform.localPosition = new Vector3(0f, 0f, -0.1f);
			Emitter.transform.localRotation = Quaternion.identity;
			Emitter.ApplyPreset(preset);
		}

		public override Texture2D GetIcon()
		{
			return Emitter.GetIcon();
		}

		public override void PostLoad()
		{
			base.PostLoad();
			Name = new TranslationTerm(Preset.Name);
			Emitter.Init(this, Rigidbody, false, Rotation);
		}

		public override void Update()
		{
			base.Update();
			if (Emitter == null || RootDrone == null || RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
			{
				return;
			}
			if (IsActive())
			{
				if (HealthPool.CurrentState != EChemicalState.Frozen && !NoInput)
				{
					Emitter.UpdateRotation();
				}
				if (_shootKeyBind.IsPressed(KeyEventHub))
				{
					Emitter.Emit(true, base.CurrentResourceHub);
				}
				else
				{
					Emitter.Emit(false, base.CurrentResourceHub);
				}
			}
			else
			{
				Emitter.Emit(false, base.CurrentResourceHub);
			}
		}

		public override string GetDetailedTooltip()
		{
			string detailedTooltip = base.GetDetailedTooltip();
			detailedTooltip = detailedTooltip + LabelHelper.NewLine + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/UpgradeSlots") + ": " + LabelHelper.Orange + UpgradeSlots;
			return detailedTooltip + LabelHelper.NewLine;
		}

		public override void OnTooltip(bool show)
		{
			if (DragAndDropHelper.DraggedItem == null)
			{
				NimbatusToolTip.ShowWeapon(this, false, show);
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			_shootKeyBind = new KeyBinding("Shoot", BaseSingleton<KeybindManager>.Instance.GetKeyCode(EKeybinding.DefaultShootButton));
			return new List<KeyBinding> { _shootKeyBind };
		}

		public List<NimbatusItem> GetModules()
		{
			return Emitter.GetModules();
		}

		public NimbatusItem Instantiate()
		{
			return Object.Instantiate(base.gameObject).GetComponent<NimbatusItem>();
		}

		public override NimbatusItemData CreateData()
		{
			return new WeaponData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			WeaponData weaponData = data as WeaponData;
			if (weaponData != null)
			{
				weaponData.RotationMode = Rotation;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			WeaponData weaponData = data as WeaponData;
			if (weaponData != null)
			{
				Rotation = weaponData.RotationMode;
			}
		}
	}
}
