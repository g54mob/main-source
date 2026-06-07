using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Lerp Color")]
	[Description("Linearly interpolates between to colors over time")]
	[Category("Math/Shading/Lerp Color")]
	[Parameter("Color 1", "The starting Color value")]
	[Parameter("Color 2", "The targeted Color value")]
	[Parameter("Duration", "How long it takes to perform the transition")]
	[Parameter("Easing", "The change rate of the transition over time")]
	[Parameter("Wait to Complete", "Whether to wait until the transition is finished or not")]
	[Keywords(new string[] { "Change", "Value", "Transition" })]
	[Image(typeof(IconColor), ColorTheme.Type.Yellow, typeof(OverlayArrowRight))]
	public class InstructionShadingLerpColor : TInstructionShading
	{
		[SerializeField]
		private PropertyGetColor m_Color1 = GetColorColorsWhite.Create;

		[SerializeField]
		private PropertyGetColor m_Color2 = GetColorColorsBlue.Create;

		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => $"Lerp from {m_Color1} to {m_Color2}";

		protected override async Task Run(Args args)
		{
			Color source = m_Color1.Get(args);
			Color target = m_Color2.Get(args);
			ITweenInput tween = new TweenInput<Color>(source, target, m_Transition.Duration, delegate(Color a, Color b, float t)
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
