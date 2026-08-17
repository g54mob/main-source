using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;
using Assets.Scripts.Game.Spawning;
using Assets.Scripts.Inventory.Stats;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Game.Combat.EnemySpecialAttacks;

public class EnemyProjectileMud : EnemySpecialAttackPrefab
{
	public GameObject hitEffect;

	public ParticleSystem mudParticles;

	public Transform slamParticles;

	public Transform preParticles;

	public bool grounded;

	public bool predictive;

	protected unsafe override void Init()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0258: Expected O, but got Ref
		//IL_015e: Expected O, but got Ref
		//IL_00dc: Expected O, but got Ref
		//IL_00dc: Expected O, but got Ref
		//IL_018a: Expected O, but got Ref
		//IL_01b6: Expected O, but got Ref
		//IL_01e7: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		hitEffect.SetActive(value: false);
		GameObject gameObject = preParticles.gameObject;
		gameObject.SetActive(value: true);
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		if (predictive)
		{
			MyPlayer instance = MyPlayer.Instance;
			Vector3 velocity = instance.playerMovement.GetVelocity();
		}
		float num = default(float);
		if (grounded)
		{
			GameManager instance2 = GameManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			object obj3 = default(object);
			int layerMask = default(int);
			RaycastHit[] array = Physics.RaycastAll((Vector3)(&num), (Vector3)(&obj3), 999f, layerMask);
			if (array.Length != 0)
			{
				RaycastHit raycastHit = SpawnPositions.FindHitClosestToPlayerY(array, out System.Runtime.CompilerServices.Unsafe.As<object, bool>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64)));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
			}
		}
		Action completeAction = SpawnHitEffect;
		CreateWarningSphere((Vector3)(&num), completeAction);
		Transform transform2 = base.transform;
		transform2.position = (Vector3)(&num);
		Transform transform3 = slamParticles.transform;
		transform3.localScale = (Vector3)(&num);
		Transform transform4 = preParticles.transform;
		transform4.localScale = (Vector3)(&num);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
		EnemySpecialAttack enemySpecialAttack = base._003CspecialAttack_003Ek__BackingField;
		ParticleSystem.ShapeModule shapeModule = (ParticleSystem.ShapeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
		((ParticleSystem.ShapeModule*)shapeModule)->radius = enemySpecialAttack.attackRadius;
	}

	private unsafe void SpawnHitEffect()
	{
		//IL_009b: Expected O, but got Ref
		//IL_017e: Expected O, but got Ref
		GameObject gameObject = preParticles.gameObject;
		gameObject.SetActive(value: false);
		hitEffect.SetActive(value: true);
		EnemySpecialAttack enemySpecialAttack = base._003CspecialAttack_003Ek__BackingField;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		GameManager instance = GameManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		float num = default(float);
		int layerMask = default(int);
		if (Physics.CheckSphere((Vector3)(&num), enemySpecialAttack.attackRadius, layerMask))
		{
			EnemySpecialAttack enemySpecialAttack2 = base._003CspecialAttack_003Ek__BackingField;
			float damage = EnemyStats.GetDamage(enemy);
			float damage2 = damage * enemySpecialAttack2.damageMultiplier;
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory = instance2.inventory;
			Transform transform2 = MyPlayer.Instance.transform;
			Vector3 position2 = transform2.position;
			Transform transform3 = base.transform;
			Vector3 position3 = transform3.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			bool ignoreShield = default(bool);
			string damageSource = default(string);
			DcFlags flags = default(DcFlags);
			EDamageEffect damageEffect = default(EDamageEffect);
			inventory.playerHealth.DamagePlayerExternal(damage2, 8f, (Vector3)(&num), ignoreShield, damageSource, flags, damageEffect);
			MyPlayer instance3 = MyPlayer.Instance;
			PlayerInventory inventory2 = instance3.inventory;
			inventory2.statusEffects.SlowPlayer(3f);
		}
		Invoke("ReturnToPool", 2f);
	}
}
