using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Stonescript.Compiler;
using Stonescript.Runtime;
using Stonescript.Types;
using UnityEngine;

namespace Stonescript
{
	public class Processor : Visitor
	{
		protected ExecutionContext execCtx;

		private StringBuilder stringBuilder = new StringBuilder(512);

		public override Script script => execCtx.CurrentExecutable.script;

		protected override StonescriptObject target => execCtx.CurrentTarget;

		protected override StonescriptObject This
		{
			get
			{
				List<InvocationContext> callStack = execCtx.callStack;
				for (int num = callStack.Count - 1; num >= 0; num--)
				{
					if (callStack[num].owner != null)
					{
						return callStack[num].owner;
					}
				}
				return callStack[0].scope;
			}
		}

		public ExecutionContext ExecutionContext
		{
			get
			{
				return execCtx;
			}
			set
			{
				execCtx = value;
			}
		}

		public Processor(Machine machine)
			: base(machine)
		{
		}

		protected void Warn(string message, IParseTree node)
		{
			RuntimeException ex = new RuntimeException(execCtx, node, message);
			ex.level = StonescriptException.Level.Warning;
			machine.HandleException(ex);
		}

		protected override StonescriptException CreateException(string message, IParseTree node, Exception innerException = null, StonescriptException.Level level = StonescriptException.Level.Error)
		{
			return new RuntimeException(execCtx, node, message, innerException);
		}

		public object Execute(Executable executable, ExecutionContext execCtx)
		{
			ExecutionContext executionContext = this.execCtx;
			this.execCtx = execCtx;
			long startTime = execCtx.startTime;
			execCtx.startTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
			execCtx.Push(executable);
			try
			{
				object result = executable.script.parseTree.root.Accept(this);
				execCtx.PopExecutable();
				execCtx.startTime = startTime;
				this.execCtx = executionContext;
				return result;
			}
			catch (Exception)
			{
				execCtx.PopExecutable();
				execCtx.startTime = startTime;
				this.execCtx = executionContext;
				throw;
			}
		}

		public object ExecuteExpression(Executable executable, ExecutionContext execCtx)
		{
			ExecutionContext executionContext = this.execCtx;
			this.execCtx = execCtx;
			bool flag = false;
			if (execCtx.CurrentExecutable == null)
			{
				execCtx.Push(executable);
				flag = true;
			}
			try
			{
				object result = executable.script.parseTree.root.Accept(this);
				if (flag)
				{
					execCtx.PopExecutable();
				}
				this.execCtx = executionContext;
				return result;
			}
			catch (Exception)
			{
				if (flag)
				{
					execCtx.PopExecutable();
				}
				this.execCtx = executionContext;
				throw;
			}
		}

		public object Execute(Executable executable, IFunction function, IEnumerable<object> parameters, ExecutionContext execCtx)
		{
			ExecutionContext executionContext = this.execCtx;
			this.execCtx = execCtx;
			long startTime = execCtx.startTime;
			execCtx.startTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
			List<object> list = parameters as List<object>;
			bool flag = false;
			if (list == null)
			{
				flag = true;
				list = machine.objectListPool.Get();
				if (parameters != null)
				{
					list.AddRange(parameters);
				}
			}
			try
			{
				InvocationContext ctx = execCtx.Push(executable, function, list);
				object result = function.Invoke(list, ctx);
				execCtx.PopExecutable();
				if (flag)
				{
					machine.objectListPool.Return(list);
				}
				execCtx.startTime = startTime;
				this.execCtx = executionContext;
				return result;
			}
			catch (Exception)
			{
				execCtx.PopExecutable();
				if (flag)
				{
					machine.objectListPool.Return(list);
				}
				execCtx.startTime = startTime;
				this.execCtx = executionContext;
				throw;
			}
		}

		protected virtual Exception CreateException(string message, ParserRuleContext context, Exception innerException = null)
		{
			return new RuntimeException(execCtx, context, message, innerException);
		}

		protected override bool ShouldVisitNextChild(IRuleNode node, object currentResult)
		{
			if (!execCtx.returned && !execCtx.breaked)
			{
				return !execCtx.continued;
			}
			return false;
		}

		public override object VisitStmt([NotNull] StonescriptParser.StmtContext context)
		{
			try
			{
				execCtx.CurrentStatement = context;
				return VisitChildren(context);
			}
			catch (Exception ex)
			{
				if (!(ex is RuntimeException))
				{
					ex = CreateException(ex.Message, context, ex);
				}
				machine.HandleException(ex);
				return null;
			}
		}

		public override object VisitTerminal(ITerminalNode node)
		{
			if (script.parseTree.TryGetConstant(node, out var value))
			{
				return value;
			}
			return VisitTerminalImpl(node);
		}

		public override object VisitQualifiedId([NotNull] StonescriptParser.QualifiedIdContext context)
		{
			return GetValue(context);
		}

		public override object VisitArray([NotNull] StonescriptParser.ArrayContext context)
		{
			StonescriptParser.ExpressionContext[] array = context.expression();
			StonescriptArray stonescriptArray = new StonescriptArray(array.Length);
			StonescriptParser.ExpressionContext[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				object o = array2[i].Accept(this);
				stonescriptArray.Add(o);
			}
			return stonescriptArray;
		}

		public override object VisitObject([NotNull] StonescriptParser.ObjectContext context)
		{
			StonescriptObject stonescriptObject = new StonescriptObject();
			ITerminalNode[] array = context.ID();
			StonescriptParser.ExpressionContext[] array2 = context.expression();
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				string id = GetId(array[i]);
				object value = array2[i].Accept(this);
				stonescriptObject.Declare(id, value);
			}
			return stonescriptObject;
		}

		public override object VisitNew_stmt([NotNull] StonescriptParser.New_stmtContext context)
		{
			string scriptName = context.children[1].Accept(this) as string;
			return machine.New(scriptName, execCtx).Target;
		}

		public override object VisitImport_stmt([NotNull] StonescriptParser.Import_stmtContext context)
		{
			string scriptName = context.children[1].Accept(this) as string;
			return machine.Import(scriptName, execCtx).Target;
		}

		public override object VisitCmd_stmt([NotNull] StonescriptParser.Cmd_stmtContext context)
		{
			IList<IParseTree> children = context.children;
			string commandId = DataTypes.ToString(context.COMMAND().Accept(this));
			stringBuilder.Clear();
			for (int i = 1; i < children.Count; i++)
			{
				string value = children[i].Accept(this) as string;
				stringBuilder.Append(value);
			}
			string parameters = stringBuilder.ToString();
			return machine.ExecuteCommand(commandId, parameters, execCtx);
		}

		public override object VisitExpression([NotNull] StonescriptParser.ExpressionContext context)
		{
			object value = null;
			if (script.parseTree.TryGetConstant(context, out value))
			{
				return value;
			}
			return VisitExpressionImpl(context);
		}

		public override object VisitDecl_stmt([NotNull] StonescriptParser.Decl_stmtContext context)
		{
			string varId = context.ID().Accept(this) as string;
			string text = machine.ValidateVariableName(varId);
			if (text != null)
			{
				throw CreateException(text, context);
			}
			if (target.IsVariable(varId, allowParentChaining: false))
			{
				return null;
			}
			object obj = null;
			StonescriptParser.ExpressionContext expressionContext = context.expression();
			if (expressionContext != null)
			{
				obj = expressionContext.Accept(this);
			}
			StonescriptObject.Modifiers modifiers = StonescriptObject.Modifiers.None;
			if (context.CONST() != null)
			{
				modifiers = StonescriptObject.Modifiers.Constant;
			}
			target.DeclareVariable(varId, obj, modifiers);
			return obj;
		}

		public override object VisitAssignment([NotNull] StonescriptParser.AssignmentContext context)
		{
			object obj = context.expression().Accept(this);
			ITerminalNode terminalNode = context.children[1] as ITerminalNode;
			object obj2;
			switch (terminalNode.Symbol.Type)
			{
			case 28:
				obj2 = obj;
				break;
			case 34:
			case 35:
			case 36:
			case 37:
			{
				object value = GetValue(context.lvalue());
				obj2 = BinaryOperation(value, obj, terminalNode.Symbol.Type);
				break;
			}
			default:
				throw CreateException("Invalid operation.", context);
			}
			SetValue(context.lvalue(), obj2);
			return obj2;
		}

		public override object VisitInc_stmt([NotNull] StonescriptParser.Inc_stmtContext context)
		{
			StonescriptParser.QualifiedIdContext context2 = context.qualifiedId();
			object value = GetValue(context2);
			object result;
			if (context.children[0] is StonescriptParser.QualifiedIdContext)
			{
				ITerminalNode terminalNode = context.children[1] as ITerminalNode;
				result = GetValue(context2);
				object value2 = UnaryOperation(value, terminalNode.Symbol.Type);
				SetValue(context2, value2);
			}
			else
			{
				ITerminalNode terminalNode2 = context.children[0] as ITerminalNode;
				object value2 = UnaryOperation(value, terminalNode2.Symbol.Type);
				SetValue(context2, value2);
				result = value2;
			}
			return result;
		}

		public object Invoke(ScriptFunction function, [NotNull] ParserRuleContext context, List<object> parameters, InvocationContext parentCtx)
		{
			int num = parameters?.Count ?? 0;
			List<string> parameterNames = function.ParameterNames;
			int num2 = parameterNames?.Count ?? 0;
			if (parameterNames != null && num != num2)
			{
				throw new InvalidOperationException($"{function.Name} expected {num2} parameters but received {num}.");
			}
			for (int i = 0; i < num; i++)
			{
				target.Declare(parameterNames[i], parameters[i]);
			}
			execCtx.returned = false;
			execCtx.returnValue = null;
			base.VisitChildren(context);
			object returnValue = execCtx.returnValue;
			execCtx.returnValue = null;
			execCtx.returned = false;
			return returnValue;
		}

		public override object VisitInvocation([NotNull] StonescriptParser.InvocationContext context)
		{
			return VisitInvocation(context.expression(), context.paramlist());
		}

		protected override object VisitInvocation([NotNull] StonescriptParser.ExpressionContext expression, StonescriptParser.ParamlistContext paramlist)
		{
			if (!(expression.Accept(this) is IFunction function))
			{
				throw CreateException("\"" + expression.GetText() + "\" is not a function.", expression);
			}
			List<object> list = machine.objectListPool.Get();
			if (paramlist != null)
			{
				VisitParamlist(paramlist, list);
			}
			InvocationContext invocationContext = null;
			if (function is NativeFunction nativeFunction)
			{
				invocationContext = execCtx.Push(nativeFunction.Owner, function, list);
			}
			try
			{
				object result = function.Invoke(list, invocationContext);
				if (invocationContext != null)
				{
					execCtx.Pop();
				}
				machine.objectListPool.Return(list);
				return result;
			}
			catch (Exception)
			{
				if (invocationContext != null)
				{
					execCtx.Pop();
				}
				machine.objectListPool.Return(list);
				throw;
			}
		}

		public override object VisitFuncdef([NotNull] StonescriptParser.FuncdefContext context)
		{
			return null;
		}

		public override object VisitLambda([NotNull] StonescriptParser.LambdaContext context)
		{
			StonescriptParser.VarlistContext varlistContext = context.varlist();
			List<string> parameterNames = ((varlistContext == null) ? new List<string>() : (varlistContext.Accept(this) as List<string>));
			return new ScriptFunction("lambda", parameterNames, context, execCtx.CurrentExecutable);
		}

		public void VisitParamlist([NotNull] StonescriptParser.ParamlistContext context, List<object> parameters)
		{
			StonescriptParser.ExpressionContext[] array = context.expression();
			foreach (StonescriptParser.ExpressionContext expressionContext in array)
			{
				parameters.Add(expressionContext.Accept(this));
			}
		}

		public override object VisitParamlist([NotNull] StonescriptParser.ParamlistContext context)
		{
			List<object> list = new List<object>();
			StonescriptParser.ExpressionContext[] array = context.expression();
			foreach (StonescriptParser.ExpressionContext expressionContext in array)
			{
				list.Add(expressionContext.Accept(this));
			}
			return list;
		}

		public override object VisitVarlist([NotNull] StonescriptParser.VarlistContext context)
		{
			List<string> list = new List<string>();
			ITerminalNode[] array = context.ID();
			foreach (ITerminalNode node in array)
			{
				list.Add(GetId(node));
			}
			return list;
		}

		public override object VisitIf_stmt([NotNull] StonescriptParser.If_stmtContext context)
		{
			if (DataTypes.ToBool(context.expression().Accept(this)))
			{
				StonescriptParser.BlockContext blockContext = context.block();
				if (blockContext == null)
				{
					Warn("If statement has no body.", context);
					return null;
				}
				return blockContext.Accept(this);
			}
			if (context.else_if_stmt().Length != 0)
			{
				StonescriptParser.Else_if_stmtContext[] array = context.else_if_stmt();
				foreach (StonescriptParser.Else_if_stmtContext else_if_stmtContext in array)
				{
					if (DataTypes.ToBool(else_if_stmtContext.expression().Accept(this)))
					{
						StonescriptParser.BlockContext blockContext2 = else_if_stmtContext.block();
						if (blockContext2 == null)
						{
							Warn("Else if statement has no body.", else_if_stmtContext);
							return null;
						}
						return blockContext2.Accept(this);
					}
				}
			}
			StonescriptParser.Else_stmtContext else_stmtContext = context.else_stmt();
			if (else_stmtContext != null)
			{
				StonescriptParser.BlockContext blockContext3 = else_stmtContext.block();
				if (blockContext3 == null)
				{
					Warn("Else statement has no body.", else_stmtContext);
					return null;
				}
				return blockContext3.Accept(this);
			}
			return null;
		}

		public override object VisitFor_stmt([NotNull] StonescriptParser.For_stmtContext context)
		{
			string id = GetId(context.ID());
			StonescriptObject parent = target;
			execCtx.breaked = false;
			execCtx.continued = false;
			StonescriptParser.ExpressionContext[] array = context.expression();
			object result = null;
			if (context.COLON() != null)
			{
				foreach (object item in array[0].Accept(this) as IEnumerable<object>)
				{
					Scope scope = machine.scopePool.Get().Init(parent);
					try
					{
						execCtx.Push(scope);
						scope.Declare(id, item);
						result = context.block().Accept(this);
						execCtx.Pop();
						machine.scopePool.Return(scope);
					}
					catch (Exception)
					{
						execCtx.Pop();
						machine.scopePool.Return(scope);
						throw;
					}
					execCtx.continued = false;
					if (execCtx.returned || execCtx.breaked)
					{
						break;
					}
				}
			}
			else
			{
				object o = array[0].Accept(this);
				object o2 = array[1].Accept(this);
				int num = DataTypes.ToInt(o);
				int num2 = DataTypes.ToInt(o2);
				int num3 = (int)Mathf.Sign(num2 - num);
				if (num3 == 0)
				{
					num3 = 1;
				}
				int num4 = num;
				int num5 = Mathf.Min(num, num2);
				int num6 = Mathf.Max(num, num2);
				int num7 = 0;
				int num8 = 10000;
				while (true)
				{
					Scope scope2 = machine.scopePool.Get().Init(parent);
					try
					{
						execCtx.Push(scope2);
						scope2.Declare(id, num4);
						result = context.block().Accept(this);
						num4 = target.Get<int>(id);
						execCtx.Pop();
						machine.scopePool.Return(scope2);
					}
					catch (Exception)
					{
						execCtx.Pop();
						machine.scopePool.Return(scope2);
						throw;
					}
					num4 += num3;
					execCtx.continued = false;
					if (execCtx.returned || execCtx.breaked || num4 < num5 || num4 > num6)
					{
						break;
					}
					num7++;
					if (num7 >= num8)
					{
						throw new Exception("Infinite loop.");
					}
				}
			}
			execCtx.breaked = false;
			execCtx.continued = false;
			return result;
		}

		public override object VisitReturn_stmt([NotNull] StonescriptParser.Return_stmtContext context)
		{
			execCtx.returnValue = null;
			StonescriptParser.ExpressionContext expressionContext = context.expression();
			if (expressionContext != null)
			{
				execCtx.returnValue = expressionContext.Accept(this);
			}
			execCtx.returned = true;
			return execCtx.returnValue;
		}

		public override object VisitBreak_stmt([NotNull] StonescriptParser.Break_stmtContext context)
		{
			execCtx.breaked = true;
			return null;
		}

		public override object VisitContinue_stmt([NotNull] StonescriptParser.Continue_stmtContext context)
		{
			execCtx.continued = true;
			return null;
		}
	}
}
