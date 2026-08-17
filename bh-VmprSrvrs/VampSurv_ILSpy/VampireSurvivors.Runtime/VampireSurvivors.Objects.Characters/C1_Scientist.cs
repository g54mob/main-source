using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters;

public class C1_Scientist : CharacterController
{
	public override void LevelUp()
	{
		base.LevelUp();
		if (base._level == 10 || base._level == 20 || base._level == 30 || base._level == 40 || base._level == 50)
		{
			GM.Core.QueueEnterSkillSelection(this);
		}
	}
}
