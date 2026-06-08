using System;
using System.Dynamic;
using System.Runtime.CompilerServices;
using HandlebarsDotNet.PathStructure;
using Microsoft.CSharp.RuntimeBinder;

namespace HandlebarsDotNet.MemberAccessors
{
	public sealed class DynamicMemberAccessor : IMemberAccessor
	{
		public bool TryGetValue(object instance, ChainSegment memberName, out object value)
		{
			value = null;
			IDynamicMetaObjectProvider target = (IDynamicMetaObjectProvider)instance;
			try
			{
				value = GetProperty(target, memberName.TrimmedValue);
				return value != null;
			}
			catch
			{
				return false;
			}
		}

		private static object GetProperty(object target, string name)
		{
			CallSite<Func<CallSite, object, object>> callSite = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, name, target.GetType(), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			return callSite.Target(callSite, target);
		}
	}
}
