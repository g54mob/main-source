using UnityEngine;

public class ONSPAmbisonicsNative : MonoBehaviour
{
	public enum ovrAmbisonicsNativeStatus
	{
		Uninitialized = -1,
		NotEnabled = 0,
		Success = 1,
		StreamError = 2,
		ProcessError = 3,
		MaxStatValue = 4
	}

	private AudioSource source;

	private static int numFOAChannels = 4;

	private static int paramAmbiStat = 6;

	private ovrAmbisonicsNativeStatus currentStatus = ovrAmbisonicsNativeStatus.Uninitialized;

	private void OnEnable()
	{
		source = GetComponent<AudioSource>();
		currentStatus = ovrAmbisonicsNativeStatus.Uninitialized;
		if (source == null)
		{
			Debug.Log("Ambisonic ERROR: AudioSource does not exist.");
			return;
		}
		if (source.spatialize)
		{
			Debug.Log("Ambisonic WARNING: Turning spatialize field off for Ambisonic sources.");
			source.spatialize = false;
		}
		if (source.clip == null)
		{
			Debug.Log("Ambisonic ERROR: AudioSource does not contain an audio clip.");
		}
		else if (source.clip.channels != numFOAChannels)
		{
			Debug.Log("Ambisonic ERROR: AudioSource clip does not have correct number of channels.");
		}
	}

	private void Update()
	{
		if (source == null)
		{
			return;
		}
		float value = 0f;
		source.GetAmbisonicDecoderFloat(paramAmbiStat, out value);
		ovrAmbisonicsNativeStatus ovrAmbisonicsNativeStatus2 = (ovrAmbisonicsNativeStatus)value;
		if (ovrAmbisonicsNativeStatus2 != currentStatus)
		{
			switch (ovrAmbisonicsNativeStatus2)
			{
			case ovrAmbisonicsNativeStatus.NotEnabled:
				Debug.Log("Ambisonic Native: Ambisonic not enabled on clip. Check clip field and turn it on");
				break;
			case ovrAmbisonicsNativeStatus.Uninitialized:
				Debug.Log("Ambisonic Native: Stream uninitialized");
				break;
			case ovrAmbisonicsNativeStatus.Success:
				Debug.Log("Ambisonic Native: Stream successfully initialized and playing/playable");
				break;
			case ovrAmbisonicsNativeStatus.StreamError:
				Debug.Log("Ambisonic Native WARNING: Stream error (bad input format?)");
				break;
			case ovrAmbisonicsNativeStatus.ProcessError:
				Debug.Log("Ambisonic Native WARNING: Stream process error (check default speaker setup)");
				break;
			}
		}
		currentStatus = ovrAmbisonicsNativeStatus2;
	}
}
