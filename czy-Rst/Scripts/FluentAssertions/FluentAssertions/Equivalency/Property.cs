using System;
using System.ComponentModel;
using System.Reflection;
using FluentAssertions.Common;

namespace FluentAssertions.Equivalency
{
	internal class Property : Node, IMember, INode
	{
		private readonly PropertyInfo propertyInfo;

		private bool? isBrowsable;

		public Type DeclaringType { get; }

		public Type ReflectedType { get; }

		public CSharpAccessModifier GetterAccessibility => propertyInfo.GetGetMethod(nonPublic: true).GetCSharpAccessModifier();

		public CSharpAccessModifier SetterAccessibility => propertyInfo.GetSetMethod(nonPublic: true).GetCSharpAccessModifier();

		public bool IsBrowsable
		{
			get
			{
				bool valueOrDefault = isBrowsable == true;
				if (!isBrowsable.HasValue)
				{
					EditorBrowsableAttribute customAttribute = propertyInfo.GetCustomAttribute<EditorBrowsableAttribute>();
					valueOrDefault = customAttribute == null || customAttribute.State != EditorBrowsableState.Never;
					isBrowsable = valueOrDefault;
				}
				return isBrowsable.Value;
			}
		}

		public Property(PropertyInfo propertyInfo, INode parent)
			: this(propertyInfo.ReflectedType, propertyInfo, parent)
		{
		}

		public Property(Type reflectedType, PropertyInfo propertyInfo, INode parent)
		{
			ReflectedType = reflectedType;
			this.propertyInfo = propertyInfo;
			DeclaringType = propertyInfo.DeclaringType;
			base.Subject = new Pathway(parent.Subject.PathAndName, propertyInfo.Name, (string pathAndName) => "property " + parent.GetSubjectId().Combine(pathAndName));
			base.Expectation = new Pathway(parent.Expectation.PathAndName, propertyInfo.Name, (string pathAndName) => "property " + pathAndName);
			base.Type = propertyInfo.PropertyType;
			base.ParentType = propertyInfo.DeclaringType;
			base.GetSubjectId = parent.GetSubjectId;
			base.RootIsCollection = parent.RootIsCollection;
		}

		public object GetValue(object obj)
		{
			return propertyInfo.GetValue(obj);
		}
	}
}
