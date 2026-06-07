using System.Collections.Generic;

namespace Coherence
{
	public class CommandDescription
	{
		public string CommandName;

		public string MethodName;

		public string MethodDeclaringClass;

		public string BindingName;

		public string BindingGuid;

		public string Routing;

		public List<CommandParameterInfo> ParametersInfo;

		public string BakeConditional;

		public CommandDescription(string name, string methodName, string declaringClass, string bindingName, string bindingGuid, string routing, List<CommandParameterInfo> parameters, string bakeConditional)
		{
		}
	}
}
