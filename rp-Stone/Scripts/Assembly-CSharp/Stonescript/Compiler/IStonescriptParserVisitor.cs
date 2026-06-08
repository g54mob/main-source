using System;
using System.CodeDom.Compiler;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace Stonescript.Compiler
{
	[GeneratedCode("ANTLR", "4.9.1")]
	[CLSCompliant(false)]
	public interface IStonescriptParserVisitor<Result> : IParseTreeVisitor<Result>
	{
		Result VisitProgram([NotNull] StonescriptParser.ProgramContext context);

		Result VisitBlock([NotNull] StonescriptParser.BlockContext context);

		Result VisitStmt([NotNull] StonescriptParser.StmtContext context);

		Result VisitCmd_stmt([NotNull] StonescriptParser.Cmd_stmtContext context);

		Result VisitLvalue([NotNull] StonescriptParser.LvalueContext context);

		Result VisitAssignment([NotNull] StonescriptParser.AssignmentContext context);

		Result VisitInc_stmt([NotNull] StonescriptParser.Inc_stmtContext context);

		Result VisitDecl_stmt([NotNull] StonescriptParser.Decl_stmtContext context);

		Result VisitImport_stmt([NotNull] StonescriptParser.Import_stmtContext context);

		Result VisitNew_stmt([NotNull] StonescriptParser.New_stmtContext context);

		Result VisitQualifiedId([NotNull] StonescriptParser.QualifiedIdContext context);

		Result VisitObject([NotNull] StonescriptParser.ObjectContext context);

		Result VisitArray([NotNull] StonescriptParser.ArrayContext context);

		Result VisitExpression([NotNull] StonescriptParser.ExpressionContext context);

		Result VisitFuncdef([NotNull] StonescriptParser.FuncdefContext context);

		Result VisitLambda([NotNull] StonescriptParser.LambdaContext context);

		Result VisitVarlist([NotNull] StonescriptParser.VarlistContext context);

		Result VisitInvocation([NotNull] StonescriptParser.InvocationContext context);

		Result VisitParamlist([NotNull] StonescriptParser.ParamlistContext context);

		Result VisitIf_stmt([NotNull] StonescriptParser.If_stmtContext context);

		Result VisitElse_if_stmt([NotNull] StonescriptParser.Else_if_stmtContext context);

		Result VisitElse_stmt([NotNull] StonescriptParser.Else_stmtContext context);

		Result VisitFor_stmt([NotNull] StonescriptParser.For_stmtContext context);

		Result VisitBreak_stmt([NotNull] StonescriptParser.Break_stmtContext context);

		Result VisitContinue_stmt([NotNull] StonescriptParser.Continue_stmtContext context);

		Result VisitReturn_stmt([NotNull] StonescriptParser.Return_stmtContext context);
	}
}
