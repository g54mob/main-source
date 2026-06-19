using Trivial.Mono.Cecil;

namespace Trivial.CodeSecurity
{
	public class IllegalAssemblyReference
	{
		private AssemblyNameReference assemblyName;

		private IllegalReferenceUsage illegalUsage;

		public AssemblyNameReference ReferencedAssemebly => assemblyName;

		public IllegalReferenceUsage IllegalUsage => illegalUsage;

		public IllegalAssemblyReference(AssemblyNameReference illegalAssemblyName, ModuleDefinition module)
		{
			assemblyName = illegalAssemblyName;
			illegalUsage = new IllegalReferenceUsage(module);
		}

		public override string ToString()
		{
			return $"Illegal reference to disallowed reference assembly: {assemblyName}";
		}
	}
}
