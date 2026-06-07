using CTS.BBT.AI;
using CTS.Emotes;
using UnityEngine;

namespace CTS
{
	public class AlertVisual : MonoBehaviour
	{
		[SerializeField]
		private Sprite _backgroundSprite;

		[SerializeField]
		private Color _backgroundColor;

		[SerializeField]
		private Color _imageColor;

		private Agent _agent;

		private EmoteBBT _emote;

		private bool _playing;

		private void Awake()
		{
			_agent = GetComponentInParent<Agent>();
		}

		private void OnEnable()
		{
			CustomerActionAlert.AlertStatusChanged += OnAlertStarted;
		}

		private void OnDisable()
		{
			CustomerActionAlert.AlertStatusChanged -= OnAlertStarted;
		}

		private void OnAlertStarted(Agent p_agent, bool p_alerted)
		{
			if (p_agent != _agent)
			{
				return;
			}
			if (p_alerted)
			{
				if (!_playing)
				{
					_playing = true;
					if (_emote != null && _emote.IsPlaying)
					{
						_emote = null;
					}
					_emote = EmoteManagerBBT.Play(_agent, E_EmoteIcons.Point, _emote).SetStayDuration(-1f);
					_emote.SetBackgroundColor(_backgroundColor);
					_emote.SetBackgroundSprite(_backgroundSprite);
					_emote.SetContentColor(_imageColor);
				}
			}
			else
			{
				_emote?.Kill();
				_playing = false;
			}
		}
	}
}
