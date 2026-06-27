using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;

namespace FluentAssertions.Execution
{
	internal abstract class LateBoundTestFramework : ITestFramework
	{
		private readonly bool loadAssembly;

		private Func<string, Exception> exceptionFactory;

		public bool IsAvailable
		{
			get
			{
				Type exceptionType = FindExceptionAssembly()?.GetType(ExceptionFullName);
				exceptionFactory = ((exceptionType != null) ? ((Func<string, Exception>)((string message) => (Exception)Activator.CreateInstance(exceptionType, message))) : ((Func<string, Exception>)delegate
				{
					throw new InvalidOperationException(GetType().Name + " is not available");
				}));
				return (object)exceptionType != null;
			}
		}

		protected internal abstract string AssemblyName { get; }

		protected abstract string ExceptionFullName { get; }

		protected LateBoundTestFramework(bool loadAssembly = false)
		{
			this.loadAssembly = loadAssembly;
			exceptionFactory = delegate
			{
				throw new InvalidOperationException("IsAvailable must be called first.");
			};
		}

		[DoesNotReturn]
		public void Throw(string message)
		{
			throw exceptionFactory(message);
		}

		private Assembly FindExceptionAssembly()
		{
			Assembly assembly = Array.Find(AppDomain.CurrentDomain.GetAssemblies(), (Assembly a) => a.GetName().Name == AssemblyName);
			if ((object)assembly == null && loadAssembly)
			{
				try
				{
					return Assembly.Load(new AssemblyName(AssemblyName));
				}
				catch (FileNotFoundException)
				{
					return null;
				}
				catch (FileLoadException)
				{
					return null;
				}
			}
			return assembly;
		}
	}
}
