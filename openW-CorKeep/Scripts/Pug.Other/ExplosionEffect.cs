using Pug.UnityExtensions;
using UnityEngine;

public class ExplosionEffect : PoolableSimple
{
	public ParticleSystem explosion;

	public Light lightSource;

	private TimerSimple timer = new TimerSimple(1f, false, false);

	private void Awake()
	{
		explosion.gameObject.SetActive(value: false);
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		timer.Start();
		explosion.gameObject.SetActive(value: true);
		explosion.Play(withChildren: true);
		AudioManager.SfxFollowTransform(SfxID.bomb, base.transform, 1f, 1f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
		WaterSim.AddImpulse(base.transform.position, 2f, 10f);
	}

	public static void Play(Vector3 position)
	{
		Manager.memory.GetFreeComponent<ExplosionEffect>().transform.position = position;
	}

	private void LateUpdate()
	{
		if (!timer.isRunning || timer.isTimerElapsed)
		{
			Free();
		}
		else
		{
			lightSource.range = Mathf.Lerp(5f, 0f, timer.elapsedRatio);
		}
	}
}
