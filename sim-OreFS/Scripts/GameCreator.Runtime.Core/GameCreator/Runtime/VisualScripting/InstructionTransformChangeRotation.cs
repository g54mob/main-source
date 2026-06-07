using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Change Rotation")]
	[Description("Changes the rotation of a game object over time")]
	[Image(typeof(IconRotation), ColorTheme.Type.Yellow)]
	[Category("Transforms/Change Rotation")]
	[Parameter("Rotation", "The desired rotation of the game object")]
	[Parameter("Space", "If the transformation occurs in local or world space")]
	[Parameter("Duration", "How long it takes to perform the transition")]
	[Parameter("Easing", "The change rate of the rotation over time")]
	[Parameter("Wait to Complete", "Whether to wait until the rotation is finished or not")]
	[Keywords(new string[] { "Rotate", "Angle", "Euler", "Tilt", "Pitch", "Yaw", "Roll" })]
	public class InstructionTransformChangeRotation : TInstructionTransform
	{
		private enum SpaceMode
		{
			GlobalRotation = 0,
			LocalRotation = 1
		}

		[SerializeField]
		private SpaceMode m_Space;

		[SerializeField]
		private ChangeQuaternion m_Rotation = new ChangeQuaternion(Quaternion.Euler(0f, 180f, 0f));

		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => $"Rotate {m_Transform} {m_Rotation}";

		protected override async Task Run(Args args)
		{
			GameObject gameObject = m_Transform.Get(args);
			if (gameObject == null)
			{
				return;
			}
			Quaternion quaternion = m_Space switch
			{
				SpaceMode.GlobalRotation => gameObject.transform.rotation, 
				SpaceMode.LocalRotation => gameObject.transform.localRotation, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
			Quaternion target = m_Rotation.Get(quaternion, args);
			ITweenInput tween = new TweenInput<Quaternion>(quaternion, target, m_Transition.Duration, delegate(Quaternion a, Quaternion b, float t)
			{
				switch (m_Space)
				{
				case SpaceMode.GlobalRotation:
					gameObject.transform.rotation = Quaternion.LerpUnclamped(a, b, t);
					break;
				case SpaceMode.LocalRotation:
					gameObject.transform.localRotation = Quaternion.LerpUnclamped(a, b, t);
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}, Tween.GetHash(typeof(Transform), "rotation"), m_Transition.EasingType, m_Transition.Time);
			Tween.To(gameObject, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
