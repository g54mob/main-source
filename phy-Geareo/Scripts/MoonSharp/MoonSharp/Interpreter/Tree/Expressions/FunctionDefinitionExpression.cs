using System;
using System.Collections.Generic;
using MoonSharp.Interpreter.Debugging;
using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter.Tree.Expressions
{
	internal class FunctionDefinitionExpression : Expression, IClosureBuilder
	{
		private SymbolRef[] m_ParamNames;

		private Statement m_Statement;

		private RuntimeScopeFrame m_StackFrame;

		private List<SymbolRef> m_Closure;

		private bool m_HasVarArgs;

		private Instruction m_ClosureInstruction;

		private bool m_UsesGlobalEnv;

		private SymbolRef m_Env;

		private SourceRef m_Begin;

		private SourceRef m_End;

		public FunctionDefinitionExpression(ScriptLoadingContext lcontext, bool usesGlobalEnv)
			: base(null)
		{
		}

		public FunctionDefinitionExpression(ScriptLoadingContext lcontext, bool pushSelfParam, bool isLambda)
			: base(null)
		{
		}

		private FunctionDefinitionExpression(ScriptLoadingContext lcontext, bool pushSelfParam, bool usesGlobalEnv, bool isLambda)
			: base(null)
		{
		}

		private Statement CreateLambdaBody(ScriptLoadingContext lcontext)
		{
			return null;
		}

		private Statement CreateBody(ScriptLoadingContext lcontext)
		{
			return null;
		}

		private List<string> BuildParamList(ScriptLoadingContext lcontext, bool pushSelfParam, Token openBracketToken, bool isLambda)
		{
			return null;
		}

		private SymbolRef[] DefineArguments(List<string> paramnames, ScriptLoadingContext lcontext)
		{
			return null;
		}

		public SymbolRef CreateUpvalue(BuildTimeScope scope, SymbolRef symbol)
		{
			return null;
		}

		public override DynValue Eval(ScriptExecutionContext context)
		{
			return null;
		}

		public int CompileBody(ByteCode bc, string friendlyName)
		{
			return 0;
		}

		public int Compile(ByteCode bc, Func<int> afterDecl, string friendlyName)
		{
			return 0;
		}

		public override void Compile(ByteCode bc)
		{
		}
	}
}
