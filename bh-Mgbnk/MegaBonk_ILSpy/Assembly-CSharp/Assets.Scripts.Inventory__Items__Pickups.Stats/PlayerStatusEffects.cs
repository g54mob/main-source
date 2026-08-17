using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Game.Combat.ConstantAttacks;
using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Stats;

public class PlayerStatusEffects
{
	public Dictionary<EStatusEffect, StatusEffect> statusEffects;

	public static Action<EStat> A_StatusModifiedStat;

	public static Action<EStatusEffect, bool> A_StatusEffectAdded;

	public static Action<EStatusEffect> A_StatusEffectRemoved;

	public const string poisonEffectName = "Poison";

	public const string bleedEffectName = "Bleed";

	private float nextBleedTime;

	private float bleedInterval;

	private float nextPoisonTime;

	private float poisonInterval;

	public PlayerStatusEffects()
	{
		//IL_01e9: Expected O, but got I4
		//IL_01fc: Expected I, but got O
		//IL_00d2: Expected O, but got I4
		//IL_00e5: Expected I, but got O
		//IL_0245: Expected O, but got I4
		//IL_0256: Expected I, but got O
		//IL_026c: Expected I, but got O
		//IL_0292: Expected O, but got I4
		//IL_02a3: Expected I, but got O
		//IL_02b9: Expected I, but got O
		Dictionary<EStatusEffect, StatusEffect> dictionary = new Dictionary<EStatusEffect, StatusEffect>();
		statusEffects = dictionary;
		bleedInterval = 0.5f;
		poisonInterval = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		Action<Pickup> b = OnPickupTriggered;
		Delegate obj = Delegate.Combine(Pickup.A_PickupTriggered, b);
		nint num;
		object obj2;
		Delegate obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			Pickup.A_PickupTriggered = (Action<Pickup>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Pickup> action = default(Action<Pickup>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				obj2 = 0;
				obj3 = null;
				num = (nint)typeof(Action<Pickup>);
				obj4 = obj;
				goto IL_02d7;
			}
			Pickup.A_PickupTriggered = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			obj2 = 0;
			obj3 = null;
			num2 = (nint)typeof(Action<Pickup>);
			obj4 = obj;
			if (flag)
			{
				goto IL_0222;
			}
		}
		Action action2 = OnLevelupScreenDone;
		Delegate obj6 = Delegate.Combine(LevelupScreen.A_LevelUpClose, action2);
		if ((object)obj6 == null)
		{
			LevelupScreen.A_LevelUpClose = null;
			return;
		}
		bool flag2 = (object)obj6.GetType() != typeof(Action);
		Delegate obj7 = null;
		if (!flag2)
		{
			obj7 = obj6;
		}
		bool flag3 = (object)obj7 == null;
		obj2 = 0;
		obj3 = obj6;
		num2 = (nint)LevelupScreen.A_LevelUpClose;
		obj4 = action2;
		nint num3 = (nint)typeof(Action);
		if (flag3)
		{
			goto IL_02c7;
		}
		LevelupScreen.A_LevelUpClose = (Action)obj7;
		bool flag4 = (object)obj6.GetType() != typeof(Action);
		Delegate obj8 = null;
		if (!flag4)
		{
			obj8 = obj6;
		}
		bool flag5 = (object)obj8 == null;
		obj2 = 0;
		obj3 = obj6;
		num = (nint)LevelupScreen.A_LevelUpClose;
		obj4 = action2;
		nint num4 = (nint)typeof(Action);
		if (!flag5)
		{
			return;
		}
		goto IL_02d7;
		IL_02c7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0222;
		IL_0222:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02d7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_02c7;
	}

	public void OnDestroy()
	{
		//IL_01a1: Expected I, but got O
		//IL_01b2: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_0207: Expected I, but got O
		//IL_0218: Expected O, but got I4
		//IL_022e: Expected I, but got O
		//IL_0254: Expected I, but got O
		//IL_0265: Expected O, but got I4
		//IL_027b: Expected I, but got O
		Action<Pickup> value = OnPickupTriggered;
		Delegate obj = Delegate.Remove(Pickup.A_PickupTriggered, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			Pickup.A_PickupTriggered = (Action<Pickup>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Pickup> action = default(Action<Pickup>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<Pickup>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_0299;
			}
			Pickup.A_PickupTriggered = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<Pickup>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_01e4;
			}
		}
		Action action2 = OnLevelupScreenDone;
		Delegate obj6 = Delegate.Remove(LevelupScreen.A_LevelUpClose, action2);
		if ((object)obj6 == null)
		{
			LevelupScreen.A_LevelUpClose = null;
			return;
		}
		bool flag2 = (object)obj6.GetType() != typeof(Action);
		Delegate obj7 = null;
		if (!flag2)
		{
			obj7 = obj6;
		}
		bool flag3 = (object)obj7 == null;
		num2 = (nint)LevelupScreen.A_LevelUpClose;
		obj2 = action2;
		obj3 = 0;
		obj4 = obj6;
		nint num3 = (nint)typeof(Action);
		if (flag3)
		{
			goto IL_0289;
		}
		LevelupScreen.A_LevelUpClose = (Action)obj7;
		bool flag4 = (object)obj6.GetType() != typeof(Action);
		Delegate obj8 = null;
		if (!flag4)
		{
			obj8 = obj6;
		}
		bool flag5 = (object)obj8 == null;
		num = (nint)LevelupScreen.A_LevelUpClose;
		obj2 = action2;
		obj3 = 0;
		obj4 = obj6;
		nint num4 = (nint)typeof(Action);
		if (!flag5)
		{
			return;
		}
		goto IL_0299;
		IL_0289:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01e4;
		IL_01e4:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0299:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0289;
	}

	public unsafe void Tick()
	{
		//IL_01d5: Expected O, but got Ref
		//IL_007a: Expected O, but got Ref
		//IL_0106: Expected O, but got Ref
		bool flag = statusEffects == null;
		List<StatusEffect> list = (List<StatusEffect>)(object)statusEffects;
		if (!flag)
		{
			int count = statusEffects.Count;
			if (count <= 0)
			{
				return;
			}
			List<StatusEffect> list2 = new List<StatusEffect>();
			if (statusEffects != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
				Dictionary<EStatusEffect, StatusEffect>.Enumerator enumerator = default(Dictionary<EStatusEffect, StatusEffect>.Enumerator);
				StatusEffect statusEffect = default(StatusEffect);
				while (enumerator.MoveNext())
				{
					list = (List<StatusEffect>)(&enumerator);
					if (statusEffect != null)
					{
						if (!(MyTime.time < statusEffect.expirationTime))
						{
							if (list2 == null)
							{
								throw new NullReferenceException();
							}
							list2.Add(statusEffect);
						}
						continue;
					}
					throw new NullReferenceException();
				}
				enumerator.Dispose();
				bool flag2 = list2 == null;
				list = (List<StatusEffect>)(&enumerator);
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
					List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
					object obj = default(object);
					while (true)
					{
						if (enumerator2.MoveNext())
						{
							bool flag3 = obj == null;
							List<object>.Enumerator enumerator3 = (List<object>.Enumerator)(&enumerator2);
							if (flag3)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ stack_-88+10]");
							RemoveStatusEffect(EStatusEffect.Haste);
							continue;
						}
						((List<StatusEffect>.Enumerator*)(&enumerator2))->Dispose();
						TickEffects();
						return;
					}
					throw new NullReferenceException();
				}
			}
		}
		throw new NullReferenceException();
	}

	public void AddNewEffect(StatusEffect statusEffect, float statusLengthTime)
	{
		//IL_0092: Expected O, but got I4
		//IL_0052: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_00ab: Expected O, but got I4
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		if (!((Dictionary<System.Int32Enum, object>)(object)statusEffects).ContainsKey((System.Int32Enum)statusEffect.eStatusEffect))
		{
			((Dictionary<System.Int32Enum, object>)(object)statusEffects).Add((System.Int32Enum)statusEffect.eStatusEffect, (object)statusEffect);
			object obj = 1;
		}
		else
		{
			object obj2 = ((Dictionary<System.Int32Enum, object>)(object)statusEffects).get_Item((System.Int32Enum)statusEffect.eStatusEffect);
			float num = statusLengthTime + MyTime.time;
			object obj = 0;
		}
		StatModifier[] modifiers = statusEffect.modifiers;
		object obj3 = 0;
		object obj4 = 0;
		while ((nint)obj3 < modifiers.Length)
		{
			Action<EStat> a_StatusModifiedStat = A_StatusModifiedStat;
			if (A_StatusModifiedStat != null)
			{
				StatModifier statModifier = modifiers[obj4];
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v67 @ r9_v7 (System.Action`1<Assets.Scripts.Menu.Shop.EStat>)+18] (should have been resolved before IL gen)");
			}
			obj4++;
			obj3 = obj4;
		}
		Action<EStatusEffect, bool> a_StatusEffectAdded = A_StatusEffectAdded;
		if (A_StatusEffectAdded != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v205 @ r10_v1 (System.Action`2<Assets.Scripts.Inventory__Items__Pickups.Stats.EStatusEffect, System.Boolean>)+18] (should have been resolved before IL gen)");
		}
	}

	private void RemoveStatusEffect(EStatusEffect eStatusEffect)
	{
		//IL_0096: Expected O, but got I
		//IL_00a5: Expected O, but got I4
		//IL_00ae: Expected O, but got I4
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		//IL_00ea: Expected O, but got I
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)statusEffects).ContainsKey((System.Int32Enum)eStatusEffect);
		bool flag2 = !flag;
		object obj = null;
		if (!flag2)
		{
			object obj2 = ((Dictionary<System.Int32Enum, object>)(object)statusEffects).get_Item((System.Int32Enum)eStatusEffect);
			obj = obj2;
		}
		bool flag3 = ((Dictionary<System.Int32Enum, object>)(object)statusEffects).Remove((System.Int32Enum)eStatusEffect);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rdi_v4 (System.Object)+18]");
			object obj3 = 0;
			object obj4 = 0;
			object obj5 = 0;
			while (true)
			{
				object obj6 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdi_v7+18]");
				if ((nint)obj6 >= 0)
				{
					break;
				}
				Action<EStat> a_StatusModifiedStat = A_StatusModifiedStat;
				if (A_StatusModifiedStat != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdi_v7+20+v75 @ rbx_v7*8]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v155 @ r9_v4 (System.Action`1<Assets.Scripts.Menu.Shop.EStat>)+18] (should have been resolved before IL gen)");
				}
				obj5++;
				obj4 = obj5;
			}
		}
		Action<EStatusEffect> a_StatusEffectRemoved = A_StatusEffectRemoved;
		if (A_StatusEffectRemoved != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v264 @ rax_v11 (System.Action`1<Assets.Scripts.Inventory__Items__Pickups.Stats.EStatusEffect>)+18] (should have been resolved before IL gen)");
		}
	}

	public void RemoveAllStatusEffects()
	{
		Dictionary<EStatusEffect, StatusEffect>.KeyCollection keys = statusEffects.Keys;
		List<System.Int32Enum> list = Enumerable.ToList((IEnumerable<System.Int32Enum>)(object)keys);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18115DC70");
		List<EStatusEffect>.Enumerator enumerator = default(List<EStatusEffect>.Enumerator);
		EStatusEffect eStatusEffect = default(EStatusEffect);
		while (enumerator.MoveNext())
		{
			RemoveStatusEffect(eStatusEffect);
		}
		enumerator.Dispose();
	}

	public bool HasStatusEffect(EStatusEffect effect)
	{
		//IL_002b: Expected I4, but got O
		if (statusEffects != null)
		{
			return ((Dictionary<System.Int32Enum, object>)(object)statusEffects).ContainsKey((System.Int32Enum)effect);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void TestPickup(EPickup ePickup)
	{
		OnPickupTriggered(ePickup);
	}

	private void OnPickupTriggered(Pickup pickup)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 15 Invalid \"Jump target not found in method: 0x180448D50\"");
		throw new NullReferenceException();
	}

	public void SlowPlayer(float time)
	{
		//IL_003c: Expected I, but got O
		StatModifier[] array = new StatModifier[1];
		StatModifier statModifier = new StatModifier();
		statModifier.stat = EStat.MoveSpeedMultiplier;
		statModifier.modification = 0.5f;
		statModifier.modifyType = EStatModifyType.Multiplication;
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj = default(object);
		if (obj != null)
		{
			array[0] = statModifier;
			float expirationTime = default(float);
			StatusEffect statusEffect = new StatusEffect(EStatusEffect.Slow, expirationTime, array);
			expirationTime = MyTime.time + time;
			AddNewEffect(statusEffect, time);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
		object obj2 = default(object);
		throw obj2;
	}

	public void FreezePlayer(float time)
	{
		//IL_003c: Expected I, but got O
		StatModifier[] array = new StatModifier[1];
		StatModifier statModifier = new StatModifier();
		statModifier.stat = EStat.MoveSpeedMultiplier;
		statModifier.modification = 0.075f;
		statModifier.modifyType = EStatModifyType.Multiplication;
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj = default(object);
		if (obj != null)
		{
			array[0] = statModifier;
			float expirationTime = default(float);
			StatusEffect statusEffect = new StatusEffect(EStatusEffect.Freeze, expirationTime, array);
			expirationTime = MyTime.time + time;
			AddNewEffect(statusEffect, time);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
		object obj2 = default(object);
		throw obj2;
	}

	public void BleedPlayer(float duration)
	{
		StatModifier[] modifiers = new StatModifier[0];
		float expirationTime = default(float);
		StatusEffect statusEffect = new StatusEffect(EStatusEffect.Bleed, expirationTime, modifiers);
		expirationTime = MyTime.time + duration;
		AddNewEffect(statusEffect, duration);
	}

	public void PoisonPlayer(float duration)
	{
		if (MyPlayer.Instance != null)
		{
			MyPlayer instance = MyPlayer.Instance;
			if (instance.playerConstantAttacks != null)
			{
				MyPlayer instance2 = MyPlayer.Instance;
				AuraAttacks playerConstantAttacks = instance2.playerConstantAttacks;
				if (playerConstantAttacks.aegisAttack != null)
				{
					MyPlayer instance3 = MyPlayer.Instance;
					AuraAttacks playerConstantAttacks2 = instance3.playerConstantAttacks;
					AegisAttack aegisAttack = playerConstantAttacks2.aegisAttack;
					if (aegisAttack.isActive)
					{
						MyPlayer instance4 = MyPlayer.Instance;
						if (instance4.character == ECharacter.Athena)
						{
							return;
						}
					}
				}
			}
		}
		StatModifier[] modifiers = new StatModifier[0];
		float expirationTime = default(float);
		StatusEffect statusEffect = new StatusEffect(EStatusEffect.Poison, expirationTime, modifiers);
		expirationTime = MyTime.time + duration;
		AddNewEffect(statusEffect, duration);
	}

	public void BossPoisonPlayer(float duration)
	{
		StatModifier[] modifiers = new StatModifier[0];
		float expirationTime = default(float);
		StatusEffect statusEffect = new StatusEffect(EStatusEffect.BossPoison, expirationTime, modifiers);
		expirationTime = MyTime.time + duration;
		AddNewEffect(statusEffect, duration);
	}

	private void OnPickupTriggered(EPickup ePickup)
	{
		//IL_049f: Expected O, but got I4
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0390: Expected I, but got O
		//IL_03a0: Expected O, but got I
		//IL_0214: Expected I, but got O
		//IL_0224: Expected O, but got I
		//IL_013b: Expected I, but got O
		//IL_02c7: Expected I, but got O
		//IL_02d7: Expected O, but got I
		object obj = ePickup - 4;
		bool flag = ePickup == EPickup.Time;
		float statusLengthTime;
		StatusEffect statusEffect2;
		StatusEffect statusEffect4;
		if (!flag)
		{
			object obj2 = obj - 1;
			float time;
			float num2;
			StatusEffect statusEffect3;
			float num4;
			float expirationTime2 = default(float);
			if (!flag)
			{
				object obj3 = obj2 - 1;
				if (!flag)
				{
					object obj4 = obj3 - 1;
					if (!flag)
					{
						if ((nint)obj4 != 1)
						{
							return;
						}
						float stat = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
						float num = stat * 15f;
						StatModifier[] modifiers = new StatModifier[0];
						float expirationTime = default(float);
						StatusEffect statusEffect = new StatusEffect(EStatusEffect.Stonks, expirationTime, modifiers);
						expirationTime = MyTime.time + num;
						statusEffect._002Ector(EStatusEffect.Stonks, expirationTime, modifiers);
						float stat2 = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
						statusLengthTime = stat2 * 15f;
						statusEffect2 = statusEffect;
						goto IL_0503;
					}
					time = MyTime.time;
					float stat3 = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
					num2 = stat3 * 20f;
					StatModifier[] array = new StatModifier[1];
					StatModifier statModifier = new StatModifier();
					statModifier._002Ector();
					statModifier.stat = EStat.MoveSpeedMultiplier;
					float stat4 = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
					float modification = stat4 * 1.75f;
					statModifier.modifyType = EStatModifyType.Multiplication;
					statModifier.modification = modification;
					nint num3 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj5 = default(object);
					if (obj5 == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
						StatModifier statModifier2 = default(StatModifier);
						throw statModifier2;
					}
					array[0] = statModifier;
					StatModifier[] modifiers2 = default(StatModifier[]);
					EStatusEffect eStatusEffect = default(EStatusEffect);
					statusEffect3 = new StatusEffect(eStatusEffect, expirationTime2, modifiers2);
					modifiers2 = array;
					num4 = 20f;
					eStatusEffect = EStatusEffect.Haste;
				}
				else
				{
					time = MyTime.time;
					float stat5 = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
					num2 = stat5 * 15f;
					StatModifier[] array2 = new StatModifier[2];
					StatModifier statModifier3 = new StatModifier();
					statModifier3._002Ector();
					statModifier3.stat = EStat.DamageMultiplier;
					float stat6 = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
					float modification = stat6 * 1.5f;
					statModifier3.modifyType = EStatModifyType.Multiplication;
					statModifier3.modification = modification;
					nint num5 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rdx_v31 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Stats.StatModifier[]>)+40]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj7 = default(object);
					bool flag2 = obj7 == null;
					StatModifier statModifier4 = statModifier3;
					if (flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
						StatModifier statModifier5 = default(StatModifier);
						throw statModifier5;
					}
					array2[0] = statModifier3;
					StatModifier statModifier6 = new StatModifier();
					statModifier6.stat = EStat.AttackSpeed;
					float stat7 = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
					statModifier6.modifyType = EStatModifyType.Multiplication;
					modification = stat7 + stat7;
					statModifier6.modification = modification;
					nint num6 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v721 @ rdx_v36 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Stats.StatModifier[]>)+40]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj9 = default(object);
					bool flag3 = obj9 == null;
					StatModifier statModifier7 = statModifier6;
					if (flag3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
						StatModifier statModifier8 = default(StatModifier);
						throw statModifier8;
					}
					array2[1] = statModifier6;
					statusEffect3 = null;
					StatModifier[] modifiers2 = array2;
					num4 = 15f;
					EStatusEffect eStatusEffect = EStatusEffect.Rage;
				}
			}
			else
			{
				time = MyTime.time;
				float modification = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
				num2 = modification * 15f;
				StatModifier[] array3 = new StatModifier[1];
				StatModifier statModifier9 = new StatModifier();
				statModifier9._002Ector();
				statModifier9.stat = EStat.DamageReductionMultiplier;
				statModifier9.modification = 1f;
				statModifier9.modifyType = EStatModifyType.Flat;
				nint num7 = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ rdx_v19 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Stats.StatModifier[]>)+40]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj11 = default(object);
				bool flag4 = obj11 == null;
				StatModifier statModifier10 = statModifier9;
				if (flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
					object obj12 = default(object);
					throw obj12;
				}
				array3[0] = statModifier9;
				statusEffect3 = null;
				StatModifier[] modifiers2 = array3;
				num4 = 15f;
				EStatusEffect eStatusEffect = EStatusEffect.Shield;
			}
			expirationTime2 = num2 + time;
			float stat8 = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
			statusLengthTime = stat8 * num4;
			statusEffect4 = statusEffect3;
			goto IL_0566;
		}
		float stat9 = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
		float num8 = stat9 * 12f;
		StatModifier[] modifiers3 = new StatModifier[0];
		float expirationTime3 = default(float);
		StatusEffect statusEffect5 = new StatusEffect(EStatusEffect.TimeFreeze, expirationTime3, modifiers3);
		expirationTime3 = MyTime.time + num8;
		statusEffect5._002Ector(EStatusEffect.TimeFreeze, expirationTime3, modifiers3);
		float stat10 = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
		statusLengthTime = stat10 * 12f;
		statusEffect2 = statusEffect5;
		goto IL_0503;
		IL_0566:
		AddNewEffect(statusEffect4, statusLengthTime);
		return;
		IL_0503:
		statusEffect4 = statusEffect2;
		goto IL_0566;
	}

	private void OnLevelupScreenDone()
	{
		//IL_003c: Expected I, but got O
		StatModifier[] array = new StatModifier[1];
		StatModifier statModifier = new StatModifier();
		statModifier.stat = EStat.DamageReductionMultiplier;
		statModifier.modification = 1f;
		statModifier.modifyType = EStatModifyType.Flat;
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj = default(object);
		if (obj != null)
		{
			array[0] = statModifier;
			float expirationTime = default(float);
			StatusEffect statusEffect = new StatusEffect(EStatusEffect.Invulnerability, expirationTime, array);
			expirationTime = MyTime.time + 0.25f;
			AddNewEffect(statusEffect, 0.25f);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
		object obj2 = default(object);
		throw obj2;
	}

	private unsafe void TickEffects()
	{
		//IL_0156: Invalid comparison between F4 and I
		//IL_0280: Invalid comparison between F4 and I
		//IL_0191: Expected F4, but got I4
		//IL_00c5: Expected O, but got I4
		//IL_00c5: Expected O, but got Ref
		//IL_02bb: Expected F4, but got I4
		//IL_01ef: Expected O, but got I4
		//IL_01ef: Expected O, but got Ref
		//IL_01ef: Expected F4, but got I4
		//IL_0319: Expected O, but got I4
		//IL_0319: Expected O, but got Ref
		//IL_0319: Expected F4, but got I4
		Vector3 zeroVector = default(Vector3);
		bool ignoreShield = default(bool);
		string damageSource = default(string);
		DcFlags flags = default(DcFlags);
		EDamageEffect damageEffect = default(EDamageEffect);
		if (((Dictionary<System.Int32Enum, object>)(object)statusEffects).ContainsKey((System.Int32Enum)8) && MyTime.time > nextBleedTime)
		{
			float num = MyTime.time + bleedInterval;
			nextBleedTime = num;
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			if (!inventory.playerHealth.WillDamageKill(5f, ignoreShield: true))
			{
				MyPlayer instance2 = MyPlayer.Instance;
				PlayerInventory inventory2 = instance2.inventory;
				inventory2.playerHealth.DamagePlayerExternal(5f, 0f, (Vector3)(&zeroVector), ignoreShield, damageSource, flags, damageEffect, (Enemy)1);
				zeroVector = Vector3.zeroVector;
			}
		}
		if (MyTime.time < nextPoisonTime)
		{
			return;
		}
		if (((Dictionary<System.Int32Enum, object>)(object)statusEffects).ContainsKey((System.Int32Enum)9))
		{
			float num2 = MyTime.time + poisonInterval;
			nextPoisonTime = num2;
			MyPlayer instance3 = MyPlayer.Instance;
			PlayerInventory inventory3 = instance3.inventory;
			Dictionary<EStatusEffect, StatusEffect> playerHealth = (Dictionary<EStatusEffect, StatusEffect>)(object)inventory3.playerHealth;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rcx_v30 (System.Collections.Generic.Dictionary`2<Assets.Scripts.Inventory__Items__Pickups.Stats.EStatusEffect, Assets.Scripts.Inventory__Items__Pickups.Stats.StatusEffect>)+14]");
			float num3 = 0f * 0.01f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262EC7C]");
			bool flag = default(bool);
			MyPlayer instance4 = default(MyPlayer);
			if (!(num3 < 0f))
			{
				flag = playerHealth.ContainsKey(EStatusEffect.Haste);
				instance4 = MyPlayer.Instance;
			}
			PlayerInventory inventory4 = instance4.inventory;
			if (!inventory4.playerHealth.WillDamageKill(flag ? 1 : 0, ignoreShield: true))
			{
				MyPlayer instance5 = MyPlayer.Instance;
				PlayerInventory inventory5 = instance5.inventory;
				inventory5.playerHealth.DamagePlayerExternal(flag ? 1 : 0, 0f, (Vector3)(&zeroVector), ignoreShield, damageSource, flags, damageEffect, (Enemy)1);
				zeroVector = Vector3.zeroVector;
			}
		}
		if (((Dictionary<System.Int32Enum, object>)(object)statusEffects).ContainsKey((System.Int32Enum)10))
		{
			float num4 = MyTime.time + poisonInterval;
			nextPoisonTime = num4;
			MyPlayer instance6 = MyPlayer.Instance;
			PlayerInventory inventory6 = instance6.inventory;
			Dictionary<EStatusEffect, StatusEffect> playerHealth2 = (Dictionary<EStatusEffect, StatusEffect>)(object)inventory6.playerHealth;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rcx_v15 (System.Collections.Generic.Dictionary`2<Assets.Scripts.Inventory__Items__Pickups.Stats.EStatusEffect, Assets.Scripts.Inventory__Items__Pickups.Stats.StatusEffect>)+14]");
			float num5 = 0f * 0.03f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262EC7C]");
			bool flag2 = default(bool);
			MyPlayer instance7 = default(MyPlayer);
			if (!(num5 < 0f))
			{
				flag2 = playerHealth2.ContainsKey(EStatusEffect.Haste);
				instance7 = MyPlayer.Instance;
			}
			PlayerInventory inventory7 = instance7.inventory;
			if (!inventory7.playerHealth.WillDamageKill(flag2 ? 1 : 0, ignoreShield: true))
			{
				MyPlayer instance8 = MyPlayer.Instance;
				PlayerInventory inventory8 = instance8.inventory;
				inventory8.playerHealth.DamagePlayerExternal(flag2 ? 1 : 0, 0f, (Vector3)(&zeroVector), ignoreShield, damageSource, flags, damageEffect, (Enemy)1);
			}
		}
	}
}
