using System;
using System.Collections.Generic;

namespace Dorfromantik
{
	[Serializable]
	public class FloatOption
	{
		public string propertyName;

		public float value;

		public List<int> rendererIndices = new List<int> { 0 };
	}
}
