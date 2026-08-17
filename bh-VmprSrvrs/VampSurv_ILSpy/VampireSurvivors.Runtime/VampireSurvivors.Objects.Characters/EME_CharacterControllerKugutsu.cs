using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.NumberTypes;

namespace VampireSurvivors.Objects.Characters;

public class EME_CharacterControllerKugutsu : EME_CharacterControllerShowstopper
{
	public override void OnGlimmeredTechniqueLearned(WeaponType glimmerType)
	{
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CGrowth_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + 0.05f;
		playerStats._003CGrowth_003Ek__BackingField = eggFloat2;
		PlayerModifierStats playerStats2 = _playerStats;
		EggDouble eggDouble = playerStats2._003CRevivals_003Ek__BackingField;
		EggDouble eggDouble2 = new EggDouble(eggDouble._val, eggDouble._eggVal);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm7,qword ptr [188A10758h]\"");
		playerStats2._003CRevivals_003Ek__BackingField = eggDouble2;
	}

	public EME_CharacterControllerKugutsu()
	{
		base._morphDuration = 13000f;
		((CharacterController)this)._002Ector();
	}
}
