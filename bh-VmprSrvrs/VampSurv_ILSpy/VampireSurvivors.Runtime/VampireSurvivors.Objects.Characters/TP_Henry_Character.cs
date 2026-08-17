using System.Collections.Generic;
using Coherence.Toolkit;
using Cpp2ILInjected;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;

namespace VampireSurvivors.Objects.Characters;

public class TP_Henry_Character : TP_Character
{
	private float MaxBonus = 1f;

	private float MaxEnemies = 300f;

	public float currentBonus;

	public override float PLuck()
	{
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CLuck_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + currentBonus;
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		WickedSeason wickedSeason = arcanaManager._wickedSeason;
		float eggValue = default(float);
		float value2 = default(float);
		EggFloat eggFloat3 = new EggFloat(value2, eggValue);
		eggValue = eggFloat2._eggVal * wickedSeason._luck;
		value2 = eggFloat2._val * wickedSeason._luck;
		if (eggFloat3._val > MaxReachedPLuck)
		{
			MaxReachedPLuck = eggFloat3._val;
		}
		if (MinReachedPLuck > eggFloat3._val)
		{
			MinReachedPLuck = eggFloat3._val;
		}
		return eggFloat3._val;
	}

	public override float PArea()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CArea_003Ek__BackingField;
		float num = eggFloat._eggVal + eggFloat._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001876348B0h\"");
				if (num == -1f / 0f)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					object obj3 = -3.4028235E+38f & 0;
					return (float)obj3 + currentBonus;
				}
				goto IL_00fc;
			}
		}
		num = 3.4028235E+38f;
		goto IL_00fc;
		IL_00fc:
		float num2 = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj4 = num2 & 0;
		return (float)obj4 + currentBonus;
	}

	private void LateUpdate()
	{
		//IL_006f: Expected O, but got I
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v9 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v9 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v9 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		GameManager core = GM.Core;
		Stage stage = core._stage;
		List<EnemyController> spawnedEnemies = stage._spawnedEnemies;
		float num = (float)spawnedEnemies._size / MaxEnemies;
		bool flag3 = !(1f > num);
		float num2 = 1f;
		if (!flag3)
		{
			num2 = num;
		}
		float num3 = num2 * MaxBonus;
		currentBonus = num3;
	}
}
