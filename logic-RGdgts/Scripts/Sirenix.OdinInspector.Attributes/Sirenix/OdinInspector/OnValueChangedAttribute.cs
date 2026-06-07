using System;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	public sealed class OnValueChangedAttribute : Attribute
	{
		public string Action;

		public bool IncludeChildren;

		public bool InvokeOnUndoRedo;

		public bool InvokeOnInitialize;

		[Obsolete]
		public string MethodName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public OnValueChangedAttribute(string action, bool includeChildren = false)
		{
		}
	}
}
