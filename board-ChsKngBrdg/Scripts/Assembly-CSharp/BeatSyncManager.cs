using UnityEngine;

public class BeatSyncManager : MonoBehaviour
{
	public enum NoteType
	{
		WholeNote = 0,
		HalfNote = 1,
		QuarterNote = 2,
		EighthNote = 3
	}

	public enum SyncType
	{
		NextOnBeat = 0,
		NextDownBeat = 1,
		NextUpBeat = 2
	}

	public AudioSource audioSource;

	public float beatsPerMinute;

	public int timeSignatureQuotient;

	public static AudioSource globalAudioSource;

	public static float globalBeatsPerMinute;

	public static int globalTimeSignatureQuotient;

	public void Awake()
	{
		ResetSources();
	}

	public void ResetSources()
	{
		globalAudioSource = audioSource;
		globalBeatsPerMinute = beatsPerMinute;
		globalTimeSignatureQuotient = timeSignatureQuotient;
	}

	public static float NoteSeconds(NoteType noteType = NoteType.WholeNote)
	{
		float num = (float)globalTimeSignatureQuotient * (60f / globalBeatsPerMinute);
		float result = 0f;
		switch (noteType)
		{
		case NoteType.WholeNote:
			result = num;
			break;
		case NoteType.HalfNote:
			result = num / 2f;
			break;
		case NoteType.QuarterNote:
			result = num / 4f;
			break;
		case NoteType.EighthNote:
			result = num / 8f;
			break;
		}
		return result;
	}

	public static float SecondsUntilBeatSync(SyncType syncType = SyncType.NextOnBeat, int beatCount = 1)
	{
		if (globalAudioSource == null)
		{
			return 0f;
		}
		int num = (int)Mathf.Floor((float)(int)Mathf.Floor(globalBeatsPerMinute * globalAudioSource.clip.length / 60f) * globalAudioSource.time / globalAudioSource.clip.length);
		int num2 = (int)Mathf.Floor(num) / globalTimeSignatureQuotient;
		float num3 = 60f / globalBeatsPerMinute;
		float num4 = (float)(num + 1) * num3;
		float num5 = (float)(num2 * globalTimeSignatureQuotient + 4) * num3;
		float num6 = (float)((num2 + 1) * globalTimeSignatureQuotient - 1) * num3;
		float result = 0f;
		switch (syncType)
		{
		case SyncType.NextOnBeat:
			result = num4 - globalAudioSource.time;
			result += (float)(beatCount - 1) * num3;
			break;
		case SyncType.NextDownBeat:
			result = num5 - globalAudioSource.time;
			result += (float)((beatCount - 1) * globalTimeSignatureQuotient) * num3;
			break;
		case SyncType.NextUpBeat:
			result = num6 - globalAudioSource.time;
			if (result < 0f)
			{
				result = (float)((num2 + 2) * globalTimeSignatureQuotient - 1) * num3 - globalAudioSource.time;
			}
			result += (float)((beatCount - 1) * globalTimeSignatureQuotient) * num3;
			break;
		}
		return result;
	}
}
