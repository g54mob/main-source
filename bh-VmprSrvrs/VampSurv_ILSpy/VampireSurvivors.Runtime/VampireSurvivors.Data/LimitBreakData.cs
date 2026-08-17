using System;
using Cpp2ILInjected;
using I2.Loc;
using UnityEngine;
using VampireSurvivors.Data.Weapons;

namespace VampireSurvivors.Data;

[Serializable]
public class LimitBreakData
{
	private int _003Crarity_003Ek__BackingField;

	private float? _003Cpower_003Ek__BackingField;

	private float? _003Carea_003Ek__BackingField;

	private float? _003Cspeed_003Ek__BackingField;

	private int? _003Cmax_003Ek__BackingField;

	private int? _003Cpenetrating_003Ek__BackingField;

	private int? _003Camount_003Ek__BackingField;

	private float? _003Cchance_003Ek__BackingField;

	private int? _003Cduration_003Ek__BackingField;

	private float? _003CcritChance_003Ek__BackingField;

	private float? _003Ccooldown_003Ek__BackingField;

	private WeaponType? _003CaddEvolvedWeapon_003Ek__BackingField;

	public int rarity
	{
		get
		{
			return _003Crarity_003Ek__BackingField;
		}
		set
		{
			_003Crarity_003Ek__BackingField = value;
		}
	}

	public float? power
	{
		get
		{
			return _003Cpower_003Ek__BackingField;
		}
		set
		{
			_003Cpower_003Ek__BackingField = value;
		}
	}

	public float? area
	{
		get
		{
			return _003Carea_003Ek__BackingField;
		}
		set
		{
			_003Carea_003Ek__BackingField = value;
		}
	}

	public float? speed
	{
		get
		{
			return _003Cspeed_003Ek__BackingField;
		}
		set
		{
			_003Cspeed_003Ek__BackingField = value;
		}
	}

	public int? max
	{
		get
		{
			return _003Cmax_003Ek__BackingField;
		}
		set
		{
			_003Cmax_003Ek__BackingField = value;
		}
	}

	public int? penetrating
	{
		get
		{
			return _003Cpenetrating_003Ek__BackingField;
		}
		set
		{
			_003Cpenetrating_003Ek__BackingField = value;
		}
	}

	public int? amount
	{
		get
		{
			return _003Camount_003Ek__BackingField;
		}
		set
		{
			_003Camount_003Ek__BackingField = value;
		}
	}

	public float? chance
	{
		get
		{
			return _003Cchance_003Ek__BackingField;
		}
		set
		{
			_003Cchance_003Ek__BackingField = value;
		}
	}

	public int? duration
	{
		get
		{
			return _003Cduration_003Ek__BackingField;
		}
		set
		{
			_003Cduration_003Ek__BackingField = value;
		}
	}

	public float? critChance
	{
		get
		{
			return _003CcritChance_003Ek__BackingField;
		}
		set
		{
			_003CcritChance_003Ek__BackingField = value;
		}
	}

	public float? cooldown
	{
		get
		{
			return _003Ccooldown_003Ek__BackingField;
		}
		set
		{
			_003Ccooldown_003Ek__BackingField = value;
		}
	}

	public WeaponType? addEvolvedWeapon
	{
		get
		{
			return _003CaddEvolvedWeapon_003Ek__BackingField;
		}
		set
		{
			_003CaddEvolvedWeapon_003Ek__BackingField = value;
		}
	}

	public void AccumulateData(LimitBreakData limitBreakData)
	{
		//IL_004d: Expected O, but got I4
		//IL_009a: Expected O, but got I4
		//IL_003f: Expected O, but got I4
		//IL_00e7: Expected O, but got I4
		//IL_008c: Expected O, but got I4
		//IL_0134: Expected O, but got I4
		//IL_00d9: Expected O, but got I4
		//IL_0181: Expected O, but got I4
		//IL_0126: Expected O, but got I4
		//IL_01ce: Expected O, but got I4
		//IL_0173: Expected O, but got I4
		//IL_021b: Expected O, but got I4
		//IL_01c0: Expected O, but got I4
		//IL_0299: Expected O, but got I4
		//IL_0268: Expected O, but got I4
		//IL_020d: Expected O, but got I4
		//IL_025a: Expected O, but got I4
		//IL_02b0: Expected O, but got I4
		if ((object)_003Cpower_003Ek__BackingField != null)
		{
			object obj = (object?)_003Cpower_003Ek__BackingField & (object?)limitBreakData._003Cpower_003Ek__BackingField;
			float? num = (float?)((obj == null) ? ((object)0) : ((object)1));
			_003Cpower_003Ek__BackingField = num;
		}
		if ((object)_003Carea_003Ek__BackingField != null)
		{
			object obj2 = (object?)limitBreakData._003Carea_003Ek__BackingField & (object?)_003Carea_003Ek__BackingField;
			float? num2 = (float?)((obj2 == null) ? ((object)0) : ((object)1));
			_003Carea_003Ek__BackingField = num2;
		}
		if ((object)_003Cspeed_003Ek__BackingField != null)
		{
			object obj3 = (object?)_003Cspeed_003Ek__BackingField & (object?)limitBreakData._003Cspeed_003Ek__BackingField;
			float? num3 = (float?)((obj3 == null) ? ((object)0) : ((object)1));
			_003Cspeed_003Ek__BackingField = num3;
		}
		if ((object)_003Cpenetrating_003Ek__BackingField != null)
		{
			object obj4 = (object?)_003Cpenetrating_003Ek__BackingField & (object?)limitBreakData._003Cpenetrating_003Ek__BackingField;
			int? num4 = (int?)((obj4 == null) ? ((object)0) : ((object)1));
			_003Cpenetrating_003Ek__BackingField = num4;
		}
		if ((object)_003Camount_003Ek__BackingField != null)
		{
			object obj5 = (object?)limitBreakData._003Camount_003Ek__BackingField & (object?)_003Camount_003Ek__BackingField;
			int? num5 = (int?)((obj5 == null) ? ((object)0) : ((object)1));
			_003Camount_003Ek__BackingField = num5;
		}
		if ((object)_003Cchance_003Ek__BackingField != null)
		{
			object obj6 = (object?)limitBreakData._003Cchance_003Ek__BackingField & (object?)_003Cchance_003Ek__BackingField;
			float? num6 = (float?)((obj6 == null) ? ((object)0) : ((object)1));
			_003Cchance_003Ek__BackingField = num6;
		}
		if ((object)_003Cduration_003Ek__BackingField != null)
		{
			object obj7 = (object?)_003Cduration_003Ek__BackingField & (object?)limitBreakData._003Cduration_003Ek__BackingField;
			int? num7 = (int?)((obj7 == null) ? ((object)0) : ((object)1));
			_003Cduration_003Ek__BackingField = num7;
		}
		if ((object)_003CcritChance_003Ek__BackingField != null)
		{
			object obj8 = (object?)_003CcritChance_003Ek__BackingField & (object?)limitBreakData._003CcritChance_003Ek__BackingField;
			float? num8 = (float?)((obj8 == null) ? ((object)0) : ((object)1));
			_003CcritChance_003Ek__BackingField = num8;
		}
		if ((object)_003Ccooldown_003Ek__BackingField != null)
		{
			object obj9 = (object?)limitBreakData._003Ccooldown_003Ek__BackingField & (object?)_003Ccooldown_003Ek__BackingField;
			bool flag = obj9 == null;
			float? num9 = (float?)(object)0;
			if (!flag)
			{
				num9 = (float?)(object)1;
			}
			_003Ccooldown_003Ek__BackingField = num9;
		}
	}

	public void ApplyDataToWeapon(WeaponData weaponData)
	{
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected I4, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected I4, but got Unknown
		//IL_0217: Expected O, but got I4
		//IL_0209: Expected O, but got I4
		object obj = default(object);
		if ((object)_003Cpower_003Ek__BackingField != null)
		{
			if ((object)_003Cpower_003Ek__BackingField == null)
			{
				goto IL_02c5;
			}
			float num = (float)obj + weaponData._003Cpower_003Ek__BackingField;
			weaponData._003Cpower_003Ek__BackingField = num;
		}
		if ((object)_003Carea_003Ek__BackingField != null)
		{
			if ((object)_003Carea_003Ek__BackingField == null)
			{
				goto IL_02c5;
			}
			float num2 = (float)obj + weaponData._003Carea_003Ek__BackingField;
			weaponData._003Carea_003Ek__BackingField = num2;
		}
		if ((object)_003Cspeed_003Ek__BackingField != null)
		{
			if ((object)_003Cspeed_003Ek__BackingField == null)
			{
				goto IL_02c5;
			}
			float num3 = (float)obj + weaponData._003Cspeed_003Ek__BackingField;
			weaponData._003Cspeed_003Ek__BackingField = num3;
		}
		if ((object)_003Cpenetrating_003Ek__BackingField != null)
		{
			if ((object)_003Cpenetrating_003Ek__BackingField == null)
			{
				goto IL_02c5;
			}
			object obj2 = (object?)_003Cpenetrating_003Ek__BackingField >> 32;
			int num4 = weaponData._003Cpenetrating_003Ek__BackingField + obj2;
			weaponData._003Cpenetrating_003Ek__BackingField = num4;
		}
		if ((object)_003Camount_003Ek__BackingField != null)
		{
			if ((object)_003Camount_003Ek__BackingField == null)
			{
				goto IL_02c5;
			}
			object obj3 = (object?)_003Camount_003Ek__BackingField >> 32;
			int num5 = weaponData._003Camount_003Ek__BackingField + obj3;
			weaponData._003Camount_003Ek__BackingField = num5;
		}
		if ((object)_003Cchance_003Ek__BackingField != null)
		{
			if ((object)_003Cchance_003Ek__BackingField == null)
			{
				goto IL_02c5;
			}
			float num6 = (float)obj + weaponData._003Cchance_003Ek__BackingField;
			weaponData._003Cchance_003Ek__BackingField = num6;
		}
		if ((object)_003Cduration_003Ek__BackingField != null)
		{
			if ((object)_003Cduration_003Ek__BackingField == null)
			{
				goto IL_02c5;
			}
			float? num7 = (float?)(((object)weaponData._003Cduration_003Ek__BackingField == null) ? ((object)0) : ((object)1));
			weaponData._003Cduration_003Ek__BackingField = num7;
		}
		if ((object)_003CcritChance_003Ek__BackingField != null)
		{
			if ((object)_003CcritChance_003Ek__BackingField == null)
			{
				goto IL_02c5;
			}
			float num8 = (float)obj + weaponData._003CcritChance_003Ek__BackingField;
			weaponData._003CcritChance_003Ek__BackingField = num8;
		}
		if ((object)_003Ccooldown_003Ek__BackingField != null)
		{
			if ((object)_003Ccooldown_003Ek__BackingField != null)
			{
				float num9 = (float)obj + weaponData._003Ccooldown_003Ek__BackingField;
				weaponData._003Ccooldown_003Ek__BackingField = num9;
				return;
			}
			goto IL_02c5;
		}
		return;
		IL_02c5:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
	}

	public unsafe string GetLocalizedDescription()
	{
		//IL_037c: Expected O, but got I4
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Ref, but got Unknown
		//IL_0063: Expected F4, but got I
		//IL_03f8: Expected O, but got I4
		//IL_086e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0873: Expected O, but got Unknown
		//IL_087d: Unsupported input type for neg.
		//IL_087d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0882: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected Ref, but got Unknown
		//IL_0171: Expected F4, but got I
		//IL_0474: Expected O, but got I4
		//IL_08b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b8: Expected O, but got Unknown
		//IL_08c2: Unsupported input type for neg.
		//IL_08c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c7: Expected O, but got Unknown
		//IL_0397: Expected O, but got I8
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected Ref, but got Unknown
		//IL_027e: Expected F4, but got I
		//IL_0917: Unknown result type (might be due to invalid IL or missing references)
		//IL_091c: Expected O, but got Unknown
		//IL_0926: Unsupported input type for neg.
		//IL_0926: Unknown result type (might be due to invalid IL or missing references)
		//IL_092b: Expected O, but got Unknown
		//IL_0413: Expected O, but got I8
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected Ref, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected Ref, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_048f: Expected O, but got I8
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected Ref, but got Unknown
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Expected Ref, but got Unknown
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Expected O, but got Unknown
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected Ref, but got Unknown
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Expected Ref, but got Unknown
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Expected O, but got Unknown
		//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ea: Expected Ref, but got Unknown
		//IL_04ff: Expected F4, but got I
		//IL_05fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0601: Expected Ref, but got Unknown
		//IL_0616: Expected F4, but got I
		//IL_0709: Unknown result type (might be due to invalid IL or missing references)
		//IL_070e: Expected Ref, but got Unknown
		//IL_0723: Expected F4, but got I
		//IL_0542: Unknown result type (might be due to invalid IL or missing references)
		//IL_0547: Expected Ref, but got Unknown
		//IL_0550: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Expected Ref, but got Unknown
		//IL_056b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0570: Expected O, but got Unknown
		//IL_064f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0654: Expected Ref, but got Unknown
		//IL_065d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0662: Expected Ref, but got Unknown
		//IL_0678: Unknown result type (might be due to invalid IL or missing references)
		//IL_067d: Expected O, but got Unknown
		//IL_075c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0761: Expected Ref, but got Unknown
		//IL_076a: Unknown result type (might be due to invalid IL or missing references)
		//IL_076f: Expected Ref, but got Unknown
		//IL_0785: Unknown result type (might be due to invalid IL or missing references)
		//IL_078a: Expected O, but got Unknown
		bool flag = (object)_003Cpower_003Ek__BackingField == null;
		string text = "";
		object obj = default(object);
		if (!flag)
		{
			_ = _003Cpower_003Ek__BackingField;
			if ((object)_003Cpower_003Ek__BackingField == null)
			{
				goto IL_07d2;
			}
			_ = 0;
			ref decimal.DecCalc result = ref *(decimal.DecCalc*)(obj - 16);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+24]");
			decimal.DecCalc.VarDecFromR4(0f, out result);
			_ = 0;
			_ = 10;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
			_ = 0;
			decimal.DecCalc.VarDecMul(ref *(decimal.DecCalc*)(obj - 16), ref *(decimal.DecCalc*)(obj - 32));
			decimal value = obj - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
			_ = 0;
			string description = GetDescription("limitBreak_might", value);
			string text2 = "" + description;
			text = text2;
		}
		if ((object)_003Carea_003Ek__BackingField != null)
		{
			_ = _003Carea_003Ek__BackingField;
			if ((object)_003Carea_003Ek__BackingField == null)
			{
				goto IL_07d2;
			}
			_ = 0;
			ref decimal.DecCalc result2 = ref *(decimal.DecCalc*)(obj - 16);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+24]");
			decimal.DecCalc.VarDecFromR4(0f, out result2);
			_ = 0;
			_ = 100;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
			_ = 0;
			decimal.DecCalc.VarDecMul(ref *(decimal.DecCalc*)(obj - 16), ref *(decimal.DecCalc*)(obj - 32));
			decimal value2 = obj - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
			_ = 0;
			string description2 = GetDescription("limitBreak_area", value2);
			string text3 = text + description2;
			text = text3;
		}
		if ((object)_003Cspeed_003Ek__BackingField != null)
		{
			_ = _003Cspeed_003Ek__BackingField;
			if ((object)_003Cspeed_003Ek__BackingField == null)
			{
				goto IL_07d2;
			}
			_ = 0;
			ref decimal.DecCalc result3 = ref *(decimal.DecCalc*)(obj - 16);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+24]");
			decimal.DecCalc.VarDecFromR4(0f, out result3);
			_ = 0;
			_ = 100;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
			_ = 0;
			decimal.DecCalc.VarDecMul(ref *(decimal.DecCalc*)(obj - 16), ref *(decimal.DecCalc*)(obj - 32));
			decimal value3 = obj - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
			_ = 0;
			string description3 = GetDescription("limitBreak_speed", value3);
			string text4 = text + description3;
			text = text4;
		}
		if ((object)_003Camount_003Ek__BackingField != null)
		{
			if ((object)_003Camount_003Ek__BackingField == null)
			{
				goto IL_07d2;
			}
			object obj2 = (object?)_003Camount_003Ek__BackingField >> 32;
			bool flag2 = (nint)obj2 >= 0;
			object obj3 = 0;
			if (!flag2)
			{
				obj3 = 2147483648L;
			}
			decimal value4 = obj - 16;
			_ = 0;
			object obj4 = 0 - obj2;
			_ = 0;
			if ((nint)obj2 >= 0)
			{
				obj4 = obj2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-20]");
			_ = 0;
			string description4 = GetDescription("limitBreak_amount", value4);
			string text5 = text + description4;
			text = text5;
		}
		if ((object)_003Cpenetrating_003Ek__BackingField != null)
		{
			if ((object)_003Cpenetrating_003Ek__BackingField == null)
			{
				goto IL_07d2;
			}
			object obj5 = (object?)_003Cpenetrating_003Ek__BackingField >> 32;
			bool flag3 = (nint)obj5 >= 0;
			object obj6 = 0;
			if (!flag3)
			{
				obj6 = 2147483648L;
			}
			decimal value5 = obj - 16;
			_ = 0;
			object obj7 = 0 - obj5;
			_ = 0;
			if ((nint)obj5 >= 0)
			{
				obj7 = obj5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-20]");
			_ = 0;
			string description5 = GetDescription("limitBreak_passes", value5);
			string text6 = text + description5;
			text = text6;
		}
		if ((object)_003Cduration_003Ek__BackingField != null)
		{
			if ((object)_003Cduration_003Ek__BackingField == null)
			{
				goto IL_07d2;
			}
			object obj8 = (object?)_003Cduration_003Ek__BackingField >> 32;
			bool flag4 = (nint)obj8 >= 0;
			object obj9 = 0;
			if (!flag4)
			{
				obj9 = 2147483648L;
			}
			decimal value6 = obj - 16;
			_ = 0;
			object obj10 = 0 - obj8;
			_ = 0;
			if ((nint)obj8 >= 0)
			{
				obj10 = obj8;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-20]");
			_ = 0;
			string description6 = GetDescription("limitBreak_duration", value6);
			string text7 = text + description6;
			text = text7;
		}
		if ((object)_003Ccooldown_003Ek__BackingField != null)
		{
			_ = _003Ccooldown_003Ek__BackingField;
			if ((object)_003Ccooldown_003Ek__BackingField == null)
			{
				goto IL_07d2;
			}
			_ = 0;
			ref decimal.DecCalc result4 = ref *(decimal.DecCalc*)(obj - 16);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+24]");
			decimal.DecCalc.VarDecFromR4(0f, out result4);
			_ = 2147483648L;
			_ = 100;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
			_ = 0;
			decimal.DecCalc.VarDecMul(ref *(decimal.DecCalc*)(obj - 16), ref *(decimal.DecCalc*)(obj - 32));
			decimal value7 = obj - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
			_ = 0;
			string description7 = GetDescription("limitBreak_cooldown", value7, 1);
			string text8 = text + description7;
			text = text8;
		}
		if ((object)_003CcritChance_003Ek__BackingField != null)
		{
			_ = _003CcritChance_003Ek__BackingField;
			if ((object)_003CcritChance_003Ek__BackingField == null)
			{
				goto IL_07d2;
			}
			_ = 0;
			ref decimal.DecCalc result5 = ref *(decimal.DecCalc*)(obj - 16);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+24]");
			decimal.DecCalc.VarDecFromR4(0f, out result5);
			_ = 0;
			_ = 100;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
			_ = 0;
			decimal.DecCalc.VarDecMul(ref *(decimal.DecCalc*)(obj - 16), ref *(decimal.DecCalc*)(obj - 32));
			decimal value8 = obj - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
			_ = 0;
			string description8 = GetDescription("limitBreak_critical", value8, 1);
			string text9 = text + description8;
			text = text9;
		}
		if ((object)_003Cchance_003Ek__BackingField != null)
		{
			_ = _003Cchance_003Ek__BackingField;
			if ((object)_003Cchance_003Ek__BackingField == null)
			{
				goto IL_07d2;
			}
			_ = 0;
			ref decimal.DecCalc result6 = ref *(decimal.DecCalc*)(obj - 16);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+24]");
			decimal.DecCalc.VarDecFromR4(0f, out result6);
			_ = 0;
			_ = 100;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
			_ = 0;
			decimal.DecCalc.VarDecMul(ref *(decimal.DecCalc*)(obj - 16), ref *(decimal.DecCalc*)(obj - 32));
			decimal value9 = obj - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
			_ = 0;
			string description9 = GetDescription("limitBreak_chance", value9, 1);
			string text10 = text + description9;
			text = text10;
		}
		return text;
		IL_07d2:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		string result7 = default(string);
		return result7;
	}

	private unsafe string GetDescription(string term, decimal value, int decimalPlaces = 0)
	{
		//IL_0127: Expected O, but got Ref
		//IL_0086: Expected O, but got Ref
		//IL_0093: Expected O, but got I4
		string term2 = "lang/" + term;
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term2, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		string customFormat;
		object obj = default(object);
		if (decimalPlaces > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			customFormat = string.FormatHelper((IFormatProvider)null, "F{0}", (System.ParamsArray)(&obj));
			obj = 0;
		}
		else
		{
			customFormat = "";
		}
		string newValue = UtilityExtensionMethods.DecimalToString((decimal)(&obj), customFormat);
		if (translation != null)
		{
			string text = translation.Replace("%0", newValue);
			if (text != null)
			{
				return text.Replace("\\n", "<br>");
			}
		}
		return (string)(object)new NullReferenceException();
	}
}
