using System;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OVRLipSyncMicInput : MonoBehaviour
{
	public enum micActivation
	{
		HoldToSpeak = 0,
		PushToSpeak = 1,
		ConstantSpeak = 2
	}

	[Tooltip("Manual specification of Audio Source - by default will use any attached to the same object.")]
	public AudioSource audioSource;

	[Tooltip("Enable a keypress to toggle the microphone device selection GUI.")]
	public bool enableMicSelectionGUI;

	[Tooltip("Key to toggle the microphone selection GUI if enabled.")]
	public KeyCode micSelectionGUIKey = KeyCode.M;

	[SerializeField]
	[Range(0f, 100f)]
	[Tooltip("Microphone input volume control.")]
	private float micInputVolume = 100f;

	[SerializeField]
	[Tooltip("Requested microphone input frequency")]
	private int micFrequency = 48000;

	[Tooltip("Microphone input control method. Hold To Speak and Push To Speak are driven with the Mic Activation Key.")]
	public micActivation micControl = micActivation.ConstantSpeak;

	[Tooltip("Key used to drive Hold To Speak and Push To Speak methods of microphone input control.")]
	public KeyCode micActivationKey = KeyCode.Space;

	[Tooltip("Will contain the string name of the selected microphone device - read only.")]
	public string selectedDevice;

	private bool micSelected;

	private int minFreq;

	private int maxFreq;

	private bool focused = true;

	private bool initialized;

	public float MicFrequency
	{
		get
		{
			return micFrequency;
		}
		set
		{
			micFrequency = (int)Mathf.Clamp(value, 0f, 96000f);
		}
	}

	private void Awake()
	{
		if (!audioSource)
		{
			audioSource = GetComponent<AudioSource>();
		}
		_ = (bool)audioSource;
	}

	private void Start()
	{
		audioSource.loop = true;
		audioSource.mute = false;
		InitializeMicrophone();
	}

	private void InitializeMicrophone()
	{
		if (!initialized && Microphone.devices.Length != 0)
		{
			selectedDevice = Microphone.devices[0].ToString();
			micSelected = true;
			GetMicCaps();
			initialized = true;
		}
	}

	private void Update()
	{
		if (!focused)
		{
			if (Microphone.IsRecording(selectedDevice))
			{
				StopMicrophone();
			}
			return;
		}
		if (!Application.isPlaying)
		{
			StopMicrophone();
			return;
		}
		if (!initialized)
		{
			InitializeMicrophone();
		}
		audioSource.volume = micInputVolume / 100f;
		if (micControl == micActivation.HoldToSpeak)
		{
			if (Input.GetKey(micActivationKey))
			{
				if (!Microphone.IsRecording(selectedDevice))
				{
					StartMicrophone();
				}
			}
			else if (Microphone.IsRecording(selectedDevice))
			{
				StopMicrophone();
			}
		}
		if (micControl == micActivation.PushToSpeak && Input.GetKeyDown(micActivationKey))
		{
			if (Microphone.IsRecording(selectedDevice))
			{
				StopMicrophone();
			}
			else if (!Microphone.IsRecording(selectedDevice))
			{
				StartMicrophone();
			}
		}
		if (micControl == micActivation.ConstantSpeak && !Microphone.IsRecording(selectedDevice))
		{
			StartMicrophone();
		}
		if (enableMicSelectionGUI && Input.GetKeyDown(micSelectionGUIKey))
		{
			micSelected = false;
		}
	}

	private void OnApplicationFocus(bool focus)
	{
		focused = focus;
		if (!focused)
		{
			StopMicrophone();
		}
	}

	private void OnApplicationPause(bool pauseStatus)
	{
		focused = !pauseStatus;
		if (!focused)
		{
			StopMicrophone();
		}
	}

	private void OnDisable()
	{
		StopMicrophone();
	}

	private void OnGUI()
	{
		MicDeviceGUI(Screen.width / 2 - 150, Screen.height / 2 - 75, 300f, 50f, 10f, -300f);
	}

	public void MicDeviceGUI(float left, float top, float width, float height, float buttonSpaceTop, float buttonSpaceLeft)
	{
		if (Microphone.devices.Length < 1 || !enableMicSelectionGUI || micSelected)
		{
			return;
		}
		for (int i = 0; i < Microphone.devices.Length; i++)
		{
			if (GUI.Button(new Rect(left + (width + buttonSpaceLeft) * (float)i, top + (height + buttonSpaceTop) * (float)i, width, height), Microphone.devices[i].ToString()))
			{
				StopMicrophone();
				selectedDevice = Microphone.devices[i].ToString();
				micSelected = true;
				GetMicCaps();
				StartMicrophone();
			}
		}
	}

	public void GetMicCaps()
	{
		if (micSelected)
		{
			Microphone.GetDeviceCaps(selectedDevice, out minFreq, out maxFreq);
			if (minFreq == 0 && maxFreq == 0)
			{
				UnityEngine.Debug.LogWarning("GetMicCaps warning:: min and max frequencies are 0");
				minFreq = 44100;
				maxFreq = 44100;
			}
			if (micFrequency > maxFreq)
			{
				micFrequency = maxFreq;
			}
		}
	}

	public void StartMicrophone()
	{
		if (micSelected)
		{
			audioSource.clip = Microphone.Start(selectedDevice, loop: true, 1, micFrequency);
			Stopwatch stopwatch = Stopwatch.StartNew();
			while (Microphone.GetPosition(selectedDevice) <= 0 && stopwatch.Elapsed.TotalMilliseconds < 1000.0)
			{
				Thread.Sleep(50);
			}
			if (Microphone.GetPosition(selectedDevice) <= 0)
			{
				throw new Exception("Timeout initializing microphone " + selectedDevice);
			}
			audioSource.Play();
		}
	}

	public void StopMicrophone()
	{
		if (micSelected)
		{
			if (audioSource != null && audioSource.clip != null && audioSource.clip.name == "Microphone")
			{
				audioSource.Stop();
			}
			GetComponent<OVRLipSyncContext>().ResetContext();
			Microphone.End(selectedDevice);
		}
	}

	private float GetAveragedVolume()
	{
		return 0f;
	}
}
