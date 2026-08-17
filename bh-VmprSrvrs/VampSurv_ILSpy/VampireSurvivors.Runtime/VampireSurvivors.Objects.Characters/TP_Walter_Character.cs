using System;
using System.Collections.Generic;
using Coherence.Toolkit;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class TP_Walter_Character : TP_Character
{
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public List<Equipment> weapons;

		public TP_Walter_Character _003C_003E4__this;

		public Action _003C_003E9__2;

		internal void _003CStatsUp_003Eb__2()
		{
			//IL_02cd: Expected O, but got I4
			//IL_007c: Expected I, but got O
			//IL_008a: Expected I, but got O
			//IL_009a: Expected O, but got I
			//IL_011a: Expected O, but got I4
			//IL_00d6: Expected O, but got I
			//IL_010c: Expected O, but got I4
			//IL_0260: Expected I, but got O
			//IL_035d: Expected I, but got O
			//IL_01ec: Expected I4, but got O
			//IL_0236: Expected O, but got I4
			//IL_030c->IL0277: Incompatible stack heights: 1 vs 0
			//IL_0149->IL0277: Incompatible stack heights: 1 vs 0
			//IL_01d3->IL0277: Incompatible stack heights: 1 vs 0
			//IL_0211->IL0277: Incompatible stack heights: 1 vs 0
			Equipment equipment;
			Equipment equipment2;
			object obj4;
			if ((object)_003C_003E4__this != null)
			{
				GameObject gameObject = _003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj == null)
					{
						return;
					}
					equipment = Extensions.PickRnd(weapons);
					if ((object)equipment == null)
					{
						equipment2 = null;
						goto IL_02ea;
					}
					nint num = (nint)equipment;
					nint num2 = (nint)typeof(Weapon);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
					if (num3 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v44+FFFFFFF8+v400 @ rax_v40*8]");
						if (0 == (nint)typeof(Weapon))
						{
							obj4 = 1;
							goto IL_0311;
						}
					}
					obj4 = 0;
					goto IL_0311;
				}
			}
			goto IL_0277;
			IL_02ea:
			GameManager core = GM.Core;
			if ((object)GM.Core == null || core._multiplayer == null)
			{
				goto IL_0277;
			}
			if (core._multiplayer.IsOnlineMultiplayer)
			{
				if ((object)equipment2 == null)
				{
					return;
				}
				if (((UnityEngine.Object)equipment2).m_CachedPtr != (IntPtr)0)
				{
					GameObject gameObject2 = (GameObject)(object)_003C_003E4__this;
					if ((object)_003C_003E4__this != null)
					{
						Action<int> action = null;
						((TP_Walter_Character)(object)action).TriggerWeapon((int)_003C_003E4__this);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v31 (UnityEngine.GameObject)+A8]");
						if ((nint)0 != 0)
						{
							nint num = (nint)equipment2._equipmentType;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F6CDA0");
							Equipment equipment3 = (Equipment)1;
							goto IL_0355;
						}
					}
					goto IL_0277;
				}
			}
			if ((object)equipment2 != null)
			{
				nint num4 = (nint)equipment2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v536 @ rax_v24 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+4B8] (should have been resolved before IL gen)");
				Equipment equipment3 = equipment;
				goto IL_0355;
			}
			return;
			IL_0311:
			bool flag2 = obj4 == null;
			equipment2 = null;
			if (!flag2)
			{
				equipment2 = equipment;
			}
			goto IL_02ea;
			IL_0355:
			nint num5 = (nint)equipment2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v567 @ rax_v21 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+4B8] (should have been resolved before IL gen)");
			return;
			IL_0277:
			throw new NullReferenceException();
		}
	}

	private float OverhealDelay;

	private float OverhealTriggerValue2;

	private bool _canOverheal;

	private Timer _overHealTimer;

	private Weapon aurablastWeapon;

	private List<WeaponType> spells;

	public override bool DrainWeaponsImmunity => true;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		Action<float, float> b = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE6B0");
		Delegate obj = Delegate.Combine(((CharacterController)this)._onHpRecoveryCallback, b);
		if ((object)obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			if ((object)obj == null)
			{
				throw new InvalidCastException();
			}
		}
		((CharacterController)this)._onHpRecoveryCallback = (Action<float, float>)obj;
		_canOverheal = true;
	}

	private unsafe void StatsUp(float value, float rawValue)
	{
		//IL_006f: Expected O, but got I
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_02ec: Expected I, but got O
		//IL_0302: Expected O, but got I
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Expected O, but got Unknown
		//IL_0386: Expected I, but got O
		//IL_01c0: Expected O, but got I4
		//IL_04ad: Expected O, but got I4
		//IL_04d6: Expected I, but got I8
		//IL_02cc: Expected O, but got I4
		//IL_02da: Expected O, but got I4
		//IL_0362: Expected I, but got I8
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rcx_v38 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rcx_v38 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rcx_v38 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		float num = rawValue - value;
		if (num < OverhealTriggerValue2)
		{
			return;
		}
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals15 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals15._003C_003E4__this = this;
		if (!_canOverheal)
		{
			return;
		}
		CharacterWeaponsManager weaponsManager = ((CharacterController)this)._weaponsManager;
		Predicate<Equipment> match = delegate(Equipment x)
		{
			//IL_0067: Expected I4, but got O
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected I4, but got Unknown
			if ((object)x != null)
			{
				List<WeaponType> list3 = spells;
				if (spells != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					object obj6 = default(object);
					object obj5 = obj6 >> 31;
					return (byte)(obj5 ^ 1) != 0;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		};
		List<object> weapons = ((List<object>)(object)((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField).FindAll((Predicate<object>)match);
		List<Equipment> list = (List<Equipment>)(CS_0024_003C_003E8__locals15 + 16);
		CS_0024_003C_003E8__locals15.weapons = (List<Equipment>)(object)weapons;
		List<Equipment> weapons2 = CS_0024_003C_003E8__locals15.weapons;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (weapons2._size > 0)
		{
			List<Equipment> list2 = list.FindAll(match);
			if ((nint)list2 > 10)
			{
				list2 = (List<Equipment>)10;
			}
			else if ((nint)list2 <= 0)
			{
				goto IL_03e3;
			}
			bool flag3 = false;
			do
			{
				bool flag4 = CS_0024_003C_003E8__locals15._003C_003E9__2 != null;
				Action onComplete = CS_0024_003C_003E8__locals15._003C_003E9__2;
				if (!flag4)
				{
					Action action = delegate
					{
						//IL_02cd: Expected O, but got I4
						//IL_007c: Expected I, but got O
						//IL_008a: Expected I, but got O
						//IL_009a: Expected O, but got I
						//IL_011a: Expected O, but got I4
						//IL_00d6: Expected O, but got I
						//IL_010c: Expected O, but got I4
						//IL_0260: Expected I, but got O
						//IL_035d: Expected I, but got O
						//IL_01ec: Expected I4, but got O
						//IL_0236: Expected O, but got I4
						//IL_030c->IL0277: Incompatible stack heights: 1 vs 0
						//IL_0149->IL0277: Incompatible stack heights: 1 vs 0
						//IL_01d3->IL0277: Incompatible stack heights: 1 vs 0
						//IL_0211->IL0277: Incompatible stack heights: 1 vs 0
						Equipment equipment;
						Equipment equipment2;
						object obj8;
						if ((object)CS_0024_003C_003E8__locals15._003C_003E4__this != null)
						{
							GameObject gameObject = CS_0024_003C_003E8__locals15._003C_003E4__this.gameObject;
							if ((object)gameObject != null)
							{
								bool flag5 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj5 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj5 == null)
								{
									return;
								}
								equipment = Extensions.PickRnd(CS_0024_003C_003E8__locals15.weapons);
								if ((object)equipment == null)
								{
									equipment2 = null;
									goto IL_02ea;
								}
								nint num4 = (nint)equipment;
								nint num5 = (nint)typeof(Weapon);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
								object obj6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
								nint num6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
								if (num6 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
									object obj7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v44+FFFFFFF8+v400 @ rax_v40*8]");
									if (0 == (nint)typeof(Weapon))
									{
										obj8 = 1;
										goto IL_0311;
									}
								}
								obj8 = 0;
								goto IL_0311;
							}
						}
						goto IL_0277;
						IL_02ea:
						GameManager core = GM.Core;
						if ((object)GM.Core == null || core._multiplayer == null)
						{
							goto IL_0277;
						}
						Equipment equipment3;
						if (core._multiplayer.IsOnlineMultiplayer)
						{
							if ((object)equipment2 == null)
							{
								return;
							}
							if (((UnityEngine.Object)equipment2).m_CachedPtr != (IntPtr)0)
							{
								GameObject gameObject2 = (GameObject)(object)CS_0024_003C_003E8__locals15._003C_003E4__this;
								if ((object)CS_0024_003C_003E8__locals15._003C_003E4__this != null)
								{
									Action<int> action3 = null;
									((TP_Walter_Character)(object)action3).TriggerWeapon((int)CS_0024_003C_003E8__locals15._003C_003E4__this);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v31 (UnityEngine.GameObject)+A8]");
									if ((nint)0 != 0)
									{
										nint num4 = (nint)equipment2._equipmentType;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F6CDA0");
										equipment3 = (Equipment)1;
										goto IL_0355;
									}
								}
								goto IL_0277;
							}
						}
						if ((object)equipment2 == null)
						{
							return;
						}
						nint num7 = (nint)equipment2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v536 @ rax_v24 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+4B8] (should have been resolved before IL gen)");
						equipment3 = equipment;
						goto IL_0355;
						IL_0311:
						bool flag6 = obj8 == null;
						equipment2 = null;
						if (!flag6)
						{
							equipment2 = equipment;
						}
						goto IL_02ea;
						IL_0355:
						nint num8 = (nint)equipment2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v567 @ rax_v21 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+4B8] (should have been resolved before IL gen)");
						return;
						IL_0277:
						throw new NullReferenceException();
					};
					list = (List<Equipment>)(CS_0024_003C_003E8__locals15 + 32);
					CS_0024_003C_003E8__locals15._003C_003E9__2 = action;
					onComplete = action;
				}
				float duration = (float)(flag3 ? 1 : 0) * 0.001f;
				Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				flag3 = (byte)((flag3 ? 1u : 0u) + 100u) != 0;
			}
			while (CS_0024_003C_003E8__locals15._003C_003E9__2 != null);
		}
		goto IL_03e3;
		IL_03e3:
		Timer overHealTimer = _overHealTimer;
		_canOverheal = false;
		if (_overHealTimer != null && !_overHealTimer.IsDone)
		{
			float timeElapsed = _overHealTimer.GetTimeElapsed();
			overHealTimer._timeElapsedBeforeCancel = (float?)(object)1;
			overHealTimer._timeElapsedBeforePause = (float?)(object)0;
		}
		Action action2 = null;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ r10_v2 (Il2CppMethodInfo)+8]");
		((Delegate)action2).method_ptr = (IntPtr)0;
		((Delegate)action2).method = (nint)__ldftn(TP_Walter_Character._003CStatsUp_003Eb__9_1);
		((Delegate)action2).m_target = this;
		((Delegate)action2).method_code = (IntPtr)action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ r10_v2 (Il2CppMethodInfo)+4C]");
		object obj2 = (nint)0 >> 4;
		object obj3 = obj2 & 1;
		nint num3;
		if (obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ r10_v2 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num3 = unchecked((nint)6447293664L);
				goto IL_04a4;
			}
		}
		num3 = ((Delegate)action2).method_ptr;
		((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
		goto IL_04a4;
		IL_04a4:
		object obj4 = 24;
		float duration2 = OverhealDelay * 0.001f;
		((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
		Timer overHealTimer2 = Timers.Register(duration2, action2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_overHealTimer = overHealTimer2;
	}

	public void TriggerWeapon(int weapon)
	{
		((CharacterController)this)._weaponsManager.GetWeaponByType((WeaponType)weapon)?.Fire();
	}

	public TP_Walter_Character()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_071c: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0744: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_076c: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_0794: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_07bc: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_07e4: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_080c: Expected O, but got I
		//IL_0368: Expected O, but got I
		//IL_0834: Expected O, but got I
		//IL_03d2: Expected O, but got I
		//IL_085c: Expected O, but got I
		//IL_043c: Expected O, but got I
		//IL_0884: Expected O, but got I
		//IL_04a6: Expected O, but got I
		//IL_08ac: Expected O, but got I
		//IL_0510: Expected O, but got I
		//IL_08d4: Expected O, but got I
		//IL_057a: Expected O, but got I
		//IL_08fc: Expected O, but got I
		//IL_05e4: Expected O, but got I
		//IL_0924: Expected O, but got I
		//IL_064e: Expected O, but got I
		//IL_094c: Expected O, but got I
		//IL_06b8: Expected O, but got I
		OverhealDelay = 100f;
		OverhealTriggerValue2 = 8f;
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1402);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1402;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1471);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1471;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1427);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1427;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1429);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1429;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1473);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1473;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1452);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1452;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdx_v16+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1437);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1437;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rdx_v18+18]");
		if (num8 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1438);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 1438;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v20+18]");
		if (num9 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1439);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 1439;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdx_v22+18]");
		if (num10 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1497);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 1497;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdx_v24+18]");
		if (num11 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1498);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 1498;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdx_v26+18]");
		if (num12 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1499);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 1499;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v28+18]");
		if (num13 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1562);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 1562;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rdx_v30+18]");
		if (num14 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1560);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 1560;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v32+18]");
		if (num15 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1563);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 1563;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdx_v34+18]");
		if (num16 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1447);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj32 = (nint)0 + (nint)1;
			_ = 1447;
		}
		spells = list;
		((CharacterController)this)._002Ector();
	}

	private bool _003CStatsUp_003Eb__9_0(Equipment x)
	{
		//IL_0067: Expected I4, but got O
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected I4, but got Unknown
		if ((object)x != null)
		{
			List<WeaponType> list = spells;
			if (spells != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj2 = default(object);
				object obj = obj2 >> 31;
				return (byte)(obj ^ 1) != 0;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void _003CStatsUp_003Eb__9_1()
	{
		_canOverheal = true;
	}
}
