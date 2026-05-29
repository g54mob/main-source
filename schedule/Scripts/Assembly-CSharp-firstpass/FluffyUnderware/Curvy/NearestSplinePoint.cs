using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy
{
	[ExecuteAlways]
	[AddComponentMenu("Curvy/Misc/Nearest Spline Point")]
	[HelpURL("https://curvyeditor.com/doclink/nearestsplinepoint")]
	public class NearestSplinePoint : DTVersionedMonoBehaviour
	{
		[Tooltip("The spline on which the nearest position is searched for")]
		public CurvySpline Spline;

		[Tooltip("A transform which position will be used as the input position for the lookup")]
		public Transform SourcePosition;

		[Tooltip("A transform which position will be updated with the nearest point on Spline to Source Position")]
		public Transform TargetPosition;

		[Tooltip("When to run the lookup")]
		public CurvyUpdateMethod UpdateIn;

		[Tooltip("At each update, this event is called with the result of the lookup")]
		public UnityEventEx<Vector3> OnUpdated;

		private void Process()
		{
		}

		[UsedImplicitly]
		private void Update()
		{
		}

		[UsedImplicitly]
		private void LateUpdate()
		{
		}

		[UsedImplicitly]
		private void FixedUpdate()
		{
		}
	}
}
