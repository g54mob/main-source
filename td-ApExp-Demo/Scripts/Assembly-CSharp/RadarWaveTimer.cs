using UnityEngine;

[CreateAssetMenu(fileName = "2WaveTimer", menuName = "Radar/2WaveTimer")]
public class RadarWaveTimer : EnhancementRadar
{
	public override void OnApplied()
	{
		UIManager.Instance.WaveTimerUnlocked = true;
		LevelManager.Instance.LevelStarted += UIManager.Instance.HUD.ResetTimer;
	}

	public override void OnRemoved()
	{
		UIManager.Instance.WaveTimerUnlocked = false;
		LevelManager.Instance.LevelStarted -= UIManager.Instance.HUD.ResetTimer;
	}
}
