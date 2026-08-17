using Cpp2ILInjected;
using UnityEngine;

public class RandomSfx : MonoBehaviour
{
	public AudioClip[] sounds;

	public float maxPitch = 0.94f;

	public float minPitch = 1.06f;

	public float randomVolume = 0.1f;

	public AudioSource s;

	public bool playOnAwake = true;

	private float defaultVolume = -1f;

	private void Awake()
	{
		Init();
		if (playOnAwake)
		{
			Play();
		}
	}

	private void Init()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018035E65Bh\"");
		if (defaultVolume == -1f)
		{
			if (s == null)
			{
				AudioSource component = GetComponent<AudioSource>();
				s = component;
			}
			if (s != null)
			{
				float volume = s.volume;
				defaultVolume = volume;
			}
		}
	}

	public void Play(float delay = 0f, float volumeMultiplier = 1f)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected F4, but got Unknown
		Init();
		if (sounds == null)
		{
			return;
		}
		AudioClip[] array = sounds;
		if (array.Length != 0)
		{
			float num = randomVolume;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
			float minInclusive = num ^ 0;
			float num2 = Random.Range(minInclusive, randomVolume);
			float num3 = num2 + 1f;
			float num4 = defaultVolume * volumeMultiplier;
			float volume = num4 * num3;
			s.volume = volume;
			AudioClip[] array2 = sounds;
			int num5 = Random.Range(0, array2.Length);
			s.clip = array2[num5];
			float pitch = Random.Range(minPitch, maxPitch);
			s.pitch = pitch;
			if (s.enabled)
			{
				s.PlayDelayed(delay);
			}
		}
	}

	public void Stop()
	{
		s.Stop();
	}

	private void OnValidate()
	{
		if (s == null)
		{
			AudioSource component = GetComponent<AudioSource>();
			s = component;
		}
	}
}
