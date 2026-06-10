using System;
using UnityEngine.Events;

namespace STMTools.Links
{
	[Serializable]
	public class Link
	{
		public string label = string.Empty;

		public UnityEvent onClick;
	}
}
