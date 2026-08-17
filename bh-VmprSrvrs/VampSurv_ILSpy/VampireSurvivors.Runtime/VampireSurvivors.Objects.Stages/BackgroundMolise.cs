using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundMolise : BackgroundManager
{
	private float _restored;

	public override void Create()
	{
		base.Create();
		_restored = 0f;
	}

	public void RestoreHp(float value)
	{
		//IL_00f9: Expected O, but got I4
		if ((_restored = value + _restored) > 10000f)
		{
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			object obj = default(object);
			if (obj == null)
			{
				GameManager core2 = GM.Core;
				core2._playerOptions.RevealCharacter(CharacterType.PEPPINO);
				GameManager core3 = GM.Core;
				core3._playerOptions.UnlockCharacter(CharacterType.PEPPINO);
				GameManager core4 = GM.Core;
				core4._playerOptions.BuyCharacter(CharacterType.PEPPINO);
				GameManager core5 = GM.Core;
				core5._playerOptions.Save();
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Detune = -1000f;
				soundConfig.Rate = 0.5f;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ThingFound, soundConfig, 0f, 10, time);
			}
		}
	}
}
