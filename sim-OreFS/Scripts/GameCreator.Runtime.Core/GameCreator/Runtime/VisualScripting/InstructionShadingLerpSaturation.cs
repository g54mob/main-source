using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Lerp Saturation")]
	[Description("Linearly interpolates between to the desired saturation value over time")]
	[Category("Math/Shading/Lerp Saturation")]
	[Parameter("Saturation", "The targeted Saturation value (between 0 and 1)")]
	[Parameter("Duration", "How long it takes to perform the transition")]
	[Parameter("Easing", "The change rate of the transition over time")]
	[Parameter("Wait to Complete", "Whether to wait until the transition is finished or not")]
	[Keywords(new string[] { "Change", "Value", "Transition" })]
	[Image(typeof(IconColor), ColorTheme.Type.Blue, typeof(OverlayY))]
	public class InstructionShadingLerpSaturation : TInstructionShading
	{
		[SerializeField]
		private PropertyGetDecimal m_Saturation = GetDecimalDecimal.Create(1f);

		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => $"Lerp to Saturation: {m_Saturation}";

		protected override async Task Run(Args args)
		{
			Color color = m_Set.Get(args);
			Color.RGBToHSV(color, out var H, out var _, out var V);
			Color target = Color.HSVToRGB(H, (float)m_Saturation.Get(args), V);
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
