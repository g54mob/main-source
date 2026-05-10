using System;
using UnityEngine;

namespace PG
{
	[Serializable]
	public struct Layer
	{
		[SerializeField]
		private int value;

		public static implicit operator int(Layer layer)
		{
			return 0;
		}
	}
}
