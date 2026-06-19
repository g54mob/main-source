using Trivial.Mono.Cecil;

namespace Trivial.CodeSecurity.CodeEvaluation
{
	internal class FieldChecker : CodeChecker<FieldDefinition>, ICodeUsageProvider
	{
		private FieldDefinition currentField;

		private TypeReferenceChecker typeReferenceChecker;

		public FieldChecker()
		{
			typeReferenceChecker = new TypeReferenceChecker(this);
		}

		public override void SecurityCheckCode(CodeSecurityContext context, FieldDefinition fieldDefinition)
		{
			currentField = fieldDefinition;
			typeReferenceChecker.SecurityCheckCode(context, fieldDefinition.FieldType);
		}

		public IllegalReferenceUsage GetIllegalUsage()
		{
			return new IllegalReferenceUsage(currentField);
		}
	}
}
