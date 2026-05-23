using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class FoldoutGroupAttribute : PropertyGroupAttribute
	{
		private bool expanded;

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "expanded", "HasDefinedExpanded" })]
		public bool Expanded
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool HasDefinedExpanded { get; private set; }

		public FoldoutGroupAttribute(string groupName, float order = 0f)
			: base(null, 0f)
		{
		}

		public FoldoutGroupAttribute(string groupName, bool expanded, float order = 0f)
			: base(null, 0f)
		{
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
		}
	}
}
