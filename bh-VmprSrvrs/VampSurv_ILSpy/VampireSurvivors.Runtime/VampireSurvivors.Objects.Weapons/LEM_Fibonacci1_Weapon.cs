using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class LEM_Fibonacci1_Weapon : LEM_BaseWeapon
{
	private sealed class _003C_003Ec__DisplayClass23_0
	{
		public Weapon w;

		public int localI;

		public LEM_Fibonacci1_Weapon _003C_003E4__this;

		internal void _003CTriggerOtherWeapons_003Eb__0()
		{
			//IL_0026: Expected I, but got O
			//IL_0050: Expected I, but got O
			//IL_0060: Expected O, but got I
			//IL_009c: Expected O, but got I
			//IL_0145: Expected O, but got I4
			//IL_00d9: Expected O, but got I
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Expected O, but got Unknown
			Weapon weapon = w;
			bool flag = ((Equipment)weapon)._equipmentType == WeaponType.LEM_PLANETS2;
			nint num = (nint)weapon;
			if (!flag)
			{
				weapon.Fire();
				goto IL_012e;
			}
			nint num2 = (nint)typeof(LEM_Planets2_Weapon);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Planets2_Weapon>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Planets2_Weapon>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v11+FFFFFFF8+v66 @ rax_v10*8]");
				if (0 == (nint)typeof(LEM_Planets2_Weapon))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Planets2_Weapon>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v11+FFFFFFF8+v223 @ rcx_v10*8]");
					object obj4 = 0 - typeof(LEM_Planets2_Weapon);
					bool flag2 = obj4 == null;
					bool flag3 = !flag2;
					LEM_Planets1_Weapon lEM_Planets1_Weapon = null;
					if (!flag3)
					{
						lEM_Planets1_Weapon = (LEM_Planets1_Weapon)weapon;
					}
					lEM_Planets1_Weapon.ToggleNegative(true);
					goto IL_012e;
				}
			}
			throw new NullReferenceException();
			IL_012e:
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float detune = (float)localI * 100f;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.sfx_paradoxMist, soundConfig, 0f, 10, time);
		}
	}

	private List<int> _003CFibonacciSequence_003Ek__BackingField;

	private List<float2> _003CFibonacciOffsets_003Ek__BackingField;

	protected virtual float WeaponTriggerChance
	{
		get
		{
			//IL_0015: Expected O, but got I4
			//IL_004c: Expected O, but got I
			//IL_0061: Expected O, but got I4
			List<int> list = _003CFibonacciSequence_003Ek__BackingField;
			object obj = ((Equipment)this)._003CLevel_003Ek__BackingField - 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rdx_v1 (System.Collections.Generic.List`1<System.Int32>)+18]");
			float num2 = default(float);
			if ((nint)obj < 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rdx_v1 (System.Collections.Generic.List`1<System.Int32>)+10]");
				object obj2 = 0;
				object obj3 = ((Equipment)this)._003CLevel_003Ek__BackingField - 1;
				float weaponTriggerLuckBonus = WeaponTriggerLuckBonus;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v9+20+v113 @ rbx_v3*4]");
				float num = 0f / 100f;
				return num2 + num;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			return num2;
		}
	}

	protected virtual float WeaponTriggerLuckBonus
	{
		get
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
			object obj = default(object);
			float num2 = (float)obj - 1f;
			return num2 * 0.1f;
		}
	}

	protected virtual int NumWeaponsToTrigger => 1;

	public List<int> FibonacciSequence
	{
		get
		{
			return _003CFibonacciSequence_003Ek__BackingField;
		}
		private set
		{
			_003CFibonacciSequence_003Ek__BackingField = value;
		}
	}

	public List<float2> FibonacciOffsets
	{
		get
		{
			return _003CFibonacciOffsets_003Ek__BackingField;
		}
		private set
		{
			_003CFibonacciOffsets_003Ek__BackingField = value;
		}
	}

	public float FibSeqLength => 15f;

	public virtual float StartingAngle => 90f;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		CreateFibonacciSequence();
		CreateFibonnaciOffsets();
		AddOuterSaboteur();
	}

	private void CreateFibonacciSequence()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_010a: Expected O, but got I4
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0154: Expected O, but got I
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected O, but got Unknown
		//IL_01f4: Expected O, but got I
		//IL_024d: Expected O, but got I
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Expected O, but got Unknown
		//IL_02d1: Invalid comparison between F4 and O
		List<int> list = new List<int>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v5+18]");
		if (num >= 0)
		{
			list.AddWithResize(1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rdx_v7+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1;
		}
		_003CFibonacciSequence_003Ek__BackingField = list;
		object obj5 = 2;
		while (true)
		{
			List<int> list2 = _003CFibonacciSequence_003Ek__BackingField;
			object obj6 = obj5 - 2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r9_v6 (System.Collections.Generic.List`1<System.Int32>)+18]");
			if ((nint)obj6 >= 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r9_v6 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj7 = 0;
			object obj8 = obj5 - 2;
			object obj9 = obj5 - 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r9_v6 (System.Collections.Generic.List`1<System.Int32>)+18]");
			if ((nint)obj9 >= 0)
			{
				break;
			}
			object obj10 = obj5 - 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v11+20+v99 @ rax_v18*4]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v11+20+v201 @ rcx_v15*4]");
			int item = (int)(num3 + 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r9_v6 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r9_v6 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r9_v6 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rcx_v16+18]");
			if (num4 >= 0)
			{
				list2.AddWithResize(item);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r9_v6 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj12 = (nint)0 + (nint)1;
			}
			obj5++;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)15f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new IndexOutOfRangeException();
	}

	private void CreateFibonnaciOffsets()
	{
		//IL_003d: Expected O, but got I4
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_0087: Expected O, but got I
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Expected O, but got Unknown
		//IL_02b8: Expected O, but got I4
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		//IL_022d: Invalid comparison between F4 and O
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected O, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Expected O, but got Unknown
		List<float2> list = new List<float2>();
		float2 item = default(float2);
		list.Add(item);
		list.Add(item);
		_003CFibonacciOffsets_003Ek__BackingField = list;
		object obj = 2;
		while (true)
		{
			List<float2> list2 = _003CFibonacciOffsets_003Ek__BackingField;
			object obj2 = obj - 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v14 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			if ((nint)obj2 >= 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v14 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
			object obj3 = 0;
			object obj4 = obj - 1;
			object obj5 = obj & 0x80000001L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v10+18]");
			if ((nint)obj4 < 0)
			{
				object obj6 = obj5 - 1;
				object obj7 = obj6 | -2;
				obj5 = obj7 + 1;
			}
			if ((nint)obj5 == 1)
			{
				float2 item2 = (float2)(obj - 2);
				((List<float2>)(object)_003CFibonacciSequence_003Ek__BackingField).Add(item2);
				object obj8 = obj & 0x80000003L;
				if ((nint)_003CFibonacciSequence_003Ek__BackingField < 0)
				{
					object obj9 = obj8 - 1;
					object obj10 = obj9 | -4;
					obj8 = obj10 + 1;
				}
				if ((nint)obj8 == 3)
				{
				}
			}
			object obj11 = obj & 1;
			bool flag = obj11 == null;
			object obj12 = !flag;
			if (obj12 == null)
			{
				float2 item3 = (float2)(obj - 2);
				((List<float2>)(object)_003CFibonacciSequence_003Ek__BackingField).Add(item3);
				object obj13 = obj & 0x80000003L;
				if ((nint)_003CFibonacciSequence_003Ek__BackingField < 0)
				{
					object obj14 = obj13 - 1;
					object obj15 = obj14 | -4;
					obj13 = obj15 + 1;
				}
				if (obj13 != null)
				{
					continue;
				}
			}
			_003CFibonacciOffsets_003Ek__BackingField.Add(item);
			obj++;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)15f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public override void Fire(bool skipTriggers = false)
	{
		base.Fire(skipTriggers);
		Action onComplete = CheckForWeaponTrigger;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void CheckForWeaponTrigger()
	{
		//IL_0053: Expected O, but got I
		List<float> critChancesArray = _critChancesArray;
		int critIndex = _critIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		int num = (int)((nint)critIndex % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)num < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			int critIndex2 = _critIndex + 1;
			_critIndex = critIndex2;
			float weaponTriggerChance = WeaponTriggerChance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rcx_v7+20+v49 @ rdx_v5 (System.Int32)*4]");
			object obj2 = default(object);
			if ((nint)obj2 > 0)
			{
				int numWeaponsToTrigger = NumWeaponsToTrigger;
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 112 Invalid \"Jump target not found in method: 0x1874E0960\"");
			}
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	protected unsafe void TriggerOtherWeapons(int numWeapons)
	{
		//IL_0107: Expected I, but got O
		//IL_0115: Expected I, but got O
		//IL_0125: Expected O, but got I
		//IL_01a5: Expected O, but got I4
		//IL_0161: Expected O, but got I
		//IL_0280: Expected O, but got I4
		//IL_01b2: Expected I4, but got O
		//IL_0197: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
		if (((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField != null)
		{
			List<object> list = new List<object>(((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField);
			List<Equipment> weapons = default(List<Equipment>);
			RemoveProblematicWeapons(ref weapons);
			if (numWeapons <= 0)
			{
				return;
			}
			bool flag = false;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			do
			{
				_003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass23_0();
				CS_0024_003C_003E8__locals7._003C_003E4__this = this;
				if (weapons._size == 0)
				{
					break;
				}
				Equipment equipment = Extensions.PickRnd(weapons);
				bool flag2;
				if ((object)equipment == null)
				{
					flag2 = false;
					goto IL_0273;
				}
				nint num = (nint)equipment;
				nint num2 = (nint)typeof(Weapon);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				object obj3;
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v32+FFFFFFF8+v493 @ rax_v27*8]");
					if (0 == (nint)typeof(Weapon))
					{
						obj3 = 1;
						goto IL_02bb;
					}
				}
				obj3 = 0;
				goto IL_02bb;
				IL_0273:
				CS_0024_003C_003E8__locals7.w = (Weapon)flag2;
				bool flag3 = ((List<object>)(object)weapons).Remove((object)CS_0024_003C_003E8__locals7.w);
				CS_0024_003C_003E8__locals7.localI = (flag ? 1 : 0);
				Action action = delegate
				{
					//IL_0026: Expected I, but got O
					//IL_0050: Expected I, but got O
					//IL_0060: Expected O, but got I
					//IL_009c: Expected O, but got I
					//IL_0145: Expected O, but got I4
					//IL_00d9: Expected O, but got I
					//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
					//IL_00f4: Expected O, but got Unknown
					Weapon w = CS_0024_003C_003E8__locals7.w;
					bool flag5 = ((Equipment)w)._equipmentType == WeaponType.LEM_PLANETS2;
					nint num5 = (nint)w;
					if (flag5)
					{
						nint num6 = (nint)typeof(LEM_Planets2_Weapon);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Planets2_Weapon>)+130]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
						nint num7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Planets2_Weapon>)+130]");
						if (num7 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v11+FFFFFFF8+v66 @ rax_v10*8]");
							if (0 == (nint)typeof(LEM_Planets2_Weapon))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Planets2_Weapon>)+130]");
								object obj6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v11+FFFFFFF8+v223 @ rcx_v10*8]");
								object obj7 = 0 - typeof(LEM_Planets2_Weapon);
								bool flag6 = obj7 == null;
								bool flag7 = !flag6;
								LEM_Planets1_Weapon lEM_Planets1_Weapon = null;
								if (!flag7)
								{
									lEM_Planets1_Weapon = (LEM_Planets1_Weapon)w;
								}
								lEM_Planets1_Weapon.ToggleNegative(true);
								goto IL_012e;
							}
						}
						throw new NullReferenceException();
					}
					w.Fire();
					goto IL_012e;
					IL_012e:
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
					soundConfig.Volume = (float?)(object)1;
					soundConfig.Rate = 1f;
					float detune = (float)CS_0024_003C_003E8__locals7.localI * 100f;
					soundConfig.Detune = detune;
					float time = default(float);
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.sfx_paradoxMist, soundConfig, 0f, 10, time);
				};
				action._002Ector(CS_0024_003C_003E8__locals7, (nint)__ldftn(_003C_003Ec__DisplayClass23_0._003CTriggerOtherWeapons_003Eb__0));
				float num4 = (float)(flag ? 1 : 0) * 200f;
				float duration = num4 * 0.001f;
				Timer timer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
				continue;
				IL_02bb:
				bool flag4 = obj3 == null;
				flag2 = false;
				if (!flag4)
				{
					flag2 = (byte)(int)equipment != 0;
				}
				goto IL_0273;
			}
			while ((flag ? 1 : 0) < numWeapons);
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	private void RemoveProblematicWeapons(ref List<Equipment> weapons)
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0940: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_096f: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_0997: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_09bf: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_0262: Expected O, but got I
		//IL_02bc: Expected O, but got I
		//IL_09f6: Expected O, but got I
		//IL_0326: Expected O, but got I
		//IL_0a1e: Expected O, but got I
		//IL_0390: Expected O, but got I
		//IL_0a46: Expected O, but got I
		//IL_03fa: Expected O, but got I
		//IL_0a6e: Expected O, but got I
		//IL_0464: Expected O, but got I
		//IL_0a96: Expected O, but got I
		//IL_04ce: Expected O, but got I
		//IL_0abe: Expected O, but got I
		//IL_0538: Expected O, but got I
		//IL_0ae6: Expected O, but got I
		//IL_05a2: Expected O, but got I
		//IL_0b0e: Expected O, but got I
		//IL_060c: Expected O, but got I
		//IL_0b36: Expected O, but got I
		//IL_0676: Expected O, but got I
		//IL_069e: Expected O, but got I4
		//IL_0706: Expected I, but got O
		//IL_070e: Expected I, but got O
		//IL_071e: Expected O, but got I
		//IL_079e: Expected O, but got I4
		//IL_075a: Expected O, but got I
		//IL_0790: Expected O, but got I4
		//IL_08ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f4: Expected O, but got Unknown
		//IL_08ff: Expected O, but got I4
		//IL_0866: Expected O, but got I
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdx_v5+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1499);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1499;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v7+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1440);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1440;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v9+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1705);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1705;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v11+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1706);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1706;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdx_v13+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1707);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1707;
		}
		List<WeaponType> list2 = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rdx_v16+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)26);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 26;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v18+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)210);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 210;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdx_v20+18]");
		if (num8 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)93);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 93;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdx_v22+18]");
		if (num9 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1470);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 1470;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rdx_v24+18]");
		if (num10 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1563);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 1563;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rdx_v26+18]");
		if (num11 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1612);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 1612;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rdx_v28+18]");
		if (num12 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1496);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 1496;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rdx_v30+18]");
		if (num13 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1500);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 1500;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdx_v32+18]");
		if (num14 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1701);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 1701;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdx_v34+18]");
		if (num15 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1702);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 1702;
		}
		List<Equipment> list3 = weapons;
		bool flag = (nint)weapons < 0;
		object obj31 = list3._size - 1;
		if (flag)
		{
			return;
		}
		object obj35 = default(object);
		nint num19 = default(nint);
		object obj36 = default(object);
		while (true)
		{
			List<Equipment> list4 = weapons;
			if ((nint)obj31 >= list4._size)
			{
				break;
			}
			Equipment[] items = list4._items;
			Equipment equipment = items[obj31];
			nint num16 = (nint)typeof(Weapon);
			nint num17 = (nint)equipment;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdx_v37 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			object obj32 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
			nint num18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdx_v37 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			object obj34;
			if (num18 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
				object obj33 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1245 @ rax_v47+FFFFFFF8+v1231 @ rax_v32*8]");
				if (0 == (nint)typeof(Weapon))
				{
					obj34 = 1;
					goto IL_0b64;
				}
			}
			obj34 = 0;
			goto IL_0b64;
			IL_0b64:
			bool flag2 = obj34 == null;
			object item = null;
			if (!flag2)
			{
				item = equipment;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num20;
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				num17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				bool flag3 = (nint)obj35 != -1;
				num19 = 0;
				equipment = null;
				num20 = 0;
				if (flag3)
				{
					goto IL_08b2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
			bool flag4 = (nint)obj36 < 0;
			if (obj36 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rsi_v6 (System.Object)+98]");
				object obj37 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v39+18]");
				flag4 = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v39+18]");
				bool flag5 = (nint)0 <= (nint)0;
				num20 = num19;
				if (!flag5)
				{
					goto IL_08b2;
				}
			}
			goto IL_08e6;
			IL_08e6:
			obj31--;
			object obj38 = !flag4;
			if (obj38 == null)
			{
				return;
			}
			continue;
			IL_08b2:
			flag4 = (nint)weapons < 0;
			bool flag6 = ((List<object>)(object)weapons).Remove(item);
			num19 = num20;
			goto IL_08e6;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new IndexOutOfRangeException();
	}

	private void TriggerWeapon(Weapon weapon)
	{
		//IL_0021: Expected I, but got O
		//IL_0047: Expected I, but got O
		//IL_0057: Expected O, but got I
		//IL_0093: Expected O, but got I
		//IL_00d0: Expected O, but got I
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		bool flag = ((Equipment)weapon)._equipmentType == WeaponType.LEM_PLANETS2;
		nint num = (nint)weapon;
		if (!flag)
		{
			weapon.Fire();
			return;
		}
		nint num2 = (nint)typeof(LEM_Planets2_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Planets2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Planets2_Weapon>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v5+FFFFFFF8+v55 @ rax_v4*8]");
			if (0 == (nint)typeof(LEM_Planets2_Weapon))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Planets2_Weapon>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v5+FFFFFFF8+v129 @ rcx_v4*8]");
				object obj4 = 0 - typeof(LEM_Planets2_Weapon);
				bool flag2 = obj4 == null;
				bool flag3 = !flag2;
				LEM_Planets1_Weapon lEM_Planets1_Weapon = null;
				if (!flag3)
				{
					lEM_Planets1_Weapon = (LEM_Planets1_Weapon)weapon;
				}
				lEM_Planets1_Weapon.ToggleNegative(true);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void SetVisible(bool visible)
	{
		//IL_0038: Expected O, but got I4
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		_isVisible = visible;
		if (visible)
		{
			return;
		}
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		bool flag = (nint)_spawnedProjectiles < 0;
		object obj = spawnedProjectiles._size - 1;
		if (flag)
		{
			return;
		}
		while (true)
		{
			List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
			if ((nint)obj >= spawnedProjectiles2._size)
			{
				break;
			}
			Projectile[] items = spawnedProjectiles2._items;
			items[obj].Despawn();
			obj--;
			if ((nint)items[obj] < 0)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}
}
