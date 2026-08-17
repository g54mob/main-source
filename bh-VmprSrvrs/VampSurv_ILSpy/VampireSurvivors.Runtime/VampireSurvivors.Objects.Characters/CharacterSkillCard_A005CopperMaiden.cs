using Cpp2ILInjected;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class CharacterSkillCard_A005CopperMaiden : CharacterSkillCard_Base
{
	public CharacterSkillCard_A005CopperMaiden(ArcanaType type)
		: base(type)
	{
		float num = ((Edition == SkillCardEdition.Poly) ? 2f : ((Edition != SkillCardEdition.Inve) ? 1f : (-0.5f)));
		ModifierStats modifierStats = new ModifierStats();
		float num2 = num * 3f;
		float num3 = num * -0.6f;
		modifierStats._003CArmor_003Ek__BackingField = num2;
		modifierStats._003CMoveSpeed_003Ek__BackingField = num3;
		InitialBonus = modifierStats;
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
