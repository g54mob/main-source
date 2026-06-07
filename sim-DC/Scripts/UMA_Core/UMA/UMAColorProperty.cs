using System;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class UMAColorProperty : UMAProperty
	{
		public Color Value;

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
