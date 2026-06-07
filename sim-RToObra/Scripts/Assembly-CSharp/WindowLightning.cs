using System.Collections.Generic;
using UnityEngine;

public class WindowLightning : MonoBehaviour
{
	private class SubdueAudioSource
	{
		public AudioSource source;

		public float startVolume;

		public float endVolume;

		public SubdueAudioSource(AudioSource source_, float endVolumePerc)
		{
			source = source_;
			startVolume = source.volume;
			endVolume = startVolume * endVolumePerc;
		}

		public void Update(SoundEnviron soundEnviron, float time)
		{
			soundEnviron.SetDefaultVolume(source, Util.LerpScale(time, 0f, 10f, startVolume, endVolume));
		}
	}

	private enum State
	{
		Idle = 0,
		Flashing = 1
	}

	public GameObject officeRoot;

	public Light windowLight0;

	public Light windowLight1;

	public SoundEnviron soundEnviron;

	public AudioSource clockAudioSource;

	public AudioSource rainAudioSource;

	public AudioSource rainPitter1AudioSource;

	public AudioSource rainPitter2AudioSource;

	public AudioSource thunderAudioSource;

	public AudioClip[] thunderAudioClips;

	[Space]
	[Readonly]
	public Transform groupRoot;

	[Readonly]
	public Transform spot0;

	[Readonly]
	public Transform spot1;

	[Readonly]
	public Transform windowsBlack;

	[Readonly]
	public Transform windowsWhite;

	private ShuffleAudioClips shuffledThunderAudioClips;

	private List<SubdueAudioSource> subdueAudioSources = new List<SubdueAudioSource>();

	private Stater<State> stater;

	private float duration;

	private float startTime;

	private int numFlashesSoFar;

	private bool forScreenshot;

	private void Start()
	{
		startTime = Clock.play.time;
		shuffledThunderAudioClips = new ShuffleAudioClips(thunderAudioClips);
		subdueAudioSources.Add(new SubdueAudioSource(clockAudioSource, 0.4f));
		subdueAudioSources.Add(new SubdueAudioSource(rainAudioSource, 0.6f));
		subdueAudioSources.Add(new SubdueAudioSource(rainPitter1AudioSource, 0.75f));
		subdueAudioSources.Add(new SubdueAudioSource(rainPitter2AudioSource, 0.75f));
		stater = new Stater<State>("WindowLightning");
		stater.AddState(State.Idle).AddFunc(StaterFunc.ENTER(delegate
		{
			SetWindowsWhite(false);
			windowLight0.gameObject.SetActive(false);
			windowLight1.gameObject.SetActive(false);
			duration = ((!forScreenshot) ? Mathf.Lerp(8f, 20f, Random.value) : 1000f);
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (forScreenshot)
			{
				if (DebugMenu.GetKeyDown(KeyCode.Y))
				{
					stater.Go(State.Flashing);
				}
			}
			else if (stater.stateTime > duration)
			{
				stater.Go(State.Flashing);
			}
		}));
		stater.AddState(State.Flashing).AddFunc(StaterFunc.ENTER(delegate
		{
			duration = ((!forScreenshot) ? Mathf.Lerp(2f, 4f, Random.value) : 2f);
			windowLight0.gameObject.SetActive(true);
			windowLight1.gameObject.SetActive(true);
			float t = ((!forScreenshot) ? (0.33f * Random.value) : 0f);
			if ((numFlashesSoFar & 1) == 0)
			{
				windowLight0.transform.rotation = Quaternion.Lerp(spot0.rotation, spot1.rotation, t);
			}
			else
			{
				windowLight0.transform.rotation = Quaternion.Lerp(spot1.rotation, spot0.rotation, t);
			}
			windowLight0.transform.LookAt(windowLight0.transform.localToWorldMatrix.MultiplyPoint(10f * Vector3.forward), Vector3.up);
			windowLight1.transform.rotation = windowLight0.transform.rotation;
			numFlashesSoFar++;
		})).AddFunc(StaterFunc.AT_STEP(0.5f, delegate
		{
			thunderAudioSource.clip = shuffledThunderAudioClips.next;
			thunderAudioSource.Play();
		}))
			.AddFunc(StaterFunc.STEP(delegate
			{
				float num = stater.stateTime / duration;
				if (num < 1f)
				{
					float t = Mathf.Pow(Mathf.PerlinNoise(5f * Clock.play.time, 0f), 2f);
					float a = Util.LerpScale(num, 0f, 0.1f, 1f, 0f);
					int num2 = ((Mathf.Lerp(a, 1f, t) > 0.25f) ? 1 : 0);
					windowLight0.intensity = 8 * num2;
					windowLight1.intensity = 8 * num2;
					SetWindowsWhite((float)num2 > 0.01f);
				}
				else
				{
					stater.Go(State.Idle);
				}
			}));
		stater.Go(State.Idle);
	}

	private void Update()
	{
		stater.Step(Clock.play.deltaTime);
		foreach (SubdueAudioSource subdueAudioSource in subdueAudioSources)
		{
			subdueAudioSource.Update(soundEnviron, Clock.play.time - startTime);
		}
	}

	private void SetWindowsWhite(bool white)
	{
		windowsBlack.gameObject.SetActive(!white);
		windowsWhite.gameObject.SetActive(white);
	}

	private float GetFlicker()
	{
		float num = 0f;
		float t = 1f;
		float a = Mathf.Lerp(0f, 0.8f, t);
		float b = Mathf.Lerp(0.5f, 1f, t);
		float num2 = Clock.play.time + num;
		float t2 = Mathf.Lerp((Mathf.Cos(30f * num2) > 0f) ? 1 : 0, Mathf.PerlinNoise(5f * num2, 0f), t);
		return Mathf.Lerp(a, b, t2);
	}
}
