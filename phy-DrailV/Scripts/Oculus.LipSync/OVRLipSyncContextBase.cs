using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OVRLipSyncContextBase : MonoBehaviour
{
	public AudioSource audioSource;

	[Tooltip("Which lip sync provider to use for viseme computation.")]
	public OVRLipSync.ContextProviders provider = OVRLipSync.ContextProviders.Enhanced;

	[Tooltip("Enable DSP offload on supported Android devices.")]
	public bool enableAcceleration = true;

	private OVRLipSync.Frame frame = new OVRLipSync.Frame();

	private uint context;

	private int _smoothing;

	public int Smoothing
	{
		get
		{
			return _smoothing;
		}
		set
		{
			switch (OVRLipSync.SendSignal(context, OVRLipSync.Signals.VisemeSmoothing, value, 0))
			{
			case OVRLipSync.Result.InvalidParam:
				Debug.LogError("OVRLipSyncContextBase.SetSmoothing: A viseme smoothing parameter is invalid, it should be between 1 and 100!");
				break;
			default:
				Debug.LogError("OVRLipSyncContextBase.SetSmoothing: An unexpected error occured.");
				break;
			case OVRLipSync.Result.Success:
				break;
			}
			_smoothing = value;
		}
	}

	public uint Context => context;

	protected OVRLipSync.Frame Frame => frame;

	private void Awake()
	{
		if (!audioSource)
		{
			audioSource = GetComponent<AudioSource>();
		}
		lock (this)
		{
			if (context == 0 && OVRLipSync.CreateContext(ref context, provider, 0, enableAcceleration) != OVRLipSync.Result.Success)
			{
				Debug.LogError("OVRLipSyncContextBase.Start ERROR: Could not create Phoneme context.");
			}
		}
	}

	private void OnDestroy()
	{
		lock (this)
		{
			if (context != 0 && OVRLipSync.DestroyContext(context) != OVRLipSync.Result.Success)
			{
				Debug.LogError("OVRLipSyncContextBase.OnDestroy ERROR: Could not delete Phoneme context.");
			}
		}
	}

	public OVRLipSync.Frame GetCurrentPhonemeFrame()
	{
		return frame;
	}

	public void SetVisemeBlend(int viseme, int amount)
	{
		switch (OVRLipSync.SendSignal(context, OVRLipSync.Signals.VisemeAmount, viseme, amount))
		{
		case OVRLipSync.Result.InvalidParam:
			Debug.LogError("OVRLipSyncContextBase.SetVisemeBlend: Viseme ID is invalid.");
			break;
		default:
			Debug.LogError("OVRLipSyncContextBase.SetVisemeBlend: An unexpected error occured.");
			break;
		case OVRLipSync.Result.Success:
			break;
		}
	}

	public void SetLaughterBlend(int amount)
	{
		if (OVRLipSync.SendSignal(context, OVRLipSync.Signals.LaughterAmount, amount, 0) != OVRLipSync.Result.Success)
		{
			Debug.LogError("OVRLipSyncContextBase.SetLaughterBlend: An unexpected error occured.");
		}
	}

	public OVRLipSync.Result ResetContext()
	{
		frame.Reset();
		return OVRLipSync.ResetContext(context);
	}
}
