using System;
using System.Reflection;

namespace Sirenix.OdinInspector
{
	public class OdinDesignerBindingAttribute : Attribute
	{
		public string[] MemberNames;

		public OdinDesignerBindingAttribute(params string[] memberNames)
		{
		}

		public MemberInfo GetBindingMemberInfo(Type type, int index)
		{
			return null;
		}
	}
}
