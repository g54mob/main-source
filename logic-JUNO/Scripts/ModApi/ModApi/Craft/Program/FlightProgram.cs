using System.Collections.Generic;
using System.Linq;
using ModApi.Craft.Program.Expressions;
using ModApi.Craft.Program.Instructions;

namespace ModApi.Craft.Program
{
	public class FlightProgram : IGetInstructionById
	{
		private List<CustomExpression> _customExpressions = new List<CustomExpression>();

		private List<CustomInstruction> _customInstructions = new List<CustomInstruction>();

		public IReadOnlyList<CustomExpression> CustomExpressions => _customExpressions;

		public IReadOnlyList<CustomInstruction> CustomInstructions => _customInstructions;

		public VariableSet GlobalVariables { get; set; }

		public string Name { get; set; }

		public bool RequiresMfd { get; set; }

		public List<ProgramExpression> RootExpressions { get; private set; } = new List<ProgramExpression>();

		public List<ProgramInstruction> RootInstructions { get; private set; } = new List<ProgramInstruction>();

		public FlightProgram()
		{
			GlobalVariables = new VariableSet();
		}

		public void AddCustomExpression(CustomExpression customExpression)
		{
			_customExpressions.Add(customExpression);
		}

		public void AddCustomInstruction(CustomInstruction customInstruction)
		{
			_customInstructions.Add(customInstruction);
		}

		public CustomExpression GetCustomExpression(string name)
		{
			return CustomExpressions.Where((CustomExpression x) => x.Name == name).FirstOrDefault();
		}

		public CustomInstruction GetCustomInstruction(string name)
		{
			return CustomInstructions.Where((CustomInstruction x) => x.Name == name).FirstOrDefault();
		}

		ProgramInstruction IGetInstructionById.GetInstructionById(int instructionId)
		{
			foreach (ProgramInstruction rootInstruction in RootInstructions)
			{
				ProgramInstruction instructionById = ((IGetInstructionById)rootInstruction).GetInstructionById(instructionId);
				if (instructionById != null)
				{
					return instructionById;
				}
			}
			return null;
		}

		public void RemoveCustomExpression(CustomExpression customExpression)
		{
			_customExpressions.Remove(customExpression);
		}

		public void RemoveCustomInstruction(CustomInstruction customInstruction)
		{
			_customInstructions.Remove(customInstruction);
		}
	}
}
