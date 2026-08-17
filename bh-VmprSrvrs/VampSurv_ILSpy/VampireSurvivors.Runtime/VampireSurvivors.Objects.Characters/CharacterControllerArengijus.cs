using System;
using System.Runtime.CompilerServices;
using Coherence.Toolkit;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerArengijus : CharacterController
{
	private int _003CNameIndex_003Ek__BackingField;

	private uint _003CInitializationSeed_003Ek__BackingField;

	private Unity.Mathematics.Random _initializationRng;

	public int SyncedStartingWeaponType
	{
		get
		{
			return (int)_startingWeaponType;
		}
		set
		{
			_startingWeaponType = (WeaponType)value;
		}
	}

	public int NameIndex
	{
		get
		{
			return _003CNameIndex_003Ek__BackingField;
		}
		set
		{
			_003CNameIndex_003Ek__BackingField = value;
		}
	}

	public uint InitializationSeed
	{
		get
		{
			return _003CInitializationSeed_003Ek__BackingField;
		}
		set
		{
			_003CInitializationSeed_003Ek__BackingField = value;
		}
	}

	protected unsafe override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00ab: Expected I4, but got O
		//IL_2262: Expected O, but got I8
		//IL_22cb: Expected O, but got I4
		//IL_0077: Expected O, but got I
		//IL_220b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2210: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_00dd: Expected O, but got I8
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Expected O, but got Unknown
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f6: Expected O, but got Unknown
		//IL_04ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Expected O, but got Unknown
		//IL_05a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a8: Expected O, but got Unknown
		//IL_067c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0681: Expected O, but got Unknown
		//IL_0755: Unknown result type (might be due to invalid IL or missing references)
		//IL_075a: Expected O, but got Unknown
		//IL_082e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0833: Expected O, but got Unknown
		//IL_08f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fc: Expected O, but got Unknown
		//IL_09d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d5: Expected O, but got Unknown
		//IL_0aa9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aae: Expected O, but got Unknown
		//IL_0b82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b87: Expected O, but got Unknown
		//IL_0c4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c50: Expected O, but got Unknown
		//IL_0d14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d19: Expected O, but got Unknown
		//IL_0dc7: Expected O, but got Ref
		//IL_0e3d: Expected O, but got Ref
		//IL_0e02: Expected I, but got O
		//IL_0ec2: Expected O, but got Ref
		//IL_0e78: Expected I, but got O
		//IL_0f45: Expected O, but got Ref
		//IL_0efb: Expected I, but got O
		//IL_0fc8: Expected O, but got Ref
		//IL_0f7e: Expected I, but got O
		//IL_103c: Expected O, but got Ref
		//IL_1050: Expected native int or pointer, but got O
		//IL_1068: Expected O, but got Ref
		//IL_1001: Expected I, but got O
		//IL_10c5: Expected O, but got Ref
		//IL_114d: Expected O, but got Ref
		//IL_1103: Expected I, but got O
		//IL_11d0: Expected O, but got Ref
		//IL_1186: Expected I, but got O
		//IL_1253: Expected O, but got Ref
		//IL_1209: Expected I, but got O
		//IL_12d6: Expected O, but got Ref
		//IL_128c: Expected I, but got O
		//IL_134a: Expected O, but got Ref
		//IL_135e: Expected native int or pointer, but got O
		//IL_1376: Expected O, but got Ref
		//IL_130f: Expected I, but got O
		//IL_1441: Unknown result type (might be due to invalid IL or missing references)
		//IL_1446: Expected O, but got Unknown
		//IL_150a: Unknown result type (might be due to invalid IL or missing references)
		//IL_150f: Expected O, but got Unknown
		//IL_15d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d8: Expected O, but got Unknown
		//IL_16e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e6: Expected O, but got Unknown
		//IL_17aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_17af: Expected O, but got Unknown
		//IL_1873: Unknown result type (might be due to invalid IL or missing references)
		//IL_1878: Expected O, but got Unknown
		//IL_1981: Unknown result type (might be due to invalid IL or missing references)
		//IL_1986: Expected O, but got Unknown
		//IL_1a4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a4f: Expected O, but got Unknown
		//IL_1b13: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b18: Expected O, but got Unknown
		//IL_1c21: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c26: Expected O, but got Unknown
		//IL_1cea: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cef: Expected O, but got Unknown
		//IL_1db3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1db8: Expected O, but got Unknown
		//IL_1ec1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ec6: Expected O, but got Unknown
		//IL_1f8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f8f: Expected O, but got Unknown
		//IL_2053: Unknown result type (might be due to invalid IL or missing references)
		//IL_2058: Expected O, but got Unknown
		//IL_0e25->IL0e25: Incompatible stack heights: 1 vs 0
		//IL_0e9b->IL0e9b: Incompatible stack heights: 1 vs 0
		//IL_0f1e->IL0f1e: Incompatible stack heights: 1 vs 0
		//IL_0fa1->IL0fa1: Incompatible stack heights: 1 vs 0
		//IL_1024->IL1024: Incompatible stack heights: 1 vs 0
		//IL_1126->IL1126: Incompatible stack heights: 1 vs 0
		//IL_11a9->IL11a9: Incompatible stack heights: 1 vs 0
		//IL_122c->IL122c: Incompatible stack heights: 1 vs 0
		//IL_12af->IL12af: Incompatible stack heights: 1 vs 0
		//IL_1332->IL1332: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.MakeLevelOne();
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		bool flag4;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rcx_v259 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rcx_v259 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rcx_v259 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj3 = -3;
				bool flag2 = obj3 == null;
				flag = flag2;
			}
			bool flag3 = !flag;
			flag4 = false;
			if (flag3)
			{
				goto IL_2255;
			}
		}
		uint num = (uint)UnityEngine.Random.RandomRangeInt(1, 2147483647);
		_003CInitializationSeed_003Ek__BackingField = num;
		CharacterData currentCharacterData = _currentCharacterData;
		int num2 = (object?)currentCharacterData._003CnameIndex_003Ek__BackingField >> 32;
		_003CNameIndex_003Ek__BackingField = num2;
		flag4 = true;
		goto IL_2255;
		IL_2255:
		object obj4 = 6442450944L;
		int num3 = (int)(_003CInitializationSeed_003Ek__BackingField << 13);
		int num4 = (int)_003CInitializationSeed_003Ek__BackingField ^ num3;
		int num5 = num4 >> 17;
		int num6 = num4 ^ num5;
		int num7 = num6 << 5;
		int num8 = num7 ^ num6;
		int num9 = _003CNameIndex_003Ek__BackingField;
		_initializationRng = (Unity.Mathematics.Random)num8;
		ModifierStats onEveryLevelUp = default(ModifierStats);
		object obj9 = default(object);
		if (_003CNameIndex_003Ek__BackingField <= 7)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r15_v13+759BF9C+v870 @ rax_v44 (System.Int32)*4]");
			object obj5 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v930 @ rcx_v254 (should have been resolved before IL gen)");
		}
		else
		{
			onEveryLevelUp = base._onEveryLevelUp;
			object obj6 = (object)_initializationRng << 13;
			object obj7 = obj6 ^ (object)_initializationRng;
			object obj8 = (object)_initializationRng >> 9;
			obj9 = obj8 | 0x3F800000;
			object obj10 = obj7 >> 17;
			object obj11 = obj7 ^ obj10;
			object obj12 = obj11 << 5;
			Unity.Mathematics.Random initializationRng = (Unity.Mathematics.Random)(obj12 ^ obj11);
			_initializationRng = initializationRng;
		}
		float num10 = (float)obj9 - 1f;
		float num11 = num10 - 0.025f;
		float num12 = num11 * 1f;
		onEveryLevelUp._003CMaxHp_003Ek__BackingField = num12;
		ModifierStats onEveryLevelUp2 = base._onEveryLevelUp;
		object obj13 = (object)_initializationRng << 13;
		object obj14 = obj13 ^ (object)_initializationRng;
		object obj15 = (object)_initializationRng >> 9;
		object obj16 = obj15 | 0x3F800000;
		object obj17 = obj14 >> 17;
		object obj18 = obj14 ^ obj17;
		object obj19 = obj18 << 5;
		Unity.Mathematics.Random initializationRng2 = (Unity.Mathematics.Random)(obj19 ^ obj18);
		_initializationRng = initializationRng2;
		float num13 = (float)obj16 - 1f;
		float num14 = num13 - 0.1f;
		float num15 = num14 * 0.01f;
		float num16 = num15 * 1f;
		onEveryLevelUp2._003CRegen_003Ek__BackingField = num16;
		ModifierStats onEveryLevelUp3 = base._onEveryLevelUp;
		object obj20 = (object)_initializationRng << 13;
		object obj21 = obj20 ^ (object)_initializationRng;
		object obj22 = (object)_initializationRng >> 9;
		object obj23 = obj22 | 0x3F800000;
		object obj24 = obj21 >> 17;
		object obj25 = obj21 ^ obj24;
		object obj26 = obj25 << 5;
		Unity.Mathematics.Random initializationRng3 = (Unity.Mathematics.Random)(obj26 ^ obj25);
		_initializationRng = initializationRng3;
		float num17 = (float)obj23 - 1f;
		float num18 = num17 - 0.1f;
		float num19 = num18 * 0.01f;
		float num20 = num19 * 1f;
		onEveryLevelUp3._003CArmor_003Ek__BackingField = num20;
		ModifierStats onEveryLevelUp4 = base._onEveryLevelUp;
		object obj27 = (object)_initializationRng << 13;
		object obj28 = obj27 ^ (object)_initializationRng;
		object obj29 = (object)_initializationRng >> 9;
		object obj30 = obj29 | 0x3F800000;
		object obj31 = obj28 >> 17;
		object obj32 = obj28 ^ obj31;
		object obj33 = obj32 << 5;
		Unity.Mathematics.Random initializationRng4 = (Unity.Mathematics.Random)(obj33 ^ obj32);
		_initializationRng = initializationRng4;
		float num21 = (float)obj30 - 1f;
		float num22 = num21 - 0.1f;
		float num23 = num22 * 0.01f;
		float num24 = num23 * 1f;
		onEveryLevelUp4._003CAmount_003Ek__BackingField = num24;
		ModifierStats onEveryLevelUp5 = base._onEveryLevelUp;
		object obj34 = (object)_initializationRng << 13;
		object obj35 = obj34 ^ (object)_initializationRng;
		object obj36 = (object)_initializationRng >> 9;
		object obj37 = obj36 | 0x3F800000;
		object obj38 = obj35 >> 17;
		object obj39 = obj35 ^ obj38;
		object obj40 = obj39 << 5;
		Unity.Mathematics.Random initializationRng5 = (Unity.Mathematics.Random)(obj40 ^ obj39);
		_initializationRng = initializationRng5;
		float num25 = (float)obj37 - 1f;
		float num26 = num25 - 0.1f;
		float num27 = num26 * 0.01f;
		float num28 = num27 * 1f;
		onEveryLevelUp5._003CRevivals_003Ek__BackingField = num28;
		ModifierStats onEveryLevelUp6 = base._onEveryLevelUp;
		object obj41 = (object)_initializationRng << 13;
		object obj42 = obj41 ^ (object)_initializationRng;
		object obj43 = (object)_initializationRng >> 9;
		object obj44 = obj43 | 0x3F800000;
		object obj45 = obj42 >> 17;
		object obj46 = obj42 ^ obj45;
		object obj47 = obj46 << 5;
		Unity.Mathematics.Random initializationRng6 = (Unity.Mathematics.Random)(obj47 ^ obj46);
		_initializationRng = initializationRng6;
		float num29 = (float)obj44 - 1f;
		float num30 = num29 - 0.1f;
		float num31 = num30 * 0.003f;
		float num32 = num31 * 1f;
		onEveryLevelUp6._003CMagnet_003Ek__BackingField = num32;
		ModifierStats onEveryLevelUp7 = base._onEveryLevelUp;
		object obj48 = (object)_initializationRng << 13;
		object obj49 = obj48 ^ (object)_initializationRng;
		object obj50 = (object)_initializationRng >> 9;
		object obj51 = obj50 | 0x3F800000;
		object obj52 = obj49 >> 17;
		object obj53 = obj49 ^ obj52;
		object obj54 = obj53 << 5;
		Unity.Mathematics.Random initializationRng7 = (Unity.Mathematics.Random)(obj54 ^ obj53);
		_initializationRng = initializationRng7;
		float num33 = (float)obj51 - 1f;
		float num34 = num33 - 0.1f;
		float num35 = num34 * 0.01f;
		float num36 = num35 * 1f;
		onEveryLevelUp7._003CSpeed_003Ek__BackingField = num36;
		ModifierStats onEveryLevelUp8 = base._onEveryLevelUp;
		object obj55 = (object)_initializationRng << 13;
		object obj56 = obj55 ^ (object)_initializationRng;
		object obj57 = (object)_initializationRng >> 9;
		object obj58 = obj57 | 0x3F800000;
		object obj59 = obj56 >> 17;
		object obj60 = obj56 ^ obj59;
		object obj61 = obj60 << 5;
		Unity.Mathematics.Random initializationRng8 = (Unity.Mathematics.Random)(obj61 ^ obj60);
		_initializationRng = initializationRng8;
		float num37 = (float)obj58 - 1f;
		float num38 = num37 - 0.2f;
		float num39 = num38 * 0.01f;
		float num40 = num39 * 1f;
		onEveryLevelUp8._003CMoveSpeed_003Ek__BackingField = num40;
		ModifierStats onEveryLevelUp9 = base._onEveryLevelUp;
		object obj62 = (object)_initializationRng << 13;
		object obj63 = obj62 ^ (object)_initializationRng;
		object obj64 = (object)_initializationRng >> 9;
		object obj65 = obj64 | 0x3F800000;
		object obj66 = obj63 >> 17;
		object obj67 = obj63 ^ obj66;
		object obj68 = obj67 << 5;
		Unity.Mathematics.Random initializationRng9 = (Unity.Mathematics.Random)(obj68 ^ obj67);
		_initializationRng = initializationRng9;
		float num41 = (float)obj65 - 1f;
		float num42 = num41 - 0.1f;
		float num43 = num42 * 0.01f;
		float num44 = num43 * 1f;
		onEveryLevelUp9._003CPower_003Ek__BackingField = num44;
		ModifierStats onEveryLevelUp10 = base._onEveryLevelUp;
		object obj69 = (object)_initializationRng << 13;
		object obj70 = obj69 ^ (object)_initializationRng;
		object obj71 = (object)_initializationRng >> 9;
		object obj72 = obj71 | 0x3F800000;
		object obj73 = obj70 >> 17;
		object obj74 = obj70 ^ obj73;
		object obj75 = obj74 << 5;
		Unity.Mathematics.Random initializationRng10 = (Unity.Mathematics.Random)(obj75 ^ obj74);
		_initializationRng = initializationRng10;
		float num45 = (float)obj72 - 1f;
		float num46 = num45 - 0.05f;
		float num47 = num46 * -0.005f;
		onEveryLevelUp10._003CCooldown_003Ek__BackingField = num47;
		ModifierStats onEveryLevelUp11 = base._onEveryLevelUp;
		object obj76 = (object)_initializationRng << 13;
		object obj77 = obj76 ^ (object)_initializationRng;
		object obj78 = (object)_initializationRng >> 9;
		object obj79 = obj78 | 0x3F800000;
		object obj80 = obj77 >> 17;
		object obj81 = obj77 ^ obj80;
		object obj82 = obj81 << 5;
		Unity.Mathematics.Random initializationRng11 = (Unity.Mathematics.Random)(obj82 ^ obj81);
		_initializationRng = initializationRng11;
		float num48 = (float)obj79 - 1f;
		float num49 = num48 - 0.1f;
		float num50 = num49 * 0.01f;
		float num51 = num50 * 1f;
		onEveryLevelUp11._003CArea_003Ek__BackingField = num51;
		ModifierStats onEveryLevelUp12 = base._onEveryLevelUp;
		object obj83 = (object)_initializationRng << 13;
		object obj84 = obj83 ^ (object)_initializationRng;
		object obj85 = (object)_initializationRng >> 9;
		object obj86 = obj85 | 0x3F800000;
		object obj87 = obj84 >> 17;
		object obj88 = obj84 ^ obj87;
		object obj89 = obj88 << 5;
		Unity.Mathematics.Random initializationRng12 = (Unity.Mathematics.Random)(obj89 ^ obj88);
		_initializationRng = initializationRng12;
		float num52 = (float)obj86 - 1f;
		float num53 = num52 - 0.1f;
		float num54 = num53 * 0.01f;
		float num55 = num54 * 1f;
		onEveryLevelUp12._003CDuration_003Ek__BackingField = num55;
		ModifierStats onEveryLevelUp13 = base._onEveryLevelUp;
		object obj90 = (object)_initializationRng << 13;
		object obj91 = obj90 ^ (object)_initializationRng;
		object obj92 = (object)_initializationRng >> 9;
		object obj93 = obj92 | 0x3F800000;
		object obj94 = obj91 >> 17;
		object obj95 = obj91 ^ obj94;
		object obj96 = obj95 << 5;
		Unity.Mathematics.Random initializationRng13 = (Unity.Mathematics.Random)(obj96 ^ obj95);
		_initializationRng = initializationRng13;
		float num56 = (float)obj93 - 1f;
		float num57 = num56 - 0.1f;
		float num58 = num57 * 0.01f;
		float num59 = num58 * 1f;
		onEveryLevelUp13._003CLuck_003Ek__BackingField = num59;
		ModifierStats onEveryLevelUp14 = base._onEveryLevelUp;
		object obj97 = (object)_initializationRng << 13;
		object obj98 = obj97 ^ (object)_initializationRng;
		object obj99 = (object)_initializationRng >> 9;
		object obj100 = obj99 | 0x3F800000;
		object obj101 = obj98 >> 17;
		object obj102 = obj98 ^ obj101;
		object obj103 = obj102 << 5;
		Unity.Mathematics.Random initializationRng14 = (Unity.Mathematics.Random)(obj103 ^ obj102);
		_initializationRng = initializationRng14;
		float num60 = (float)obj100 - 1f;
		float num61 = num60 - 0.1f;
		float num62 = num61 * 0.01f;
		onEveryLevelUp14._003CGrowth_003Ek__BackingField = num62;
		ModifierStats onEveryLevelUp15 = base._onEveryLevelUp;
		object obj104 = (object)_initializationRng << 13;
		object obj105 = obj104 ^ (object)_initializationRng;
		object obj106 = (object)_initializationRng >> 9;
		object obj107 = obj106 | 0x3F800000;
		object obj108 = obj105 >> 17;
		object obj109 = obj105 ^ obj108;
		object obj110 = obj109 << 5;
		Unity.Mathematics.Random initializationRng15 = (Unity.Mathematics.Random)(obj110 ^ obj109);
		_initializationRng = initializationRng15;
		float num63 = (float)obj107 - 1f;
		float num64 = num63 - 0.1f;
		float num65 = num64 * 0.01f;
		onEveryLevelUp15._003CGreed_003Ek__BackingField = num65;
		ModifierStats onEveryLevelUp16 = base._onEveryLevelUp;
		object obj111 = (object)_initializationRng << 13;
		object obj112 = obj111 ^ (object)_initializationRng;
		object obj113 = (object)_initializationRng >> 9;
		object obj114 = obj113 | 0x3F800000;
		object obj115 = obj112 >> 17;
		object obj116 = obj112 ^ obj115;
		object obj117 = obj116 << 5;
		Unity.Mathematics.Random initializationRng16 = (Unity.Mathematics.Random)(obj117 ^ obj116);
		_initializationRng = initializationRng16;
		float num66 = (float)obj114 - 1f;
		float num67 = num66 - 0.025f;
		float num68 = num67 * 0.01f;
		float num69 = num68 * 1f;
		onEveryLevelUp16._003CCurse_003Ek__BackingField = num69;
		object[] array = new object[5];
		object obj118 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		_ = _003CNameIndex_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj119 = default(object);
		if (obj119 != null)
		{
			nint num70 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj120 = default(object);
			bool flag5 = obj120 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj121 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		_ = _003CInitializationSeed_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj122 = default(object);
		if (obj122 != null)
		{
			nint num71 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj123 = default(object);
			bool flag6 = obj123 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		ModifierStats onEveryLevelUp17 = base._onEveryLevelUp;
		object obj124 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		_ = onEveryLevelUp17._003CMaxHp_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj125 = default(object);
		if (obj125 != null)
		{
			nint num72 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj126 = default(object);
			bool flag7 = obj126 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		ModifierStats onEveryLevelUp18 = base._onEveryLevelUp;
		object obj127 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		_ = onEveryLevelUp18._003CRegen_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj128 = default(object);
		if (obj128 != null)
		{
			nint num73 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj129 = default(object);
			bool flag8 = obj129 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		ModifierStats onEveryLevelUp19 = base._onEveryLevelUp;
		object obj130 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		_ = onEveryLevelUp19._003CArmor_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj131 = default(object);
		if (obj131 != null)
		{
			nint num74 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj132 = default(object);
			bool flag9 = obj132 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		System.ParamsArray paramsArray = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(array));
		System.ParamsArray args = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-69]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
		_ = 0;
		string text = string.FormatHelper((IFormatProvider)null, "<color=green>Init Rngesus. NameIndex: {0}. Seed: {1}. Hp: {2}. Regen: {3}. Armor: {4}.", args);
		object[] array2 = new object[5];
		ModifierStats onEveryLevelUp20 = base._onEveryLevelUp;
		object obj133 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		_ = onEveryLevelUp20._003CAmount_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj134 = default(object);
		if (obj134 != null)
		{
			nint num75 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj135 = default(object);
			bool flag10 = obj135 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		ModifierStats onEveryLevelUp21 = base._onEveryLevelUp;
		object obj136 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		_ = onEveryLevelUp21._003CRevivals_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj137 = default(object);
		if (obj137 != null)
		{
			nint num76 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj138 = default(object);
			bool flag11 = obj138 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		ModifierStats onEveryLevelUp22 = base._onEveryLevelUp;
		object obj139 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		_ = onEveryLevelUp22._003CMagnet_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj140 = default(object);
		if (obj140 != null)
		{
			nint num77 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj141 = default(object);
			bool flag12 = obj141 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		ModifierStats onEveryLevelUp23 = base._onEveryLevelUp;
		object obj142 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		_ = onEveryLevelUp23._003CSpeed_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj143 = default(object);
		if (obj143 != null)
		{
			nint num78 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj144 = default(object);
			bool flag13 = obj144 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		ModifierStats onEveryLevelUp24 = base._onEveryLevelUp;
		object obj145 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		_ = onEveryLevelUp24._003CPower_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj146 = default(object);
		if (obj146 != null)
		{
			nint num79 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj147 = default(object);
			bool flag14 = obj147 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		System.ParamsArray paramsArray2 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray2, new System.ParamsArray(array2));
		System.ParamsArray args2 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-39]");
		_ = 0;
		string text2 = string.FormatHelper((IFormatProvider)null, "Amount: {0}. Revivals: {1}. Magnet: {2}. Speed: {3}. Power: {4}</color>", args2);
		string message = text + text2;
		Debug.Log(message);
		CharacterData currentCharacterData2 = _currentCharacterData;
		SineBonusData sineBonusData = new SineBonusData();
		sineBonusData._003Cmin_003Ek__BackingField = 1f;
		sineBonusData._003Cmax_003Ek__BackingField = 1f;
		sineBonusData._003Cduration_003Ek__BackingField = 1f;
		object obj148 = (object)_initializationRng << 13;
		object obj149 = obj148 ^ (object)_initializationRng;
		object obj150 = (object)_initializationRng >> 9;
		object obj151 = obj150 | 0x3F800000;
		object obj152 = obj149 >> 17;
		object obj153 = obj149 ^ obj152;
		object obj154 = obj153 << 5;
		Unity.Mathematics.Random initializationRng17 = (Unity.Mathematics.Random)(obj154 ^ obj153);
		_initializationRng = initializationRng17;
		float num80 = (float)obj151 - 1f;
		float num81 = num80 + 0.1f;
		float num82 = num81 + num81;
		float num83 = num82 * 1f;
		sineBonusData._003Cmin_003Ek__BackingField = num83;
		object obj155 = (object)_initializationRng << 13;
		object obj156 = obj155 ^ (object)_initializationRng;
		object obj157 = (object)_initializationRng >> 9;
		object obj158 = obj157 | 0x3F800000;
		object obj159 = obj156 >> 17;
		object obj160 = obj156 ^ obj159;
		object obj161 = obj160 << 5;
		Unity.Mathematics.Random initializationRng18 = (Unity.Mathematics.Random)(obj161 ^ obj160);
		_initializationRng = initializationRng18;
		float num84 = (float)obj158 - 1f;
		float num85 = num84 + 0.1f;
		float num86 = num85 + num85;
		float num87 = num86 * 1f;
		sineBonusData._003Cmax_003Ek__BackingField = num87;
		object obj162 = (object)_initializationRng << 13;
		object obj163 = obj162 ^ (object)_initializationRng;
		object obj164 = (object)_initializationRng >> 9;
		object obj165 = obj164 | 0x3F800000;
		object obj166 = obj163 >> 17;
		object obj167 = obj163 ^ obj166;
		object obj168 = obj167 << 5;
		Unity.Mathematics.Random initializationRng19 = (Unity.Mathematics.Random)(obj168 ^ obj167);
		_initializationRng = initializationRng19;
		float num88 = (float)obj165 - 1f;
		float num89 = num88 + 0.1f;
		float num90 = num89 * 60000f;
		sineBonusData._003Cduration_003Ek__BackingField = num90;
		currentCharacterData2._003CsineMight_003Ek__BackingField = sineBonusData;
		CharacterData currentCharacterData3 = _currentCharacterData;
		SineBonusData sineBonusData2 = new SineBonusData();
		sineBonusData2._003Cmin_003Ek__BackingField = 1f;
		sineBonusData2._003Cmax_003Ek__BackingField = 1f;
		sineBonusData2._003Cduration_003Ek__BackingField = 1f;
		object obj169 = (object)_initializationRng << 13;
		object obj170 = obj169 ^ (object)_initializationRng;
		object obj171 = (object)_initializationRng >> 9;
		object obj172 = obj171 | 0x3F800000;
		object obj173 = obj170 >> 17;
		object obj174 = obj170 ^ obj173;
		object obj175 = obj174 << 5;
		Unity.Mathematics.Random initializationRng20 = (Unity.Mathematics.Random)(obj175 ^ obj174);
		_initializationRng = initializationRng20;
		float num91 = (float)obj172 - 1f;
		float num92 = num91 + 0.1f;
		float num93 = num92 + num92;
		float num94 = num93 * 1f;
		sineBonusData2._003Cmin_003Ek__BackingField = num94;
		object obj176 = (object)_initializationRng << 13;
		object obj177 = obj176 ^ (object)_initializationRng;
		object obj178 = (object)_initializationRng >> 9;
		object obj179 = obj178 | 0x3F800000;
		object obj180 = obj177 >> 17;
		object obj181 = obj177 ^ obj180;
		object obj182 = obj181 << 5;
		Unity.Mathematics.Random initializationRng21 = (Unity.Mathematics.Random)(obj182 ^ obj181);
		_initializationRng = initializationRng21;
		float num95 = (float)obj179 - 1f;
		float num96 = num95 + 0.1f;
		float num97 = num96 + num96;
		float num98 = num97 * 1f;
		sineBonusData2._003Cmax_003Ek__BackingField = num98;
		object obj183 = (object)_initializationRng << 13;
		object obj184 = obj183 ^ (object)_initializationRng;
		object obj185 = (object)_initializationRng >> 9;
		object obj186 = obj185 | 0x3F800000;
		object obj187 = obj184 >> 17;
		object obj188 = obj184 ^ obj187;
		object obj189 = obj188 << 5;
		Unity.Mathematics.Random initializationRng22 = (Unity.Mathematics.Random)(obj189 ^ obj188);
		_initializationRng = initializationRng22;
		float num99 = (float)obj186 - 1f;
		float num100 = num99 + 0.1f;
		float num101 = num100 * 60000f;
		sineBonusData2._003Cduration_003Ek__BackingField = num101;
		currentCharacterData3._003CsineSpeed_003Ek__BackingField = sineBonusData2;
		CharacterData currentCharacterData4 = _currentCharacterData;
		SineBonusData sineBonusData3 = new SineBonusData();
		sineBonusData3._003Cmin_003Ek__BackingField = 1f;
		sineBonusData3._003Cmax_003Ek__BackingField = 1f;
		sineBonusData3._003Cduration_003Ek__BackingField = 1f;
		object obj190 = (object)_initializationRng << 13;
		object obj191 = obj190 ^ (object)_initializationRng;
		object obj192 = (object)_initializationRng >> 9;
		object obj193 = obj192 | 0x3F800000;
		object obj194 = obj191 >> 17;
		object obj195 = obj191 ^ obj194;
		object obj196 = obj195 << 5;
		Unity.Mathematics.Random initializationRng23 = (Unity.Mathematics.Random)(obj196 ^ obj195);
		_initializationRng = initializationRng23;
		float num102 = (float)obj193 - 1f;
		float num103 = num102 + 0.1f;
		float num104 = num103 + num103;
		float num105 = num104 * 1f;
		sineBonusData3._003Cmin_003Ek__BackingField = num105;
		object obj197 = (object)_initializationRng << 13;
		object obj198 = obj197 ^ (object)_initializationRng;
		object obj199 = (object)_initializationRng >> 9;
		object obj200 = obj199 | 0x3F800000;
		object obj201 = obj198 >> 17;
		object obj202 = obj198 ^ obj201;
		object obj203 = obj202 << 5;
		Unity.Mathematics.Random initializationRng24 = (Unity.Mathematics.Random)(obj203 ^ obj202);
		_initializationRng = initializationRng24;
		float num106 = (float)obj200 - 1f;
		float num107 = num106 + 0.1f;
		float num108 = num107 + num107;
		float num109 = num108 * 1f;
		sineBonusData3._003Cmax_003Ek__BackingField = num109;
		object obj204 = (object)_initializationRng << 13;
		object obj205 = obj204 ^ (object)_initializationRng;
		object obj206 = (object)_initializationRng >> 9;
		object obj207 = obj206 | 0x3F800000;
		object obj208 = obj205 >> 17;
		object obj209 = obj205 ^ obj208;
		object obj210 = obj209 << 5;
		Unity.Mathematics.Random initializationRng25 = (Unity.Mathematics.Random)(obj210 ^ obj209);
		_initializationRng = initializationRng25;
		float num110 = (float)obj207 - 1f;
		float num111 = num110 + 0.1f;
		float num112 = num111 * 60000f;
		sineBonusData3._003Cduration_003Ek__BackingField = num112;
		currentCharacterData4._003CsineDuration_003Ek__BackingField = sineBonusData3;
		CharacterData currentCharacterData5 = _currentCharacterData;
		SineBonusData sineBonusData4 = new SineBonusData();
		sineBonusData4._003Cmin_003Ek__BackingField = 1f;
		sineBonusData4._003Cmax_003Ek__BackingField = 1f;
		sineBonusData4._003Cduration_003Ek__BackingField = 1f;
		object obj211 = (object)_initializationRng << 13;
		object obj212 = obj211 ^ (object)_initializationRng;
		object obj213 = (object)_initializationRng >> 9;
		object obj214 = obj213 | 0x3F800000;
		object obj215 = obj212 >> 17;
		object obj216 = obj212 ^ obj215;
		object obj217 = obj216 << 5;
		Unity.Mathematics.Random initializationRng26 = (Unity.Mathematics.Random)(obj217 ^ obj216);
		_initializationRng = initializationRng26;
		float num113 = (float)obj214 - 1f;
		float num114 = num113 + 0.1f;
		float num115 = num114 + num114;
		float num116 = num115 * 1f;
		sineBonusData4._003Cmin_003Ek__BackingField = num116;
		object obj218 = (object)_initializationRng << 13;
		object obj219 = obj218 ^ (object)_initializationRng;
		object obj220 = (object)_initializationRng >> 9;
		object obj221 = obj220 | 0x3F800000;
		object obj222 = obj219 >> 17;
		object obj223 = obj219 ^ obj222;
		object obj224 = obj223 << 5;
		Unity.Mathematics.Random initializationRng27 = (Unity.Mathematics.Random)(obj224 ^ obj223);
		_initializationRng = initializationRng27;
		float num117 = (float)obj221 - 1f;
		float num118 = num117 + 0.1f;
		float num119 = num118 + num118;
		float num120 = num119 * 1f;
		sineBonusData4._003Cmax_003Ek__BackingField = num120;
		object obj225 = (object)_initializationRng << 13;
		object obj226 = obj225 ^ (object)_initializationRng;
		object obj227 = (object)_initializationRng >> 9;
		object obj228 = obj227 | 0x3F800000;
		object obj229 = obj226 >> 17;
		object obj230 = obj226 ^ obj229;
		object obj231 = obj230 << 5;
		Unity.Mathematics.Random initializationRng28 = (Unity.Mathematics.Random)(obj231 ^ obj230);
		_initializationRng = initializationRng28;
		float num121 = (float)obj228 - 1f;
		float num122 = num121 + 0.1f;
		float num123 = num122 * 60000f;
		sineBonusData4._003Cduration_003Ek__BackingField = num123;
		currentCharacterData5._003CsineArea_003Ek__BackingField = sineBonusData4;
		CharacterData currentCharacterData6 = _currentCharacterData;
		SineBonusData sineBonusData5 = new SineBonusData();
		sineBonusData5._003Cmin_003Ek__BackingField = 1f;
		sineBonusData5._003Cmax_003Ek__BackingField = 1f;
		sineBonusData5._003Cduration_003Ek__BackingField = 1f;
		object obj232 = (object)_initializationRng << 13;
		object obj233 = obj232 ^ (object)_initializationRng;
		object obj234 = (object)_initializationRng >> 9;
		object obj235 = obj234 | 0x3F800000;
		object obj236 = obj233 >> 17;
		object obj237 = obj233 ^ obj236;
		object obj238 = obj237 << 5;
		Unity.Mathematics.Random initializationRng29 = (Unity.Mathematics.Random)(obj238 ^ obj237);
		_initializationRng = initializationRng29;
		float num124 = (float)obj235 - 1f;
		float num125 = num124 + 0.1f;
		float num126 = num125 + num125;
		float num127 = num126 * 1f;
		sineBonusData5._003Cmin_003Ek__BackingField = num127;
		object obj239 = (object)_initializationRng << 13;
		object obj240 = obj239 ^ (object)_initializationRng;
		object obj241 = (object)_initializationRng >> 9;
		object obj242 = obj241 | 0x3F800000;
		object obj243 = obj240 >> 17;
		object obj244 = obj240 ^ obj243;
		object obj245 = obj244 << 5;
		Unity.Mathematics.Random initializationRng30 = (Unity.Mathematics.Random)(obj245 ^ obj244);
		_initializationRng = initializationRng30;
		float num128 = (float)obj242 - 1f;
		float num129 = num128 + 0.1f;
		float num130 = num129 + num129;
		float num131 = num130 * 1f;
		sineBonusData5._003Cmax_003Ek__BackingField = num131;
		object obj246 = (object)_initializationRng << 13;
		object obj247 = obj246 ^ (object)_initializationRng;
		object obj248 = (object)_initializationRng >> 9;
		object obj249 = obj248 | 0x3F800000;
		object obj250 = obj247 >> 17;
		object obj251 = obj247 ^ obj250;
		object obj252 = obj251 << 5;
		Unity.Mathematics.Random initializationRng31 = (Unity.Mathematics.Random)(obj252 ^ obj251);
		_initializationRng = initializationRng31;
		float num132 = (float)obj249 - 1f;
		float num133 = num132 + 0.1f;
		float num134 = num133 * 60000f;
		sineBonusData5._003Cduration_003Ek__BackingField = num134;
		currentCharacterData6._003CsineCooldown_003Ek__BackingField = sineBonusData5;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		int num135 = config._003CPlayedRNJ_003Ek__BackingField + 1;
		config._003CPlayedRNJ_003Ek__BackingField = num135;
	}
}
