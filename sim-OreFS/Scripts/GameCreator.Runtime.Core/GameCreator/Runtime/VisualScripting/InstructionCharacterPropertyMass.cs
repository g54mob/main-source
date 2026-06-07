using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Mass")]
	[Description("Changes the Character's mass over time")]
	[Category("Characters/Properties/Change Mass")]
	[Parameter("Mass", "The target Mass value for the Character")]
	[Parameter("Duration", "How long it takes to perform the transition")]
	[Parameter("Easing", "The change rate of the parameter over time")]
	[Parameter("Wait to Complete", "Whether to wait until the transition is finished")]
	[Keywords(new string[] { "Weight" })]
	[Image(typeof(IconBust), ColorTheme.Type.Yellow)]
	public class InstructionCharacterPropertyMass : TInstructionCharacterProperty
	{
		[SerializeField]
		private ChangeDecimal m_Mass = new ChangeDecimal(80f);

		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => $"Mass of {m_Character} {m_Mass}";

		protected override async Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return;
			}
			float mass = character.Motion.Mass;
			float target = (float)m_Mass.Get(mass, args);
			ITweenInput tween = new TweenInput<float>(mass, target, m_Transition.Duration, delegate(float a, float b, float t)
			{
				character.Motion.Mass = Mathf.Lerp(a, b, t);
			}, Tween.GetHash(typeof(Character), "property:mass"), m_Transition.EasingType, m_Transition.Time);
			Tween.To(character.gameObject, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
