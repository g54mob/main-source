using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.NumberTypes;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_EnemiesCount_AddRevives : CharacterSkillCard_Base
{
	protected override int[] bonusTresholds => new int[3] { 1000, 5000, 10000 };

	public SubSkillCard_EnemiesCount_AddRevives(ArcanaType type)
		: base(type)
	{
	}

	public override void Update()
	{
		base.Update();
		Update_CountEnemies();
	}

	protected override void OnEnemiesCountReached()
	{
		CharacterController linkedCharacter = LinkedCharacter;
		PlayerModifierStats playerStats = linkedCharacter._playerStats;
		EggDouble eggDouble = playerStats._003CRevivals_003Ek__BackingField;
		EggDouble eggDouble2 = new EggDouble(eggDouble._val, eggDouble._eggVal);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm7,qword ptr [188A10758h]\"");
		playerStats._003CRevivals_003Ek__BackingField = eggDouble2;
	}
}
