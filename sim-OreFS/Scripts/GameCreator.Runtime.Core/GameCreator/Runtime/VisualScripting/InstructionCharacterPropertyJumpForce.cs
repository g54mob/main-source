using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Jump Force")]
	[Description("Changes the Character's jump force over time")]
	[Category("Characters/Properties/Change Jump Force")]
	[Parameter("Jump Force", "The target Jump Force value for the Character")]
	[Parameter("Duration", "How long it will take to perform the transition")]
	[Parameter("Easing", "The change rate of the parameter over time")]
	[Parameter("Wait to Complete", "Whether to wait until the transition is finished")]
	[Keywords(new string[] { "Hop", "Build", "Wind", "Fly" })]
	[Image(typeof(IconBust), ColorTheme.Type.Yellow)]
	public class InstructionCharacterPropertyJumpForce : TInstructionCharacterProperty
	{
		[SerializeField]
		private ChangeDecimal m_JumpForce = new ChangeDecimal(4f);

		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => $"Jump Force {m_Character} {m_JumpForce}";

		protected override async Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return;
			}
			float jumpForce = character.Motion.JumpForce;
			float target = (float)m_JumpForce.Get(jumpForce, args);
			ITweenInput tween = new TweenInput<float>(jumpForce, target, m_Transition.Duration, delegate(float a, float b, float t)
			{
				character.Motion.JumpForce = Mathf.Lerp(a, b, t);
			}, Tween.GetHash(typeof(Character), "property:jump-force"), m_Transition.EasingType, m_Transition.Time);
			Tween.To(character.gameObject, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
