using Cpp2ILInjected;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class CharacterSkillCard_A017GlassRose : CharacterSkillCard_Base
{
	public CharacterSkillCard_A017GlassRose(ArcanaType type)
		: base(type)
	{
		InitialBonus = new ModifierStats
		{
			_003CFever_003Ek__BackingField = 0.5f,
			_003CCharm_003Ek__BackingField = 50,
			_003CInvulTimeBonus_003Ek__BackingField = -100f
		};
		AvailableSlots = 3;
	}

	protected override void OnActivate_Gala()
	{
		//IL_004f: Expected I, but got O
		ArcanaType galaType = base.GalaType;
		if (galaType != ArcanaType.VOID)
		{
			ArcanaType galaType2 = base.GalaType;
			AddSubCard(galaType2);
			int availableSlots = AvailableSlots - 1;
			AvailableSlots = availableSlots;
		}
		SubSkillCard_XLevel_MaxHP5 subSkillCard_XLevel_MaxHP = new SubSkillCard_XLevel_MaxHP5(ArcanaType.SUB_XLEVEL_MAXHP5);
		subSkillCard_XLevel_MaxHP.Edition = Edition;
		nint num = (nint)subSkillCard_XLevel_MaxHP;
		subSkillCard_XLevel_MaxHP.SetLinkedCharacter(LinkedCharacter);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1A80");
		int availableSlots2 = AvailableSlots - 1;
		AvailableSlots = availableSlots2;
	}
}
