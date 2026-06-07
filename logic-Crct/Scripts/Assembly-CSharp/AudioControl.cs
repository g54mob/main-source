using PortAudioForUnity;
using Simulation;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
	public enum System
	{
		Unity = 0,
		PortAudio = 1
	}

	public System AudioSystem;

	private System _audioSystem;

	private static AudioControl _inst;

	private static int sampleRate;

	public int m_SafeBufferDistance;

	public AudioSource AudioSource;

	private static IAudioComponent[] components;

	private long mainLoopHeartbeat;

	private bool canPlayAudio;

	private bool refreshReadPos;

	public static int SampleRate => 0;

	private HostApiInfo HostApiInfo => null;

	private DeviceInfo OutputDeviceInfo => null;

	public static int SafeBufferDistance => 0;

	private void Awake()
	{
	}

	public static void RegisterAudioComponents(ICircuitModel[] e)
	{
	}

	private void Refresh()
	{
	}

	public void Update()
	{
	}

	public static float Sinc(float x)
	{
		return 0f;
	}

	public static float SincInterpolate(float[] buffer, float index)
	{
		return 0f;
	}

	private void OnPortAudioRead(float[] data)
	{
	}

	public void OnAudioFilterRead(float[] data, int channel)
	{
	}
}
