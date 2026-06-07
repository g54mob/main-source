using System;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class UMAVectorProperty : UMAProperty
	{
		public Vector4 Value;

		public void SetValue(Vector4 vector)
		{
		}

		public void SetValue(Vector3 vector)
		{
		}

		public void SetValue(Vector2 vector)
		{
		}

		public override void Apply(Material mpb, int overlayNumber = -1)
		{
		}

		public override UMAProperty Clone()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
