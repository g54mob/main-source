using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace Assets.Scripts.Utility;

public static class FxUtility
{
	public static Dictionary<EWeapon, float> weaponCooldowns;

	public static Dictionary<EWeapon, float> muzzleCooldowns;

	public static void Init()
	{
		//IL_0124: Expected I, but got O
		Action b = OnRunStarted;
		Delegate obj = Delegate.Combine(GameManager.A_RunStarted, b);
		if ((object)obj == null)
		{
			GameManager.A_RunStarted = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			GameManager.A_RunStarted = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public static void Cleanup()
	{
		//IL_0124: Expected I, but got O
		Action value = OnRunStarted;
		Delegate obj = Delegate.Remove(GameManager.A_RunStarted, value);
		if ((object)obj == null)
		{
			GameManager.A_RunStarted = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			GameManager.A_RunStarted = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private static void OnRunStarted()
	{
		Dictionary<EWeapon, float> dictionary = new Dictionary<EWeapon, float>();
		weaponCooldowns = dictionary;
		Dictionary<EWeapon, float> dictionary2 = new Dictionary<EWeapon, float>();
		muzzleCooldowns = dictionary2;
	}

	static FxUtility()
	{
		Dictionary<EWeapon, float> dictionary = new Dictionary<EWeapon, float>();
		weaponCooldowns = dictionary;
		Dictionary<EWeapon, float> dictionary2 = new Dictionary<EWeapon, float>();
		muzzleCooldowns = dictionary2;
	}
}
