using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Attacks;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Game.Combat;

public class ProjectileExplosion : MonoBehaviour
{
	private WeaponAttack weaponAttack;

	public GameObject collisionEffect;

	private Vector3 effectPos;

	private Vector3 effectDir;

	private bool useAudio = true;

	public unsafe void Set(WeaponAttack weaponAttack, float radius, Vector3 position, float defaultRadius)
	{
		//IL_001c: Expected O, but got Ref
		//IL_0079: Expected O, but got Ref
		//IL_00c2: Expected O, but got Ref
		Transform transform = base.transform;
		float num = default(float);
		transform.position = (Vector3)(&num);
		this.weaponAttack = weaponAttack;
		CheckZone(weaponAttack.weaponBase, radius, weaponAttack.prefabHit);
		GameObject gameObject = base.gameObject;
		Transform transform2 = gameObject.transform;
		transform2.localScale = (Vector3)(&num);
		Transform transform3 = collisionEffect.transform;
		transform3.parentInternal = null;
		Transform transform4 = collisionEffect.transform;
		transform4.localScale = (Vector3)(&num);
		Transform transform5 = collisionEffect.transform;
		GameObject gameObject2 = base.gameObject;
		Transform parentInternal = gameObject2.transform;
		transform5.parentInternal = parentInternal;
	}

	public unsafe void CheckZone(WeaponBase weaponBase, float radius, GameObject hitEffect = null)
	{
		//IL_002b: Expected O, but got Ref
		//IL_0082: Expected F4, but got I4
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Expected O, but got Unknown
		//IL_011f: Expected O, but got Ref
		//IL_0149: Expected O, but got Ref
		//IL_0167: Expected F4, but got O
		//IL_01b9: Expected O, but got Ref
		//IL_01cc: Expected O, but got F4
		//IL_01fd: Expected O, but got I
		//IL_0250: Expected F4, but got O
		//IL_0286: Expected F4, but got O
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float num = default(float);
		float range = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num), range, out var buffer);
		bool flag = hitEffect == null;
		if (enemiesInRadiusSafe <= 0)
		{
			return;
		}
		bool flag2 = flag;
		num = position.x;
		float num2 = 0f;
		Collider collider = null;
		object obj2 = default(object);
		float num4 = default(float);
		float forceDamage = default(float);
		object obj3 = default(object);
		float x = default(float);
		do
		{
			if (EnemyManager.Instance.GetEnemy(buffer[(object)collider], out var enemy))
			{
				Vector3 centerPosition = enemy.GetCenterPosition();
				Transform transform2 = MyPlayer.Instance.transform;
				Vector3 position2 = transform2.position;
				float num3 = centerPosition.x - position2.x;
				object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				DamageContainer damageContainer = WeaponUtility.GetDamageContainer(weaponBase, null, enemy, (Vector3)(&num4), forceDamage);
				enemy.DamageFromPlayerWeapon(damageContainer);
				num4 = (float)obj3;
				num = num3;
				if (!flag2)
				{
					Transform transform3 = base.transform;
					Vector3 position3 = transform3.position;
					Vector3 vector = buffer[(object)collider].ClosestPoint((Vector3)(&x));
					effectPos = (Vector3)vector.x;
					_ = vector.z;
					range = num2 + 0.1f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v27 (Assets.Scripts.Actors.DamageContainer)+10]");
					effectDir = (Vector3)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v27 (Assets.Scripts.Actors.DamageContainer)+18]");
					_ = 0;
					Invoke("SpawnEffect", range);
					num2 += 0.01f;
					bool flag3 = !(num2 > 0.1f);
					x = position3.x;
					num4 = (float)obj3;
					flag2 = true;
					num = num3;
					if (!flag3)
					{
						x = position3.x;
						num4 = (float)obj3;
						flag2 = true;
						num = num3;
						num2 = 0.1f;
					}
				}
			}
			collider = (Collider)(collider + 1);
		}
		while ((nint)collider < enemiesInRadiusSafe);
	}

	private unsafe void SpawnEffect()
	{
		//IL_001c: Expected O, but got Ref
		//IL_001c: Expected O, but got Ref
		object obj = default(object);
		object obj2 = default(object);
		bool useSfx = default(bool);
		weaponAttack.ProjectileHit((Vector3)(&obj), (Vector3)(&obj2), hitEnemy: true, useSfx);
		useAudio = false;
	}
}
