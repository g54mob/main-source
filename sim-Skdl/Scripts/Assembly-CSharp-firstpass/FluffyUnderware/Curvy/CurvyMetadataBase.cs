using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy
{
	[ExecuteAlways]
	[RequireComponent(typeof(CurvySplineSegment))]
	public abstract class CurvyMetadataBase : DTVersionedMonoBehaviour
	{
		private CurvySplineSegment mCP;

		public CurvySplineSegment ControlPoint => null;

		public CurvySpline Spline => null;

		protected virtual void Awake()
		{
		}

		[UsedImplicitly]
		private void OnDestroy()
		{
		}

		public T GetPreviousData<T>(bool autoCreate = true, bool segmentsOnly = true, bool useFollowUp = false) where T : CurvyMetadataBase
		{
			return null;
		}

		public T GetNextData<T>(bool autoCreate = true, bool segmentsOnly = true, bool useFollowUp = false) where T : CurvyMetadataBase
		{
			return null;
		}

		protected void NotifyModification()
		{
		}
	}
}
