using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dorfromantik
{
	[Serializable]
	public class SearchIterationData
	{
		public float searchDistance = 10f;

		public float maxAngle = 90f;

		public AnimationCurve coneAngleByRadius;

		public bool searchOffscreen = true;

		public bool limitOffscreenSearchDistance;

		[FormerlySerializedAs("maxOffscreenSearchDistance")]
		public Vector2 maxOffscreenDistance = Vector2.zero;

		public float maxCircleSegmentLength = 1.5f;

		public Color debugColor;

		public float debugDuration;
	}
}
