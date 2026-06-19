using System;
using System.Collections;

[Serializable]
public class FadeOutInCinematic : CinematicEvent
{
	public float StartWaitTime;

	public float FadeTime;

	public float FadedWaitTime;

	public Action OnBlackAction;

	public override IEnumerator DoCinematicAction()
	{
		return null;
	}
}
