using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;
using Cpp2ILInjected;
using UnityEngine;

public class EnemyGroundSlam : EnemySpecialAttackPrefab
{
	public GameObject hitEffect;

	public AudioSource hitSfx;

	private float finalRadius;

	protected unsafe override void Init()
	{
		//IL_008b: Expected O, but got Ref
		//IL_00e3: Expected O, but got Ref
		//IL_0117: Expected O, but got Ref
		hitEffect.SetActive(value: false);
		EnemySpecialAttack enemySpecialAttack = base._003CspecialAttack_003Ek__BackingField;
		finalRadius = enemySpecialAttack.attackRadius;
		Transform transform = base.transform;
		Vector3 feetPosition = enemy.GetFeetPosition();
		Transform transform2 = enemy.transform;
		Vector3 forward = transform2.forward;
		float num = default(float);
		transform.position = (Vector3)(&num);
		Transform transform3 = base.transform;
		Vector3 position = transform3.position;
		EnemySpecialAttack enemySpecialAttack2 = base._003CspecialAttack_003Ek__BackingField;
		Action action = SpawnHitEffect;
		Action completeAction = default(Action);
		CircleWarning circleWarning = EffectManager.Instance.WarningSphere((Vector3)(&num), finalRadius, enemySpecialAttack2.attackChargeTime, completeAction);
		base.circleWarning = circleWarning;
		Transform transform4 = hitEffect.transform;
		transform4.localScale = (Vector3)(&num);
	}

	private unsafe void SpawnHitEffect()
	{
		//IL_00b1: Expected O, but got Ref
		//IL_0172: Expected O, but got Ref
		hitEffect.SetActive(value: true);
		GameObject gameObject = hitSfx.gameObject;
		if (gameObject.activeInHierarchy)
		{
			hitSfx.Play();
		}
		Transform transform = base.transform;
		Vector3 position = transform.position;
		GameManager instance = GameManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		float num = default(float);
		int layerMask = default(int);
		if (Physics.CheckSphere((Vector3)(&num), finalRadius, layerMask))
		{
			float damage = base._003CspecialAttack_003Ek__BackingField.GetDamage(enemy);
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
			inventory.playerHealth.DamagePlayerExternal(damage, 20f, (Vector3)(&num), ignoreShield, damageSource, flags, damageEffect);
		}
		Invoke("ReturnToPool", 0.5f);
	}
}
