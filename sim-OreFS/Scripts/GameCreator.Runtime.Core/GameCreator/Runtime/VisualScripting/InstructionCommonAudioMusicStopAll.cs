using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Fade all Music")]
	[Description("Stops all Music currently playing")]
	[Category("Audio/Fade all Music")]
	[Parameter("Wait To Complete", "Check if you want to wait until the sound has faded out")]
	[Parameter("Transition Out", "Time it takes for the sound to fade out")]
	[Keywords(new string[] { "Audio", "Music", "Background", "Fade", "Mute" })]
	[Image(typeof(IconHeadset), ColorTheme.Type.TextLight, typeof(OverlayArrowRight))]
	public class InstructionCommonAudioMusicStopAll : Instruction
	{
		[SerializeField]
		private bool m_WaitToComplete;

		[SerializeField]
		private float transitionOut = 2f;

		public override string Title => string.Format("Stop all Music {0}", (transitionOut < float.Epsilon) ? string.Empty : string.Format("in {0} second{1}", transitionOut, Mathf.Approximately(transitionOut, 1f) ? string.Empty : "s"));

		protected override async Task Run(Args args)
		{
			if (m_WaitToComplete)
			{
				await Singleton<AudioManager>.Instance.Music.StopAll(transitionOut);
			}
			else
			{
				Singleton<AudioManager>.Instance.Music.StopAll(transitionOut);
			}
		}
	}
}
