using System;
using NSubstitute.Core;

namespace NSubstitute
{
	public static class Substitute
	{
		public static T For<T>(params object[] constructorArguments) where T : class
		{
			return (T)For(new Type[1] { typeof(T) }, constructorArguments);
		}

		public static T1 For<T1, T2>(params object[] constructorArguments) where T1 : class where T2 : class
		{
			return (T1)For(new Type[2]
			{
				typeof(T1),
				typeof(T2)
			}, constructorArguments);
		}

		public static T1 For<T1, T2, T3>(params object[] constructorArguments) where T1 : class where T2 : class where T3 : class
		{
			return (T1)For(new Type[3]
			{
				typeof(T1),
				typeof(T2),
				typeof(T3)
			}, constructorArguments);
		}

		public static object For(Type[] typesToProxy, object[] constructorArguments)
		{
			return SubstitutionContext.Current.SubstituteFactory.Create(typesToProxy, constructorArguments);
		}

		public static T ForPartsOf<T>(params object[] constructorArguments) where T : class
		{
			return (T)SubstitutionContext.Current.SubstituteFactory.CreatePartial(new Type[1] { typeof(T) }, constructorArguments);
		}
	}
}
