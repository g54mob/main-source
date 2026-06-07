using System;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	[HideInTables]
	[IncludeMyAttributes]
	public sealed class OnStateUpdateAttribute : Attribute
	{
		public string Action;

		public OnStateUpdateAttribute(string action)
		{
		}
	}
}
