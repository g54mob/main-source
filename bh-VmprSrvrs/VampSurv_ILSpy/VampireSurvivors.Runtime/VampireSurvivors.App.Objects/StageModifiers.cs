using System;
using Cpp2ILInjected;

namespace VampireSurvivors.App.Objects;

[Serializable]
public class StageModifiers
{
	private float? _003CTimeLimit_003Ek__BackingField;

	private float? _003CClockSpeed_003Ek__BackingField;

	private float? _003CPlayerPxSpeed_003Ek__BackingField;

	private float? _003CEnemySpeed_003Ek__BackingField;

	private float? _003CProjectileSpeed_003Ek__BackingField;

	private float? _003CGoldMultiplier_003Ek__BackingField;

	private float? _003CEnemyHealthMultiplier_003Ek__BackingField;

	private float? _003CLuckBonus_003Ek__BackingField;

	private float? _003CXpBonus_003Ek__BackingField;

	private float? _003CStartingSpawns_003Ek__BackingField;

	private float? _003CEndCycles_003Ek__BackingField;

	private TimeMods _003CTimeMods_003Ek__BackingField;

	private bool _003Cunlocked_003Ek__BackingField;

	private float _003CEnemyMinimumMul_003Ek__BackingField;

	private float _003CBGM_rate_003Ek__BackingField = 1f;

	private int _003CBGM_detune_003Ek__BackingField;

	private bool _003CBGM_ignoreModsForNewSoundtrack_003Ek__BackingField;

	private float _003CBGM_new_rate_003Ek__BackingField = 1f;

	private int _003CBGM_new_detune_003Ek__BackingField;

	private uint? _003Ctint_003Ek__BackingField;

	public float? TimeLimit
	{
		get
		{
			return _003CTimeLimit_003Ek__BackingField;
		}
		set
		{
			_003CTimeLimit_003Ek__BackingField = value;
		}
	}

	public float? ClockSpeed
	{
		get
		{
			return _003CClockSpeed_003Ek__BackingField;
		}
		set
		{
			_003CClockSpeed_003Ek__BackingField = value;
		}
	}

	public float? PlayerPxSpeed
	{
		get
		{
			return _003CPlayerPxSpeed_003Ek__BackingField;
		}
		set
		{
			_003CPlayerPxSpeed_003Ek__BackingField = value;
		}
	}

	public float? EnemySpeed
	{
		get
		{
			return _003CEnemySpeed_003Ek__BackingField;
		}
		set
		{
			_003CEnemySpeed_003Ek__BackingField = value;
		}
	}

	public float? ProjectileSpeed
	{
		get
		{
			return _003CProjectileSpeed_003Ek__BackingField;
		}
		set
		{
			_003CProjectileSpeed_003Ek__BackingField = value;
		}
	}

	public float? GoldMultiplier
	{
		get
		{
			return _003CGoldMultiplier_003Ek__BackingField;
		}
		set
		{
			_003CGoldMultiplier_003Ek__BackingField = value;
		}
	}

	public float? EnemyHealthMultiplier
	{
		get
		{
			return _003CEnemyHealthMultiplier_003Ek__BackingField;
		}
		set
		{
			_003CEnemyHealthMultiplier_003Ek__BackingField = value;
		}
	}

	public float? LuckBonus
	{
		get
		{
			return _003CLuckBonus_003Ek__BackingField;
		}
		set
		{
			_003CLuckBonus_003Ek__BackingField = value;
		}
	}

	public float? XpBonus
	{
		get
		{
			return _003CXpBonus_003Ek__BackingField;
		}
		set
		{
			_003CXpBonus_003Ek__BackingField = value;
		}
	}

	public float? StartingSpawns
	{
		get
		{
			return _003CStartingSpawns_003Ek__BackingField;
		}
		set
		{
			_003CStartingSpawns_003Ek__BackingField = value;
		}
	}

	public float? EndCycles
	{
		get
		{
			return _003CEndCycles_003Ek__BackingField;
		}
		set
		{
			_003CEndCycles_003Ek__BackingField = value;
		}
	}

	public TimeMods TimeMods
	{
		get
		{
			return _003CTimeMods_003Ek__BackingField;
		}
		set
		{
			_003CTimeMods_003Ek__BackingField = value;
		}
	}

	public bool unlocked
	{
		get
		{
			return _003Cunlocked_003Ek__BackingField;
		}
		set
		{
			_003Cunlocked_003Ek__BackingField = value;
		}
	}

	public float EnemyMinimumMul
	{
		get
		{
			return _003CEnemyMinimumMul_003Ek__BackingField;
		}
		set
		{
			_003CEnemyMinimumMul_003Ek__BackingField = value;
		}
	}

	public float BGM_rate
	{
		get
		{
			return _003CBGM_rate_003Ek__BackingField;
		}
		set
		{
			_003CBGM_rate_003Ek__BackingField = value;
		}
	}

	public int BGM_detune
	{
		get
		{
			return _003CBGM_detune_003Ek__BackingField;
		}
		set
		{
			_003CBGM_detune_003Ek__BackingField = value;
		}
	}

	public bool BGM_ignoreModsForNewSoundtrack
	{
		get
		{
			return _003CBGM_ignoreModsForNewSoundtrack_003Ek__BackingField;
		}
		set
		{
			_003CBGM_ignoreModsForNewSoundtrack_003Ek__BackingField = value;
		}
	}

	public float BGM_new_rate
	{
		get
		{
			return _003CBGM_new_rate_003Ek__BackingField;
		}
		set
		{
			_003CBGM_new_rate_003Ek__BackingField = value;
		}
	}

	public int BGM_new_detune
	{
		get
		{
			return _003CBGM_new_detune_003Ek__BackingField;
		}
		set
		{
			_003CBGM_new_detune_003Ek__BackingField = value;
		}
	}

	public uint? tint
	{
		get
		{
			return _003Ctint_003Ek__BackingField;
		}
		set
		{
			_003Ctint_003Ek__BackingField = value;
		}
	}

	public void SetStageDefaults()
	{
		//IL_0011: Expected O, but got I4
		//IL_001c: Expected O, but got I4
		//IL_0027: Expected O, but got I4
		//IL_0032: Expected O, but got I4
		//IL_003d: Expected O, but got I4
		//IL_0048: Expected O, but got I4
		//IL_0053: Expected O, but got I4
		//IL_005e: Expected O, but got I4
		//IL_0069: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_007f: Expected O, but got I4
		//IL_009b: Expected O, but got I4
		//IL_00a9: Expected O, but got I4
		//IL_00b7: Expected O, but got I4
		_003CTimeLimit_003Ek__BackingField = (float?)(object)1;
		_003CClockSpeed_003Ek__BackingField = (float?)(object)1;
		_003CPlayerPxSpeed_003Ek__BackingField = (float?)(object)1;
		_003CEnemySpeed_003Ek__BackingField = (float?)(object)1;
		_003CProjectileSpeed_003Ek__BackingField = (float?)(object)1;
		_003CGoldMultiplier_003Ek__BackingField = (float?)(object)1;
		_003CEnemyHealthMultiplier_003Ek__BackingField = (float?)(object)1;
		_003CXpBonus_003Ek__BackingField = (float?)(object)1;
		_003CStartingSpawns_003Ek__BackingField = (float?)(object)1;
		_003CLuckBonus_003Ek__BackingField = (float?)(object)1;
		_003CEndCycles_003Ek__BackingField = (float?)(object)1;
		TimeMods timeMods = new TimeMods();
		timeMods.HpPerMinute = (float?)(object)1;
		timeMods.SpeedPerMinute = (float?)(object)1;
		timeMods.Start = (float?)(object)1;
		_003CTimeMods_003Ek__BackingField = timeMods;
	}

	public void Add(StageModifiers data)
	{
		//IL_003b: Expected O, but got I4
		//IL_002d: Expected O, but got I4
		//IL_0057: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		//IL_0065: Expected O, but got I4
		//IL_008f: Expected O, but got I4
		//IL_0081: Expected O, but got I4
		//IL_00ab: Expected O, but got I4
		//IL_009d: Expected O, but got I4
		//IL_00c7: Expected O, but got I4
		//IL_00b9: Expected O, but got I4
		//IL_00e3: Expected O, but got I4
		//IL_00d5: Expected O, but got I4
		//IL_00ff: Expected O, but got I4
		//IL_00f1: Expected O, but got I4
		//IL_0337: Expected O, but got I4
		//IL_0183: Expected O, but got I4
		//IL_0175: Expected O, but got I4
		//IL_01a5: Expected O, but got I4
		//IL_01bc: Expected O, but got I4
		if (data == null)
		{
			return;
		}
		float? num = (float?)(((object)_003CPlayerPxSpeed_003Ek__BackingField == null) ? ((object)0) : ((object)1));
		_003CPlayerPxSpeed_003Ek__BackingField = num;
		float? num2 = (float?)(((object)_003CEnemySpeed_003Ek__BackingField == null) ? ((object)0) : ((object)1));
		_003CEnemySpeed_003Ek__BackingField = num2;
		float? num3 = (float?)(((object)_003CProjectileSpeed_003Ek__BackingField == null) ? ((object)0) : ((object)1));
		_003CProjectileSpeed_003Ek__BackingField = num3;
		float? num4 = (float?)(((object)_003CGoldMultiplier_003Ek__BackingField == null) ? ((object)0) : ((object)1));
		_003CGoldMultiplier_003Ek__BackingField = num4;
		float? num5 = (float?)(((object)_003CEnemyHealthMultiplier_003Ek__BackingField == null) ? ((object)0) : ((object)1));
		_003CEnemyHealthMultiplier_003Ek__BackingField = num5;
		float? num6 = (float?)(((object)_003CLuckBonus_003Ek__BackingField == null) ? ((object)0) : ((object)1));
		_003CLuckBonus_003Ek__BackingField = num6;
		float? num7 = (float?)(((object)_003CXpBonus_003Ek__BackingField == null) ? ((object)0) : ((object)1));
		_003CXpBonus_003Ek__BackingField = num7;
		float? num8 = (float?)(((object)_003CStartingSpawns_003Ek__BackingField == null) ? ((object)0) : ((object)1));
		_003CStartingSpawns_003Ek__BackingField = num8;
		if (data._003CTimeMods_003Ek__BackingField != null)
		{
			TimeMods timeMods = _003CTimeMods_003Ek__BackingField;
			TimeMods timeMods2 = data._003CTimeMods_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ r8_v2 (VampireSurvivors.App.Objects.TimeMods)+14]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rax_v19 (VampireSurvivors.App.Objects.TimeMods)+14]");
			TimeMods timeMods3 = default(TimeMods);
			if (num9 <= 0)
			{
				timeMods.Start = (float?)(object)1;
				timeMods3 = _003CTimeMods_003Ek__BackingField;
			}
			float? hpPerMinute = (float?)(((object)timeMods3.HpPerMinute == null) ? ((object)0) : ((object)1));
			timeMods3.HpPerMinute = hpPerMinute;
			TimeMods timeMods4 = _003CTimeMods_003Ek__BackingField;
			bool flag = (object)timeMods4.SpeedPerMinute == null;
			float? speedPerMinute = (float?)(object)0;
			if (!flag)
			{
				speedPerMinute = (float?)(object)1;
			}
			timeMods4.SpeedPerMinute = speedPerMinute;
		}
	}

	public void Set(StageModifiers data)
	{
		//IL_0037: Expected O, but got I4
		//IL_00fb: Expected O, but got I4
		//IL_0128: Expected O, but got I4
		//IL_0155: Expected O, but got I4
		//IL_0182: Expected O, but got I4
		//IL_01af: Expected O, but got I4
		//IL_01dc: Expected O, but got I4
		//IL_01e7: Expected O, but got I4
		//IL_0210: Expected O, but got I4
		//IL_021b: Expected O, but got I4
		//IL_0094: Expected O, but got I4
		//IL_00b1: Expected O, but got I4
		//IL_00ce: Expected O, but got I4
		if (data == null)
		{
			return;
		}
		if ((object)data._003CTimeLimit_003Ek__BackingField != null)
		{
		}
		_003CTimeLimit_003Ek__BackingField = (float?)(object)1;
		if ((object)data._003CClockSpeed_003Ek__BackingField != null)
		{
		}
		_003CClockSpeed_003Ek__BackingField = (float?)(object)1;
		if ((object)data._003CPlayerPxSpeed_003Ek__BackingField != null)
		{
		}
		_003CPlayerPxSpeed_003Ek__BackingField = (float?)(object)1;
		if ((object)data._003CEnemySpeed_003Ek__BackingField != null)
		{
		}
		_003CEnemySpeed_003Ek__BackingField = (float?)(object)1;
		if ((object)data._003CProjectileSpeed_003Ek__BackingField != null)
		{
		}
		_003CProjectileSpeed_003Ek__BackingField = (float?)(object)1;
		if ((object)data._003CGoldMultiplier_003Ek__BackingField != null)
		{
		}
		_003CGoldMultiplier_003Ek__BackingField = (float?)(object)1;
		if ((object)data._003CEnemyHealthMultiplier_003Ek__BackingField != null)
		{
		}
		_003CEnemyHealthMultiplier_003Ek__BackingField = (float?)(object)1;
		_003CLuckBonus_003Ek__BackingField = (float?)(object)1;
		if ((object)data._003CXpBonus_003Ek__BackingField == null)
		{
			_003CXpBonus_003Ek__BackingField = (float?)(object)1;
			_003CStartingSpawns_003Ek__BackingField = (float?)(object)1;
			if (data._003CTimeMods_003Ek__BackingField != null)
			{
				TimeMods timeMods = _003CTimeMods_003Ek__BackingField;
				timeMods.Start = (float?)(object)1;
				TimeMods timeMods2 = _003CTimeMods_003Ek__BackingField;
				timeMods2.HpPerMinute = (float?)(object)1;
				TimeMods timeMods3 = _003CTimeMods_003Ek__BackingField;
				timeMods3.SpeedPerMinute = (float?)(object)1;
			}
		}
	}
}
