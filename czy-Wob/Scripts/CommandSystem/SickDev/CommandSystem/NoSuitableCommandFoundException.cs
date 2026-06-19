using System.Reflection;

namespace SickDev.CommandSystem
{
	public class NoSuitableCommandFoundException : CommandSystemException
	{
		private MethodInfo method;

		public override string Message => "No suitable command found for method " + method.DeclaringType.Name + "." + method.Name + ". Please, review the docs on how to create new Command types";

		public NoSuitableCommandFoundException(MethodInfo method)
		{
			this.method = method;
		}
	}
}
