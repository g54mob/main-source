using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Cpp2ILInjected;
using UnityEngine;

public class ProjectileFirefield : ProjectileBase
{
	private float spawnTime;

	private float aliveTime;

	private float spawnRadius;

	private Vector3 normal;

	public Firefield firefield;

	private string damageSource;

	protected unsafe override bool TryInit(int projectileIndex)
	{
		//IL_018c: Expected I4, but got O
		//IL_00f7: Expected O, but got Ref
		//IL_0178: Expected O, but got Ref
		//IL_0178: Expected O, but got Ref
		float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(base.weaponBase);
		Transform transform = base.transform;
		Transform transform2 = base.transform;
		if ((object)transform2 != null)
		{
			Vector3 position = transform2.position;
			MyPlayer instance = MyPlayer.Instance;
			if ((object)MyPlayer.Instance != null && (object)instance.playerRenderer != null)
			{
				Transform transform3 = instance.playerRenderer.transform;
				if ((object)transform3 != null)
				{
					float radius = attackSizeMultiplier * 4f;
					Vector3 forward = transform3.forward;
					if ((object)transform != null)
					{
						float num = default(float);
						transform.position = (Vector3)(&num);
						if ((object)MyPlayer.Instance != null)
						{
							Vector3 feetPosition = MyPlayer.Instance.GetFeetPosition();
							float duration = GetDuration();
							if ((object)firefield != null)
							{
								object obj = default(object);
								float duration2 = default(float);
								float damage = default(float);
								WeaponBase weaponBase = default(WeaponBase);
								string text = default(string);
								firefield.Set((Vector3)(&obj), (Vector3)(&num), radius, duration2, damage, weaponBase, text);
								return true;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	protected unsafe override Vector3 GetMovementDirection()
	{
		//IL_0013: Expected I, but got O
		//IL_0031: Expected F4, but got O
		//IL_002c: Expected native int or pointer, but got O
		//IL_0046: Expected F4, but got I
		//IL_0041: Expected native int or pointer, but got O
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = (float)Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
	}

	protected override void MyFixedUpdate()
	{
	}

	private void CheckDamage()
	{
	}

	protected override void MyUpdate()
	{
	}

	protected override void FindMovementDirection()
	{
	}

	protected override void StepMovement()
	{
	}

	protected override bool CheckCollision(Collider collider, Vector3 normal)
	{
		return false;
	}

	public unsafe ProjectileFirefield()
	{
		//IL_0015: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
		base._002Ector();
	}
}
