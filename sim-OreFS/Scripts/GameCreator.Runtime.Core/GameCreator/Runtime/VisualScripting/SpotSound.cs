using System;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Common.Audio;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Play Sound")]
	[Keywords(new string[] { "Audio", "Sounds" })]
	[Image(typeof(IconMusicNote), ColorTheme.Type.Yellow)]
	[Category("Audio/Play Sound")]
	[Description("Plays a User Interface sound effect when the Hotspot is activated or deactivated")]
	public class SpotSound : Spot
	{
		[SerializeField]
		protected PropertyGetAudio m_OnActivate = new PropertyGetAudio();

		[SerializeField]
		protected PropertyGetAudio m_OnDeactivate = new PropertyGetAudio();

		[SerializeField]
		private AudioConfigSoundUI m_AudioSettings = new AudioConfigSoundUI();

		[NonSerialized]
		private bool m_WasActive;

		public override string Title => $"Play {m_OnActivate} / {m_OnDeactivate}";

		public override void OnEnable(Hotspot hotspot)
		{
			base.OnEnable(hotspot);
			m_WasActive = false;
		}

		public override void OnDisable(Hotspot hotspot)
		{
			base.OnDisable(hotspot);
			if (!ApplicationManager.IsExiting && m_WasActive)
			{
				Args args = new Args(hotspot.gameObject, hotspot.Target);
				AudioClip audioClip = m_OnDeactivate.Get(args);
				if (audioClip != null)
				{
					Singleton<AudioManager>.Instance.UserInterface.Play(audioClip, m_AudioSettings, args);
				}
			}
		}

		public override void OnUpdate(Hotspot hotspot)
		{
			base.OnUpdate(hotspot);
			if (!m_WasActive)
			{
				if (hotspot.IsActive)
				{
					Args args = new Args(hotspot.gameObject, hotspot.Target);
					AudioClip audioClip = m_OnActivate.Get(args);
					if (audioClip != null)
					{
						Singleton<AudioManager>.Instance.UserInterface.Play(audioClip, m_AudioSettings, args);
					}
				}
			}
			else if (!hotspot.IsActive)
			{
				Args args2 = new Args(hotspot.gameObject, hotspot.Target);
				AudioClip audioClip2 = m_OnDeactivate.Get(args2);
				if (audioClip2 != null)
				{
					Singleton<AudioManager>.Instance.UserInterface.Play(audioClip2, m_AudioSettings, args2);
				}
			}
			m_WasActive = hotspot.IsActive;
		}
	}
}
