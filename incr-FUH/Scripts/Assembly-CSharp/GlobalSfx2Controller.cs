using UnityEngine;

public class GlobalSfx2Controller : LocalSfx2Controller
{
	public static GlobalSfx2Controller Instance;

	public AudioSource SfxTest;

	public AudioSource MasterTest;

	protected override void Init()
	{
		Instance = this;
	}

	public void PlayTest()
	{
		SfxTest.Play();
	}

	public void PlayMasterTest()
	{
		MasterTest.Play();
	}
}
