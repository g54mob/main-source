using System;
using System.IO;
using Trivial.Mono.Cecil;
using Trivial.Mono.Cecil.Cil;
using Trivial.Mono.Collections.Generic;

namespace Trivial.CodeSecurity.LoopDetection
{
	public class LoopDetectionEngine : IDisposable
	{
		private byte[] definitionBytes;

		private AssemblyDefinition definition;

		public LoopDetectionEngine(string assemblyDefinitionFile)
		{
			if (assemblyDefinitionFile == null)
			{
				throw new ArgumentNullException("assemblyDefinitionFile");
			}
			using Stream loadStream = File.OpenRead(assemblyDefinitionFile);
			InitializeFromStream(loadStream);
		}

		public LoopDetectionEngine(byte[] assemblyImage)
		{
			if (assemblyImage == null)
			{
				throw new ArgumentNullException("assemblyImage");
			}
			Stream loadStream = new MemoryStream(assemblyImage);
			InitializeFromStream(loadStream);
		}

		public LoopDetectionEngine(Stream assemblyDefinitionStream)
		{
			if (assemblyDefinitionStream == null)
			{
				throw new ArgumentNullException("assemblyDefinitionStream");
			}
			InitializeFromStream(assemblyDefinitionStream);
		}

		public void Dispose()
		{
			if (definition != null)
			{
				definition.Dispose();
				definition = null;
			}
		}

		public bool LoopDetectAndPatchAssembly()
		{
			LoopDetectionInstructionPatcher loopDetectionInstructionPatcher = new LoopDetectionInstructionPatcher(definition.MainModule);
			LoopDetectionHashGenerator hashGenerator = new LoopDetectionHashGenerator();
			bool result = false;
			foreach (TypeDefinition type in definition.MainModule.Types)
			{
				foreach (MethodDefinition method in type.Methods)
				{
					Collection<Instruction> instructions = method.Body.Instructions;
					if (instructions != null && instructions.Count > 0 && loopDetectionInstructionPatcher.DetectPotentialLoopInstructions(instructions) && loopDetectionInstructionPatcher.PatchPotentialLoopInstructions(instructions, hashGenerator))
					{
						result = true;
					}
				}
			}
			return result;
		}

		private void InitializeFromStream(Stream loadStream, Stream symbolsStream = null)
		{
			ReaderParameters readerParameters = new ReaderParameters();
			readerParameters.ReadSymbols = false;
			definition = AssemblyDefinition.ReadAssembly(loadStream, readerParameters);
			if (definition == null)
			{
				throw new Exception("Failed to read assembly definition for loop evaluation");
			}
		}
	}
}
