using System.Collections.Generic;
using UnityEngine;

public class LiveRain : MonoBehaviour
{
	public float radius = 5f;

	public float dropsPerSecond = 30f;

	public float dropLifetime = 0.1f;

	public Transform fallDirTransform;

	public AudioSource masterHiAudioSource;

	public AudioSource hiAudioSource;

	public AudioSource loAudioSource;

	public SoundEnviron soundEnviron;

	public List<LiveRainDrop> drops;

	private float dropsThisFrame;

	private int lastAllocatedDropIndex;

	private RaycastHit hitInfo = default(RaycastHit);

	public const float kDropLength = 10f;

	private const float kCastMaxDist = 10f;

	public Vector3 fallDir
	{
		get
		{
			return fallDirTransform.forward;
		}
	}

	private void Start()
	{
		foreach (LiveRainDrop drop in drops)
		{
			drop.gameObject.SetActive(false);
		}
	}

	private void Update()
	{
		dropsThisFrame += dropsPerSecond * Clock.play.deltaTime;
		while (dropsThisFrame >= 1f)
		{
			LiveRainDrop liveRainDrop = AllocDrop();
			if (liveRainDrop != null)
			{
				CastDrop(liveRainDrop);
			}
			dropsThisFrame -= 1f;
		}
	}

	private static void MatchAudioSource(AudioSource src, AudioSource dst, float volumeScale = 1f)
	{
		if (src.isPlaying)
		{
			if (!dst.isPlaying)
			{
				dst.Play();
				dst.loop = src.loop;
			}
			dst.volume = src.volume * volumeScale;
			dst.panStereo = src.panStereo;
		}
		else if (dst.isPlaying)
		{
			dst.Stop();
		}
	}

	private void LateUpdate()
	{
		MatchAudioSource(masterHiAudioSource, hiAudioSource, 0.25f);
		if (hiAudioSource.isPlaying)
		{
			if (!loAudioSource.isPlaying)
			{
				loAudioSource.Play();
				loAudioSource.loop = true;
			}
			float y = Player.instance.eyePos.y;
			float num = Util.LerpScale(y, -3f, -0.9f, 0f, 1f);
			num = Mathf.Max(0f, num - hiAudioSource.volume / 0.25f);
			num = soundEnviron.fadedVolumeLevel * num;
			loAudioSource.volume = num;
		}
		else if (loAudioSource.isPlaying)
		{
			loAudioSource.Stop();
		}
	}

	private void CastDrop(LiveRainDrop drop)
	{
		int layerMask = ~(1 << LayerMask.NameToLayer("Player"));
		Vector2 vector = Player.instance.transform.position.ToVector2XZ() + radius * Random.insideUnitCircle;
		Vector3 vector2 = new Vector3(vector.x, Mathf.Max(Player.instance.footPos.y - 0.01f, 0f), vector.y);
		Vector3 origin = vector2 - fallDir * 10f * 0.5f;
		if (Physics.Raycast(origin, fallDir, out hitInfo, 10f, layerMask))
		{
			drop.transform.position = hitInfo.point;
			drop.lifetime = 0.01f * Mathf.Lerp(-1f, 1f, Random.value) + dropLifetime;
			drop.falling = true;
			drop.splashGo.transform.up = fallDir - 2f * Vector3.Dot(fallDir, hitInfo.normal) * hitInfo.normal;
			drop.gameObject.SetActive(true);
		}
	}

	private LiveRainDrop AllocDrop()
	{
		for (int i = 0; i < drops.Count; i++)
		{
			int index = (i + lastAllocatedDropIndex + 1) % drops.Count;
			LiveRainDrop liveRainDrop = drops[index];
			if (!liveRainDrop.falling)
			{
				lastAllocatedDropIndex = index;
				return liveRainDrop;
			}
		}
		lastAllocatedDropIndex = 0;
		return null;
	}
}
