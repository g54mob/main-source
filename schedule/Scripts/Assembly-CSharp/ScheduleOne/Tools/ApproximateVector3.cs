using UnityEngine;

namespace ScheduleOne.Tools
{
	public struct ApproximateVector3
	{
		public short X;

		public short Y;

		public short Z;

		public ApproximateVector3(float x, float y, float z)
		{
			X = 0;
			Y = 0;
			Z = 0;
		}

		public ApproximateVector3(Vector3 vector)
		{
			X = 0;
			Y = 0;
			Z = 0;
		}

		public Vector3 ToVector3()
		{
			return default(Vector3);
		}
	}
}
