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
			SecurityCheckCodeMethodReturn(context, methodReference.ReturnType, methodReference);
			if (methodReference.HasParameters)
			{
				SecurityCheckCodeMethodParameters(context, methodReference.Parameters, methodReference);
			}
			if (!methodReference.IsDefinition)
			{
				SecurityCheckAndReportMemberReference(context, methodReference, usageProvider);
			}
		}

		public void SecurityCheckCodeMethodReturn(CodeSecurityContext context, TypeReference returnType, MethodReference methodContext)
		{
			typeReferenceChecker.SecurityCheckCode(context, ResolveGenerics(returnType, methodContext));
		}

		public void SecurityCheckCodeMethodParameters(CodeSecurityContext context, Collection<ParameterDefinition> parameters, MethodReference methodContext)
		{
			foreach (ParameterDefinition parameter in parameters)
			{
				typeReferenceChecker.SecurityCheckCode(context, ResolveGenerics(parameter.ParameterType, methodContext));
			}
		}

		private TypeReference ResolveGenerics(TypeReference reference, MethodReference parent)
		{
			if (reference.Name.StartsWith("!!"))
			{
				int genericRank = GetGenericRank(reference);
				reference = (parent as GenericInstanceMethod).GenericArguments[genericRank];
			}
			else if (reference.Name.StartsWith("!"))
			{
				int genericRank2 = GetGenericRank(reference);
				reference = (parent.DeclaringType as GenericInstanceType).GenericArguments[genericRank2];
			}
			return reference;
		}

		private int GetGenericRank(TypeReference reference)
		{
			string text = reference.Name.TrimStart(new char[1] { '!' });
			int num = -1;
			for (int i = 0; i < text.Length; i++)
			{
				if (!char.IsDigit(text[i]))
				{
					num = i;
					break;
				}
			}
			if (num != -1)
			{
				text = text.Remove(num);
			}
			return int.Parse(text);
		}
	}
}
