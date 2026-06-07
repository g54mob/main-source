using System;
using JetBrains.Annotations;
using ToolBuddy.Pooling.Collections;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator
{
	[CGDataInfo(0.08f, 0.4f, 0.75f, 1f)]
	public class CGVolume : CGPath
	{
		public bool CrossClosed;

		public bool CrossSeamless;

		public float CrossFShift;

		public SamplePointsMaterialGroupCollection CrossMaterialGroups;

		private SubArray<Vector3> vertices;

		private SubArray<Vector3> vertexNormals;

		private SubArray<float> crossRelativeDistances;

		private SubArray<float> crossCustomValues;

		private SubArray<Vector2> scales;

		[UsedImplicitly]
		[Obsolete("Do not use this. Use the GetCrossLength method instead")]
		private float[] _segmentLength;

		public SubArray<Vector3> Vertices
		{
			get
			{
				return default(SubArray<Vector3>);
			}
			set
			{
			}
		}

		public SubArray<Vector3> VertexNormals
		{
			get
			{
				return default(SubArray<Vector3>);
			}
			set
			{
			}
		}

		public SubArray<float> CrossRelativeDistances
		{
			get
			{
				return default(SubArray<float>);
			}
			set
			{
			}
		}

		public SubArray<float> CrossCustomValues
		{
			get
			{
				return default(SubArray<float>);
			}
			set
			{
			}
		}

		public SubArray<Vector2> Scales
		{
			get
			{
				return default(SubArray<Vector2>);
			}
			set
			{
			}
		}

		[UsedImplicitly]
		[Obsolete("Use Vertices instead")]
		public Vector3[] Vertex
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
		[Obsolete("Use VertexNormals instead")]
		public Vector3[] VertexNormal
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Obsolete("Use CrossRelativeDistances instead")]
		[UsedImplicitly]
		public float[] CrossF
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Obsolete("Use CrossCustomValues instead")]
		[UsedImplicitly]
		public float[] CrossMap
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
		[Obsolete("Do not use this. Use the GetCrossLength method instead")]
		public float[] SegmentLength
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int CrossSize => 0;

		public int VertexCount => 0;

		[Obsolete("Use one of the other constructors")]
		[UsedImplicitly]
		public CGVolume()
		{
		}

		public CGVolume(int samplePoints, CGShape crossShape)
		{
		}

		public CGVolume(CGPath path, CGShape crossShape)
		{
		}

		public CGVolume(CGVolume source)
		{
		}

		protected override bool Dispose(bool disposing)
		{
			return false;
		}

		[NotNull]
		public static CGVolume Get([CanBeNull] CGVolume data, CGPath path, CGShape crossShape)
		{
			return null;
		}

		public override T Clone<T>()
		{
			return null;
		}

		public void InterpolateVolume(float f, float crossF, out Vector3 pos, out Vector3 dir, out Vector3 up)
		{
			pos = default(Vector3);
			dir = default(Vector3);
			up = default(Vector3);
		}

		public Vector3 InterpolateVolumePosition(float f, float crossF)
		{
			return default(Vector3);
		}

		public Vector3 InterpolateVolumeDirection(float f, float crossF)
		{
			return default(Vector3);
		}

		public Vector3 InterpolateVolumeUp(float f, float crossF)
		{
			return default(Vector3);
		}

		public float GetCrossLength(float pathF)
		{
			return 0f;
		}

		public float CrossFToDistance(float f, float crossF, CurvyClamping crossClamping = CurvyClamping.Clamp)
		{
			return 0f;
		}

		public float CrossDistanceToF(float f, float distance, CurvyClamping crossClamping = CurvyClamping.Clamp)
		{
			return 0f;
		}

		[UsedImplicitly]
		[Obsolete("Method will get removed. Copy its content if you still need it")]
		public void GetSegmentIndices(float pathF, out int segment0Index, out int segment1Index, out float frag)
		{
			segment0Index = default(int);
			segment1Index = default(int);
			frag = default(float);
		}

		public int GetSegmentIndex(int segment)
		{
			return 0;
		}

		public int GetCrossFIndex(float crossF, out float frag)
		{
			frag = default(float);
			return 0;
		}

		public int GetVertexIndex(float pathF, out float pathFrag)
		{
			pathFrag = default(float);
			return 0;
		}

		public int GetVertexIndex(float pathF, float crossF, out float pathFrag, out float crossFrag)
		{
			pathFrag = default(float);
			crossFrag = default(float);
			return 0;
		}

		public Vector3[] GetSegmentVertices(params int[] segmentIndices)
		{
			return null;
		}

		private float calcSegmentLength(int segmentIndex)
		{
			return 0f;
		}
	}
}
