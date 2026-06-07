using UnityEngine;

namespace Coherence.Toolkit
{
	public class ReadOnlyAttribute : PropertyAttribute
	{
		public bool IncludeChildren { get; set; }

		public ReadOnlyAttribute(bool includeChildren)
		{
		}
	}
}
