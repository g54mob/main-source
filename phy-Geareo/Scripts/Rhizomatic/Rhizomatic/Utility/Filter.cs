using System;
using UnityEngine;

namespace Rhizomatic.Utility
{
	[Serializable]
	public class Filter
	{
		public LayerMask layerMask;

		public string[] tags;
	}
}
