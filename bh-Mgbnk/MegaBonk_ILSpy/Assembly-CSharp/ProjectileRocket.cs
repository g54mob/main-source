using System;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Cpp2ILInjected;
using UnityEngine;

public class ProjectileRocket : ProjectileBase
{
	public Rocket rocket;

	private string damageSource;

	private void Awake()
	{
		//IL_0136: Expected O, but got I4
		//IL_0144: Expected I, but got O
		//IL_016a: Expected O, but got I4
		//IL_0178: Expected I, but got O
		Rocket rocket = this.rocket;
		if ((object)this.rocket != null)
		{
			Action b = OnRocketDone;
			Delegate obj = Delegate.Combine(rocket.A_ProjectileDone, b);
			if ((object)obj == null)
			{
				rocket.A_ProjectileDone = null;
				return;
			}
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			bool flag2 = (object)obj2 == null;
			object obj3 = 0;
			nint num = (nint)typeof(Action);
			if (flag2)
			{
				goto IL_018e;
			}
			rocket.A_ProjectileDone = (Action)obj2;
			bool flag3 = (object)obj.GetType() != typeof(Action);
			Delegate obj4 = null;
			if (!flag3)
			{
				obj4 = obj;
			}
			bool flag4 = (object)obj4 == null;
			obj3 = 0;
			num = (nint)typeof(Action);
			NullReferenceException ex = (NullReferenceException)(object)obj;
			if (!flag4)
			{
				return;
			}
		}
		else
		{
			NullReferenceException ex = new NullReferenceException();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_018e;
		IL_018e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	protected unsafe override bool TryInit(int projectileIndex)
	{
		//IL_019f: Expected I4, but got O
		//IL_00a2: Expected O, but got Ref
		//IL_013f: Expected O, but got Ref
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Vector3 position = transform.position;
			float weaponRange = WeaponUtility.GetWeaponRange(base.weaponBase);
			WeaponBase weaponBase = base.weaponBase;
			if (base.weaponBase != null)
			{
				WeaponData weaponData = weaponBase.weaponData;
				if ((object)weaponBase.weaponData != null)
				{
					float num = default(float);
					GameObject exceptObject = default(GameObject);
					Enemy enemy = EnemyTargeting.GetEnemy((Vector3)(&num), weaponRange, projectileIndex, weaponData.useVision, exceptObject);
					if (!(enemy != null))
					{
						return false;
					}
					Transform transform2 = base.transform;
					if ((object)transform2 != null)
					{
						Vector3 position2 = transform2.position;
						if ((object)this.rocket != null)
						{
							bool useGenericPool = default(bool);
							string text = default(string);
							this.rocket.Set((Vector3)(&num), 0f, 0f, (WeaponBase)(object)exceptObject, useGenericPool, text);
							Rocket rocket = this.rocket;
							if ((object)this.rocket != null)
							{
								rocket.targetEnemy = enemy;
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

	private void OnDestroy()
	{
		//IL_0136: Expected O, but got I4
		//IL_0144: Expected I, but got O
		//IL_016a: Expected O, but got I4
		//IL_0178: Expected I, but got O
		Rocket rocket = this.rocket;
		if ((object)this.rocket != null)
		{
			Action value = OnRocketDone;
			Delegate obj = Delegate.Remove(rocket.A_ProjectileDone, value);
			if ((object)obj == null)
			{
				rocket.A_ProjectileDone = null;
				return;
			}
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			bool flag2 = (object)obj2 == null;
			object obj3 = 0;
			nint num = (nint)typeof(Action);
			if (flag2)
			{
				goto IL_018e;
			}
			rocket.A_ProjectileDone = (Action)obj2;
			bool flag3 = (object)obj.GetType() != typeof(Action);
			Delegate obj4 = null;
			if (!flag3)
			{
				obj4 = obj;
			}
			bool flag4 = (object)obj4 == null;
			obj3 = 0;
			num = (nint)typeof(Action);
			NullReferenceException ex = (NullReferenceException)(object)obj;
			if (!flag4)
			{
				return;
			}
		}
		else
		{
			NullReferenceException ex = new NullReferenceException();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_018e;
		IL_018e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnRocketDone()
	{
		ProjectileDone();
	}

	protected override void MyFixedUpdate()
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

	public unsafe ProjectileRocket()
	{
		//IL_0015: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
		base._002Ector();
	}
}
