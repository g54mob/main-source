using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions.Common;

namespace FluentAssertions.Types
{
	public class PropertyInfoSelector : IEnumerable<PropertyInfo>, IEnumerable
	{
		private IEnumerable<PropertyInfo> selectedProperties;

		public PropertyInfoSelector ThatArePublicOrInternal
		{
			get
			{
				selectedProperties = selectedProperties.Where(delegate(PropertyInfo property)
				{
					MethodInfo getMethod = property.GetGetMethod(nonPublic: true);
					bool flag = (((object)getMethod != null && (getMethod.IsPublic || getMethod.IsAssembly)) ? true : false);
					bool flag2 = flag;
					if (!flag2)
					{
						MethodInfo setMethod = property.GetSetMethod(nonPublic: true);
						bool flag3 = (((object)setMethod != null && (setMethod.IsPublic || setMethod.IsAssembly)) ? true : false);
						flag2 = flag3;
					}
					return flag2;
				});
				return this;
			}
		}

		public PropertyInfoSelector ThatAreAbstract
		{
			get
			{
				selectedProperties = selectedProperties.Where((PropertyInfo property) => property.IsAbstract());
				return this;
			}
		}

		public PropertyInfoSelector ThatAreNotAbstract
		{
			get
			{
				selectedProperties = selectedProperties.Where((PropertyInfo property) => !property.IsAbstract());
				return this;
			}
		}

		public PropertyInfoSelector ThatAreStatic
		{
			get
			{
				selectedProperties = selectedProperties.Where((PropertyInfo property) => property.IsStatic());
				return this;
			}
		}

		public PropertyInfoSelector ThatAreNotStatic
		{
			get
			{
				selectedProperties = selectedProperties.Where((PropertyInfo property) => !property.IsStatic());
				return this;
			}
		}

		public PropertyInfoSelector ThatAreVirtual
		{
			get
			{
				selectedProperties = selectedProperties.Where((PropertyInfo property) => property.IsVirtual());
				return this;
			}
		}

		public PropertyInfoSelector ThatAreNotVirtual
		{
			get
			{
				selectedProperties = selectedProperties.Where((PropertyInfo property) => !property.IsVirtual());
				return this;
			}
		}

		public PropertyInfoSelector(Type type)
			: this(new _003C_003Ez__ReadOnlySingleElementList<Type>(type))
		{
		}

		public PropertyInfoSelector(IEnumerable<Type> types)
		{
			Guard.ThrowIfArgumentIsNull(types, "types");
			Guard.ThrowIfArgumentContainsNull(types, "types");
			selectedProperties = types.SelectMany((Type t) => t.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic));
		}

		public PropertyInfoSelector ThatAreDecoratedWith<TAttribute>() where TAttribute : Attribute
		{
			selectedProperties = selectedProperties.Where((PropertyInfo property) => property.IsDecoratedWith<TAttribute>());
			return this;
		}

		public PropertyInfoSelector ThatAreDecoratedWithOrInherit<TAttribute>() where TAttribute : Attribute
		{
			selectedProperties = selectedProperties.Where((PropertyInfo property) => property.IsDecoratedWithOrInherit<TAttribute>());
			return this;
		}

		public PropertyInfoSelector ThatAreNotDecoratedWith<TAttribute>() where TAttribute : Attribute
		{
			selectedProperties = selectedProperties.Where((PropertyInfo property) => !property.IsDecoratedWith<TAttribute>());
			return this;
		}

		public PropertyInfoSelector ThatAreNotDecoratedWithOrInherit<TAttribute>() where TAttribute : Attribute
		{
			selectedProperties = selectedProperties.Where((PropertyInfo property) => !property.IsDecoratedWithOrInherit<TAttribute>());
			return this;
		}

		public PropertyInfoSelector OfType<TReturn>()
		{
			selectedProperties = selectedProperties.Where((PropertyInfo property) => property.PropertyType == typeof(TReturn));
			return this;
		}

		public PropertyInfoSelector NotOfType<TReturn>()
		{
			selectedProperties = selectedProperties.Where((PropertyInfo property) => property.PropertyType != typeof(TReturn));
			return this;
		}

		public TypeSelector ReturnTypes()
		{
			return new TypeSelector(selectedProperties.Select((PropertyInfo property) => property.PropertyType));
		}

		public PropertyInfo[] ToArray()
		{
			return selectedProperties.ToArray();
		}

		public IEnumerator<PropertyInfo> GetEnumerator()
		{
			return selectedProperties.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
