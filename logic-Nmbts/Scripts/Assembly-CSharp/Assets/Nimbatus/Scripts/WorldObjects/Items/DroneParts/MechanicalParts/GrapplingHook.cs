using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Controls.Keybinds;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MechanicalParts
{
	public class GrapplingHook : SensorPart
	{
		private const int MinStrength = 1;

		private const int MaxStrength = 100;

		[IntSetting("DronePartSettings/WinchSpeed", 1, 100, 60, UndoManager.EStoreReason.HookStrength)]
		public int Strength = 50;

		[EnumSetting("DronePartSettings/Rotation", UndoManager.EStoreReason.WeaponRotation)]
		public EWeaponRotation Rotation = EWeaponRotation.Cursor;

		[EnumSetting("DronePartSettings/Target", 4, UndoManager.EStoreReason.HookTarget)]
		public EGrapplingHookTarget Target;

		public GrapplingHookProjectile Projectile;

		public tk2dSprite Indicator;

		public MeshRenderer IndicatorRenderer;

		public Color IndicatorFixed;

		public Color IndicatorCursor;

		public float ShootForce = 100f;

		public float MaxRange = 100f;

		public float TerrainStickRadius = 5f;

		private KeyBinding _extend;

		private KeyBinding _retract;

		private KeyBinding _release;

		private EventKeyBinding _hooked;

		private bool _wasHooked;

		private EventKeyBinding _fullyRetracted;

		private bool _wasFullyRetracted;

		public LayerMask StickLayers { get; private set; }

		public bool IsReadyToFire { get; set; }

		public bool Retracting { get; set; }

		public bool Extending { get; set; }

		public bool Returning { get; set; }

		public bool HasNoInput
		{
			get
			{
				return NoInput;
			}
		}

		public Quaternion LastProjectileRotation { get; private set; }

		protected override void Validate()
		{
			base.Validate();
			Strength = Mathf.Clamp(Strength, 1, 100);
		}

		protected override void Start()
		{
			base.Start();
			Projectile.Init(this);
			InitLayerMask(RootDrone);
			InvokeRetracted(true);
			IsReadyToFire = true;
		}

		public override void Update()
		{
			base.Update();
			if (RuntimeGlobals.RunningMode != ERunningMode.DroneCustomization && Projectile != null && IsActive())
			{
				if (IsReadyToFire)
				{
					Retracting = false;
					Extending = false;
					if (_extend.IsPressed(KeyEventHub))
					{
						Projectile.Fire();
					}
					Projectile.UpdateRotation(Rotation);
					LastProjectileRotation = Projectile.transform.localRotation;
				}
				else
				{
					Retracting = _retract.IsPressed(KeyEventHub);
					Extending = _extend.IsPressed(KeyEventHub);
					if (_release.IsPressed(KeyEventHub))
					{
						Projectile.Return();
					}
					if (!HasNoInput && !Returning && Rotation == EWeaponRotation.Cursor && HealthPool.CurrentState != EChemicalState.Frozen)
					{
						Quaternion lastProjectileRotation = Quaternion.Inverse(base.transform.rotation) * TransformHelper.Get2DRotationTowardsTarget(base.transform.position, Projectile.transform.position);
						LastProjectileRotation = lastProjectileRotation;
					}
				}
			}
			if (Indicator != null)
			{
				IndicatorRenderer.enabled = IsReadyToFire;
				IndicatorRenderer.material.color = ((Rotation == EWeaponRotation.Cursor) ? IndicatorCursor : IndicatorFixed);
				Indicator.transform.localRotation = LastProjectileRotation;
			}
		}

		public override void OnDisable()
		{
			base.OnDisable();
			if (_wasHooked)
			{
				InvokeHooked(false);
			}
			if (_wasFullyRetracted)
			{
				InvokeRetracted(false);
			}
		}

		private void InitLayerMask(NimbatusDrone drone)
		{
			StickLayers = 0;
			if (drone == null)
			{
				return;
			}
			foreach (KeyValuePair<EGrapplingHookTarget, LayerMask> grapplingLayerMask in drone.GrapplingLayerMasks)
			{
				if (Target.HasFlag(grapplingLayerMask.Key))
				{
					StickLayers = (int)StickLayers | (int)grapplingLayerMask.Value;
				}
			}
		}

		public void InvokeHooked(bool hooked)
		{
			if (_wasHooked != hooked)
			{
				_hooked.PressKey(hooked, KeyEventHub);
				_wasHooked = hooked;
			}
		}

		public void InvokeRetracted(bool retracted)
		{
			if (_wasFullyRetracted != retracted)
			{
				_fullyRetracted.PressKey(retracted, KeyEventHub);
				_wasFullyRetracted = retracted;
			}
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			_extend = new KeyBinding("Extend", BaseSingleton<KeybindManager>.Instance.GetKeyCode(EKeybinding.DefaultShootButton));
			_retract = new KeyBinding("Retract", BaseSingleton<KeybindManager>.Instance.GetKeyCode(EKeybinding.SecondaryShootButton));
			_release = new KeyBinding("Release", BaseSingleton<KeybindManager>.Instance.GetKeyCode(EKeybinding.ReplaceDronePart));
			return new List<KeyBinding> { _extend, _retract, _release };
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/WinchSpeed") + ": " + LabelHelper.Orange + Strength.ToString("##0.##") + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Range") + ": " + LabelHelper.Orange + MaxRange.ToString("##0.##") + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Rotation") + ": " + LabelHelper.Orange + Rotation.ToLocalizationString();
		}

		public override List<EventKeyBinding> GetEventBindings()
		{
			_hooked = new EventKeyBinding("Hooked", KeyCode.None);
			_fullyRetracted = new EventKeyBinding("Fully retracted", KeyCode.None);
			return new List<EventKeyBinding> { _hooked, _fullyRetracted };
		}

		public override NimbatusItemData CreateData()
		{
			return new GrapplingHookData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			GrapplingHookData grapplingHookData;
			if ((grapplingHookData = data as GrapplingHookData) != null)
			{
				grapplingHookData.Strength = Strength;
				grapplingHookData.Rotation = Rotation;
				grapplingHookData.Target = Target;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			GrapplingHookData grapplingHookData;
			if ((grapplingHookData = data as GrapplingHookData) != null)
			{
				Strength = grapplingHookData.Strength;
				Rotation = grapplingHookData.Rotation;
				Target = grapplingHookData.Target;
			}
		}
	}
}
