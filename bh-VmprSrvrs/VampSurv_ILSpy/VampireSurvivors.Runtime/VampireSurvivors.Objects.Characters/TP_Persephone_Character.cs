namespace VampireSurvivors.Objects.Characters;

public class TP_Persephone_Character : TP_Character
{
	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		EnableDestroyDestructiblesOnTouch();
	}
}
