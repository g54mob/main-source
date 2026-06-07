using Presentation.FactoryFloor;
using UnityEngine;

namespace JobSystem
{
	public struct RequestTransformJobContext
	{
		public readonly Transform Transform;

		public readonly Vector3 StartPosition;

		public readonly Vector3 EndPosition;

		public readonly float StartScale;

		public readonly float EndScale;

		public readonly float TotalTime;

		public readonly float StartTime;

		public readonly ITransformJobAble Source;

		private readonly bool _add;

		internal RequestTransformJobContext(Transform transform, ITransformJobAble source, Vector3 startPosition, Vector3 endPosition, float startScale, float endScale, float totalTime, float startTime, bool add)
		{
			Transform = transform;
			StartPosition = startPosition;
			EndPosition = endPosition;
			StartScale = startScale;
			EndScale = endScale;
			TotalTime = totalTime;
			StartTime = startTime;
			Source = source;
			_add = add;
		}

		public void Execute()
		{
			if (_add)
			{
				TransformJobManager.AddTransform(this);
			}
			else
			{
				TransformJobManager.RemoveTransform(this);
			}
		}
	}
}
