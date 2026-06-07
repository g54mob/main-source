using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Lerp Lightness")]
	[Description("Linearly interpolates between to the desired lightness value over time")]
	[Category("Math/Shading/Lerp Lightness")]
	[Parameter("Lightness", "The targeted Lightness value (between 0 and 1)")]
	[Parameter("Duration", "How long it takes to perform the transition")]
	[Parameter("Easing", "The change rate of the transition over time")]
	[Parameter("Wait to Complete", "Whether to wait until the transition is finished or not")]
	[Keywords(new string[] { "Change", "Value", "Transition" })]
	[Image(typeof(IconColor), ColorTheme.Type.Blue, typeof(OverlayZ))]
	public class InstructionShadingLerpLight : TInstructionShading
	{
		[SerializeField]
		private PropertyGetDecimal m_Lightness = GetDecimalDecimal.Create(1f);

		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => $"Lerp to Lightness: {m_Lightness}";

		protected override async Task Run(Args args)
		{
			Color color = m_Set.Get(args);
			Color.RGBToHSV(color, out var H, out var S, out var _);
			Color target = Color.HSVToRGB(H, S, (float)m_Lightness.Get(args));
			ITweenInput tween = new TweenInput<Color>(color, target, m_Transition.Duration, delegate(Color a, Color b, float t)
			{
				m_Set.Set(Color.Lerp(a, b, t), args);
			}, Tween.GetHash(typeof(GameObject), "color"), m_Transition.EasingType, m_Transition.Time);
			Tween.To(args.Self, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
