using Assets.Nimbatus.Scripts.Combat;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Ammunitions;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons
{
	public class EnemyWeapon : NimbatusItem, IWeapon
	{
		[HideInInspector]
		public Emitter Emitter;

		[HideInInspector]
		public Ammunition Ammunition;

		[HideInInspector]
		public WeaponPreset Preset;

		internal IsShootingCheck ShootingCheck;

		public override Texture2D GetIcon()
		{
			return Emitter.GetIcon();
		}

		public void Init(NimbatusObject parentObject, float damageModifier)
		{
			Emitter.Init(parentObject, null, true, EWeaponRotation.Fixed, damageModifier);
			Emitter.InitLayer(BaseSingleton<CollisionLayerManager>.Instance.EnemyWeaponRaycastLayerMask, BaseSingleton<CollisionLayerManager>.Instance.EnemyProjectileLayer);
		}

		public override void InitStackSettings()
		{
			IsStackable = false;
		}

		public void ApplyWeaponPreset(WeaponPreset preset)
		{
			Preset = preset;
			Ammunition = preset.Ammunition;
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

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (!(Emitter == null))
			{
				Emitter.UpdateRotation();
				if (ShootingCheck != null && ShootingCheck(this))
				{
					Emitter.Emit(true);
				}
				else
				{
					Emitter.Emit(false);
				}
			}
		}

		public NimbatusItem Instantiate()
		{
			return Object.Instantiate(base.gameObject).GetComponent<NimbatusItem>();
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
