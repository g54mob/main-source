using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class InputRecording : MonoBehaviour
{
	[SerializeField]
	private EventSystem eventSystem;

	[SerializeField]
	private InputRecordingAsset data;

	[SerializeField]
	private RectTransform playbackCursor;

	[SerializeField]
	private Canvas playbackCanvas;

	private bool _recording;

	private bool _playback;

	private int _playbackIndex;

	private double _playbackTime;

	private double _recordStartTime;

	private Vector2 _lastPosition;

	private void Awake()
	{
		eventSystem = Object.FindFirstObjectByType<EventSystem>();
	}

	private void Update()
	{
		if (Keyboard.current.numpad1Key.wasPressedThisFrame)
		{
			ToggleRecording();
		}
		if (Keyboard.current.numpad2Key.wasPressedThisFrame)
		{
			TogglePlayback();
		}
		if (_recording)
		{
			Record();
		}
		if (_playback)
		{
			Playback();
		}
	}

	private void ToggleRecording()
	{
		if (_playback)
		{
			Debug.LogWarning("Can't start recording if playing back.");
		}
		else if (_recording)
		{
			StopRecording();
		}
		else
		{
			StartRecording();
		}
	}

	private void TogglePlayback()
	{
		if (_recording)
		{
			Debug.LogWarning("Can't start playback if recording.");
		}
		else if (_playback)
		{
			StopPlayback();
		}
		else
		{
			StartPlayback();
		}
	}

	private void StartPlayback()
	{
		Debug.Log("Starting playback " + data.name);
		_playback = true;
		_playbackIndex = 0;
		_playbackTime = 0.0;
		Cursor.visible = false;
		playbackCursor.gameObject.SetActive(value: true);
		BiteRandom.Shared.InitState(data.seed0, data.seed1, data.seed2, data.seed3);
	}

	private void Playback()
	{
		if (_playbackIndex >= data.samples.Count)
		{
			StopPlayback();
			return;
		}
		_playbackTime += Time.unscaledDeltaTime;
		while (_playbackIndex < data.samples.Count && data.samples[_playbackIndex].time <= _playbackTime)
		{
			InputRecordingAsset.Sample sample = data.samples[_playbackIndex++];
			InputSystem.QueueStateEvent(Mouse.current, new MouseState
			{
				position = sample.position,
				delta = sample.delta
			});
			if (sample.leftPressed)
			{
				InputSystem.QueueDeltaStateEvent((InputControl)Mouse.current.leftButton, (byte)1, -1.0);
			}
			if (sample.leftReleased)
			{
				InputSystem.QueueDeltaStateEvent((InputControl)Mouse.current.leftButton, (byte)0, -1.0);
			}
			UpdateCursorPosition(sample.position);
		}
		InputSystem.Update();
	}

	private void StopPlayback()
	{
		Debug.Log($"Stopping playback after {_playbackIndex}/{data.samples.Count} samples");
		_playback = false;
		Cursor.visible = true;
		playbackCursor.gameObject.SetActive(value: false);
	}

	private void UpdateCursorPosition(Vector2 position)
	{
		RectTransformUtility.ScreenPointToLocalPointInRectangle(playbackCanvas.transform as RectTransform, position, null, out var localPoint);
		playbackCursor.anchoredPosition = localPoint;
	}

	private void StartRecording()
	{
		Debug.Log("Starting recording");
		_recording = true;
		_recordStartTime = Time.unscaledTimeAsDouble;
		data.Clear();
		data.Track(0.0, Mouse.current);
		BiteRandom.Shared.InitState();
		data.seed0 = BiteRandom.Shared.State.S0;
		data.seed1 = BiteRandom.Shared.State.S1;
		data.seed2 = BiteRandom.Shared.State.S2;
		data.seed3 = BiteRandom.Shared.State.S3;
	}

	private void Record()
	{
		data.Track(Time.unscaledTimeAsDouble - _recordStartTime, Mouse.current);
	}

	private void StopRecording()
	{
		Debug.Log($"Recorded {data.samples.Count} samples");
		_recording = false;
	}
}
