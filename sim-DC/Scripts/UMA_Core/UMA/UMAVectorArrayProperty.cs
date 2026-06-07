using System;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class UMAVectorArrayProperty : UMAProperty
	{
		public Vector4[] Value;

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
