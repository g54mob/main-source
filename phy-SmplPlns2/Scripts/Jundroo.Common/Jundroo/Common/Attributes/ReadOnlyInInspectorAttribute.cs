using UnityEngine;

namespace Jundroo.Common.Attributes
{
	public class ReadOnlyInInspectorAttribute : PropertyAttribute
	{
		public string Label { get; set; }

		public ReadOnlyInInspectorAttribute()
		{
		}

		public ReadOnlyInInspectorAttribute(string label)
		{
			Label = label;
		}
	}
}
