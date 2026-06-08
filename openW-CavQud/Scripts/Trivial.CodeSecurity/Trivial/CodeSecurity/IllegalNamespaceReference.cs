using System.Collections.Generic;
using Trivial.Mono.Cecil;

namespace Trivial.CodeSecurity
{
	public class IllegalNamespaceReference
	{
		private string referencedNamespace;

		private List<IllegalTypeReference> indirectIllegalTypeReferences = new List<IllegalTypeReference>();

		private List<IllegalReferenceUsage> referenceUsages = new List<IllegalReferenceUsage>();

		public string ReferencedNamespace => referencedNamespace;

		public ICollection<IllegalTypeReference> IndirectIllegalTypeReferences => indirectIllegalTypeReferences;

		public ICollection<IllegalReferenceUsage> ReferenceUsages => referenceUsages;

		public IllegalNamespaceReference(string illegalNamespace, TypeReference illegalTypeInIllegalNamespace, IllegalReferenceUsage illegalUsage)
		{
			referencedNamespace = illegalNamespace;
			AddIllegalNamespaceUsage(illegalTypeInIllegalNamespace, illegalUsage);
		}

		public void AddIllegalNamespaceUsage(TypeReference illegalTypeInIllegalNamespace, IllegalReferenceUsage illegalUsage)
		{
			referenceUsages.Add(illegalUsage);
			foreach (IllegalTypeReference indirectIllegalTypeReference in indirectIllegalTypeReferences)
			{
				if (indirectIllegalTypeReference.ReferencedType == illegalTypeInIllegalNamespace)
				{
					indirectIllegalTypeReference.AddIllegalReferenceUsage(illegalUsage);
					return;
				}
			}
			indirectIllegalTypeReferences.Add(new IllegalTypeReference(illegalTypeInIllegalNamespace, illegalUsage, indirect: true));
		}

		public override string ToString()
		{
			return $"Illegal reference to disallowed namespace: {referencedNamespace}";
		}
	}
}
