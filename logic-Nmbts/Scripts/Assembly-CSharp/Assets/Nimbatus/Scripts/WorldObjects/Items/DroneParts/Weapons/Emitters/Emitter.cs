using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.ResourceCollection;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Ammunitions;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute.Enums;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters
{
	public abstract class Emitter : NimbatusItem
	{
		public EWeaponType WeaponType;

		public Renderer AmmunitionDisplay;

		public Texture2D AmmunitionTexture;

		[HideInInspector]
		public EWeaponRotation RotationMode;

		public FloatWeaponAttribute AttackSpeed = new FloatWeaponAttribute();

		public FloatWeaponAttribute EnergyUsage = new FloatWeaponAttribute();

		public FloatWeaponAttribute Damage = new FloatWeaponAttribute();

		public FloatWeaponAttribute ElementalStrength = new FloatWeaponAttribute();

		public FloatWeaponAttribute DiggingStrength = new FloatWeaponAttribute();

		private List<WeaponAttribute> _attributes;

		private bool _wasEmitting;

		[HideInInspector]
		public int ProjectileLayer;

		[HideInInspector]
		public LayerMask Collisionmask;

		[HideInInspector]
		public bool UsedByEnemy;

		[HideInInspector]
		public Rigidbody WeaponRigidbody;

		[HideInInspector]
		public NimbatusObject ParentObject;

		[HideInInspector]
		public Ammunition Ammunition;

		[HideInInspector]
		public List<WeaponAttributeUpgrade> Upgrades;

		[HideInInspector]
		public float DamageModifier;

		private float _lastShootTime;

		private bool _wasInit;

		public List<WeaponAttribute> Attributes
		{
			get
			{
				if (_attributes == null)
				{
					InitAttributes();
					_attributes = GetBaseAttributes();
					_attributes.AddRange(GetAttributes());
				}
				return _attributes;
			}
		}

		protected virtual List<WeaponAttribute> GetBaseAttributes()
		{
			return new List<WeaponAttribute> { AttackSpeed, EnergyUsage, Damage, ElementalStrength, DiggingStrength };
		}

		protected abstract IEnumerable<WeaponAttribute> GetAttributes();

		protected override void Awake()
		{
			base.Awake();
			_wasInit = false;
		}

		public override void PostLoad()
		{
			base.PostLoad();
			InitAttributes();
		}

		public override void InitStackSettings()
		{
			IsStackable = false;
		}

		public virtual void InitAttributes()
		{
			AttackSpeed.Init(EWeaponAttributeType.AttackSpeed, 1, 0.5f, 20f, !UsedByEnemy);
			EnergyUsage.Init(EWeaponAttributeType.EnergyUsage, 1, 0f, 50f, !UsedByEnemy);
			Damage.Init(EWeaponAttributeType.Damage, 0, 0f, 200f, !UsedByEnemy);
			ElementalStrength.Init(EWeaponAttributeType.ElementalMultiplier, 1, 0f, 10f, !UsedByEnemy);
			DiggingStrength.Init(EWeaponAttributeType.DiggingStrength, 1, 0f, 20f, !UsedByEnemy);
		}

		public void Init(NimbatusObject parentObject, Rigidbody rigidBody, bool usedByEnemy, EWeaponRotation rotation, float damageModifier = 1f)
		{
			WeaponRigidbody = rigidBody;
			UsedByEnemy = usedByEnemy;
			DamageModifier = damageModifier;
			ParentObject = parentObject;
			RotationMode = rotation;
			if (usedByEnemy)
			{
				Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].enabled = false;
				}
			}
			foreach (WeaponAttributeUpgrade upgrade in Upgrades)
			{
				if (upgrade == null || (!usedByEnemy && !upgrade.Unlocked && RuntimeGlobals.RunningMode != ERunningMode.WeaponCustomization && RuntimeGlobals.HasWeaponWorkshop))
				{
					continue;
				}
				foreach (WeaponAttribute attribute in Attributes)
				{
					if (upgrade.IsCompatible(this))
					{
						attribute.ApplyUpgrade(upgrade);
					}
				}
			}
			Init();
			if (AmmunitionDisplay != null)
			{
				AmmunitionDisplay.material.color = Ammunition.ColorModifier;
			}
			_wasInit = true;
		}

		public void InitLayer(LayerMask collisionMask, int projectileLayer)
		{
			Collisionmask = collisionMask;
			ProjectileLayer = projectileLayer;
		}

		public virtual void ApplyPreset(WeaponPreset preset)
		{
			Upgrades = preset.Upgrades;
			Ammunition = preset.Ammunition;
			_wasInit = false;
		}

		public abstract void Init();

		protected abstract void DoEmit(bool emissionActive, bool readyToShoot);

		public void Emit(bool emit, ResourceHub resourceHub = null)
		{
			if ((!_wasEmitting && !emit) || !_wasInit)
			{
				return;
			}
			foreach (WeaponAttribute attribute in Attributes)
			{
				attribute.Update(emit);
			}
			bool flag = emit && IsReadyToShoot();
			float amount = EnergyUsage.Value / AttackSpeed.Value;
			if (resourceHub != null)
			{
				if (resourceHub.HasResource(EResourceType.Energy, amount))
				{
					if (flag)
					{
						resourceHub.UseResourceFromParts(EResourceType.Energy, amount);
					}
				}
				else
				{
					emit = false;
				}
			}
			if (IsUnobstructed() && (_wasEmitting || emit))
			{
				DoEmit(emit, flag);
				_wasEmitting = emit;
			}
		}

		public bool IsReadyToShoot()
		{
			float num = 1f / AttackSpeed.Value;
			if (Time.time - _lastShootTime > num + Random.Range((0f - num) * 0.05f, num * 0.05f))
			{
				_lastShootTime = Time.time;
				return true;
			}
			return false;
		}

		protected abstract bool IsUnobstructed();

		public void UpdateRotation()
		{
			EWeaponRotation rotationMode = RotationMode;
			if (rotationMode == EWeaponRotation.Cursor)
			{
				base.transform.rotation = TransformHelper.Get2DRotationTowardsMouse(base.transform.position, RuntimeGlobals.Camera.Camera);
			}
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip();
			foreach (WeaponAttribute item in Attributes.Where((WeaponAttribute a) => !a.Hidden))
			{
				text = text + LabelHelper.NewLine + item;
			}
			return text;
		}

		public abstract List<NimbatusItem> GetModules();

		public override string ToString()
		{
			return Name.GetTranslation();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
		}

		public override NimbatusItemData CreateData()
		{
			return new NimbatusItemData();
		}
	}
}
