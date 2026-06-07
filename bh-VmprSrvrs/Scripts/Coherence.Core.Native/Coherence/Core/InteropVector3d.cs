using Coherence.Common;

namespace Coherence.Core
{
	public struct InteropVector3d
	{
		public double X;

		public double Y;

		public double Z;

		public InteropVector3d(Vector3d vector)
		{
			X = 0.0;
			Y = 0.0;
			Z = 0.0;
		}

		public Vector3d Into()
		{
			return default(Vector3d);
		}
	}
}
