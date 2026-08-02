using System.Collections;
using HQFPSTemplate.Pooling;
using Mirror;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	[RequireComponent(typeof(ProjectileWeapon))]
	public class ProjectileWeaponVFX : PlayerComponent, IEquipmentComponent, IObjectReferenceFiller
	{
		[SerializeField]
		private ProjectileWeaponVFXInfo m_VFXInfo;

		[Space]
		[SerializeField]
		private Transform m_Muzzle;

		[SerializeField]
		private Transform m_CasingEjectionPoint;

		[SerializeField]
		private Transform m_MagazineEjectionPoint;

		[Header("TPS Parts")]
		[SerializeField]
		private Transform m_Muzzle_TPS;

		[SerializeField]
		private Transform m_CasingEjectionPoint_TPS;

		[Space]
		[SerializeField]
		private LightEffect m_LightEffect;

		private ProjectileWeapon m_Weapon;

		private PlayerEquipmentController m_EquipmentController;

		private WaitForSeconds m_CasingSpawnDelay;

		public GameObject TracerPrefab => m_VFXInfo?.ParticleEffects?.TracerPrefab;

		public GameObject MuzzleFlashPrefab => m_VFXInfo?.ParticleEffects?.MuzzleFlashPrefab;

		public void TryAutoFillObjectReferences()
		{
			m_Muzzle = base.transform.FindDeepChild("Muzzle");
			m_LightEffect = base.transform.FindDeepChild("Light").GetComponent<LightEffect>();
			m_MagazineEjectionPoint = base.transform.FindDeepChild("MagazineEjection");
			m_CasingEjectionPoint = base.transform.FindDeepChild("CasingEjection");
		}

		public void Initialize(EquipmentItem equipmentItem)
		{
			m_Weapon = equipmentItem as ProjectileWeapon;
			m_CasingSpawnDelay = new WaitForSeconds(m_VFXInfo.CasingEjection.SpawnDelay);
			int num = m_Weapon.MagazineSize * 2;
			int maxSize = num * 2;
			if (m_VFXInfo.ParticleEffects.MuzzleFlashPrefab != null)
			{
				Singleton<PoolingManager>.Instance.CreatePool(m_VFXInfo.ParticleEffects.MuzzleFlashPrefab, num, maxSize, autoShrink: true, m_VFXInfo.ParticleEffects.MuzzleFlashPrefab.GetInstanceID().ToString(), 1f);
			}
			if (m_VFXInfo.ParticleEffects.TracerPrefab != null)
			{
				Singleton<PoolingManager>.Instance.CreatePool(m_VFXInfo.ParticleEffects.TracerPrefab, num, maxSize, autoShrink: true, m_VFXInfo.ParticleEffects.TracerPrefab.GetInstanceID().ToString(), 3f);
			}
			if (m_VFXInfo.MagazineEjection.MagazinePrefab != null)
			{
				Singleton<PoolingManager>.Instance.CreatePool(m_VFXInfo.MagazineEjection.MagazinePrefab, 3, 10, autoShrink: true, m_VFXInfo.MagazineEjection.MagazinePrefab.GetInstanceID().ToString(), 10f);
			}
			if (m_VFXInfo.CasingEjection.CasingPrefab != null)
			{
				Singleton<PoolingManager>.Instance.CreatePool(m_VFXInfo.CasingEjection.CasingPrefab, num, maxSize, autoShrink: true, m_VFXInfo.CasingEjection.CasingPrefab.GetInstanceID().ToString(), 5f);
			}
		}

		public void OnSelected()
		{
			m_Weapon.FireHitPoints.AddListener(OnFireHitPoints);
			base.Player.Reload.AddStartListener(OnReloadStart);
		}

		private void OnDisable()
		{
			m_Weapon.FireHitPoints.RemoveListener(OnFireHitPoints);
			base.Player.Reload.RemoveStartListener(OnReloadStart);
		}

		public Vector3 GetLocalMuzzlePos()
		{
			if (!(m_Muzzle != null))
			{
				return Vector3.zero;
			}
			return m_Muzzle.position;
		}

		public Vector3 GetTPSMuzzlePos()
		{
			if (!(m_Muzzle_TPS != null))
			{
				return GetLocalMuzzlePos();
			}
			return m_Muzzle_TPS.position;
		}

		public Quaternion GetLocalMuzzleRotation()
		{
			if (!(m_Muzzle != null))
			{
				return Quaternion.identity;
			}
			return m_Muzzle.rotation;
		}

		public Quaternion GetTPSMuzzleRotation()
		{
			if (!(m_Muzzle_TPS != null))
			{
				return GetLocalMuzzleRotation();
			}
			return m_Muzzle_TPS.rotation;
		}

		public Transform GetLocalMuzzle()
		{
			return m_Muzzle;
		}

		public Transform GetTPSMuzzle()
		{
			if (!(m_Muzzle_TPS != null))
			{
				return m_Muzzle;
			}
			return m_Muzzle_TPS;
		}

		public Vector3 GetViewmodelAlignedMuzzlePos()
		{
			Camera camera = ((base.Player.Camera != null) ? base.Player.Camera.UnityCamera : null);
			if (m_EquipmentController == null && base.Player != null)
			{
				m_EquipmentController = base.Player.GetComponentInChildren<PlayerEquipmentController>();
			}
			Camera camera2 = ((m_EquipmentController != null) ? m_EquipmentController.FPCamera : null);
			if (camera == null || camera2 == null || m_Muzzle == null)
			{
				return GetLocalMuzzlePos();
			}
			Vector3 pos = camera2.WorldToScreenPoint(m_Muzzle.position);
			if (pos.z <= 0f)
			{
				return GetLocalMuzzlePos();
			}
			Ray ray = camera.ScreenPointToRay(pos);
			float distance = Mathf.Max(pos.z, camera.nearClipPlane + 0.05f);
			return ray.GetPoint(distance);
		}

		public void SpawnCasingLocal(int targetLayer)
		{
			if (base.gameObject.activeInHierarchy && m_VFXInfo.CasingEjection.CasingPrefab != null)
			{
				Transform transform = ((targetLayer != 0) ? m_CasingEjectionPoint : (m_CasingEjectionPoint_TPS ?? m_CasingEjectionPoint));
				if (transform != null)
				{
					StartCoroutine(C_SpawnCasing(transform, targetLayer));
				}
			}
		}

		public void SpawnMagazineLocal(int targetLayer)
		{
			if (base.gameObject.activeInHierarchy && !m_Weapon.CanBeUsed() && m_VFXInfo.MagazineEjection.MagazinePrefab != null && m_MagazineEjectionPoint != null)
			{
				StartCoroutine(C_SpawnMagazine(targetLayer));
			}
		}

		private IEnumerator C_SpawnCasing(Transform spawnPoint, int targetLayer)
		{
			yield return m_CasingSpawnDelay;
			Quaternion rotation = Quaternion.Euler(Random.Range(-30, 30), Random.Range(-30, 30), Random.Range(-30, 30));
			Vector3 vector = spawnPoint.TransformVector((!base.Player.Aim.Active) ? m_VFXInfo.CasingEjection.SpawnOffset : m_VFXInfo.CasingEjection.AimSpawnOffset);
			PoolableObject objectLocal = Singleton<PoolingManager>.Instance.GetObjectLocal(m_VFXInfo.CasingEjection.CasingPrefab.gameObject, spawnPoint.position + vector, rotation);
			objectLocal.transform.localScale = new Vector3(m_VFXInfo.CasingEjection.CasingScale, m_VFXInfo.CasingEjection.CasingScale, m_VFXInfo.CasingEjection.CasingScale);
			SetLayerRecursively(objectLocal.transform, targetLayer);
			Rigidbody component = objectLocal.GetComponent<Rigidbody>();
			component.maxAngularVelocity = 10000f;
			component.velocity = base.transform.TransformVector(new Vector3(m_VFXInfo.CasingEjection.SpawnVelocity.x * Random.Range(0.75f, 1.15f), m_VFXInfo.CasingEjection.SpawnVelocity.y * Random.Range(0.9f, 1.1f), m_VFXInfo.CasingEjection.SpawnVelocity.z * Random.Range(0.85f, 1.15f))) + base.Player.Velocity.Get();
			float spin = m_VFXInfo.CasingEjection.Spin;
			component.angularVelocity = new Vector3(Random.Range(0f - spin, spin), Random.Range(0f - spin, spin), Random.Range(0f - spin, spin));
		}

		private void OnFireHitPoints(Vector3[] hitPoints)
		{
			PlayerWeaponVFXRelay component = TrainGameManager.instance.mainPlayer.GetComponent<PlayerWeaponVFXRelay>();
			if (component != null)
			{
				component.CmdSpawnEffects(base.gameObject.name, hitPoints, m_Muzzle.position, (!base.Player.Aim.Active) ? m_VFXInfo.ParticleEffects.TracerOffset : Vector3.zero, base.Player.GetComponent<NetworkIdentity>().netId);
			}
		}

		private void OnReloadStart()
		{
			PlayerWeaponVFXRelay component = TrainGameManager.instance.mainPlayer.GetComponent<PlayerWeaponVFXRelay>();
			if (component != null)
			{
				component.CmdSpawnMagazine(base.gameObject.name, base.Player.GetComponent<NetworkIdentity>().netId);
			}
		}

		public void PlayLightEffect()
		{
			if (m_LightEffect != null)
			{
				m_LightEffect.Play(fadeIn: false);
			}
		}

		public void SpawnCasingLocal()
		{
			if (base.gameObject.activeInHierarchy && m_VFXInfo.CasingEjection.CasingPrefab != null && m_CasingEjectionPoint != null)
			{
				StartCoroutine(C_SpawnCasing());
			}
		}

		public void SpawnMagazineLocal()
		{
			if (base.gameObject.activeInHierarchy && !m_Weapon.CanBeUsed() && m_VFXInfo.MagazineEjection.MagazinePrefab != null && m_MagazineEjectionPoint != null)
			{
				StartCoroutine(C_SpawnMagazine(m_VFXInfo.MagazineEjection.MagazinePrefab.gameObject.layer));
			}
		}

		public void SpawnEffectsLocal(Vector3[] hitPoints)
		{
			if (!base.gameObject.activeSelf)
			{
				return;
			}
			if (m_Muzzle != null)
			{
				if ((bool)m_VFXInfo.ParticleEffects.TracerPrefab)
				{
					for (int i = 0; i < hitPoints.Length; i++)
					{
						Vector3 vector = m_Muzzle.position + m_Muzzle.TransformVector((!base.Player.Aim.Active) ? m_VFXInfo.ParticleEffects.TracerOffset : Vector3.zero);
						PoolableObject objectLocal = Singleton<PoolingManager>.Instance.GetObjectLocal(m_VFXInfo.ParticleEffects.TracerPrefab, vector, Quaternion.LookRotation(hitPoints[i] - base.Player.Camera.Physics.transform.position));
						if (!(objectLocal != null))
						{
							continue;
						}
						objectLocal.gameObject.layer = LayerMask.NameToLayer("Bullet");
						ParticleSystem component = objectLocal.GetComponent<ParticleSystem>();
						if (component != null)
						{
							float num = Vector3.Distance(vector, hitPoints[i]);
							ParticleSystem.MainModule main = component.main;
							float constant = main.startSpeed.constant;
							if (constant > 0.01f)
							{
								main.startLifetime = num / constant;
							}
						}
					}
				}
				if (m_VFXInfo.ParticleEffects.MuzzleFlashPrefab != null)
				{
					PoolableObject objectLocal2 = Singleton<PoolingManager>.Instance.GetObjectLocal(m_VFXInfo.ParticleEffects.MuzzleFlashPrefab, Vector3.zero, Quaternion.identity, m_Muzzle);
					objectLocal2.transform.localPosition = m_VFXInfo.ParticleEffects.MuzzleFlashOffset;
					Vector3 muzzleFlashRandomRot = m_VFXInfo.ParticleEffects.MuzzleFlashRandomRot;
					muzzleFlashRandomRot = new Vector3(Random.Range(0f - muzzleFlashRandomRot.x, muzzleFlashRandomRot.x), Random.Range(0f - muzzleFlashRandomRot.y, muzzleFlashRandomRot.y), Random.Range(0f - muzzleFlashRandomRot.z, muzzleFlashRandomRot.z));
					objectLocal2.transform.localRotation = Quaternion.Euler(muzzleFlashRandomRot);
					float num2 = Random.Range(m_VFXInfo.ParticleEffects.MuzzleFlashRandomScale.x, m_VFXInfo.ParticleEffects.MuzzleFlashRandomScale.y);
					objectLocal2.transform.localScale = new Vector3(num2, num2, num2);
				}
			}
			PlayLightEffect();
			SpawnCasingLocal();
		}

		private static void SetLayerRecursively(Transform parent, int layer)
		{
			parent.gameObject.layer = layer;
			for (int i = 0; i < parent.childCount; i++)
			{
				SetLayerRecursively(parent.GetChild(i), layer);
			}
		}

		private void OnValidate()
		{
			m_CasingSpawnDelay = new WaitForSeconds((m_VFXInfo != null) ? m_VFXInfo.CasingEjection.SpawnDelay : 0f);
		}

		private IEnumerator C_SpawnMagazine(int targetLayer)
		{
			yield return new WaitForSeconds(m_VFXInfo.MagazineEjection.SpawnDelay);
			PoolableObject objectLocal = Singleton<PoolingManager>.Instance.GetObjectLocal(m_VFXInfo.MagazineEjection.MagazinePrefab, m_MagazineEjectionPoint.position, Quaternion.identity);
			SetLayerRecursively(objectLocal.transform, targetLayer);
			if (objectLocal.TryGetComponent<Rigidbody>(out var component))
			{
				component.AddRelativeForce(m_VFXInfo.MagazineEjection.MagazineVelocity);
				component.AddRelativeTorque(m_VFXInfo.MagazineEjection.MagazineAngularVelocity);
			}
		}

		private IEnumerator C_SpawnCasing()
		{
			yield return m_CasingSpawnDelay;
			Quaternion rotation = Quaternion.Euler(Random.Range(-30, 30), Random.Range(-30, 30), Random.Range(-30, 30));
			Vector3 vector = m_CasingEjectionPoint.TransformVector((!base.Player.Aim.Active) ? m_VFXInfo.CasingEjection.SpawnOffset : m_VFXInfo.CasingEjection.AimSpawnOffset);
			PoolableObject objectLocal = Singleton<PoolingManager>.Instance.GetObjectLocal(m_VFXInfo.CasingEjection.CasingPrefab.gameObject, m_CasingEjectionPoint.position + vector, rotation);
			objectLocal.transform.localScale = new Vector3(m_VFXInfo.CasingEjection.CasingScale, m_VFXInfo.CasingEjection.CasingScale, m_VFXInfo.CasingEjection.CasingScale);
			Rigidbody component = objectLocal.GetComponent<Rigidbody>();
			component.maxAngularVelocity = 10000f;
			component.velocity = base.transform.TransformVector(new Vector3(m_VFXInfo.CasingEjection.SpawnVelocity.x * Random.Range(0.75f, 1.15f), m_VFXInfo.CasingEjection.SpawnVelocity.y * Random.Range(0.9f, 1.1f), m_VFXInfo.CasingEjection.SpawnVelocity.z * Random.Range(0.85f, 1.15f))) + base.Player.Velocity.Get();
			float spin = m_VFXInfo.CasingEjection.Spin;
			component.angularVelocity = new Vector3(Random.Range(0f - spin, spin), Random.Range(0f - spin, spin), Random.Range(0f - spin, spin));
		}
	}
}
