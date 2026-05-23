using System;
using UnityEngine;

namespace Kinemation.Recoilly.Runtime
{
	[Serializable]
	public struct VectorSpringData
	{
		public SpringData x;

		public SpringData y;

		public SpringData z;

		public Vector3 scale;
	}
}
