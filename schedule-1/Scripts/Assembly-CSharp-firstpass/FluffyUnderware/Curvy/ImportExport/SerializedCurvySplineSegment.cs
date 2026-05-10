using System;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.ImportExport
{
	[Serializable]
	public class SerializedCurvySplineSegment
	{
		public Vector3 Position;

		public Vector3 Rotation;

		public bool AutoBakeOrientation;

		public bool OrientationAnchor;

		public CurvyOrientationSwirl Swirl;

		public float SwirlTurns;

		public bool AutoHandles;

		public bool SynchronizeTCB;

		public float AutoHandleDistance;

		public Vector3 HandleOut;

		public Vector3 HandleIn;

		public SerializedCurvySplineSegment()
		{
		}

		public SerializedCurvySplineSegment([NotNull] CurvySplineSegment segment, CurvySerializationSpace space)
		{
		}

		public void WriteIntoControlPoint([NotNull] CurvySplineSegment controlPoint, CurvySerializationSpace space)
		{
		}
	}
}
