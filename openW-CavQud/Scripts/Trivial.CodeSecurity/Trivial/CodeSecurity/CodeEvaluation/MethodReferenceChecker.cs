using System;
using Trivial.Mono.Cecil;
using Trivial.Mono.Collections.Generic;

namespace Trivial.CodeSecurity.CodeEvaluation
{
	internal class MethodReferenceChecker : CodeChecker<MethodReference>
	{
		private TypeReferenceChecker typeReferenceChecker;

		private ICodeUsageProvider usageProvider;

		public MethodReferenceChecker(ICodeUsageProvider usageProvider)
		{
			if (usageProvider == null)
			{
				throw new ArgumentNullException("usageProvider");
			}
			typeReferenceChecker = new TypeReferenceChecker(usageProvider);
			this.usageProvider = usageProvider;
		}

		public override void SecurityCheckCode(CodeSecurityContext context, MethodReference methodReference)
		{
			SecurityCheckCodeMethodReturn(context, methodReference.ReturnType);
			if (methodReference.HasParameters)
			{
				SecurityCheckCodeMethodParameters(context, methodReference.Parameters);
			}
			SecurityCheckAndReportMemberReference(context, methodReference, usageProvider);
		}

		public void SecurityCheckCodeMethodReturn(CodeSecurityContext context, TypeReference returnType)
		{
			typeReferenceChecker.SecurityCheckCode(context, returnType);
		}

		public void SecurityCheckCodeMethodParameters(CodeSecurityContext context, Collection<ParameterDefinition> parameters)
		{
			foreach (ParameterDefinition parameter in parameters)
			{
				typeReferenceChecker.SecurityCheckCode(context, parameter.ParameterType);
			}
		}
	}
}
