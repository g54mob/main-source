using UnityEngine;

namespace FuryStudios.BuildSystem
{
	public class ConditionalFieldAttribute : PropertyAttribute
	{
		public readonly string referenceField;

		public readonly object value;

		public readonly bool invert;

		public ConditionalFieldAttribute(string referenceField, object value, bool invert = false)
		{
		}
	}
}
