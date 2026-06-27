using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions.Common;

namespace FluentAssertions.Types
{
	public class MethodInfoSelector : IEnumerable<MethodInfo>, IEnumerable
	{
		private IEnumerable<MethodInfo> selectedMethods;

		public MethodInfoSelector ThatArePublicOrInternal
		{
			get
			{
				selectedMethods = selectedMethods.Where((MethodInfo method) => method.IsPublic || method.IsAssembly);
				return this;
			}
		}

		public MethodInfoSelector ThatReturnVoid
		{
			get
			{
				selectedMethods = selectedMethods.Where((MethodInfo method) => method.ReturnType == typeof(void));
				return this;
			}
		}

		public MethodInfoSelector ThatDoNotReturnVoid
		{
			get
			{
				selectedMethods = selectedMethods.Where((MethodInfo method) => method.ReturnType != typeof(void));
				return this;
			}
		}

		public MethodInfoSelector(Type type)
			: this(new _003C_003Ez__ReadOnlySingleElementList<Type>(type))
		{
		}

		public MethodInfoSelector(IEnumerable<Type> types)
		{
			Guard.ThrowIfArgumentIsNull(types, "types");
			Guard.ThrowIfArgumentContainsNull(types, "types");
			selectedMethods = types.SelectMany((Type t) => from method in t.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
				where !HasSpecialName(method)
				select method);
		}

		public MethodInfoSelector ThatReturn<TReturn>()
		{
			selectedMethods = selectedMethods.Where((MethodInfo method) => method.ReturnType == typeof(TReturn));
			return this;
		}

		public MethodInfoSelector ThatDoNotReturn<TReturn>()
		{
			selectedMethods = selectedMethods.Where((MethodInfo method) => method.ReturnType != typeof(TReturn));
			return this;
		}

		public MethodInfoSelector ThatAreDecoratedWith<TAttribute>() where TAttribute : Attribute
		{
			selectedMethods = selectedMethods.Where((MethodInfo method) => method.IsDecoratedWith<TAttribute>());
			return this;
		}

		public MethodInfoSelector ThatAreDecoratedWithOrInherit<TAttribute>() where TAttribute : Attribute
		{
			selectedMethods = selectedMethods.Where((MethodInfo method) => method.IsDecoratedWithOrInherit<TAttribute>());
			return this;
		}

		public MethodInfoSelector ThatAreNotDecoratedWith<TAttribute>() where TAttribute : Attribute
		{
			selectedMethods = selectedMethods.Where((MethodInfo method) => !method.IsDecoratedWith<TAttribute>());
			return this;
		}

		public MethodInfoSelector ThatAreNotDecoratedWithOrInherit<TAttribute>() where TAttribute : Attribute
		{
			selectedMethods = selectedMethods.Where((MethodInfo method) => !method.IsDecoratedWithOrInherit<TAttribute>());
			return this;
		}

		public MethodInfoSelector ThatAreAbstract()
		{
			selectedMethods = selectedMethods.Where((MethodInfo method) => method.IsAbstract);
			return this;
		}

		public MethodInfoSelector ThatAreNotAbstract()
		{
			selectedMethods = selectedMethods.Where((MethodInfo method) => !method.IsAbstract);
			return this;
		}

		public MethodInfoSelector ThatAreAsync()
		{
			selectedMethods = selectedMethods.Where((MethodInfo method) => method.IsAsync());
			return this;
		}

		public MethodInfoSelector ThatAreNotAsync()
		{
			selectedMethods = selectedMethods.Where((MethodInfo method) => !method.IsAsync());
			return this;
		}

		public MethodInfoSelector ThatAreStatic()
		{
			selectedMethods = selectedMethods.Where((MethodInfo method) => method.IsStatic);
			return this;
		}

		public MethodInfoSelector ThatAreNotStatic()
		{
			selectedMethods = selectedMethods.Where((MethodInfo method) => !method.IsStatic);
			return this;
		}

		public MethodInfoSelector ThatAreVirtual()
		{
			selectedMethods = selectedMethods.Where((MethodInfo method) => !method.IsNonVirtual());
			return this;
		}

		public MethodInfoSelector ThatAreNotVirtual()
		{
			selectedMethods = selectedMethods.Where((MethodInfo method) => method.IsNonVirtual());
			return this;
		}

		public TypeSelector ReturnTypes()
		{
			return new TypeSelector(selectedMethods.Select((MethodInfo mi) => mi.ReturnType));
		}

		public MethodInfo[] ToArray()
		{
			return selectedMethods.ToArray();
		}

		private static bool HasSpecialName(MethodInfo method)
		{
			return (method.Attributes & MethodAttributes.SpecialName) == MethodAttributes.SpecialName;
		}

		public IEnumerator<MethodInfo> GetEnumerator()
		{
			return selectedMethods.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
