using UnityEngine;

namespace GRP
{
	public struct RattleTouchKey
	{
		public int a;

		public int b;

		public Vector3 point;

		public bool Equals(RattleTouchKey other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
