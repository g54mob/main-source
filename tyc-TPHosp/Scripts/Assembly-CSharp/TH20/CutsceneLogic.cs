using UnityEngine;

namespace TH20
{
	public abstract class CutsceneLogic
	{
		public enum Type
		{
			FocalPointPosition = 0,
			Spline = 1
		}

		public struct Result
		{
			public Vector3 TargetPosition;

			public Vector3 TargetFocalPoint;
		}

		protected Transform CameraTransform;

		public Type LogicType { get; protected set; }

		protected CutsceneLogic(Transform cameraTransform)
		{
			CameraTransform = cameraTransform;
		}

		public abstract Result CalculateCameraVariables();

		public virtual bool ContinueSmoothingAfterFinish()
		{
			return false;
		}

		public abstract bool IsFinished();

		public abstract string PrintStatus();
	}
}
