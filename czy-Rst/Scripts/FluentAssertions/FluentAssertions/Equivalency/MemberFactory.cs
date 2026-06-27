using System;
using System.Reflection;
using FluentAssertions.Common;

namespace FluentAssertions.Equivalency
{
	public static class MemberFactory
	{
		public static IMember Create(MemberInfo memberInfo, INode parent)
		{
			return memberInfo.MemberType switch
			{
				MemberTypes.Field => new Field((FieldInfo)memberInfo, parent), 
				MemberTypes.Property => new Property((PropertyInfo)memberInfo, parent), 
				_ => throw new NotSupportedException($"Don't know how to deal with a {memberInfo.MemberType}"), 
			};
		}

		internal static IMember Find(object target, string memberName, INode parent)
		{
			PropertyInfo propertyInfo = target.GetType().FindProperty(memberName, MemberVisibility.Public | MemberVisibility.ExplicitlyImplemented);
			if ((object)propertyInfo != null && !propertyInfo.IsIndexer())
			{
				return new Property(propertyInfo, parent);
			}
			FieldInfo fieldInfo = target.GetType().FindField(memberName, MemberVisibility.Public);
			if ((object)fieldInfo == null)
			{
				return null;
			}
			return new Field(fieldInfo, parent);
		}
	}
}
