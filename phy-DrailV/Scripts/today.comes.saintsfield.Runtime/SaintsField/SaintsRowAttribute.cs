using System;
using System.Diagnostics;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	public class SaintsRowAttribute : PropertyAttribute
	{
		public readonly bool Inline;

		public SaintsRowAttribute()
			: this(inline: false)
		{
		}

		public SaintsRowAttribute(bool inline)
		{
			Inline = inline;
		}

		[Obsolete]
		public SaintsRowAttribute(bool inline, bool tryFixUIToolkit)
			: this(inline)
		{
		}
	}
}
