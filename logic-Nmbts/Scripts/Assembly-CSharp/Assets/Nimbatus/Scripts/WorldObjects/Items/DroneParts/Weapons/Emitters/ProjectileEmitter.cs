using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainData;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute.Enums;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Projectiles;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters
{
	public class ProjectileEmitter : Emitter
	{
		public FloatWeaponAttribute ShootForce = new FloatWeaponAttribute();

		public FloatWeaponAttribute Recoil = new FloatWeaponAttribute();

		public FloatWeaponAttribute Accuracy = new FloatWeaponAttribute();

		public FloatWeaponAttribute NumberOfShots = new FloatWeaponAttribute();

		public Transform ShootTransform;

		public ProjectileGenerator ProjectileGenerator;

		public ProjectileGenerator SecondaryProjectileGenerator;

		private ProjectileGenerator _instantiatedGen;

		private ProjectileGenerator _instantiatedSecondarGen;

		private GameObjectPoolManager<Projectile> _projectilePool;

		private GameObjectPoolManager<Projectile> _secondaryProjectilePool;

		private const float ForceMultiplier = 0.25f;

		public override void InitAttributes()
		{
			base.InitAttributes();
			ShootForce.Init(EWeaponAttributeType.ShootForce, 0, 0f, 20f, !UsedByEnemy);
			Recoil.Init(EWeaponAttributeType.Recoil, 2, 0f, 3f, !UsedByEnemy);
			Accuracy.Init(EWeaponAttributeType.Accuracy, 1, 0f, 100f, !UsedByEnemy);
			NumberOfShots.Init(EWeaponAttributeType.NumberOfShots, 0, 0f, 20f, !UsedByEnemy);
			if (_instantiatedGen == null)
			{
				_instantiatedGen = Object.Instantiate(ProjectileGenerator, base.transform);
			}
			if (_instantiatedSecondarGen == null)
			{
				_instantiatedSecondarGen = Object.Instantiate(SecondaryProjectileGenerator, base.transform);
			}
			_instantiatedGen.Init(this);
			_instantiatedSecondarGen.Init(this);
		}

		public override void Init()
		{
			_projectilePool = new GameObjectPoolManager<Projectile>(InstantiateProjectile, InitProjectile, 100);
			_secondaryProjectilePool = new GameObjectPoolManager<Projectile>(InstantiateSecondaryProjectile, InitSecondaryProjectile, 100);
		}

		private void InitProjectile(Projectile projectile)
		{
			_instantiatedGen.InitProjectile(projectile);
		}

		private void InitSecondaryProjectile(Projectile projectile)
		{
			_instantiatedSecondarGen.InitProjectile(projectile);
		}

		private Projectile InstantiateProjectile()
		{
			Projectile projectile = _instantiatedGen.CreateProjectile();
			InitProjectile(projectile);
			return projectile;
		}

		private Projectile InstantiateSecondaryProjectile()
		{
			Projectile projectile = _instantiatedSecondarGen.CreateProjectile();
			InitSecondaryProjectile(projectile);
			return projectile;
		}

		public IEnumerator SpawnRandomProjectiles(Vector3 pos)
		{
			for (int i = 0; i < 3; i++)
			{
				Projectile projectile = _secondaryProjectilePool.Instantiate(pos, Random.rotation);
				if (projectile != null)
				{
					projectile.Reset();
					projectile.SetPool(_secondaryProjectilePool);
					projectile.gameObject.layer = ProjectileLayer;
					projectile.transform.parent = null;
					projectile.transform.localScale = Vector3.one;
					projectile.transform.position = pos;
					Vector3 force = projectile.transform.right * ShootForce.Value * 0.25f;
					projectile.Rigidbody.AddForce(force, ForceMode.Impulse);
					if (this != null && _instantiatedSecondarGen != null && _instantiatedSecondarGen.ShootEffect != null)
					{
						_instantiatedSecondarGen.ShootEffect.PlayEffect(base.transform);
					}
				}
				yield return true;
			}
		}

		public override void OnDisable()
		{
			base.OnDisable();
			StopAllCoroutines();
		}

		protected override void DoEmit(bool emissionActive, bool readyToShoot)
		{
			float num = (100f - Accuracy.Value) / 2f / 45f;
			if (emissionActive && readyToShoot)
			{
				for (int i = 0; (float)i < NumberOfShots.Value; i++)
				{
					ShootProjectile(base.transform.right + base.transform.up * Random.Range(0f - num, num), i);
				}
			}
		}

		protected override bool IsUnobstructed()
		{
			if (RuntimeGlobals.WorldController == null || RuntimeGlobals.WorldController.ForeGroundTerrain == null)
			{
				return true;
			}
			NimbatusTerrainData? data = RuntimeGlobals.WorldController.ForeGroundTerrain.GetData(ShootTransform.position);
			if (data.HasValue && data.Value.Volume > 0.5f)
			{
				return false;
			}
			return true;
		}

		private void ShootProjectile(Vector3 direction, int index)
		{
			Vector3 vector = ShootTransform.position + ShootTransform.up * index * 0.1f;
			vector.z = 0.01f;
			direction.z = 0.01f;
			Projectile projectile = _projectilePool.Instantiate(vector, TransformHelper.Get2DRotationTowardsTarget(vector, vector + direction));
			if (projectile != null)
			{
				if (_instantiatedGen.ShootEffect != null)
				{
					_instantiatedGen.ShootEffect.PlayEffect(base.transform);
				}
				projectile.Reset();
				projectile.SetPool(_projectilePool);
				projectile.gameObject.layer = ProjectileLayer;
				projectile.transform.position = vector;
				projectile.transform.localScale = Vector3.one;
				projectile.transform.rotation = TransformHelper.Get2DRotationTowardsTarget(vector, vector + direction);
				if (WeaponRigidbody != null)
				{
					Vector3 vector2 = (ShootTransform.right + direction).normalized * ShootForce.Value * 0.25f;
					Vector3 vector3 = WeaponRigidbody.velocity * projectile.Rigidbody.mass;
					float num = (Vector2.Dot(vector2.normalized, vector3.normalized) + 1f) / 2f;
					projectile.Rigidbody.AddForce(vector2 + vector3 * num, ForceMode.Impulse);
				}
				else
				{
					projectile.Rigidbody.AddForce((ShootTransform.right + direction).normalized * ShootForce.Value * 0.25f + Vector3.one * projectile.Rigidbody.mass, ForceMode.Impulse);
				}
				DoRecoil();
			}
		}

		private void DoRecoil()
		{
			StartCoroutine(HandleRecoil());
		}

		private IEnumerator HandleRecoil()
		{
			if (!UsedByEnemy && RuntimeGlobals.Camera != null)
			{
				RuntimeGlobals.Camera.DoRecoilShake(base.transform.right, Recoil.Value);
			}
			if (WeaponRigidbody != null)
			{
				WeaponRigidbody.AddForceAtPosition(-base.transform.right * Recoil.Value * 15f, WeaponRigidbody.transform.position, ForceMode.Impulse);
			}
			base.transform.position = base.transform.position - base.transform.right * 0.2f;
			yield return new WaitForSeconds(0.05f);
			Vector3 position = base.transform.position;
			position.x = 0f;
			position.y = 0f;
			position.z = -0.1f;
			base.transform.localPosition = position;
		}

		public override List<NimbatusItem> GetModules()
		{
			List<NimbatusItem> list = new List<NimbatusItem>();
			list.Add(_instantiatedGen);
			list.AddRange(Upgrades.Cast<NimbatusItem>());
			return list;
		}

		protected override IEnumerable<WeaponAttribute> GetAttributes()
		{
			List<WeaponAttribute> list = new List<WeaponAttribute>();
			list.Add(ShootForce);
			list.Add(Recoil);
			list.Add(Accuracy);
			list.Add(NumberOfShots);
			list.AddRange(_instantiatedGen.GetAttributes());
			return list;
		}
	}
}
