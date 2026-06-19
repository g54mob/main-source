using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using FullInspector.Internal;
using FullSerializer.Internal;
using UnityEngine;

namespace FullInspector
{
	public static class InspectedMemberFilters
	{
		private class AllFilter : IInspectedMemberFilter
		{
			public bool IsInterested(InspectedProperty property)
			{
				return true;
			}

			public bool IsInterested(InspectedMethod method)
			{
				return true;
			}
		}

		private class FullInspectorSerializedPropertiesFilter : IInspectedMemberFilter
		{
			public bool IsInterested(InspectedProperty property)
			{
				if (property.CanWrite && InspectedType.IsSerializedByFullInspector(property))
				{
					return !InspectedType.IsSerializedByUnity(property);
				}
				return false;
			}

			public bool IsInterested(InspectedMethod method)
			{
				return false;
			}
		}

		private class InspectableMembersFilter : IInspectedMemberFilter
		{
			public bool IsInterested(InspectedProperty property)
			{
				if (IsPropertyTypeInspectable(property))
				{
					return ShouldDisplayProperty(property);
				}
				return false;
			}

			public bool IsInterested(InspectedMethod method)
			{
				return method.Method.IsDefined(typeof(InspectorButtonAttribute), inherit: true);
			}
		}

		private class StaticInspectableMembersFilter : IInspectedMemberFilter
		{
			public bool IsInterested(InspectedProperty property)
			{
				if (property.IsStatic)
				{
					return IsPropertyTypeInspectable(property);
				}
				return false;
			}

			public bool IsInterested(InspectedMethod method)
			{
				return method.Method.IsDefined(typeof(InspectorButtonAttribute), inherit: true);
			}
		}

		private class ButtonMembersFilter : IInspectedMemberFilter
		{
			public bool IsInterested(InspectedProperty property)
			{
				return false;
			}

			public bool IsInterested(InspectedMethod method)
			{
				return method.Method.IsDefined(typeof(InspectorButtonAttribute), inherit: true);
			}
		}

		public static IInspectedMemberFilter All = new AllFilter();

		public static IInspectedMemberFilter FullInspectorSerializedProperties = new FullInspectorSerializedPropertiesFilter();

		public static IInspectedMemberFilter InspectableMembers = new InspectableMembersFilter();

		public static IInspectedMemberFilter StaticInspectableMembers = new StaticInspectableMembersFilter();

		public static IInspectedMemberFilter ButtonMembers = new ButtonMembersFilter();

		private static bool ShouldDisplayProperty(InspectedProperty property)
		{
			MemberInfo memberInfo = property.MemberInfo;
			if (memberInfo.IsDefined(typeof(ShowInInspectorAttribute), inherit: true))
			{
				return true;
			}
			if (memberInfo.IsDefined(typeof(HideInInspector), inherit: true) || memberInfo.IsDefined(typeof(NotSerializedAttribute), inherit: true) || fiInstalledSerializerManager.SerializationOptOutAnnotations.Any((Type t) => memberInfo.IsDefined(t, inherit: true)))
			{
				return false;
			}
			if (!property.IsStatic && fiInstalledSerializerManager.SerializationOptInAnnotations.Any((Type t) => memberInfo.IsDefined(t, inherit: true)))
			{
				return true;
			}
			if (property.MemberInfo is PropertyInfo && fiSettings.InspectorRequireShowInInspector)
			{
				return false;
			}
			if (!typeof(BaseObject).Resolve().IsAssignableFrom(property.StorageType.Resolve()) && !InspectedType.IsSerializedByFullInspector(property))
			{
				return InspectedType.IsSerializedByUnity(property);
			}
			return true;
		}

		private static bool IsPropertyTypeInspectable(InspectedProperty property)
		{
			if (typeof(Delegate).IsAssignableFrom(property.StorageType))
			{
				return false;
			}
			if (property.MemberInfo is FieldInfo)
			{
				if (property.MemberInfo.IsDefined(typeof(CompilerGeneratedAttribute), inherit: false))
				{
					return false;
				}
			}
			else if (property.MemberInfo is PropertyInfo)
			{
				PropertyInfo propertyInfo = (PropertyInfo)property.MemberInfo;
				if (!propertyInfo.CanRead)
				{
					return false;
				}
				string text = propertyInfo.DeclaringType.Namespace;
				if (text != null && (text.StartsWith("UnityEngine") || text.StartsWith("UnityEditor")) && !propertyInfo.CanWrite)
				{
					return false;
				}
				if (propertyInfo.Name.EndsWith("Item") && propertyInfo.GetIndexParameters().Length != 0)
				{
					return false;
				}
			}
			return true;
		}
	}
}
