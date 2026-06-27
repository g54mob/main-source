using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NSubstitute.Core.Arguments;

namespace NSubstitute.Core
{
	public class CallSpecification : ICallSpecification
	{
		private readonly IArgumentSpecification[] _argumentSpecifications;

		public CallSpecification(MethodInfo methodInfo, IEnumerable<IArgumentSpecification> argumentSpecifications)
		{
			_003CmethodInfo_003EP = methodInfo;
			_argumentSpecifications = argumentSpecifications.ToArray();
			base._002Ector();
		}

		public MethodInfo GetMethodInfo()
		{
			return _003CmethodInfo_003EP;
		}

		public Type ReturnType()
		{
			return _003CmethodInfo_003EP.ReturnType;
		}

		public bool IsSatisfiedBy(ICall call)
		{
			if (!AreComparable(GetMethodInfo(), call.GetMethodInfo()))
			{
				return false;
			}
			if (HasDifferentNumberOfArguments(call))
			{
				return false;
			}
			if (!IsMatchingArgumentSpecifications(call))
			{
				return false;
			}
			return true;
		}

		private static bool AreComparable(MethodInfo a, MethodInfo b)
		{
			if (a == b)
			{
				return true;
			}
			if (a.IsGenericMethod && b.IsGenericMethod)
			{
				return CanCompareGenericMethods(a, b);
			}
			return false;
		}

		private static bool CanCompareGenericMethods(MethodInfo a, MethodInfo b)
		{
			if (AreEquivalentDefinitions(a, b) && TypesAreAllEquivalent(ParameterTypes(a), ParameterTypes(b)))
			{
				return TypesAreAllEquivalent(a.GetGenericArguments(), b.GetGenericArguments());
			}
			return false;
		}

		private static Type[] ParameterTypes(MethodInfo info)
		{
			return (from p in info.GetParameters()
				select p.ParameterType).ToArray();
		}

		internal static bool TypesAreAllEquivalent(Type[] aArgs, Type[] bArgs)
		{
			if (aArgs.Length != bArgs.Length)
			{
				return false;
			}
			for (int i = 0; i < aArgs.Length; i++)
			{
				Type type = aArgs[i];
				Type type2 = bArgs[i];
				if (type.IsGenericType && type2.IsGenericType && type.GetGenericTypeDefinition() == type2.GetGenericTypeDefinition())
				{
					if (!TypesAreAllEquivalent(type.GenericTypeArguments, type2.GenericTypeArguments))
					{
						return false;
					}
					continue;
				}
				bool num = type.IsAssignableFrom(type2) || type2.IsAssignableFrom(type);
				bool flag = typeof(Arg.AnyType).IsAssignableFrom(type) || typeof(Arg.AnyType).IsAssignableFrom(type2);
				bool flag2 = type.IsByRef && type2.IsByRef && (typeof(Arg.AnyType).IsAssignableFrom(type.GetElementType()) || typeof(Arg.AnyType).IsAssignableFrom(type2.GetElementType()));
				if (!(num || flag || flag2))
				{
					return false;
				}
			}
			return true;
		}

		private static bool AreEquivalentDefinitions(MethodInfo a, MethodInfo b)
		{
			if (a.IsGenericMethod == b.IsGenericMethod && a.ReturnType == b.ReturnType)
			{
				return a.Name.Equals(b.Name, StringComparison.Ordinal);
			}
			return false;
		}

		private bool IsMatchingArgumentSpecifications(ICall call)
		{
			object[] originalArguments = call.GetOriginalArguments();
			for (int i = 0; i < originalArguments.Length; i++)
			{
				if (!_argumentSpecifications[i].IsSatisfiedBy(originalArguments[i]))
				{
					return false;
				}
			}
			return true;
		}

		public IEnumerable<ArgumentMatchInfo> NonMatchingArguments(ICall call)
		{
			return from x in call.GetOriginalArguments().Select((object arg, int index) => new ArgumentMatchInfo(index, arg, _argumentSpecifications[index]))
				where !x.IsMatch
				select x;
		}

		public override string ToString()
		{
			string[] formattedArguments = _argumentSpecifications.Select((IArgumentSpecification x) => x.ToString() ?? string.Empty).ToArray();
			return CallFormatter.Default.Format(GetMethodInfo(), formattedArguments);
		}

		public string Format(ICall call)
		{
			return CallFormatter.Default.Format(call.GetMethodInfo(), FormatArguments(call.GetOriginalArguments()));
		}

		private IEnumerable<string> FormatArguments(IEnumerable<object?> arguments)
		{
			return arguments.Zip(_argumentSpecifications, (object arg, IArgumentSpecification spec) => spec.FormatArgument(arg)).ToArray();
		}

		public ICallSpecification CreateCopyThatMatchesAnyArguments()
		{
			IArgumentSpecification[] argumentSpecifications = GetMethodInfo().GetParameters().Zip(_argumentSpecifications, (ParameterInfo p, IArgumentSpecification spec) => spec.CreateCopyMatchingAnyArgOfType(p.ParameterType)).ToArray();
			return new CallSpecification(GetMethodInfo(), argumentSpecifications);
		}

		public void InvokePerArgumentActions(CallInfo callInfo)
		{
			object[] array = callInfo.Args();
			IArgumentSpecification[] argumentSpecifications = _argumentSpecifications;
			for (int i = 0; i < array.Length; i++)
			{
				argumentSpecifications[i].RunAction(array[i]);
			}
		}

		private bool HasDifferentNumberOfArguments(ICall call)
		{
			return _argumentSpecifications.Length != call.GetOriginalArguments().Length;
		}
	}
}
