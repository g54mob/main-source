using System;

namespace MoonSharp.Interpreter.Interop.RegistrationPolicies
{
	public class DefaultRegistrationPolicy : IRegistrationPolicy
	{
		public IUserDataDescriptor HandleRegistration(IUserDataDescriptor newDescriptor, IUserDataDescriptor oldDescriptor)
		{
			return null;
		}

		public virtual bool AllowTypeAutoRegistration(Type type)
		{
			return false;
		}
	}
}
