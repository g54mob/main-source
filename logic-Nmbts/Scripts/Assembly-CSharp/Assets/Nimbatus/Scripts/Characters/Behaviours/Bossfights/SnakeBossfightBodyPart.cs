using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Behaviours.Radar;
using Assets.Nimbatus.Scripts.Behaviours.Weapons;
using Assets.Nimbatus.Scripts.Combat;
using Assets.Nimbatus.Scripts.GalaxyMap.Boss;
using Assets.Nimbatus.Scripts.WorldObjects;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Characters.Behaviours.Bossfights
{
	public class SnakeBossfightBodyPart : MonoBehaviour
	{
		public SnakeBossfightBodyCollider Collider;

		public NimbatusParticleEffect ExplosionEffect;

		public InteractiveWorldObject Armor;

		public InteractiveWorldObject Eye;

		public GameObject Eyelid;

		public WeaponSlot EyeWeapon;

		public EnemyRadar EyeRadar;

		public bool IsHead;

		[ShowIf("IsHead", true)]
		public GameObject Remnant;

		[ShowIf("IsHead", true)]
		public ParticleSystem BloodParticleSystem;

		[ShowIf("IsHead", true)]
		public ParticleSystem LaserParticleSystem;

		[ShowIf("IsHead", true)]
		public string LaserSoundEffect;

		public string SoundLoop;

		public string DamageSoundLoop;

		[HideInInspector]
		public bool Attached;

		private bool _canShoot;

		public void Init(SnakeBossfightManager snake)
		{
			Attached = true;
			AudioController.Play(SoundLoop, base.transform);
			Collider.Init(this, snake);
			if (!(Eye == null) && !(EyeWeapon == null) && !(EyeRadar == null))
			{
				EyeWeapon.Init(Eye, 1, ShootingCheck);
			}
		}

		public void OnDisable()
		{
			if (!(Armor == null))
			{
				Armor.HealthPool.SetTemperature(0f);
			}
		}

		public void Die()
		{
			Attached = false;
			if (AudioController.IsPlaying(DamageSoundLoop))
			{
				AudioController.Stop(DamageSoundLoop);
			}
			if (AudioController.IsPlaying(LaserSoundEffect))
			{
				AudioController.Stop(LaserSoundEffect);
			}
			ExplosionEffect.PlayEffect(base.transform);
			Object.Destroy(base.gameObject);
		}

		public void ChangeEyeState(bool attackable)
		{
			if (!(Eye == null))
			{
				Eye.GetComponent<Collider>().enabled = attackable;
				Eye.HealthPool.IsInvincible = !attackable;
				if (Eyelid != null)
				{
					Eyelid.SetActive(!attackable);
				}
			}
		}

		public void SetEyeOpen(bool open)
		{
			if (!(Eye == null))
			{
				Eye.GetComponent<SpriteRenderer>().enabled = open;
				if (open && IsHead && BloodParticleSystem != null)
				{
					BloodParticleSystem.Play();
				}
			}
		}

		public void ActivateEyeWeapon(bool active)
		{
			_canShoot = active;
		}

		public void ChargeLaser(bool on)
		{
			if (IsHead && LaserParticleSystem != null)
			{
				if (on)
				{
					AudioController.Play(LaserSoundEffect);
					LaserParticleSystem.Play();
				}
				else
				{
					LaserParticleSystem.Stop();
				}
			}
		}

		private bool ShootingCheck(EnemyWeapon weapon)
		{
			if (!_canShoot || EyeRadar.NearestTarget == null || Eye.HealthPool.CurrentState == EChemicalState.Frozen || EyeWeapon.Weapon == null)
			{
				return false;
			}
			if (!IsHead)
			{
				float angle = Vector3.SignedAngle(EyeWeapon.Weapon.transform.right, EyeRadar.NearestTarget.position - EyeWeapon.Weapon.transform.position, Vector3.forward);
				EyeWeapon.Weapon.transform.Rotate(Vector3.forward, angle);
			}
			return true;
		}
	}
}
