using System;
using System.Collections.Generic;
using Trivial.Mono.Cecil;
using UnityEngine;

namespace Trivial.CodeSecurity
{
	[Serializable]
	public class CodeSecurityAllowance : ICodeSecurityValidator, ISerializationCallbackReceiver
	{
		[SerializeField]
		[HideInInspector]
		private bool allowPInvoke;

		[SerializeField]
		[HideInInspector]
		private CodeSecurityRestrictions.CodeSecurityBehaviour defaultBehaviour = CodeSecurityRestrictions.CodeSecurityBehaviour.Deny;

		[SerializeField]
		[HideInInspector]
		private List<CodeSecurityAssemblyAllowance> allowedAssemblies = new List<CodeSecurityAssemblyAllowance>();

		private Dictionary<string, CodeSecurityAssemblyAllowance> allowedAssemblyLookup = new Dictionary<string, CodeSecurityAssemblyAllowance>();

		public bool AllowPInvoke
		{
			get
			{
				return allowPInvoke;
			}
			set
			{
				allowPInvoke = value;
			}
		}

		public CodeSecurityRestrictions.CodeSecurityBehaviour DefaultBehaviour
		{
			get
			{
				return defaultBehaviour;
			}
			set
			{
				defaultBehaviour = value;
			}
		}

		public IEnumerable<CodeSecurityAssemblyAllowance> AllowedAssemblies => allowedAssemblyLookup.Values;

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			allowedAssemblies.Clear();
			allowedAssemblies.AddRange(allowedAssemblyLookup.Values);
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			allowedAssemblyLookup.Clear();
			foreach (CodeSecurityAssemblyAllowance allowedAssembly in allowedAssemblies)
			{
				allowedAssemblyLookup[allowedAssembly.AssemblyName] = allowedAssembly;
			}
		}

		public CodeSecurityAssemblyAllowance AddAssemblyAllowance(string assemblyName)
		{
			if (allowedAssemblyLookup.TryGetValue(assemblyName, out var value))
			{
				return value;
			}
			value = new CodeSecurityAssemblyAllowance(assemblyName);
			allowedAssemblyLookup[assemblyName] = value;
			return value;
		}

		public void RemoveAssemblyAllowance(CodeSecurityAssemblyAllowance assemblyAllowance)
		{
			if (allowedAssemblyLookup.ContainsKey(assemblyAllowance.AssemblyName))
			{
				allowedAssemblyLookup.Remove(assemblyAllowance.AssemblyName);
			}
		}

		public bool IsAssemblyReferenceAllowed(string assemblyReference)
		{
			return allowedAssemblyLookup.ContainsKey(assemblyReference);
		}

		public bool IsNamespaceReferenceAllowed(TypeReference reference)
		{
			if (!allowedAssemblyLookup.TryGetValue(reference.Module.Name, out var value))
			{
				return defaultBehaviour == CodeSecurityRestrictions.CodeSecurityBehaviour.Allow;
			}
			return value.IsNamespaceAllowed(reference);
		}

		public bool IsTypeReferenceAllowed(TypeReference reference)
		{
			if (!allowedAssemblyLookup.TryGetValue(reference.Module.Name, out var value))
			{
				return defaultBehaviour == CodeSecurityRestrictions.CodeSecurityBehaviour.Allow;
			}
			return value.IsTypeReferenceAllowed(reference);
		}

		public bool IsMemberReferenceAllowed(MemberReference reference)
		{
			if (!allowedAssemblyLookup.TryGetValue(reference.Module.Name, out var value))
			{
				return defaultBehaviour == CodeSecurityRestrictions.CodeSecurityBehaviour.Allow;
			}
			return value.IsMemberReferenceAllowed(reference);
		}

		public static int GetMemberReferenceHashPersistent(string memberName)
		{
			if (memberName == null)
			{
				return -1;
			}
			int num = 23;
			int length = memberName.Length;
			for (int i = 0; i < length; i++)
			{
				num = num * 31 + memberName[i];
			}
			return num;
		}
	}
}
