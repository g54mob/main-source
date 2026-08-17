using UnityEngine;

public class AttackMuzzle : MonoBehaviour
{
	public RandomSfx randomSfx;

	public ParticleSystem ps;

	private float cliplength;

	private float volumeMultiplier = 1f;

	public float minVolumeMultiplier = 0.5f;

	public float maxInterval = 0.4f;

	public float minAudioCooldown = 0.06f;

	private float lastPlayedTime;

	public void Set(int quantity, float burstInterval)
	{
		RandomSfx randomSfx = this.randomSfx;
		AudioClip[] sounds = randomSfx.sounds;
		float length = sounds[0].length;
		cliplength = length;
		float fixedDeltaTime = Time.fixedDeltaTime;
		bool log = default(bool);
		float num = AudioSpamFilter.FindVolumeMultiplier(fixedDeltaTime, maxInterval, burstInterval, minVolumeMultiplier, log);
		volumeMultiplier = num;
	}

	public void Play()
	{
		float time = Time.time;
		float num = lastPlayedTime + minAudioCooldown;
		if (!(num > time))
		{
			float time2 = Time.time;
			lastPlayedTime = time2;
			if (randomSfx != null && randomSfx.enabled)
			{
				randomSfx.Play(0f, volumeMultiplier);
			}
			if (ps != null)
			{
				ps.Play();
			}
		}
	}

	private void OnValidate()
	{
		RandomSfx component = GetComponent<RandomSfx>();
		randomSfx = component;
		ParticleSystem component2 = GetComponent<ParticleSystem>();
		ps = component2;
	}
}
