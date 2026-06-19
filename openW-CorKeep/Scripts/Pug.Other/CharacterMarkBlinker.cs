using Pug.UnityExtensions;
using UnityEngine;

public class CharacterMarkBlinker : MonoBehaviour
{
	public SpriteRenderer sr;

	private TimerSimple blinkTimer = new TimerSimple(0.5f, unscaled: true);

	public void EnableAndResetBlink()
	{
		sr.enabled = true;
		blinkTimer.Start(0.5f);
		base.gameObject.SetActive(value: true);
	}

	private void Update()
	{
		if (!blinkTimer.isRunning || blinkTimer.isTimerElapsed)
		{
			sr.enabled = !sr.enabled;
			blinkTimer.Start(sr.enabled ? 0.5f : 0.2f);
		}
	}
}
