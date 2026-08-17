using Cpp2ILInjected;

namespace VampireSurvivors.Objects.Weapons;

public class ConeOfColdCounterWeapon : Weapon
{
	protected override void Awake()
	{
		base.Awake();
		base._003CFreezeChance_003Ek__BackingField = 1f;
		((Equipment)this)._003CShowInRecap_003Ek__BackingField = false;
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = (base._003CTotalTime_003Ek__BackingField = num + base._003CTotalTime_003Ek__BackingField);
		float num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PDuration();
		float num4 = deltaTime * 10000f;
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
