using System.Collections.Generic;
using Trivial.Mono.Cecil;

namespace Trivial.CodeSecurity
{
	public class IllegalTypeReference
	{
		private TypeReference referencedType;

		private List<IllegalReferenceUsage> referenceUsages = new List<IllegalReferenceUsage>();

		protected bool indirect;

		public TypeReference ReferencedType => referencedType;

		public ICollection<IllegalReferenceUsage> ReferenceUsages => referenceUsages;

		public int ReferenceUsageCount => referenceUsages.Count;

		public IllegalTypeReference(TypeReference illegalType, IllegalReferenceUsage illegalUsage, bool indirect = false)
		{
			referencedType = illegalType;
			referenceUsages.Add(illegalUsage);
			this.indirect = indirect;
		}

		public void AddIllegalReferenceUsage(IllegalReferenceUsage illegalUsage)
		{
			referenceUsages.Add(illegalUsage);
		}

		public override string ToString()
		{
			if (!indirect)
			{
				return $"Illegal reference to disallowed type: {referencedType}";
			}
			return $"Indirect illegal reference via namespace exclusion to disallowed type: {referencedType}";
		}
	}
}
