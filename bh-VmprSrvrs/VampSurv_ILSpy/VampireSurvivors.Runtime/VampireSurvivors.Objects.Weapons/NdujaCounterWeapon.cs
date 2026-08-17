using Cpp2ILInjected;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class NdujaCounterWeapon : Weapon
{
	protected override void Awake()
	{
		base.Awake();
		((Equipment)this)._003CShowInRecap_003Ek__BackingField = false;
	}

	public override void InternalUpdate()
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		float num = deltaTime * 1000f;
		float num2 = (base._003CTotalTime_003Ek__BackingField = num + base._003CTotalTime_003Ek__BackingField);
		PlayerModifierStats playerStats = characterController._playerStats;
		EggFloat eggFloat = playerStats._003CDuration_003Ek__BackingField;
		float num3 = eggFloat._eggVal + eggFloat._val;
		object obj = num3 & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num3 & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875346E5h\"");
				if (num3 == -1f / 0f)
				{
					num3 = -3.4028235E+38f;
				}
				goto IL_016e;
			}
		}
		num3 = 3.4028235E+38f;
		goto IL_016e;
		IL_016e:
		float num4 = num3 * 10000f;
		if (num2 > num4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE570");
			if (_firingTimer != null)
			{
				_firingTimer.Cancel();
			}
		}
	}

	protected override void MakeLevelOne()
	{
		base.MakeLevelOne();
		base._003CTotalTime_003Ek__BackingField = 0f;
	}
}
