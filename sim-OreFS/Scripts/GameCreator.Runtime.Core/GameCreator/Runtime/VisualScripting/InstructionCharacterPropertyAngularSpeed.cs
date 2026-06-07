using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Angular Speed")]
	[Description("Changes the Character's angular speed over time")]
	[Category("Characters/Properties/Change Angular Speed")]
	[Parameter("Angular Speed", "The target Angular Speed value for the Character, measured in degrees per second")]
	[Parameter("Duration", "How long it takes to perform the transition")]
	[Parameter("Easing", "The change rate of the parameter over time")]
	[Parameter("Wait to Complete", "Whether to wait until the transition is finished")]
	[Keywords(new string[] { "Rotation", "Euler", "Direction", "Face", "Look" })]
	[Image(typeof(IconBust), ColorTheme.Type.Yellow)]
	public class InstructionCharacterPropertyAngularSpeed : TInstructionCharacterProperty
	{
		[SerializeField]
		private ChangeDecimal m_AngularSpeed = new ChangeDecimal(720f);

		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => $"Angular Speed {m_Character} {m_AngularSpeed}";

		protected override async Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return;
			}
			float angularSpeed = character.Motion.AngularSpeed;
			float target = (float)m_AngularSpeed.Get(angularSpeed, args);
			ITweenInput tween = new TweenInput<float>(angularSpeed, target, m_Transition.Duration, delegate(float a, float b, float t)
			{
				character.Motion.AngularSpeed = Mathf.Lerp(a, b, t);
			}, Tween.GetHash(typeof(Character), "property:angular-speed"), m_Transition.EasingType, m_Transition.Time);
			Tween.To(character.gameObject, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
