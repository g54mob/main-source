#define TRACE
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using FluentAssertions.Configuration;
using FluentAssertions.Execution;
using FluentAssertions.Extensibility;

namespace FluentAssertions
{
	public static class AssertionEngine
	{
		private static readonly object Lockable;

		private static ITestFramework testFramework;

		private static bool isInitialized;

		public static ITestFramework TestFramework
		{
			get
			{
				if (testFramework != null)
				{
					return testFramework;
				}
				lock (Lockable)
				{
					if (testFramework == null)
					{
						testFramework = TestFrameworkFactory.GetFramework(Configuration.TestFramework);
					}
				}
				return testFramework;
			}
			set
			{
				testFramework = value;
			}
		}

		public static GlobalConfiguration Configuration { get; private set; }

		static AssertionEngine()
		{
			Lockable = new object();
			Configuration = new GlobalConfiguration();
			EnsureInitialized();
		}

		public static void ResetToDefaults()
		{
			isInitialized = false;
			Configuration = new GlobalConfiguration();
			testFramework = null;
			EnsureInitialized();
		}

		internal static void EnsureInitialized()
		{
			if (isInitialized)
			{
				return;
			}
			lock (Lockable)
			{
				if (!isInitialized)
				{
					ExecuteCustomInitializers();
					if (!License.Accepted)
					{
						Console.WriteLine("     Warning:\r\n     The component \"Fluent Assertions\" is governed by the rules defined in the Xceed License Agreement and\r\n     the Xceed Fluent Assertions Community License. You may use Fluent Assertions free of charge for\r\n     non-commercial use only. An active subscription is required to use Fluent Assertions for commercial use.\r\n\r\n     Please contact Xceed Sales mailto:sales@xceed.com to acquire a subscription at a very low cost.\r\n\r\n     A paid commercial license supports the development and continued increasing support of\r\n     Fluent Assertions users under both commercial and community licenses. Help us\r\n     keep Fluent Assertions at the forefront of unit testing.\r\n\r\n     For more information, visit https://xceed.com/products/unit-testing/fluent-assertions/");
						Trace.WriteLine("     Warning:\r\n     The component \"Fluent Assertions\" is governed by the rules defined in the Xceed License Agreement and\r\n     the Xceed Fluent Assertions Community License. You may use Fluent Assertions free of charge for\r\n     non-commercial use only. An active subscription is required to use Fluent Assertions for commercial use.\r\n\r\n     Please contact Xceed Sales mailto:sales@xceed.com to acquire a subscription at a very low cost.\r\n\r\n     A paid commercial license supports the development and continued increasing support of\r\n     Fluent Assertions users under both commercial and community licenses. Help us\r\n     keep Fluent Assertions at the forefront of unit testing.\r\n\r\n     For more information, visit https://xceed.com/products/unit-testing/fluent-assertions/");
					}
					isInitialized = true;
				}
			}
		}

		private static void ExecuteCustomInitializers()
		{
			Assembly currentAssembly = Assembly.GetExecutingAssembly();
			AssemblyName currentAssemblyName = currentAssembly.GetName();
			AssertionEngineInitializerAttribute[] array = Array.Empty<AssertionEngineInitializerAttribute>();
			try
			{
				array = (from a in AppDomain.CurrentDomain.GetAssemblies()
					where a != currentAssembly && !a.IsDynamic && !IsFramework(a)
					where a.GetReferencedAssemblies().Any((AssemblyName r) => r.FullName == currentAssemblyName.FullName)
					select a).SelectMany((Assembly a) => a.GetCustomAttributes<AssertionEngineInitializerAttribute>()).ToArray();
			}
			catch
			{
			}
			AssertionEngineInitializerAttribute[] array2 = array;
			foreach (AssertionEngineInitializerAttribute assertionEngineInitializerAttribute in array2)
			{
				try
				{
					assertionEngineInitializerAttribute.Initialize();
				}
				catch
				{
				}
			}
		}

		private static bool IsFramework(Assembly assembly)
		{
			if (!assembly.FullName.StartsWith("Microsoft.", StringComparison.OrdinalIgnoreCase))
			{
				return assembly.FullName.StartsWith("System.", StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}
	}
}
