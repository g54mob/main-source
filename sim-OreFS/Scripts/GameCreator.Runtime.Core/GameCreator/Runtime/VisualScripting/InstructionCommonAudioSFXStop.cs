using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Stop Sound Effect")]
	[Description("Stops a currently playing Sound Effect")]
	[Category("Audio/Stop Sound Effect")]
	[Keywords(new string[] { "Audio", "Sounds", "Silence", "Fade", "Mute", "SFX", "FX" })]
	[Image(typeof(IconMusicNote), ColorTheme.Type.TextLight, typeof(OverlayCross))]
	public class InstructionCommonAudioSFXStop : Instruction
	{
		[SerializeField]
		private PropertyGetAudio m_AudioClip = GetAudioClip.Create;

		[SerializeField]
		private bool m_WaitToComplete;

		[SerializeField]
		private float transitionOut = 0.1f;

		public override string Title => string.Format("Stop SFX: {0} {1}", m_AudioClip, (transitionOut < float.Epsilon) ? string.Empty : string.Format("in {0} second{1}", transitionOut, Mathf.Approximately(transitionOut, 1f) ? string.Empty : "s"));

		protected override async Task Run(Args args)
		{
			AudioClip audioClip = m_AudioClip.Get(args);
			if (!(audioClip == null))
			{
				if (m_WaitToComplete)
				{
					await Singleton<AudioManager>.Instance.SoundEffect.Stop(audioClip, transitionOut);
				}
				else
				{
					Singleton<AudioManager>.Instance.SoundEffect.Stop(audioClip, transitionOut);
				}
			}
		}
	}
}
