using System;
using System.Collections.Generic;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace NUnit.Framework
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public class SetUpFixtureAttribute : NUnitAttribute, IFixtureBuilder
	{
		public IEnumerable<TestSuite> BuildFrom(ITypeInfo typeInfo)
		{
			SetUpFixture setUpFixture = new SetUpFixture(typeInfo);
			if (setUpFixture.RunState != RunState.NotRunnable)
			{
				string reason = null;
				if (!IsValidFixtureType(typeInfo, ref reason))
				{
					setUpFixture.RunState = RunState.NotRunnable;
					setUpFixture.Properties.Set("_SKIPREASON", reason);
				}
			}
			return new TestSuite[1] { setUpFixture };
		}

		private bool IsValidFixtureType(ITypeInfo typeInfo, ref string reason)
		{
			if (typeInfo.IsAbstract)
			{
				reason = $"{typeInfo.FullName} is an abstract class";
				return false;
			}
			if (!typeInfo.HasConstructor(new Type[0]))
			{
				reason = $"{typeInfo.FullName} does not have a default constructor";
				return false;
			}
			Type[] array = new Type[4]
			{
				typeof(SetUpAttribute),
				typeof(TearDownAttribute),
				typeof(TestFixtureSetUpAttribute),
				typeof(TestFixtureTearDownAttribute)
			};
			foreach (Type type in array)
			{
				if (typeInfo.HasMethodWithAttribute(type))
				{
					reason = type.Name + " attribute not allowed in a SetUpFixture";
					return false;
				}
			}
			return true;
		}
	}
}
