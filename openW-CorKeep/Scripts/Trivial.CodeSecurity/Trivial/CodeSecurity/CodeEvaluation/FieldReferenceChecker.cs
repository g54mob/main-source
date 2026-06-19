using System;
using Trivial.Mono.Cecil;

namespace Trivial.CodeSecurity.CodeEvaluation
{
	internal class FieldReferenceChecker : CodeChecker<FieldReference>
	{
		private TypeReferenceChecker typeReferenceChecker;

		private ICodeUsageProvider usageProvider;

		public FieldReferenceChecker(ICodeUsageProvider usageProvider)
		{
			if (usageProvider == null)
			{
				throw new ArgumentNullException("usageProvider");
			}
			typeReferenceChecker = new TypeReferenceChecker(usageProvider);
			this.usageProvider = usageProvider;
		}

		public override void SecurityCheckCode(CodeSecurityContext context, FieldReference fieldReference)
		{
			typeReferenceChecker.SecurityCheckCode(context, fieldReference.FieldType);
			if (!fieldReference.IsDefinition)
			{
				SecurityCheckAndReportMemberReference(context, fieldReference, usageProvider);
			}
		}
	}
}
