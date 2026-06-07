using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Image(typeof(IconLight), ColorTheme.Type.Yellow)]
	[Title("Light Color")]
	[Description("Smoothly changes the color of a Light component")]
	[Category("Lights/Light Color")]
	[Parameter("Color", "The color the Light component starts emitting")]
	[Keywords(new string[] { "Colour", "Hue", "Mood", "RGB", "Light" })]
	public class InstructionLightChangeColor : TInstructionLight
	{
		[SerializeField]
		private ChangeColor m_Color = new ChangeColor();

		public override string Title => $"Light Color of {m_Light} {m_Color}";

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
			Color color = light.color;
			Color target = m_Color.Get(color, args);
			ITweenInput tween = new TweenInput<Color>(color, target, m_Transition.Duration, delegate(Color a, Color b, float t)
			{
				light.color = Color.Lerp(a, b, t);
			}, Tween.GetHash(typeof(Light), "color"), m_Transition.EasingType, m_Transition.Time);
			Tween.To(gameObject, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
