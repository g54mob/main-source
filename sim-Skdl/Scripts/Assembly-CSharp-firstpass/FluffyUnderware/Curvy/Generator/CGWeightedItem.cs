using System;
using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator
{
	[Serializable]
	public class CGWeightedItem
	{
		[SerializeField]
		[RangeEx(0f, 1f, null, null, Slider = true, Precision = 1)]
		private float m_Weight;

		public float Weight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}
	}
}
