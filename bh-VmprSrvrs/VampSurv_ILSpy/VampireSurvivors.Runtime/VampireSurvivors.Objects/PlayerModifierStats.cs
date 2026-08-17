using System;
using Cpp2ILInjected;
using VampireSurvivors.Framework.NumberTypes;

namespace VampireSurvivors.Objects;

[Serializable]
public class PlayerModifierStats
{
	private EggFloat _003CPower_003Ek__BackingField;

	private EggFloat _003CArea_003Ek__BackingField;

	private EggFloat _003CSpeed_003Ek__BackingField;

	private EggFloat _003CMoveSpeed_003Ek__BackingField;

	private EggFloat _003CGrowth_003Ek__BackingField;

	private EggFloat _003CLuck_003Ek__BackingField;

	private EggFloat _003CDuration_003Ek__BackingField;

	private EggFloat _003CCooldown_003Ek__BackingField;

	private EggFloat _003CAmount_003Ek__BackingField;

	private EggFloat _003CArmor_003Ek__BackingField;

	private EggFloat _003CGreed_003Ek__BackingField;

	private EggFloat _003CRegen_003Ek__BackingField;

	private EggFloat _003CReRolls_003Ek__BackingField;

	private EggFloat _003CSkips_003Ek__BackingField;

	private EggFloat _003CMaxHp_003Ek__BackingField;

	private EggFloat _003CMagnet_003Ek__BackingField;

	private EggFloat _003CCurse_003Ek__BackingField;

	private EggFloat _003CBanish_003Ek__BackingField;

	private EggDouble _003CRevivals_003Ek__BackingField;

	private int _003CUsedRevivals_003Ek__BackingField;

	private float _003CShroud_003Ek__BackingField;

	private float _003CShields_003Ek__BackingField;

	private int _003CCharm_003Ek__BackingField;

	private float _003CDefang_003Ek__BackingField;

	private float _003CThorns_003Ek__BackingField;

	private float _003CInvulTimeBonus_003Ek__BackingField;

	private float _003CFever_003Ek__BackingField;

	private float _003CRecycle_003Ek__BackingField;

	public EggFloat Power
	{
		get
		{
			return _003CPower_003Ek__BackingField;
		}
		set
		{
			_003CPower_003Ek__BackingField = value;
		}
	}

	public EggFloat Area
	{
		get
		{
			return _003CArea_003Ek__BackingField;
		}
		set
		{
			_003CArea_003Ek__BackingField = value;
		}
	}

	public EggFloat Speed
	{
		get
		{
			return _003CSpeed_003Ek__BackingField;
		}
		set
		{
			_003CSpeed_003Ek__BackingField = value;
		}
	}

	public EggFloat MoveSpeed
	{
		get
		{
			return _003CMoveSpeed_003Ek__BackingField;
		}
		set
		{
			_003CMoveSpeed_003Ek__BackingField = value;
		}
	}

	public EggFloat Growth
	{
		get
		{
			return _003CGrowth_003Ek__BackingField;
		}
		set
		{
			_003CGrowth_003Ek__BackingField = value;
		}
	}

	public EggFloat Luck
	{
		get
		{
			return _003CLuck_003Ek__BackingField;
		}
		set
		{
			_003CLuck_003Ek__BackingField = value;
		}
	}

	public EggFloat Duration
	{
		get
		{
			return _003CDuration_003Ek__BackingField;
		}
		set
		{
			_003CDuration_003Ek__BackingField = value;
		}
	}

	public EggFloat Cooldown
	{
		get
		{
			return _003CCooldown_003Ek__BackingField;
		}
		set
		{
			_003CCooldown_003Ek__BackingField = value;
		}
	}

	public EggFloat Amount
	{
		get
		{
			return _003CAmount_003Ek__BackingField;
		}
		set
		{
			_003CAmount_003Ek__BackingField = value;
		}
	}

	public EggFloat Armor
	{
		get
		{
			return _003CArmor_003Ek__BackingField;
		}
		set
		{
			_003CArmor_003Ek__BackingField = value;
		}
	}

	public EggFloat Greed
	{
		get
		{
			return _003CGreed_003Ek__BackingField;
		}
		set
		{
			_003CGreed_003Ek__BackingField = value;
		}
	}

	public EggFloat Regen
	{
		get
		{
			return _003CRegen_003Ek__BackingField;
		}
		set
		{
			_003CRegen_003Ek__BackingField = value;
		}
	}

	public EggFloat ReRolls
	{
		get
		{
			return _003CReRolls_003Ek__BackingField;
		}
		set
		{
			_003CReRolls_003Ek__BackingField = value;
		}
	}

	public EggFloat Skips
	{
		get
		{
			return _003CSkips_003Ek__BackingField;
		}
		set
		{
			_003CSkips_003Ek__BackingField = value;
		}
	}

	public EggFloat MaxHp
	{
		get
		{
			return _003CMaxHp_003Ek__BackingField;
		}
		set
		{
			_003CMaxHp_003Ek__BackingField = value;
		}
	}

	public EggFloat Magnet
	{
		get
		{
			return _003CMagnet_003Ek__BackingField;
		}
		set
		{
			_003CMagnet_003Ek__BackingField = value;
		}
	}

	public EggFloat Curse
	{
		get
		{
			return _003CCurse_003Ek__BackingField;
		}
		set
		{
			_003CCurse_003Ek__BackingField = value;
		}
	}

	public EggFloat Banish
	{
		get
		{
			return _003CBanish_003Ek__BackingField;
		}
		set
		{
			_003CBanish_003Ek__BackingField = value;
		}
	}

	public EggDouble Revivals
	{
		get
		{
			return _003CRevivals_003Ek__BackingField;
		}
		set
		{
			_003CRevivals_003Ek__BackingField = value;
		}
	}

	public int UsedRevivals
	{
		get
		{
			return _003CUsedRevivals_003Ek__BackingField;
		}
		set
		{
			_003CUsedRevivals_003Ek__BackingField = value;
		}
	}

	public float Shroud
	{
		get
		{
			return _003CShroud_003Ek__BackingField;
		}
		set
		{
			_003CShroud_003Ek__BackingField = value;
		}
	}

	public float Shields
	{
		get
		{
			return _003CShields_003Ek__BackingField;
		}
		set
		{
			_003CShields_003Ek__BackingField = value;
		}
	}

	public int Charm
	{
		get
		{
			return _003CCharm_003Ek__BackingField;
		}
		set
		{
			_003CCharm_003Ek__BackingField = value;
		}
	}

	public float Defang
	{
		get
		{
			return _003CDefang_003Ek__BackingField;
		}
		set
		{
			_003CDefang_003Ek__BackingField = value;
		}
	}

	public float Thorns
	{
		get
		{
			return _003CThorns_003Ek__BackingField;
		}
		set
		{
			_003CThorns_003Ek__BackingField = value;
		}
	}

	public float InvulTimeBonus
	{
		get
		{
			return _003CInvulTimeBonus_003Ek__BackingField;
		}
		set
		{
			_003CInvulTimeBonus_003Ek__BackingField = value;
		}
	}

	public float Fever
	{
		get
		{
			return _003CFever_003Ek__BackingField;
		}
		set
		{
			_003CFever_003Ek__BackingField = value;
		}
	}

	public float Recycle
	{
		get
		{
			return _003CRecycle_003Ek__BackingField;
		}
		set
		{
			_003CRecycle_003Ek__BackingField = value;
		}
	}

	public void ResetStats()
	{
		EggFloat eggFloat = new EggFloat(0f);
		_003CPower_003Ek__BackingField = eggFloat;
		EggFloat eggFloat2 = new EggFloat(0f);
		_003CArea_003Ek__BackingField = eggFloat2;
		EggFloat eggFloat3 = new EggFloat(0f);
		_003CSpeed_003Ek__BackingField = eggFloat3;
		EggFloat eggFloat4 = new EggFloat(0f);
		_003CMoveSpeed_003Ek__BackingField = eggFloat4;
		EggFloat eggFloat5 = new EggFloat(0f);
		_003CGrowth_003Ek__BackingField = eggFloat5;
		EggFloat eggFloat6 = new EggFloat(0f);
		_003CLuck_003Ek__BackingField = eggFloat6;
		EggFloat eggFloat7 = new EggFloat(0f);
		_003CDuration_003Ek__BackingField = eggFloat7;
		EggFloat eggFloat8 = new EggFloat(0f);
		_003CCooldown_003Ek__BackingField = eggFloat8;
		EggFloat eggFloat9 = new EggFloat(0f);
		_003CAmount_003Ek__BackingField = eggFloat9;
		EggFloat eggFloat10 = new EggFloat(0f);
		_003CArmor_003Ek__BackingField = eggFloat10;
		EggFloat eggFloat11 = new EggFloat(0f);
		_003CGreed_003Ek__BackingField = eggFloat11;
		EggFloat eggFloat12 = new EggFloat(0f);
		_003CRegen_003Ek__BackingField = eggFloat12;
		EggFloat eggFloat13 = new EggFloat(0f);
		_003CReRolls_003Ek__BackingField = eggFloat13;
		EggFloat eggFloat14 = new EggFloat(0f);
		_003CSkips_003Ek__BackingField = eggFloat14;
		EggFloat eggFloat15 = new EggFloat(0f);
		_003CMaxHp_003Ek__BackingField = eggFloat15;
		EggFloat eggFloat16 = new EggFloat(0f);
		_003CMagnet_003Ek__BackingField = eggFloat16;
		EggFloat eggFloat17 = new EggFloat(0f);
		_003CCurse_003Ek__BackingField = eggFloat17;
		EggFloat eggFloat18 = new EggFloat(0f);
		_003CBanish_003Ek__BackingField = eggFloat18;
		EggDouble eggDouble = new EggDouble(0.0);
		_003CRevivals_003Ek__BackingField = eggDouble;
		_003CShroud_003Ek__BackingField = 0f;
		_003CCharm_003Ek__BackingField = 0;
		_003CThorns_003Ek__BackingField = 0f;
		_003CFever_003Ek__BackingField = 0f;
		_003CUsedRevivals_003Ek__BackingField = 0;
	}

	public void Set(ModifierStats modifierStats)
	{
		EggFloat eggFloat = new EggFloat(modifierStats._003CPower_003Ek__BackingField);
		_003CPower_003Ek__BackingField = eggFloat;
		EggFloat eggFloat2 = new EggFloat(modifierStats._003CArea_003Ek__BackingField);
		_003CArea_003Ek__BackingField = eggFloat2;
		EggFloat eggFloat3 = new EggFloat(modifierStats._003CSpeed_003Ek__BackingField);
		_003CSpeed_003Ek__BackingField = eggFloat3;
		EggFloat eggFloat4 = new EggFloat(modifierStats._003CMoveSpeed_003Ek__BackingField);
		_003CMoveSpeed_003Ek__BackingField = eggFloat4;
		EggFloat eggFloat5 = new EggFloat(modifierStats._003CGrowth_003Ek__BackingField);
		_003CGrowth_003Ek__BackingField = eggFloat5;
		EggFloat eggFloat6 = new EggFloat(modifierStats._003CLuck_003Ek__BackingField);
		_003CLuck_003Ek__BackingField = eggFloat6;
		EggFloat eggFloat7 = new EggFloat(modifierStats._003CDuration_003Ek__BackingField);
		_003CDuration_003Ek__BackingField = eggFloat7;
		EggFloat eggFloat8 = new EggFloat(modifierStats._003CCooldown_003Ek__BackingField);
		_003CCooldown_003Ek__BackingField = eggFloat8;
		EggFloat eggFloat9 = new EggFloat(modifierStats._003CAmount_003Ek__BackingField);
		_003CAmount_003Ek__BackingField = eggFloat9;
		EggFloat eggFloat10 = new EggFloat(modifierStats._003CArmor_003Ek__BackingField);
		_003CArmor_003Ek__BackingField = eggFloat10;
		EggFloat eggFloat11 = new EggFloat(modifierStats._003CGreed_003Ek__BackingField);
		_003CGreed_003Ek__BackingField = eggFloat11;
		EggFloat eggFloat12 = new EggFloat(modifierStats._003CRegen_003Ek__BackingField);
		_003CRegen_003Ek__BackingField = eggFloat12;
		EggFloat eggFloat13 = new EggFloat(modifierStats._003CReRolls_003Ek__BackingField);
		_003CReRolls_003Ek__BackingField = eggFloat13;
		EggFloat eggFloat14 = new EggFloat(modifierStats._003CSkips_003Ek__BackingField);
		_003CSkips_003Ek__BackingField = eggFloat14;
		EggFloat eggFloat15 = new EggFloat(modifierStats._003CMaxHp_003Ek__BackingField);
		_003CMaxHp_003Ek__BackingField = eggFloat15;
		EggFloat eggFloat16 = new EggFloat(modifierStats._003CMagnet_003Ek__BackingField);
		_003CMagnet_003Ek__BackingField = eggFloat16;
		EggFloat eggFloat17 = new EggFloat(modifierStats._003CCurse_003Ek__BackingField);
		_003CCurse_003Ek__BackingField = eggFloat17;
		EggFloat eggFloat18 = new EggFloat(modifierStats._003CBanish_003Ek__BackingField);
		_003CBanish_003Ek__BackingField = eggFloat18;
		EggDouble eggDouble = new EggDouble(modifierStats._003CRevivals_003Ek__BackingField);
		_003CRevivals_003Ek__BackingField = eggDouble;
		_003CShroud_003Ek__BackingField = modifierStats._003CShroud_003Ek__BackingField;
		_003CShields_003Ek__BackingField = modifierStats._003CShields_003Ek__BackingField;
		_003CCharm_003Ek__BackingField = modifierStats._003CCharm_003Ek__BackingField;
		_003CDefang_003Ek__BackingField = modifierStats._003CDefang_003Ek__BackingField;
		_003CDefang_003Ek__BackingField = modifierStats._003CThorns_003Ek__BackingField;
		_003CInvulTimeBonus_003Ek__BackingField = modifierStats._003CInvulTimeBonus_003Ek__BackingField;
		_003CFever_003Ek__BackingField = modifierStats._003CFever_003Ek__BackingField;
		_003CRecycle_003Ek__BackingField = modifierStats._003CRecycle_003Ek__BackingField;
	}

	public void Upgrade(ModifierStats other, bool multiplicativeMaxHp = false)
	{
		EggFloat eggFloat = _003CPower_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + other._003CPower_003Ek__BackingField;
		_003CPower_003Ek__BackingField = eggFloat2;
		EggFloat eggFloat3 = _003CArea_003Ek__BackingField;
		float value2 = default(float);
		EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
		value2 = eggFloat3._val + other._003CArea_003Ek__BackingField;
		_003CArea_003Ek__BackingField = eggFloat4;
		EggFloat eggFloat5 = _003CSpeed_003Ek__BackingField;
		float value3 = default(float);
		EggFloat eggFloat6 = new EggFloat(value3, eggFloat5._eggVal);
		value3 = eggFloat5._val + other._003CSpeed_003Ek__BackingField;
		_003CSpeed_003Ek__BackingField = eggFloat6;
		EggFloat eggFloat7 = _003CCooldown_003Ek__BackingField;
		float value4 = default(float);
		EggFloat eggFloat8 = new EggFloat(value4, eggFloat7._eggVal);
		value4 = eggFloat7._val + other._003CCooldown_003Ek__BackingField;
		_003CCooldown_003Ek__BackingField = eggFloat8;
		EggFloat eggFloat9 = _003CAmount_003Ek__BackingField;
		float value5 = default(float);
		EggFloat eggFloat10 = new EggFloat(value5, eggFloat9._eggVal);
		value5 = eggFloat9._val + other._003CAmount_003Ek__BackingField;
		_003CAmount_003Ek__BackingField = eggFloat10;
		EggFloat eggFloat11 = _003CMoveSpeed_003Ek__BackingField;
		float value6 = default(float);
		EggFloat eggFloat12 = new EggFloat(value6, eggFloat11._eggVal);
		value6 = eggFloat11._val + other._003CMoveSpeed_003Ek__BackingField;
		_003CMoveSpeed_003Ek__BackingField = eggFloat12;
		EggFloat eggFloat13 = _003CGrowth_003Ek__BackingField;
		float value7 = default(float);
		EggFloat eggFloat14 = new EggFloat(value7, eggFloat13._eggVal);
		value7 = eggFloat13._val + other._003CGrowth_003Ek__BackingField;
		_003CGrowth_003Ek__BackingField = eggFloat14;
		EggFloat eggFloat15 = _003CLuck_003Ek__BackingField;
		float value8 = default(float);
		EggFloat eggFloat16 = new EggFloat(value8, eggFloat15._eggVal);
		value8 = eggFloat15._val + other._003CLuck_003Ek__BackingField;
		_003CLuck_003Ek__BackingField = eggFloat16;
		EggFloat eggFloat17 = _003CArmor_003Ek__BackingField;
		float value9 = default(float);
		EggFloat eggFloat18 = new EggFloat(value9, eggFloat17._eggVal);
		value9 = eggFloat17._val + other._003CArmor_003Ek__BackingField;
		_003CArmor_003Ek__BackingField = eggFloat18;
		EggFloat eggFloat19 = _003CDuration_003Ek__BackingField;
		float value10 = default(float);
		EggFloat eggFloat20 = new EggFloat(value10, eggFloat19._eggVal);
		value10 = eggFloat19._val + other._003CDuration_003Ek__BackingField;
		_003CDuration_003Ek__BackingField = eggFloat20;
		EggFloat eggFloat21 = _003CGreed_003Ek__BackingField;
		float value11 = default(float);
		EggFloat eggFloat22 = new EggFloat(value11, eggFloat21._eggVal);
		value11 = eggFloat21._val + other._003CGreed_003Ek__BackingField;
		_003CGreed_003Ek__BackingField = eggFloat22;
		EggFloat eggFloat23 = _003CRegen_003Ek__BackingField;
		float value12 = default(float);
		EggFloat eggFloat24 = new EggFloat(value12, eggFloat23._eggVal);
		value12 = eggFloat23._val + other._003CRegen_003Ek__BackingField;
		_003CRegen_003Ek__BackingField = eggFloat24;
		EggFloat eggFloat25 = _003CMaxHp_003Ek__BackingField;
		if (!multiplicativeMaxHp)
		{
			float value13 = default(float);
			EggFloat eggFloat26 = new EggFloat(value13, eggFloat25._eggVal);
			value13 = eggFloat25._val + other._003CMaxHp_003Ek__BackingField;
			_003CMaxHp_003Ek__BackingField = eggFloat26;
		}
		else
		{
			EggFloat eggFloat27 = _003CMaxHp_003Ek__BackingField;
			float eggValue = default(float);
			float value14 = default(float);
			EggFloat eggFloat28 = new EggFloat(value14, eggValue);
			eggValue = eggFloat27._eggVal * other._003CMaxHp_003Ek__BackingField;
			value14 = eggFloat27._val * other._003CMaxHp_003Ek__BackingField;
			float eggValue2 = default(float);
			float value15 = default(float);
			EggFloat eggFloat29 = new EggFloat(value15, eggValue2);
			eggValue2 = eggFloat28._eggVal + eggFloat25._eggVal;
			value15 = eggFloat28._val + eggFloat25._val;
			_003CMaxHp_003Ek__BackingField = eggFloat29;
		}
		EggDouble eggDouble = _003CRevivals_003Ek__BackingField;
		EggDouble eggDouble2 = new EggDouble(eggDouble._val, eggDouble._eggVal);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm7,xmm8\"");
		_003CRevivals_003Ek__BackingField = eggDouble2;
		EggFloat eggFloat30 = _003CReRolls_003Ek__BackingField;
		float value16 = default(float);
		EggFloat eggFloat31 = new EggFloat(value16, eggFloat30._eggVal);
		value16 = eggFloat30._val + other._003CReRolls_003Ek__BackingField;
		_003CReRolls_003Ek__BackingField = eggFloat31;
		EggFloat eggFloat32 = _003CSkips_003Ek__BackingField;
		float value17 = default(float);
		EggFloat eggFloat33 = new EggFloat(value17, eggFloat32._eggVal);
		value17 = eggFloat32._val + other._003CSkips_003Ek__BackingField;
		_003CSkips_003Ek__BackingField = eggFloat33;
		float num = _003CShroud_003Ek__BackingField + other._003CShroud_003Ek__BackingField;
		EggFloat eggFloat34 = _003CBanish_003Ek__BackingField;
		_003CShroud_003Ek__BackingField = num;
		float value18 = default(float);
		EggFloat eggFloat35 = new EggFloat(value18, eggFloat34._eggVal);
		value18 = eggFloat34._val + other._003CBanish_003Ek__BackingField;
		_003CBanish_003Ek__BackingField = eggFloat35;
		EggFloat eggFloat36 = _003CMagnet_003Ek__BackingField;
		float value19 = default(float);
		EggFloat eggFloat37 = new EggFloat(value19, eggFloat36._eggVal);
		value19 = eggFloat36._val + other._003CMagnet_003Ek__BackingField;
		_003CMagnet_003Ek__BackingField = eggFloat37;
		EggFloat eggFloat38 = _003CCurse_003Ek__BackingField;
		float value20 = default(float);
		EggFloat eggFloat39 = new EggFloat(value20, eggFloat38._eggVal);
		value20 = eggFloat38._val + other._003CCurse_003Ek__BackingField;
		_003CCurse_003Ek__BackingField = eggFloat39;
		float num2 = _003CShields_003Ek__BackingField + other._003CShields_003Ek__BackingField;
		_003CShields_003Ek__BackingField = num2;
		int num3 = _003CCharm_003Ek__BackingField + other._003CCharm_003Ek__BackingField;
		_003CCharm_003Ek__BackingField = num3;
		float num4 = _003CDefang_003Ek__BackingField + other._003CDefang_003Ek__BackingField;
		_003CDefang_003Ek__BackingField = num4;
		float num5 = _003CThorns_003Ek__BackingField + other._003CThorns_003Ek__BackingField;
		_003CThorns_003Ek__BackingField = num5;
		float num6 = _003CInvulTimeBonus_003Ek__BackingField + other._003CInvulTimeBonus_003Ek__BackingField;
		_003CInvulTimeBonus_003Ek__BackingField = num6;
		float num7 = _003CFever_003Ek__BackingField + other._003CFever_003Ek__BackingField;
		_003CFever_003Ek__BackingField = num7;
		float num8 = _003CRecycle_003Ek__BackingField + other._003CRecycle_003Ek__BackingField;
		_003CRecycle_003Ek__BackingField = num8;
	}

	public PlayerModifierStats()
	{
		//IL_00ae: Expected F4, but got I4
		//IL_00f1: Expected F4, but got I4
		EggFloat eggFloat = new EggFloat(0f);
		_003CPower_003Ek__BackingField = eggFloat;
		EggFloat eggFloat2 = new EggFloat(0f);
		_003CArea_003Ek__BackingField = eggFloat2;
		EggFloat eggFloat3 = new EggFloat(0f);
		_003CSpeed_003Ek__BackingField = eggFloat3;
		EggFloat eggFloat4 = new EggFloat(0f);
		_003CMoveSpeed_003Ek__BackingField = eggFloat4;
		EggFloat eggFloat5 = null;
		float val = ((0 > 2139095040) ? 3.4028235E+38f : 0f);
		eggFloat5._val = val;
		float num = 3.4028235E+38f;
		bool flag = 0 > 2139095040;
		num = 3.4028235E+38f;
		if (!flag)
		{
			num = 0f;
		}
		eggFloat5._eggVal = num;
		_003CGrowth_003Ek__BackingField = eggFloat5;
		EggFloat eggFloat6 = new EggFloat(0f);
		_003CLuck_003Ek__BackingField = eggFloat6;
		EggFloat eggFloat7 = new EggFloat(0f);
		_003CDuration_003Ek__BackingField = eggFloat7;
		EggFloat eggFloat8 = new EggFloat(0f);
		_003CCooldown_003Ek__BackingField = eggFloat8;
		EggFloat eggFloat9 = new EggFloat(0f);
		_003CAmount_003Ek__BackingField = eggFloat9;
		EggFloat eggFloat10 = new EggFloat(0f);
		_003CArmor_003Ek__BackingField = eggFloat10;
		EggFloat eggFloat11 = new EggFloat(0f);
		_003CGreed_003Ek__BackingField = eggFloat11;
		EggFloat eggFloat12 = new EggFloat(0f);
		_003CRegen_003Ek__BackingField = eggFloat12;
		EggFloat eggFloat13 = new EggFloat(0f);
		_003CReRolls_003Ek__BackingField = eggFloat13;
		EggFloat eggFloat14 = new EggFloat(0f);
		_003CSkips_003Ek__BackingField = eggFloat14;
		EggFloat eggFloat15 = new EggFloat(0f);
		_003CMaxHp_003Ek__BackingField = eggFloat15;
		EggFloat eggFloat16 = new EggFloat(0f);
		_003CMagnet_003Ek__BackingField = eggFloat16;
		EggFloat eggFloat17 = new EggFloat(0f);
		_003CCurse_003Ek__BackingField = eggFloat17;
		EggFloat eggFloat18 = new EggFloat(0f);
		_003CBanish_003Ek__BackingField = eggFloat18;
		EggDouble eggDouble = new EggDouble(0.0);
		_003CRevivals_003Ek__BackingField = eggDouble;
	}
}
