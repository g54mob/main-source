using System;

namespace Sirenix.OdinInspector
{
	public class HideIfGroupAttribute : PropertyGroupAttribute
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

		[Obsolete]
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

		public HideIfGroupAttribute(string path, bool animate = true)
			: base(null, 0f)
		{
		}

		public HideIfGroupAttribute(string path, object value, bool animate = true)
			: base(null, 0f)
		{
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
		}
	}
}
