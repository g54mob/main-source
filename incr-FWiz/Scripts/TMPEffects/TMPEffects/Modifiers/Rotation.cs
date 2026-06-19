using System;
using UnityEngine;

namespace TMPEffects.Modifiers
{
	[Serializable]
	public struct Rotation
	{
		public Vector3 pivot;

		public Vector3 eulerAngles;

		public Rotation(Vector3 eulerAngles, Vector3 pivot)
		{
			this.pivot = default(Vector3);
			this.eulerAngles = default(Vector3);
		}

		public bool Equals(Rotation other)
		{
			return false;
		}
	}
}
