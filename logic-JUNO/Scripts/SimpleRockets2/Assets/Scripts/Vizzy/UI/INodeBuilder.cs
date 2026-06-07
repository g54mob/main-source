using System.Collections.Generic;
using Assets.Scripts.Vizzy.UI.Elements;
using ModApi.Craft.Program;
using ModApi.Craft.Program.Instructions;

namespace Assets.Scripts.Vizzy.UI
{
	public interface INodeBuilder
	{
		ExpressionElementScript BuildExpressionElement(ProgramExpression expression, NodeFormat.Token token);

		InstructionElementScript BuildInstructionElement(ProgramInstruction instruction);

		BlockElementScript BuildProgramNodeElement(ProgramNode node);

		List<BlockElementScript> CloneBlock(BlockElementScript block, bool cloneChain);

		void RebuildChildren(BlockElementScript blockScript);
	}
}
