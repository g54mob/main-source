using UnityEngine;

namespace Aura2API
{
	public class ColorCircularPickerAttribute : PropertyAttribute
	{
		public readonly bool showLabel;

		public ColorCircularPickerAttribute(bool showLabel = false)
		{
			this.showLabel = showLabel;
		}
	}
}
