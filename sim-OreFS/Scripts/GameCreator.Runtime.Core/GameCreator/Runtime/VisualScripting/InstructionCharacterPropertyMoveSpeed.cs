using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Movement Speed")]
	[Description("Changes the Character's maximum speed over time")]
	[Category("Characters/Properties/Change Movement Speed")]
	[Parameter("Speed", "The target movement Speed value for the Character")]
	[Parameter("Duration", "How long it takes to perform the transition")]
	[Parameter("Easing", "The change rate of the parameter over time")]
	[Parameter("Wait to Complete", "Whether to wait until the transition is finished")]
	[Keywords(new string[] { "Linear", "Walk", "Run", "Jog", "Sprint", "Velocity", "Throttle" })]
	[Image(typeof(IconBust), ColorTheme.Type.Yellow)]
	public class InstructionCharacterPropertyMoveSpeed : TInstructionCharacterProperty
	{
		[SerializeField]
		private ChangeDecimal m_Speed = new ChangeDecimal(4f);

		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => $"Move Speed {m_Character} {m_Speed}";

		protected override async Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return;
			}
			float linearSpeed = character.Motion.LinearSpeed;
			float target = (float)m_Speed.Get(linearSpeed, args);
			ITweenInput tween = new TweenInput<float>(linearSpeed, target, m_Transition.Duration, delegate(float a, float b, float t)
			{
				character.Motion.LinearSpeed = Mathf.Lerp(a, b, t);
			}, Tween.GetHash(typeof(Character), "property:linear-speed"), m_Transition.EasingType, m_Transition.Time);
			Tween.To(character.gameObject, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
