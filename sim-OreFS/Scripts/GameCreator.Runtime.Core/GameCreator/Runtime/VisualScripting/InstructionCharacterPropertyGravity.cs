using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Gravity")]
	[Description("Changes the Character's gravity over time")]
	[Category("Characters/Properties/Change Gravity")]
	[Parameter("Mode", "Whether the upwards, downwards or both Gravity values are changed")]
	[Parameter("Gravity", "The target Gravity value for the Character")]
	[Parameter("Duration", "How long it takes to perform the transition")]
	[Parameter("Easing", "The change rate of the parameter over time")]
	[Parameter("Wait to Complete", "Whether to wait until the transition is finished")]
	[Keywords(new string[] { "Space" })]
	[Image(typeof(IconBust), ColorTheme.Type.Yellow)]
	public class InstructionCharacterPropertyGravity : TInstructionCharacterProperty
	{
		private enum Mode
		{
			Both = 0,
			GravityUpwards = 1,
			GravityDownwards = 2
		}

		[SerializeField]
		private Mode m_Mode;

		[SerializeField]
		private ChangeDecimal m_Gravity = new ChangeDecimal(-9.81f);

		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => string.Format("{0}Gravity {1} {2}", m_Mode switch
		{
			Mode.Both => string.Empty, 
			Mode.GravityUpwards => "Upwards ", 
			Mode.GravityDownwards => "Downwards ", 
			_ => throw new ArgumentOutOfRangeException(), 
		}, m_Character, m_Gravity);

		protected override async Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return;
			}
			float num = Math.Min(0f, m_Mode switch
			{
				Mode.Both => (character.Motion.GravityUpwards + character.Motion.GravityDownwards) / 2f, 
				Mode.GravityUpwards => character.Motion.GravityUpwards, 
				Mode.GravityDownwards => character.Motion.GravityDownwards, 
				_ => throw new ArgumentOutOfRangeException(), 
			});
			float target = (float)m_Gravity.Get(num, args);
			ITweenInput tween = new TweenInput<float>(num, target, m_Transition.Duration, delegate(float a, float b, float t)
			{
				float num2 = Mathf.Lerp(a, b, t);
				switch (m_Mode)
				{
				case Mode.Both:
					character.Motion.GravityUpwards = num2;
					character.Motion.GravityDownwards = num2;
					break;
				case Mode.GravityUpwards:
					character.Motion.GravityUpwards = num2;
					break;
				case Mode.GravityDownwards:
					character.Motion.GravityDownwards = num2;
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}, Tween.GetHash(typeof(Character), "property:gravity"), m_Transition.EasingType, m_Transition.Time);
			Tween.To(character.gameObject, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
