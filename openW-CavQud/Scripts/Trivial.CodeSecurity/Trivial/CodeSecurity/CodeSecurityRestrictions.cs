using System;
using Trivial.Mono.Cecil;
using UnityEngine;

namespace Trivial.CodeSecurity
{
	[Serializable]
	public class CodeSecurityRestrictions : ICodeSecurityValidator
	{
		[Serializable]
		public enum CodeSecurityBehaviour
		{
			Allow = 0,
			Deny = 1
		}

		[SerializeField]
		[HideInInspector]
		private CodeSecurityRestrictionsEntry assemblyReferences = new CodeSecurityRestrictionsEntry();

		[SerializeField]
		[HideInInspector]
		private CodeSecurityRestrictionsEntry namespaceReferences = new CodeSecurityRestrictionsEntry();

		[SerializeField]
		[HideInInspector]
		private CodeSecurityRestrictionsEntry typeReferences = new CodeSecurityRestrictionsEntry();

		[SerializeField]
		[HideInInspector]
		public CodeSecurityRestrictionsEntry memberReferences = new CodeSecurityRestrictionsEntry();

		[SerializeField]
		[HideInInspector]
		private bool ignoreCase;

		public CodeSecurityRestrictionsEntry AssemblyReferences => assemblyReferences;

		public CodeSecurityRestrictionsEntry NamespaceReferences => namespaceReferences;

		public CodeSecurityRestrictionsEntry TypeReferences => typeReferences;

		public CodeSecurityRestrictionsEntry MemberReferences => memberReferences;

		public bool IgnoreCase
		{
			get
			{
				return ignoreCase;
			}
			set
			{
				ignoreCase = value;
			}
		}

		public int RestrictionsHash
		{
			get
			{
				int num = 6779 + (0x1A7B ^ assemblyReferences.RestrictionsHash);
				int num2 = num * (num ^ namespaceReferences.RestrictionsHash);
				int num3 = num2 / (num2 ^ typeReferences.RestrictionsHash);
				int num4 = num3 - (num3 ^ memberReferences.RestrictionsHash);
				return num4 | (num4 ^ ignoreCase.GetHashCode());
			}
		}

		public bool IsAssemblyReferenceAllowed(string assemblyReference)
		{
			return assemblyReferences.IsAllowable(assemblyReference, ignoreCase);
		}

		public bool IsNamespaceReferenceAllowed(string namespaceName)
		{
			return namespaceReferences.IsAllowable(namespaceName, ignoreCase, allowWildcard: true);
		}

		public bool IsTypeReferenceAllowed(TypeReference reference)
		{
			return typeReferences.IsAllowable(reference.FullName, ignoreCase);
		}

		public bool IsMemberReferenceAllowed(MemberReference reference)
		{
			string text = reference.Name;
			if (text.StartsWith("get_"))
			{
				text = text.Remove(0, 4);
			}
			else if (text.StartsWith("set_"))
			{
				text = text.Remove(0, 4);
			}
			string entryName = $"{reference.DeclaringType.FullName}.{text}";
			return memberReferences.IsAllowable(entryName, ignoreCase);
		}

		public static string SystemToCecilTypeString(string fullTypeName)
		{
			return fullTypeName.Replace("+", "/");
		}
	}
}
