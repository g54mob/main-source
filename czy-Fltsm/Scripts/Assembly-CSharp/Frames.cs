using System;
using UnityEngine;

public class Frames : MonoBehaviour
{
	[Serializable]
	private struct OverlayFrame
	{
		public Overlays.Type Overlay;

		public RectTransform Frame;
	}

	[SerializeField]
	private GameObject _pauseFrame;

	[SerializeField]
	private OverlayFrame[] _overlayFrames;

	[SerializeField]
	[Tooltip("The offset used for overlay frames when the pause frame is enabled")]
	private int _pausedOverlayOffset = 12;

	private RectTransform _activeOverlayFrame;

	private void Awake()
	{
		GameEventDispatcher.AddListener(GameEventType.GameSpeedChange, OnGameSpeedChange);
		GameEventDispatcher.AddListener(GameEventType.OverlayUpdate, OnOverlayUpdate);
		_pauseFrame.SetActive(value: false);
		OverlayFrame[] overlayFrames = _overlayFrames;
		for (int i = 0; i < overlayFrames.Length; i++)
		{
			overlayFrames[i].Frame?.gameObject.SetActive(value: false);
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.GameSpeedChange, OnGameSpeedChange);
		GameEventDispatcher.RemoveListener(GameEventType.OverlayUpdate, OnOverlayUpdate);
	}

	private void OnGameSpeedChange(GameEvent gameEvent)
	{
		if (gameEvent is GameSpeedChangedEvent gameSpeedChangedEvent)
		{
			SetPauseFrameActive(gameSpeedChangedEvent.GameSpeed == GameSpeed.Zero);
		}
	}

	private void OnOverlayUpdate(GameEvent gameEvent)
	{
		if (gameEvent is OverlayEvent overlayEvent)
		{
			SetOverlay(overlayEvent.OverlayType);
		}
	}

	private void SetPauseFrameActive(bool value)
	{
		_pauseFrame.SetActive(value);
		SetOverlayFrameOffsets(_activeOverlayFrame);
	}

	private void SetOverlay(Overlays.Type overlay)
	{
		if ((bool)_activeOverlayFrame)
		{
			_activeOverlayFrame.gameObject.SetActive(value: false);
			_activeOverlayFrame = null;
		}
		OverlayFrame[] overlayFrames = _overlayFrames;
		for (int i = 0; i < overlayFrames.Length; i++)
		{
			OverlayFrame overlayFrame = overlayFrames[i];
			if (overlayFrame.Overlay == overlay)
			{
				_activeOverlayFrame = overlayFrame.Frame;
				_activeOverlayFrame.gameObject?.SetActive(value: true);
				SetOverlayFrameOffsets(_activeOverlayFrame);
				break;
			}
		}
	}

	private void SetOverlayFrameOffsets(RectTransform overlayFrame)
	{
		if (!(overlayFrame == null))
		{
			if (_pauseFrame.activeInHierarchy)
			{
				overlayFrame.offsetMin = new Vector2(_pausedOverlayOffset, _pausedOverlayOffset);
				overlayFrame.offsetMax = new Vector2(-_pausedOverlayOffset, -_pausedOverlayOffset);
			}
			else
			{
				overlayFrame.offsetMin = new Vector2(0f, 0f);
				overlayFrame.offsetMax = new Vector2(0f, 0f);
			}
		}
	}
}
