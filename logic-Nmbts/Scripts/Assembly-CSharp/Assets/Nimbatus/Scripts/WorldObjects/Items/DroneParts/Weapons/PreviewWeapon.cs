using Assets.Nimbatus.Scripts.Combat;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Ammunitions;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons
{
	public class PreviewWeapon : SerializedMonoBehaviour, IWeapon
	{
		[HideInInspector]
		public Emitter Emitter;

		[HideInInspector]
		public Ammunition Ammunition;

		[HideInInspector]
		public WeaponPreset Preset;

		public string GetDescription()
		{
			if (Emitter != null)
			{
				return Emitter.GetDetailedTooltip();
			}
			return "";
		}

		public void Init(float damageModifier)
		{
			if (Emitter != null)
			{
				Emitter.Init(null, null, false, EWeaponRotation.Fixed, damageModifier);
				Emitter.InitLayer(BaseSingleton<CollisionLayerManager>.Instance.EnemyWeaponRaycastLayerMask, BaseSingleton<CollisionLayerManager>.Instance.EnemyProjectileLayer);
			}
		}

		public void ApplyWeaponPreset(WeaponPreset preset)
		{
			if (preset != null && !(preset.Ammunition == null) && !(preset.Emitter == null))
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
		}

		public void FixedUpdate()
		{
			if (!(Emitter == null))
			{
				Emitter.Emit(true);
			}
		}

		public NimbatusItem Instantiate()
		{
			return Object.Instantiate(base.gameObject).GetComponent<NimbatusItem>();
		}
	}
}
