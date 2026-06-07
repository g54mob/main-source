using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Change Animator Layer")]
	[Description("Changes the weight of an Animator Layer")]
	[Image(typeof(IconAnimator), ColorTheme.Type.Blue)]
	[Category("Animations/Change Animator Layer")]
	[Parameter("Layer Index", "The Animator's Layer index that's being modified")]
	[Parameter("Weight", "The target Animator layer weight")]
	[Parameter("Duration", "How long it takes to perform the transition")]
	[Parameter("Easing", "The change rate of the parameter over time")]
	[Parameter("Wait to Complete", "Whether to wait until the transition is finished")]
	[Keywords(new string[] { "Weight" })]
	public class InstructionAnimatorLayer : TInstructionAnimator
	{
		[SerializeField]
		private int m_LayerIndex = 1;

		[SerializeField]
		private ChangeDecimal m_Weight = new ChangeDecimal(1f);

		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => $"Change Layer Weight {m_LayerIndex} on {m_Animator}";

		protected override async Task Run(Args args)
		{
			GameObject gameObject = m_Animator.Get(args);
			if (gameObject == null)
			{
				return;
			}
			Animator animator = gameObject.Get<Animator>();
			if (animator == null || m_LayerIndex >= animator.layerCount)
			{
				return;
			}
			float layerWeight = animator.GetLayerWeight(m_LayerIndex);
			float target = (float)m_Weight.Get(layerWeight, args);
			ITweenInput tween = new TweenInput<float>(layerWeight, target, m_Transition.Duration, delegate(float a, float b, float t)
			{
				animator.SetLayerWeight(m_LayerIndex, Mathf.Lerp(a, b, t));
			}, Tween.GetHash(typeof(Animator), "weight"), m_Transition.EasingType, m_Transition.Time);
			Tween.To(gameObject, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
