using UnityEngine;

namespace MyBox
{
	public class OverrideLabelAttribute : PropertyAttribute
	{
		public readonly string NewLabel;

		public OverrideLabelAttribute(string newLabel)
		{
		}
	}
}
