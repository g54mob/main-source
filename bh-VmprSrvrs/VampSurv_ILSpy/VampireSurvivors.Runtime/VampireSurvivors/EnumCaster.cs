using System;
using Cpp2ILInjected;
using VampireSurvivors.Data;

namespace VampireSurvivors;

public class EnumCaster<T>
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		static _003C_003Ec()
		{
			//IL_0035: Expected O, but got I
			//IL_004a: Expected O, but got I
			nint num = 0;
			object obj = null;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v10 (Il2CppRgctx<VampireSurvivors.EnumCaster`1+<>c>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v12+B8]");
			object obj3 = 0;
			obj3 = obj;
		}

		internal WeaponType _003C_002Ecctor_003Eb__4_0(byte b)
		{
			return (WeaponType)b;
		}

		internal WeaponType _003C_002Ecctor_003Eb__4_1(short b)
		{
			return (WeaponType)b;
		}

		internal WeaponType _003C_002Ecctor_003Eb__4_2(int b)
		{
			return (WeaponType)b;
		}

		internal WeaponType _003C_002Ecctor_003Eb__4_3(long b)
		{
			//IL_0005: Expected I4, but got I8
			return (WeaponType)b;
		}

		internal ItemType _003C_002Ecctor_003Eb__4_4(byte b)
		{
			return (ItemType)b;
		}

		internal ItemType _003C_002Ecctor_003Eb__4_5(short b)
		{
			return (ItemType)b;
		}

		internal ItemType _003C_002Ecctor_003Eb__4_6(int b)
		{
			return (ItemType)b;
		}

		internal ItemType _003C_002Ecctor_003Eb__4_7(long b)
		{
			//IL_0005: Expected I4, but got I8
			return (ItemType)b;
		}

		internal PrizeType _003C_002Ecctor_003Eb__4_8(byte b)
		{
			return (PrizeType)b;
		}

		internal PrizeType _003C_002Ecctor_003Eb__4_9(short b)
		{
			return (PrizeType)b;
		}

		internal PrizeType _003C_002Ecctor_003Eb__4_10(int b)
		{
			return (PrizeType)b;
		}

		internal PrizeType _003C_002Ecctor_003Eb__4_11(long b)
		{
			//IL_0005: Expected I4, but got I8
			return (PrizeType)b;
		}

		internal CharacterType _003C_002Ecctor_003Eb__4_12(byte b)
		{
			return (CharacterType)b;
		}

		internal CharacterType _003C_002Ecctor_003Eb__4_13(short b)
		{
			return (CharacterType)b;
		}

		internal CharacterType _003C_002Ecctor_003Eb__4_14(int b)
		{
			return (CharacterType)b;
		}

		internal CharacterType _003C_002Ecctor_003Eb__4_15(long b)
		{
			//IL_0005: Expected I4, but got I8
			return (CharacterType)b;
		}

		internal ArcanaType _003C_002Ecctor_003Eb__4_16(byte b)
		{
			return (ArcanaType)b;
		}

		internal ArcanaType _003C_002Ecctor_003Eb__4_17(short b)
		{
			return (ArcanaType)b;
		}

		internal ArcanaType _003C_002Ecctor_003Eb__4_18(int b)
		{
			return (ArcanaType)b;
		}

		internal ArcanaType _003C_002Ecctor_003Eb__4_19(long b)
		{
			//IL_0005: Expected I4, but got I8
			return (ArcanaType)b;
		}

		internal PowerUpType _003C_002Ecctor_003Eb__4_20(byte b)
		{
			return (PowerUpType)b;
		}

		internal PowerUpType _003C_002Ecctor_003Eb__4_21(short b)
		{
			return (PowerUpType)b;
		}

		internal PowerUpType _003C_002Ecctor_003Eb__4_22(int b)
		{
			return (PowerUpType)b;
		}

		internal PowerUpType _003C_002Ecctor_003Eb__4_23(long b)
		{
			//IL_0005: Expected I4, but got I8
			return (PowerUpType)b;
		}

		internal StageType _003C_002Ecctor_003Eb__4_24(byte b)
		{
			return (StageType)b;
		}

		internal StageType _003C_002Ecctor_003Eb__4_25(short b)
		{
			return (StageType)b;
		}

		internal StageType _003C_002Ecctor_003Eb__4_26(int b)
		{
			return (StageType)b;
		}

		internal StageType _003C_002Ecctor_003Eb__4_27(long b)
		{
			//IL_0005: Expected I4, but got I8
			return (StageType)b;
		}

		internal AchievementType _003C_002Ecctor_003Eb__4_28(byte b)
		{
			return (AchievementType)b;
		}

		internal AchievementType _003C_002Ecctor_003Eb__4_29(short b)
		{
			return (AchievementType)b;
		}

		internal AchievementType _003C_002Ecctor_003Eb__4_30(int b)
		{
			return (AchievementType)b;
		}

		internal AchievementType _003C_002Ecctor_003Eb__4_31(long b)
		{
			//IL_0005: Expected I4, but got I8
			return (AchievementType)b;
		}

		internal EnemyType _003C_002Ecctor_003Eb__4_32(byte b)
		{
			return (EnemyType)b;
		}

		internal EnemyType _003C_002Ecctor_003Eb__4_33(short b)
		{
			return (EnemyType)b;
		}

		internal EnemyType _003C_002Ecctor_003Eb__4_34(int b)
		{
			return (EnemyType)b;
		}

		internal EnemyType _003C_002Ecctor_003Eb__4_35(long b)
		{
			//IL_0005: Expected I4, but got I8
			return (EnemyType)b;
		}

		internal SkinType _003C_002Ecctor_003Eb__4_36(byte b)
		{
			return (SkinType)b;
		}

		internal SkinType _003C_002Ecctor_003Eb__4_37(short b)
		{
			return (SkinType)b;
		}

		internal SkinType _003C_002Ecctor_003Eb__4_38(int b)
		{
			return (SkinType)b;
		}

		internal SkinType _003C_002Ecctor_003Eb__4_39(long b)
		{
			//IL_0005: Expected I4, but got I8
			return (SkinType)b;
		}
	}

	public static readonly Func<byte, T> FromByte;

	public static readonly Func<short, T> FromShort;

	public static readonly Func<int, T> FromInt;

	public static readonly Func<long, T> FromLong;

	static EnumCaster()
	{
		//IL_002a: Expected O, but got I
		//IL_003f: Expected O, but got I
		//IL_0084: Expected O, but got I
		//IL_0099: Expected O, but got I
		//IL_00cc: Expected I, but got O
		//IL_0101: Expected O, but got I
		//IL_0116: Expected O, but got I
		//IL_0149: Expected I, but got O
		//IL_017e: Expected O, but got I
		//IL_0193: Expected O, but got I
		//IL_01c6: Expected I, but got O
		//IL_01fb: Expected O, but got I
		//IL_0210: Expected O, but got I
		//IL_0255: Expected O, but got I
		//IL_026a: Expected O, but got I
		//IL_029d: Expected I, but got O
		//IL_02d2: Expected O, but got I
		//IL_02e7: Expected O, but got I
		//IL_031a: Expected I, but got O
		//IL_034f: Expected O, but got I
		//IL_0364: Expected O, but got I
		//IL_0397: Expected I, but got O
		//IL_03cc: Expected O, but got I
		//IL_03e1: Expected O, but got I
		//IL_0426: Expected O, but got I
		//IL_043b: Expected O, but got I
		//IL_046e: Expected I, but got O
		//IL_04a3: Expected O, but got I
		//IL_04b8: Expected O, but got I
		//IL_04eb: Expected I, but got O
		//IL_0520: Expected O, but got I
		//IL_0535: Expected O, but got I
		//IL_0568: Expected I, but got O
		//IL_059d: Expected O, but got I
		//IL_05b2: Expected O, but got I
		//IL_05f7: Expected O, but got I
		//IL_060c: Expected O, but got I
		//IL_063f: Expected I, but got O
		//IL_0674: Expected O, but got I
		//IL_0689: Expected O, but got I
		//IL_06bc: Expected I, but got O
		//IL_06f1: Expected O, but got I
		//IL_0706: Expected O, but got I
		//IL_0739: Expected I, but got O
		//IL_076e: Expected O, but got I
		//IL_0783: Expected O, but got I
		//IL_07c8: Expected O, but got I
		//IL_07dd: Expected O, but got I
		//IL_0810: Expected I, but got O
		//IL_0845: Expected O, but got I
		//IL_085a: Expected O, but got I
		//IL_088d: Expected I, but got O
		//IL_08c2: Expected O, but got I
		//IL_08d7: Expected O, but got I
		//IL_090a: Expected I, but got O
		//IL_093f: Expected O, but got I
		//IL_0954: Expected O, but got I
		//IL_0999: Expected O, but got I
		//IL_09ae: Expected O, but got I
		//IL_09e1: Expected I, but got O
		//IL_0a16: Expected O, but got I
		//IL_0a2b: Expected O, but got I
		//IL_0a5e: Expected I, but got O
		//IL_0a93: Expected O, but got I
		//IL_0aa8: Expected O, but got I
		//IL_0adb: Expected I, but got O
		//IL_0b10: Expected O, but got I
		//IL_0b25: Expected O, but got I
		//IL_0b65: Expected O, but got I
		//IL_0b7a: Expected O, but got I
		//IL_0bad: Expected I, but got O
		//IL_0be2: Expected O, but got I
		//IL_0bf7: Expected O, but got I
		//IL_0c2a: Expected I, but got O
		//IL_0c5f: Expected O, but got I
		//IL_0c74: Expected O, but got I
		//IL_0ca7: Expected I, but got O
		//IL_0cdc: Expected O, but got I
		//IL_0cf1: Expected O, but got I
		//IL_0d31: Expected O, but got I
		//IL_0d46: Expected O, but got I
		//IL_0d79: Expected I, but got O
		//IL_0dae: Expected O, but got I
		//IL_0dc3: Expected O, but got I
		//IL_0df6: Expected I, but got O
		//IL_0e2b: Expected O, but got I
		//IL_0e40: Expected O, but got I
		//IL_0e73: Expected I, but got O
		//IL_0ea8: Expected O, but got I
		//IL_0ebd: Expected O, but got I
		//IL_0efd: Expected O, but got I
		//IL_0f12: Expected O, but got I
		//IL_0f45: Expected I, but got O
		//IL_0f7a: Expected O, but got I
		//IL_0f8f: Expected O, but got I
		//IL_0fc2: Expected I, but got O
		//IL_0ff7: Expected O, but got I
		//IL_100c: Expected O, but got I
		//IL_103f: Expected I, but got O
		//IL_1074: Expected O, but got I
		//IL_1089: Expected O, but got I
		//IL_10ce: Expected O, but got I
		//IL_10e3: Expected O, but got I
		//IL_1116: Expected I, but got O
		//IL_114b: Expected O, but got I
		//IL_1160: Expected O, but got I
		//IL_1193: Expected I, but got O
		//IL_11c8: Expected O, but got I
		//IL_11dd: Expected O, but got I
		//IL_1210: Expected I, but got O
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v10 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rax_v12+B8]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ r8_v1 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+10]");
		Func<byte, WeaponType> fromByte = new Func<byte, WeaponType>(obj2, (IntPtr)0);
		nint num2 = 0;
		EnumCaster<WeaponType>.FromByte = fromByte;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rax_v24 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rax_v26+B8]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ r8_v4 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+18]");
		Func<short, WeaponType> func = new Func<short, WeaponType>(obj4, (IntPtr)0);
		nint num4 = 0;
		nint num5 = (nint)typeof(EnumCaster<WeaponType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rax_v32 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.WeaponType>>)+B8]");
		nint num6 = 0;
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ rax_v36 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rax_v38+B8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ r8_v7 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+20]");
		Func<int, WeaponType> func2 = new Func<int, WeaponType>(obj6, (IntPtr)0);
		nint num8 = 0;
		nint num9 = (nint)typeof(EnumCaster<WeaponType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ rax_v44 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.WeaponType>>)+B8]");
		nint num10 = 0;
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rax_v48 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v50+B8]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ r8_v10 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+28]");
		Func<long, WeaponType> func3 = new Func<long, WeaponType>(obj8, (IntPtr)0);
		nint num12 = 0;
		nint num13 = (nint)typeof(EnumCaster<WeaponType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v600 @ rax_v56 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.WeaponType>>)+B8]");
		nint num14 = 0;
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v60 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v706 @ rax_v62+B8]");
		object obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v733 @ r8_v13 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+30]");
		Func<byte, ItemType> fromByte2 = new Func<byte, ItemType>(obj10, (IntPtr)0);
		nint num16 = 0;
		EnumCaster<ItemType>.FromByte = fromByte2;
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v847 @ rax_v74 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v864 @ rax_v76+B8]");
		object obj12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v891 @ r8_v16 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+38]");
		Func<short, ItemType> func4 = new Func<short, ItemType>(obj12, (IntPtr)0);
		nint num18 = 0;
		nint num19 = (nint)typeof(EnumCaster<ItemType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v899 @ rax_v82 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.ItemType>>)+B8]");
		nint num20 = 0;
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v988 @ rax_v86 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1005 @ rax_v88+B8]");
		object obj14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1032 @ r8_v19 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+40]");
		Func<int, ItemType> func5 = new Func<int, ItemType>(obj14, (IntPtr)0);
		nint num22 = 0;
		nint num23 = (nint)typeof(EnumCaster<ItemType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1040 @ rax_v94 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.ItemType>>)+B8]");
		nint num24 = 0;
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1129 @ rax_v98 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1144 @ rax_v100+B8]");
		object obj16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1165 @ r8_v22 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+48]");
		Func<long, ItemType> func6 = new Func<long, ItemType>(obj16, (IntPtr)0);
		nint num26 = 0;
		nint num27 = (nint)typeof(EnumCaster<ItemType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1170 @ rax_v106 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.ItemType>>)+B8]");
		nint num28 = 0;
		nint num29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1253 @ rax_v110 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1267 @ rax_v112+B8]");
		object obj18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1288 @ r8_v25 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+50]");
		Func<byte, PrizeType> fromByte3 = new Func<byte, PrizeType>(obj18, (IntPtr)0);
		nint num30 = 0;
		EnumCaster<PrizeType>.FromByte = fromByte3;
		nint num31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1390 @ rax_v124 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1404 @ rax_v126+B8]");
		object obj20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1425 @ r8_v28 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+58]");
		Func<short, PrizeType> func7 = new Func<short, PrizeType>(obj20, (IntPtr)0);
		nint num32 = 0;
		nint num33 = (nint)typeof(EnumCaster<PrizeType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1430 @ rax_v132 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.PrizeType>>)+B8]");
		nint num34 = 0;
		nint num35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1513 @ rax_v136 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rax_v138+B8]");
		object obj22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1548 @ r8_v31 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+60]");
		Func<int, PrizeType> func8 = new Func<int, PrizeType>(obj22, (IntPtr)0);
		nint num36 = 0;
		nint num37 = (nint)typeof(EnumCaster<PrizeType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1553 @ rax_v144 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.PrizeType>>)+B8]");
		nint num38 = 0;
		nint num39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1636 @ rax_v148 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1650 @ rax_v150+B8]");
		object obj24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ r8_v34 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+68]");
		Func<long, PrizeType> func9 = new Func<long, PrizeType>(obj24, (IntPtr)0);
		nint num40 = 0;
		nint num41 = (nint)typeof(EnumCaster<PrizeType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1676 @ rax_v156 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.PrizeType>>)+B8]");
		nint num42 = 0;
		nint num43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1759 @ rax_v160 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1773 @ rax_v162+B8]");
		object obj26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1794 @ r8_v37 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+70]");
		Func<byte, CharacterType> fromByte4 = new Func<byte, CharacterType>(obj26, (IntPtr)0);
		nint num44 = 0;
		EnumCaster<CharacterType>.FromByte = fromByte4;
		nint num45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1896 @ rax_v174 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1910 @ rax_v176+B8]");
		object obj28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1931 @ r8_v40 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+78]");
		Func<short, CharacterType> func10 = new Func<short, CharacterType>(obj28, (IntPtr)0);
		nint num46 = 0;
		nint num47 = (nint)typeof(EnumCaster<CharacterType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1936 @ rax_v182 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.CharacterType>>)+B8]");
		nint num48 = 0;
		nint num49 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2019 @ rax_v186 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2033 @ rax_v188+B8]");
		object obj30 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2054 @ r8_v43 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+80]");
		Func<int, CharacterType> func11 = new Func<int, CharacterType>(obj30, (IntPtr)0);
		nint num50 = 0;
		nint num51 = (nint)typeof(EnumCaster<CharacterType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2059 @ rax_v194 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.CharacterType>>)+B8]");
		nint num52 = 0;
		nint num53 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2142 @ rax_v198 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2156 @ rax_v200+B8]");
		object obj32 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2177 @ r8_v46 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+88]");
		Func<long, CharacterType> func12 = new Func<long, CharacterType>(obj32, (IntPtr)0);
		nint num54 = 0;
		nint num55 = (nint)typeof(EnumCaster<CharacterType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2182 @ rax_v206 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.CharacterType>>)+B8]");
		nint num56 = 0;
		nint num57 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2265 @ rax_v210 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2279 @ rax_v212+B8]");
		object obj34 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2300 @ r8_v49 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+90]");
		Func<byte, ArcanaType> fromByte5 = new Func<byte, ArcanaType>(obj34, (IntPtr)0);
		nint num58 = 0;
		EnumCaster<ArcanaType>.FromByte = fromByte5;
		nint num59 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2402 @ rax_v224 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2416 @ rax_v226+B8]");
		object obj36 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2437 @ r8_v52 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+98]");
		Func<short, ArcanaType> func13 = new Func<short, ArcanaType>(obj36, (IntPtr)0);
		nint num60 = 0;
		nint num61 = (nint)typeof(EnumCaster<ArcanaType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2442 @ rax_v232 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.ArcanaType>>)+B8]");
		nint num62 = 0;
		nint num63 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2525 @ rax_v236 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2539 @ rax_v238+B8]");
		object obj38 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2560 @ r8_v55 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+A0]");
		Func<int, ArcanaType> func14 = new Func<int, ArcanaType>(obj38, (IntPtr)0);
		nint num64 = 0;
		nint num65 = (nint)typeof(EnumCaster<ArcanaType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2565 @ rax_v244 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.ArcanaType>>)+B8]");
		nint num66 = 0;
		nint num67 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2648 @ rax_v248 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v250+B8]");
		object obj40 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2683 @ r8_v58 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+A8]");
		Func<long, ArcanaType> func15 = new Func<long, ArcanaType>(obj40, (IntPtr)0);
		nint num68 = 0;
		nint num69 = (nint)typeof(EnumCaster<ArcanaType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2688 @ rax_v256 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.ArcanaType>>)+B8]");
		nint num70 = 0;
		nint num71 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2771 @ rax_v260 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2785 @ rax_v262+B8]");
		object obj42 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2806 @ r8_v61 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+B0]");
		Func<byte, PowerUpType> fromByte6 = new Func<byte, PowerUpType>(obj42, (IntPtr)0);
		nint num72 = 0;
		EnumCaster<PowerUpType>.FromByte = fromByte6;
		nint num73 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2908 @ rax_v274 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2922 @ rax_v276+B8]");
		object obj44 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2943 @ r8_v64 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+B8]");
		Func<short, PowerUpType> func16 = new Func<short, PowerUpType>(obj44, (IntPtr)0);
		nint num74 = 0;
		nint num75 = (nint)typeof(EnumCaster<PowerUpType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2948 @ rax_v282 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.PowerUpType>>)+B8]");
		nint num76 = 0;
		nint num77 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3031 @ rax_v286 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3045 @ rax_v288+B8]");
		object obj46 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3066 @ r8_v67 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+C0]");
		Func<int, PowerUpType> func17 = new Func<int, PowerUpType>(obj46, (IntPtr)0);
		nint num78 = 0;
		nint num79 = (nint)typeof(EnumCaster<PowerUpType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3071 @ rax_v294 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.PowerUpType>>)+B8]");
		nint num80 = 0;
		nint num81 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3154 @ rax_v298 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj47 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3168 @ rax_v300+B8]");
		object obj48 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3189 @ r8_v70 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+C8]");
		Func<long, PowerUpType> func18 = new Func<long, PowerUpType>(obj48, (IntPtr)0);
		nint num82 = 0;
		nint num83 = (nint)typeof(EnumCaster<PowerUpType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3194 @ rax_v306 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.PowerUpType>>)+B8]");
		nint num84 = 0;
		nint num85 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3214 @ rax_v311 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj49 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3227 @ rax_v313+B8]");
		object obj50 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3248 @ r8_v72 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+D0]");
		Func<byte, StageType> fromByte7 = new Func<byte, StageType>(obj50, (IntPtr)0);
		nint num86 = 0;
		EnumCaster<StageType>.FromByte = fromByte7;
		nint num87 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3287 @ rax_v325 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj51 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3300 @ rax_v327+B8]");
		object obj52 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3321 @ r8_v74 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+D8]");
		Func<short, StageType> func19 = new Func<short, StageType>(obj52, (IntPtr)0);
		nint num88 = 0;
		nint num89 = (nint)typeof(EnumCaster<StageType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3326 @ rax_v333 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.StageType>>)+B8]");
		nint num90 = 0;
		nint num91 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3346 @ rax_v338 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj53 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3359 @ rax_v340+B8]");
		object obj54 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3380 @ r8_v76 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+E0]");
		Func<int, StageType> func20 = new Func<int, StageType>(obj54, (IntPtr)0);
		nint num92 = 0;
		nint num93 = (nint)typeof(EnumCaster<StageType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3385 @ rax_v346 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.StageType>>)+B8]");
		nint num94 = 0;
		nint num95 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3405 @ rax_v351 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj55 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3418 @ rax_v353+B8]");
		object obj56 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3439 @ r8_v78 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+E8]");
		Func<long, StageType> func21 = new Func<long, StageType>(obj56, (IntPtr)0);
		nint num96 = 0;
		nint num97 = (nint)typeof(EnumCaster<StageType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3444 @ rax_v359 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.StageType>>)+B8]");
		nint num98 = 0;
		nint num99 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3464 @ rax_v364 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj57 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3477 @ rax_v366+B8]");
		object obj58 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3498 @ r8_v80 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+F0]");
		Func<byte, AchievementType> fromByte8 = new Func<byte, AchievementType>(obj58, (IntPtr)0);
		nint num100 = 0;
		EnumCaster<AchievementType>.FromByte = fromByte8;
		nint num101 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3537 @ rax_v378 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj59 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3550 @ rax_v380+B8]");
		object obj60 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3571 @ r8_v82 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+F8]");
		Func<short, AchievementType> func22 = new Func<short, AchievementType>(obj60, (IntPtr)0);
		nint num102 = 0;
		nint num103 = (nint)typeof(EnumCaster<AchievementType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3576 @ rax_v386 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.AchievementType>>)+B8]");
		nint num104 = 0;
		nint num105 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3596 @ rax_v391 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj61 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3609 @ rax_v393+B8]");
		object obj62 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3630 @ r8_v84 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+100]");
		Func<int, AchievementType> func23 = new Func<int, AchievementType>(obj62, (IntPtr)0);
		nint num106 = 0;
		nint num107 = (nint)typeof(EnumCaster<AchievementType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3635 @ rax_v399 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.AchievementType>>)+B8]");
		nint num108 = 0;
		nint num109 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3655 @ rax_v404 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj63 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3668 @ rax_v406+B8]");
		object obj64 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3689 @ r8_v86 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+108]");
		Func<long, AchievementType> func24 = new Func<long, AchievementType>(obj64, (IntPtr)0);
		nint num110 = 0;
		nint num111 = (nint)typeof(EnumCaster<AchievementType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3694 @ rax_v412 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.AchievementType>>)+B8]");
		nint num112 = 0;
		nint num113 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3714 @ rax_v417 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj65 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3727 @ rax_v419+B8]");
		object obj66 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3748 @ r8_v88 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+110]");
		Func<byte, EnemyType> fromByte9 = new Func<byte, EnemyType>(obj66, (IntPtr)0);
		nint num114 = 0;
		EnumCaster<EnemyType>.FromByte = fromByte9;
		nint num115 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3787 @ rax_v431 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj67 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3800 @ rax_v433+B8]");
		object obj68 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3821 @ r8_v90 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+118]");
		Func<short, EnemyType> func25 = new Func<short, EnemyType>(obj68, (IntPtr)0);
		nint num116 = 0;
		nint num117 = (nint)typeof(EnumCaster<EnemyType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3826 @ rax_v439 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.EnemyType>>)+B8]");
		nint num118 = 0;
		nint num119 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3846 @ rax_v444 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj69 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3859 @ rax_v446+B8]");
		object obj70 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3880 @ r8_v92 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+120]");
		Func<int, EnemyType> func26 = new Func<int, EnemyType>(obj70, (IntPtr)0);
		nint num120 = 0;
		nint num121 = (nint)typeof(EnumCaster<EnemyType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3885 @ rax_v452 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.EnemyType>>)+B8]");
		nint num122 = 0;
		nint num123 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3905 @ rax_v457 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj71 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3918 @ rax_v459+B8]");
		object obj72 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3939 @ r8_v94 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+128]");
		Func<long, EnemyType> func27 = new Func<long, EnemyType>(obj72, (IntPtr)0);
		nint num124 = 0;
		nint num125 = (nint)typeof(EnumCaster<EnemyType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3944 @ rax_v465 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.EnemyType>>)+B8]");
		nint num126 = 0;
		nint num127 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4027 @ rax_v469 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj73 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4041 @ rax_v471+B8]");
		object obj74 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4062 @ r8_v97 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+130]");
		Func<byte, SkinType> fromByte10 = new Func<byte, SkinType>(obj74, (IntPtr)0);
		nint num128 = 0;
		EnumCaster<SkinType>.FromByte = fromByte10;
		nint num129 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4164 @ rax_v483 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj75 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4178 @ rax_v485+B8]");
		object obj76 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4199 @ r8_v100 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+138]");
		Func<short, SkinType> func28 = new Func<short, SkinType>(obj76, (IntPtr)0);
		nint num130 = 0;
		nint num131 = (nint)typeof(EnumCaster<SkinType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4204 @ rax_v491 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.SkinType>>)+B8]");
		nint num132 = 0;
		nint num133 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4287 @ rax_v495 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj77 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4301 @ rax_v497+B8]");
		object obj78 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4322 @ r8_v103 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+140]");
		Func<int, SkinType> func29 = new Func<int, SkinType>(obj78, (IntPtr)0);
		nint num134 = 0;
		nint num135 = (nint)typeof(EnumCaster<SkinType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4327 @ rax_v503 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.SkinType>>)+B8]");
		nint num136 = 0;
		nint num137 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4410 @ rax_v507 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+8]");
		object obj79 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4424 @ rax_v509+B8]");
		object obj80 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4445 @ r8_v106 (Il2CppRgctx<VampireSurvivors.EnumCaster`1>)+148]");
		Func<long, SkinType> func30 = new Func<long, SkinType>(obj80, (IntPtr)0);
		nint num138 = 0;
		nint num139 = (nint)typeof(EnumCaster<SkinType>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4450 @ rax_v515 (Il2CppClass<VampireSurvivors.EnumCaster`1<VampireSurvivors.Data.SkinType>>)+B8]");
		nint num140 = 0;
	}
}
