using System;
using System.ComponentModel;
using System.Reflection;
using FluentAssertions.Common;

namespace FluentAssertions.Equivalency
{
	internal class Field : Node, IMember, INode
	{
		private readonly FieldInfo fieldInfo;

		private bool? isBrowsable;

		public Type ReflectedType { get; }

		public Type DeclaringType { get; set; }

		public CSharpAccessModifier GetterAccessibility => fieldInfo.GetCSharpAccessModifier();

		public CSharpAccessModifier SetterAccessibility => fieldInfo.GetCSharpAccessModifier();

		public bool IsBrowsable
		{
			get
			{
				bool valueOrDefault = isBrowsable == true;
				if (!isBrowsable.HasValue)
				{
					EditorBrowsableAttribute customAttribute = fieldInfo.GetCustomAttribute<EditorBrowsableAttribute>();
					valueOrDefault = customAttribute == null || customAttribute.State != EditorBrowsableState.Never;
					isBrowsable = valueOrDefault;
					return valueOrDefault;
				}
				return valueOrDefault;
			}
		}

		public Field(FieldInfo fieldInfo, INode parent)
		{
			this.fieldInfo = fieldInfo;
			DeclaringType = fieldInfo.DeclaringType;
			ReflectedType = fieldInfo.ReflectedType;
			base.Subject = new Pathway(parent.Subject.PathAndName, fieldInfo.Name, (string pathAndName) => "field " + parent.GetSubjectId().Combine(pathAndName));
			base.Expectation = new Pathway(parent.Expectation.PathAndName, fieldInfo.Name, (string pathAndName) => "field " + pathAndName);
			base.GetSubjectId = parent.GetSubjectId;
			base.Type = fieldInfo.FieldType;
			base.ParentType = fieldInfo.DeclaringType;
			base.RootIsCollection = parent.RootIsCollection;
		}

		public object GetValue(object obj)
		{
			return fieldInfo.GetValue(obj);
		}
	}
}
