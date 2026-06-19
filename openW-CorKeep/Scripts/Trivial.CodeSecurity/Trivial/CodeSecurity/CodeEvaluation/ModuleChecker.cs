using Trivial.Mono.Cecil;

namespace Trivial.CodeSecurity.CodeEvaluation
{
	internal class ModuleChecker
	{
		private TypeChecker typeChecker = new TypeChecker();

		public void SecurityCheckModuleReferences(CodeSecurityContext context, ModuleDefinition module)
		{
			foreach (AssemblyNameReference assemblyReference in module.AssemblyReferences)
			{
				if (!context.Validator.IsAssemblyReferenceAllowed(assemblyReference.Name))
				{
					context.Report.AddIllegalAssemblyReferenceOccurence(assemblyReference, module);
				}
			}
		}

		public void SecurityCheckModuleCode(CodeSecurityContext context, ModuleDefinition module)
		{
			foreach (TypeDefinition type in module.Types)
			{
				typeChecker.SecurityCheckCode(context, type);
			}
		}
	}
}
