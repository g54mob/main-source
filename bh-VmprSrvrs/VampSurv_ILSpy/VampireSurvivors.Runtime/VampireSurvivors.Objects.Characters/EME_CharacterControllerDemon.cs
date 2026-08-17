using Cpp2ILInjected;
using VampireSurvivors.Framework.NumberTypes;

namespace VampireSurvivors.Objects.Characters;

public class EME_CharacterControllerDemon : CharacterController
{
	private float _techniquesCount;

	private float _bonusPower;

	public override float PPower()
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + _bonusPower;
		float num = eggFloat2._eggVal + eggFloat2._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018764E0D6h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				return num;
			}
		}
		return 3.4028235E+38f;
	}

	public override void OnGlimmeredTechniqueFired()
	{
		//IL_002f: Invalid comparison between I4 and F4
		//IL_0041: Expected F4, but got I4
		float num = ++_techniquesCount;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FD90");
		bool flag = !(0f < num);
		float num2 = 0f;
		if (!flag)
		{
			num2 = num;
		}
		float bonusPower = num2 * 0.25f;
		_bonusPower = bonusPower;
	}
}
