using UnityEngine;

public class Endings_AnimHelper : MonoBehaviour
{
	public void AnimEvent_PlayerTVBwompBlinkSFX()
	{
		AudioManager.Singleton.PlaySFX_TvBwomp(base.transform.position);
	}

	public void AnimEvent_CutToBlack()
	{
		CutscenesManager.Singleton.PiggyEnding_CutToBlack();
	}

	public void AnimEvent_PlaySFX_ChainsawThud()
	{
		AudioManager.Singleton.PlaySFX_ChainsawThud(base.transform.position);
	}

	public void AnimEvent_ChainsawScreenEffects_On()
	{
		VcrIntroManager.Singleton.SetGlitchedChainsawScreenEffects(_val: true);
		CutscenesManager.Singleton.StartChainsawCuttingSFX();
	}

	public void AnimEvent_ChainsawScreenEffects_Off()
	{
		VcrIntroManager.Singleton.SetGlitchedChainsawScreenEffects(_val: false);
		CutscenesManager.Singleton.StopChainsawCuttingSFX();
		CutscenesManager.Singleton.StopRadioMusic_MurderMusic();
	}

	public void AnimEvent_PlayDistortedScream()
	{
		AudioManager.Singleton.PlaySFX_DistortedScream();
	}

	public void AnimEvent_ShowEjectBlueScreen()
	{
		VcrIntroManager.Singleton.StartEnding_EJECT();
	}

	public void AnimEvent_PlaySFX_Wink()
	{
		CutscenesManager.Singleton.PlaySFX_ChainsawWink();
		CutscenesManager.Singleton.ge_WinkSparkle_Particles.Play();
	}

	public void AnimEvent_PlaySFX_RadioLanding()
	{
		CutscenesManager.Singleton.PlaySFX_RadioLanding();
	}

	public void AnimEvent_PlaySFX_RadioButtonClick()
	{
		CutscenesManager.Singleton.PlaySFX_RadioButtonClick();
	}

	public void AnimEvent_PlayMusic_SillyMusic()
	{
		CutscenesManager.Singleton.PlayRadioMusic_SillyMusic();
	}

	public void AnimEvent_PlayMusic_MurderMusic()
	{
		CutscenesManager.Singleton.PlayRadioMusic_MurderMusic();
	}

	public void AnimEvent_StopMusic_SillyMusic()
	{
		CutscenesManager.Singleton.StopRadioMusic_SillyMusic();
	}

	public void AnimEvent_StopMusic_MurderMusic()
	{
		CutscenesManager.Singleton.StopRadioMusic_MurderMusic();
		CutscenesManager.Singleton.StopChainsawRumbling();
	}

	public void AnimEvent_MsRainbowMoveSpookyJitter()
	{
		VcrIntroManager.Singleton.StartGlitchedOutBlackStarOrbEffect(1.5f);
		AudioManager.Singleton.PlaySFX_MsRainbowMoveJitter(GameManager.Singleton.playerObject.transform.position);
	}
}
