using System.Collections.Generic;
using Trivial.Mono.Cecil;
using Trivial.Mono.Cecil.Cil;
using Trivial.Mono.Collections.Generic;

namespace Trivial.CodeSecurity.LoopDetection
{
	internal sealed class LoopDetectionInstructionPatcher
	{
		public struct LoopingInstruction
		{
			public Instruction loopStart;

			public Instruction loopJump;
		}

		private List<LoopingInstruction> foundLoopingInstructions = new List<LoopingInstruction>();

		private ModuleDefinition module;

		private MethodReference enterExecutionTimingMethod;

		private MethodReference exitExecutionTimingMethod;

		public MethodReference EnterExecutionTimingMethod
		{
			get
			{
				if (enterExecutionTimingMethod == null)
				{
					enterExecutionTimingMethod = module.ImportReference(typeof(ExecutionTimingServices).GetMethod("EnterTimedExecutionContext"));
				}
				return enterExecutionTimingMethod;
			}
		}

		public MethodReference ExitExecutionTimingMethod
		{
			get
			{
				if (exitExecutionTimingMethod == null)
				{
					exitExecutionTimingMethod = module.ImportReference(typeof(ExecutionTimingServices).GetMethod("ExitTimedExecutionContext"));
				}
				return exitExecutionTimingMethod;
			}
		}

		public LoopDetectionInstructionPatcher(ModuleDefinition module)
		{
			this.module = module;
		}

		public bool DetectPotentialLoopInstructions(Collection<Instruction> instructions)
		{
			foundLoopingInstructions.Clear();
			foreach (Instruction instruction2 in instructions)
			{
				if (instruction2.Operand is Instruction)
				{
					Instruction instruction = instruction2.Operand as Instruction;
					if (instruction2.Offset > instruction.Offset)
					{
						foundLoopingInstructions.Add(new LoopingInstruction
						{
							loopStart = instruction,
							loopJump = instruction2
						});
					}
				}
			}
			return foundLoopingInstructions.Count > 0;
		}

		public bool PatchPotentialLoopInstructions(Collection<Instruction> instructions, LoopDetectionHashGenerator hashGenerator)
		{
			int num = 0;
			foreach (LoopingInstruction foundLoopingInstruction in foundLoopingInstructions)
			{
				int nextHash = hashGenerator.GetNextHash();
				int num2 = instructions.IndexOf(foundLoopingInstruction.loopStart) + 1;
				Instruction item = Instruction.Create(OpCodes.Ldc_I4, nextHash);
				Instruction item2 = Instruction.Create(OpCodes.Call, EnterExecutionTimingMethod);
				instructions.Insert(num2, item);
				instructions.Insert(num2 + 1, item2);
				int num3 = instructions.IndexOf(foundLoopingInstruction.loopJump) + 1;
				Instruction item3 = Instruction.Create(OpCodes.Call, ExitExecutionTimingMethod);
				instructions.Insert(num3, item);
				instructions.Insert(num3 + 1, item3);
				num++;
			}
			return num > 0;
		}
	}
}
