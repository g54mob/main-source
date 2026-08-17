namespace VampireSurvivors.Objects.Characters;

public class EME_CharacterControllerMrS : EME_CharacterControllerShowstopper
{
	public override int GlimmerComboModifier
	{
		get
		{
			//IL_000a: Expected I4, but got I8
			return -30;
		}
	}

	public EME_CharacterControllerMrS()
	{
		base._morphDuration = 13000f;
		((CharacterController)this)._002Ector();
	}
}
