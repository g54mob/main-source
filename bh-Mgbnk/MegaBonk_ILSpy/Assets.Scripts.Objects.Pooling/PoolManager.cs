using System;
using System.Collections.Generic;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Attacks;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Objects.Pooling;

public class PoolManager : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass121_0
	{
		public PoolManager _003C_003E4__this;

		public GameObject hitPrefabToUse;

		public ObjectPool<GameObject> newPool;

		public int maxObjects;

		internal GameObject _003CCreateObjectPool_003Eb__0()
		{
			if ((object)_003C_003E4__this != null)
			{
				return _003C_003E4__this.CreatePooledItem(hitPrefabToUse, newPool, maxObjects);
			}
			return (GameObject)(object)new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass122_0
	{
		public PoolManager _003C_003E4__this;

		public GameObject hitPrefabToUse;

		public ObjectPool<GameObject> newPool;

		public int maxObjects;

		public float timeoutTime;

		internal GameObject _003CCreateObjectPoolTimeout_003Eb__0()
		{
			float time = default(float);
			if ((object)_003C_003E4__this != null)
			{
				return _003C_003E4__this.CreatePooledItemTimeout(hitPrefabToUse, newPool, maxObjects, time);
			}
			return (GameObject)(object)new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass123_0
	{
		public PoolManager _003C_003E4__this;

		public EnemySpecialAttack specialAttack;

		public ObjectPool<GameObject> newPool;

		public int maxObjects;

		internal GameObject _003CGetEnemyAttack_003Eb__0()
		{
			EnemySpecialAttack enemySpecialAttack = specialAttack;
			if (specialAttack != null && (object)_003C_003E4__this != null)
			{
				return _003C_003E4__this.CreatePooledItem(enemySpecialAttack.attackPrefab, newPool, maxObjects);
			}
			return (GameObject)(object)new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass124_0
	{
		public PoolManager _003C_003E4__this;

		public EnemySpecialAttackPrefab enemyAttackPrefab;

		public ObjectPool<GameObject> newPool;

		public int maxObjects;

		internal GameObject _003CGetEnemyAttackFx_003Eb__0()
		{
			EnemySpecialAttackPrefab enemySpecialAttackPrefab = enemyAttackPrefab;
			if ((object)enemyAttackPrefab != null && (object)_003C_003E4__this != null)
			{
				return _003C_003E4__this.CreatePooledItem(enemySpecialAttackPrefab.attackEffectPrefab, newPool, maxObjects);
			}
			return (GameObject)(object)new NullReferenceException();
		}
	}

	public Transform damageNumbersParent;

	private static int maxCritPrefabs = 20;

	private int maxBonkPrefabs = 10;

	private int maxBulletHitPrefabs = 20;

	private int maxHitNumbers = 100;

	private int maxLightningStrikes = 70;

	private int maxFirefields = 50;

	public const int rocketPoolSize = 200;

	private int orbPoolSize = 200;

	private int explosionPoolSize = 100;

	private static int maxSilver = 30;

	private static int cursedHitsPoolSize = 20;

	private static int charmPoolSize = 20;

	private static int eatPoolSize = 10;

	public static PoolManager Instance;

	private int maxWarningSpheres = 5000;

	public GameObject xpPrefab;

	public GameObject goldPrefab;

	public GameObject silverPrefab;

	public GameObject enemyPrefab;

	public GameObject enemySpawnFxPrefab;

	public GameObject damageNumbersPrefab;

	public GameObject pickupEffectPrefab;

	public GameObject goldBurstPrefab;

	public GameObject critEffectPrefab;

	public GameObject lightningStrikePrefab;

	public GameObject footstepPrefab;

	public GameObject enemyStatusSymbolsPrefab;

	public ObjectPool<GameObject> xpPool;

	public ObjectPool<GameObject> goldPool;

	public ObjectPool<GameObject> silverPool;

	public ObjectPool<GameObject> enemyPool;

	public ObjectPool<GameObject> enemySpawnFxPool;

	public ObjectPool<GameObject> damageNumbersPool;

	public ObjectPool<GameObject> pickupeffectPool;

	public ObjectPool<GameObject> goldBurstPool;

	public ObjectPool<GameObject> critEffectPool;

	public ObjectPool<GameObject> lightningStrikePool;

	public ObjectPool<GameObject> footstepPool;

	public ObjectPool<GameObject> enemyStatusSymbolsPool;

	public ObjectPool<GameObject> powerupPool;

	public ObjectPool<GameObject> warningTubePool;

	public ObjectPool<GameObject> warningSpherePool;

	public ObjectPool<GameObject> bullseyePool;

	public ObjectPool<GameObject> poisonPool;

	public GameObject defaultHitPrefab;

	public GameObject powerupPrefab;

	public GameObject warningTube;

	public GameObject warningSphere;

	public GameObject bullseye;

	public GameObject poisonCloud;

	public Dictionary<EWeapon, ObjectPool<GameObject>> weaponAttackPools;

	public Dictionary<EWeapon, ObjectPool<GameObject>> projectilePools;

	public Dictionary<string, ObjectPool<GameObject>> projectileDonePools;

	public Dictionary<string, ObjectPool<GameObject>> projectileHitPools;

	public Dictionary<string, ObjectPool<GameObject>> enemyAttacksPools;

	public Dictionary<EEnemyAttack, ObjectPool<GameObject>> enemyAttacksFxPools;

	private int itemFxPoolSizes;

	public ObjectPool<GameObject> grandmaTonicPool;

	public ObjectPool<GameObject> megaCritPool;

	public ObjectPool<GameObject> executePool;

	public ObjectPool<GameObject> spicyMeatballPool;

	public ObjectPool<GameObject> chainLightningPool;

	public ObjectPool<GameObject> freezeFxPool;

	public ObjectPool<GameObject> firefieldPool;

	public ObjectPool<GameObject> rocketPool;

	public ObjectPool<GameObject> explosionPool;

	public ObjectPool<GameObject> bonkPool;

	public ObjectPool<GameObject> bulletHitPool;

	public ObjectPool<GameObject> cursedHitPool;

	public ObjectPool<GameObject> orbPool;

	public ObjectPool<GameObject> ghostPool;

	public ObjectPool<GameObject> angrySoulPool;

	public ObjectPool<GameObject> charmPool;

	public ObjectPool<GameObject> borgorPool;

	public ObjectPool<GameObject> eatPool;

	public ObjectPool<GameObject> bloodmarkPool;

	public ObjectPool<GameObject> cactusPool;

	public ObjectPool<GameObject> tumbleweedPool;

	public ObjectPool<GameObject> tumbleweedBreakPool;

	public ObjectPool<GameObject> quinMaskPool;

	public ObjectPool<GameObject> snekPool;

	public GameObject grandmaTonicFx;

	public GameObject megaCritFx;

	public GameObject spicyMeatballFx;

	public GameObject chainLightningFx;

	public GameObject freezeFx;

	public GameObject firefield;

	public GameObject rocket;

	public GameObject explosionFx;

	public GameObject bonkFx;

	public GameObject executeFx;

	public GameObject bulletHit;

	public GameObject cursedHit;

	public GameObject orb;

	public GameObject ghost;

	public GameObject angrySoul;

	public GameObject charmFx;

	public GameObject borgor;

	public GameObject eat;

	public GameObject bloodmark;

	public GameObject cactusFx;

	public GameObject tumbleweed;

	public GameObject tumbleweedBreak;

	public GameObject quinMaskFx;

	public GameObject snekFx;

	private Dictionary<GameObject, WeaponAttack> weaponAttacksDict;

	private Dictionary<GameObject, ProjectileBase> projectileDict;

	private Dictionary<GameObject, DamageNumbers> damageNumbersDict;

	private Dictionary<GameObject, AttackHit> attackHitsDict;

	private Dictionary<EWeapon, string> weaponStrings;

	private void Awake()
	{
		if (Instance != null)
		{
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj);
		}
		else
		{
			Instance = this;
		}
	}

	private unsafe void Start()
	{
		Func<GameObject> createFunc = delegate
		{
			ObjectPool<GameObject> objectPool42 = xpPool;
			return (GameObject)((xpPool != null) ? ((object)((objectPool42._003CCountAll_003Ek__BackingField < PickupManager.maxXpObjects) ? UnityEngine.Object.Instantiate(xpPrefab) : null)) : ((object)new NullReferenceException()));
		};
		Action<GameObject> action = OnTakeFromPool;
		action._002Ector((object)this, (IntPtr)(nint)__ldftn(PoolManager.OnTakeFromPool));
		Action<GameObject> actionOnRelease = OnReturnedToPool;
		Action<GameObject> action2 = OnDestroyPoolObject;
		Action<GameObject> actionOnDestroy = default(Action<GameObject>);
		bool collectionCheck = default(bool);
		int defaultCapacity = default(int);
		int maxSize = default(int);
		ObjectPool<GameObject> objectPool = new ObjectPool<GameObject>(createFunc, action, actionOnRelease, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		xpPool = objectPool;
		Func<GameObject> createFunc2 = delegate
		{
			ObjectPool<GameObject> objectPool42 = goldPool;
			return (GameObject)((goldPool != null) ? ((object)((objectPool42._003CCountAll_003Ek__BackingField < MoneyFlying.maxMoneyObjects) ? UnityEngine.Object.Instantiate(goldPrefab) : null)) : ((object)new NullReferenceException()));
		};
		Action<GameObject> actionOnGet = OnTakeFromPool;
		Action<GameObject> actionOnRelease2 = OnReturnedToPool;
		Action<GameObject> action3 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool2 = new ObjectPool<GameObject>(createFunc2, actionOnGet, actionOnRelease2, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		goldPool = objectPool2;
		Func<GameObject> createFunc3 = delegate
		{
			ObjectPool<GameObject> objectPool42 = silverPool;
			return (GameObject)((silverPool != null) ? ((object)((objectPool42._003CCountAll_003Ek__BackingField < MoneyFlying.maxMoneyObjects) ? UnityEngine.Object.Instantiate(silverPrefab) : null)) : ((object)new NullReferenceException()));
		};
		Action<GameObject> actionOnGet2 = OnTakeFromPool;
		Action<GameObject> actionOnRelease3 = OnReturnedToPool;
		Action<GameObject> action4 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool3 = new ObjectPool<GameObject>(createFunc3, actionOnGet2, actionOnRelease3, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		silverPool = objectPool3;
		Func<GameObject> createFunc4 = delegate
		{
			ObjectPool<GameObject> objectPool42 = enemyPool;
			return (GameObject)((enemyPool != null) ? ((object)((objectPool42._003CCountAll_003Ek__BackingField < EnemyManager.maxNumEnemiesPooled) ? UnityEngine.Object.Instantiate(enemyPrefab) : null)) : ((object)new NullReferenceException()));
		};
		Action<GameObject> actionOnGet3 = OnTakeFromPool;
		Action<GameObject> actionOnRelease4 = OnReturnedToPool;
		Action<GameObject> action5 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool4 = new ObjectPool<GameObject>(createFunc4, actionOnGet3, actionOnRelease4, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		enemyPool = objectPool4;
		Func<GameObject> createFunc5 = delegate
		{
			ObjectPool<GameObject> objectPool42 = enemySpawnFxPool;
			return (GameObject)((enemySpawnFxPool != null) ? ((object)((objectPool42._003CCountAll_003Ek__BackingField < 20) ? UnityEngine.Object.Instantiate(enemySpawnFxPrefab) : null)) : ((object)new NullReferenceException()));
		};
		Action<GameObject> actionOnGet4 = OnTakeFromPool;
		Action<GameObject> actionOnRelease5 = OnReturnedToPool;
		Action<GameObject> action6 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool5 = new ObjectPool<GameObject>(createFunc5, actionOnGet4, actionOnRelease5, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		enemySpawnFxPool = objectPool5;
		Func<GameObject> createFunc6 = delegate
		{
			ObjectPool<GameObject> objectPool42 = damageNumbersPool;
			return (GameObject)((damageNumbersPool != null) ? ((object)((objectPool42._003CCountAll_003Ek__BackingField < maxHitNumbers) ? UnityEngine.Object.Instantiate(damageNumbersPrefab) : null)) : ((object)new NullReferenceException()));
		};
		Action<GameObject> actionOnGet5 = OnTakeFromPool;
		Action<GameObject> actionOnRelease6 = OnReturnedToPool;
		Action<GameObject> action7 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool6 = new ObjectPool<GameObject>(createFunc6, actionOnGet5, actionOnRelease6, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		damageNumbersPool = objectPool6;
		Func<GameObject> createFunc7 = delegate
		{
			ObjectPool<GameObject> objectPool42 = pickupeffectPool;
			return (GameObject)((pickupeffectPool != null) ? ((object)((objectPool42._003CCountAll_003Ek__BackingField < 5) ? UnityEngine.Object.Instantiate(pickupEffectPrefab) : null)) : ((object)new NullReferenceException()));
		};
		Action<GameObject> actionOnGet6 = OnTakeFromPool;
		Action<GameObject> actionOnRelease7 = OnReturnedToPool;
		Action<GameObject> action8 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool7 = new ObjectPool<GameObject>(createFunc7, actionOnGet6, actionOnRelease7, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		pickupeffectPool = objectPool7;
		Func<GameObject> createFunc8 = () =>
		{
			float time = default(float);
			return CreatePooledItemTimeout(goldBurstPrefab, goldBurstPool, 10, time);
		};
		Action<GameObject> actionOnGet7 = OnTakeFromPool;
		Action<GameObject> actionOnRelease8 = OnReturnedToPool;
		Action<GameObject> action9 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool8 = new ObjectPool<GameObject>(createFunc8, actionOnGet7, actionOnRelease8, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		goldBurstPool = objectPool8;
		Func<GameObject> createFunc9 = () =>
		{
			float time = default(float);
			return CreatePooledItemTimeout(critEffectPrefab, critEffectPool, maxCritPrefabs, time);
		};
		Action<GameObject> actionOnGet8 = OnTakeFromPool;
		Action<GameObject> actionOnRelease9 = OnReturnedToPool;
		Action<GameObject> action10 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool9 = new ObjectPool<GameObject>(createFunc9, actionOnGet8, actionOnRelease9, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		critEffectPool = objectPool9;
		Func<GameObject> createFunc10 = delegate
		{
			ObjectPool<GameObject> objectPool42 = enemyStatusSymbolsPool;
			return (GameObject)((enemyStatusSymbolsPool != null) ? ((object)((objectPool42._003CCountAll_003Ek__BackingField < 100) ? UnityEngine.Object.Instantiate(enemyStatusSymbolsPrefab) : null)) : ((object)new NullReferenceException()));
		};
		Action<GameObject> actionOnGet9 = OnTakeFromPool;
		Action<GameObject> actionOnRelease10 = OnReturnedToPool;
		Action<GameObject> action11 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool10 = new ObjectPool<GameObject>(createFunc10, actionOnGet9, actionOnRelease10, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		enemyStatusSymbolsPool = objectPool10;
		Func<GameObject> createFunc11 = delegate
		{
			//IL_0014: Expected O, but got I4
			ObjectPool<GameObject> objectPool42 = powerupPool;
			if (powerupPool != null)
			{
				object obj = PickupManager.maxPowerupsOnMap + PickupManager.maxPowerupsOnMap;
				if (objectPool42._003CCountAll_003Ek__BackingField < (nint)obj)
				{
					return UnityEngine.Object.Instantiate(powerupPrefab);
				}
				return (GameObject)null;
			}
			return (GameObject)(object)new NullReferenceException();
		};
		Action<GameObject> actionOnGet10 = OnTakeFromPool;
		Action<GameObject> actionOnRelease11 = OnReturnedToPool;
		Action<GameObject> action12 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool11 = new ObjectPool<GameObject>(createFunc11, actionOnGet10, actionOnRelease11, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		powerupPool = objectPool11;
		Func<GameObject> createFunc12 = delegate
		{
			ObjectPool<GameObject> objectPool42 = warningTubePool;
			return (GameObject)((warningTubePool != null) ? ((object)((objectPool42._003CCountAll_003Ek__BackingField < maxWarningSpheres) ? UnityEngine.Object.Instantiate(warningTube) : null)) : ((object)new NullReferenceException()));
		};
		Action<GameObject> actionOnGet11 = OnTakeFromPool;
		Action<GameObject> actionOnRelease12 = OnReturnedToPool;
		Action<GameObject> action13 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool12 = new ObjectPool<GameObject>(createFunc12, actionOnGet11, actionOnRelease12, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		warningTubePool = objectPool12;
		Func<GameObject> createFunc13 = delegate
		{
			ObjectPool<GameObject> objectPool42 = warningSpherePool;
			return (GameObject)((warningSpherePool != null) ? ((object)((objectPool42._003CCountAll_003Ek__BackingField < maxWarningSpheres) ? UnityEngine.Object.Instantiate(warningSphere) : null)) : ((object)new NullReferenceException()));
		};
		Action<GameObject> actionOnGet12 = OnTakeFromPool;
		Action<GameObject> actionOnRelease13 = OnReturnedToPool;
		Action<GameObject> action14 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool13 = new ObjectPool<GameObject>(createFunc13, actionOnGet12, actionOnRelease13, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		warningSpherePool = objectPool13;
		Func<GameObject> createFunc14 = () =>
		{
			float time = default(float);
			return CreatePooledItemTimeout(lightningStrikePrefab, lightningStrikePool, maxLightningStrikes, time);
		};
		Action<GameObject> actionOnGet13 = OnTakeFromPool;
		Action<GameObject> actionOnRelease14 = OnReturnedToPool;
		Action<GameObject> action15 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool14 = new ObjectPool<GameObject>(createFunc14, actionOnGet13, actionOnRelease14, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		lightningStrikePool = objectPool14;
		Func<GameObject> createFunc15 = () =>
		{
			float time = default(float);
			return CreatePooledItemTimeout(chainLightningFx, chainLightningPool, maxLightningStrikes, time);
		};
		Action<GameObject> actionOnGet14 = OnTakeFromPool;
		Action<GameObject> actionOnRelease15 = OnReturnedToPool;
		Action<GameObject> action16 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool15 = new ObjectPool<GameObject>(createFunc15, actionOnGet14, actionOnRelease15, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		chainLightningPool = objectPool15;
		Func<GameObject> createFunc16 = delegate
		{
			ObjectPool<GameObject> objectPool42 = firefieldPool;
			return (GameObject)((firefieldPool != null) ? ((object)((objectPool42._003CCountAll_003Ek__BackingField < maxFirefields) ? UnityEngine.Object.Instantiate(firefield) : null)) : ((object)new NullReferenceException()));
		};
		Action<GameObject> actionOnGet15 = OnTakeFromPool;
		Action<GameObject> actionOnRelease16 = OnReturnedToPool;
		Action<GameObject> action17 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool16 = new ObjectPool<GameObject>(createFunc16, actionOnGet15, actionOnRelease16, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		firefieldPool = objectPool16;
		Func<GameObject> createFunc17 = () =>
		{
			float time = default(float);
			return CreatePooledItemTimeout(footstepPrefab, footstepPool, 10, time);
		};
		Action<GameObject> actionOnGet16 = OnTakeFromPool;
		Action<GameObject> actionOnRelease17 = OnReturnedToPool;
		Action<GameObject> action18 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool17 = new ObjectPool<GameObject>(createFunc17, actionOnGet16, actionOnRelease17, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		footstepPool = objectPool17;
		Func<GameObject> createFunc18 = delegate
		{
			ObjectPool<GameObject> objectPool42 = bullseyePool;
			return (GameObject)((bullseyePool != null) ? ((object)((objectPool42._003CCountAll_003Ek__BackingField < 20) ? UnityEngine.Object.Instantiate(bullseye) : null)) : ((object)new NullReferenceException()));
		};
		Action<GameObject> actionOnGet17 = OnTakeFromPool;
		Action<GameObject> actionOnRelease18 = OnReturnedToPool;
		Action<GameObject> action19 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool18 = new ObjectPool<GameObject>(createFunc18, actionOnGet17, actionOnRelease18, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		bullseyePool = objectPool18;
		Func<GameObject> createFunc19 = () =>
		{
			float time = default(float);
			return CreatePooledItemTimeout(poisonCloud, poisonPool, 20, time);
		};
		Action<GameObject> actionOnGet18 = OnTakeFromPool;
		Action<GameObject> actionOnRelease19 = OnReturnedToPool;
		Action<GameObject> action20 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool19 = new ObjectPool<GameObject>(createFunc19, actionOnGet18, actionOnRelease19, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		poisonPool = objectPool19;
		Func<GameObject> createFunc20 = () =>
		{
			float time = default(float);
			return CreatePooledItemTimeout(grandmaTonicFx, grandmaTonicPool, itemFxPoolSizes, time);
		};
		Action<GameObject> actionOnGet19 = OnTakeFromPool;
		Action<GameObject> actionOnRelease20 = OnReturnedToPool;
		Action<GameObject> action21 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool20 = new ObjectPool<GameObject>(createFunc20, actionOnGet19, actionOnRelease20, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		grandmaTonicPool = objectPool20;
		Func<GameObject> createFunc21 = () =>
		{
			float time = default(float);
			return CreatePooledItemTimeout(megaCritFx, megaCritPool, itemFxPoolSizes, time);
		};
		Action<GameObject> actionOnGet20 = OnTakeFromPool;
		Action<GameObject> actionOnRelease21 = OnReturnedToPool;
		Action<GameObject> action22 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool21 = new ObjectPool<GameObject>(createFunc21, actionOnGet20, actionOnRelease21, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		megaCritPool = objectPool21;
		Func<GameObject> createFunc22 = () =>
		{
			float time = default(float);
			return CreatePooledItemTimeout(executeFx, executePool, itemFxPoolSizes, time);
		};
		Action<GameObject> actionOnGet21 = OnTakeFromPool;
		Action<GameObject> actionOnRelease22 = OnReturnedToPool;
		Action<GameObject> action23 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool22 = new ObjectPool<GameObject>(createFunc22, actionOnGet21, actionOnRelease22, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		executePool = objectPool22;
		Func<GameObject> createFunc23 = () =>
		{
			float time = default(float);
			return CreatePooledItemTimeout(spicyMeatballFx, spicyMeatballPool, itemFxPoolSizes, time);
		};
		Action<GameObject> actionOnGet22 = OnTakeFromPool;
		Action<GameObject> actionOnRelease23 = OnReturnedToPool;
		Action<GameObject> action24 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool23 = new ObjectPool<GameObject>(createFunc23, actionOnGet22, actionOnRelease23, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		spicyMeatballPool = objectPool23;
		Func<GameObject> createFunc24 = () =>
		{
			float time = default(float);
			return CreatePooledItemTimeout(freezeFx, freezeFxPool, itemFxPoolSizes, time);
		};
		Action<GameObject> actionOnGet23 = OnTakeFromPool;
		Action<GameObject> actionOnRelease24 = OnReturnedToPool;
		Action<GameObject> action25 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool24 = new ObjectPool<GameObject>(createFunc24, actionOnGet23, actionOnRelease24, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		freezeFxPool = objectPool24;
		Func<GameObject> createFunc25 = delegate
		{
			ObjectPool<GameObject> objectPool42 = rocketPool;
			return (GameObject)((rocketPool != null) ? ((object)((objectPool42._003CCountAll_003Ek__BackingField < 200) ? UnityEngine.Object.Instantiate(rocket) : null)) : ((object)new NullReferenceException()));
		};
		Action<GameObject> actionOnGet24 = OnTakeFromPool;
		Action<GameObject> actionOnRelease25 = OnReturnedToPool;
		Action<GameObject> action26 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool25 = new ObjectPool<GameObject>(createFunc25, actionOnGet24, actionOnRelease25, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		rocketPool = objectPool25;
		Func<GameObject> createFunc26 = delegate
		{
			ObjectPool<GameObject> objectPool42 = orbPool;
			return (GameObject)((orbPool != null) ? ((object)((objectPool42._003CCountAll_003Ek__BackingField < orbPoolSize) ? UnityEngine.Object.Instantiate(orb) : null)) : ((object)new NullReferenceException()));
		};
		Action<GameObject> actionOnGet25 = OnTakeFromPool;
		Action<GameObject> actionOnRelease26 = OnReturnedToPool;
		Action<GameObject> action27 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool26 = new ObjectPool<GameObject>(createFunc26, actionOnGet25, actionOnRelease26, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		orbPool = objectPool26;
		Func<GameObject> createFunc27 = () =>
		{
			float time = default(float);
			return CreatePooledItemTimeout(explosionFx, explosionPool, explosionPoolSize, time);
		};
		Action<GameObject> actionOnGet26 = OnTakeFromPool;
		Action<GameObject> actionOnRelease27 = OnReturnedToPool;
		Action<GameObject> action28 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool27 = new ObjectPool<GameObject>(createFunc27, actionOnGet26, actionOnRelease27, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		explosionPool = objectPool27;
		Func<GameObject> createFunc28 = () =>
		{
			float time = default(float);
			return CreatePooledItemTimeout(bonkFx, bonkPool, maxBonkPrefabs, time);
		};
		Action<GameObject> actionOnGet27 = OnTakeFromPool;
		Action<GameObject> actionOnRelease28 = OnReturnedToPool;
		Action<GameObject> action29 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool28 = new ObjectPool<GameObject>(createFunc28, actionOnGet27, actionOnRelease28, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		bonkPool = objectPool28;
		Func<GameObject> createFunc29 = () =>
		{
			float time = default(float);
			return CreatePooledItemTimeout(bulletHit, bulletHitPool, maxBulletHitPrefabs, time);
		};
		Action<GameObject> actionOnGet28 = OnTakeFromPool;
		Action<GameObject> actionOnRelease29 = OnReturnedToPool;
		Action<GameObject> action30 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool29 = new ObjectPool<GameObject>(createFunc29, actionOnGet28, actionOnRelease29, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		bulletHitPool = objectPool29;
		Func<GameObject> createFunc30 = () =>
		{
			float time = default(float);
			return CreatePooledItemTimeout(cursedHit, cursedHitPool, cursedHitsPoolSize, time);
		};
		Action<GameObject> actionOnGet29 = OnTakeFromPool;
		Action<GameObject> actionOnRelease30 = OnReturnedToPool;
		Action<GameObject> action31 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool30 = new ObjectPool<GameObject>(createFunc30, actionOnGet29, actionOnRelease30, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		cursedHitPool = objectPool30;
		Func<GameObject> createFunc31 = delegate
		{
			ObjectPool<GameObject> objectPool42 = ghostPool;
			return (GameObject)((ghostPool != null) ? ((object)((objectPool42._003CCountAll_003Ek__BackingField < 180) ? UnityEngine.Object.Instantiate(ghost) : null)) : ((object)new NullReferenceException()));
		};
		Action<GameObject> actionOnGet30 = OnTakeFromPool;
		Action<GameObject> actionOnRelease31 = OnReturnedToPool;
		Action<GameObject> action32 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool31 = new ObjectPool<GameObject>(createFunc31, actionOnGet30, actionOnRelease31, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		ghostPool = objectPool31;
		Func<GameObject> createFunc32 = delegate
		{
			ObjectPool<GameObject> objectPool42 = angrySoulPool;
			return (GameObject)((angrySoulPool != null) ? ((object)((objectPool42._003CCountAll_003Ek__BackingField < 100) ? UnityEngine.Object.Instantiate(angrySoul) : null)) : ((object)new NullReferenceException()));
		};
		Action<GameObject> actionOnGet31 = OnTakeFromPool;
		Action<GameObject> actionOnRelease32 = OnReturnedToPool;
		Action<GameObject> action33 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool32 = new ObjectPool<GameObject>(createFunc32, actionOnGet31, actionOnRelease32, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		angrySoulPool = objectPool32;
		Func<GameObject> createFunc33 = () =>
		{
			float time = default(float);
			return CreatePooledItemTimeout(charmFx, charmPool, charmPoolSize, time);
		};
		Action<GameObject> actionOnGet32 = OnTakeFromPool;
		Action<GameObject> actionOnRelease33 = OnReturnedToPool;
		Action<GameObject> action34 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool33 = new ObjectPool<GameObject>(createFunc33, actionOnGet32, actionOnRelease33, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		charmPool = objectPool33;
		Func<GameObject> createFunc34 = delegate
		{
			ObjectPool<GameObject> objectPool42 = borgorPool;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18043BB80");
			object obj = default(object);
			return (GameObject)((borgorPool != null) ? ((object)((objectPool42._003CCountAll_003Ek__BackingField < (nint)obj) ? UnityEngine.Object.Instantiate(borgor) : null)) : ((object)new NullReferenceException()));
		};
		Action<GameObject> actionOnGet33 = OnTakeFromPool;
		Action<GameObject> actionOnRelease34 = OnReturnedToPool;
		Action<GameObject> action35 = OnDestroyPoolObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18043BB80");
		ObjectPool<GameObject> objectPool34 = new ObjectPool<GameObject>(createFunc34, actionOnGet33, actionOnRelease34, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		borgorPool = objectPool34;
		Func<GameObject> createFunc35 = () =>
		{
			float time = default(float);
			return CreatePooledItemTimeout(eat, eatPool, eatPoolSize, time);
		};
		Action<GameObject> actionOnGet34 = OnTakeFromPool;
		Action<GameObject> actionOnRelease35 = OnReturnedToPool;
		Action<GameObject> action36 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool35 = new ObjectPool<GameObject>(createFunc35, actionOnGet34, actionOnRelease35, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		eatPool = objectPool35;
		Func<GameObject> createFunc36 = () =>
		{
			float time = default(float);
			return CreatePooledItemTimeout(bloodmark, bloodmarkPool, maxBonkPrefabs, time);
		};
		Action<GameObject> actionOnGet35 = OnTakeFromPool;
		Action<GameObject> actionOnRelease36 = OnReturnedToPool;
		Action<GameObject> action37 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool36 = new ObjectPool<GameObject>(createFunc36, actionOnGet35, actionOnRelease36, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		bloodmarkPool = objectPool36;
		Func<GameObject> createFunc37 = () =>
		{
			float time = default(float);
			return CreatePooledItemTimeout(cactusFx, cactusPool, maxBonkPrefabs, time);
		};
		Action<GameObject> actionOnGet36 = OnTakeFromPool;
		Action<GameObject> actionOnRelease37 = OnReturnedToPool;
		Action<GameObject> action38 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool37 = new ObjectPool<GameObject>(createFunc37, actionOnGet36, actionOnRelease37, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		cactusPool = objectPool37;
		Func<GameObject> createFunc38 = () =>
		{
			float time = default(float);
			return CreatePooledItemTimeout(tumbleweedBreak, tumbleweedBreakPool, maxBonkPrefabs, time);
		};
		Action<GameObject> actionOnGet37 = OnTakeFromPool;
		Action<GameObject> actionOnRelease38 = OnReturnedToPool;
		Action<GameObject> action39 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool38 = new ObjectPool<GameObject>(createFunc38, actionOnGet37, actionOnRelease38, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		tumbleweedBreakPool = objectPool38;
		Func<GameObject> createFunc39 = delegate
		{
			ObjectPool<GameObject> objectPool42 = tumbleweedPool;
			return (GameObject)((tumbleweedPool != null) ? ((object)((objectPool42._003CCountAll_003Ek__BackingField < 25) ? UnityEngine.Object.Instantiate(tumbleweed) : null)) : ((object)new NullReferenceException()));
		};
		Action<GameObject> actionOnGet38 = OnTakeFromPool;
		Action<GameObject> actionOnRelease39 = OnReturnedToPool;
		Action<GameObject> action40 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool39 = new ObjectPool<GameObject>(createFunc39, actionOnGet38, actionOnRelease39, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		tumbleweedPool = objectPool39;
		Func<GameObject> createFunc40 = () =>
		{
			float time = default(float);
			return CreatePooledItemTimeout(quinMaskFx, quinMaskPool, itemFxPoolSizes, time);
		};
		Action<GameObject> actionOnGet39 = OnTakeFromPool;
		Action<GameObject> actionOnRelease40 = OnReturnedToPool;
		Action<GameObject> action41 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool40 = new ObjectPool<GameObject>(createFunc40, actionOnGet39, actionOnRelease40, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		quinMaskPool = objectPool40;
		Func<GameObject> createFunc41 = () =>
		{
			float time = default(float);
			return CreatePooledItemTimeout(snekFx, snekPool, itemFxPoolSizes, time);
		};
		Action<GameObject> actionOnGet40 = OnTakeFromPool;
		Action<GameObject> actionOnRelease41 = OnReturnedToPool;
		Action<GameObject> action42 = OnDestroyPoolObject;
		ObjectPool<GameObject> objectPool41 = new ObjectPool<GameObject>(createFunc41, actionOnGet40, actionOnRelease41, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
		snekPool = objectPool41;
	}

	public DamageNumbers GetDamageNumber()
	{
		if (damageNumbersPool != null)
		{
			GameObject gameObject = damageNumbersPool.Get();
			if (!(gameObject != null))
			{
				return null;
			}
			if ((object)gameObject != null)
			{
				Transform transform = gameObject.transform;
				if ((object)transform != null)
				{
					Transform parent = transform.parent;
					if (parent == null)
					{
						Transform transform2 = gameObject.transform;
						if ((object)transform2 == null)
						{
							goto IL_01b0;
						}
						transform2.parentInternal = damageNumbersParent;
					}
					if (damageNumbersDict != null)
					{
						if (!damageNumbersDict.ContainsKey(gameObject))
						{
							DamageNumbers component = gameObject.GetComponent<DamageNumbers>();
							if (damageNumbersDict == null)
							{
								goto IL_01b0;
							}
							((Dictionary<object, object>)(object)damageNumbersDict).set_Item((object)gameObject, (object)component);
						}
						if (damageNumbersDict != null)
						{
							return damageNumbersDict.get_Item(gameObject);
						}
					}
				}
			}
		}
		goto IL_01b0;
		IL_01b0:
		return (DamageNumbers)(object)new NullReferenceException();
	}

	public WeaponAttack GetAttack(WeaponBase weaponBase)
	{
		WeaponData weaponData;
		if (weaponBase != null)
		{
			weaponData = weaponBase.weaponData;
			if ((object)weaponBase.weaponData != null && weaponAttackPools != null)
			{
				if (((Dictionary<System.Int32Enum, object>)(object)weaponAttackPools).ContainsKey((System.Int32Enum)weaponData.eWeapon))
				{
					goto IL_0139;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180435740");
				WeaponData weaponData2 = weaponBase.weaponData;
				if ((object)weaponBase.weaponData != null)
				{
					int maxObjects = default(int);
					ObjectPool<GameObject> value = CreateObjectPool(weaponData2.attack, maxObjects);
					WeaponData weaponData3 = weaponBase.weaponData;
					if ((object)weaponBase.weaponData != null && weaponAttackPools != null)
					{
						((Dictionary<System.Int32Enum, object>)(object)weaponAttackPools).Add((System.Int32Enum)weaponData3.eWeapon, (object)value);
						goto IL_0139;
					}
				}
			}
		}
		goto IL_0297;
		IL_025e:
		ObjectPool<GameObject> objectPool;
		if (weaponAttacksDict != null)
		{
			return weaponAttacksDict.get_Item((GameObject)(object)objectPool);
		}
		goto IL_0297;
		IL_0139:
		if (weaponAttackPools != null)
		{
			object obj = ((Dictionary<System.Int32Enum, object>)(object)weaponAttackPools).get_Item((System.Int32Enum)weaponData.eWeapon);
			if (obj != null)
			{
				objectPool = ((Dictionary<EWeapon, ObjectPool<GameObject>>)obj).get_Item(EWeapon.FireStaff);
				if (!((UnityEngine.Object)(object)objectPool != null))
				{
					return null;
				}
				if (weaponAttacksDict != null)
				{
					if (weaponAttacksDict.ContainsKey((GameObject)(object)objectPool))
					{
						goto IL_025e;
					}
					if (objectPool != null)
					{
						WeaponAttack component = ((GameObject)(object)objectPool).GetComponent<WeaponAttack>();
						if (weaponAttacksDict != null)
						{
							((Dictionary<object, object>)(object)weaponAttacksDict).set_Item((object)objectPool, (object)component);
							goto IL_025e;
						}
					}
				}
			}
		}
		goto IL_0297;
		IL_0297:
		return (WeaponAttack)(object)new NullReferenceException();
	}

	public void ReturnAttack(WeaponAttack weaponAttack)
	{
		GameObject gameObject = weaponAttack.gameObject;
		gameObject.SetActive(value: false);
		WeaponBase weaponBase = weaponAttack.weaponBase;
		WeaponData weaponData = weaponBase.weaponData;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)weaponAttackPools).get_Item((System.Int32Enum)weaponData.eWeapon);
		GameObject element = weaponAttack.gameObject;
		((ObjectPool<GameObject>)obj).Release(element);
	}

	public ProjectileBase GetProjectile(WeaponAttack weaponAttack)
	{
		WeaponData weaponData;
		if ((object)weaponAttack != null)
		{
			WeaponBase weaponBase = weaponAttack.weaponBase;
			if (weaponAttack.weaponBase != null)
			{
				weaponData = weaponBase.weaponData;
				if ((object)weaponBase.weaponData != null && projectilePools != null)
				{
					if (((Dictionary<System.Int32Enum, object>)(object)projectilePools).ContainsKey((System.Int32Enum)weaponData.eWeapon))
					{
						goto IL_0175;
					}
					int maxProjectilesPoolSize = WeaponUtility.GetMaxProjectilesPoolSize(weaponData.eWeapon);
					ObjectPool<GameObject> value = CreateObjectPool(weaponAttack.prefabProjectile, maxProjectilesPoolSize);
					WeaponBase weaponBase2 = weaponAttack.weaponBase;
					if (weaponAttack.weaponBase != null)
					{
						WeaponData weaponData2 = weaponBase2.weaponData;
						if ((object)weaponBase2.weaponData != null && projectilePools != null)
						{
							((Dictionary<System.Int32Enum, object>)(object)projectilePools).Add((System.Int32Enum)weaponData2.eWeapon, (object)value);
							goto IL_0175;
						}
					}
				}
			}
		}
		goto IL_02d3;
		IL_02d3:
		return (ProjectileBase)(object)new NullReferenceException();
		IL_029a:
		ObjectPool<GameObject> objectPool;
		if (projectileDict != null)
		{
			return projectileDict.get_Item((GameObject)(object)objectPool);
		}
		goto IL_02d3;
		IL_0175:
		if (projectilePools != null)
		{
			object obj = ((Dictionary<System.Int32Enum, object>)(object)projectilePools).get_Item((System.Int32Enum)weaponData.eWeapon);
			if (obj != null)
			{
				objectPool = ((Dictionary<EWeapon, ObjectPool<GameObject>>)obj).get_Item(EWeapon.FireStaff);
				if (!((UnityEngine.Object)(object)objectPool != null))
				{
					return null;
				}
				if (projectileDict != null)
				{
					if (projectileDict.ContainsKey((GameObject)(object)objectPool))
					{
						goto IL_029a;
					}
					if (objectPool != null)
					{
						ProjectileBase component = ((GameObject)(object)objectPool).GetComponent<ProjectileBase>();
						if (projectileDict != null)
						{
							((Dictionary<object, object>)(object)projectileDict).set_Item((object)objectPool, (object)component);
							goto IL_029a;
						}
					}
				}
			}
		}
		goto IL_02d3;
	}

	public void ReturnProjectile(WeaponAttack weaponAttack, GameObject projectile)
	{
		projectile.SetActive(value: false);
		WeaponBase weaponBase = weaponAttack.weaponBase;
		WeaponData weaponData = weaponBase.weaponData;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)projectilePools).get_Item((System.Int32Enum)weaponData.eWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003260");
	}

	public AttackHit GetProjectileHit(string source, GameObject hitPrefab)
	{
		//IL_0108: Expected O, but got I
		bool flag = hitPrefab == null;
		bool flag2 = !flag;
		GameObject hitPrefabToUse = hitPrefab;
		if (!flag2)
		{
			hitPrefabToUse = defaultHitPrefab;
		}
		ObjectPool<GameObject> objectPool2;
		if (projectileHitPools != null)
		{
			if (!projectileHitPools.ContainsKey(source))
			{
				ObjectPool<GameObject> value = CreateObjectPool(hitPrefabToUse, 20);
				if (projectileHitPools == null)
				{
					goto IL_0207;
				}
				((Dictionary<object, object>)(object)projectileHitPools).Add((object)source, (object)value);
			}
			if (projectileHitPools != null)
			{
				ObjectPool<GameObject> objectPool = projectileHitPools.get_Item(source);
				if (objectPool != null)
				{
					objectPool2 = ((Dictionary<string, ObjectPool<GameObject>>)(object)objectPool).get_Item((string)0);
					if (!((UnityEngine.Object)(object)objectPool2 != null))
					{
						return null;
					}
					if (attackHitsDict != null)
					{
						if (attackHitsDict.ContainsKey((GameObject)(object)objectPool2))
						{
							goto IL_01ce;
						}
						if (objectPool2 != null)
						{
							AttackHit component = ((GameObject)(object)objectPool2).GetComponent<AttackHit>();
							if (attackHitsDict != null)
							{
								((Dictionary<object, object>)(object)attackHitsDict).set_Item((object)objectPool2, (object)component);
								goto IL_01ce;
							}
						}
					}
				}
			}
		}
		goto IL_0207;
		IL_0207:
		return (AttackHit)(object)new NullReferenceException();
		IL_01ce:
		if (attackHitsDict != null)
		{
			return attackHitsDict.get_Item((GameObject)(object)objectPool2);
		}
		goto IL_0207;
	}

	public unsafe GameObject GetProjectileDoneFx(EWeapon eWeapon, GameObject hitPrefab)
	{
		//IL_002f: Expected O, but got Ref
		//IL_0117: Expected O, but got I
		if (!((Dictionary<System.Int32Enum, object>)(object)weaponStrings).ContainsKey((System.Int32Enum)eWeapon))
		{
			object obj = default(object);
			string value = ((Enum)(&obj)).ToString();
			if (weaponStrings == null)
			{
				return (GameObject)(object)new NullReferenceException();
			}
			((Dictionary<System.Int32Enum, object>)(object)weaponStrings).Add((System.Int32Enum)eWeapon, (object)value);
		}
		object key = ((Dictionary<System.Int32Enum, object>)(object)weaponStrings).get_Item((System.Int32Enum)eWeapon);
		if (hitPrefab != null)
		{
			if (!projectileDonePools.ContainsKey((string)key))
			{
				ObjectPool<GameObject> value2 = CreateObjectPoolTimeout(hitPrefab, 10, 0.5f);
				((Dictionary<object, object>)(object)projectileDonePools).Add(key, (object)value2);
			}
			ObjectPool<GameObject> objectPool = projectileDonePools.get_Item((string)key);
			return (GameObject)(object)((Dictionary<string, ObjectPool<GameObject>>)(object)objectPool).get_Item((string)0);
		}
		return null;
	}

	public GameObject GetProjectileDoneFx(string source, GameObject hitPrefab)
	{
		//IL_010a: Expected O, but got I
		if (hitPrefab != null)
		{
			if (projectileDonePools != null)
			{
				if (!projectileDonePools.ContainsKey(source))
				{
					ObjectPool<GameObject> value = CreateObjectPoolTimeout(hitPrefab, 10, 0.5f);
					if (projectileDonePools == null)
					{
						goto IL_0115;
					}
					((Dictionary<object, object>)(object)projectileDonePools).Add((object)source, (object)value);
				}
				if (projectileDonePools != null)
				{
					ObjectPool<GameObject> objectPool = projectileDonePools.get_Item(source);
					if (objectPool != null)
					{
						return (GameObject)(object)((Dictionary<string, ObjectPool<GameObject>>)(object)objectPool).get_Item((string)0);
					}
				}
			}
			goto IL_0115;
		}
		return null;
		IL_0115:
		return (GameObject)(object)new NullReferenceException();
	}

	private ObjectPool<GameObject> CreateObjectPool(GameObject hitPrefabToUse, int maxObjects)
	{
		_003C_003Ec__DisplayClass121_0 CS_0024_003C_003E8__locals12 = new _003C_003Ec__DisplayClass121_0();
		if (CS_0024_003C_003E8__locals12 != null)
		{
			CS_0024_003C_003E8__locals12._003C_003E4__this = this;
			CS_0024_003C_003E8__locals12.hitPrefabToUse = hitPrefabToUse;
			CS_0024_003C_003E8__locals12.maxObjects = maxObjects;
			CS_0024_003C_003E8__locals12.newPool = null;
			Func<GameObject> createFunc = () => (GameObject)(((object)CS_0024_003C_003E8__locals12._003C_003E4__this != null) ? ((object)CS_0024_003C_003E8__locals12._003C_003E4__this.CreatePooledItem(CS_0024_003C_003E8__locals12.hitPrefabToUse, CS_0024_003C_003E8__locals12.newPool, CS_0024_003C_003E8__locals12.maxObjects)) : ((object)new NullReferenceException()));
			Action<GameObject> actionOnGet = OnTakeFromPool;
			Action<GameObject> actionOnRelease = OnReturnedToPool;
			Action<GameObject> action = OnDestroyPoolObject;
			Action<GameObject> actionOnDestroy = default(Action<GameObject>);
			bool collectionCheck = default(bool);
			int defaultCapacity = default(int);
			int maxSize = default(int);
			ObjectPool<GameObject> newPool = new ObjectPool<GameObject>(createFunc, actionOnGet, actionOnRelease, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
			CS_0024_003C_003E8__locals12.newPool = newPool;
			return CS_0024_003C_003E8__locals12.newPool;
		}
		return (ObjectPool<GameObject>)(object)new NullReferenceException();
	}

	private ObjectPool<GameObject> CreateObjectPoolTimeout(GameObject hitPrefabToUse, int maxObjects, float timeoutTime)
	{
		_003C_003Ec__DisplayClass122_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass122_0();
		if (CS_0024_003C_003E8__locals13 != null)
		{
			CS_0024_003C_003E8__locals13._003C_003E4__this = this;
			CS_0024_003C_003E8__locals13.hitPrefabToUse = hitPrefabToUse;
			CS_0024_003C_003E8__locals13.timeoutTime = timeoutTime;
			CS_0024_003C_003E8__locals13.maxObjects = maxObjects;
			CS_0024_003C_003E8__locals13.newPool = null;
			Func<GameObject> createFunc = () =>
			{
				float time = default(float);
				return (GameObject)(((object)CS_0024_003C_003E8__locals13._003C_003E4__this != null) ? ((object)CS_0024_003C_003E8__locals13._003C_003E4__this.CreatePooledItemTimeout(CS_0024_003C_003E8__locals13.hitPrefabToUse, CS_0024_003C_003E8__locals13.newPool, CS_0024_003C_003E8__locals13.maxObjects, time)) : ((object)new NullReferenceException()));
			};
			Action<GameObject> actionOnGet = OnTakeFromPool;
			Action<GameObject> actionOnRelease = OnReturnedToPool;
			Action<GameObject> action = OnDestroyPoolObject;
			Action<GameObject> actionOnDestroy = default(Action<GameObject>);
			bool collectionCheck = default(bool);
			int defaultCapacity = default(int);
			int maxSize = default(int);
			ObjectPool<GameObject> newPool = new ObjectPool<GameObject>(createFunc, actionOnGet, actionOnRelease, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
			CS_0024_003C_003E8__locals13.newPool = newPool;
			return CS_0024_003C_003E8__locals13.newPool;
		}
		return (ObjectPool<GameObject>)(object)new NullReferenceException();
	}

	public GameObject GetEnemyAttack(EnemySpecialAttack specialAttack)
	{
		//IL_02bc: Expected O, but got I
		_003C_003Ec__DisplayClass123_0 CS_0024_003C_003E8__locals21 = new _003C_003Ec__DisplayClass123_0();
		if (CS_0024_003C_003E8__locals21 != null)
		{
			CS_0024_003C_003E8__locals21._003C_003E4__this = this;
			CS_0024_003C_003E8__locals21.specialAttack = specialAttack;
			EnemySpecialAttack specialAttack2 = CS_0024_003C_003E8__locals21.specialAttack;
			if (CS_0024_003C_003E8__locals21.specialAttack != null)
			{
				if (string.IsNullOrEmpty(specialAttack2.attackName))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				}
				EnemySpecialAttack specialAttack3 = CS_0024_003C_003E8__locals21.specialAttack;
				if (CS_0024_003C_003E8__locals21.specialAttack != null && enemyAttacksPools != null)
				{
					bool flag = enemyAttacksPools.ContainsKey(specialAttack3.attackName);
					PoolManager poolManager = this;
					if (!flag)
					{
						CS_0024_003C_003E8__locals21.maxObjects = 1024;
						CS_0024_003C_003E8__locals21.newPool = null;
						Func<GameObject> createFunc = delegate
						{
							EnemySpecialAttack specialAttack6 = CS_0024_003C_003E8__locals21.specialAttack;
							return (GameObject)((CS_0024_003C_003E8__locals21.specialAttack != null && (object)CS_0024_003C_003E8__locals21._003C_003E4__this != null) ? ((object)CS_0024_003C_003E8__locals21._003C_003E4__this.CreatePooledItem(specialAttack6.attackPrefab, CS_0024_003C_003E8__locals21.newPool, CS_0024_003C_003E8__locals21.maxObjects)) : ((object)new NullReferenceException()));
						};
						Action<GameObject> actionOnGet = OnTakeFromPool;
						Action<GameObject> actionOnRelease = OnReturnedToPool;
						Action<GameObject> action = OnDestroyPoolObject;
						Action<GameObject> actionOnDestroy = default(Action<GameObject>);
						bool collectionCheck = default(bool);
						int defaultCapacity = default(int);
						int maxSize = default(int);
						ObjectPool<GameObject> newPool = new ObjectPool<GameObject>(createFunc, actionOnGet, actionOnRelease, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
						CS_0024_003C_003E8__locals21.newPool = newPool;
						EnemySpecialAttack specialAttack4 = CS_0024_003C_003E8__locals21.specialAttack;
						if (CS_0024_003C_003E8__locals21.specialAttack == null || enemyAttacksPools == null)
						{
							goto IL_0313;
						}
						((Dictionary<object, object>)(object)enemyAttacksPools).Add((object)specialAttack4.attackName, (object)CS_0024_003C_003E8__locals21.newPool);
						poolManager = this;
					}
					EnemySpecialAttack specialAttack5 = CS_0024_003C_003E8__locals21.specialAttack;
					if (CS_0024_003C_003E8__locals21.specialAttack != null && poolManager.enemyAttacksPools != null)
					{
						ObjectPool<GameObject> objectPool = poolManager.enemyAttacksPools.get_Item(specialAttack5.attackName);
						if (objectPool != null)
						{
							ObjectPool<GameObject> objectPool2 = ((Dictionary<string, ObjectPool<GameObject>>)(object)objectPool).get_Item((string)0);
							if (!((UnityEngine.Object)(object)objectPool2 != null))
							{
								return null;
							}
							if (objectPool2 != null)
							{
								((GameObject)(object)objectPool2).SetActive(true);
								return (GameObject)(object)objectPool2;
							}
						}
					}
				}
			}
		}
		goto IL_0313;
		IL_0313:
		return (GameObject)(object)new NullReferenceException();
	}

	public GameObject GetEnemyAttackFx(EnemySpecialAttackPrefab enemyAttackPrefab)
	{
		_003C_003Ec__DisplayClass124_0 CS_0024_003C_003E8__locals15 = new _003C_003Ec__DisplayClass124_0();
		if (CS_0024_003C_003E8__locals15 != null)
		{
			CS_0024_003C_003E8__locals15._003C_003E4__this = this;
			CS_0024_003C_003E8__locals15.enemyAttackPrefab = enemyAttackPrefab;
			EnemySpecialAttackPrefab enemyAttackPrefab2 = CS_0024_003C_003E8__locals15.enemyAttackPrefab;
			if ((object)CS_0024_003C_003E8__locals15.enemyAttackPrefab != null && enemyAttacksFxPools != null)
			{
				bool flag = ((Dictionary<System.Int32Enum, object>)(object)enemyAttacksFxPools).ContainsKey((System.Int32Enum)enemyAttackPrefab2.eAttack);
				PoolManager poolManager = this;
				if (!flag)
				{
					CS_0024_003C_003E8__locals15.maxObjects = 256;
					CS_0024_003C_003E8__locals15.newPool = null;
					Func<GameObject> createFunc = delegate
					{
						EnemySpecialAttackPrefab enemyAttackPrefab3 = CS_0024_003C_003E8__locals15.enemyAttackPrefab;
						return (GameObject)(((object)CS_0024_003C_003E8__locals15.enemyAttackPrefab != null && (object)CS_0024_003C_003E8__locals15._003C_003E4__this != null) ? ((object)CS_0024_003C_003E8__locals15._003C_003E4__this.CreatePooledItem(enemyAttackPrefab3.attackEffectPrefab, CS_0024_003C_003E8__locals15.newPool, CS_0024_003C_003E8__locals15.maxObjects)) : ((object)new NullReferenceException()));
					};
					Action<GameObject> actionOnGet = OnTakeFromPool;
					Action<GameObject> actionOnRelease = OnReturnedToPool;
					Action<GameObject> action = OnDestroyPoolObject;
					Action<GameObject> actionOnDestroy = default(Action<GameObject>);
					bool collectionCheck = default(bool);
					int defaultCapacity = default(int);
					int maxSize = default(int);
					ObjectPool<GameObject> newPool = new ObjectPool<GameObject>(createFunc, actionOnGet, actionOnRelease, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
					CS_0024_003C_003E8__locals15.newPool = newPool;
					if (enemyAttacksFxPools == null)
					{
						goto IL_024c;
					}
					((Dictionary<System.Int32Enum, object>)(object)enemyAttacksFxPools).Add((System.Int32Enum)enemyAttackPrefab2.eAttack, (object)CS_0024_003C_003E8__locals15.newPool);
					poolManager = this;
				}
				if (poolManager.enemyAttacksFxPools != null)
				{
					object obj = ((Dictionary<System.Int32Enum, object>)(object)poolManager.enemyAttacksFxPools).get_Item((System.Int32Enum)enemyAttackPrefab2.eAttack);
					if (obj != null)
					{
						ObjectPool<GameObject> objectPool = ((Dictionary<EEnemyAttack, ObjectPool<GameObject>>)obj).get_Item(EEnemyAttack.RootSpikes);
						if (!((UnityEngine.Object)(object)objectPool != null))
						{
							return null;
						}
						if (objectPool != null)
						{
							((GameObject)(object)objectPool).SetActive(true);
							return (GameObject)(object)objectPool;
						}
					}
				}
			}
		}
		goto IL_024c;
		IL_024c:
		return (GameObject)(object)new NullReferenceException();
	}

	public void ReturnEnemyAttackFx(EnemyAttackEffectPrefab attackPrefab)
	{
		GameObject gameObject = attackPrefab.gameObject;
		gameObject.SetActive(value: false);
		object obj = ((Dictionary<System.Int32Enum, object>)(object)enemyAttacksFxPools).get_Item((System.Int32Enum)attackPrefab.eAttack);
		GameObject element = attackPrefab.gameObject;
		((ObjectPool<GameObject>)obj).Release(element);
	}

	public void ReturnEnemyAttack(EnemySpecialAttackPrefab specialAttackPrefab)
	{
		GameObject gameObject = specialAttackPrefab.gameObject;
		gameObject.SetActive(value: false);
		EnemySpecialAttack enemySpecialAttack = specialAttackPrefab._003CspecialAttack_003Ek__BackingField;
		ObjectPool<GameObject> objectPool = enemyAttacksPools.get_Item(enemySpecialAttack.attackName);
		GameObject element = specialAttackPrefab.gameObject;
		objectPool.Release(element);
	}

	private GameObject CreatePooledItem(GameObject prefab, ObjectPool<GameObject> pool, int maxSize)
	{
		if (pool != null)
		{
			if (pool._003CCountAll_003Ek__BackingField < maxSize)
			{
				return UnityEngine.Object.Instantiate(prefab);
			}
			return null;
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private GameObject CreatePooledItemTimeout(GameObject prefab, ObjectPool<GameObject> pool, int maxSize, float time)
	{
		if (pool != null)
		{
			if (pool._003CCountAll_003Ek__BackingField >= maxSize)
			{
				return null;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(prefab);
			if ((object)gameObject != null)
			{
				ReturnToPool component = gameObject.GetComponent<ReturnToPool>();
				bool flag = component == null;
				bool flag2 = !flag;
				ReturnToPool returnToPool = component;
				if (!flag2)
				{
					ReturnToPool returnToPool2 = gameObject.AddComponent<ReturnToPool>();
					returnToPool = returnToPool2;
				}
				if ((object)returnToPool != null)
				{
					float timeout = default(float);
					returnToPool.SetTime(timeout, pool);
					return gameObject;
				}
			}
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private void OnReturnedToPool(GameObject obj)
	{
		obj.SetActive(value: false);
	}

	private void OnTakeFromPool(GameObject obj)
	{
		if (obj != null)
		{
			obj.SetActive(value: true);
		}
	}

	private void OnDestroyPoolObject(GameObject obj)
	{
		UnityEngine.Object.Destroy(obj);
	}

	public PoolManager()
	{
		Dictionary<EWeapon, ObjectPool<GameObject>> dictionary = new Dictionary<EWeapon, ObjectPool<GameObject>>();
		weaponAttackPools = dictionary;
		projectilePools = new Dictionary<EWeapon, ObjectPool<GameObject>>();
		projectileDonePools = new Dictionary<string, ObjectPool<GameObject>>();
		projectileHitPools = new Dictionary<string, ObjectPool<GameObject>>();
		enemyAttacksPools = new Dictionary<string, ObjectPool<GameObject>>();
		enemyAttacksFxPools = new Dictionary<EEnemyAttack, ObjectPool<GameObject>>();
		itemFxPoolSizes = 20;
		weaponAttacksDict = new Dictionary<GameObject, WeaponAttack>();
		projectileDict = new Dictionary<GameObject, ProjectileBase>();
		damageNumbersDict = new Dictionary<GameObject, DamageNumbers>();
		attackHitsDict = new Dictionary<GameObject, AttackHit>();
		weaponStrings = new Dictionary<EWeapon, string>();
		base._002Ector();
	}

	private GameObject _003CStart_003Eb__107_0()
	{
		ObjectPool<GameObject> objectPool = xpPool;
		if (xpPool != null)
		{
			if (objectPool._003CCountAll_003Ek__BackingField < PickupManager.maxXpObjects)
			{
				return UnityEngine.Object.Instantiate(xpPrefab);
			}
			return null;
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private GameObject _003CStart_003Eb__107_1()
	{
		ObjectPool<GameObject> objectPool = goldPool;
		if (goldPool != null)
		{
			if (objectPool._003CCountAll_003Ek__BackingField < MoneyFlying.maxMoneyObjects)
			{
				return UnityEngine.Object.Instantiate(goldPrefab);
			}
			return null;
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private GameObject _003CStart_003Eb__107_2()
	{
		ObjectPool<GameObject> objectPool = silverPool;
		if (silverPool != null)
		{
			if (objectPool._003CCountAll_003Ek__BackingField < MoneyFlying.maxMoneyObjects)
			{
				return UnityEngine.Object.Instantiate(silverPrefab);
			}
			return null;
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private GameObject _003CStart_003Eb__107_3()
	{
		ObjectPool<GameObject> objectPool = enemyPool;
		if (enemyPool != null)
		{
			if (objectPool._003CCountAll_003Ek__BackingField < EnemyManager.maxNumEnemiesPooled)
			{
				return UnityEngine.Object.Instantiate(enemyPrefab);
			}
			return null;
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private GameObject _003CStart_003Eb__107_4()
	{
		ObjectPool<GameObject> objectPool = enemySpawnFxPool;
		if (enemySpawnFxPool != null)
		{
			if (objectPool._003CCountAll_003Ek__BackingField < 20)
			{
				return UnityEngine.Object.Instantiate(enemySpawnFxPrefab);
			}
			return null;
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private GameObject _003CStart_003Eb__107_5()
	{
		ObjectPool<GameObject> objectPool = damageNumbersPool;
		if (damageNumbersPool != null)
		{
			if (objectPool._003CCountAll_003Ek__BackingField < maxHitNumbers)
			{
				return UnityEngine.Object.Instantiate(damageNumbersPrefab);
			}
			return null;
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private GameObject _003CStart_003Eb__107_6()
	{
		ObjectPool<GameObject> objectPool = pickupeffectPool;
		if (pickupeffectPool != null)
		{
			if (objectPool._003CCountAll_003Ek__BackingField < 5)
			{
				return UnityEngine.Object.Instantiate(pickupEffectPrefab);
			}
			return null;
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private GameObject _003CStart_003Eb__107_7()
	{
		float time = default(float);
		return CreatePooledItemTimeout(goldBurstPrefab, goldBurstPool, 10, time);
	}

	private GameObject _003CStart_003Eb__107_8()
	{
		float time = default(float);
		return CreatePooledItemTimeout(critEffectPrefab, critEffectPool, maxCritPrefabs, time);
	}

	private GameObject _003CStart_003Eb__107_9()
	{
		ObjectPool<GameObject> objectPool = enemyStatusSymbolsPool;
		if (enemyStatusSymbolsPool != null)
		{
			if (objectPool._003CCountAll_003Ek__BackingField < 100)
			{
				return UnityEngine.Object.Instantiate(enemyStatusSymbolsPrefab);
			}
			return null;
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private GameObject _003CStart_003Eb__107_10()
	{
		//IL_0014: Expected O, but got I4
		ObjectPool<GameObject> objectPool = powerupPool;
		if (powerupPool != null)
		{
			object obj = PickupManager.maxPowerupsOnMap + PickupManager.maxPowerupsOnMap;
			if (objectPool._003CCountAll_003Ek__BackingField < (nint)obj)
			{
				return UnityEngine.Object.Instantiate(powerupPrefab);
			}
			return null;
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private GameObject _003CStart_003Eb__107_11()
	{
		ObjectPool<GameObject> objectPool = warningTubePool;
		if (warningTubePool != null)
		{
			if (objectPool._003CCountAll_003Ek__BackingField < maxWarningSpheres)
			{
				return UnityEngine.Object.Instantiate(warningTube);
			}
			return null;
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private GameObject _003CStart_003Eb__107_12()
	{
		ObjectPool<GameObject> objectPool = warningSpherePool;
		if (warningSpherePool != null)
		{
			if (objectPool._003CCountAll_003Ek__BackingField < maxWarningSpheres)
			{
				return UnityEngine.Object.Instantiate(warningSphere);
			}
			return null;
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private GameObject _003CStart_003Eb__107_13()
	{
		float time = default(float);
		return CreatePooledItemTimeout(lightningStrikePrefab, lightningStrikePool, maxLightningStrikes, time);
	}

	private GameObject _003CStart_003Eb__107_14()
	{
		float time = default(float);
		return CreatePooledItemTimeout(chainLightningFx, chainLightningPool, maxLightningStrikes, time);
	}

	private GameObject _003CStart_003Eb__107_15()
	{
		ObjectPool<GameObject> objectPool = firefieldPool;
		if (firefieldPool != null)
		{
			if (objectPool._003CCountAll_003Ek__BackingField < maxFirefields)
			{
				return UnityEngine.Object.Instantiate(firefield);
			}
			return null;
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private GameObject _003CStart_003Eb__107_16()
	{
		float time = default(float);
		return CreatePooledItemTimeout(footstepPrefab, footstepPool, 10, time);
	}

	private GameObject _003CStart_003Eb__107_17()
	{
		ObjectPool<GameObject> objectPool = bullseyePool;
		if (bullseyePool != null)
		{
			if (objectPool._003CCountAll_003Ek__BackingField < 20)
			{
				return UnityEngine.Object.Instantiate(bullseye);
			}
			return null;
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private GameObject _003CStart_003Eb__107_18()
	{
		float time = default(float);
		return CreatePooledItemTimeout(poisonCloud, poisonPool, 20, time);
	}

	private GameObject _003CStart_003Eb__107_19()
	{
		float time = default(float);
		return CreatePooledItemTimeout(grandmaTonicFx, grandmaTonicPool, itemFxPoolSizes, time);
	}

	private GameObject _003CStart_003Eb__107_20()
	{
		float time = default(float);
		return CreatePooledItemTimeout(megaCritFx, megaCritPool, itemFxPoolSizes, time);
	}

	private GameObject _003CStart_003Eb__107_21()
	{
		float time = default(float);
		return CreatePooledItemTimeout(executeFx, executePool, itemFxPoolSizes, time);
	}

	private GameObject _003CStart_003Eb__107_22()
	{
		float time = default(float);
		return CreatePooledItemTimeout(spicyMeatballFx, spicyMeatballPool, itemFxPoolSizes, time);
	}

	private GameObject _003CStart_003Eb__107_23()
	{
		float time = default(float);
		return CreatePooledItemTimeout(freezeFx, freezeFxPool, itemFxPoolSizes, time);
	}

	private GameObject _003CStart_003Eb__107_24()
	{
		ObjectPool<GameObject> objectPool = rocketPool;
		if (rocketPool != null)
		{
			if (objectPool._003CCountAll_003Ek__BackingField < 200)
			{
				return UnityEngine.Object.Instantiate(rocket);
			}
			return null;
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private GameObject _003CStart_003Eb__107_25()
	{
		ObjectPool<GameObject> objectPool = orbPool;
		if (orbPool != null)
		{
			if (objectPool._003CCountAll_003Ek__BackingField < orbPoolSize)
			{
				return UnityEngine.Object.Instantiate(orb);
			}
			return null;
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private GameObject _003CStart_003Eb__107_26()
	{
		float time = default(float);
		return CreatePooledItemTimeout(explosionFx, explosionPool, explosionPoolSize, time);
	}

	private GameObject _003CStart_003Eb__107_27()
	{
		float time = default(float);
		return CreatePooledItemTimeout(bonkFx, bonkPool, maxBonkPrefabs, time);
	}

	private GameObject _003CStart_003Eb__107_28()
	{
		float time = default(float);
		return CreatePooledItemTimeout(bulletHit, bulletHitPool, maxBulletHitPrefabs, time);
	}

	private GameObject _003CStart_003Eb__107_29()
	{
		float time = default(float);
		return CreatePooledItemTimeout(cursedHit, cursedHitPool, cursedHitsPoolSize, time);
	}

	private GameObject _003CStart_003Eb__107_30()
	{
		ObjectPool<GameObject> objectPool = ghostPool;
		if (ghostPool != null)
		{
			if (objectPool._003CCountAll_003Ek__BackingField < 180)
			{
				return UnityEngine.Object.Instantiate(ghost);
			}
			return null;
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private GameObject _003CStart_003Eb__107_31()
	{
		ObjectPool<GameObject> objectPool = angrySoulPool;
		if (angrySoulPool != null)
		{
			if (objectPool._003CCountAll_003Ek__BackingField < 100)
			{
				return UnityEngine.Object.Instantiate(angrySoul);
			}
			return null;
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private GameObject _003CStart_003Eb__107_32()
	{
		float time = default(float);
		return CreatePooledItemTimeout(charmFx, charmPool, charmPoolSize, time);
	}

	private GameObject _003CStart_003Eb__107_33()
	{
		ObjectPool<GameObject> objectPool = borgorPool;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18043BB80");
		if (borgorPool != null)
		{
			object obj = default(object);
			if (objectPool._003CCountAll_003Ek__BackingField < (nint)obj)
			{
				return UnityEngine.Object.Instantiate(borgor);
			}
			return null;
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private GameObject _003CStart_003Eb__107_34()
	{
		float time = default(float);
		return CreatePooledItemTimeout(eat, eatPool, eatPoolSize, time);
	}

	private GameObject _003CStart_003Eb__107_35()
	{
		float time = default(float);
		return CreatePooledItemTimeout(bloodmark, bloodmarkPool, maxBonkPrefabs, time);
	}

	private GameObject _003CStart_003Eb__107_36()
	{
		float time = default(float);
		return CreatePooledItemTimeout(cactusFx, cactusPool, maxBonkPrefabs, time);
	}

	private GameObject _003CStart_003Eb__107_37()
	{
		float time = default(float);
		return CreatePooledItemTimeout(tumbleweedBreak, tumbleweedBreakPool, maxBonkPrefabs, time);
	}

	private GameObject _003CStart_003Eb__107_38()
	{
		ObjectPool<GameObject> objectPool = tumbleweedPool;
		if (tumbleweedPool != null)
		{
			if (objectPool._003CCountAll_003Ek__BackingField < 25)
			{
				return UnityEngine.Object.Instantiate(tumbleweed);
			}
			return null;
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private GameObject _003CStart_003Eb__107_39()
	{
		float time = default(float);
		return CreatePooledItemTimeout(quinMaskFx, quinMaskPool, itemFxPoolSizes, time);
	}

	private GameObject _003CStart_003Eb__107_40()
	{
		float time = default(float);
		return CreatePooledItemTimeout(snekFx, snekPool, itemFxPoolSizes, time);
	}
}
