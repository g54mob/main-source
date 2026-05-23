using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Namotion.Reflection
{
	public class ContextualMethodInfo : ContextualMemberInfo
	{
		public MethodInfo MethodInfo { get; }

		public override string Name => MethodInfo.Name;

		public ContextualParameterInfo[] Parameters { get; }

		public ContextualParameterInfo ReturnParameter { get; }

		public override MemberInfo MemberInfo => MethodInfo;

		internal ContextualMethodInfo(MethodInfo methodInfo, ContextualParameterInfo returnParameter, IEnumerable<ContextualParameterInfo> parameters)
		{
			MethodInfo = methodInfo;
			ReturnParameter = returnParameter;
			Parameters = parameters.ToArray();
		}

		public override string ToString()
		{
			return Name + " (" + GetType().Name.Replace("Contextual", "").Replace("Info", "") + ") - " + base.ToString();
		}
	}
}
