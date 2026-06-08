using System;
using System.Reflection;
using NUnit.Compatibility;
using NUnit.Framework.Interfaces;

namespace NUnit.Framework.Internal.Builders
{
	public class NUnitTestFixtureBuilder
	{
		private static readonly string NO_TYPE_ARGS_MSG = "Fixture type contains generic parameters. You must either provide Type arguments or specify constructor arguments that allow NUnit to deduce the Type arguments.";

		private ITestCaseBuilder _testBuilder = new DefaultTestCaseBuilder();

		public TestSuite BuildFrom(ITypeInfo typeInfo)
		{
			TestFixture testFixture = new TestFixture(typeInfo);
			if (testFixture.RunState != RunState.NotRunnable)
			{
				CheckTestFixtureIsValid(testFixture);
			}
			testFixture.ApplyAttributesToTest(NUnit.Compatibility.TypeExtensions.GetTypeInfo(typeInfo.Type));
			AddTestCasesToFixture(testFixture);
			return testFixture;
		}

		public TestSuite BuildFrom(ITypeInfo typeInfo, ITestFixtureData testFixtureData)
		{
			Guard.ArgumentNotNull(testFixtureData, "testFixtureData");
			object[] array = testFixtureData.Arguments;
			if (typeInfo.ContainsGenericParameters)
			{
				Type[] typeArgsOut = testFixtureData.TypeArgs;
				if (typeArgsOut.Length == 0)
				{
					int num = 0;
					object[] array2 = array;
					for (int i = 0; i < array2.Length && array2[i] is Type; i++)
					{
						num++;
					}
					typeArgsOut = new Type[num];
					for (int j = 0; j < num; j++)
					{
						typeArgsOut[j] = (Type)array[j];
					}
					if (num > 0)
					{
						object[] array3 = new object[array.Length - num];
						for (int k = 0; k < array3.Length; k++)
						{
							array3[k] = array[num + k];
						}
						array = array3;
					}
				}
				if (typeArgsOut.Length != 0 || TypeHelper.CanDeduceTypeArgsFromArgs(typeInfo.Type, array, ref typeArgsOut))
				{
					typeInfo = typeInfo.MakeGenericType(typeArgsOut);
				}
			}
			TestFixture testFixture = new TestFixture(typeInfo);
			if (array != null && array.Length != 0)
			{
				string text = (testFixture.Name = typeInfo.GetDisplayName(array));
				string text2 = text;
				string text3 = typeInfo.Namespace;
				testFixture.FullName = ((text3 != null && text3 != "") ? (text3 + "." + text2) : text2);
				testFixture.Arguments = array;
			}
			if (testFixture.RunState != RunState.NotRunnable)
			{
				testFixture.RunState = testFixtureData.RunState;
			}
			foreach (string key in testFixtureData.Properties.Keys)
			{
				foreach (object item in testFixtureData.Properties[key])
				{
					testFixture.Properties.Add(key, item);
				}
			}
			if (testFixture.RunState != RunState.NotRunnable)
			{
				CheckTestFixtureIsValid(testFixture);
			}
			testFixture.ApplyAttributesToTest(NUnit.Compatibility.TypeExtensions.GetTypeInfo(typeInfo.Type));
			AddTestCasesToFixture(testFixture);
			return testFixture;
		}

		private void AddTestCasesToFixture(TestFixture fixture)
		{
			if (fixture.TypeInfo.ContainsGenericParameters)
			{
				fixture.RunState = RunState.NotRunnable;
				fixture.Properties.Set("_SKIPREASON", NO_TYPE_ARGS_MSG);
				return;
			}
			IMethodInfo[] methods = fixture.TypeInfo.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (IMethodInfo method in methods)
			{
				Test test = BuildTestCase(method, fixture);
				if (test != null)
				{
					fixture.Add(test);
				}
			}
		}

		private Test BuildTestCase(IMethodInfo method, TestSuite suite)
		{
			if (!_testBuilder.CanBuildFrom(method, suite))
			{
				return null;
			}
			return _testBuilder.BuildFrom(method, suite);
		}

		private static void CheckTestFixtureIsValid(TestFixture fixture)
		{
			if (fixture.TypeInfo.ContainsGenericParameters)
			{
				fixture.RunState = RunState.NotRunnable;
				fixture.Properties.Set("_SKIPREASON", NO_TYPE_ARGS_MSG);
			}
			else if (!fixture.TypeInfo.IsStaticClass)
			{
				Type[] typeArray = Reflect.GetTypeArray(fixture.Arguments);
				if (!fixture.TypeInfo.HasConstructor(typeArray))
				{
					fixture.RunState = RunState.NotRunnable;
					fixture.Properties.Set("_SKIPREASON", "No suitable constructor was found");
				}
			}
		}

		private static bool IsStaticClass(Type type)
		{
			if (NUnit.Compatibility.TypeExtensions.GetTypeInfo(type).IsAbstract)
			{
				return NUnit.Compatibility.TypeExtensions.GetTypeInfo(type).IsSealed;
			}
			return false;
		}
	}
}
