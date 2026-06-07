using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Change Position")]
	[Description("Changes the position of a game object over time")]
	[Image(typeof(IconVector3), ColorTheme.Type.Yellow)]
	[Category("Transforms/Change Position")]
	[Parameter("Position", "The desired position of the game object")]
	[Parameter("Space", "If the transformation occurs in local or world space")]
	[Parameter("Duration", "How long it takes to perform the transition")]
	[Parameter("Easing", "The change rate of the translation over time")]
	[Parameter("Wait to Complete", "Whether to wait until the translation is finished or not")]
	[Keywords(new string[] { "Location", "Translate", "Move", "Displace", "Set" })]
	public class InstructionTransformChangePosition : TInstructionTransform
	{
		private enum SpaceMode
		{
			GlobalPosition = 0,
			LocalPosition = 1
		}

		[SerializeField]
		private SpaceMode m_Space;

		[SerializeField]
		private ChangePosition m_Position = new ChangePosition(Vector3.up);

		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => $"Move {m_Transform} {m_Position}";

		protected override async Task Run(Args args)
		{
			GameObject gameObject = m_Transform.Get(args);
			if (gameObject == null)
			{
				return;
			}
			Vector3 vector = m_Space switch
			{
				SpaceMode.GlobalPosition => gameObject.transform.position, 
				SpaceMode.LocalPosition => gameObject.transform.localPosition, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
			Vector3 target = m_Position.Get(vector, args);
			ITweenInput tween = new TweenInput<Vector3>(vector, target, m_Transition.Duration, delegate(Vector3 a, Vector3 b, float t)
			{
				switch (m_Space)
				{
				case SpaceMode.GlobalPosition:
					gameObject.transform.position = Vector3.LerpUnclamped(a, b, t);
					break;
				case SpaceMode.LocalPosition:
					gameObject.transform.localPosition = Vector3.LerpUnclamped(a, b, t);
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}, Tween.GetHash(typeof(Transform), "position"), m_Transition.EasingType, m_Transition.Time);
			Tween.To(gameObject, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
