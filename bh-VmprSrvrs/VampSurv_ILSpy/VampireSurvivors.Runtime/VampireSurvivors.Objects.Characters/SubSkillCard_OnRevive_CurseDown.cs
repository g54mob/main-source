using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_OnRevive_CurseDown : CharacterSkillCard_Base
{
	public SubSkillCard_OnRevive_CurseDown(ArcanaType type)
		: base(type)
	{
	}

	public override void OnOwnerRevived(float percentage = 1f, bool instantRevival = false)
	{
		//IL_0065: Invalid comparison between F4 and I
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		//IL_008c: Expected F4, but got I
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		base.OnOwnerRevived(percentage, instantRevival);
		CharacterController linkedCharacter = LinkedCharacter;
		PlayerModifierStats playerStats = linkedCharacter._playerStats;
		EggFloat eggFloat = playerStats._003CCurse_003Ek__BackingField;
		CharacterController linkedCharacter2 = LinkedCharacter;
		float num = eggFloat._val - 0.2f;
		PlayerModifierStats playerStats2 = linkedCharacter2._playerStats;
		float num2 = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10024]");
		if (num2 < 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10024]");
			num = 0f;
		}
		EggFloat eggFloat2 = playerStats2._003CCurse_003Ek__BackingField;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018757C3FBh\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				goto IL_016e;
			}
		}
		num = 3.4028235E+38f;
		goto IL_016e;
		IL_016e:
		eggFloat2._val = num;
		GameManager core = GM.Core;
		core._stage.RecalculateCurseAndCharm();
	}
}
