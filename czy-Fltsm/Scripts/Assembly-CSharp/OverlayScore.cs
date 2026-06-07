using System;
using PajamaLlama.UI.Formatting;
using TMPro;
using UnityEngine;
using UnityEngine.PajamaLlama;

public class OverlayScore : OverlayBehaviour
{
	[Serializable]
	public struct OverlayScoreFormatter
	{
		public Overlays.Type Overlay;

		public IntFormatter Formatter;
	}

	[SerializeField]
	private TextMeshProUGUI _scoreField;

	[SerializeField]
	private Buildable _buildable;

	[SerializeField]
	[NamedArrayElement(new string[] { "Overlay" })]
	private OverlayScoreFormatter[] _formatters;

	private int _score = int.MinValue;

	private void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.OverlayUpdate, OnOverlayUpdate);
		OnOverlayUpdate();
	}

	private void Update()
	{
		switch (Overlays.OverlayType)
		{
		case Overlays.Type.Beauty:
			SetScore(_buildable.ReturnBeautyScore());
			break;
		case Overlays.Type.Weight:
			SetScore(Mathf.RoundToInt(_buildable.ReturnWeight()));
			break;
		}
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.OverlayUpdate, OnOverlayUpdate);
	}

	private void OnOverlayUpdate(GameEvent gameEvent = null)
	{
		_score = int.MinValue;
	}

	private void SetScore(int score)
	{
		if (score == _score)
		{
			return;
		}
		_score = score;
		OverlayScoreFormatter[] formatters = _formatters;
		for (int i = 0; i < formatters.Length; i++)
		{
			OverlayScoreFormatter overlayScoreFormatter = formatters[i];
			if (overlayScoreFormatter.Overlay == Overlays.OverlayType)
			{
				IntFormatter formatter = overlayScoreFormatter.Formatter;
				formatter.Format(_scoreField, _score);
			}
		}
	}
}
