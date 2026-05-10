using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public delegate void OnPorjectileShot();

	public delegate void ProjectilCollision(Projectile projectile, Collider other);

	public Action<Projectile, GameObject> onTargetReached;

	public Action<Projectile> onDestroy;

	[SerializeField]
	private float lifetime = 10f;

	[SerializeField]
	private bool destroyOnHit = true;

	[SerializeField]
	private bool destroyOnReachTarget = true;

	[SerializeField]
	private float lifetimeOnReachTarget = 1f;

	[SerializeField]
	private bool hideRenderersOnReachTarget;

	[SerializeField]
	private GameObject[] objectsToHideOnReachTarget;

	[SerializeField]
	private bool onlyHitTarget = true;

	[SerializeField]
	private bool collideWithEnviroment;

	[SerializeField]
	private GameObject hitVFX;

	[SerializeField]
	private bool spawnHitVFXOnGround = true;

	[SerializeField]
	private AudioData hitSound;

	private GameObject owner;

	private GameObject target;

	private Vector3 targetPosition = Vector3.zero;

	private bool isShot;

	public GameObject Owner => owner;

	public GameObject Target => target;

	public Vector3 TargetPosition
	{
		get
		{
			return targetPosition;
		}
		set
		{
			targetPosition = value;
		}
	}

	public bool IsShot => isShot;

	public bool DestroyOnReachTarget
	{
		get
		{
			return destroyOnReachTarget;
		}
		set
		{
			destroyOnReachTarget = value;
		}
	}

	public event OnPorjectileShot onProjectileShot;

	public event ProjectilCollision onProjectileHit;

	private void Awake()
	{
		EnableColliders(enable: false);
	}

	private void Start()
	{
		UnityEngine.Object.Destroy(base.gameObject, lifetime);
	}

	protected void EnableColliders(bool enable)
	{
		Collider[] componentsInChildren = GetComponentsInChildren<Collider>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].enabled = enable;
		}
	}

	protected void EnableRenderers(bool enabled)
	{
		MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].enabled = enabled;
		}
	}

	public void ShootProjectileToTarget(GameObject target, GameObject owner)
	{
		this.target = target;
		ShootProjectile(owner);
	}

	public void ShootProjectileToPosition(Vector3 targetPosition, GameObject owner)
	{
		this.targetPosition = targetPosition;
		ShootProjectile(owner);
	}

	private void ShootProjectile(GameObject owner)
	{
		base.transform.parent = null;
		this.owner = owner;
		if (!isShot)
		{
			GetComponent<ProjectileMovement>().onTargetReached += OnTargetReached;
		}
		isShot = true;
		EnableColliders(enable: true);
		this.onProjectileShot?.Invoke();
	}

	public virtual void DestroyProjectile()
	{
		DestroyProjectile(lifetimeOnReachTarget);
	}

	public virtual void DestroyProjectile(float lifetime)
	{
		isShot = false;
		if (lifetime > 0f)
		{
			EnableColliders(enable: false);
			if (hideRenderersOnReachTarget)
			{
				EnableRenderers(enabled: false);
			}
			if (objectsToHideOnReachTarget != null)
			{
				for (int i = 0; i < objectsToHideOnReachTarget.Length; i++)
				{
					objectsToHideOnReachTarget[i].SetActive(value: false);
				}
			}
		}
		onDestroy?.Invoke(this);
		UnityEngine.Object.Destroy(base.gameObject, lifetime);
	}

	private void OnTriggerEnter(Collider other)
	{
		bool num = !onlyHitTarget || other.gameObject == target;
		bool flag = collideWithEnviroment || !FunctionLibrary.IsInLayerMask(other.gameObject, GetEnviromentLayerMask());
		if (num && flag)
		{
			this.onProjectileHit?.Invoke(this, other);
			SpawnHitVFX();
			PlayHitSound();
			if (destroyOnHit)
			{
				DestroyProjectile();
			}
		}
	}

	private void SpawnHitVFX()
	{
		if ((bool)hitVFX)
		{
			Vector3 position = (spawnHitVFXOnGround ? Vector3.Scale(base.transform.position, new Vector3(1f, 0f, 1f)) : base.transform.position);
			UnityEngine.Object.Instantiate(hitVFX, position, Quaternion.identity, null);
		}
	}

	private void PlayHitSound()
	{
		if (hitSound != null && hitSound.AudioClips.Length != 0)
		{
			AudioSystem.Instance.PlaySound3D(hitSound, base.transform.position, AudioSystem.EAudioMixerGroup.SFX, AudioRolloffMode.Custom, 1f, 50f);
		}
	}

	private LayerMask GetEnviromentLayerMask()
	{
		return default(LayerMask);
	}

	protected virtual void OnTargetReached()
	{
		SpawnHitVFX();
		PlayHitSound();
		onTargetReached?.Invoke(this, Target);
		if (DestroyOnReachTarget)
		{
			DestroyProjectile(lifetimeOnReachTarget);
		}
	}
}
