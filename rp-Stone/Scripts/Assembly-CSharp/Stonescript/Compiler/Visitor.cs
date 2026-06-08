using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Stonescript.Types;

namespace Stonescript.Compiler
{
	public abstract class Visitor : StonescriptParserBaseVisitor<object>
	{
		protected Machine machine;

		public abstract Script script { get; }

		protected abstract StonescriptObject target { get; }

		protected virtual StonescriptObject This => null;

		public Visitor(Machine machine)
		{
			this.machine = machine;
		}

		protected abstract StonescriptException CreateException(string message, IParseTree node, Exception innerException = null, StonescriptException.Level level = StonescriptException.Level.Error);

		protected virtual object VisitExpressionImpl([NotNull] StonescriptParser.ExpressionContext context)
		{
			IList<IParseTree> children = context.children;
			ITerminalNode[] array = context.ID();
			if (children.Count == 1)
			{
				object result = children[0].Accept(this);
				return CheckCacheExpression(context, result);
			}
			if (array != null && array.Length > 1)
			{
				string text = "";
				for (int i = 0; i < array.Length; i++)
				{
					ITerminalNode terminalNode = array[i];
					if (i > 0)
					{
						text += " ";
					}
					text += terminalNode.GetText();
				}
				script.parseTree.CacheConstant(context, text);
				return text;
			}
			StonescriptParser.ExpressionContext[] array2 = context.expression();
			if (array2.Length == 1)
			{
				StonescriptParser.ExpressionContext expressionContext = array2[0];
				if (context.DOT() != null && array != null && array.Length == 1)
				{
					object obj = expressionContext.Accept(this);
					if (!(obj is StonescriptObject))
					{
						throw new InvalidOperationException("Attempting to access member variable on a non-object.");
					}
					StonescriptObject stonescriptObject = obj as StonescriptObject;
					object value = GetValue(array[0], stonescriptObject);
					return CheckCacheExpression(context, value);
				}
				if (children[1] is ITerminalNode && (children[1] as ITerminalNode).Symbol.Type == 20)
				{
					object result2 = VisitInvocation(expressionContext, context.paramlist());
					return CheckCacheExpression(context, result2);
				}
				object obj2 = expressionContext.Accept(this);
				if (children[0] is ITerminalNode)
				{
					obj2 = UnaryOperation(obj2, (children[0] as ITerminalNode).Symbol.Type);
				}
				return CheckCacheExpression(context, obj2);
			}
			if (array2.Length == 2)
			{
				StonescriptParser.ExpressionContext expressionContext2 = array2[0];
				StonescriptParser.ExpressionContext expressionContext3 = array2[1];
				if (context.LBRACKET() != null)
				{
					StonescriptArray obj3 = (expressionContext2.Accept(this) as StonescriptArray) ?? throw CreateException("Attempting to access index on a non-array.", expressionContext2);
					int i2 = DataTypes.ToInt(expressionContext3.Accept(this));
					object result3 = obj3[i2];
					return CheckCacheExpression(context, result3);
				}
				int type = (context.children[1] as ITerminalNode).Symbol.Type;
				switch (type)
				{
				case 43:
				{
					if (!DataTypes.ToBool(expressionContext2.Accept(this)))
					{
						return CheckCacheExpression(context, false);
					}
					bool flag = DataTypes.ToBool(expressionContext3.Accept(this));
					return CheckCacheExpression(context, flag);
				}
				case 42:
					if (DataTypes.ToBool(expressionContext2.Accept(this)))
					{
						return CheckCacheExpression(context, true);
					}
					return DataTypes.ToBool(expressionContext3.Accept(this));
				default:
				{
					object a = expressionContext2.Accept(this);
					object b = expressionContext3.Accept(this);
					object result4 = BinaryOperation(a, b, type);
					return CheckCacheExpression(context, result4);
				}
				}
			}
			throw CreateException("Invalid operation.", context);
		}

		protected virtual object VisitInvocation([NotNull] StonescriptParser.ExpressionContext expression, StonescriptParser.ParamlistContext paramlist)
		{
			return null;
		}

		protected virtual object VisitTerminalImpl(ITerminalNode node)
		{
			if (script.parseTree.TryGetConstant(node, out var value))
			{
				return value;
			}
			switch (node.Symbol.Type)
			{
			case -1:
			case 1:
			case 2:
			case 63:
				script.parseTree.CacheConstant(node, null);
				return null;
			case 60:
			{
				string text3 = node.GetText();
				text3 = text3.Substring(1, text3.Length - 2);
				text3 = DataTypes.EscapeString(text3);
				script.parseTree.CacheConstant(node, text3);
				return text3;
			}
			case 61:
			{
				string text5 = node.GetText();
				script.parseTree.CacheConstant(node, text5);
				return text5;
			}
			case 4:
			case 67:
			case 72:
			{
				string text4 = node.GetText();
				text4 = Regex.Replace(text4, "^ascii\r?\n", "");
				text4 = Regex.Replace(text4, "\r?\nasciiend$", "");
				text4 = text4.Replace("\n", "\\n");
				script.parseTree.CacheConstant(node, text4);
				return text4;
			}
			case 12:
				script.parseTree.CacheConstant(node, null);
				return null;
			case 10:
				script.parseTree.CacheConstant(node, true);
				return true;
			case 11:
				script.parseTree.CacheConstant(node, false);
				return false;
			case 57:
				script.parseTree.CacheConstant(node, node.GetText());
				return node.GetText();
			case 56:
			{
				string text2 = node.GetText();
				if (text2.Contains("."))
				{
					float num = float.Parse(text2, NumberStyles.Any, CultureInfo.InvariantCulture);
					script.parseTree.CacheConstant(node, num);
					return num;
				}
				int num2 = int.Parse(text2);
				script.parseTree.CacheConstant(node, num2);
				return num2;
			}
			case 68:
			case 73:
				return DataTypes.EscapeString(node.GetText());
			case 3:
			case 58:
			case 59:
			{
				string text = node.GetText();
				script.parseTree.CacheConstant(node, text);
				return text;
			}
			case 9:
				return This;
			default:
				return node.GetText();
			}
		}

		protected object CheckCacheExpression(StonescriptParser.ExpressionContext context, object result)
		{
			for (int i = 0; i < context.children.Count; i++)
			{
				IParseTree parseTree = context.children[i];
				ITerminalNode terminalNode = parseTree as ITerminalNode;
				if (terminalNode == null && !script.parseTree.IsCached(parseTree))
				{
					return result;
				}
				if (terminalNode != null && (terminalNode.Symbol.Type == 9 || terminalNode.Symbol.Type == 51))
				{
					return result;
				}
			}
			script.parseTree.CacheConstant(context, result);
			return result;
		}

		protected object UnaryOperation(object a, int op)
		{
			switch (op)
			{
			case 38:
				if (a is float)
				{
					return DataTypes.ToFloat(a) + 1f;
				}
				return DataTypes.ToInt(a) + 1;
			case 39:
				if (a is float)
				{
					return DataTypes.ToFloat(a) - 1f;
				}
				return DataTypes.ToInt(a) - 1;
			case 31:
				if (a is int)
				{
					return -DataTypes.ToInt(a);
				}
				if (a is float)
				{
					return 0f - DataTypes.ToFloat(a);
				}
				break;
			case 40:
				return !DataTypes.ToBool(a);
			}
			return a;
		}

		protected object BinaryOperation(object a, object b, int op)
		{
			if (op == 43 || op == 42)
			{
				a = DataTypes.ToBool(a);
				b = DataTypes.ToBool(b);
				return BooleanBinaryOperation(a, b, op);
			}
			if (a == null || b == null)
			{
				return NullBinaryOperation(a, b, op);
			}
			if (a is string || b is string)
			{
				return StringBinaryOperation(a, b, op);
			}
			if (a is int && b is int)
			{
				return IntegerBinaryOperation(a, b, op);
			}
			if ((a is float && (b is float || b is int)) || (b is float && a is int))
			{
				return FloatBinaryOperation(a, b, op);
			}
			if (a is bool && b is bool)
			{
				return BooleanBinaryOperation(a, b, op);
			}
			if (a is StonescriptObject || b is StonescriptObject)
			{
				return ObjectBinaryOperation(a, b, op);
			}
			throw new InvalidOperationException();
		}

		protected object NullBinaryOperation(object a, object b, int op)
		{
			return op switch
			{
				28 => a == b, 
				40 => a != b, 
				_ => throw new InvalidOperationException("Invalid operation on a null."), 
			};
		}

		protected object ObjectBinaryOperation(object oa, object ob, int op)
		{
			return op switch
			{
				28 => oa == ob, 
				40 => oa != ob, 
				_ => throw new InvalidOperationException("Invalid object operation."), 
			};
		}

		protected object BooleanBinaryOperation(object oa, object ob, int op)
		{
			bool flag = DataTypes.ToBool(oa);
			bool flag2 = DataTypes.ToBool(ob);
			switch (op)
			{
			case 43:
			case 45:
				return flag && flag2;
			case 42:
			case 44:
				return flag || flag2;
			case 28:
				return flag == flag2;
			case 40:
				return flag != flag2;
			default:
				throw new InvalidOperationException("Invalid bool operation.");
			}
		}

		protected object StringBinaryOperation(object oa, object ob, int op)
		{
			string text = oa.ToString();
			string text2 = ob.ToString();
			return op switch
			{
				30 => text + text2, 
				28 => DataTypes.ObjectEquals(text, text2), 
				40 => !DataTypes.ObjectEquals(text, text2), 
				34 => text + text2, 
				_ => throw new InvalidOperationException("Invalid string operator."), 
			};
		}

		protected object IntegerBinaryOperation(object oa, object ob, int op)
		{
			int num = Convert.ToInt32(oa);
			int num2 = Convert.ToInt32(ob);
			return op switch
			{
				30 => num + num2, 
				31 => num - num2, 
				32 => num * num2, 
				33 => num / num2, 
				48 => num % num2, 
				53 => num > num2, 
				17 => num >= num2, 
				18 => num < num2, 
				19 => num <= num2, 
				28 => num == num2, 
				40 => num != num2, 
				34 => num + num2, 
				35 => num - num2, 
				36 => num * num2, 
				37 => num / num2, 
				_ => throw new InvalidOperationException("Invalid integer operation."), 
			};
		}

		protected object FloatBinaryOperation(object oa, object ob, int op)
		{
			float num = Convert.ToSingle(oa);
			float num2 = Convert.ToSingle(ob);
			return op switch
			{
				30 => num + num2, 
				31 => num - num2, 
				32 => num * num2, 
				33 => num / num2, 
				48 => num % num2, 
				53 => num > num2, 
				17 => num >= num2, 
				18 => num < num2, 
				19 => num <= num2, 
				28 => num == num2, 
				40 => num != num2, 
				34 => num + num2, 
				35 => num - num2, 
				36 => num * num2, 
				37 => num / num2, 
				_ => throw new InvalidOperationException("Invalid float operation."), 
			};
		}

		protected string GetId([NotNull] ITerminalNode node)
		{
			return node.GetText();
		}

		protected object GetValue([NotNull] ITerminalNode node, StonescriptObject target = null)
		{
			StonescriptObject owner;
			return GetValue(node, out owner, target);
		}

		protected object GetValue([NotNull] ITerminalNode node, out StonescriptObject owner, StonescriptObject target = null)
		{
			if (target == null)
			{
				target = this.target;
			}
			string id = GetId(node);
			return target.GetVariable(id, out owner);
		}

		protected object GetValue([NotNull] StonescriptParser.LvalueContext node, StonescriptObject target = null)
		{
			if (target == null)
			{
				target = this.target;
			}
			ITerminalNode terminalNode = node.ID();
			StonescriptParser.ExpressionContext[] array = node.expression();
			if (terminalNode != null)
			{
				if (array != null && array.Length == 1)
				{
					target = array[0].Accept(this) as StonescriptObject;
					if (target == null)
					{
						throw new Exception("Attempting to access member on a non-object.");
					}
				}
				return GetValue(terminalNode, target);
			}
			if (node.LBRACKET() != null)
			{
				StonescriptArray obj = (array[0].Accept(this) as StonescriptArray) ?? throw new Exception("Attempting to assign to index to a non-array.");
				int i = DataTypes.ToInt(array[1].Accept(this));
				return obj[i];
			}
			throw new Exception("Unsupported L-Value format.");
		}

		protected void SetValue([NotNull] StonescriptParser.LvalueContext node, object value, StonescriptObject target = null)
		{
			if (target == null)
			{
				target = this.target;
			}
			ITerminalNode terminalNode = node.ID();
			StonescriptParser.ExpressionContext[] array = node.expression();
			if (terminalNode != null)
			{
				if (array != null && array.Length == 1)
				{
					target = array[0].Accept(this) as StonescriptObject;
					if (target == null)
					{
						throw new Exception("Attempting to access member on a non-object.");
					}
				}
				SetValue(terminalNode, value, target);
			}
			else
			{
				if (node.LBRACKET() == null)
				{
					throw new Exception("Unsupported L-Value format.");
				}
				StonescriptArray obj = (array[0].Accept(this) as StonescriptArray) ?? throw new Exception("Attempting to assign to index to a non-array.");
				int i = DataTypes.ToInt(array[1].Accept(this));
				obj[i] = value;
			}
		}

		protected void SetValue([NotNull] ITerminalNode node, object value, StonescriptObject target = null)
		{
			if (target == null)
			{
				target = this.target;
			}
			string varId = node.Accept(this) as string;
			target.Set(varId, value);
		}

		protected object GetValue([NotNull] StonescriptParser.QualifiedIdContext context, StonescriptObject target = null)
		{
			StonescriptObject owner;
			return GetValue(context, out owner, target);
		}

		protected object GetValue([NotNull] StonescriptParser.QualifiedIdContext context, out StonescriptObject owner, StonescriptObject target = null)
		{
			if (target == null)
			{
				target = this.target;
			}
			ITerminalNode[] array = context.ID();
			StonescriptObject stonescriptObject = target;
			owner = null;
			object obj = null;
			try
			{
				ITerminalNode terminalNode = null;
				ITerminalNode[] array2 = array;
				foreach (ITerminalNode terminalNode2 in array2)
				{
					if (stonescriptObject == null)
					{
						string text = terminalNode.Accept(this) as string;
						throw new Exception("Variable " + text + " is being accessed but is not an object.");
					}
					owner = stonescriptObject;
					obj = GetValue(terminalNode2, stonescriptObject);
					stonescriptObject = obj as StonescriptObject;
					terminalNode = terminalNode2;
				}
				return obj;
			}
			catch (Exception ex)
			{
				string text2 = context.GetText();
				if (machine.HasGlobal(text2))
				{
					return machine.GetGlobal(text2);
				}
				if (array.Length > 1)
				{
					text2 = GetId(array[0]);
					if (machine.HasGlobal(text2))
					{
						StonescriptObject global = machine.GetGlobal<StonescriptObject>(text2);
						return GetValue(global, array, 1);
					}
				}
				if (array.Length == 1)
				{
					return text2;
				}
				throw ex;
			}
		}

		protected object GetValue(StonescriptObject cur, ITerminalNode[] ids, int startId)
		{
			object obj = null;
			for (int i = startId; i < ids.Length; i++)
			{
				string id = GetId(ids[i]);
				obj = cur.Get(id);
				if (i + 1 < ids.Length)
				{
					if (!(obj is StonescriptObject))
					{
						throw new Exception("Variable " + id + " is being accessed but is not an object.");
					}
					cur = obj as StonescriptObject;
				}
			}
			return obj;
		}

		protected void SetValue([NotNull] StonescriptParser.QualifiedIdContext context, object value, StonescriptObject target = null)
		{
			if (target == null)
			{
				target = this.target;
			}
			StonescriptObject stonescriptObject = target;
			StonescriptObject stonescriptObject2 = null;
			ITerminalNode terminalNode = null;
			ITerminalNode[] array = context.ID();
			foreach (ITerminalNode terminalNode2 in array)
			{
				if (stonescriptObject == null)
				{
					string text = terminalNode.Accept(this) as string;
					throw new Exception("Variable " + text + " is being accessed but is not an object.");
				}
				stonescriptObject2 = stonescriptObject;
				stonescriptObject = GetValue(terminalNode2, stonescriptObject) as StonescriptObject;
				terminalNode = terminalNode2;
			}
			string varId = terminalNode.Accept(this) as string;
			stonescriptObject2.Set(varId, value);
		}
	}
}
