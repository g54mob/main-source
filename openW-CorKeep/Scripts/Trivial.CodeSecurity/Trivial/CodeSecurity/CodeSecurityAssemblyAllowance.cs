using System;
using System.Collections.Generic;
using Trivial.Mono.Cecil;
using UnityEngine;

namespace Trivial.CodeSecurity
{
	[Serializable]
	public class CodeSecurityAssemblyAllowance : ISerializationCallbackReceiver
	{
		[SerializeField]
		[HideInInspector]
		private string assemblyName = "";

		[SerializeField]
		[HideInInspector]
		private List<CodeSecurityNamespaceAllowance> allowedNamespaces = new List<CodeSecurityNamespaceAllowance>();

		private Dictionary<string, CodeSecurityNamespaceAllowance> allowedNamespaceLookup = new Dictionary<string, CodeSecurityNamespaceAllowance>();

		public string AssemblyName => assemblyName;

		public IEnumerable<CodeSecurityNamespaceAllowance> AllowedNamespaces => allowedNamespaceLookup.Values;

		public CodeSecurityAssemblyAllowance()
		{
		}

		public CodeSecurityAssemblyAllowance(string assemblyName)
		{
			this.assemblyName = assemblyName;
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			allowedNamespaces.Clear();
			allowedNamespaces.AddRange(allowedNamespaceLookup.Values);
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			allowedNamespaceLookup.Clear();
			foreach (CodeSecurityNamespaceAllowance allowedNamespace in allowedNamespaces)
			{
				allowedNamespaceLookup[allowedNamespace.NamespaceName] = allowedNamespace;
			}
		}

		public CodeSecurityNamespaceAllowance AddNamespaceAllowance(string namespaceName)
		{
			if (allowedNamespaceLookup.TryGetValue(assemblyName, out var value))
			{
				return value;
			}
			value = new CodeSecurityNamespaceAllowance(assemblyName);
			allowedNamespaceLookup[assemblyName] = value;
			return value;
		}

		public void RemoveNamespaceAllowance(CodeSecurityNamespaceAllowance namespaceAllowance)
		{
			if (allowedNamespaceLookup.ContainsKey(namespaceAllowance.NamespaceName))
			{
				allowedNamespaceLookup.Remove(namespaceAllowance.NamespaceName);
			}
		}

		public bool IsNamespaceAllowed(TypeReference typeReference)
		{
			return allowedNamespaceLookup.ContainsKey(typeReference.Namespace);
		}

		public bool IsTypeReferenceAllowed(TypeReference typeReference)
		{
			if (!allowedNamespaceLookup.TryGetValue(typeReference.Namespace, out var value))
			{
				return false;
			}
			return value.IsTypeAllowed(typeReference);
		}

		public bool IsMemberReferenceAllowed(MemberReference memberReference)
		{
			if (!allowedNamespaceLookup.TryGetValue(memberReference.DeclaringType.Namespace, out var value))
			{
				return false;
			}
			return value.IsMemberAllowed(memberReference);
		}
	}
}
