using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Height")]
	[Description("Changes the Character's height over time")]
	[Category("Characters/Properties/Change Height")]
	[Parameter("Height", "The target Height value for the Character")]
	[Parameter("Duration", "How long it takes to perform the transition")]
	[Parameter("Easing", "The change rate of the parameter over time")]
	[Parameter("Wait to Complete", "Whether to wait until the transition is finished")]
	[Keywords(new string[] { "Length" })]
	[Image(typeof(IconBust), ColorTheme.Type.Yellow)]
	public class InstructionCharacterPropertyHeight : TInstructionCharacterProperty
	{
		[SerializeField]
		private ChangeDecimal m_Height = new ChangeDecimal(2f);

		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => $"Height {m_Character} {m_Height}";

		protected override async Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return;
			}
			float height = character.Motion.Height;
			float target = (float)m_Height.Get(height, args);
			ITweenInput tween = new TweenInput<float>(height, target, m_Transition.Duration, delegate(float a, float b, float t)
			{
				character.Motion.Height = Mathf.Lerp(a, b, t);
			}, Tween.GetHash(typeof(Character), "property:height"), m_Transition.EasingType, m_Transition.Time);
			Tween.To(character.gameObject, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
