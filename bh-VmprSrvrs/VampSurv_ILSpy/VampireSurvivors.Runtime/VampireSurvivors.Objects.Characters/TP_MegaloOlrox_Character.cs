namespace VampireSurvivors.Objects.Characters;

public class TP_MegaloOlrox_Character : TP_Olrox_Character
{
	private bool firstUpdateDone;

	protected override void OnUpdate()
	{
		base.OnUpdate();
		if (!firstUpdateDone && _isInitialized)
		{
			firstUpdateDone = true;
			PermanentMorph();
		}
	}

	public TP_MegaloOlrox_Character()
	{
		base._morphDuration = 30000f;
		base._finalThreshold = 15000;
		base._thresholds = new int[8] { 1000, 3000, 5000, 7000, 9000, 11000, 13000, 15000 };
		((CharacterController)this)._002Ector();
	}
}
