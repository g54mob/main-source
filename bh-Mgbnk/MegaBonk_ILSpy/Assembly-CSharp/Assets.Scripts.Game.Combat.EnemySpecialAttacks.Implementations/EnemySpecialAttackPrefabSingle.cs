using System;
using System.Runtime.CompilerServices;
using Actors.Enemies;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Spawning;
using Assets.Scripts.Objects.Pooling;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;

public class EnemySpecialAttackPrefabSingle : EnemySpecialAttackPrefab
{
	public bool grounded;

	public bool predictive;

	protected unsafe override void Init()
	{
		//IL_0008: Expected O, but got Ref
		//IL_013c: Expected O, but got Ref
		//IL_016b: Expected O, but got Ref
		//IL_00a0: Expected O, but got Ref
		//IL_00a0: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		if (predictive)
		{
			MyPlayer instance = MyPlayer.Instance;
			Vector3 velocity = instance.playerMovement.GetVelocity();
		}
		float num = default(float);
		Vector3 downVector = default(Vector3);
		if (grounded)
		{
			GameManager instance2 = GameManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			int layerMask = default(int);
			RaycastHit[] array = Physics.RaycastAll((Vector3)(&num), (Vector3)(&downVector), 999f, layerMask);
			bool flag = array.Length == 0;
			downVector = Vector3.downVector;
			if (!flag)
			{
				RaycastHit raycastHit = SpawnPositions.FindHitClosestToPlayerY(array, out System.Runtime.CompilerServices.Unsafe.As<object, bool>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64)));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
				downVector = Vector3.downVector;
			}
		}
		Action action = SpawnHitEffect;
		EnemySpecialAttack enemySpecialAttack = base._003CspecialAttack_003Ek__BackingField;
		Action completeAction = default(Action);
		CircleWarning circleWarning = EffectManager.Instance.WarningSphere((Vector3)(&downVector), enemySpecialAttack.attackRadius, enemySpecialAttack.attackChargeTime, completeAction);
		base.circleWarning = circleWarning;
		Transform transform2 = base.transform;
		transform2.position = (Vector3)(&num);
	}

	private unsafe void SpawnHitEffect()
	{
		//IL_007b: Expected O, but got Ref
		//IL_0117: Expected O, but got Ref
		//IL_00b3: Expected O, but got Ref
		//IL_01fc: Expected O, but got Ref
		GameObject enemyAttackFx = PoolManager.Instance.GetEnemyAttackFx(this);
		float num = default(float);
		if (enemyAttackFx != null)
		{
			Transform transform = enemyAttackFx.transform;
			Transform transform2 = base.transform;
			Vector3 position = transform2.position;
			transform.position = (Vector3)(&num);
			enemyAttackFx.SetActive(value: true);
			Transform transform3 = enemyAttackFx.transform;
			transform3.localScale = (Vector3)(&num);
		}
		EnemySpecialAttack enemySpecialAttack = base._003CspecialAttack_003Ek__BackingField;
		Transform transform4 = base.transform;
		Vector3 position2 = transform4.position;
		GameManager instance = GameManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		int layerMask = default(int);
		if (Physics.CheckSphere((Vector3)(&num), enemySpecialAttack.attackRadius, layerMask))
		{
			float damage = base._003CspecialAttack_003Ek__BackingField.GetDamage(base.enemy);
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory = instance2.inventory;
			Enemy enemy = base.enemy;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D90");
			object obj = default(object);
			if (obj == null)
			{
				Enemy enemy2 = base.enemy;
				EnemyData enemyData = enemy2._003CenemyData_003Ek__BackingField;
				if (enemyData.enemyName != EEnemy.GhostKing)
				{
				}
			}
			bool ignoreShield = default(bool);
			string damageSource = default(string);
			DcFlags flags = default(DcFlags);
			EDamageEffect damageEffect = default(EDamageEffect);
			inventory.playerHealth.DamagePlayerExternal(damage, 25f, (Vector3)(&num), ignoreShield, damageSource, flags, damageEffect);
			if (eAttack == EEnemyAttack.PoisonSpikes)
			{
				MyPlayer instance3 = MyPlayer.Instance;
				PlayerInventory inventory2 = instance3.inventory;
				inventory2.statusEffects.PoisonPlayer(8f);
			}
		}
		Invoke("ReturnToPool", 2f);
	}
}
