using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class CurveTransformTween : ActionTask<Transform>
	{
		public enum TransformMode
		{
			Position = 0,
			Rotation = 1,
			Scale = 2
		}

		public enum TweenMode
		{
			Absolute = 0,
			Additive = 1
		}

		public enum PlayMode
		{
			Normal = 0,
			PingPong = 1
		}

		public TransformMode transformMode;

		public TweenMode mode;

		public PlayMode playMode;

		public BBParameter<Vector3> targetPosition;

		public BBParameter<AnimationCurve> curve;

		public BBParameter<float> time;

		private Vector3 original;

		private Vector3 final;

		private bool ponging;

		protected override void OnExecute()
		{
		}

		protected override void OnUpdate()
		{
		}
	}
}
