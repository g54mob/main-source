using Trivial.Mono.Cecil;

namespace Trivial.CodeSecurity.CodeEvaluation
{
	internal class TypeChecker : CodeChecker<TypeDefinition>, ICodeUsageProvider
	{
		private TypeDefinition currentType;

		private TypeReferenceChecker typeReferenceChecker;

		private FieldChecker fieldChecker = new FieldChecker();

		private PropertyChecker properyChecker = new PropertyChecker();

		private MethodChecker methodChecker = new MethodChecker();

		private EventChecker eventChecker = new EventChecker();

		public TypeChecker()
		{
			typeReferenceChecker = new TypeReferenceChecker(this);
		}

		public override void SecurityCheckCode(CodeSecurityContext context, TypeDefinition typeDefinition)
		{
			currentType = typeDefinition;
			if (typeDefinition.BaseType != null)
			{
				typeReferenceChecker.SecurityCheckCode(context, typeDefinition.BaseType);
			}
			foreach (InterfaceImplementation @interface in typeDefinition.Interfaces)
			{
				typeReferenceChecker.SecurityCheckCode(context, @interface.InterfaceType);
			}
			foreach (FieldDefinition field in typeDefinition.Fields)
			{
				fieldChecker.SecurityCheckCode(context, field);
			}
			foreach (PropertyDefinition property in typeDefinition.Properties)
			{
				properyChecker.SecurityCheckCode(context, property);
			}
			foreach (MethodDefinition method in typeDefinition.Methods)
			{
				methodChecker.SecurityCheckCode(context, method);
			}
			foreach (EventDefinition @event in typeDefinition.Events)
			{
				eventChecker.SecurityCheckCode(context, @event);
			}
		}

		public IllegalReferenceUsage GetIllegalUsage()
		{
			return new IllegalReferenceUsage(currentType);
		}
	}
}
