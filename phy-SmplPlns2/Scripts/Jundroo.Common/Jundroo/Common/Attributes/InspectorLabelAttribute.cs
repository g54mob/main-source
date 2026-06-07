using UnityEngine;

namespace Jundroo.Common.Attributes
{
	public class InspectorLabelAttribute : PropertyAttribute
	{
		public string Label { get; set; }

		public InspectorLabelAttribute(string label)
		{
			Label = label;
		}
	}
}
