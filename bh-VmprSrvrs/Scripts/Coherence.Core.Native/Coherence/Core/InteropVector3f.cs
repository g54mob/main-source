using System.Numerics;

namespace Coherence.Core
{
	public struct InteropVector3f
	{
		public float X;

		public float Y;

		public float Z;

		public InteropVector3f(Vector3 vector)
		{
			X = 0f;
			Y = 0f;
			Z = 0f;
		}

		public Vector3 Into()
		{
			return default(Vector3);
		}
	}
}
