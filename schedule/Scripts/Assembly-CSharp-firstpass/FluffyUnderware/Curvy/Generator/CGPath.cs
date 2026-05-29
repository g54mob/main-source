using System;
using JetBrains.Annotations;
using ToolBuddy.Pooling.Collections;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator
{
	[CGDataInfo(0.13f, 0.59f, 0.95f, 1f)]
	public class CGPath : CGShape
	{
		private SubArray<Vector3> directions;

		public SubArray<Vector3> Directions
		{
			get
			{
				return default(SubArray<Vector3>);
			}
			set
			{
			}
		}

		[UsedImplicitly]
		[Obsolete("Use Directions instead")]
		public Vector3[] Direction
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CGPath()
		{
		}

		public CGPath(CGPath source)
		{
		}

		protected override bool Dispose(bool disposing)
		{
			return false;
		}

		public override T Clone<T>()
		{
			return null;
		}

		public static void Copy(CGPath dest, CGPath source)
		{
		}

		public void Interpolate(float f, out Vector3 position, out Vector3 direction, out Vector3 up)
		{
			position = default(Vector3);
			direction = default(Vector3);
			up = default(Vector3);
		}

		[UsedImplicitly]
		[Obsolete("Method is no more used by Curvy and will get removed. Copy its content if you still need it")]
		public void Interpolate(float f, float angleF, out Vector3 pos, out Vector3 dir, out Vector3 up)
		{
			pos = default(Vector3);
			dir = default(Vector3);
			up = default(Vector3);
		}

		public Vector3 InterpolateDirection(float f)
		{
			return default(Vector3);
		}
	}
}
