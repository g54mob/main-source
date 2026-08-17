using System;
using Cpp2ILInjected;
using Newtonsoft.Json;
using UnityEngine;

namespace VampireSurvivors.Objects;

[Serializable]
public class ModifierStats
{
	private float _003CPower_003Ek__BackingField;

	private float _003CArea_003Ek__BackingField;

	private float _003CSpeed_003Ek__BackingField;

	private float _003CMoveSpeed_003Ek__BackingField;

	private float _003CGrowth_003Ek__BackingField;

	private float _003CLuck_003Ek__BackingField;

	private float _003CDuration_003Ek__BackingField;

	private float _003CCooldown_003Ek__BackingField;

	private float _003CAmount_003Ek__BackingField;

	private float _003CShields_003Ek__BackingField;

	private float _003CArmor_003Ek__BackingField;

	private float _003CGreed_003Ek__BackingField;

	private float _003CRegen_003Ek__BackingField;

	private double _003CRevivals_003Ek__BackingField;

	private float _003CReRolls_003Ek__BackingField;

	private float _003CSkips_003Ek__BackingField;

	private float _003CMaxHp_003Ek__BackingField;

	private float _003CMagnet_003Ek__BackingField;

	private float _003CCurse_003Ek__BackingField;

	private float _003CBanish_003Ek__BackingField;

	private float _003CShroud_003Ek__BackingField;

	private int _003CCharm_003Ek__BackingField;

	private float _003CDefang_003Ek__BackingField;

	private float _003CThorns_003Ek__BackingField;

	private float _003CInvulTimeBonus_003Ek__BackingField;

	private float _003CFever_003Ek__BackingField;

	private float _003CRecycle_003Ek__BackingField;

	public float Power
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

	public float Area
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

	public float Speed
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

	public float MoveSpeed
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

	public float Growth
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

	public float Luck
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

	public float Duration
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

	public float Cooldown
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

	public float Amount
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

	public float Armor
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

	public float Greed
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

	public float Regen
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

	public double Revivals
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

	public float ReRolls
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

	public float Skips
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

	public float MaxHp
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

	public float Magnet
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

	public float Curse
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

	public float Banish
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
		_003CPower_003Ek__BackingField = 0f;
		_003CSpeed_003Ek__BackingField = 0f;
		_003CGrowth_003Ek__BackingField = 0f;
		_003CDuration_003Ek__BackingField = 0f;
		_003CAmount_003Ek__BackingField = 0f;
		_003CArmor_003Ek__BackingField = 0f;
		_003CRegen_003Ek__BackingField = 0f;
		_003CRevivals_003Ek__BackingField = 0.0;
		_003CReRolls_003Ek__BackingField = 0f;
		_003CMaxHp_003Ek__BackingField = 0f;
		_003CCurse_003Ek__BackingField = 0f;
		_003CShroud_003Ek__BackingField = 0f;
		_003CDefang_003Ek__BackingField = 0f;
		_003CInvulTimeBonus_003Ek__BackingField = 0f;
		_003CRecycle_003Ek__BackingField = 0f;
	}

	public void Upgrade(ModifierStats other, bool multiplicativeMaxHp = false)
	{
		float num = _003CPower_003Ek__BackingField + other._003CPower_003Ek__BackingField;
		_003CPower_003Ek__BackingField = num;
		float num2 = _003CArea_003Ek__BackingField + other._003CArea_003Ek__BackingField;
		_003CArea_003Ek__BackingField = num2;
		float num3 = _003CSpeed_003Ek__BackingField + other._003CSpeed_003Ek__BackingField;
		_003CSpeed_003Ek__BackingField = num3;
		float num4 = _003CCooldown_003Ek__BackingField + other._003CCooldown_003Ek__BackingField;
		_003CCooldown_003Ek__BackingField = num4;
		float num5 = _003CAmount_003Ek__BackingField + other._003CAmount_003Ek__BackingField;
		_003CAmount_003Ek__BackingField = num5;
		float num6 = _003CMoveSpeed_003Ek__BackingField + other._003CMoveSpeed_003Ek__BackingField;
		_003CMoveSpeed_003Ek__BackingField = num6;
		float num7 = _003CGrowth_003Ek__BackingField + other._003CGrowth_003Ek__BackingField;
		_003CGrowth_003Ek__BackingField = num7;
		float num8 = _003CLuck_003Ek__BackingField + other._003CLuck_003Ek__BackingField;
		_003CLuck_003Ek__BackingField = num8;
		float num9 = _003CArmor_003Ek__BackingField + other._003CArmor_003Ek__BackingField;
		_003CArmor_003Ek__BackingField = num9;
		float num10 = _003CDuration_003Ek__BackingField + other._003CDuration_003Ek__BackingField;
		_003CDuration_003Ek__BackingField = num10;
		float num11 = _003CGreed_003Ek__BackingField + other._003CGreed_003Ek__BackingField;
		_003CGreed_003Ek__BackingField = num11;
		float num12 = _003CRegen_003Ek__BackingField + other._003CRegen_003Ek__BackingField;
		_003CRegen_003Ek__BackingField = num12;
		float num13;
		if (!multiplicativeMaxHp)
		{
			num13 = _003CMaxHp_003Ek__BackingField + other._003CMaxHp_003Ek__BackingField;
		}
		else
		{
			float num14 = _003CMaxHp_003Ek__BackingField * other._003CMaxHp_003Ek__BackingField;
			num13 = num14 + _003CMaxHp_003Ek__BackingField;
		}
		_003CMaxHp_003Ek__BackingField = num13;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,qword ptr [rdx+48h]\"");
		_003CRevivals_003Ek__BackingField = _003CRevivals_003Ek__BackingField;
		float num15 = _003CReRolls_003Ek__BackingField + other._003CReRolls_003Ek__BackingField;
		_003CReRolls_003Ek__BackingField = num15;
		float num16 = _003CSkips_003Ek__BackingField + other._003CSkips_003Ek__BackingField;
		_003CSkips_003Ek__BackingField = num16;
		float num17 = _003CShroud_003Ek__BackingField + other._003CShroud_003Ek__BackingField;
		_003CShroud_003Ek__BackingField = num17;
		float num18 = _003CBanish_003Ek__BackingField + other._003CBanish_003Ek__BackingField;
		_003CBanish_003Ek__BackingField = num18;
		float num19 = _003CMagnet_003Ek__BackingField + other._003CMagnet_003Ek__BackingField;
		_003CMagnet_003Ek__BackingField = num19;
		float num20 = _003CCurse_003Ek__BackingField + other._003CCurse_003Ek__BackingField;
		_003CCurse_003Ek__BackingField = num20;
		float num21 = _003CShields_003Ek__BackingField + other._003CShields_003Ek__BackingField;
		_003CShields_003Ek__BackingField = num21;
		int num22 = _003CCharm_003Ek__BackingField + other._003CCharm_003Ek__BackingField;
		_003CCharm_003Ek__BackingField = num22;
		float num23 = _003CDefang_003Ek__BackingField + other._003CDefang_003Ek__BackingField;
		_003CDefang_003Ek__BackingField = num23;
		float num24 = _003CThorns_003Ek__BackingField + other._003CThorns_003Ek__BackingField;
		_003CThorns_003Ek__BackingField = num24;
		float num25 = _003CInvulTimeBonus_003Ek__BackingField + other._003CInvulTimeBonus_003Ek__BackingField;
		_003CInvulTimeBonus_003Ek__BackingField = num25;
		float num26 = _003CFever_003Ek__BackingField + other._003CFever_003Ek__BackingField;
		_003CFever_003Ek__BackingField = num26;
		float num27 = _003CRecycle_003Ek__BackingField + other._003CRecycle_003Ek__BackingField;
		_003CRecycle_003Ek__BackingField = num27;
	}

	public void LogClass()
	{
		string message = JsonConvert.SerializeObject(this);
		Debug.Log(message);
	}

	public static ModifierStats operator *(ModifierStats stats, float f)
	{
		ModifierStats modifierStats = new ModifierStats();
		if (stats != null && modifierStats != null)
		{
			float num = f * stats._003CPower_003Ek__BackingField;
			modifierStats._003CPower_003Ek__BackingField = num;
			float num2 = f * stats._003CArea_003Ek__BackingField;
			modifierStats._003CArea_003Ek__BackingField = num2;
			float num3 = f * stats._003CSpeed_003Ek__BackingField;
			modifierStats._003CSpeed_003Ek__BackingField = num3;
			float num4 = f * stats._003CMoveSpeed_003Ek__BackingField;
			modifierStats._003CMoveSpeed_003Ek__BackingField = num4;
			float num5 = f * stats._003CGrowth_003Ek__BackingField;
			modifierStats._003CGrowth_003Ek__BackingField = num5;
			float num6 = f * stats._003CLuck_003Ek__BackingField;
			modifierStats._003CLuck_003Ek__BackingField = num6;
			float num7 = f * stats._003CDuration_003Ek__BackingField;
			modifierStats._003CDuration_003Ek__BackingField = num7;
			float num8 = f * stats._003CCooldown_003Ek__BackingField;
			modifierStats._003CCooldown_003Ek__BackingField = num8;
			float num9 = f * stats._003CAmount_003Ek__BackingField;
			modifierStats._003CAmount_003Ek__BackingField = num9;
			float num10 = f * stats._003CShields_003Ek__BackingField;
			modifierStats._003CShields_003Ek__BackingField = num10;
			float num11 = f * stats._003CArmor_003Ek__BackingField;
			modifierStats._003CArmor_003Ek__BackingField = num11;
			float num12 = f * stats._003CGreed_003Ek__BackingField;
			modifierStats._003CGreed_003Ek__BackingField = num12;
			float num13 = f * stats._003CRegen_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm6\"");
			modifierStats._003CRegen_003Ek__BackingField = num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm1,qword ptr [rdi+48h]\"");
			modifierStats._003CRevivals_003Ek__BackingField = 0.0;
			float num14 = f * stats._003CReRolls_003Ek__BackingField;
			modifierStats._003CReRolls_003Ek__BackingField = num14;
			float num15 = f * stats._003CSkips_003Ek__BackingField;
			modifierStats._003CSkips_003Ek__BackingField = num15;
			float num16 = f * stats._003CMaxHp_003Ek__BackingField;
			modifierStats._003CMaxHp_003Ek__BackingField = num16;
			float num17 = f * stats._003CMagnet_003Ek__BackingField;
			modifierStats._003CMagnet_003Ek__BackingField = num17;
			float num18 = f * stats._003CCurse_003Ek__BackingField;
			modifierStats._003CCurse_003Ek__BackingField = num18;
			float num19 = f * stats._003CBanish_003Ek__BackingField;
			modifierStats._003CBanish_003Ek__BackingField = num19;
			float num20 = f * stats._003CShroud_003Ek__BackingField;
			modifierStats._003CShroud_003Ek__BackingField = num20;
			float num21 = (float)stats._003CCharm_003Ek__BackingField * f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
			int num22 = default(int);
			modifierStats._003CCharm_003Ek__BackingField = num22;
			float num23 = f * stats._003CDefang_003Ek__BackingField;
			modifierStats._003CDefang_003Ek__BackingField = num23;
			float num24 = f * stats._003CThorns_003Ek__BackingField;
			modifierStats._003CThorns_003Ek__BackingField = num24;
			float num25 = f * stats._003CInvulTimeBonus_003Ek__BackingField;
			modifierStats._003CInvulTimeBonus_003Ek__BackingField = num25;
			float num26 = f * stats._003CFever_003Ek__BackingField;
			modifierStats._003CFever_003Ek__BackingField = num26;
			float num27 = f * stats._003CRecycle_003Ek__BackingField;
			modifierStats._003CRecycle_003Ek__BackingField = num27;
			return modifierStats;
		}
		return (ModifierStats)(object)new NullReferenceException();
	}
}
