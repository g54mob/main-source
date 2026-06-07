using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Radius")]
	[Description("Changes the Character's radius over time")]
	[Category("Characters/Properties/Change Radius")]
	[Parameter("Radius", "The target Radius value for the Character")]
	[Parameter("Duration", "How long it takes to perform the transition")]
	[Parameter("Easing", "The change rate of the parameter over time")]
	[Parameter("Wait to Complete", "Whether to wait until the transition is finished")]
	[Keywords(new string[] { "Diameter", "Space", "Fat", "Thin" })]
	[Image(typeof(IconBust), ColorTheme.Type.Yellow)]
	public class InstructionCharacterPropertyRadius : TInstructionCharacterProperty
	{
		[SerializeField]
		private ChangeDecimal m_Radius = new ChangeDecimal(0.5f);

		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => $"Radius {m_Character} {m_Radius}";

		protected override async Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return;
			}
			float radius = character.Motion.Radius;
			float target = (float)m_Radius.Get(radius, args);
			ITweenInput tween = new TweenInput<float>(radius, target, m_Transition.Duration, delegate(float a, float b, float t)
			{
				character.Motion.Radius = Mathf.Lerp(a, b, t);
			}, Tween.GetHash(typeof(Character), "property:radius"), m_Transition.EasingType, m_Transition.Time);
			Tween.To(character.gameObject, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
