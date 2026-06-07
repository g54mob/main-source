using System;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	public sealed class OnInspectorGUIAttribute : ShowInInspectorAttribute
	{
		public string Prepend;

		public string Append;

		[Obsolete]
		public string PrependMethodName;

		[Obsolete]
		public string AppendMethodName;

		public OnInspectorGUIAttribute()
		{
		}

		public OnInspectorGUIAttribute(string action, bool append = true)
		{
		}

		public OnInspectorGUIAttribute(string prepend, string append)
		{
		}
	}
}
