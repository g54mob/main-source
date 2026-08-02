using System;
using MoonSharp.Interpreter.Interop.RegistrationPolicies;

namespace MoonSharp.Interpreter.Interop
{
	public static class InteropRegistrationPolicy
	{
		public static IRegistrationPolicy Default => null;

		[Obsolete("Please use InteropRegistrationPolicy.Default instead.")]
		public static IRegistrationPolicy Explicit => null;

		public static IRegistrationPolicy Automatic => null;
	}
}
