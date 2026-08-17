using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups;
using Cpp2ILInjected;
using UnityEngine;

public class PlayerShieldEffects : MonoBehaviour
{
	public ParticleSystem shieldBreakFx;

	public ParticleSystem shieldChargeFx;

	public AudioSource shieldBreakSfx;

	public AudioSource shieldChargeSfx;

	private bool shieldBroken = true;

	private void Awake()
	{
		//IL_01ce: Expected I, but got O
		//IL_01df: Expected O, but got I4
		//IL_01e8: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		Action<PlayerHealth, DamageContainer, bool> b = new Action<object, object, bool>(OnDamage);
		Delegate obj = Delegate.Combine(PlayerHealth.A_TakeDamage, b);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerHealth.A_TakeDamage = (Action<PlayerHealth, DamageContainer, bool>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, DamageContainer, bool> action = default(Action<PlayerHealth, DamageContainer, bool>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_020d;
			}
			PlayerHealth.A_TakeDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_01f2;
			}
		}
		Action<PlayerHealth, float, bool> b2 = new Action<object, float, bool>(OnHeal);
		Delegate obj6 = Delegate.Combine(PlayerHealth.A_Heal, b2);
		if ((object)obj6 == null)
		{
			PlayerHealth.A_Heal = (Action<PlayerHealth, float, bool>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerHealth, float, bool> action2 = default(Action<PlayerHealth, float, bool>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<PlayerHealth, float, bool>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_01fd;
		}
		PlayerHealth.A_Heal = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<PlayerHealth, float, bool>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_020d;
		IL_01f2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_020d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_01fd;
		IL_01fd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01f2;
	}

	private void OnDestroy()
	{
		//IL_01ce: Expected I, but got O
		//IL_01df: Expected O, but got I4
		//IL_01e8: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		Action<PlayerHealth, DamageContainer, bool> value = new Action<object, object, bool>(OnDamage);
		Delegate obj = Delegate.Remove(PlayerHealth.A_TakeDamage, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerHealth.A_TakeDamage = (Action<PlayerHealth, DamageContainer, bool>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, DamageContainer, bool> action = default(Action<PlayerHealth, DamageContainer, bool>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_020d;
			}
			PlayerHealth.A_TakeDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_01f2;
			}
		}
		Action<PlayerHealth, float, bool> value2 = new Action<object, float, bool>(OnHeal);
		Delegate obj6 = Delegate.Remove(PlayerHealth.A_Heal, value2);
		if ((object)obj6 == null)
		{
			PlayerHealth.A_Heal = (Action<PlayerHealth, float, bool>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerHealth, float, bool> action2 = default(Action<PlayerHealth, float, bool>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<PlayerHealth, float, bool>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_01fd;
		}
		PlayerHealth.A_Heal = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<PlayerHealth, float, bool>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_020d;
		IL_01f2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_020d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_01fd;
		IL_01fd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01f2;
	}

	private void OnDamage(PlayerHealth ph, DamageContainer dc, bool shieldDamage)
	{
		//IL_0027: Invalid comparison between I4 and F4
		if (shieldDamage && !(0f < ph.shield))
		{
			shieldBreakFx.Play();
			shieldBreakSfx.Play();
			shieldBroken = true;
		}
	}

	private void OnHeal(PlayerHealth ph, float amount, bool isShield)
	{
		//IL_002d: Invalid comparison between F4 and I4
		if (shieldBroken && ph.shield > 0f)
		{
			shieldChargeFx.Play();
			shieldChargeSfx.Play();
			shieldBroken = false;
		}
	}
}
