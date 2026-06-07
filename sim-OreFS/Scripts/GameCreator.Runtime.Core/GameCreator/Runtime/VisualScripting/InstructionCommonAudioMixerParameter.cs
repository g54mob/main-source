using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.Audio;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Audio Mixer Parameter")]
	[Description("Changes the value of an Audio Mixer exposed parameter")]
	[Category("Audio/Audio Mixer Parameter")]
	[Parameter("Audio Mixer", "The Audio Mixer asset with the exposed parameter")]
	[Parameter("Parameter Name", "A string representing the name of the exposed parameter")]
	[Parameter("Parameter Value", "The value which the exposed parameter is set")]
	[Keywords(new string[] { "Float", "Exposed", "Effect", "Change" })]
	[Image(typeof(IconAudioMixer), ColorTheme.Type.Yellow)]
	public class InstructionCommonAudioMixerParameter : Instruction
	{
		[SerializeField]
		private AudioMixer m_AudioMixer;

		[SerializeField]
		private PropertyGetString m_ParameterName = new PropertyGetString("Parameter_Name");

		[SerializeField]
		private PropertyGetDecimal m_ParameterValue = new PropertyGetDecimal(1f);

		public override string Title => string.Format("Audio Mixer {0} set '{1}' = {2}", (m_AudioMixer != null) ? m_AudioMixer.name : "(none)", m_ParameterName, m_ParameterValue);

		protected override Task Run(Args args)
		{
			if (m_AudioMixer != null)
			{
				m_AudioMixer.SetFloat(m_ParameterName.Get(args), (float)m_ParameterValue.Get(args));
			}
			return Instruction.DefaultResult;
		}
	}
}
