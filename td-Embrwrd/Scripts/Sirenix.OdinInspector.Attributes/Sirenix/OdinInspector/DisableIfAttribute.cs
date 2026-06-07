using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	public sealed class DisableIfAttribute : Attribute
	{
		public string Condition;

		public object Value;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use the Condition member instead.", false)]
		public string MemberName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DisableIfAttribute(string condition)
		{
		}

		public DisableIfAttribute(string condition, object optionalValue)
		{
		}
	}
}
