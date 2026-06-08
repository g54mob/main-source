using UnityEngine;

namespace GRP
{
	public struct Tetrahedron
	{
		public Vector3 A;

		public Vector3 B;

		public Vector3 C;

		public Vector3 D;

		public Tetrahedron(Vector3 A, Vector3 B, Vector3 C, Vector3 D)
		{
			this.A = default(Vector3);
			this.B = default(Vector3);
			this.C = default(Vector3);
			this.D = default(Vector3);
		}
	}
}
