using System;

namespace Assets.Scripts.Design.PartProperties.Attributes
{
	[AttributeUsage(AttributeTargets.Field)]
	public class PartModifierPropertyAttribute : Attribute
	{
		public bool PreserveState { get; set; }

		public PartModifierPropertyAttribute(bool preserveState)
		{
			PreserveState = preserveState;
		}
	}
}
