using System;
using System.Collections;
using HQFPSTemplate.Items;
using HQFPSTemplate.Pooling;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	public class ThrowingWeapon : EquipmentItem
	{
		[Serializable]
		public class ThrowingWeaponSettings
		{
			public GameObject FPObject;

			public float ModelDisableDelay = 0.9f;
		}

		private readonly int animHash_LongThrowSpeed = Animator.StringToHash("Long Throw Speed");

		private readonly int animHash_LongThrow = Animator.StringToHash("Long Throw");

		[SerializeField]
		[Group]
		private ThrowingWeaponSettings m_ThrowingWeaponSettings;

		private ThrowingWeaponInfo m_TW;

		private bool m_IsThrown;

		public override void Initialize(EquipmentHandler eHandler)
		{
			base.Initialize(eHandler);
			m_TW = base.EInfo as ThrowingWeaponInfo;
			if (m_TW.Throwing.ObjectToSpawn != null)
			{
				Singleton<PoolingManager>.Instance.CreatePool(m_TW.Throwing.ObjectToSpawn, 3, 6, autoShrink: true, m_TW.Throwing.ObjectToSpawn.GetInstanceID().ToString(), 10f);
			}
		}

		public override void Equip(Item item)
		{
			base.Equip(item);
			base.EHandler.Animator_SetFloat(animHash_LongThrowSpeed, m_TW.Throwing.AnimThrowSpeed);
			m_ThrowingWeaponSettings.FPObject.SetActive(value: true);
			m_IsThrown = false;
		}

		public override bool TryUseOnce(Ray[] itemUseRays, int useType)
		{
			if (m_IsThrown)
			{
				return false;
			}
			m_GeneralEvents.OnUse.Invoke();
			base.EHandler.Animator_SetTrigger(animHash_LongThrow);
			base.EHandler.PlayDelayedSounds(m_TW.Throwing.ThrowAudio);
			StartCoroutine(C_ThrowWithDelay(useType));
			return true;
		}

		public override bool CanBeUsed()
		{
			return !m_IsThrown;
		}

		private IEnumerator C_ThrowWithDelay(int throwIndex)
		{
			m_IsThrown = true;
			float animSpeedFactor = 1f / m_TW.Throwing.AnimThrowSpeed;
			base.Player.Camera.Physics.PlayDelayedCameraForces(m_TW.Throwing.ThrowCamForces);
			yield return new WaitForSeconds(m_TW.Throwing.ModelDisableDelay * animSpeedFactor);
			m_ThrowingWeaponSettings.FPObject.SetActive(value: false);
			yield return new WaitForSeconds((m_TW.Throwing.SpawnDelay - m_TW.Throwing.ModelDisableDelay) * animSpeedFactor);
			Ray[] array = base.EHandler.GenerateItemUseRays(base.Player, base.EHandler.ItemUseTransform, 1, 1f);
			Vector3 position = array[0].origin + base.transform.TransformVector(m_TW.Throwing.SpawnOffset);
			Quaternion rotation = Quaternion.LookRotation(array[0].direction, base.transform.up);
			Projectile projectile = UnityEngine.Object.Instantiate(m_TW.Throwing.Projectile, position, rotation);
			Rigidbody component = projectile.GetComponent<Rigidbody>();
			component.velocity = projectile.transform.forward * m_TW.Throwing.ThrowVelocity + base.Player.Velocity.Get();
			component.angularVelocity = UnityEngine.Random.onUnitSphere * m_TW.Throwing.AngularSpeed;
			projectile.Launch(base.Player);
			if (m_TW.Throwing.ObjectToSpawn != null)
			{
				Singleton<PoolingManager>.Instance.GetObject(m_TW.Throwing.ObjectToSpawn, array[0].origin + base.transform.TransformVector(m_TW.Throwing.ObjectToSpawnOffset), Quaternion.identity, null);
			}
			base.Player.DestroyEquippedItem.Try();
		}
	}
}
