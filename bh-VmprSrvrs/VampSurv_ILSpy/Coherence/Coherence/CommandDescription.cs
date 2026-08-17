using System;
using System.Collections.Generic;

namespace Coherence;

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
		//IL_0029: Expected O, but got I
		CommandName = name;
		MethodName = methodName;
		MethodDeclaringClass = declaringClass;
		IntPtr intPtr = default(IntPtr);
		BindingName = (string)(nint)intPtr;
		string bindingGuid2 = default(string);
		BindingGuid = bindingGuid2;
		string routing2 = default(string);
		Routing = routing2;
		List<CommandParameterInfo> parametersInfo = default(List<CommandParameterInfo>);
		ParametersInfo = parametersInfo;
		string bakeConditional2 = default(string);
		BakeConditional = bakeConditional2;
	}
}
