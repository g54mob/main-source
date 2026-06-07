using System.Collections.Generic;
using CLanguage.Compiler;
using CLanguage.Interpreter;
using CLanguage.Types;

namespace CLanguage.Syntax
{
	public class Block : Statement
	{
		public VariableScope VariableScope { get; }

		public List<Statement> Statements { get; }

		public Block? Parent { get; set; }

		public override bool AlwaysReturns => false;

		public List<CompiledVariable> Variables { get; private set; }

		public List<CompiledFunction> Functions { get; private set; }

		public Dictionary<string, CType> Typedefs { get; private set; }

		public List<Statement> InitStatements { get; private set; }

		public Dictionary<string, CStructType> Structures { get; private set; }

		public Dictionary<string, CEnumType> Enums { get; private set; }

		public Block(VariableScope variableScope, IEnumerable<Statement> statements)
		{
		}

		public Block(VariableScope variableScope)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public void AddStatement(Statement? stmt)
		{
		}

		public void AddStatements(IEnumerable<Statement> stmts)
		{
		}

		protected override void DoEmit(EmitContext ec)
		{
		}

		public void AddVariable(string name, CType ctype)
		{
		}

		public override void AddDeclarationToBlock(BlockContext context)
		{
		}
	}
}
