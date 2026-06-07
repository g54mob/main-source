using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OVRLipSyncContext : OVRLipSyncContextBase
{
	[Tooltip("Allow capturing of keyboard input to control operation.")]
	public bool enableKeyboardInput;

	[Tooltip("Register a mouse/touch callback to control loopback and gain (requires script restart).")]
	public bool enableTouchInput;

	[Tooltip("Play input audio back through audio output.")]
	public bool audioLoopback;

	[Tooltip("Key to toggle audio loopback.")]
	public KeyCode loopbackKey = KeyCode.L;

	[Tooltip("Show viseme scores in an OVRLipSyncDebugConsole display.")]
	public bool showVisemes;

	[Tooltip("Key to toggle viseme score display.")]
	public KeyCode debugVisemesKey = KeyCode.D;

	[Tooltip("Skip data from the Audio Source. Use if you intend to pass audio data in manually.")]
	public bool skipAudioSource;

	[Tooltip("Adjust the linear audio gain multiplier before processing lipsync")]
	public float gain = 1f;

	private bool hasDebugConsole;

	public KeyCode debugLaughterKey = KeyCode.H;

	public bool showLaughter;

	public float laughterScore;

	private void Start()
	{
		if (enableTouchInput)
		{
			OVRTouchpad.AddListener(LocalTouchEventCallback);
		}
		OVRLipSyncDebugConsole[] array = Object.FindObjectsOfType<OVRLipSyncDebugConsole>();
		if (array.Length != 0)
		{
			hasDebugConsole = array[0];
		}
	}

	private void HandleKeyboard()
	{
		if (Input.GetKeyDown(loopbackKey))
		{
			ToggleAudioLoopback();
		}
		else if (Input.GetKeyDown(debugVisemesKey))
		{
			showVisemes = !showVisemes;
			if (showVisemes)
			{
				if (hasDebugConsole)
				{
					Debug.Log("DEBUG SHOW VISEMES: ENABLED");
					return;
				}
				Debug.LogWarning("Warning: No OVRLipSyncDebugConsole in the scene!");
				showVisemes = false;
			}
			else
			{
				if (hasDebugConsole)
				{
					OVRLipSyncDebugConsole.Clear();
				}
				Debug.Log("DEBUG SHOW VISEMES: DISABLED");
			}
		}
		else if (Input.GetKeyDown(debugLaughterKey))
		{
			showLaughter = !showLaughter;
			if (showLaughter)
			{
				if (hasDebugConsole)
				{
					Debug.Log("DEBUG SHOW LAUGHTER: ENABLED");
					return;
				}
				Debug.LogWarning("Warning: No OVRLipSyncDebugConsole in the scene!");
				showLaughter = false;
			}
			else
			{
				if (hasDebugConsole)
				{
					OVRLipSyncDebugConsole.Clear();
				}
				Debug.Log("DEBUG SHOW LAUGHTER: DISABLED");
			}
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			gain -= 1f;
			if (gain < 1f)
			{
				gain = 1f;
			}
			string text = "LINEAR GAIN: ";
			text += gain;
			if (hasDebugConsole)
			{
				OVRLipSyncDebugConsole.Clear();
				OVRLipSyncDebugConsole.Log(text);
				OVRLipSyncDebugConsole.ClearTimeout(1.5f);
			}
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			gain += 1f;
			if (gain > 15f)
			{
				gain = 15f;
			}
			string text2 = "LINEAR GAIN: ";
			text2 += gain;
			if (hasDebugConsole)
			{
				OVRLipSyncDebugConsole.Clear();
				OVRLipSyncDebugConsole.Log(text2);
				OVRLipSyncDebugConsole.ClearTimeout(1.5f);
			}
		}
	}

	private void Update()
	{
		if (enableKeyboardInput)
		{
			HandleKeyboard();
		}
		laughterScore = base.Frame.laughterScore;
		DebugShowVisemesAndLaughter();
	}

	public void PreprocessAudioSamples(float[] data, int channels)
	{
		for (int i = 0; i < data.Length; i++)
		{
			data[i] *= gain;
		}
	}

	public void PostprocessAudioSamples(float[] data, int channels)
	{
		if (!audioLoopback)
		{
			for (int i = 0; i < data.Length; i++)
			{
				data[i] *= 0f;
			}
		}
	}

	public void ProcessAudioSamplesRaw(float[] data, int channels)
	{
		lock (this)
		{
			if (base.Context != 0 && OVRLipSync.IsInitialized() == OVRLipSync.Result.Success)
			{
				OVRLipSync.Frame frame = base.Frame;
				OVRLipSync.ProcessFrame(base.Context, data, frame, channels == 2);
			}
		}
	}

	public void ProcessAudioSamplesRaw(short[] data, int channels)
	{
		lock (this)
		{
			if (base.Context != 0 && OVRLipSync.IsInitialized() == OVRLipSync.Result.Success)
			{
				OVRLipSync.Frame frame = base.Frame;
				OVRLipSync.ProcessFrame(base.Context, data, frame, channels == 2);
			}
		}
	}

	public void ProcessAudioSamples(float[] data, int channels)
	{
		if (OVRLipSync.IsInitialized() == OVRLipSync.Result.Success && !(audioSource == null))
		{
			PreprocessAudioSamples(data, channels);
			ProcessAudioSamplesRaw(data, channels);
			PostprocessAudioSamples(data, channels);
		}
	}

	private void OnAudioFilterRead(float[] data, int channels)
	{
		if (!skipAudioSource)
		{
			ProcessAudioSamples(data, channels);
		}
	}

	private void DebugShowVisemesAndLaughter()
	{
		if (!hasDebugConsole)
		{
			return;
		}
		string text = "";
		if (showLaughter)
		{
			text += "Laughter:";
			int num = (int)(50f * base.Frame.laughterScore);
			for (int i = 0; i < num; i++)
			{
				text += "*";
			}
			text += "\n";
		}
		if (showVisemes)
		{
			for (int j = 0; j < base.Frame.Visemes.Length; j++)
			{
				string text2 = text;
				OVRLipSync.Viseme viseme = (OVRLipSync.Viseme)j;
				text = text2 + viseme;
				text += ":";
				int num2 = (int)(50f * base.Frame.Visemes[j]);
				for (int k = 0; k < num2; k++)
				{
					text += "*";
				}
				text += "\n";
			}
		}
		OVRLipSyncDebugConsole.Clear();
		if (text != "")
		{
			OVRLipSyncDebugConsole.Log(text);
		}
	}

	private void ToggleAudioLoopback()
	{
		audioLoopback = !audioLoopback;
		if (hasDebugConsole)
		{
			OVRLipSyncDebugConsole.Clear();
			OVRLipSyncDebugConsole.ClearTimeout(1.5f);
			if (audioLoopback)
			{
				OVRLipSyncDebugConsole.Log("LOOPBACK MODE: ENABLED");
			}
			else
			{
				OVRLipSyncDebugConsole.Log("LOOPBACK MODE: DISABLED");
			}
		}
	}

	private void LocalTouchEventCallback(OVRTouchpad.TouchEvent touchEvent)
	{
		string text = "LINEAR GAIN: ";
		switch (touchEvent)
		{
		case OVRTouchpad.TouchEvent.SingleTap:
			ToggleAudioLoopback();
			break;
		case OVRTouchpad.TouchEvent.Up:
			gain += 1f;
			if (gain > 15f)
			{
				gain = 15f;
			}
			text += gain;
			if (hasDebugConsole)
			{
				OVRLipSyncDebugConsole.Clear();
				OVRLipSyncDebugConsole.Log(text);
				OVRLipSyncDebugConsole.ClearTimeout(1.5f);
			}
			break;
		case OVRTouchpad.TouchEvent.Down:
			gain -= 1f;
			if (gain < 1f)
			{
				gain = 1f;
			}
			text += gain;
			if (hasDebugConsole)
			{
				OVRLipSyncDebugConsole.Clear();
				OVRLipSyncDebugConsole.Log(text);
				OVRLipSyncDebugConsole.ClearTimeout(1.5f);
			}
			break;
		}
	}
}
