using System;
using System.Collections.Generic;
using Trivial.Mono.Cecil;

namespace Trivial.CodeSecurity.CodeEvaluation
{
	internal class TypeReferenceChecker : CodeChecker<TypeReference>
	{
		private ICodeUsageProvider usageProvider;

		public TypeReferenceChecker(ICodeUsageProvider usageProvider)
		{
			if (usageProvider == null)
			{
				throw new ArgumentNullException("usageProvider");
			}
			this.usageProvider = usageProvider;
		}

		public override void SecurityCheckCode(CodeSecurityContext context, TypeReference typeReference)
		{
			foreach (TypeReference item in ExpandTypeReferenceGenerics(typeReference))
			{
				if (!item.IsDefinition)
				{
					SecurityCheckAndReportTypeReferenceAndNamespace(context, item, usageProvider);
				}
			}
		}

		private IEnumerable<TypeReference> ExpandTypeReferenceGenerics(TypeReference reference)
		{
			yield return reference;
			if (!reference.HasGenericParameters)
			{
				yield break;
			}
			foreach (GenericParameter genericParameter in reference.GenericParameters)
			{
				TypeDefinition typeDefinition = genericParameter.Resolve();
				if (typeDefinition == null)
				{
					continue;
				}
				foreach (TypeReference item in ExpandTypeReferenceGenerics(typeDefinition))
				{
					yield return item;
				}
			}
		}
	}
}
