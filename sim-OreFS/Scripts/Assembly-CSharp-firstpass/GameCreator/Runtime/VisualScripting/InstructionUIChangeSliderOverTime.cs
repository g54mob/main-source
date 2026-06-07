using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(1, 0, 0)]
	[Title("Change Slider Over Time")]
	[Description("Changes the value of a Slider component over a period of time")]
	[Image(typeof(IconUISlider), ColorTheme.Type.TextLight)]
	[Category("UI/Change Slider Over Time")]
	[Parameter("Slider", "The Slider component that changes its value")]
	[Parameter("Target Value", "The final value the Slider should reach")]
	[Parameter("Duration", "How long it takes to change the value")]
	[Parameter("Easing", "The easing method to interpolate the value over time")]
	[Parameter("Wait to Complete", "Whether to wait until the value is finished changing or not")]
	public class InstructionUIChangeSliderOverTime : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Slider = GetGameObjectInstance.Create();

		[SerializeField]
		private PropertyGetDecimal m_TargetValue = GetDecimalDecimal.Create(0.75f);

		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => $"Slider {m_Slider} to {m_TargetValue}";

		protected override async Task Run(Args args)
		{
			GameObject gameObject = m_Slider.Get(args);
			if (gameObject == null)
			{
				return;
			}
			Slider slider = gameObject.Get<Slider>();
			if (slider == null)
			{
				return;
			}
			float value = slider.value;
			float target = (float)m_TargetValue.Get(args);
			ITweenInput tween = new TweenInput<float>(value, target, m_Transition.Duration, delegate(float a, float b, float t)
			{
				slider.value = Mathf.LerpUnclamped(a, b, t);
			}, Tween.GetHash(typeof(Slider), "value"), m_Transition.EasingType, m_Transition.Time);
			Tween.To(gameObject, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
