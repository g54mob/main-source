using Assets.Scripts.Actors;
using Assets.Scripts.Managers;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Cpp2ILInjected;
using UnityEngine;

public class KillEnemyTrigger : MonoBehaviour
{
	public float bossPercentage;

	public float knockback;

	public string customDamageSource;

	public bool canOneshotRedGhost;

	private float chanceToOneshotRedGhosts;

	public bool isBossLamp;

	private void OnTriggerEnter(Collider collider)
	{
		//IL_00c2: Expected O, but got I4
		if (!EnemyManager.Instance.GetEnemy(collider, out var enemy) || !(enemy != null) || !enemy.CanTakeDamage())
		{
			return;
		}
		bool flag2;
		if (!canOneshotRedGhost)
		{
			EnemyData enemyData = enemy._003CenemyData_003Ek__BackingField;
			object obj = enemyData.enemyName - 39;
			bool flag = obj == null;
			flag2 = flag;
		}
		else
		{
			flag2 = false;
		}
		if (!enemy.IsBoss())
		{
			if (flag2)
			{
				float num = Random.Range(0f, 1f);
				if (num > chanceToOneshotRedGhosts)
				{
					goto IL_0173;
				}
			}
			string damageSource = GetDamageSource();
			enemy.Kill(damageSource);
			return;
		}
		goto IL_0173;
		IL_0173:
		string damageSource2 = GetDamageSource();
		DamageContainer damageContainer = new DamageContainer(0f, damageSource2);
		float damage = enemy.maxHp * bossPercentage;
		damageContainer.damage = damage;
		damageContainer.enemy = enemy;
		damageContainer.knockback = knockback;
		Transform transform = enemy.transform;
		Vector3 position = transform.position;
		Transform transform2 = base.transform;
		Vector3 position2 = transform2.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		object direction = default(object);
		damageContainer.direction = (Vector3)direction;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v26+8]");
		_ = 0;
		damageContainer.flags = DcFlags.BypassAll;
		enemy.DamageExternal(damageContainer);
		if (enemy.IsDead() && isBossLamp)
		{
			bool flag3 = MyAchievements.TryUnlock("a_bobsLantern");
		}
	}

	private string GetDamageSource()
	{
		//IL_0050: Expected O, but got I
		//IL_0060: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172ABA]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2+B8]");
		object obj2 = 0;
		if (!(customDamageSource == (string)obj2))
		{
			return customDamageSource;
		}
		return "Unkown";
	}

	public KillEnemyTrigger()
	{
		//IL_001b: Expected O, but got I
		//IL_002b: Expected O, but got I
		bossPercentage = 0.15f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rax_v1+B8]");
		customDamageSource = (string)0;
		canOneshotRedGhost = true;
		chanceToOneshotRedGhosts = 0.33f;
		base._002Ector();
	}
}
