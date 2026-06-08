using Trivial.Mono.Cecil;
using Trivial.Mono.Cecil.Cil;
using Trivial.Mono.Collections.Generic;

namespace Trivial.CodeSecurity.CodeEvaluation
{
	internal class MethodChecker : CodeChecker<MethodDefinition>, ICodeUsageProvider
	{
		private MethodDefinition currentMethod;

		private MethodBody currentMethodBody;

		private Instruction currentInstruction;

		private FieldReferenceChecker fieldReferenceChecker;

		private MethodReferenceChecker methodReferenceChecker;

		private TypeReferenceChecker typeReferenceChecker;

		public MethodChecker()
		{
			fieldReferenceChecker = new FieldReferenceChecker(this);
			methodReferenceChecker = new MethodReferenceChecker(this);
			typeReferenceChecker = new TypeReferenceChecker(this);
		}

		public override void SecurityCheckCode(CodeSecurityContext context, MethodDefinition methodDefinition)
		{
			currentMethod = methodDefinition;
			currentMethodBody = null;
			currentInstruction = null;
			methodReferenceChecker.SecurityCheckCodeMethodReturn(context, methodDefinition.ReturnType);
			if (methodDefinition.HasParameters)
			{
				methodReferenceChecker.SecurityCheckCodeMethodParameters(context, methodDefinition.Parameters);
			}
			if (methodDefinition.HasBody)
			{
				SecurityCheckCodeMethodBody(context, methodDefinition.Body);
			}
		}

		private void SecurityCheckCodeMethodBody(CodeSecurityContext context, MethodBody body)
		{
			currentMethodBody = body;
			if (body.HasVariables)
			{
				SecurityCheckCodeMethodLocals(context, body.Variables);
			}
			foreach (Instruction instruction in body.Instructions)
			{
				SecurityCheckCodeInstruction(context, body, currentInstruction = instruction);
			}
		}

		private void SecurityCheckCodeMethodLocals(CodeSecurityContext context, Collection<VariableDefinition> variables)
		{
			foreach (VariableDefinition variable in variables)
			{
				typeReferenceChecker.SecurityCheckCode(context, variable.VariableType);
			}
		}

		private void SecurityCheckCodeInstruction(CodeSecurityContext context, MethodBody body, Instruction instruction)
		{
			switch (instruction.OpCode.OperandType)
			{
			case OperandType.InlineField:
				typeReferenceChecker.SecurityCheckCode(context, (instruction.Operand as FieldReference).DeclaringType);
				fieldReferenceChecker.SecurityCheckCode(context, instruction.Operand as FieldReference);
				break;
			case OperandType.InlineMethod:
				typeReferenceChecker.SecurityCheckCode(context, (instruction.Operand as MethodReference).DeclaringType);
				methodReferenceChecker.SecurityCheckCode(context, instruction.Operand as MethodReference);
				break;
			case OperandType.InlineType:
				typeReferenceChecker.SecurityCheckCode(context, instruction.Operand as TypeReference);
				break;
			case OperandType.InlineArg:
				typeReferenceChecker.SecurityCheckCode(context, (instruction.Operand as ParameterReference).ParameterType);
				break;
			case OperandType.InlineVar:
			case OperandType.ShortInlineVar:
				typeReferenceChecker.SecurityCheckCode(context, (instruction.Operand as VariableReference).VariableType);
				break;
			}
		}

		public IllegalReferenceUsage GetIllegalUsage()
		{
			if (currentMethodBody != null && currentInstruction != null)
			{
				return new IllegalReferenceUsage(currentMethodBody, currentInstruction);
			}
			return new IllegalReferenceUsage(currentMethod);
		}
	}
}
