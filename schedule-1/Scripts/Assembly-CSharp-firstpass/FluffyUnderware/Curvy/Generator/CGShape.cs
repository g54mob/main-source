using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using ToolBuddy.Pooling.Collections;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator
{
	[CGDataInfo(0.73f, 0.87f, 0.98f, 1f)]
	public class CGShape : CGData
	{
		public List<SamplePointsMaterialGroup> MaterialGroups;

		public bool SourceIsManaged;

		public bool Closed;

		public bool Seamless;

		public float Length;

		private SubArray<float> relativeDistances;

		private SubArray<float> sourceRelativeDistances;

		private SubArray<Vector3> positions;

		private SubArray<Vector3> normals;

		private SubArray<float> customValues;

		private float mCacheLastF;

		private int mCacheLastIndex;

		private float mCacheLastFrag;

		public SubArray<float> RelativeDistances
		{
			get
			{
				return default(SubArray<float>);
			}
			set
			{
			}
		}

		public SubArray<float> SourceRelativeDistances
		{
			get
			{
				return default(SubArray<float>);
			}
			set
			{
			}
		}

		public SubArray<Vector3> Positions
		{
			get
			{
				return default(SubArray<Vector3>);
			}
			set
			{
			}
		}

		public SubArray<Vector3> Normals
		{
			get
			{
				return default(SubArray<Vector3>);
			}
			set
			{
			}
		}

		public SubArray<float> CustomValues
		{
			get
			{
				return default(SubArray<float>);
			}
			set
			{
			}
		}

		public List<DuplicateSamplePoint> DuplicatePoints { get; set; }

		[Obsolete("Use RelativeDistances instead")]
		[UsedImplicitly]
		public float[] F
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Obsolete("Use SourceRelativeDistances instead")]
		[UsedImplicitly]
		public float[] SourceF
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Obsolete("Use Positions instead")]
		[UsedImplicitly]
		public Vector3[] Position
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[UsedImplicitly]
		[Obsolete("Use Normals instead")]
		public Vector3[] Normal
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Obsolete("Use CustomValues instead")]
		[UsedImplicitly]
		public float[] Map
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override int Count => 0;

		public CGShape()
		{
		}

		public CGShape(CGShape source)
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

		public static void Copy(CGShape dest, CGShape source)
		{
		}

		public void Copy(CGShape source)
		{
		}

		public float DistanceToF(float distance)
		{
			return 0f;
		}

		public float FToDistance(float f)
		{
			return 0f;
		}

		public int GetFIndex(float f, out float frag)
		{
			frag = default(float);
			return 0;
		}

		public Vector3 InterpolatePosition(float f)
		{
			return default(Vector3);
		}

		public Vector3 InterpolateUp(float f)
		{
			return default(Vector3);
		}

		public void Interpolate(float f, out Vector3 position, out Vector3 up)
		{
			position = default(Vector3);
			up = default(Vector3);
		}

		public void Move(ref float f, ref int direction, float speed, CurvyClamping clamping)
		{
		}

		public void MoveBy(ref float f, ref int direction, float speedDist, CurvyClamping clamping)
		{
		}

		public virtual void Recalculate()
		{
		}

		[UsedImplicitly]
		[Obsolete("Use another overload of RecalculateNormals instead")]
		public void RecalculateNormals(List<int> softEdges)
		{
		}

		public void RecalculateNormals([NotNull] CurvySpline spline)
		{
		}

		public void RecalculateNormals()
		{
		}
	}
}
