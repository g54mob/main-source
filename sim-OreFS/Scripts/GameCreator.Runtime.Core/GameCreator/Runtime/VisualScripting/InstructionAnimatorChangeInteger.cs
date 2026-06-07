using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Change Animator Integer")]
	[Description("Changes the value of a 'Integer' Animator parameter")]
	[Image(typeof(IconAnimator), ColorTheme.Type.Green)]
	[Category("Animations/Change Animator Integer")]
	[Parameter("Parameter Name", "The Animator parameter name to be modified")]
	[Parameter("Value", "The value of the parameter that is set")]
	[Parameter("Duration", "How long it takes to perform the transition")]
	[Parameter("Easing", "The change rate of the parameter over time")]
	[Parameter("Wait to Complete", "Whether to wait until the transition is finished")]
	[Keywords(new string[] { "Parameter", "Number" })]
	public class InstructionAnimatorChangeInteger : TInstructionAnimator
	{
		[SerializeField]
		private PropertyGetString m_Parameter = new PropertyGetString("My Parameter");

		[SerializeField]
		private ChangeInteger m_Value = new ChangeInteger(7);

		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => $"Animator {m_Parameter} on {m_Animator}";

		protected override async Task Run(Args args)
		{
			GameObject gameObject = m_Animator.Get(args);
			if (gameObject == null)
			{
				return;
			}
			Animator animator = gameObject.Get<Animator>();
			if (animator == null)
			{
				return;
			}
			int parameter = Animator.StringToHash(m_Parameter.Get(args));
			int integer = animator.GetInteger(parameter);
			int num = m_Value.Get(integer, args);
			ITweenInput tween = new TweenInput<float>(integer, num, m_Transition.Duration, delegate(float a, float b, float t)
			{
				animator.SetInteger(parameter, Mathf.FloorToInt(Mathf.Lerp(a, b, t)));
			}, Tween.GetHash(typeof(Animator), $"parameter:{parameter}"), m_Transition.EasingType, m_Transition.Time);
			Tween.To(gameObject, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
