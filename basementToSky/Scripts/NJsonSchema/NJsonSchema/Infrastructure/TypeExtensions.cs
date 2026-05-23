using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using NJsonSchema.Generation;
using Namotion.Reflection;
using Newtonsoft.Json;

namespace NJsonSchema.Infrastructure
{
	public static class TypeExtensions
	{
		private static ReaderWriterLockSlim _namesLock = new ReaderWriterLockSlim();

		private static Dictionary<ContextualMemberInfo, string> _names = new Dictionary<ContextualMemberInfo, string>();

		internal static string GetName(this ContextualAccessorInfo accessorInfo)
		{
			_namesLock.EnterUpgradeableReadLock();
			try
			{
				if (_names.TryGetValue(accessorInfo, out var value))
				{
					return value;
				}
				_namesLock.EnterWriteLock();
				try
				{
					if (_names.TryGetValue(accessorInfo, out value))
					{
						return value;
					}
					value = GetNameWithoutCache(accessorInfo);
					_names[accessorInfo] = value;
					return value;
				}
				finally
				{
					_namesLock.ExitWriteLock();
				}
			}
			finally
			{
				_namesLock.ExitUpgradeableReadLock();
			}
		}

		private static string GetNameWithoutCache(ContextualAccessorInfo accessorInfo)
		{
			JsonPropertyAttribute contextAttribute = accessorInfo.AccessorType.GetContextAttribute<JsonPropertyAttribute>();
			if (contextAttribute != null && !string.IsNullOrEmpty(contextAttribute.PropertyName))
			{
				return contextAttribute.PropertyName;
			}
			DataMemberAttribute contextAttribute2 = accessorInfo.AccessorType.GetContextAttribute<DataMemberAttribute>();
			if (contextAttribute2 != null && !string.IsNullOrEmpty(contextAttribute2.Name))
			{
				DataContractAttribute inheritedAttribute = accessorInfo.MemberInfo.DeclaringType.ToCachedType().GetInheritedAttribute<DataContractAttribute>();
				if (inheritedAttribute != null)
				{
					return contextAttribute2.Name;
				}
			}
			return accessorInfo.Name;
		}

		public static string GetDescription(this CachedType type, IXmlDocsSettings xmlDocsSettings)
		{
			Attribute[] attributes = ((type is ContextualType contextualType) ? contextualType.ContextAttributes : type.InheritedAttributes);
			string description = GetDescription(attributes);
			if (description != null)
			{
				return description;
			}
			if (xmlDocsSettings.UseXmlDocumentation)
			{
				string xmlDocsSummary = type.GetXmlDocsSummary(xmlDocsSettings.GetXmlDocsOptions());
				if (xmlDocsSummary != string.Empty)
				{
					return xmlDocsSummary;
				}
			}
			return null;
		}

		public static string GetDescription(this ContextualAccessorInfo accessorInfo, IXmlDocsSettings xmlDocsSettings)
		{
			string description = GetDescription(accessorInfo.AccessorType.Attributes);
			if (description != null)
			{
				return description;
			}
			if (xmlDocsSettings.UseXmlDocumentation)
			{
				string xmlDocsSummary = accessorInfo.MemberInfo.GetXmlDocsSummary(xmlDocsSettings.GetXmlDocsOptions());
				if (xmlDocsSummary != string.Empty)
				{
					return xmlDocsSummary;
				}
			}
			return null;
		}

		public static string GetDescription(this ContextualParameterInfo parameter, IXmlDocsSettings xmlDocsSettings)
		{
			string description = GetDescription(parameter.ContextAttributes);
			if (description != null)
			{
				return description;
			}
			if (xmlDocsSettings.UseXmlDocumentation)
			{
				string xmlDocs = parameter.GetXmlDocs(xmlDocsSettings.GetXmlDocsOptions());
				if (xmlDocs != string.Empty)
				{
					return xmlDocs;
				}
			}
			return null;
		}

		private static string GetDescription(IEnumerable<Attribute> attributes)
		{
			dynamic val = attributes.FirstAssignableToTypeNameOrDefault("System.ComponentModel.DescriptionAttribute");
			if (val != null && !string.IsNullOrEmpty(val.Description))
			{
				return val.Description;
			}
			dynamic val2 = attributes.FirstAssignableToTypeNameOrDefault("System.ComponentModel.DataAnnotations.DisplayAttribute");
			if (val2 != null)
			{
				dynamic description = val2.GetDescription();
				if (description != null)
				{
					return description;
				}
			}
			return null;
		}
	}
}
