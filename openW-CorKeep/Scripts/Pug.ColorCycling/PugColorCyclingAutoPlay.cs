using Pug.UnityExtensions;
using UnityEngine;

[RequireComponent(typeof(PugColorCyclingController))]
public class PugColorCyclingAutoPlay : MonoBehaviour
{
	public enum AutoPlayType
	{
		PlayPatternOnLoop = 0,
		PlayPatternOnce = 10,
		ReplayPatternAtInterval = 20,
		SetPaletteFromPatternFrame0 = 30
	}

	public AutoPlayType autoPlayType;

	public int patternID;

	[Header("Settings for ReplayPatternAtInterval")]
	public float replayInterval = 5f;

	private PugColorCyclingController pfx;

	private TimerSimple timer;

	private void Awake()
	{
		pfx = GetComponent<PugColorCyclingController>();
	}

	private void Start()
	{
		switch (autoPlayType)
		{
		case AutoPlayType.ReplayPatternAtInterval:
			pfx.Play(patternID);
			timer.Start(replayInterval);
			break;
		case AutoPlayType.PlayPatternOnce:
			pfx.Play(patternID);
			base.enabled = false;
			break;
		case AutoPlayType.PlayPatternOnLoop:
			pfx.Play(patternID, loop: true);
			base.enabled = false;
			break;
		case AutoPlayType.SetPaletteFromPatternFrame0:
			pfx.SetPaletteFromPatternFrame(patternID);
			base.enabled = false;
			break;
		}
	}

	private void Update()
	{
		if (timer.isRunning && timer.isTimerElapsed)
		{
			pfx.Play(patternID);
			timer.Start();
		}
	}
}
