using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Terminal Velocity")]
	[Description("Changes the Character's maximum fall-speed over time. Useful for gliding")]
	[Category("Characters/Properties/Change Terminal Velocity")]
	[Parameter("Terminal Velocity", "The target Terminal Velocity value for the Character")]
	[Parameter("Duration", "How long it takes to perform the transition")]
	[Parameter("Easing", "The change rate of the parameter over time")]
	[Parameter("Wait to Complete", "Whether to wait until the transition is finished")]
	[Keywords(new string[] { "Fall", "Glide", "Parachute", "Height" })]
	[Image(typeof(IconBust), ColorTheme.Type.Yellow)]
	public class InstructionCharacterPropertyTerminalVelocity : TInstructionCharacterProperty
	{
		[SerializeField]
		private ChangeDecimal m_TerminalVelocity = new ChangeDecimal(-53f);

		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => $"Terminal Velocity {m_Character} {m_TerminalVelocity}";

		protected override async Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return;
			}
			float num = Math.Min(0f, character.Driver.WorldMoveDirection.y);
			float target = (float)m_TerminalVelocity.Get(num, args);
			ITweenInput tween = new TweenInput<float>(num, target, m_Transition.Duration, delegate(float a, float b, float t)
			{
				character.Motion.TerminalVelocity = Mathf.Lerp(a, b, t);
			}, Tween.GetHash(typeof(Character), "property:terminal-velocity"), m_Transition.EasingType, m_Transition.Time);
			Tween.To(character.gameObject, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
