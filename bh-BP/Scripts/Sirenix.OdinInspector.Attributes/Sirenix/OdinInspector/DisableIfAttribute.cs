using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class DisableIfAttribute : Attribute
	{
		public string Condition;

		public object Value;

		[Obsolete("Use the Condition member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
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
