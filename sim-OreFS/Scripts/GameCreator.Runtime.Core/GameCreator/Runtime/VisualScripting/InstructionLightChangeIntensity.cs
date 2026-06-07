using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Image(typeof(IconLight), ColorTheme.Type.Yellow)]
	[Title("Light Intensity")]
	[Description("Smoothly changes the intensity of a Light component")]
	[Category("Lights/Light Intensity")]
	[Parameter("Intensity", "The intensity change that the Light component undergoes")]
	public class InstructionLightChangeIntensity : TInstructionLight
	{
		[SerializeField]
		private ChangeDecimal m_Intensity = new ChangeDecimal(5f);

		public override string Title => $"Light Intensity of {m_Light} {m_Intensity}";

		protected override async Task Run(Args args)
		{
			GameObject gameObject = m_Light.Get(args);
			if (gameObject == null)
			{
				return;
			}
			Light light = gameObject.Get<Light>();
			if (light == null)
			{
				return;
			}
			float intensity = light.intensity;
			float target = (float)m_Intensity.Get(intensity, args);
			ITweenInput tween = new TweenInput<float>(intensity, target, m_Transition.Duration, delegate(float a, float b, float t)
			{
				light.intensity = Mathf.Lerp(a, b, t);
			}, Tween.GetHash(typeof(Light), "intensity"), m_Transition.EasingType, m_Transition.Time);
			Tween.To(gameObject, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
