using System.Reflection;

namespace FluentAssertions.Formatting
{
	public class MethodInfoFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is MethodInfo;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			MethodInfo methodInfo = (MethodInfo)value;
			if (methodInfo.IsSpecialName && methodInfo.Name == "op_Implicit")
			{
				formattedGraph.AddFragment("implicit operator " + methodInfo.ReturnType.Name + "(" + methodInfo.GetParameters()[0].ParameterType.Name + ")");
			}
			else if (methodInfo.IsSpecialName && methodInfo.Name == "op_Explicit")
			{
				formattedGraph.AddFragment("explicit operator " + methodInfo.ReturnType.Name + "(" + methodInfo.GetParameters()[0].ParameterType.Name + ")");
			}
			else
			{
				formattedGraph.AddFragment(methodInfo.DeclaringType.Name + "." + methodInfo.Name);
			}
		}
	}
}
