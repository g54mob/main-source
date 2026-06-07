using System;
using UnityEngine;

namespace GameCreator.Runtime.Common.Audio
{
	[Serializable]
	public class Volume
	{
		private const float DEFAULT_VALUE = 1f;

		private const float SMOOTH = 0.25f;

		[SerializeField]
		private float m_Master = 1f;

		[SerializeField]
		private float m_SFX = 1f;

		[SerializeField]
		private float m_Ambient = 1f;

		[SerializeField]
		private float m_Music = 1f;

		[SerializeField]
		private float m_Speech = 1f;

		[SerializeField]
		private float m_UI = 1f;

		private AnimFloat ValueMaster { get; set; } = new AnimFloat(1f, 0.25f);

		private AnimFloat ValueSFX { get; set; } = new AnimFloat(1f, 0.25f);

		private AnimFloat ValueAmbient { get; set; } = new AnimFloat(1f, 0.25f);

		private AnimFloat ValueMusic { get; set; } = new AnimFloat(1f, 0.25f);

		private AnimFloat ValueSpeech { get; set; } = new AnimFloat(1f, 0.25f);

		private AnimFloat ValueUI { get; set; } = new AnimFloat(1f, 0.25f);

		public float Master
		{
			get
			{
				return Mathf.Clamp01(ValueMaster.Current);
			}
			set
			{
				value = Mathf.Clamp01(value);
				if (!(Math.Abs(value - m_Master) < float.Epsilon))
				{
					m_Master = value;
					this.EventMaster?.Invoke();
				}
			}
		}

		public float SoundEffects
		{
			get
			{
				return Mathf.Clamp01(ValueSFX.Current);
			}
			set
			{
				value = Mathf.Clamp01(value);
				if (!(Math.Abs(value - m_SFX) < float.Epsilon))
				{
					m_SFX = value;
					this.EventSoundEffects?.Invoke();
				}
			}
		}

		public float Ambient
		{
			get
			{
				return Mathf.Clamp01(ValueAmbient.Current);
			}
			set
			{
				value = Mathf.Clamp01(value);
				if (!(Math.Abs(value - m_Ambient) < float.Epsilon))
				{
					m_Ambient = value;
					this.EventAmbient?.Invoke();
				}
			}
		}

		public float Music
		{
			get
			{
				return Mathf.Clamp01(ValueMusic.Current);
			}
			set
			{
				value = Mathf.Clamp01(value);
				if (!(Math.Abs(value - m_Music) < float.Epsilon))
				{
					m_Music = value;
					this.EventMusic?.Invoke();
				}
			}
		}

		public float Speech
		{
			get
			{
				return Mathf.Clamp01(ValueSpeech.Current);
			}
			set
			{
				value = Mathf.Clamp01(value);
				if (!(Math.Abs(value - m_Speech) < float.Epsilon))
				{
					m_Speech = value;
					this.EventSpeech?.Invoke();
				}
			}
		}

		public float UI
		{
			get
			{
				return Mathf.Clamp01(ValueUI.Current);
			}
			set
			{
				value = Mathf.Clamp01(value);
				if (!(Math.Abs(value - m_UI) < float.Epsilon))
				{
					m_UI = value;
					this.EventUI?.Invoke();
				}
			}
		}

		public float CurrentMaster => Mathf.Clamp01(ValueMaster.Current);

		public float CurrentSoundEffects => Mathf.Clamp01(ValueSFX.Current);

		public float CurrentAmbient => Mathf.Clamp01(ValueAmbient.Current);

		public float CurrentMusic => Mathf.Clamp01(ValueMusic.Current);

		public float CurrentSpeech => Mathf.Clamp01(ValueSpeech.Current);

		public float CurrentUI => Mathf.Clamp01(ValueUI.Current);

		public event Action EventMaster;

		public event Action EventSoundEffects;

		public event Action EventAmbient;

		public event Action EventMusic;

		public event Action EventSpeech;

		public event Action EventUI;

		internal void Update()
		{
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			ValueMaster.UpdateWithDelta(m_Master, unscaledDeltaTime);
			ValueSFX.UpdateWithDelta(m_SFX, unscaledDeltaTime);
			ValueAmbient.UpdateWithDelta(m_Ambient, unscaledDeltaTime);
			ValueMusic.UpdateWithDelta(m_Music, unscaledDeltaTime);
			ValueSpeech.UpdateWithDelta(m_Speech, unscaledDeltaTime);
			ValueUI.UpdateWithDelta(m_UI, unscaledDeltaTime);
		}
	}
}
