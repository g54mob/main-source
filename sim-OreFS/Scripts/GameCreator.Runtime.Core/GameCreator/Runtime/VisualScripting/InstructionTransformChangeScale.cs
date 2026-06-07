using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Change Scale")]
	[Description("Changes the local scale of a game object over time")]
	[Image(typeof(IconScale), ColorTheme.Type.Yellow)]
	[Category("Transforms/Change Scale")]
	[Parameter("Scale", "The desired scale of the game object")]
	[Parameter("Duration", "How long it takes to perform the transition")]
	[Parameter("Easing", "The change rate of the scaling over time")]
	[Parameter("Wait to Complete", "Whether to wait until the scaling is finished or not")]
	[Keywords(new string[] { "Size", "Resize", "Grow", "Reduce", "Small", "Big" })]
	public class InstructionTransformChangeScale : TInstructionTransform
	{
		[SerializeField]
		private ChangeScale m_Scale = new ChangeScale(Vector3.one);

		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => $"Scale {m_Transform} {m_Scale}";

		protected override async Task Run(Args args)
		{
			GameObject gameObject = m_Transform.Get(args);
			if (gameObject == null)
			{
				return;
			}
			Vector3 localScale = gameObject.transform.localScale;
			Vector3 target = m_Scale.Get(localScale, args);
			ITweenInput tween = new TweenInput<Vector3>(localScale, target, m_Transition.Duration, delegate(Vector3 a, Vector3 b, float t)
			{
				gameObject.transform.localScale = Vector3.LerpUnclamped(a, b, t);
			}, Tween.GetHash(typeof(Transform), "scale"), m_Transition.EasingType, m_Transition.Time);
			Tween.To(gameObject, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
