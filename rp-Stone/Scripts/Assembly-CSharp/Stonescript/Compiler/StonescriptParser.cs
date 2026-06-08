using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace Stonescript.Compiler
{
	[GeneratedCode("ANTLR", "4.9.1")]
	[CLSCompliant(false)]
	public class StonescriptParser : Parser
	{
		public class ProgramContext : ParserRuleContext
		{
			public override int RuleIndex => 0;

			[DebuggerNonUserCode]
			public ITerminalNode Eof()
			{
				return GetToken(-1, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode[] NEWLINE()
			{
				return GetTokens(63);
			}

			[DebuggerNonUserCode]
			public ITerminalNode NEWLINE(int i)
			{
				return GetToken(63, i);
			}

			[DebuggerNonUserCode]
			public StmtContext[] stmt()
			{
				return GetRuleContexts<StmtContext>();
			}

			[DebuggerNonUserCode]
			public StmtContext stmt(int i)
			{
				return GetRuleContext<StmtContext>(i);
			}

			[DebuggerNonUserCode]
			public BlockContext[] block()
			{
				return GetRuleContexts<BlockContext>();
			}

			[DebuggerNonUserCode]
			public BlockContext block(int i)
			{
				return GetRuleContext<BlockContext>(i);
			}

			public ProgramContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitProgram(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class BlockContext : ParserRuleContext
		{
			public override int RuleIndex => 1;

			[DebuggerNonUserCode]
			public ITerminalNode INDENT()
			{
				return GetToken(1, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode DEDENT()
			{
				return GetToken(2, 0);
			}

			[DebuggerNonUserCode]
			public StmtContext[] stmt()
			{
				return GetRuleContexts<StmtContext>();
			}

			[DebuggerNonUserCode]
			public StmtContext stmt(int i)
			{
				return GetRuleContext<StmtContext>(i);
			}

			[DebuggerNonUserCode]
			public BlockContext[] block()
			{
				return GetRuleContexts<BlockContext>();
			}

			[DebuggerNonUserCode]
			public BlockContext block(int i)
			{
				return GetRuleContext<BlockContext>(i);
			}

			[DebuggerNonUserCode]
			public ITerminalNode[] NEWLINE()
			{
				return GetTokens(63);
			}

			[DebuggerNonUserCode]
			public ITerminalNode NEWLINE(int i)
			{
				return GetToken(63, i);
			}

			public BlockContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitBlock(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class StmtContext : ParserRuleContext
		{
			public override int RuleIndex => 2;

			[DebuggerNonUserCode]
			public ITerminalNode NEWLINE()
			{
				return GetToken(63, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode Eof()
			{
				return GetToken(-1, 0);
			}

			[DebuggerNonUserCode]
			public AssignmentContext assignment()
			{
				return GetRuleContext<AssignmentContext>(0);
			}

			[DebuggerNonUserCode]
			public Break_stmtContext break_stmt()
			{
				return GetRuleContext<Break_stmtContext>(0);
			}

			[DebuggerNonUserCode]
			public Continue_stmtContext continue_stmt()
			{
				return GetRuleContext<Continue_stmtContext>(0);
			}

			[DebuggerNonUserCode]
			public Return_stmtContext return_stmt()
			{
				return GetRuleContext<Return_stmtContext>(0);
			}

			[DebuggerNonUserCode]
			public InvocationContext invocation()
			{
				return GetRuleContext<InvocationContext>(0);
			}

			[DebuggerNonUserCode]
			public Cmd_stmtContext cmd_stmt()
			{
				return GetRuleContext<Cmd_stmtContext>(0);
			}

			[DebuggerNonUserCode]
			public Decl_stmtContext decl_stmt()
			{
				return GetRuleContext<Decl_stmtContext>(0);
			}

			[DebuggerNonUserCode]
			public Import_stmtContext import_stmt()
			{
				return GetRuleContext<Import_stmtContext>(0);
			}

			[DebuggerNonUserCode]
			public New_stmtContext new_stmt()
			{
				return GetRuleContext<New_stmtContext>(0);
			}

			[DebuggerNonUserCode]
			public Inc_stmtContext inc_stmt()
			{
				return GetRuleContext<Inc_stmtContext>(0);
			}

			[DebuggerNonUserCode]
			public If_stmtContext if_stmt()
			{
				return GetRuleContext<If_stmtContext>(0);
			}

			[DebuggerNonUserCode]
			public FuncdefContext funcdef()
			{
				return GetRuleContext<FuncdefContext>(0);
			}

			[DebuggerNonUserCode]
			public For_stmtContext for_stmt()
			{
				return GetRuleContext<For_stmtContext>(0);
			}

			public StmtContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitStmt(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class Cmd_stmtContext : ParserRuleContext
		{
			public override int RuleIndex => 3;

			[DebuggerNonUserCode]
			public ITerminalNode COMMAND()
			{
				return GetToken(3, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode[] COMMAND_SPACE_SEP()
			{
				return GetTokens(71);
			}

			[DebuggerNonUserCode]
			public ITerminalNode COMMAND_SPACE_SEP(int i)
			{
				return GetToken(71, i);
			}

			[DebuggerNonUserCode]
			public ITerminalNode[] COMMAND_COMMA_SEP()
			{
				return GetTokens(66);
			}

			[DebuggerNonUserCode]
			public ITerminalNode COMMAND_COMMA_SEP(int i)
			{
				return GetToken(66, i);
			}

			[DebuggerNonUserCode]
			public ITerminalNode[] COMMAND_COMMA_PARAM()
			{
				return GetTokens(68);
			}

			[DebuggerNonUserCode]
			public ITerminalNode COMMAND_COMMA_PARAM(int i)
			{
				return GetToken(68, i);
			}

			[DebuggerNonUserCode]
			public ITerminalNode[] COMMAND_COMMA_ASCII_BLOCK()
			{
				return GetTokens(67);
			}

			[DebuggerNonUserCode]
			public ITerminalNode COMMAND_COMMA_ASCII_BLOCK(int i)
			{
				return GetToken(67, i);
			}

			[DebuggerNonUserCode]
			public ITerminalNode[] COMMAND_SPACE_PARAM()
			{
				return GetTokens(73);
			}

			[DebuggerNonUserCode]
			public ITerminalNode COMMAND_SPACE_PARAM(int i)
			{
				return GetToken(73, i);
			}

			[DebuggerNonUserCode]
			public ITerminalNode[] COMMAND_SPACE_ASCII_BLOCK()
			{
				return GetTokens(72);
			}

			[DebuggerNonUserCode]
			public ITerminalNode COMMAND_SPACE_ASCII_BLOCK(int i)
			{
				return GetToken(72, i);
			}

			public Cmd_stmtContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitCmd_stmt(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class LvalueContext : ParserRuleContext
		{
			public override int RuleIndex => 4;

			[DebuggerNonUserCode]
			public ITerminalNode ID()
			{
				return GetToken(57, 0);
			}

			[DebuggerNonUserCode]
			public ExpressionContext[] expression()
			{
				return GetRuleContexts<ExpressionContext>();
			}

			[DebuggerNonUserCode]
			public ExpressionContext expression(int i)
			{
				return GetRuleContext<ExpressionContext>(i);
			}

			[DebuggerNonUserCode]
			public ITerminalNode DOT()
			{
				return GetToken(51, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode LBRACKET()
			{
				return GetToken(22, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode RBRACKET()
			{
				return GetToken(23, 0);
			}

			public LvalueContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitLvalue(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class AssignmentContext : ParserRuleContext
		{
			public override int RuleIndex => 5;

			[DebuggerNonUserCode]
			public LvalueContext lvalue()
			{
				return GetRuleContext<LvalueContext>(0);
			}

			[DebuggerNonUserCode]
			public ExpressionContext expression()
			{
				return GetRuleContext<ExpressionContext>(0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode EQUAL()
			{
				return GetToken(28, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode PLUS_EQUAL()
			{
				return GetToken(34, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode MINUS_EQUAL()
			{
				return GetToken(35, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode MULTIPLY_EQUAL()
			{
				return GetToken(36, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode DIVIDE_EQUAL()
			{
				return GetToken(37, 0);
			}

			public AssignmentContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitAssignment(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class Inc_stmtContext : ParserRuleContext
		{
			public override int RuleIndex => 6;

			[DebuggerNonUserCode]
			public QualifiedIdContext qualifiedId()
			{
				return GetRuleContext<QualifiedIdContext>(0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode INCREMENT()
			{
				return GetToken(38, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode DECREMENT()
			{
				return GetToken(39, 0);
			}

			public Inc_stmtContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitInc_stmt(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class Decl_stmtContext : ParserRuleContext
		{
			public override int RuleIndex => 7;

			[DebuggerNonUserCode]
			public ITerminalNode ID()
			{
				return GetToken(57, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode VAR()
			{
				return GetToken(5, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode CONST()
			{
				return GetToken(6, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode EQUAL()
			{
				return GetToken(28, 0);
			}

			[DebuggerNonUserCode]
			public ExpressionContext expression()
			{
				return GetRuleContext<ExpressionContext>(0);
			}

			public Decl_stmtContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitDecl_stmt(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class Import_stmtContext : ParserRuleContext
		{
			public override int RuleIndex => 8;

			[DebuggerNonUserCode]
			public ITerminalNode IMPORT()
			{
				return GetToken(8, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode ID()
			{
				return GetToken(57, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode PATH()
			{
				return GetToken(59, 0);
			}

			public Import_stmtContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitImport_stmt(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class New_stmtContext : ParserRuleContext
		{
			public override int RuleIndex => 9;

			[DebuggerNonUserCode]
			public ITerminalNode NEW()
			{
				return GetToken(7, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode ID()
			{
				return GetToken(57, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode PATH()
			{
				return GetToken(59, 0);
			}

			public New_stmtContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitNew_stmt(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class QualifiedIdContext : ParserRuleContext
		{
			public override int RuleIndex => 10;

			[DebuggerNonUserCode]
			public ITerminalNode[] ID()
			{
				return GetTokens(57);
			}

			[DebuggerNonUserCode]
			public ITerminalNode ID(int i)
			{
				return GetToken(57, i);
			}

			[DebuggerNonUserCode]
			public ITerminalNode[] DOT()
			{
				return GetTokens(51);
			}

			[DebuggerNonUserCode]
			public ITerminalNode DOT(int i)
			{
				return GetToken(51, i);
			}

			public QualifiedIdContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitQualifiedId(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class ObjectContext : ParserRuleContext
		{
			public override int RuleIndex => 11;

			[DebuggerNonUserCode]
			public ITerminalNode LCBRACKET()
			{
				return GetToken(24, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode RCBRACKET()
			{
				return GetToken(25, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode[] ID()
			{
				return GetTokens(57);
			}

			[DebuggerNonUserCode]
			public ITerminalNode ID(int i)
			{
				return GetToken(57, i);
			}

			[DebuggerNonUserCode]
			public ITerminalNode[] COLON()
			{
				return GetTokens(46);
			}

			[DebuggerNonUserCode]
			public ITerminalNode COLON(int i)
			{
				return GetToken(46, i);
			}

			[DebuggerNonUserCode]
			public ExpressionContext[] expression()
			{
				return GetRuleContexts<ExpressionContext>();
			}

			[DebuggerNonUserCode]
			public ExpressionContext expression(int i)
			{
				return GetRuleContext<ExpressionContext>(i);
			}

			[DebuggerNonUserCode]
			public ITerminalNode[] COMMA()
			{
				return GetTokens(49);
			}

			[DebuggerNonUserCode]
			public ITerminalNode COMMA(int i)
			{
				return GetToken(49, i);
			}

			public ObjectContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitObject(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class ArrayContext : ParserRuleContext
		{
			public override int RuleIndex => 12;

			[DebuggerNonUserCode]
			public ITerminalNode LBRACKET()
			{
				return GetToken(22, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode RBRACKET()
			{
				return GetToken(23, 0);
			}

			[DebuggerNonUserCode]
			public ExpressionContext[] expression()
			{
				return GetRuleContexts<ExpressionContext>();
			}

			[DebuggerNonUserCode]
			public ExpressionContext expression(int i)
			{
				return GetRuleContext<ExpressionContext>(i);
			}

			[DebuggerNonUserCode]
			public ITerminalNode[] COMMA()
			{
				return GetTokens(49);
			}

			[DebuggerNonUserCode]
			public ITerminalNode COMMA(int i)
			{
				return GetToken(49, i);
			}

			public ArrayContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitArray(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class ExpressionContext : ParserRuleContext
		{
			public override int RuleIndex => 13;

			[DebuggerNonUserCode]
			public QualifiedIdContext qualifiedId()
			{
				return GetRuleContext<QualifiedIdContext>(0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode NUMBER()
			{
				return GetToken(56, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode ASCII_BLOCK()
			{
				return GetToken(4, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode TRUE()
			{
				return GetToken(10, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode FALSE()
			{
				return GetToken(11, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode NULL()
			{
				return GetToken(12, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode COLOR()
			{
				return GetToken(58, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode STRING_LITERAL()
			{
				return GetToken(60, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode[] ID()
			{
				return GetTokens(57);
			}

			[DebuggerNonUserCode]
			public ITerminalNode ID(int i)
			{
				return GetToken(57, i);
			}

			[DebuggerNonUserCode]
			public ITerminalNode UNQUOTED_STRING()
			{
				return GetToken(61, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode THIS()
			{
				return GetToken(9, 0);
			}

			[DebuggerNonUserCode]
			public ObjectContext @object()
			{
				return GetRuleContext<ObjectContext>(0);
			}

			[DebuggerNonUserCode]
			public ArrayContext array()
			{
				return GetRuleContext<ArrayContext>(0);
			}

			[DebuggerNonUserCode]
			public LambdaContext lambda()
			{
				return GetRuleContext<LambdaContext>(0);
			}

			[DebuggerNonUserCode]
			public New_stmtContext new_stmt()
			{
				return GetRuleContext<New_stmtContext>(0);
			}

			[DebuggerNonUserCode]
			public Import_stmtContext import_stmt()
			{
				return GetRuleContext<Import_stmtContext>(0);
			}

			[DebuggerNonUserCode]
			public Inc_stmtContext inc_stmt()
			{
				return GetRuleContext<Inc_stmtContext>(0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode LPAREN()
			{
				return GetToken(20, 0);
			}

			[DebuggerNonUserCode]
			public ExpressionContext[] expression()
			{
				return GetRuleContexts<ExpressionContext>();
			}

			[DebuggerNonUserCode]
			public ExpressionContext expression(int i)
			{
				return GetRuleContext<ExpressionContext>(i);
			}

			[DebuggerNonUserCode]
			public ITerminalNode RPAREN()
			{
				return GetToken(21, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode MINUS()
			{
				return GetToken(31, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode NOT()
			{
				return GetToken(40, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode MULTIPLY()
			{
				return GetToken(32, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode DIVIDE()
			{
				return GetToken(33, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode MOD()
			{
				return GetToken(48, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode PLUS()
			{
				return GetToken(30, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode GREATER_THAN()
			{
				return GetToken(53, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode GREATER_THAN_EQUAL()
			{
				return GetToken(17, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode LESS_THAN()
			{
				return GetToken(18, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode LESS_THAN_EQUAL()
			{
				return GetToken(19, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode EQUAL()
			{
				return GetToken(28, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode DOUBLE_EQUAL()
			{
				return GetToken(29, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode NOT_EQUAL()
			{
				return GetToken(41, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode DOUBLE_AND()
			{
				return GetToken(45, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode AND()
			{
				return GetToken(43, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode DOUBLE_OR()
			{
				return GetToken(44, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode OR()
			{
				return GetToken(42, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode DOT()
			{
				return GetToken(51, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode NEWLINE()
			{
				return GetToken(63, 0);
			}

			[DebuggerNonUserCode]
			public ParamlistContext paramlist()
			{
				return GetRuleContext<ParamlistContext>(0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode LBRACKET()
			{
				return GetToken(22, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode RBRACKET()
			{
				return GetToken(23, 0);
			}

			public ExpressionContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitExpression(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class FuncdefContext : ParserRuleContext
		{
			public override int RuleIndex => 14;

			[DebuggerNonUserCode]
			public ITerminalNode FUNCTION()
			{
				return GetToken(13, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode ID()
			{
				return GetToken(57, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode LPAREN()
			{
				return GetToken(20, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode RPAREN()
			{
				return GetToken(21, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode NEWLINE()
			{
				return GetToken(63, 0);
			}

			[DebuggerNonUserCode]
			public BlockContext block()
			{
				return GetRuleContext<BlockContext>(0);
			}

			[DebuggerNonUserCode]
			public VarlistContext varlist()
			{
				return GetRuleContext<VarlistContext>(0);
			}

			public FuncdefContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitFuncdef(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class LambdaContext : ParserRuleContext
		{
			public override int RuleIndex => 15;

			[DebuggerNonUserCode]
			public ITerminalNode FUNCTION()
			{
				return GetToken(13, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode LPAREN()
			{
				return GetToken(20, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode RPAREN()
			{
				return GetToken(21, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode NEWLINE()
			{
				return GetToken(63, 0);
			}

			[DebuggerNonUserCode]
			public BlockContext block()
			{
				return GetRuleContext<BlockContext>(0);
			}

			[DebuggerNonUserCode]
			public VarlistContext varlist()
			{
				return GetRuleContext<VarlistContext>(0);
			}

			public LambdaContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitLambda(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class VarlistContext : ParserRuleContext
		{
			public override int RuleIndex => 16;

			[DebuggerNonUserCode]
			public ITerminalNode[] ID()
			{
				return GetTokens(57);
			}

			[DebuggerNonUserCode]
			public ITerminalNode ID(int i)
			{
				return GetToken(57, i);
			}

			[DebuggerNonUserCode]
			public ITerminalNode[] COMMA()
			{
				return GetTokens(49);
			}

			[DebuggerNonUserCode]
			public ITerminalNode COMMA(int i)
			{
				return GetToken(49, i);
			}

			public VarlistContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitVarlist(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class InvocationContext : ParserRuleContext
		{
			public override int RuleIndex => 17;

			[DebuggerNonUserCode]
			public ExpressionContext expression()
			{
				return GetRuleContext<ExpressionContext>(0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode LPAREN()
			{
				return GetToken(20, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode RPAREN()
			{
				return GetToken(21, 0);
			}

			[DebuggerNonUserCode]
			public ParamlistContext paramlist()
			{
				return GetRuleContext<ParamlistContext>(0);
			}

			public InvocationContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitInvocation(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class ParamlistContext : ParserRuleContext
		{
			public override int RuleIndex => 18;

			[DebuggerNonUserCode]
			public ExpressionContext[] expression()
			{
				return GetRuleContexts<ExpressionContext>();
			}

			[DebuggerNonUserCode]
			public ExpressionContext expression(int i)
			{
				return GetRuleContext<ExpressionContext>(i);
			}

			[DebuggerNonUserCode]
			public ITerminalNode[] COMMA()
			{
				return GetTokens(49);
			}

			[DebuggerNonUserCode]
			public ITerminalNode COMMA(int i)
			{
				return GetToken(49, i);
			}

			public ParamlistContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitParamlist(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class If_stmtContext : ParserRuleContext
		{
			public override int RuleIndex => 19;

			[DebuggerNonUserCode]
			public ITerminalNode QUESTION()
			{
				return GetToken(47, 0);
			}

			[DebuggerNonUserCode]
			public ExpressionContext expression()
			{
				return GetRuleContext<ExpressionContext>(0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode NEWLINE()
			{
				return GetToken(63, 0);
			}

			[DebuggerNonUserCode]
			public BlockContext block()
			{
				return GetRuleContext<BlockContext>(0);
			}

			[DebuggerNonUserCode]
			public Else_if_stmtContext[] else_if_stmt()
			{
				return GetRuleContexts<Else_if_stmtContext>();
			}

			[DebuggerNonUserCode]
			public Else_if_stmtContext else_if_stmt(int i)
			{
				return GetRuleContext<Else_if_stmtContext>(i);
			}

			[DebuggerNonUserCode]
			public Else_stmtContext else_stmt()
			{
				return GetRuleContext<Else_stmtContext>(0);
			}

			public If_stmtContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitIf_stmt(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class Else_if_stmtContext : ParserRuleContext
		{
			public override int RuleIndex => 20;

			[DebuggerNonUserCode]
			public ITerminalNode COLON()
			{
				return GetToken(46, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode QUESTION()
			{
				return GetToken(47, 0);
			}

			[DebuggerNonUserCode]
			public ExpressionContext expression()
			{
				return GetRuleContext<ExpressionContext>(0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode NEWLINE()
			{
				return GetToken(63, 0);
			}

			[DebuggerNonUserCode]
			public BlockContext block()
			{
				return GetRuleContext<BlockContext>(0);
			}

			public Else_if_stmtContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitElse_if_stmt(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class Else_stmtContext : ParserRuleContext
		{
			public override int RuleIndex => 21;

			[DebuggerNonUserCode]
			public ITerminalNode COLON()
			{
				return GetToken(46, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode NEWLINE()
			{
				return GetToken(63, 0);
			}

			[DebuggerNonUserCode]
			public BlockContext block()
			{
				return GetRuleContext<BlockContext>(0);
			}

			public Else_stmtContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitElse_stmt(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class For_stmtContext : ParserRuleContext
		{
			public override int RuleIndex => 22;

			[DebuggerNonUserCode]
			public ITerminalNode FOR()
			{
				return GetToken(15, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode ID()
			{
				return GetToken(57, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode EQUAL()
			{
				return GetToken(28, 0);
			}

			[DebuggerNonUserCode]
			public ExpressionContext[] expression()
			{
				return GetRuleContexts<ExpressionContext>();
			}

			[DebuggerNonUserCode]
			public ExpressionContext expression(int i)
			{
				return GetRuleContext<ExpressionContext>(i);
			}

			[DebuggerNonUserCode]
			public ITerminalNode DOUBLE_DOT()
			{
				return GetToken(50, 0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode NEWLINE()
			{
				return GetToken(63, 0);
			}

			[DebuggerNonUserCode]
			public BlockContext block()
			{
				return GetRuleContext<BlockContext>(0);
			}

			[DebuggerNonUserCode]
			public ITerminalNode COLON()
			{
				return GetToken(46, 0);
			}

			public For_stmtContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitFor_stmt(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class Break_stmtContext : ParserRuleContext
		{
			public override int RuleIndex => 23;

			[DebuggerNonUserCode]
			public ITerminalNode BREAK()
			{
				return GetToken(26, 0);
			}

			public Break_stmtContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitBreak_stmt(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class Continue_stmtContext : ParserRuleContext
		{
			public override int RuleIndex => 24;

			[DebuggerNonUserCode]
			public ITerminalNode CONTINUE()
			{
				return GetToken(27, 0);
			}

			public Continue_stmtContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitContinue_stmt(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		public class Return_stmtContext : ParserRuleContext
		{
			public override int RuleIndex => 25;

			[DebuggerNonUserCode]
			public ITerminalNode RETURN()
			{
				return GetToken(14, 0);
			}

			[DebuggerNonUserCode]
			public ExpressionContext expression()
			{
				return GetRuleContext<ExpressionContext>(0);
			}

			public Return_stmtContext(ParserRuleContext parent, int invokingState)
				: base(parent, invokingState)
			{
			}

			[DebuggerNonUserCode]
			public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
			{
				if (visitor is IStonescriptParserVisitor<TResult> stonescriptParserVisitor)
				{
					return stonescriptParserVisitor.VisitReturn_stmt(this);
				}
				return visitor.VisitChildren(this);
			}
		}

		protected static DFA[] decisionToDFA;

		protected static PredictionContextCache sharedContextCache;

		public const int INDENT = 1;

		public const int DEDENT = 2;

		public const int COMMAND = 3;

		public const int ASCII_BLOCK = 4;

		public const int VAR = 5;

		public const int CONST = 6;

		public const int NEW = 7;

		public const int IMPORT = 8;

		public const int THIS = 9;

		public const int TRUE = 10;

		public const int FALSE = 11;

		public const int NULL = 12;

		public const int FUNCTION = 13;

		public const int RETURN = 14;

		public const int FOR = 15;

		public const int IN = 16;

		public const int GREATER_THAN_EQUAL = 17;

		public const int LESS_THAN = 18;

		public const int LESS_THAN_EQUAL = 19;

		public const int LPAREN = 20;

		public const int RPAREN = 21;

		public const int LBRACKET = 22;

		public const int RBRACKET = 23;

		public const int LCBRACKET = 24;

		public const int RCBRACKET = 25;

		public const int BREAK = 26;

		public const int CONTINUE = 27;

		public const int EQUAL = 28;

		public const int DOUBLE_EQUAL = 29;

		public const int PLUS = 30;

		public const int MINUS = 31;

		public const int MULTIPLY = 32;

		public const int DIVIDE = 33;

		public const int PLUS_EQUAL = 34;

		public const int MINUS_EQUAL = 35;

		public const int MULTIPLY_EQUAL = 36;

		public const int DIVIDE_EQUAL = 37;

		public const int INCREMENT = 38;

		public const int DECREMENT = 39;

		public const int NOT = 40;

		public const int NOT_EQUAL = 41;

		public const int OR = 42;

		public const int AND = 43;

		public const int DOUBLE_OR = 44;

		public const int DOUBLE_AND = 45;

		public const int COLON = 46;

		public const int QUESTION = 47;

		public const int MOD = 48;

		public const int COMMA = 49;

		public const int DOUBLE_DOT = 50;

		public const int DOT = 51;

		public const int HASH = 52;

		public const int GREATER_THAN = 53;

		public const int LINE_COMMENT = 54;

		public const int BLOCK_COMMENT = 55;

		public const int NUMBER = 56;

		public const int ID = 57;

		public const int COLOR = 58;

		public const int PATH = 59;

		public const int STRING_LITERAL = 60;

		public const int UNQUOTED_STRING = 61;

		public const int LINE_CONT = 62;

		public const int NEWLINE = 63;

		public const int WS = 64;

		public const int INVALID = 65;

		public const int COMMAND_COMMA_SEP = 66;

		public const int COMMAND_COMMA_ASCII_BLOCK = 67;

		public const int COMMAND_COMMA_PARAM = 68;

		public const int COMMAND_COMMA_LINE_CONT = 69;

		public const int COMMAND_COMMA_NEWLINE = 70;

		public const int COMMAND_SPACE_SEP = 71;

		public const int COMMAND_SPACE_ASCII_BLOCK = 72;

		public const int COMMAND_SPACE_PARAM = 73;

		public const int COMMAND_SPACE_LINE_CONT = 74;

		public const int COMMAND_SPACE_NEWLINE = 75;

		public const int RULE_program = 0;

		public const int RULE_block = 1;

		public const int RULE_stmt = 2;

		public const int RULE_cmd_stmt = 3;

		public const int RULE_lvalue = 4;

		public const int RULE_assignment = 5;

		public const int RULE_inc_stmt = 6;

		public const int RULE_decl_stmt = 7;

		public const int RULE_import_stmt = 8;

		public const int RULE_new_stmt = 9;

		public const int RULE_qualifiedId = 10;

		public const int RULE_object = 11;

		public const int RULE_array = 12;

		public const int RULE_expression = 13;

		public const int RULE_funcdef = 14;

		public const int RULE_lambda = 15;

		public const int RULE_varlist = 16;

		public const int RULE_invocation = 17;

		public const int RULE_paramlist = 18;

		public const int RULE_if_stmt = 19;

		public const int RULE_else_if_stmt = 20;

		public const int RULE_else_stmt = 21;

		public const int RULE_for_stmt = 22;

		public const int RULE_break_stmt = 23;

		public const int RULE_continue_stmt = 24;

		public const int RULE_return_stmt = 25;

		public static readonly string[] ruleNames;

		private static readonly string[] _LiteralNames;

		private static readonly string[] _SymbolicNames;

		public static readonly IVocabulary DefaultVocabulary;

		private static char[] _serializedATN;

		public static readonly ATN _ATN;

		[NotNull]
		public override IVocabulary Vocabulary => DefaultVocabulary;

		public override string GrammarFileName => "StonescriptParser.g4";

		public override string[] RuleNames => ruleNames;

		public override string SerializedAtn => new string(_serializedATN);

		static StonescriptParser()
		{
			sharedContextCache = new PredictionContextCache();
			ruleNames = new string[26]
			{
				"program", "block", "stmt", "cmd_stmt", "lvalue", "assignment", "inc_stmt", "decl_stmt", "import_stmt", "new_stmt",
				"qualifiedId", "object", "array", "expression", "funcdef", "lambda", "varlist", "invocation", "paramlist", "if_stmt",
				"else_if_stmt", "else_stmt", "for_stmt", "break_stmt", "continue_stmt", "return_stmt"
			};
			_LiteralNames = new string[67]
			{
				null, null, null, null, null, "'var'", "'const'", "'new'", "'import'", "'this'",
				"'true'", "'false'", "'null'", "'func'", "'return'", "'for'", "'in'", "'>='", "'<'", "'<='",
				"'('", "')'", null, null, "'{'", "'}'", "'break'", "'continue'", "'='", "'=='",
				"'+'", "'-'", "'*'", "'/'", "'+='", "'-='", "'*='", "'/='", "'++'", "'--'",
				"'!'", "'!='", "'|'", "'&'", "'||'", "'&&'", "':'", "'?'", "'%'", null,
				"'..'", "'.'", "'#'", "'>'", null, null, null, null, null, null,
				null, null, null, null, null, null, "','"
			};
			_SymbolicNames = new string[76]
			{
				null, "INDENT", "DEDENT", "COMMAND", "ASCII_BLOCK", "VAR", "CONST", "NEW", "IMPORT", "THIS",
				"TRUE", "FALSE", "NULL", "FUNCTION", "RETURN", "FOR", "IN", "GREATER_THAN_EQUAL", "LESS_THAN", "LESS_THAN_EQUAL",
				"LPAREN", "RPAREN", "LBRACKET", "RBRACKET", "LCBRACKET", "RCBRACKET", "BREAK", "CONTINUE", "EQUAL", "DOUBLE_EQUAL",
				"PLUS", "MINUS", "MULTIPLY", "DIVIDE", "PLUS_EQUAL", "MINUS_EQUAL", "MULTIPLY_EQUAL", "DIVIDE_EQUAL", "INCREMENT", "DECREMENT",
				"NOT", "NOT_EQUAL", "OR", "AND", "DOUBLE_OR", "DOUBLE_AND", "COLON", "QUESTION", "MOD", "COMMA",
				"DOUBLE_DOT", "DOT", "HASH", "GREATER_THAN", "LINE_COMMENT", "BLOCK_COMMENT", "NUMBER", "ID", "COLOR", "PATH",
				"STRING_LITERAL", "UNQUOTED_STRING", "LINE_CONT", "NEWLINE", "WS", "INVALID", "COMMAND_COMMA_SEP", "COMMAND_COMMA_ASCII_BLOCK", "COMMAND_COMMA_PARAM", "COMMAND_COMMA_LINE_CONT",
				"COMMAND_COMMA_NEWLINE", "COMMAND_SPACE_SEP", "COMMAND_SPACE_ASCII_BLOCK", "COMMAND_SPACE_PARAM", "COMMAND_SPACE_LINE_CONT", "COMMAND_SPACE_NEWLINE"
			};
			DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);
			_serializedATN = new char[3358]
			{
				'\u0003', '悋', 'Ꜫ', '脳', '맭', '䅼', '㯧', '瞆', '奤', '\u0003',
				'M', 'Ũ', '\u0004', '\u0002', '\t', '\u0002', '\u0004', '\u0003', '\t', '\u0003',
				'\u0004', '\u0004', '\t', '\u0004', '\u0004', '\u0005', '\t', '\u0005', '\u0004', '\u0006',
				'\t', '\u0006', '\u0004', '\a', '\t', '\a', '\u0004', '\b', '\t', '\b',
				'\u0004', '\t', '\t', '\t', '\u0004', '\n', '\t', '\n', '\u0004', '\v',
				'\t', '\v', '\u0004', '\f', '\t', '\f', '\u0004', '\r', '\t', '\r',
				'\u0004', '\u000e', '\t', '\u000e', '\u0004', '\u000f', '\t', '\u000f', '\u0004', '\u0010',
				'\t', '\u0010', '\u0004', '\u0011', '\t', '\u0011', '\u0004', '\u0012', '\t', '\u0012',
				'\u0004', '\u0013', '\t', '\u0013', '\u0004', '\u0014', '\t', '\u0014', '\u0004', '\u0015',
				'\t', '\u0015', '\u0004', '\u0016', '\t', '\u0016', '\u0004', '\u0017', '\t', '\u0017',
				'\u0004', '\u0018', '\t', '\u0018', '\u0004', '\u0019', '\t', '\u0019', '\u0004', '\u001a',
				'\t', '\u001a', '\u0004', '\u001b', '\t', '\u001b', '\u0003', '\u0002', '\u0003', '\u0002',
				'\u0003', '\u0002', '\a', '\u0002', ':', '\n', '\u0002', '\f', '\u0002', '\u000e',
				'\u0002', '=', '\v', '\u0002', '\u0003', '\u0002', '\u0003', '\u0002', '\u0003', '\u0003',
				'\u0003', '\u0003', '\u0003', '\u0003', '\u0003', '\u0003', '\a', '\u0003', 'E', '\n',
				'\u0003', '\f', '\u0003', '\u000e', '\u0003', 'H', '\v', '\u0003', '\u0003', '\u0003',
				'\u0003', '\u0003', '\u0003', '\u0004', '\u0003', '\u0004', '\u0003', '\u0004', '\u0003', '\u0004',
				'\u0003', '\u0004', '\u0003', '\u0004', '\u0003', '\u0004', '\u0003', '\u0004', '\u0003', '\u0004',
				'\u0003', '\u0004', '\u0005', '\u0004', 'V', '\n', '\u0004', '\u0003', '\u0004', '\u0003',
				'\u0004', '\u0003', '\u0004', '\u0003', '\u0004', '\u0003', '\u0004', '\u0005', '\u0004', ']',
				'\n', '\u0004', '\u0003', '\u0005', '\u0003', '\u0005', '\a', '\u0005', 'a', '\n',
				'\u0005', '\f', '\u0005', '\u000e', '\u0005', 'd', '\v', '\u0005', '\u0003', '\u0005',
				'\u0003', '\u0005', '\a', '\u0005', 'h', '\n', '\u0005', '\f', '\u0005', '\u000e',
				'\u0005', 'k', '\v', '\u0005', '\u0005', '\u0005', 'm', '\n', '\u0005', '\u0005',
				'\u0005', 'o', '\n', '\u0005', '\u0003', '\u0006', '\u0003', '\u0006', '\u0003', '\u0006',
				'\u0005', '\u0006', 't', '\n', '\u0006', '\u0003', '\u0006', '\u0003', '\u0006', '\u0003',
				'\u0006', '\u0003', '\u0006', '\u0003', '\u0006', '\u0003', '\u0006', '\u0005', '\u0006', '|',
				'\n', '\u0006', '\u0003', '\a', '\u0003', '\a', '\u0003', '\a', '\u0003', '\a',
				'\u0003', '\b', '\u0003', '\b', '\u0003', '\b', '\u0003', '\b', '\u0003', '\b',
				'\u0005', '\b', '\u0087', '\n', '\b', '\u0003', '\t', '\u0003', '\t', '\u0003',
				'\t', '\u0003', '\t', '\u0005', '\t', '\u008d', '\n', '\t', '\u0003', '\n',
				'\u0003', '\n', '\u0003', '\n', '\u0003', '\v', '\u0003', '\v', '\u0003', '\v',
				'\u0003', '\f', '\u0003', '\f', '\u0003', '\f', '\a', '\f', '\u0098', '\n',
				'\f', '\f', '\f', '\u000e', '\f', '\u009b', '\v', '\f', '\u0003', '\r',
				'\u0003', '\r', '\u0003', '\r', '\u0003', '\r', '\u0003', '\r', '\u0003', '\r',
				'\u0003', '\r', '\u0003', '\r', '\a', '\r', '¥', '\n', '\r', '\f',
				'\r', '\u000e', '\r', '\u00a8', '\v', '\r', '\u0005', '\r', 'ª', '\n',
				'\r', '\u0003', '\r', '\u0005', '\r', '\u00ad', '\n', '\r', '\u0003', '\r',
				'\u0003', '\r', '\u0003', '\u000e', '\u0003', '\u000e', '\u0003', '\u000e', '\u0003', '\u000e',
				'\a', '\u000e', 'µ', '\n', '\u000e', '\f', '\u000e', '\u000e', '\u000e', '\u00b8',
				'\v', '\u000e', '\u0005', '\u000e', 'º', '\n', '\u000e', '\u0003', '\u000e', '\u0005',
				'\u000e', '½', '\n', '\u000e', '\u0003', '\u000e', '\u0003', '\u000e', '\u0003', '\u000f',
				'\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f',
				'\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0006', '\u000f',
				'Ë', '\n', '\u000f', '\r', '\u000f', '\u000e', '\u000f', 'Ì', '\u0003', '\u000f',
				'\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f',
				'\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f',
				'\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f',
				'\u0005', '\u000f', 'ß', '\n', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003',
				'\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003',
				'\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003',
				'\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003',
				'\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0005', '\u000f', 'õ', '\n', '\u000f',
				'\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f',
				'\u0005', '\u000f', 'ü', '\n', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003',
				'\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f', '\a', '\u000f', 'Ą',
				'\n', '\u000f', '\f', '\u000f', '\u000e', '\u000f', 'ć', '\v', '\u000f', '\u0003',
				'\u0010', '\u0003', '\u0010', '\u0003', '\u0010', '\u0003', '\u0010', '\u0005', '\u0010', 'č',
				'\n', '\u0010', '\u0003', '\u0010', '\u0003', '\u0010', '\u0003', '\u0010', '\u0003', '\u0010',
				'\u0003', '\u0011', '\u0003', '\u0011', '\u0003', '\u0011', '\u0005', '\u0011', 'Ė', '\n',
				'\u0011', '\u0003', '\u0011', '\u0003', '\u0011', '\u0003', '\u0011', '\u0003', '\u0011', '\u0003',
				'\u0012', '\u0003', '\u0012', '\u0003', '\u0012', '\a', '\u0012', 'ğ', '\n', '\u0012',
				'\f', '\u0012', '\u000e', '\u0012', 'Ģ', '\v', '\u0012', '\u0003', '\u0013', '\u0003',
				'\u0013', '\u0003', '\u0013', '\u0005', '\u0013', 'ħ', '\n', '\u0013', '\u0003', '\u0013',
				'\u0003', '\u0013', '\u0003', '\u0014', '\u0003', '\u0014', '\u0003', '\u0014', '\a', '\u0014',
				'Į', '\n', '\u0014', '\f', '\u0014', '\u000e', '\u0014', 'ı', '\v', '\u0014',
				'\u0003', '\u0015', '\u0003', '\u0015', '\u0003', '\u0015', '\u0003', '\u0015', '\u0005', '\u0015',
				'ķ', '\n', '\u0015', '\u0003', '\u0015', '\a', '\u0015', 'ĺ', '\n', '\u0015',
				'\f', '\u0015', '\u000e', '\u0015', 'Ľ', '\v', '\u0015', '\u0003', '\u0015', '\u0005',
				'\u0015', 'ŀ', '\n', '\u0015', '\u0003', '\u0016', '\u0003', '\u0016', '\u0003', '\u0016',
				'\u0003', '\u0016', '\u0003', '\u0016', '\u0005', '\u0016', 'Ň', '\n', '\u0016', '\u0003',
				'\u0017', '\u0003', '\u0017', '\u0003', '\u0017', '\u0005', '\u0017', 'Ō', '\n', '\u0017',
				'\u0003', '\u0018', '\u0003', '\u0018', '\u0003', '\u0018', '\u0003', '\u0018', '\u0003', '\u0018',
				'\u0003', '\u0018', '\u0003', '\u0018', '\u0003', '\u0018', '\u0003', '\u0018', '\u0003', '\u0018',
				'\u0003', '\u0018', '\u0003', '\u0018', '\u0003', '\u0018', '\u0003', '\u0018', '\u0003', '\u0018',
				'\u0003', '\u0018', '\u0005', '\u0018', 'Ş', '\n', '\u0018', '\u0003', '\u0019', '\u0003',
				'\u0019', '\u0003', '\u001a', '\u0003', '\u001a', '\u0003', '\u001b', '\u0003', '\u001b', '\u0005',
				'\u001b', 'Ŧ', '\n', '\u001b', '\u0003', '\u001b', '\u0002', '\u0003', '\u001c', '\u001c',
				'\u0002', '\u0004', '\u0006', '\b', '\n', '\f', '\u000e', '\u0010', '\u0012', '\u0014',
				'\u0016', '\u0018', '\u001a', '\u001c', '\u001e', ' ', '"', '$', '&', '(',
				'*', ',', '.', '0', '2', '4', '\u0002', '\u000f', '\u0003', '\u0003',
				'A', 'A', '\u0003', '\u0002', 'D', 'F', '\u0003', '\u0002', 'I', 'K',
				'\u0004', '\u0002', '\u001e', '\u001e', '$', '\'', '\u0003', '\u0002', '(', ')',
				'\u0003', '\u0002', '\a', '\b', '\u0004', '\u0002', ';', ';', '=', '=',
				'\u0004', '\u0002', '"', '#', '2', '2', '\u0003', '\u0002', ' ', '!',
				'\u0004', '\u0002', '\u0013', '\u0015', '7', '7', '\u0004', '\u0002', '\u001e', '\u001f',
				'*', '+', '\u0004', '\u0002', '-', '-', '/', '/', '\u0004', '\u0002',
				',', ',', '.', '.', '\u0002', 'ƙ', '\u0002', ';', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u0004', '@', '\u0003', '\u0002', '\u0002', '\u0002', '\u0006', '\\',
				'\u0003', '\u0002', '\u0002', '\u0002', '\b', '^', '\u0003', '\u0002', '\u0002', '\u0002',
				'\n', '{', '\u0003', '\u0002', '\u0002', '\u0002', '\f', '}', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u000e', '\u0086', '\u0003', '\u0002', '\u0002', '\u0002', '\u0010', '\u0088',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u0012', '\u008e', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u0014', '\u0091', '\u0003', '\u0002', '\u0002', '\u0002', '\u0016', '\u0094', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u0018', '\u009c', '\u0003', '\u0002', '\u0002', '\u0002', '\u001a', '°',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u001c', 'Þ', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u001e', 'Ĉ', '\u0003', '\u0002', '\u0002', '\u0002', ' ', 'Ē', '\u0003', '\u0002',
				'\u0002', '\u0002', '"', 'ě', '\u0003', '\u0002', '\u0002', '\u0002', '$', 'ģ',
				'\u0003', '\u0002', '\u0002', '\u0002', '&', 'Ī', '\u0003', '\u0002', '\u0002', '\u0002',
				'(', 'Ĳ', '\u0003', '\u0002', '\u0002', '\u0002', '*', 'Ł', '\u0003', '\u0002',
				'\u0002', '\u0002', ',', 'ň', '\u0003', '\u0002', '\u0002', '\u0002', '.', 'ŝ',
				'\u0003', '\u0002', '\u0002', '\u0002', '0', 'ş', '\u0003', '\u0002', '\u0002', '\u0002',
				'2', 'š', '\u0003', '\u0002', '\u0002', '\u0002', '4', 'ţ', '\u0003', '\u0002',
				'\u0002', '\u0002', '6', ':', '\a', 'A', '\u0002', '\u0002', '7', ':',
				'\u0005', '\u0006', '\u0004', '\u0002', '8', ':', '\u0005', '\u0004', '\u0003', '\u0002',
				'9', '6', '\u0003', '\u0002', '\u0002', '\u0002', '9', '7', '\u0003', '\u0002',
				'\u0002', '\u0002', '9', '8', '\u0003', '\u0002', '\u0002', '\u0002', ':', '=',
				'\u0003', '\u0002', '\u0002', '\u0002', ';', '9', '\u0003', '\u0002', '\u0002', '\u0002',
				';', '<', '\u0003', '\u0002', '\u0002', '\u0002', '<', '>', '\u0003', '\u0002',
				'\u0002', '\u0002', '=', ';', '\u0003', '\u0002', '\u0002', '\u0002', '>', '?',
				'\a', '\u0002', '\u0002', '\u0003', '?', '\u0003', '\u0003', '\u0002', '\u0002', '\u0002',
				'@', 'F', '\a', '\u0003', '\u0002', '\u0002', 'A', 'E', '\u0005', '\u0006',
				'\u0004', '\u0002', 'B', 'E', '\u0005', '\u0004', '\u0003', '\u0002', 'C', 'E',
				'\a', 'A', '\u0002', '\u0002', 'D', 'A', '\u0003', '\u0002', '\u0002', '\u0002',
				'D', 'B', '\u0003', '\u0002', '\u0002', '\u0002', 'D', 'C', '\u0003', '\u0002',
				'\u0002', '\u0002', 'E', 'H', '\u0003', '\u0002', '\u0002', '\u0002', 'F', 'D',
				'\u0003', '\u0002', '\u0002', '\u0002', 'F', 'G', '\u0003', '\u0002', '\u0002', '\u0002',
				'G', 'I', '\u0003', '\u0002', '\u0002', '\u0002', 'H', 'F', '\u0003', '\u0002',
				'\u0002', '\u0002', 'I', 'J', '\a', '\u0004', '\u0002', '\u0002', 'J', '\u0005',
				'\u0003', '\u0002', '\u0002', '\u0002', 'K', 'V', '\u0005', '\f', '\a', '\u0002',
				'L', 'V', '\u0005', '0', '\u0019', '\u0002', 'M', 'V', '\u0005', '2',
				'\u001a', '\u0002', 'N', 'V', '\u0005', '4', '\u001b', '\u0002', 'O', 'V',
				'\u0005', '$', '\u0013', '\u0002', 'P', 'V', '\u0005', '\b', '\u0005', '\u0002',
				'Q', 'V', '\u0005', '\u0010', '\t', '\u0002', 'R', 'V', '\u0005', '\u0012',
				'\n', '\u0002', 'S', 'V', '\u0005', '\u0014', '\v', '\u0002', 'T', 'V',
				'\u0005', '\u000e', '\b', '\u0002', 'U', 'K', '\u0003', '\u0002', '\u0002', '\u0002',
				'U', 'L', '\u0003', '\u0002', '\u0002', '\u0002', 'U', 'M', '\u0003', '\u0002',
				'\u0002', '\u0002', 'U', 'N', '\u0003', '\u0002', '\u0002', '\u0002', 'U', 'O',
				'\u0003', '\u0002', '\u0002', '\u0002', 'U', 'P', '\u0003', '\u0002', '\u0002', '\u0002',
				'U', 'Q', '\u0003', '\u0002', '\u0002', '\u0002', 'U', 'R', '\u0003', '\u0002',
				'\u0002', '\u0002', 'U', 'S', '\u0003', '\u0002', '\u0002', '\u0002', 'U', 'T',
				'\u0003', '\u0002', '\u0002', '\u0002', 'V', 'W', '\u0003', '\u0002', '\u0002', '\u0002',
				'W', 'X', '\t', '\u0002', '\u0002', '\u0002', 'X', ']', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Y', ']', '\u0005', '(', '\u0015', '\u0002', 'Z', ']',
				'\u0005', '\u001e', '\u0010', '\u0002', '[', ']', '\u0005', '.', '\u0018', '\u0002',
				'\\', 'U', '\u0003', '\u0002', '\u0002', '\u0002', '\\', 'Y', '\u0003', '\u0002',
				'\u0002', '\u0002', '\\', 'Z', '\u0003', '\u0002', '\u0002', '\u0002', '\\', '[',
				'\u0003', '\u0002', '\u0002', '\u0002', ']', '\a', '\u0003', '\u0002', '\u0002', '\u0002',
				'^', 'n', '\a', '\u0005', '\u0002', '\u0002', '_', 'a', '\t', '\u0003',
				'\u0002', '\u0002', '`', '_', '\u0003', '\u0002', '\u0002', '\u0002', 'a', 'd',
				'\u0003', '\u0002', '\u0002', '\u0002', 'b', '`', '\u0003', '\u0002', '\u0002', '\u0002',
				'b', 'c', '\u0003', '\u0002', '\u0002', '\u0002', 'c', 'o', '\u0003', '\u0002',
				'\u0002', '\u0002', 'd', 'b', '\u0003', '\u0002', '\u0002', '\u0002', 'e', 'i',
				'\a', 'I', '\u0002', '\u0002', 'f', 'h', '\t', '\u0004', '\u0002', '\u0002',
				'g', 'f', '\u0003', '\u0002', '\u0002', '\u0002', 'h', 'k', '\u0003', '\u0002',
				'\u0002', '\u0002', 'i', 'g', '\u0003', '\u0002', '\u0002', '\u0002', 'i', 'j',
				'\u0003', '\u0002', '\u0002', '\u0002', 'j', 'm', '\u0003', '\u0002', '\u0002', '\u0002',
				'k', 'i', '\u0003', '\u0002', '\u0002', '\u0002', 'l', 'e', '\u0003', '\u0002',
				'\u0002', '\u0002', 'l', 'm', '\u0003', '\u0002', '\u0002', '\u0002', 'm', 'o',
				'\u0003', '\u0002', '\u0002', '\u0002', 'n', 'b', '\u0003', '\u0002', '\u0002', '\u0002',
				'n', 'l', '\u0003', '\u0002', '\u0002', '\u0002', 'o', '\t', '\u0003', '\u0002',
				'\u0002', '\u0002', 'p', 'q', '\u0005', '\u001c', '\u000f', '\u0002', 'q', 'r',
				'\a', '5', '\u0002', '\u0002', 'r', 't', '\u0003', '\u0002', '\u0002', '\u0002',
				's', 'p', '\u0003', '\u0002', '\u0002', '\u0002', 's', 't', '\u0003', '\u0002',
				'\u0002', '\u0002', 't', 'u', '\u0003', '\u0002', '\u0002', '\u0002', 'u', '|',
				'\a', ';', '\u0002', '\u0002', 'v', 'w', '\u0005', '\u001c', '\u000f', '\u0002',
				'w', 'x', '\a', '\u0018', '\u0002', '\u0002', 'x', 'y', '\u0005', '\u001c',
				'\u000f', '\u0002', 'y', 'z', '\a', '\u0019', '\u0002', '\u0002', 'z', '|',
				'\u0003', '\u0002', '\u0002', '\u0002', '{', 's', '\u0003', '\u0002', '\u0002', '\u0002',
				'{', 'v', '\u0003', '\u0002', '\u0002', '\u0002', '|', '\v', '\u0003', '\u0002',
				'\u0002', '\u0002', '}', '~', '\u0005', '\n', '\u0006', '\u0002', '~', '\u007f',
				'\t', '\u0005', '\u0002', '\u0002', '\u007f', '\u0080', '\u0005', '\u001c', '\u000f', '\u0002',
				'\u0080', '\r', '\u0003', '\u0002', '\u0002', '\u0002', '\u0081', '\u0082', '\t', '\u0006',
				'\u0002', '\u0002', '\u0082', '\u0087', '\u0005', '\u0016', '\f', '\u0002', '\u0083', '\u0084',
				'\u0005', '\u0016', '\f', '\u0002', '\u0084', '\u0085', '\t', '\u0006', '\u0002', '\u0002',
				'\u0085', '\u0087', '\u0003', '\u0002', '\u0002', '\u0002', '\u0086', '\u0081', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u0086', '\u0083', '\u0003', '\u0002', '\u0002', '\u0002', '\u0087', '\u000f',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u0088', '\u0089', '\t', '\a', '\u0002', '\u0002',
				'\u0089', '\u008c', '\a', ';', '\u0002', '\u0002', '\u008a', '\u008b', '\a', '\u001e',
				'\u0002', '\u0002', '\u008b', '\u008d', '\u0005', '\u001c', '\u000f', '\u0002', '\u008c', '\u008a',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u008c', '\u008d', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u008d', '\u0011', '\u0003', '\u0002', '\u0002', '\u0002', '\u008e', '\u008f', '\a', '\n',
				'\u0002', '\u0002', '\u008f', '\u0090', '\t', '\b', '\u0002', '\u0002', '\u0090', '\u0013',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u0091', '\u0092', '\a', '\t', '\u0002', '\u0002',
				'\u0092', '\u0093', '\t', '\b', '\u0002', '\u0002', '\u0093', '\u0015', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u0094', '\u0099', '\a', ';', '\u0002', '\u0002', '\u0095', '\u0096',
				'\a', '5', '\u0002', '\u0002', '\u0096', '\u0098', '\a', ';', '\u0002', '\u0002',
				'\u0097', '\u0095', '\u0003', '\u0002', '\u0002', '\u0002', '\u0098', '\u009b', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u0099', '\u0097', '\u0003', '\u0002', '\u0002', '\u0002', '\u0099', '\u009a',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u009a', '\u0017', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u009b', '\u0099', '\u0003', '\u0002', '\u0002', '\u0002', '\u009c', '©', '\a', '\u001a',
				'\u0002', '\u0002', '\u009d', '\u009e', '\a', ';', '\u0002', '\u0002', '\u009e', '\u009f',
				'\a', '0', '\u0002', '\u0002', '\u009f', '¦', '\u0005', '\u001c', '\u000f', '\u0002',
				'\u00a0', '¡', '\a', '3', '\u0002', '\u0002', '¡', '¢', '\a', ';',
				'\u0002', '\u0002', '¢', '£', '\a', '0', '\u0002', '\u0002', '£', '¥',
				'\u0005', '\u001c', '\u000f', '\u0002', '¤', '\u00a0', '\u0003', '\u0002', '\u0002', '\u0002',
				'¥', '\u00a8', '\u0003', '\u0002', '\u0002', '\u0002', '¦', '¤', '\u0003', '\u0002',
				'\u0002', '\u0002', '¦', '§', '\u0003', '\u0002', '\u0002', '\u0002', '§', 'ª',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u00a8', '¦', '\u0003', '\u0002', '\u0002', '\u0002',
				'©', '\u009d', '\u0003', '\u0002', '\u0002', '\u0002', '©', 'ª', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ª', '¬', '\u0003', '\u0002', '\u0002', '\u0002', '«', '\u00ad',
				'\a', '3', '\u0002', '\u0002', '¬', '«', '\u0003', '\u0002', '\u0002', '\u0002',
				'¬', '\u00ad', '\u0003', '\u0002', '\u0002', '\u0002', '\u00ad', '®', '\u0003', '\u0002',
				'\u0002', '\u0002', '®', '\u00af', '\a', '\u001b', '\u0002', '\u0002', '\u00af', '\u0019',
				'\u0003', '\u0002', '\u0002', '\u0002', '°', '¹', '\a', '\u0018', '\u0002', '\u0002',
				'±', '¶', '\u0005', '\u001c', '\u000f', '\u0002', '²', '³', '\a', '3',
				'\u0002', '\u0002', '³', 'µ', '\u0005', '\u001c', '\u000f', '\u0002', '\u00b4', '²',
				'\u0003', '\u0002', '\u0002', '\u0002', 'µ', '\u00b8', '\u0003', '\u0002', '\u0002', '\u0002',
				'¶', '\u00b4', '\u0003', '\u0002', '\u0002', '\u0002', '¶', '·', '\u0003', '\u0002',
				'\u0002', '\u0002', '·', 'º', '\u0003', '\u0002', '\u0002', '\u0002', '\u00b8', '¶',
				'\u0003', '\u0002', '\u0002', '\u0002', '¹', '±', '\u0003', '\u0002', '\u0002', '\u0002',
				'¹', 'º', '\u0003', '\u0002', '\u0002', '\u0002', 'º', '¼', '\u0003', '\u0002',
				'\u0002', '\u0002', '»', '½', '\a', '3', '\u0002', '\u0002', '¼', '»',
				'\u0003', '\u0002', '\u0002', '\u0002', '¼', '½', '\u0003', '\u0002', '\u0002', '\u0002',
				'½', '¾', '\u0003', '\u0002', '\u0002', '\u0002', '¾', '¿', '\a', '\u0019',
				'\u0002', '\u0002', '¿', '\u001b', '\u0003', '\u0002', '\u0002', '\u0002', 'À', 'Á',
				'\b', '\u000f', '\u0001', '\u0002', 'Á', 'ß', '\u0005', '\u0016', '\f', '\u0002',
				'Â', 'ß', '\a', ':', '\u0002', '\u0002', 'Ã', 'ß', '\a', '\u0006',
				'\u0002', '\u0002', 'Ä', 'ß', '\a', '\f', '\u0002', '\u0002', 'Å', 'ß',
				'\a', '\r', '\u0002', '\u0002', 'Æ', 'ß', '\a', '\u000e', '\u0002', '\u0002',
				'Ç', 'ß', '\a', '<', '\u0002', '\u0002', 'È', 'ß', '\a', '>',
				'\u0002', '\u0002', 'É', 'Ë', '\a', ';', '\u0002', '\u0002', 'Ê', 'É',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ë', 'Ì', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ì', 'Ê', '\u0003', '\u0002', '\u0002', '\u0002', 'Ì', 'Í', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Í', 'ß', '\u0003', '\u0002', '\u0002', '\u0002', 'Î', 'ß',
				'\a', '?', '\u0002', '\u0002', 'Ï', 'ß', '\a', '\v', '\u0002', '\u0002',
				'Ð', 'ß', '\u0005', '\u0018', '\r', '\u0002', 'Ñ', 'ß', '\u0005', '\u001a',
				'\u000e', '\u0002', 'Ò', 'ß', '\u0005', ' ', '\u0011', '\u0002', 'Ó', 'ß',
				'\u0005', '\u0014', '\v', '\u0002', 'Ô', 'ß', '\u0005', '\u0012', '\n', '\u0002',
				'Õ', 'ß', '\u0005', '\u000e', '\b', '\u0002', 'Ö', '×', '\a', '\u0016',
				'\u0002', '\u0002', '×', 'Ø', '\u0005', '\u001c', '\u000f', '\u0002', 'Ø', 'Ù',
				'\a', '\u0017', '\u0002', '\u0002', 'Ù', 'ß', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ú', 'Û', '\a', '!', '\u0002', '\u0002', 'Û', 'ß', '\u0005', '\u001c',
				'\u000f', '\n', 'Ü', 'Ý', '\a', '*', '\u0002', '\u0002', 'Ý', 'ß',
				'\u0005', '\u001c', '\u000f', '\t', 'Þ', 'À', '\u0003', '\u0002', '\u0002', '\u0002',
				'Þ', 'Â', '\u0003', '\u0002', '\u0002', '\u0002', 'Þ', 'Ã', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Þ', 'Ä', '\u0003', '\u0002', '\u0002', '\u0002', 'Þ', 'Å',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Þ', 'Æ', '\u0003', '\u0002', '\u0002', '\u0002',
				'Þ', 'Ç', '\u0003', '\u0002', '\u0002', '\u0002', 'Þ', 'È', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Þ', 'Ê', '\u0003', '\u0002', '\u0002', '\u0002', 'Þ', 'Î',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Þ', 'Ï', '\u0003', '\u0002', '\u0002', '\u0002',
				'Þ', 'Ð', '\u0003', '\u0002', '\u0002', '\u0002', 'Þ', 'Ñ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Þ', 'Ò', '\u0003', '\u0002', '\u0002', '\u0002', 'Þ', 'Ó',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Þ', 'Ô', '\u0003', '\u0002', '\u0002', '\u0002',
				'Þ', 'Õ', '\u0003', '\u0002', '\u0002', '\u0002', 'Þ', 'Ö', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Þ', 'Ú', '\u0003', '\u0002', '\u0002', '\u0002', 'Þ', 'Ü',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ß', 'ą', '\u0003', '\u0002', '\u0002', '\u0002',
				'à', 'á', '\f', '\b', '\u0002', '\u0002', 'á', 'â', '\t', '\t',
				'\u0002', '\u0002', 'â', 'Ą', '\u0005', '\u001c', '\u000f', '\t', 'ã', 'ä',
				'\f', '\a', '\u0002', '\u0002', 'ä', 'å', '\t', '\n', '\u0002', '\u0002',
				'å', 'Ą', '\u0005', '\u001c', '\u000f', '\b', 'æ', 'ç', '\f', '\u0006',
				'\u0002', '\u0002', 'ç', 'è', '\t', '\v', '\u0002', '\u0002', 'è', 'Ą',
				'\u0005', '\u001c', '\u000f', '\a', 'é', 'ê', '\f', '\u0005', '\u0002', '\u0002',
				'ê', 'ë', '\t', '\f', '\u0002', '\u0002', 'ë', 'Ą', '\u0005', '\u001c',
				'\u000f', '\u0006', 'ì', 'í', '\f', '\u0004', '\u0002', '\u0002', 'í', 'î',
				'\t', '\r', '\u0002', '\u0002', 'î', 'Ą', '\u0005', '\u001c', '\u000f', '\u0005',
				'ï', 'ð', '\f', '\u0003', '\u0002', '\u0002', 'ð', 'ñ', '\t', '\u000e',
				'\u0002', '\u0002', 'ñ', 'Ą', '\u0005', '\u001c', '\u000f', '\u0004', 'ò', 'ô',
				'\f', '\u001e', '\u0002', '\u0002', 'ó', 'õ', '\a', 'A', '\u0002', '\u0002',
				'ô', 'ó', '\u0003', '\u0002', '\u0002', '\u0002', 'ô', 'õ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'õ', 'ö', '\u0003', '\u0002', '\u0002', '\u0002', 'ö', '÷',
				'\a', '5', '\u0002', '\u0002', '÷', 'Ą', '\a', ';', '\u0002', '\u0002',
				'ø', 'ù', '\f', '\r', '\u0002', '\u0002', 'ù', 'û', '\a', '\u0016',
				'\u0002', '\u0002', 'ú', 'ü', '\u0005', '&', '\u0014', '\u0002', 'û', 'ú',
				'\u0003', '\u0002', '\u0002', '\u0002', 'û', 'ü', '\u0003', '\u0002', '\u0002', '\u0002',
				'ü', 'ý', '\u0003', '\u0002', '\u0002', '\u0002', 'ý', 'Ą', '\a', '\u0017',
				'\u0002', '\u0002', 'þ', 'ÿ', '\f', '\f', '\u0002', '\u0002', 'ÿ', 'Ā',
				'\a', '\u0018', '\u0002', '\u0002', 'Ā', 'ā', '\u0005', '\u001c', '\u000f', '\u0002',
				'ā', 'Ă', '\a', '\u0019', '\u0002', '\u0002', 'Ă', 'Ą', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ă', 'à', '\u0003', '\u0002', '\u0002', '\u0002', 'ă', 'ã',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ă', 'æ', '\u0003', '\u0002', '\u0002', '\u0002',
				'ă', 'é', '\u0003', '\u0002', '\u0002', '\u0002', 'ă', 'ì', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ă', 'ï', '\u0003', '\u0002', '\u0002', '\u0002', 'ă', 'ò',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ă', 'ø', '\u0003', '\u0002', '\u0002', '\u0002',
				'ă', 'þ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ą', 'ć', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ą', 'ă', '\u0003', '\u0002', '\u0002', '\u0002', 'ą', 'Ć',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ć', '\u001d', '\u0003', '\u0002', '\u0002', '\u0002',
				'ć', 'ą', '\u0003', '\u0002', '\u0002', '\u0002', 'Ĉ', 'ĉ', '\a', '\u000f',
				'\u0002', '\u0002', 'ĉ', 'Ċ', '\a', ';', '\u0002', '\u0002', 'Ċ', 'Č',
				'\a', '\u0016', '\u0002', '\u0002', 'ċ', 'č', '\u0005', '"', '\u0012', '\u0002',
				'Č', 'ċ', '\u0003', '\u0002', '\u0002', '\u0002', 'Č', 'č', '\u0003', '\u0002',
				'\u0002', '\u0002', 'č', 'Ď', '\u0003', '\u0002', '\u0002', '\u0002', 'Ď', 'ď',
				'\a', '\u0017', '\u0002', '\u0002', 'ď', 'Đ', '\a', 'A', '\u0002', '\u0002',
				'Đ', 'đ', '\u0005', '\u0004', '\u0003', '\u0002', 'đ', '\u001f', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ē', 'ē', '\a', '\u000f', '\u0002', '\u0002', 'ē', 'ĕ',
				'\a', '\u0016', '\u0002', '\u0002', 'Ĕ', 'Ė', '\u0005', '"', '\u0012', '\u0002',
				'ĕ', 'Ĕ', '\u0003', '\u0002', '\u0002', '\u0002', 'ĕ', 'Ė', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ė', 'ė', '\u0003', '\u0002', '\u0002', '\u0002', 'ė', 'Ę',
				'\a', '\u0017', '\u0002', '\u0002', 'Ę', 'ę', '\a', 'A', '\u0002', '\u0002',
				'ę', 'Ě', '\u0005', '\u0004', '\u0003', '\u0002', 'Ě', '!', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ě', 'Ġ', '\a', ';', '\u0002', '\u0002', 'Ĝ', 'ĝ',
				'\a', '3', '\u0002', '\u0002', 'ĝ', 'ğ', '\a', ';', '\u0002', '\u0002',
				'Ğ', 'Ĝ', '\u0003', '\u0002', '\u0002', '\u0002', 'ğ', 'Ģ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ġ', 'Ğ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ġ', 'ġ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ġ', '#', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ģ', 'Ġ', '\u0003', '\u0002', '\u0002', '\u0002', 'ģ', 'Ĥ', '\u0005', '\u001c',
				'\u000f', '\u0002', 'Ĥ', 'Ħ', '\a', '\u0016', '\u0002', '\u0002', 'ĥ', 'ħ',
				'\u0005', '&', '\u0014', '\u0002', 'Ħ', 'ĥ', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ħ', 'ħ', '\u0003', '\u0002', '\u0002', '\u0002', 'ħ', 'Ĩ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ĩ', 'ĩ', '\a', '\u0017', '\u0002', '\u0002', 'ĩ', '%',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ī', 'į', '\u0005', '\u001c', '\u000f', '\u0002',
				'ī', 'Ĭ', '\a', '3', '\u0002', '\u0002', 'Ĭ', 'Į', '\u0005', '\u001c',
				'\u000f', '\u0002', 'ĭ', 'ī', '\u0003', '\u0002', '\u0002', '\u0002', 'Į', 'ı',
				'\u0003', '\u0002', '\u0002', '\u0002', 'į', 'ĭ', '\u0003', '\u0002', '\u0002', '\u0002',
				'į', 'İ', '\u0003', '\u0002', '\u0002', '\u0002', 'İ', '\'', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ı', 'į', '\u0003', '\u0002', '\u0002', '\u0002', 'Ĳ', 'ĳ',
				'\a', '1', '\u0002', '\u0002', 'ĳ', 'Ĵ', '\u0005', '\u001c', '\u000f', '\u0002',
				'Ĵ', 'Ķ', '\a', 'A', '\u0002', '\u0002', 'ĵ', 'ķ', '\u0005', '\u0004',
				'\u0003', '\u0002', 'Ķ', 'ĵ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ķ', 'ķ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ķ', 'Ļ', '\u0003', '\u0002', '\u0002', '\u0002',
				'ĸ', 'ĺ', '\u0005', '*', '\u0016', '\u0002', 'Ĺ', 'ĸ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ĺ', 'Ľ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ļ', 'Ĺ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ļ', 'ļ', '\u0003', '\u0002', '\u0002', '\u0002',
				'ļ', 'Ŀ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ľ', 'Ļ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ľ', 'ŀ', '\u0005', ',', '\u0017', '\u0002', 'Ŀ', 'ľ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ŀ', 'ŀ', '\u0003', '\u0002', '\u0002', '\u0002',
				'ŀ', ')', '\u0003', '\u0002', '\u0002', '\u0002', 'Ł', 'ł', '\a', '0',
				'\u0002', '\u0002', 'ł', 'Ń', '\a', '1', '\u0002', '\u0002', 'Ń', 'ń',
				'\u0005', '\u001c', '\u000f', '\u0002', 'ń', 'ņ', '\a', 'A', '\u0002', '\u0002',
				'Ņ', 'Ň', '\u0005', '\u0004', '\u0003', '\u0002', 'ņ', 'Ņ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ņ', 'Ň', '\u0003', '\u0002', '\u0002', '\u0002', 'Ň', '+',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ň', 'ŉ', '\a', '0', '\u0002', '\u0002',
				'ŉ', 'ŋ', '\a', 'A', '\u0002', '\u0002', 'Ŋ', 'Ō', '\u0005', '\u0004',
				'\u0003', '\u0002', 'ŋ', 'Ŋ', '\u0003', '\u0002', '\u0002', '\u0002', 'ŋ', 'Ō',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ō', '-', '\u0003', '\u0002', '\u0002', '\u0002',
				'ō', 'Ŏ', '\a', '\u0011', '\u0002', '\u0002', 'Ŏ', 'ŏ', '\a', ';',
				'\u0002', '\u0002', 'ŏ', 'Ő', '\a', '\u001e', '\u0002', '\u0002', 'Ő', 'ő',
				'\u0005', '\u001c', '\u000f', '\u0002', 'ő', 'Œ', '\a', '4', '\u0002', '\u0002',
				'Œ', 'œ', '\u0005', '\u001c', '\u000f', '\u0002', 'œ', 'Ŕ', '\a', 'A',
				'\u0002', '\u0002', 'Ŕ', 'ŕ', '\u0005', '\u0004', '\u0003', '\u0002', 'ŕ', 'Ş',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ŗ', 'ŗ', '\a', '\u0011', '\u0002', '\u0002',
				'ŗ', 'Ř', '\a', ';', '\u0002', '\u0002', 'Ř', 'ř', '\a', '0',
				'\u0002', '\u0002', 'ř', 'Ś', '\u0005', '\u001c', '\u000f', '\u0002', 'Ś', 'ś',
				'\a', 'A', '\u0002', '\u0002', 'ś', 'Ŝ', '\u0005', '\u0004', '\u0003', '\u0002',
				'Ŝ', 'Ş', '\u0003', '\u0002', '\u0002', '\u0002', 'ŝ', 'ō', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ŝ', 'Ŗ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ş', '/',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ş', 'Š', '\a', '\u001c', '\u0002', '\u0002',
				'Š', '1', '\u0003', '\u0002', '\u0002', '\u0002', 'š', 'Ţ', '\a', '\u001d',
				'\u0002', '\u0002', 'Ţ', '3', '\u0003', '\u0002', '\u0002', '\u0002', 'ţ', 'ť',
				'\a', '\u0010', '\u0002', '\u0002', 'Ť', 'Ŧ', '\u0005', '\u001c', '\u000f', '\u0002',
				'ť', 'Ť', '\u0003', '\u0002', '\u0002', '\u0002', 'ť', 'Ŧ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ŧ', '5', '\u0003', '\u0002', '\u0002', '\u0002', ')', '9',
				';', 'D', 'F', 'U', '\\', 'b', 'i', 'l', 'n', 's',
				'{', '\u0086', '\u008c', '\u0099', '¦', '©', '¬', '¶', '¹', '¼',
				'Ì', 'Þ', 'ô', 'û', 'ă', 'ą', 'Č', 'ĕ', 'Ġ', 'Ħ',
				'į', 'Ķ', 'Ļ', 'Ŀ', 'ņ', 'ŋ', 'ŝ', 'ť'
			};
			_ATN = new ATNDeserializer().Deserialize(_serializedATN);
			decisionToDFA = new DFA[_ATN.NumberOfDecisions];
			for (int i = 0; i < _ATN.NumberOfDecisions; i++)
			{
				decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
			}
		}

		public StonescriptParser(ITokenStream input)
			: this(input, Console.Out, Console.Error)
		{
		}

		public StonescriptParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
			: base(input, output, errorOutput)
		{
			Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
		}

		[RuleVersion(0)]
		public ProgramContext program()
		{
			ProgramContext programContext = new ProgramContext(Context, base.State);
			EnterRule(programContext, 0, 0);
			try
			{
				EnterOuterAlt(programContext, 1);
				base.State = 57;
				ErrorHandler.Sync(this);
				int num = base.TokenStream.LA(1);
				while ((num & -64) == 0 && ((1L << num) & -5260061700764139526L) != 0L)
				{
					base.State = 55;
					ErrorHandler.Sync(this);
					switch (base.TokenStream.LA(1))
					{
					case 63:
						base.State = 52;
						Match(63);
						break;
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
					case 8:
					case 9:
					case 10:
					case 11:
					case 12:
					case 13:
					case 14:
					case 15:
					case 20:
					case 22:
					case 24:
					case 26:
					case 27:
					case 31:
					case 38:
					case 39:
					case 40:
					case 47:
					case 56:
					case 57:
					case 58:
					case 60:
					case 61:
						base.State = 53;
						stmt();
						break;
					case 1:
						base.State = 54;
						block();
						break;
					default:
						throw new NoViableAltException(this);
					}
					base.State = 59;
					ErrorHandler.Sync(this);
					num = base.TokenStream.LA(1);
				}
				base.State = 60;
				Match(-1);
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (programContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return programContext;
		}

		[RuleVersion(0)]
		public BlockContext block()
		{
			BlockContext blockContext = new BlockContext(Context, base.State);
			EnterRule(blockContext, 2, 1);
			try
			{
				EnterOuterAlt(blockContext, 1);
				base.State = 62;
				Match(1);
				base.State = 68;
				ErrorHandler.Sync(this);
				int num = base.TokenStream.LA(1);
				while ((num & -64) == 0 && ((1L << num) & -5260061700764139526L) != 0L)
				{
					base.State = 66;
					ErrorHandler.Sync(this);
					switch (base.TokenStream.LA(1))
					{
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
					case 8:
					case 9:
					case 10:
					case 11:
					case 12:
					case 13:
					case 14:
					case 15:
					case 20:
					case 22:
					case 24:
					case 26:
					case 27:
					case 31:
					case 38:
					case 39:
					case 40:
					case 47:
					case 56:
					case 57:
					case 58:
					case 60:
					case 61:
						base.State = 63;
						stmt();
						break;
					case 1:
						base.State = 64;
						block();
						break;
					case 63:
						base.State = 65;
						Match(63);
						break;
					default:
						throw new NoViableAltException(this);
					}
					base.State = 70;
					ErrorHandler.Sync(this);
					num = base.TokenStream.LA(1);
				}
				base.State = 71;
				Match(2);
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (blockContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return blockContext;
		}

		[RuleVersion(0)]
		public StmtContext stmt()
		{
			StmtContext stmtContext = new StmtContext(Context, base.State);
			EnterRule(stmtContext, 4, 2);
			try
			{
				base.State = 90;
				ErrorHandler.Sync(this);
				switch (Interpreter.AdaptivePredict(base.TokenStream, 5, Context))
				{
				case 1:
				{
					EnterOuterAlt(stmtContext, 1);
					base.State = 83;
					ErrorHandler.Sync(this);
					switch (Interpreter.AdaptivePredict(base.TokenStream, 4, Context))
					{
					case 1:
						base.State = 73;
						assignment();
						break;
					case 2:
						base.State = 74;
						break_stmt();
						break;
					case 3:
						base.State = 75;
						continue_stmt();
						break;
					case 4:
						base.State = 76;
						return_stmt();
						break;
					case 5:
						base.State = 77;
						invocation();
						break;
					case 6:
						base.State = 78;
						cmd_stmt();
						break;
					case 7:
						base.State = 79;
						decl_stmt();
						break;
					case 8:
						base.State = 80;
						import_stmt();
						break;
					case 9:
						base.State = 81;
						new_stmt();
						break;
					case 10:
						base.State = 82;
						inc_stmt();
						break;
					}
					base.State = 85;
					int num = base.TokenStream.LA(1);
					if (num != -1 && num != 63)
					{
						ErrorHandler.RecoverInline(this);
						break;
					}
					ErrorHandler.ReportMatch(this);
					Consume();
					break;
				}
				case 2:
					EnterOuterAlt(stmtContext, 2);
					base.State = 87;
					if_stmt();
					break;
				case 3:
					EnterOuterAlt(stmtContext, 3);
					base.State = 88;
					funcdef();
					break;
				case 4:
					EnterOuterAlt(stmtContext, 4);
					base.State = 89;
					for_stmt();
					break;
				}
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (stmtContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return stmtContext;
		}

		[RuleVersion(0)]
		public Cmd_stmtContext cmd_stmt()
		{
			Cmd_stmtContext cmd_stmtContext = new Cmd_stmtContext(Context, base.State);
			EnterRule(cmd_stmtContext, 6, 3);
			try
			{
				EnterOuterAlt(cmd_stmtContext, 1);
				base.State = 92;
				Match(3);
				base.State = 108;
				ErrorHandler.Sync(this);
				switch (Interpreter.AdaptivePredict(base.TokenStream, 9, Context))
				{
				case 1:
				{
					base.State = 96;
					ErrorHandler.Sync(this);
					int num = base.TokenStream.LA(1);
					while (((num - 66) & -64) == 0 && ((1L << num - 66) & 7) != 0L)
					{
						base.State = 93;
						num = base.TokenStream.LA(1);
						if (((num - 66) & -64) != 0 || ((1L << num - 66) & 7) == 0L)
						{
							ErrorHandler.RecoverInline(this);
						}
						else
						{
							ErrorHandler.ReportMatch(this);
							Consume();
						}
						base.State = 98;
						ErrorHandler.Sync(this);
						num = base.TokenStream.LA(1);
					}
					break;
				}
				case 2:
				{
					base.State = 106;
					ErrorHandler.Sync(this);
					int num = base.TokenStream.LA(1);
					if (num != 71)
					{
						break;
					}
					base.State = 99;
					Match(71);
					base.State = 103;
					ErrorHandler.Sync(this);
					num = base.TokenStream.LA(1);
					while (((num - 71) & -64) == 0 && ((1L << num - 71) & 7) != 0L)
					{
						base.State = 100;
						num = base.TokenStream.LA(1);
						if (((num - 71) & -64) != 0 || ((1L << num - 71) & 7) == 0L)
						{
							ErrorHandler.RecoverInline(this);
						}
						else
						{
							ErrorHandler.ReportMatch(this);
							Consume();
						}
						base.State = 105;
						ErrorHandler.Sync(this);
						num = base.TokenStream.LA(1);
					}
					break;
				}
				}
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (cmd_stmtContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return cmd_stmtContext;
		}

		[RuleVersion(0)]
		public LvalueContext lvalue()
		{
			LvalueContext lvalueContext = new LvalueContext(Context, base.State);
			EnterRule(lvalueContext, 8, 4);
			try
			{
				base.State = 121;
				ErrorHandler.Sync(this);
				switch (Interpreter.AdaptivePredict(base.TokenStream, 11, Context))
				{
				case 1:
					EnterOuterAlt(lvalueContext, 1);
					base.State = 113;
					ErrorHandler.Sync(this);
					if (Interpreter.AdaptivePredict(base.TokenStream, 10, Context) == 1)
					{
						base.State = 110;
						expression(0);
						base.State = 111;
						Match(51);
					}
					base.State = 115;
					Match(57);
					break;
				case 2:
					EnterOuterAlt(lvalueContext, 2);
					base.State = 116;
					expression(0);
					base.State = 117;
					Match(22);
					base.State = 118;
					expression(0);
					base.State = 119;
					Match(23);
					break;
				}
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (lvalueContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return lvalueContext;
		}

		[RuleVersion(0)]
		public AssignmentContext assignment()
		{
			AssignmentContext assignmentContext = new AssignmentContext(Context, base.State);
			EnterRule(assignmentContext, 10, 5);
			try
			{
				EnterOuterAlt(assignmentContext, 1);
				base.State = 123;
				lvalue();
				base.State = 124;
				int num = base.TokenStream.LA(1);
				if ((num & -64) != 0 || ((1L << num) & 0x3C10000000L) == 0L)
				{
					ErrorHandler.RecoverInline(this);
				}
				else
				{
					ErrorHandler.ReportMatch(this);
					Consume();
				}
				base.State = 125;
				expression(0);
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (assignmentContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return assignmentContext;
		}

		[RuleVersion(0)]
		public Inc_stmtContext inc_stmt()
		{
			Inc_stmtContext inc_stmtContext = new Inc_stmtContext(Context, base.State);
			EnterRule(inc_stmtContext, 12, 6);
			try
			{
				base.State = 132;
				ErrorHandler.Sync(this);
				switch (base.TokenStream.LA(1))
				{
				case 38:
				case 39:
				{
					EnterOuterAlt(inc_stmtContext, 1);
					base.State = 127;
					int num = base.TokenStream.LA(1);
					if (num != 38 && num != 39)
					{
						ErrorHandler.RecoverInline(this);
					}
					else
					{
						ErrorHandler.ReportMatch(this);
						Consume();
					}
					base.State = 128;
					qualifiedId();
					break;
				}
				case 57:
				{
					EnterOuterAlt(inc_stmtContext, 2);
					base.State = 129;
					qualifiedId();
					base.State = 130;
					int num = base.TokenStream.LA(1);
					if (num != 38 && num != 39)
					{
						ErrorHandler.RecoverInline(this);
						break;
					}
					ErrorHandler.ReportMatch(this);
					Consume();
					break;
				}
				default:
					throw new NoViableAltException(this);
				}
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (inc_stmtContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return inc_stmtContext;
		}

		[RuleVersion(0)]
		public Decl_stmtContext decl_stmt()
		{
			Decl_stmtContext decl_stmtContext = new Decl_stmtContext(Context, base.State);
			EnterRule(decl_stmtContext, 14, 7);
			try
			{
				EnterOuterAlt(decl_stmtContext, 1);
				base.State = 134;
				int num = base.TokenStream.LA(1);
				if (num != 5 && num != 6)
				{
					ErrorHandler.RecoverInline(this);
				}
				else
				{
					ErrorHandler.ReportMatch(this);
					Consume();
				}
				base.State = 135;
				Match(57);
				base.State = 138;
				ErrorHandler.Sync(this);
				num = base.TokenStream.LA(1);
				if (num == 28)
				{
					base.State = 136;
					Match(28);
					base.State = 137;
					expression(0);
				}
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (decl_stmtContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return decl_stmtContext;
		}

		[RuleVersion(0)]
		public Import_stmtContext import_stmt()
		{
			Import_stmtContext import_stmtContext = new Import_stmtContext(Context, base.State);
			EnterRule(import_stmtContext, 16, 8);
			try
			{
				EnterOuterAlt(import_stmtContext, 1);
				base.State = 140;
				Match(8);
				base.State = 141;
				int num = base.TokenStream.LA(1);
				if (num != 57 && num != 59)
				{
					ErrorHandler.RecoverInline(this);
				}
				else
				{
					ErrorHandler.ReportMatch(this);
					Consume();
				}
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (import_stmtContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return import_stmtContext;
		}

		[RuleVersion(0)]
		public New_stmtContext new_stmt()
		{
			New_stmtContext new_stmtContext = new New_stmtContext(Context, base.State);
			EnterRule(new_stmtContext, 18, 9);
			try
			{
				EnterOuterAlt(new_stmtContext, 1);
				base.State = 143;
				Match(7);
				base.State = 144;
				int num = base.TokenStream.LA(1);
				if (num != 57 && num != 59)
				{
					ErrorHandler.RecoverInline(this);
				}
				else
				{
					ErrorHandler.ReportMatch(this);
					Consume();
				}
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (new_stmtContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return new_stmtContext;
		}

		[RuleVersion(0)]
		public QualifiedIdContext qualifiedId()
		{
			QualifiedIdContext qualifiedIdContext = new QualifiedIdContext(Context, base.State);
			EnterRule(qualifiedIdContext, 20, 10);
			try
			{
				EnterOuterAlt(qualifiedIdContext, 1);
				base.State = 146;
				Match(57);
				base.State = 151;
				ErrorHandler.Sync(this);
				int num = Interpreter.AdaptivePredict(base.TokenStream, 14, Context);
				while (true)
				{
					switch (num)
					{
					case 1:
						base.State = 147;
						Match(51);
						base.State = 148;
						Match(57);
						break;
					case 0:
					case 2:
						goto end_IL_00c9;
					}
					base.State = 153;
					ErrorHandler.Sync(this);
					num = Interpreter.AdaptivePredict(base.TokenStream, 14, Context);
					continue;
					end_IL_00c9:
					break;
				}
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (qualifiedIdContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return qualifiedIdContext;
		}

		[RuleVersion(0)]
		public ObjectContext @object()
		{
			ObjectContext objectContext = new ObjectContext(Context, base.State);
			EnterRule(objectContext, 22, 11);
			try
			{
				EnterOuterAlt(objectContext, 1);
				base.State = 154;
				Match(24);
				base.State = 167;
				ErrorHandler.Sync(this);
				if (base.TokenStream.LA(1) == 57)
				{
					base.State = 155;
					Match(57);
					base.State = 156;
					Match(46);
					base.State = 157;
					expression(0);
					base.State = 164;
					ErrorHandler.Sync(this);
					int num = Interpreter.AdaptivePredict(base.TokenStream, 15, Context);
					while (true)
					{
						switch (num)
						{
						case 1:
							base.State = 158;
							Match(49);
							base.State = 159;
							Match(57);
							base.State = 160;
							Match(46);
							base.State = 161;
							expression(0);
							goto IL_0127;
						default:
							goto IL_0127;
						case 0:
						case 2:
							break;
						}
						break;
						IL_0127:
						base.State = 166;
						ErrorHandler.Sync(this);
						num = Interpreter.AdaptivePredict(base.TokenStream, 15, Context);
					}
				}
				base.State = 170;
				ErrorHandler.Sync(this);
				if (base.TokenStream.LA(1) == 49)
				{
					base.State = 169;
					Match(49);
				}
				base.State = 172;
				Match(25);
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (objectContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return objectContext;
		}

		[RuleVersion(0)]
		public ArrayContext array()
		{
			ArrayContext arrayContext = new ArrayContext(Context, base.State);
			EnterRule(arrayContext, 24, 12);
			try
			{
				EnterOuterAlt(arrayContext, 1);
				base.State = 174;
				Match(22);
				base.State = 183;
				ErrorHandler.Sync(this);
				int num = base.TokenStream.LA(1);
				if ((num & -64) == 0 && ((1L << num) & 0x370001C081503F90L) != 0L)
				{
					base.State = 175;
					expression(0);
					base.State = 180;
					ErrorHandler.Sync(this);
					int num2 = Interpreter.AdaptivePredict(base.TokenStream, 18, Context);
					while (true)
					{
						switch (num2)
						{
						case 1:
							base.State = 176;
							Match(49);
							base.State = 177;
							expression(0);
							goto IL_00ed;
						default:
							goto IL_00ed;
						case 0:
						case 2:
							break;
						}
						break;
						IL_00ed:
						base.State = 182;
						ErrorHandler.Sync(this);
						num2 = Interpreter.AdaptivePredict(base.TokenStream, 18, Context);
					}
				}
				base.State = 186;
				ErrorHandler.Sync(this);
				num = base.TokenStream.LA(1);
				if (num == 49)
				{
					base.State = 185;
					Match(49);
				}
				base.State = 188;
				Match(23);
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (arrayContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return arrayContext;
		}

		[RuleVersion(0)]
		public ExpressionContext expression()
		{
			return expression(0);
		}

		private ExpressionContext expression(int _p)
		{
			ParserRuleContext context = Context;
			int state = base.State;
			ExpressionContext expressionContext = new ExpressionContext(Context, state);
			int state2 = 26;
			EnterRecursionRule(expressionContext, 26, 13, _p);
			try
			{
				EnterOuterAlt(expressionContext, 1);
				base.State = 220;
				ErrorHandler.Sync(this);
				int num;
				switch (Interpreter.AdaptivePredict(base.TokenStream, 22, Context))
				{
				case 1:
					base.State = 191;
					qualifiedId();
					break;
				case 2:
					base.State = 192;
					Match(56);
					break;
				case 3:
					base.State = 193;
					Match(4);
					break;
				case 4:
					base.State = 194;
					Match(10);
					break;
				case 5:
					base.State = 195;
					Match(11);
					break;
				case 6:
					base.State = 196;
					Match(12);
					break;
				case 7:
					base.State = 197;
					Match(58);
					break;
				case 8:
					base.State = 198;
					Match(60);
					break;
				case 9:
					base.State = 200;
					ErrorHandler.Sync(this);
					num = 1;
					do
					{
						if (num == 1)
						{
							base.State = 199;
							Match(57);
							base.State = 202;
							ErrorHandler.Sync(this);
							num = Interpreter.AdaptivePredict(base.TokenStream, 21, Context);
							continue;
						}
						throw new NoViableAltException(this);
					}
					while (num != 2 && num != 0);
					break;
				case 10:
					base.State = 204;
					Match(61);
					break;
				case 11:
					base.State = 205;
					Match(9);
					break;
				case 12:
					base.State = 206;
					@object();
					break;
				case 13:
					base.State = 207;
					array();
					break;
				case 14:
					base.State = 208;
					lambda();
					break;
				case 15:
					base.State = 209;
					new_stmt();
					break;
				case 16:
					base.State = 210;
					import_stmt();
					break;
				case 17:
					base.State = 211;
					inc_stmt();
					break;
				case 18:
					base.State = 212;
					Match(20);
					base.State = 213;
					expression(0);
					base.State = 214;
					Match(21);
					break;
				case 19:
					base.State = 216;
					Match(31);
					base.State = 217;
					expression(8);
					break;
				case 20:
					base.State = 218;
					Match(40);
					base.State = 219;
					expression(7);
					break;
				}
				Context.Stop = base.TokenStream.LT(-1);
				base.State = 259;
				ErrorHandler.Sync(this);
				num = Interpreter.AdaptivePredict(base.TokenStream, 26, Context);
				while (true)
				{
					switch (num)
					{
					case 1:
						if (ParseListeners != null)
						{
							TriggerExitRuleEvent();
						}
						base.State = 257;
						ErrorHandler.Sync(this);
						switch (Interpreter.AdaptivePredict(base.TokenStream, 25, Context))
						{
						case 1:
						{
							expressionContext = new ExpressionContext(context, state);
							PushNewRecursionContext(expressionContext, state2, 13);
							base.State = 222;
							if (!Precpred(Context, 6))
							{
								throw new FailedPredicateException(this, "Precpred(Context, 6)");
							}
							base.State = 223;
							int num2 = base.TokenStream.LA(1);
							if ((num2 & -64) != 0 || ((1L << num2) & 0x1000300000000L) == 0L)
							{
								ErrorHandler.RecoverInline(this);
							}
							else
							{
								ErrorHandler.ReportMatch(this);
								Consume();
							}
							base.State = 224;
							expression(7);
							break;
						}
						case 2:
						{
							expressionContext = new ExpressionContext(context, state);
							PushNewRecursionContext(expressionContext, state2, 13);
							base.State = 225;
							if (!Precpred(Context, 5))
							{
								throw new FailedPredicateException(this, "Precpred(Context, 5)");
							}
							base.State = 226;
							int num2 = base.TokenStream.LA(1);
							if (num2 != 30 && num2 != 31)
							{
								ErrorHandler.RecoverInline(this);
							}
							else
							{
								ErrorHandler.ReportMatch(this);
								Consume();
							}
							base.State = 227;
							expression(6);
							break;
						}
						case 3:
						{
							expressionContext = new ExpressionContext(context, state);
							PushNewRecursionContext(expressionContext, state2, 13);
							base.State = 228;
							if (!Precpred(Context, 4))
							{
								throw new FailedPredicateException(this, "Precpred(Context, 4)");
							}
							base.State = 229;
							int num2 = base.TokenStream.LA(1);
							if ((num2 & -64) != 0 || ((1L << num2) & 0x200000000E0000L) == 0L)
							{
								ErrorHandler.RecoverInline(this);
							}
							else
							{
								ErrorHandler.ReportMatch(this);
								Consume();
							}
							base.State = 230;
							expression(5);
							break;
						}
						case 4:
						{
							expressionContext = new ExpressionContext(context, state);
							PushNewRecursionContext(expressionContext, state2, 13);
							base.State = 231;
							if (!Precpred(Context, 3))
							{
								throw new FailedPredicateException(this, "Precpred(Context, 3)");
							}
							base.State = 232;
							int num2 = base.TokenStream.LA(1);
							if ((num2 & -64) != 0 || ((1L << num2) & 0x30030000000L) == 0L)
							{
								ErrorHandler.RecoverInline(this);
							}
							else
							{
								ErrorHandler.ReportMatch(this);
								Consume();
							}
							base.State = 233;
							expression(4);
							break;
						}
						case 5:
						{
							expressionContext = new ExpressionContext(context, state);
							PushNewRecursionContext(expressionContext, state2, 13);
							base.State = 234;
							if (!Precpred(Context, 2))
							{
								throw new FailedPredicateException(this, "Precpred(Context, 2)");
							}
							base.State = 235;
							int num2 = base.TokenStream.LA(1);
							if (num2 != 43 && num2 != 45)
							{
								ErrorHandler.RecoverInline(this);
							}
							else
							{
								ErrorHandler.ReportMatch(this);
								Consume();
							}
							base.State = 236;
							expression(3);
							break;
						}
						case 6:
						{
							expressionContext = new ExpressionContext(context, state);
							PushNewRecursionContext(expressionContext, state2, 13);
							base.State = 237;
							if (!Precpred(Context, 1))
							{
								throw new FailedPredicateException(this, "Precpred(Context, 1)");
							}
							base.State = 238;
							int num2 = base.TokenStream.LA(1);
							if (num2 != 42 && num2 != 44)
							{
								ErrorHandler.RecoverInline(this);
							}
							else
							{
								ErrorHandler.ReportMatch(this);
								Consume();
							}
							base.State = 239;
							expression(2);
							break;
						}
						case 7:
						{
							expressionContext = new ExpressionContext(context, state);
							PushNewRecursionContext(expressionContext, state2, 13);
							base.State = 240;
							if (!Precpred(Context, 28))
							{
								throw new FailedPredicateException(this, "Precpred(Context, 28)");
							}
							base.State = 242;
							ErrorHandler.Sync(this);
							int num2 = base.TokenStream.LA(1);
							if (num2 == 63)
							{
								base.State = 241;
								Match(63);
							}
							base.State = 244;
							Match(51);
							base.State = 245;
							Match(57);
							break;
						}
						case 8:
						{
							expressionContext = new ExpressionContext(context, state);
							PushNewRecursionContext(expressionContext, state2, 13);
							base.State = 246;
							if (!Precpred(Context, 11))
							{
								throw new FailedPredicateException(this, "Precpred(Context, 11)");
							}
							base.State = 247;
							Match(20);
							base.State = 249;
							ErrorHandler.Sync(this);
							int num2 = base.TokenStream.LA(1);
							if ((num2 & -64) == 0 && ((1L << num2) & 0x370001C081503F90L) != 0L)
							{
								base.State = 248;
								paramlist();
							}
							base.State = 251;
							Match(21);
							break;
						}
						case 9:
							expressionContext = new ExpressionContext(context, state);
							PushNewRecursionContext(expressionContext, state2, 13);
							base.State = 252;
							if (!Precpred(Context, 10))
							{
								throw new FailedPredicateException(this, "Precpred(Context, 10)");
							}
							base.State = 253;
							Match(22);
							base.State = 254;
							expression(0);
							base.State = 255;
							Match(23);
							break;
						}
						break;
					case 0:
					case 2:
						goto end_IL_09ce;
					}
					base.State = 261;
					ErrorHandler.Sync(this);
					num = Interpreter.AdaptivePredict(base.TokenStream, 26, Context);
					continue;
					end_IL_09ce:
					break;
				}
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (expressionContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				UnrollRecursionContexts(context);
			}
			return expressionContext;
		}

		[RuleVersion(0)]
		public FuncdefContext funcdef()
		{
			FuncdefContext funcdefContext = new FuncdefContext(Context, base.State);
			EnterRule(funcdefContext, 28, 14);
			try
			{
				EnterOuterAlt(funcdefContext, 1);
				base.State = 262;
				Match(13);
				base.State = 263;
				Match(57);
				base.State = 264;
				Match(20);
				base.State = 266;
				ErrorHandler.Sync(this);
				if (base.TokenStream.LA(1) == 57)
				{
					base.State = 265;
					varlist();
				}
				base.State = 268;
				Match(21);
				base.State = 269;
				Match(63);
				base.State = 270;
				block();
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (funcdefContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return funcdefContext;
		}

		[RuleVersion(0)]
		public LambdaContext lambda()
		{
			LambdaContext lambdaContext = new LambdaContext(Context, base.State);
			EnterRule(lambdaContext, 30, 15);
			try
			{
				EnterOuterAlt(lambdaContext, 1);
				base.State = 272;
				Match(13);
				base.State = 273;
				Match(20);
				base.State = 275;
				ErrorHandler.Sync(this);
				if (base.TokenStream.LA(1) == 57)
				{
					base.State = 274;
					varlist();
				}
				base.State = 277;
				Match(21);
				base.State = 278;
				Match(63);
				base.State = 279;
				block();
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (lambdaContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return lambdaContext;
		}

		[RuleVersion(0)]
		public VarlistContext varlist()
		{
			VarlistContext varlistContext = new VarlistContext(Context, base.State);
			EnterRule(varlistContext, 32, 16);
			try
			{
				EnterOuterAlt(varlistContext, 1);
				base.State = 281;
				Match(57);
				base.State = 286;
				ErrorHandler.Sync(this);
				for (int num = base.TokenStream.LA(1); num == 49; num = base.TokenStream.LA(1))
				{
					base.State = 282;
					Match(49);
					base.State = 283;
					Match(57);
					base.State = 288;
					ErrorHandler.Sync(this);
				}
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (varlistContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return varlistContext;
		}

		[RuleVersion(0)]
		public InvocationContext invocation()
		{
			InvocationContext invocationContext = new InvocationContext(Context, base.State);
			EnterRule(invocationContext, 34, 17);
			try
			{
				EnterOuterAlt(invocationContext, 1);
				base.State = 289;
				expression(0);
				base.State = 290;
				Match(20);
				base.State = 292;
				ErrorHandler.Sync(this);
				int num = base.TokenStream.LA(1);
				if ((num & -64) == 0 && ((1L << num) & 0x370001C081503F90L) != 0L)
				{
					base.State = 291;
					paramlist();
				}
				base.State = 294;
				Match(21);
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (invocationContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return invocationContext;
		}

		[RuleVersion(0)]
		public ParamlistContext paramlist()
		{
			ParamlistContext paramlistContext = new ParamlistContext(Context, base.State);
			EnterRule(paramlistContext, 36, 18);
			try
			{
				EnterOuterAlt(paramlistContext, 1);
				base.State = 296;
				expression(0);
				base.State = 301;
				ErrorHandler.Sync(this);
				for (int num = base.TokenStream.LA(1); num == 49; num = base.TokenStream.LA(1))
				{
					base.State = 297;
					Match(49);
					base.State = 298;
					expression(0);
					base.State = 303;
					ErrorHandler.Sync(this);
				}
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (paramlistContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return paramlistContext;
		}

		[RuleVersion(0)]
		public If_stmtContext if_stmt()
		{
			If_stmtContext if_stmtContext = new If_stmtContext(Context, base.State);
			EnterRule(if_stmtContext, 38, 19);
			try
			{
				EnterOuterAlt(if_stmtContext, 1);
				base.State = 304;
				Match(47);
				base.State = 305;
				expression(0);
				base.State = 306;
				Match(63);
				base.State = 308;
				ErrorHandler.Sync(this);
				if (Interpreter.AdaptivePredict(base.TokenStream, 32, Context) == 1)
				{
					base.State = 307;
					block();
				}
				base.State = 313;
				ErrorHandler.Sync(this);
				int num = Interpreter.AdaptivePredict(base.TokenStream, 33, Context);
				while (true)
				{
					switch (num)
					{
					case 1:
						base.State = 310;
						else_if_stmt();
						break;
					case 0:
					case 2:
						base.State = 317;
						ErrorHandler.Sync(this);
						if (base.TokenStream.LA(1) == 46)
						{
							base.State = 316;
							else_stmt();
						}
						goto end_IL_011f;
					}
					base.State = 315;
					ErrorHandler.Sync(this);
					num = Interpreter.AdaptivePredict(base.TokenStream, 33, Context);
					continue;
					end_IL_011f:
					break;
				}
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (if_stmtContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return if_stmtContext;
		}

		[RuleVersion(0)]
		public Else_if_stmtContext else_if_stmt()
		{
			Else_if_stmtContext else_if_stmtContext = new Else_if_stmtContext(Context, base.State);
			EnterRule(else_if_stmtContext, 40, 20);
			try
			{
				EnterOuterAlt(else_if_stmtContext, 1);
				base.State = 319;
				Match(46);
				base.State = 320;
				Match(47);
				base.State = 321;
				expression(0);
				base.State = 322;
				Match(63);
				base.State = 324;
				ErrorHandler.Sync(this);
				if (Interpreter.AdaptivePredict(base.TokenStream, 35, Context) == 1)
				{
					base.State = 323;
					block();
				}
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (else_if_stmtContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return else_if_stmtContext;
		}

		[RuleVersion(0)]
		public Else_stmtContext else_stmt()
		{
			Else_stmtContext else_stmtContext = new Else_stmtContext(Context, base.State);
			EnterRule(else_stmtContext, 42, 21);
			try
			{
				EnterOuterAlt(else_stmtContext, 1);
				base.State = 326;
				Match(46);
				base.State = 327;
				Match(63);
				base.State = 329;
				ErrorHandler.Sync(this);
				if (Interpreter.AdaptivePredict(base.TokenStream, 36, Context) == 1)
				{
					base.State = 328;
					block();
				}
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (else_stmtContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return else_stmtContext;
		}

		[RuleVersion(0)]
		public For_stmtContext for_stmt()
		{
			For_stmtContext for_stmtContext = new For_stmtContext(Context, base.State);
			EnterRule(for_stmtContext, 44, 22);
			try
			{
				base.State = 347;
				ErrorHandler.Sync(this);
				switch (Interpreter.AdaptivePredict(base.TokenStream, 37, Context))
				{
				case 1:
					EnterOuterAlt(for_stmtContext, 1);
					base.State = 331;
					Match(15);
					base.State = 332;
					Match(57);
					base.State = 333;
					Match(28);
					base.State = 334;
					expression(0);
					base.State = 335;
					Match(50);
					base.State = 336;
					expression(0);
					base.State = 337;
					Match(63);
					base.State = 338;
					block();
					break;
				case 2:
					EnterOuterAlt(for_stmtContext, 2);
					base.State = 340;
					Match(15);
					base.State = 341;
					Match(57);
					base.State = 342;
					Match(46);
					base.State = 343;
					expression(0);
					base.State = 344;
					Match(63);
					base.State = 345;
					block();
					break;
				}
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (for_stmtContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return for_stmtContext;
		}

		[RuleVersion(0)]
		public Break_stmtContext break_stmt()
		{
			Break_stmtContext break_stmtContext = new Break_stmtContext(Context, base.State);
			EnterRule(break_stmtContext, 46, 23);
			try
			{
				EnterOuterAlt(break_stmtContext, 1);
				base.State = 349;
				Match(26);
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (break_stmtContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return break_stmtContext;
		}

		[RuleVersion(0)]
		public Continue_stmtContext continue_stmt()
		{
			Continue_stmtContext continue_stmtContext = new Continue_stmtContext(Context, base.State);
			EnterRule(continue_stmtContext, 48, 24);
			try
			{
				EnterOuterAlt(continue_stmtContext, 1);
				base.State = 351;
				Match(27);
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (continue_stmtContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return continue_stmtContext;
		}

		[RuleVersion(0)]
		public Return_stmtContext return_stmt()
		{
			Return_stmtContext return_stmtContext = new Return_stmtContext(Context, base.State);
			EnterRule(return_stmtContext, 50, 25);
			try
			{
				EnterOuterAlt(return_stmtContext, 1);
				base.State = 353;
				Match(14);
				base.State = 355;
				ErrorHandler.Sync(this);
				int num = base.TokenStream.LA(1);
				if ((num & -64) == 0 && ((1L << num) & 0x370001C081503F90L) != 0L)
				{
					base.State = 354;
					expression(0);
				}
			}
			catch (RecognitionException exception)
			{
				RecognitionException e = (return_stmtContext.exception = exception);
				ErrorHandler.ReportError(this, e);
				ErrorHandler.Recover(this, e);
			}
			finally
			{
				ExitRule();
			}
			return return_stmtContext;
		}

		public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex)
		{
			if (ruleIndex == 13)
			{
				return expression_sempred((ExpressionContext)_localctx, predIndex);
			}
			return true;
		}

		private bool expression_sempred(ExpressionContext _localctx, int predIndex)
		{
			return predIndex switch
			{
				0 => Precpred(Context, 6), 
				1 => Precpred(Context, 5), 
				2 => Precpred(Context, 4), 
				3 => Precpred(Context, 3), 
				4 => Precpred(Context, 2), 
				5 => Precpred(Context, 1), 
				6 => Precpred(Context, 28), 
				7 => Precpred(Context, 11), 
				8 => Precpred(Context, 10), 
				_ => true, 
			};
		}
	}
}
