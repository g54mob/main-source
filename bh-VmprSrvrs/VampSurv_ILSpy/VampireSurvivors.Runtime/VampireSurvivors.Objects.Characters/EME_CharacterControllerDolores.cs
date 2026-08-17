using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Objects.Algorithm;

namespace VampireSurvivors.Objects.Characters;

public class EME_CharacterControllerDolores : EME_CharacterControllerShowstopper
{
	private float _specialCDBonus;

	public override void DoPostRevivalActions(CharacterController revived, bool instantRevival = false)
	{
		//IL_00ac: Expected O, but got I4
		//IL_004b: Expected O, but got I4
		bool flag = revived._deficiencyControl == null;
		bool flag2 = true;
		if (!flag)
		{
			CharacterADControl deficiencyControl = revived._deficiencyControl;
			object obj = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
			bool flag3 = obj == null;
			flag2 = !flag3;
		}
		int num = revived._PlayerIndex >> 31;
		int num2 = (flag2 ? 1 : 0) & num;
		bool flag4 = num2 == 0;
		object obj2 = !flag4;
		if (obj2 == null)
		{
			StartShowstopper();
		}
	}

	protected override void OnShowStopperStarted()
	{
		if (0.2f > _specialCDBonus)
		{
			float specialCDBonus = _specialCDBonus + 0.008f;
			PlayerModifierStats playerStats = _playerStats;
			_specialCDBonus = specialCDBonus;
			EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val - 0.008f;
			playerStats._003CCooldown_003Ek__BackingField = eggFloat2;
		}
	}

	public EME_CharacterControllerDolores()
	{
		base._morphDuration = 13000f;
		((CharacterController)this)._002Ector();
	}
}
