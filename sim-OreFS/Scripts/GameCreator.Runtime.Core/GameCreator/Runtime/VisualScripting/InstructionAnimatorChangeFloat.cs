using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Change Animator Float")]
	[Description("Changes the value of a 'Float' Animator parameter")]
	[Image(typeof(IconAnimator), ColorTheme.Type.Green)]
	[Category("Animations/Change Animator Float")]
	[Parameter("Parameter Name", "The Animator parameter name to be modified")]
	[Parameter("Value", "The value of the parameter that is set")]
	[Parameter("Duration", "How long it takes to perform the transition")]
	[Parameter("Easing", "The change rate of the parameter over time")]
	[Parameter("Wait to Complete", "Whether to wait until the transition is finished")]
	[Keywords(new string[] { "Parameter", "Number" })]
	public class InstructionAnimatorChangeFloat : TInstructionAnimator
	{
		[SerializeField]
		private PropertyGetString m_Parameter = new PropertyGetString("My Parameter");

		[SerializeField]
		private ChangeDecimal m_Value = new ChangeDecimal(1f);

		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => $"Change Animator Parameter {m_Parameter} on {m_Animator}";

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
			float num = animator.GetFloat(parameter);
			float target = (float)m_Value.Get(num, args);
			ITweenInput tween = new TweenInput<float>(num, target, m_Transition.Duration, delegate(float a, float b, float t)
			{
				animator.SetFloat(parameter, Mathf.Lerp(a, b, t));
			}, Tween.GetHash(typeof(Animator), $"parameter:{parameter}"), m_Transition.EasingType, m_Transition.Time);
			Tween.To(gameObject, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
