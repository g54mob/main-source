using System;
using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter.Tree.Expressions
{
	internal class BinaryOperatorExpression : Expression
	{
		[Flags]
		private enum Operator
		{
			NotAnOperator = 0,
			Or = 1,
			And = 2,
			Less = 4,
			Greater = 8,
			LessOrEqual = 0x10,
			GreaterOrEqual = 0x20,
			NotEqual = 0x40,
			Equal = 0x80,
			StrConcat = 0x100,
			Add = 0x200,
			Sub = 0x400,
			Mul = 0x1000,
			Div = 0x2000,
			Mod = 0x4000,
			Power = 0x8000
		}

		private class Node
		{
			public Expression Expr;

			public Operator Op;

			public Node Prev;

			public Node Next;
		}

		private class LinkedList
		{
			public Node Nodes;

			public Node Last;

			public Operator OperatorMask;
		}

		private const Operator POWER = Operator.Power;

		private const Operator MUL_DIV_MOD = Operator.Mul | Operator.Div | Operator.Mod;

		private const Operator ADD_SUB = Operator.Add | Operator.Sub;

		private const Operator STRCAT = Operator.StrConcat;

		private const Operator COMPARES = Operator.Less | Operator.Greater | Operator.LessOrEqual | Operator.GreaterOrEqual | Operator.NotEqual | Operator.Equal;

		private const Operator LOGIC_AND = Operator.And;

		private const Operator LOGIC_OR = Operator.Or;

		private Expression m_Exp1;

		private Expression m_Exp2;

		private Operator m_Operator;

		public static object BeginOperatorChain()
		{
			return null;
		}

		public static void AddExpressionToChain(object chain, Expression exp)
		{
		}

		public static void AddOperatorToChain(object chain, Token op)
		{
		}

		public static Expression CommitOperatorChain(object chain, ScriptLoadingContext lcontext)
		{
			return null;
		}

		public static Expression CreatePowerExpression(Expression op1, Expression op2, ScriptLoadingContext lcontext)
		{
			return null;
		}

		private static void AddNode(LinkedList list, Node node)
		{
		}

		private static Expression CreateSubTree(LinkedList list, ScriptLoadingContext lcontext)
		{
			return null;
		}

		private static Node PrioritizeLeftAssociative(Node nodes, ScriptLoadingContext lcontext, Operator operatorsToFind)
		{
			return null;
		}

		private static Node PrioritizeRightAssociative(Node nodes, ScriptLoadingContext lcontext, Operator operatorsToFind)
		{
			return null;
		}

		private static Operator ParseBinaryOperator(Token token)
		{
			return default(Operator);
		}

		private BinaryOperatorExpression(Expression exp1, Expression exp2, Operator op, ScriptLoadingContext lcontext)
			: base(null)
		{
		}

		private static bool ShouldInvertBoolean(Operator op)
		{
			return false;
		}

		private static OpCode OperatorToOpCode(Operator op)
		{
			return default(OpCode);
		}

		public override void Compile(ByteCode bc)
		{
		}

		public override DynValue Eval(ScriptExecutionContext context)
		{
			return null;
		}

		private double EvalArithmetic(DynValue v1, DynValue v2)
		{
			return 0.0;
		}

		private bool EvalComparison(DynValue l, DynValue r, Operator op)
		{
			return false;
		}
	}
}
