using System.Collections.Generic;
using Trivial.Mono.Cecil;

namespace Trivial.CodeSecurity
{
	internal class CodeSecurityContext
	{
		private AssemblyDefinition checkAssembly;

		private CodeSecurityReport report;

		private ICodeSecurityValidator validator;

		private Dictionary<string, bool> namespaceReferenceCache = new Dictionary<string, bool>();

		private Dictionary<TypeReference, bool> typeReferenceCache = new Dictionary<TypeReference, bool>();

		private Dictionary<MemberReference, bool> memberReferenceCache = new Dictionary<MemberReference, bool>();

		public AssemblyDefinition CheckAssembly => checkAssembly;

		public CodeSecurityReport Report => report;

		public ICodeSecurityValidator Validator => validator;

		public CodeSecurityContext(AssemblyDefinition checkAssembly, CodeSecurityReport report, ICodeSecurityValidator validator)
		{
			this.checkAssembly = checkAssembly;
			this.report = report;
			this.validator = validator;
		}

		public bool IsNamespaceReferenceAllowedCached(string potentialIllegalNamespace)
		{
			if (potentialIllegalNamespace == null)
			{
				return true;
			}
			bool value = false;
			if (namespaceReferenceCache.TryGetValue(potentialIllegalNamespace, out value))
			{
				return value;
			}
			value = validator.IsNamespaceReferenceAllowed(potentialIllegalNamespace);
			namespaceReferenceCache.Add(potentialIllegalNamespace, value);
			return value;
		}

		public bool IsTypeReferenceAllowedCached(TypeReference potentialIllegalType)
		{
			if (potentialIllegalType == null)
			{
				return true;
			}
			bool value = false;
			if (typeReferenceCache.TryGetValue(potentialIllegalType, out value))
			{
				return value;
			}
			value = validator.IsTypeReferenceAllowed(potentialIllegalType);
			typeReferenceCache.Add(potentialIllegalType, value);
			return value;
		}

		public bool IsMemberReferenceAllowedCached(MemberReference potentialIllegalMember)
		{
			if (potentialIllegalMember == null)
			{
				return true;
			}
			bool value = false;
			if (memberReferenceCache.TryGetValue(potentialIllegalMember, out value))
			{
				return value;
			}
			value = validator.IsMemberReferenceAllowed(potentialIllegalMember);
			memberReferenceCache.Add(potentialIllegalMember, value);
			return value;
		}
	}
}
