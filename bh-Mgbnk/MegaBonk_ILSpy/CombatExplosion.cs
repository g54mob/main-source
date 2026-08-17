using System.Runtime.CompilerServices;
using Actors.Enemies;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using UnityEngine;

public class CombatExplosion : MonoBehaviour
{
	public float radius;

	public float playerDamage;

	public float playerKnockback = 35f;

	public float enemyKnockback = 5f;

	private unsafe void Start()
	{
		//IL_0008: Expected O, but got Ref
		//IL_05e6: Invalid comparison between F4 and I4
		//IL_0018: Invalid comparison between F4 and I4
		//IL_026e: Invalid comparison between F4 and I4
		//IL_007c: Expected O, but got Ref
		//IL_00a4: Invalid comparison between F4 and I4
		//IL_00c0: Expected O, but got I4
		//IL_01ad: Invalid comparison between F4 and I4
		//IL_02df: Expected O, but got Ref
		//IL_0616: Expected I, but got O
		//IL_017a: Expected O, but got Ref
		//IL_0183: Expected F4, but got I4
		//IL_019d: Expected O, but got Ref
		//IL_05c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c7: Expected O, but got Unknown
		//IL_024c: Expected O, but got Ref
		//IL_06cc: Expected O, but got I
		//IL_050f: Expected O, but got Ref
		//IL_06df: Expected I, but got O
		//IL_0530: Expected O, but got F4
		//IL_0590: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		float x = default(float);
		if (playerDamage > 0f || playerKnockback > 0f)
		{
			Transform transform = base.transform;
			Vector3 position = transform.position;
			GameManager instance = GameManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			int layerMask = default(int);
			if (Physics.CheckSphere((Vector3)(&x), radius, layerMask))
			{
				bool flag = !(playerDamage > 0f);
				float num = radius;
				Vector3 vector = (Vector3)0;
				if (!flag)
				{
					MyPlayer instance2 = MyPlayer.Instance;
					PlayerInventory inventory = instance2.inventory;
					Transform transform2 = MyPlayer.Instance.transform;
					Vector3 position2 = transform2.position;
					Transform transform3 = base.transform;
					Vector3 position3 = transform3.position;
					float num2 = position2.x - position3.x;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					bool ignoreShield = default(bool);
					string damageSource = default(string);
					DcFlags flags = default(DcFlags);
					EDamageEffect damageEffect = default(EDamageEffect);
					inventory.playerHealth.DamagePlayerExternal(playerDamage, 0f, (Vector3)(&x), ignoreShield, damageSource, flags, damageEffect);
					float num3 = 0f;
					float num4 = num2;
					num = playerDamage;
					vector = (Vector3)(&x);
				}
				if (playerKnockback > 0f)
				{
					Transform transform4 = MyPlayer.Instance.transform;
					Vector3 position4 = transform4.position;
					Transform transform5 = base.transform;
					Vector3 position5 = transform5.position;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					nint num5 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1085 @ rax_v58 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num6 = 0;
					float num7 = (float)Vector3.upVector * 0.75f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1086 @ rcx_v53 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
					float num8 = 0f * 0.75f;
					object obj3 = default(object);
					float num9 = num7 + (float)obj3;
					float num10 = num8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ rax_v56+8]");
					float num11 = num10 + 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1086 @ rcx_v53 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
					float num12 = 0f * 0.75f;
					float num13 = num12;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ rax_v56+4]");
					float num14 = num13 + 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					MyPlayer instance3 = MyPlayer.Instance;
					float num15 = playerKnockback;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ rax_v59+4]");
					float num3 = num15 * 0f;
					instance3.playerMovement.RocketJump((Vector3)(&x));
					float num4 = num9;
				}
			}
		}
		float num16 = enemyKnockback;
		if (!(enemyKnockback > 0f))
		{
			return;
		}
		Transform transform6 = base.transform;
		Vector3 position6 = transform6.position;
		GameManager instance4 = GameManager.Instance;
		float x2 = position6.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		int layerMask2 = default(int);
		Collider[] array = Physics.OverlapSphere((Vector3)(&x), radius, layerMask2);
		Enemy enemy = null;
		float num17 = radius;
		x = position6.x;
		Enemy enemy2 = null;
		object obj6 = default(object);
		while ((nint)enemy2 < array.Length)
		{
			GameObject gameObject = array[(object)enemy].gameObject;
			int layer = gameObject.layer;
			int num18 = LayerMask.NameToLayer("Enemy");
			if (layer == num18 && EnemyManager.Instance.GetEnemy(array[(object)enemy], out System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128))))
			{
				Transform transform7 = array[(object)enemy].transform;
				Vector3 position7 = transform7.position;
				Transform transform8 = base.transform;
				Vector3 position8 = transform8.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331420");
				float num19 = position8.x - 1f;
				x2 = num19 / radius;
				if (!(0.3f > x2))
				{
					if (x2 > 1f)
					{
						x2 = 1f;
					}
				}
				else
				{
					x2 = 0.3f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+80]");
				object obj4 = 0;
				DamageContainer damageContainer = new DamageContainer(0f, "CombatExplosion (This is a bug)");
				Transform transform9 = array[(object)enemy].transform;
				Vector3 position9 = transform9.position;
				Transform transform10 = base.transform;
				Vector3 position10 = transform10.position;
				float num20 = position9.x - position10.x;
				object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				nint num21 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ rax_v37 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num22 = 0;
				float num23 = (float)Vector3.upVector * 0.4f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ rcx_v34 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
				float num24 = 0f * 0.4f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ rcx_v34 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				float num25 = 0f * 0.4f;
				float num26 = num23 + (float)obj6;
				float num27 = num24;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1164 @ rax_v35+4]");
				num17 = num27 + 0f;
				float num28 = num25;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1164 @ rax_v35+8]");
				float num3 = num28 + 0f;
				damageContainer.direction = (Vector3)num26;
				float num29 = 1f - x2;
				num16 = num29 * enemyKnockback;
				damageContainer.damage = 0f;
				damageContainer.knockback = num16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rax_v28+58]");
				((EnemyMovementRb)0).Knockback(damageContainer);
				float x3 = position7.x;
				float num4 = num20;
				x = position8.x;
			}
			enemy = (Enemy)(enemy + 1);
			enemy2 = enemy;
		}
	}

	private unsafe void OnDrawGizmosSelected()
	{
		//IL_0009: Expected O, but got Ref
		//IL_0034: Expected O, but got Ref
		object obj = default(object);
		Gizmos.color = (Color)(&obj);
		Transform transform = base.transform;
		Vector3 position = transform.position;
		object obj2 = default(object);
		Gizmos.DrawWireSphere((Vector3)(&obj2), radius);
	}
}
