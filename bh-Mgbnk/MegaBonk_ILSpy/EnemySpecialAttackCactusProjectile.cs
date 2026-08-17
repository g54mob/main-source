using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;
using Assets.Scripts.Game.Spawning;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class EnemySpecialAttackCactusProjectile : EnemySpecialAttackPrefab
{
	public bool grounded;

	public bool predictive;

	private float timer;

	private Vector3 impactPos;

	private Vector3 startPos;

	public TrailRenderer trailRenderer;

	private float arcHeight = 20f;

	protected unsafe override void Init()
	{
		//IL_0008: Expected O, but got Ref
		//IL_002f: Expected O, but got Ref
		//IL_007b: Expected O, but got F4
		//IL_00e5: Expected O, but got F4
		//IL_03dd: Expected O, but got Ref
		//IL_0283: Expected O, but got Ref
		//IL_0307: Expected I, but got O
		//IL_03a5: Expected I, but got O
		//IL_0199: Expected O, but got Ref
		//IL_01ac: Expected O, but got Ref
		//IL_021a: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		Transform transform = base.transform;
		Vector3 centerPosition = enemy.GetCenterPosition();
		Vector3 position = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		_ = centerPosition.x;
		_ = centerPosition.z;
		transform.position = position;
		Transform transform2 = base.transform;
		Vector3 position2 = transform2.position;
		startPos = (Vector3)position2.x;
		_ = position2.z;
		timer = 0f;
		trailRenderer.Clear();
		Transform transform3 = MyPlayer.Instance.transform;
		Vector3 position3 = transform3.position;
		bool flag = !predictive;
		impactPos = (Vector3)position3.x;
		_ = position3.z;
		if (!flag)
		{
			EnemySpecialAttack enemySpecialAttack = base._003CspecialAttack_003Ek__BackingField;
			MyPlayer instance = MyPlayer.Instance;
			Vector3 velocity = instance.playerMovement.GetVelocity();
			float num = enemySpecialAttack.attackChargeTime * velocity.z;
			float num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (EnemySpecialAttackCactusProjectile)+60]");
			float num3 = num2 + 0f;
			Vector3 vector = default(Vector3);
			impactPos = vector;
		}
		if (grounded)
		{
			nint num4 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v461 @ rdx_v16 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num5 = 0;
			float num6 = (float)Vector3.upVector * 999f;
			float num7 = num6 + (float)impactPos;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ rax_v24 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
			float num8 = 0f * 999f;
			float num9 = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (EnemySpecialAttackCactusProjectile)+5C]");
			float num10 = num9 + 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ rax_v24 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			float num11 = 0f * 999f;
			float num12 = num11;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (EnemySpecialAttackCactusProjectile)+60]");
			float num13 = num12 + 0f;
			nint num14 = (nint)typeof(Vector3);
			GameManager instance2 = GameManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdx_v17 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			Vector3 direction = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			Vector3 origin = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
			_ = Vector3.downVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rax_v27 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
			_ = 0;
			int layerMask = default(int);
			RaycastHit[] hits = Physics.RaycastAll(origin, direction, 9999f, layerMask);
			RaycastHit raycastHit = SpawnPositions.FindHitClosestToPlayerY(hits, out System.Runtime.CompilerServices.Unsafe.As<object, bool>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103)));
			object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
			_ = raycastHit.m_Point;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ rax_v32 (UnityEngine.RaycastHit)+10]");
			_ = 0;
			_ = raycastHit.m_Distance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
			object obj4 = default(object);
			impactPos = (Vector3)obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ rax_v33+8]");
			_ = 0;
		}
		Action completeAction = SpawnHitEffect;
		_ = impactPos;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (EnemySpecialAttackCactusProjectile)+60]");
		_ = 0;
		Vector3 pos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		CreateWarningSphere(pos, completeAction);
		Transform transform4 = base.transform;
		Vector3 position4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (EnemySpecialAttackCactusProjectile)+60]");
		_ = 0;
		_ = impactPos;
		transform4.position = position4;
	}

	private unsafe void Update()
	{
		//IL_0027: Invalid comparison between I4 and F4
		//IL_0072: Expected F4, but got I4
		//IL_0108: Invalid comparison between I4 and F4
		//IL_00ad: Expected O, but got Ref
		if (!(timer < 1f))
		{
			return;
		}
		float num = timer + MyTime.deltaTime;
		EnemySpecialAttack enemySpecialAttack = base._003CspecialAttack_003Ek__BackingField;
		timer = num;
		float num2 = num / enemySpecialAttack.attackChargeTime;
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		if (0f > num2 || !(num2 > 1f))
		{
		}
		Transform transform = base.transform;
		float num3 = default(float);
		transform.position = (Vector3)(&num3);
	}

	private unsafe void SpawnHitEffect()
	{
		//IL_0055: Expected O, but got Ref
		//IL_00cf: Expected O, but got Ref
		EnemySpecialAttack enemySpecialAttack = base._003CspecialAttack_003Ek__BackingField;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		GameManager instance = GameManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		float num = default(float);
		int layerMask = default(int);
		if (Physics.CheckSphere((Vector3)(&num), enemySpecialAttack.attackRadius, layerMask))
		{
			float damage = base._003CspecialAttack_003Ek__BackingField.GetDamage(enemy);
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory = instance2.inventory;
			bool ignoreShield = default(bool);
			string damageSource = default(string);
			DcFlags flags = default(DcFlags);
			EDamageEffect damageEffect = default(EDamageEffect);
			inventory.playerHealth.DamagePlayerExternal(damage, 4f, (Vector3)(&num), ignoreShield, damageSource, flags, damageEffect);
		}
		ReturnToPool();
	}
}
