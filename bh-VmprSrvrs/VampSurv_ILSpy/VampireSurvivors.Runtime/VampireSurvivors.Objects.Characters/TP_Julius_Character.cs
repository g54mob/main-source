using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;

namespace VampireSurvivors.Objects.Characters;

public class TP_Julius_Character : TP_Character
{
	private float mightPercIncrease;

	public override void AfterFullInitialization()
	{
		//IL_004c: Expected O, but got I
		//IL_00a6: Expected O, but got I
		base.AfterFullInitialization();
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<System.Int32Enum> list = (List<System.Int32Enum>)(object)arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r8_v3+18]");
		if (num >= 0)
		{
			list.AddWithResize((System.Int32Enum)19);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 19;
		}
		GameManager core2 = GM.Core;
		core2._arcanaManager.TriggerArcana(ArcanaType.T19_FIRE);
		GameManager core3 = GM.Core;
		ArcanaManager arcanaManager2 = core3._arcanaManager;
		int num2 = arcanaManager2._003CMaxArcanasPerRun_003Ek__BackingField + 1;
		arcanaManager2._003CMaxArcanasPerRun_003Ek__BackingField = num2;
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		float num = base.MaxHp();
		float num2 = base.MaxHp();
		object obj = default(object);
		float num3 = (float)obj / 180f;
		float num4 = ((CharacterController)this)._currentHp / (float)obj;
		float num5 = 1f - num4;
		float num6 = num5 * num3;
		float num7 = num6 + 1f;
		mightPercIncrease = num7;
	}

	public override float PPower()
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
		float eggValue = default(float);
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggValue);
		eggValue = eggFloat._eggVal * mightPercIncrease;
		value = eggFloat._val * mightPercIncrease;
		float num = eggFloat2._eggVal + eggFloat2._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018763933Bh\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				return num;
			}
		}
		return 3.4028235E+38f;
	}
}
