using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace Stonescript.Compiler
{
	[GeneratedCode("ANTLR", "4.9.1")]
	[DebuggerNonUserCode]
	[CLSCompliant(false)]
	public class StonescriptParserBaseVisitor<Result> : AbstractParseTreeVisitor<Result>, IStonescriptParserVisitor<Result>, IParseTreeVisitor<Result>
	{
		public virtual Result VisitProgram([NotNull] StonescriptParser.ProgramContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitBlock([NotNull] StonescriptParser.BlockContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitStmt([NotNull] StonescriptParser.StmtContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitCmd_stmt([NotNull] StonescriptParser.Cmd_stmtContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitLvalue([NotNull] StonescriptParser.LvalueContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitAssignment([NotNull] StonescriptParser.AssignmentContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitInc_stmt([NotNull] StonescriptParser.Inc_stmtContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitDecl_stmt([NotNull] StonescriptParser.Decl_stmtContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitImport_stmt([NotNull] StonescriptParser.Import_stmtContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitNew_stmt([NotNull] StonescriptParser.New_stmtContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitQualifiedId([NotNull] StonescriptParser.QualifiedIdContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitObject([NotNull] StonescriptParser.ObjectContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitArray([NotNull] StonescriptParser.ArrayContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitExpression([NotNull] StonescriptParser.ExpressionContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitFuncdef([NotNull] StonescriptParser.FuncdefContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitLambda([NotNull] StonescriptParser.LambdaContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitVarlist([NotNull] StonescriptParser.VarlistContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitInvocation([NotNull] StonescriptParser.InvocationContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitParamlist([NotNull] StonescriptParser.ParamlistContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitIf_stmt([NotNull] StonescriptParser.If_stmtContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitElse_if_stmt([NotNull] StonescriptParser.Else_if_stmtContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitElse_stmt([NotNull] StonescriptParser.Else_stmtContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitFor_stmt([NotNull] StonescriptParser.For_stmtContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitBreak_stmt([NotNull] StonescriptParser.Break_stmtContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitContinue_stmt([NotNull] StonescriptParser.Continue_stmtContext context)
		{
			return VisitChildren(context);
		}

		public virtual Result VisitReturn_stmt([NotNull] StonescriptParser.Return_stmtContext context)
		{
			return VisitChildren(context);
		}
	}
}
