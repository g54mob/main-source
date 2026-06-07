using Coherence.Common;

namespace Coherence.Toolkit
{
	public struct FloatingOriginShiftArgs
	{
		public Vector3d OldOrigin;

		public Vector3d NewOrigin;

		public Vector3d Delta => default(Vector3d);

		public FloatingOriginShiftArgs(Vector3d oldOrigin, Vector3d newOrigin)
		{
			OldOrigin = default(Vector3d);
			NewOrigin = default(Vector3d);
		}
	}
}
