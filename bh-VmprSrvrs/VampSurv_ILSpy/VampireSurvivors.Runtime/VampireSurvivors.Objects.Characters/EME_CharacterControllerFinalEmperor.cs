namespace VampireSurvivors.Objects.Characters;

public class EME_CharacterControllerFinalEmperor : EME_CharacterControllerShowstopper
{
	public override int GlimmerComboModifier
	{
		get
		{
			//IL_000a: Expected I4, but got I8
			return -1;
		}
	}

	public EME_CharacterControllerFinalEmperor()
	{
		base._morphDuration = 13000f;
		((CharacterController)this)._002Ector();
	}
}
