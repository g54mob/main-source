using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using NSubstitute.Core.Arguments;
using NSubstitute.Exceptions;

namespace NSubstitute.Core
{
	public class PropertyHelper : IPropertyHelper
	{
		private readonly ICallFactory _callFactory;

		private readonly IArgumentSpecificationCompatibilityTester _argSpecCompatTester;

		public PropertyHelper(ICallFactory callFactory, IArgumentSpecificationCompatibilityTester argSpecCompatTester)
		{
			_callFactory = callFactory;
			_argSpecCompatTester = argSpecCompatTester;
		}

		public bool IsCallToSetAReadWriteProperty(ICall call)
		{
			PropertyInfo propertyFromSetterCall = GetPropertyFromSetterCall(call);
			return PropertySetterExistsAndHasAGetMethod(propertyFromSetterCall);
		}

		private bool PropertySetterExistsAndHasAGetMethod([NotNullWhen(true)] PropertyInfo? propertySetter)
		{
			if (propertySetter != null)
			{
				return propertySetter.GetGetMethod(nonPublic: true) != null;
			}
			return false;
		}

		private PropertyInfo? GetPropertyFromSetterCall(ICall call)
		{
			return call.GetMethodInfo().GetPropertyFromSetterCallOrNull();
		}

		public ICall CreateCallToPropertyGetterFromSetterCall(ICall callToSetter)
		{
			PropertyInfo propertyFromSetterCall = GetPropertyFromSetterCall(callToSetter);
			if (!PropertySetterExistsAndHasAGetMethod(propertyFromSetterCall))
			{
				throw new InvalidOperationException("Could not find a GetMethod for \"" + callToSetter.GetMethodInfo()?.ToString() + "\"");
			}
			MethodInfo getMethod = propertyFromSetterCall.GetGetMethod(nonPublic: true);
			if ((object)getMethod == null)
			{
				throw new SubstituteInternalException("A property with a getter expected.");
			}
			object[] getterArgs = SkipLast(callToSetter.GetOriginalArguments());
			IList<IArgumentSpecification> getterCallSpecificationsFromSetterCall = GetGetterCallSpecificationsFromSetterCall(callToSetter);
			return _callFactory.Create(getMethod, getterArgs, callToSetter.Target(), getterCallSpecificationsFromSetterCall);
		}

		private IList<IArgumentSpecification> GetGetterCallSpecificationsFromSetterCall(ICall callToSetter)
		{
			object argumentValue = callToSetter.GetOriginalArguments().Last();
			Type parameterType = callToSetter.GetParameterInfos().Last().ParameterType;
			IList<IArgumentSpecification> list = callToSetter.GetArgumentSpecifications();
			if (list.Count == 0)
			{
				return list;
			}
			if (_argSpecCompatTester.IsSpecificationCompatible(list.Last(), argumentValue, parameterType))
			{
				list = SkipLast(list);
			}
			return list;
		}

		private static T[] SkipLast<T>(ICollection<T> collection)
		{
			return collection.Take(collection.Count - 1).ToArray();
		}
	}
}
