using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Audio Source Pitch")]
	[Description("Changes the pitch of an Audio Source component")]
	[Category("Audio/Audio Source Pitch")]
	[Parameter("Audio Source", "The Audio Source component")]
	[Parameter("Pitch", "The new targeted pitch to change")]
	[Parameter("Transition", "How long it takes to reach the new value")]
	[Keywords(new string[] { "Clip", "Music" })]
	[Image(typeof(IconAudioSource), ColorTheme.Type.Yellow)]
	public class InstructionCommonAudioSourcePitch : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_AudioSource = GetGameObjectInstance.Create();

		[SerializeField]
		private PropertyGetDecimal m_Pitch = GetDecimalDecimal.Create(1f);

		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => $"Pitch of {m_AudioSource} = {m_Pitch}";

		protected override async Task Run(Args args)
		{
			AudioSource audioSource = m_AudioSource.Get<AudioSource>(args);
			if (audioSource == null)
			{
				return;
			}
			float pitch = audioSource.pitch;
			float target = (float)m_Pitch.Get(args);
			ITweenInput tween = new TweenInput<float>(pitch, target, m_Transition.Duration, delegate(float a, float b, float t)
			{
				audioSource.pitch = Mathf.Lerp(a, b, t);
			}, Tween.GetHash(typeof(AudioSource), "pitch"), m_Transition.EasingType, m_Transition.Time);
			Tween.To(audioSource.gameObject, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
