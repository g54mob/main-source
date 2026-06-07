using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.Audio;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Snapshot")]
	[Description("Smoothly transitions to a new snapshot over a period of time")]
	[Category("Audio/Change Snapshot")]
	[Parameter("Snapshot", "The Audio Mixer Snapshot that is activated")]
	[Parameter("Transition", "How long it takes to transition to the new Snapshot")]
	[Keywords(new string[] { "Effect", "Transition", "Effect", "Change" })]
	[Image(typeof(IconAudioMixer), ColorTheme.Type.Yellow)]
	public class InstructionCommonAudioSnapshot : Instruction
	{
		[SerializeField]
		private AudioMixerSnapshot m_Snapshot;

		[SerializeField]
		private PropertyGetDecimal m_Transition = new PropertyGetDecimal(0.5f);

		public override string Title => string.Format("Change to Snapshot {0} in {1} seconds", (m_Snapshot != null) ? m_Snapshot.name : "(none)", m_Transition);

		protected override Task Run(Args args)
		{
			if (m_Snapshot != null)
			{
				float timeToReach = (float)m_Transition.Get(args);
				m_Snapshot.TransitionTo(timeToReach);
			}
			return Instruction.DefaultResult;
		}
	}
}
