using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Stop Music")]
	[Description("Stops a currently playing Music audio")]
	[Category("Audio/Stop Music")]
	[Parameter("Audio Clip", "The Audio Clip to be played")]
	[Parameter("Wait To Complete", "Check if you want to wait until the sound has faded out")]
	[Parameter("Transition Out", "Time it takes for the sound to fade out")]
	[Keywords(new string[] { "Audio", "Music", "Background", "Fade", "Mute" })]
	[Image(typeof(IconHeadset), ColorTheme.Type.TextLight, typeof(OverlayCross))]
	public class InstructionCommonAudioMusicStop : Instruction
	{
		[SerializeField]
		private PropertyGetAudio m_AudioClip = GetAudioClip.Create;

		[SerializeField]
		private bool m_WaitToComplete;

		[SerializeField]
		private float transitionOut = 2f;

		public override string Title => string.Format("Stop Music: {0} {1}", m_AudioClip, (transitionOut < float.Epsilon) ? string.Empty : string.Format("in {0} second{1}", transitionOut, Mathf.Approximately(transitionOut, 1f) ? string.Empty : "s"));

		protected override async Task Run(Args args)
		{
			AudioClip audioClip = m_AudioClip.Get(args);
			if (!(audioClip == null))
			{
				if (m_WaitToComplete)
				{
					await Singleton<AudioManager>.Instance.Music.Stop(audioClip, transitionOut);
				}
				else
				{
					Singleton<AudioManager>.Instance.Music.Stop(audioClip, transitionOut);
				}
			}
		}
	}
}
