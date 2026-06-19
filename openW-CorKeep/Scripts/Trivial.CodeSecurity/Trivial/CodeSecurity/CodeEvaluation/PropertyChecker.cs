using Trivial.Mono.Cecil;

namespace Trivial.CodeSecurity.CodeEvaluation
{
	internal class PropertyChecker : CodeChecker<PropertyDefinition>, ICodeUsageProvider
	{
		private PropertyDefinition currentProperty;

		private TypeReferenceChecker typeReferenceChecker;

		private MethodChecker accessorChecker = new MethodChecker();

		public PropertyChecker()
		{
			typeReferenceChecker = new TypeReferenceChecker(this);
		}

		public override void SecurityCheckCode(CodeSecurityContext context, PropertyDefinition propertyDefinition)
		{
			currentProperty = propertyDefinition;
			typeReferenceChecker.SecurityCheckCode(context, propertyDefinition.PropertyType);
			SecurityCheckAndReportMemberReference(context, propertyDefinition, this);
			if (propertyDefinition.GetMethod != null)
			{
				accessorChecker.SecurityCheckCode(context, propertyDefinition.GetMethod);
			}
			if (propertyDefinition.SetMethod != null)
			{
				accessorChecker.SecurityCheckCode(context, propertyDefinition.SetMethod);
			}
		}

		public IllegalReferenceUsage GetIllegalUsage()
		{
			return new IllegalReferenceUsage(currentProperty);
		}
	}
}
