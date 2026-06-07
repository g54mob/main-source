using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Smooth Time")]
	[Description("Changes the average blend time between locomotion animations")]
	[Category("Characters/Animation/Change Smooth Time")]
	[Parameter("Smooth Time", "The target Smooth Time value. Values usually range between 0 and 0.5")]
	[Parameter("Duration", "How long it takes to perform the transition")]
	[Parameter("Easing", "The change rate of the parameter over time")]
	[Parameter("Wait to Complete", "Whether to wait until the transition is finished")]
	[Example("The Smooth Time controls how fast a Character animation blends into another when reacting to external factors. A value of 0 makes the Character react instantly whereas a value of 0.5 takes half a second to completely blend in. A value between 0.2 and 0.4 usually provide the best results, though it depends on the look and feel the creator wants to achieve.")]
	[Keywords(new string[] { "Fade", "Realistic", "Old", "School", "Reaction" })]
	[Image(typeof(IconAnimator), ColorTheme.Type.Yellow)]
	public class InstructionCharacterSmoothTime : TInstructionCharacterProperty
	{
		[SerializeField]
		private ChangeDecimal m_SmoothTime = new ChangeDecimal(0.25f);

		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => $"Change Smooth Time of {m_Character} {m_SmoothTime}";

		protected override async Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return;
			}
			float smoothTime = character.Animim.SmoothTime;
			float target = (float)m_SmoothTime.Get(smoothTime, args);
			ITweenInput tween = new TweenInput<float>(smoothTime, target, m_Transition.Duration, delegate(float a, float b, float t)
			{
				character.Animim.SmoothTime = Mathf.Lerp(a, b, t);
			}, Tween.GetHash(typeof(IUnitAnimim), "smooth-time"), m_Transition.EasingType, m_Transition.Time);
			Tween.To(character.gameObject, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
