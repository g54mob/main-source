using UnityEngine;

namespace Subdiv.Demo
{
	internal struct MVertex_t
	{
		private Vector3 position;

		private Vector3 normal;

		public MVertex_t(Vector3 p, Vector3 n)
		{
			position = p;
			normal = n;
		}
	}
}
