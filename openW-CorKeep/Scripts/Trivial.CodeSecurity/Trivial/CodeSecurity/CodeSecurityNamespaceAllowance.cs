using System;
using System.Collections.Generic;
using Trivial.Mono.Cecil;
using UnityEngine;

namespace Trivial.CodeSecurity
{
	[Serializable]
	public class CodeSecurityNamespaceAllowance : ISerializationCallbackReceiver
	{
		[SerializeField]
		[HideInInspector]
		private string namespaceName = "";

		[SerializeField]
		[HideInInspector]
		private List<CodeSecurityTypeAllowance> allowedTypes = new List<CodeSecurityTypeAllowance>();

		private Dictionary<string, CodeSecurityTypeAllowance> allowedTypesLookup = new Dictionary<string, CodeSecurityTypeAllowance>();

		public string NamespaceName => namespaceName;

		public IEnumerable<CodeSecurityTypeAllowance> AllowedTypes => allowedTypesLookup.Values;

		public CodeSecurityNamespaceAllowance()
		{
		}

		public CodeSecurityNamespaceAllowance(string namespaceName)
		{
			this.namespaceName = namespaceName;
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			allowedTypes.Clear();
			allowedTypes.AddRange(allowedTypesLookup.Values);
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			allowedTypesLookup.Clear();
			foreach (CodeSecurityTypeAllowance allowedType in allowedTypes)
			{
				allowedTypesLookup[allowedType.TypeName] = allowedType;
			}
		}

		public CodeSecurityTypeAllowance AddTypeAllowance(Type type)
		{
			if (allowedTypesLookup.TryGetValue(type.Name, out var value))
			{
				return value;
			}
			value = new CodeSecurityTypeAllowance(type.Name);
			allowedTypesLookup[type.Name] = value;
			return value;
		}

		public void RemoveTypeAllowance(CodeSecurityTypeAllowance typeAllowance)
		{
			if (allowedTypesLookup.ContainsKey(typeAllowance.TypeName))
			{
				allowedTypesLookup.Remove(typeAllowance.TypeName);
			}
		}

		public void RemoveTypeAllowance(Type type)
		{
			if (allowedTypesLookup.ContainsKey(type.Name))
			{
				allowedTypesLookup.Remove(type.Name);
			}
		}

		public bool IsTypeAllowed(TypeReference typeReference)
		{
			return allowedTypesLookup.ContainsKey(typeReference.Name);
		}

		public bool IsMemberAllowed(MemberReference memberReference)
		{
			if (!allowedTypesLookup.TryGetValue(memberReference.DeclaringType.Name, out var value))
			{
				return false;
			}
			return value.IsMemberAllowed(memberReference);
		}
	}
}
