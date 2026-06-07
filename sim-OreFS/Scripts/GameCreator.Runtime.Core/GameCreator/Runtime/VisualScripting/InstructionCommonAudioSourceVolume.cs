using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Audio Source Volume")]
	[Description("Changes the volume of an Audio Source component")]
	[Category("Audio/Audio Source Volume")]
	[Parameter("Audio Source", "The Audio Source component")]
	[Parameter("Volume", "The new targeted volume to change")]
	[Parameter("Transition", "How long it takes to reach the new value")]
	[Keywords(new string[] { "Clip", "Music" })]
	[Image(typeof(IconAudioSource), ColorTheme.Type.Yellow)]
	public class InstructionCommonAudioSourceVolume : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_AudioSource = GetGameObjectInstance.Create();

		[SerializeField]
		private PropertyGetDecimal m_Volume = GetDecimalDecimal.Create(1f);

		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => $"Volume of {m_AudioSource} = {m_Volume}";

		protected override async Task Run(Args args)
		{
			AudioSource audioSource = m_AudioSource.Get<AudioSource>(args);
			if (audioSource == null)
			{
				return;
			}
			float volume = audioSource.volume;
			float target = (float)m_Volume.Get(args);
			ITweenInput tween = new TweenInput<float>(volume, target, m_Transition.Duration, delegate(float a, float b, float t)
			{
				audioSource.volume = Mathf.Lerp(a, b, t);
			}, Tween.GetHash(typeof(AudioSource), "volume"), m_Transition.EasingType, m_Transition.Time);
			Tween.To(audioSource.gameObject, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
