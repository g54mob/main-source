using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions.Common;

namespace FluentAssertions.Types
{
	public class TypeSelector : IEnumerable<Type>, IEnumerable
	{
		private List<Type> types;

		public TypeSelector(Type type)
			: this(new _003C_003Ez__ReadOnlySingleElementList<Type>(type))
		{
		}

		public TypeSelector(IEnumerable<Type> types)
		{
			Guard.ThrowIfArgumentIsNull(types, "types");
			Guard.ThrowIfArgumentContainsNull(types, "types");
			this.types = types.ToList();
		}

		public Type[] ToArray()
		{
			return types.ToArray();
		}

		public TypeSelector ThatDeriveFrom<TBase>()
		{
			types = types.Where((Type type) => type.IsSubclassOf(typeof(TBase))).ToList();
			return this;
		}

		public TypeSelector ThatDoNotDeriveFrom<TBase>()
		{
			types = types.Where((Type type) => !type.IsSubclassOf(typeof(TBase))).ToList();
			return this;
		}

		public TypeSelector ThatImplement<TInterface>()
		{
			types = types.Where((Type t) => typeof(TInterface).IsAssignableFrom(t) && t != typeof(TInterface)).ToList();
			return this;
		}

		public TypeSelector ThatDoNotImplement<TInterface>()
		{
			types = types.Where((Type t) => !typeof(TInterface).IsAssignableFrom(t) && t != typeof(TInterface)).ToList();
			return this;
		}

		public TypeSelector ThatAreDecoratedWith<TAttribute>() where TAttribute : Attribute
		{
			types = types.Where((Type t) => t.IsDecoratedWith<TAttribute>()).ToList();
			return this;
		}

		public TypeSelector ThatAreDecoratedWithOrInherit<TAttribute>() where TAttribute : Attribute
		{
			types = types.Where((Type t) => t.IsDecoratedWithOrInherit<TAttribute>()).ToList();
			return this;
		}

		public TypeSelector ThatAreNotDecoratedWith<TAttribute>() where TAttribute : Attribute
		{
			types = types.Where((Type t) => !t.IsDecoratedWith<TAttribute>()).ToList();
			return this;
		}

		public TypeSelector ThatAreNotDecoratedWithOrInherit<TAttribute>() where TAttribute : Attribute
		{
			types = types.Where((Type t) => !t.IsDecoratedWithOrInherit<TAttribute>()).ToList();
			return this;
		}

		public TypeSelector ThatAreInNamespace(string @namespace)
		{
			types = types.Where((Type t) => t.Namespace == @namespace).ToList();
			return this;
		}

		public TypeSelector ThatAreNotInNamespace(string @namespace)
		{
			types = types.Where((Type t) => t.Namespace != @namespace).ToList();
			return this;
		}

		public TypeSelector ThatAreUnderNamespace(string @namespace)
		{
			types = types.Where((Type t) => t.IsUnderNamespace(@namespace)).ToList();
			return this;
		}

		public TypeSelector ThatAreNotUnderNamespace(string @namespace)
		{
			types = types.Where((Type t) => !t.IsUnderNamespace(@namespace)).ToList();
			return this;
		}

		public TypeSelector ThatAreValueTypes()
		{
			types = types.Where((Type t) => t.IsValueType).ToList();
			return this;
		}

		public TypeSelector ThatAreNotValueTypes()
		{
			types = types.Where((Type t) => !t.IsValueType).ToList();
			return this;
		}

		public TypeSelector ThatAreClasses()
		{
			types = types.Where((Type t) => t.IsClass).ToList();
			return this;
		}

		public TypeSelector ThatAreNotClasses()
		{
			types = types.Where((Type t) => !t.IsClass).ToList();
			return this;
		}

		public TypeSelector ThatAreAbstract()
		{
			types = types.Where((Type t) => t.IsCSharpAbstract()).ToList();
			return this;
		}

		public TypeSelector ThatAreNotAbstract()
		{
			types = types.Where((Type t) => !t.IsCSharpAbstract()).ToList();
			return this;
		}

		public TypeSelector ThatAreSealed()
		{
			types = types.Where((Type t) => t.IsSealed).ToList();
			return this;
		}

		public TypeSelector ThatAreNotSealed()
		{
			types = types.Where((Type t) => !t.IsSealed).ToList();
			return this;
		}

		public TypeSelector ThatAreInterfaces()
		{
			types = types.Where((Type t) => t.IsInterface).ToList();
			return this;
		}

		public TypeSelector ThatAreNotInterfaces()
		{
			types = types.Where((Type t) => !t.IsInterface).ToList();
			return this;
		}

		public TypeSelector ThatAreStatic()
		{
			types = types.Where((Type t) => t.IsCSharpStatic()).ToList();
			return this;
		}

		public TypeSelector ThatAreNotStatic()
		{
			types = types.Where((Type t) => !t.IsCSharpStatic()).ToList();
			return this;
		}

		public TypeSelector ThatSatisfy(Func<Type, bool> predicate)
		{
			types = types.Where(predicate).ToList();
			return this;
		}

		public TypeSelector UnwrapTaskTypes()
		{
			types = types.ConvertAll(delegate(Type type)
			{
				if (type.IsGenericType)
				{
					Type genericTypeDefinition = type.GetGenericTypeDefinition();
					if (genericTypeDefinition == typeof(Task<>) || genericTypeDefinition == typeof(ValueTask<>))
					{
						return type.GetGenericArguments().Single();
					}
				}
				return (!(type == typeof(Task)) && !(type == typeof(ValueTask))) ? type : typeof(void);
			});
			return this;
		}

		public TypeSelector UnwrapEnumerableTypes()
		{
			List<Type> list = new List<Type>();
			foreach (Type type in types)
			{
				if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
				{
					list.Add(type.GetGenericArguments().Single());
					continue;
				}
				List<Type> list2 = (from ied in type.GetInterfaces()
					where ied.IsGenericType && ied.GetGenericTypeDefinition() == typeof(IEnumerable<>)
					select ied.GetGenericArguments().Single()).ToList();
				if (list2.Count > 0)
				{
					list.AddRange(list2);
				}
				else
				{
					list.Add(type);
				}
			}
			types = list;
			return this;
		}

		public IEnumerator<Type> GetEnumerator()
		{
			return types.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
