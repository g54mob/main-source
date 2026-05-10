using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[Conditional("UNITY_EDITOR")]
	public class ShowIfGroupAttribute : PropertyGroupAttribute
	{
		public object Value;

		public bool Animate
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

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

		public string Condition
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ShowIfGroupAttribute(string path, bool animate = true)
			: base(null, 0f)
		{
		}

		public ShowIfGroupAttribute(string path, object value, bool animate = true)
			: base(null, 0f)
		{
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
		}
	}
}
