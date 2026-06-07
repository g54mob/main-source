using System;

namespace VRTK
{
	[Serializable]
	public class Vector3State
	{
		public bool xState;

		public bool yState;

		public bool zState;

		public static Vector3State False => new Vector3State(x: false, y: false, z: false);

		public static Vector3State True => new Vector3State(x: true, y: true, z: true);

		public Vector3State(bool x, bool y, bool z)
		{
			xState = x;
			yState = y;
			zState = z;
		}
	}
}
