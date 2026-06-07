using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public struct MotionFollowData
	{
		public static MotionFollowData None => default(MotionFollowData);

		[field: NonSerialized]
		public Transform Transform { get; }

		[field: NonSerialized]
		public float MinRadius { get; }

		[field: NonSerialized]
		public float MaxRadius { get; }

		public MotionFollowData(Transform transform, float minRadius, float maxRadius)
		{
			Transform = transform;
			MinRadius = minRadius;
			MaxRadius = maxRadius;
		}
	}
}
