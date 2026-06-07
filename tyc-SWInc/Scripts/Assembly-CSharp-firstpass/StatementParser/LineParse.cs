using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace StatementParser
{
	public static class LineParse
	{
		public static class EBNF
		{
			public delegate TreeNode MatcherDelegate(List<Token> tokens, ref int i);

			public static TreeNode StartMatch(List<Token> tokens)
			{
				int i = 0;
				TreeNode treeNode = null;
				while (i < tokens.Count)
				{
					Token token = tokens[i];
					if (token.Type == TokenType.EndLine)
					{
						i++;
						continue;
					}
					TreeNode treeNode2 = MatchExpressions(tokens, ref i);
					if (treeNode2 == null)
					{
						ThrowEx("Failed parsing " + GetCleanName(token.Type), token);
					}
					if (treeNode != null)
					{
						TreeNode treeNode3 = new TreeNode(TokenType.Block, treeNode2.TokenItem.Line, treeNode2.TokenItem.Col);
						treeNode3.AddLeft(treeNode);
						treeNode3.AddRight(treeNode2);
						treeNode = treeNode3;
					}
					else
					{
						treeNode = treeNode2;
					}
				}
				return treeNode;
			}

			private static void MatchSurrounding(List<Token> tokens, ref int i, TreeNode root, TokenType start, TokenType end)
			{
				if (i >= tokens.Count)
				{
					throw new Exception("Unexpected end of file");
				}
				if (tokens[i].Type == start)
				{
					i++;
					TreeNode treeNode = MatchExpressions(tokens, ref i);
					if (treeNode == null)
					{
						ThrowEx("Rogue " + GetCleanName(root.TokenItem.Type), root.TokenItem);
					}
					while (i < tokens.Count && tokens[i].Type != end)
					{
						TreeNode treeNode2 = new TreeNode(TokenType.EndLine, tokens[i].Line, tokens[i].Col);
						treeNode2.AddLeft(treeNode);
						treeNode = treeNode2;
						TreeNode treeNode3 = MatchExpressions(tokens, ref i);
						if (treeNode3 == null)
						{
							ThrowEx("Rogue " + GetCleanName(root.TokenItem.Type), root.TokenItem);
						}
						treeNode.AddRight(treeNode3);
					}
					ValidateNext(tokens, ref i, end);
					root.AddRight(treeNode);
				}
				else
				{
					TreeNode treeNode4 = MatchSimpleExpression(tokens, ref i);
					if (treeNode4 == null)
					{
						ThrowEx("Rogue " + GetCleanName(root.TokenItem.Type), root.TokenItem);
					}
					root.AddRight(treeNode4);
				}
			}

			private static void MatchSurroundingSimple(List<Token> tokens, ref int i, TreeNode root, TokenType start, TokenType end)
			{
				ValidateNext(tokens, ref i, start);
				TreeNode treeNode = MatchSimpleExpression(tokens, ref i);
				if (treeNode == null)
				{
					ThrowEx("Rogue " + root.TokenItem.Type, root.TokenItem);
				}
				ValidateNext(tokens, ref i, end);
				root.AddLeft(treeNode);
			}

			private static TreeNode MatchControl(List<Token> tokens, ref int i)
			{
				Token token = tokens[i];
				TreeNode treeNode = null;
				if (token.Type == TokenType.Break)
				{
					i++;
					return new TreeNode(token);
				}
				if (token.Type == TokenType.Else)
				{
					ThrowEx("Got else without corresponding if", token);
				}
				if (token.Type == TokenType.If)
				{
					treeNode = new TreeNode(token);
					i++;
					MatchSurroundingSimple(tokens, ref i, treeNode, TokenType.LeftParan, TokenType.RightParan);
					MatchSurrounding(tokens, ref i, treeNode, TokenType.LeftBracket, TokenType.RightBracket);
					if (i < tokens.Count)
					{
						token = tokens[i];
						if (token.Type == TokenType.Else)
						{
							TreeNode treeNode2 = new TreeNode(token);
							i++;
							TreeNode right = treeNode.Right;
							treeNode.ReplaceChild(right, treeNode2);
							treeNode2.AddLeft(right);
							MatchSurrounding(tokens, ref i, treeNode2, TokenType.LeftBracket, TokenType.RightBracket);
						}
					}
				}
				if (treeNode == null && token.Type == TokenType.ForEach)
				{
					treeNode = new TreeNode(token);
					i++;
					ValidateNext(tokens, ref i, TokenType.LeftParan);
					treeNode.TokenItem.Value = ValidateNext(tokens, ref i, TokenType.Variable).Value;
					ValidateNext(tokens, ref i, TokenType.In);
					TreeNode treeNode3 = MatchSimpleExpression(tokens, ref i);
					if (treeNode3 == null)
					{
						ThrowEx("Missing enumerable expression", treeNode.TokenItem);
					}
					treeNode.AddLeft(treeNode3);
					ValidateNext(tokens, ref i, TokenType.RightParan);
					MatchSurrounding(tokens, ref i, treeNode, TokenType.LeftBracket, TokenType.RightBracket);
				}
				return treeNode ?? MatchSimpleExpression(tokens, ref i);
			}

			private static TreeNode MatchExpressions(List<Token> tokens, ref int i)
			{
				TreeNode treeNode = MatchControl(tokens, ref i);
				if (treeNode != null)
				{
					treeNode = MatchZeroOrMore(tokens, ref i, treeNode, MatchControl, true, false, TokenType.EndLine);
				}
				return treeNode;
			}

			private static TreeNode MatchSimpleExpression(List<Token> tokens, ref int i)
			{
				TreeNode treeNode = MatchAssign(tokens, ref i);
				if (treeNode != null)
				{
					treeNode = MatchInlineIf(tokens, ref i, treeNode);
				}
				return treeNode;
			}

			private static TreeNode MatchInlineIf(List<Token> tokens, ref int i, TreeNode root)
			{
				if (i < tokens.Count && tokens[i].Type == TokenType.Questionmark)
				{
					i++;
					TreeNode treeNode = MatchSimpleExpression(tokens, ref i);
					if (treeNode == null)
					{
						ThrowEx("Expected rest of inline if statement", root.TokenItem);
					}
					ValidateNext(tokens, ref i, TokenType.Colon);
					TreeNode treeNode2 = MatchSimpleExpression(tokens, ref i);
					if (treeNode2 == null)
					{
						ThrowEx("Expected rest of inline if statement", root.TokenItem);
					}
					return new TreeNode(TokenType.InlineIf, root.TokenItem.Line, root.TokenItem.Col)
					{
						Children = { root, treeNode, treeNode2 }
					};
				}
				return root;
			}

			private static TreeNode MatchAssign(List<Token> tokens, ref int i)
			{
				TreeNode treeNode = MatchOr(tokens, ref i);
				if (treeNode != null)
				{
					treeNode = MatchZeroOrMore(tokens, ref i, treeNode, MatchOr, false, true, TokenType.Assign);
				}
				return treeNode;
			}

			private static TreeNode MatchOr(List<Token> tokens, ref int i)
			{
				TreeNode treeNode = MatchAnd(tokens, ref i);
				if (treeNode != null)
				{
					treeNode = MatchZeroOrMore(tokens, ref i, treeNode, MatchAnd, false, false, TokenType.Or);
				}
				return treeNode;
			}

			private static TreeNode MatchAnd(List<Token> tokens, ref int i)
			{
				TreeNode treeNode = MatchIs(tokens, ref i);
				if (treeNode != null)
				{
					treeNode = MatchZeroOrMore(tokens, ref i, treeNode, MatchIs, false, false, TokenType.And);
				}
				return treeNode;
			}

			private static TreeNode MatchIs(List<Token> tokens, ref int i)
			{
				TreeNode treeNode = MatchEquality(tokens, ref i);
				if (treeNode != null)
				{
					treeNode = MatchZeroOrMore(tokens, ref i, treeNode, MatchEquality, false, false, TokenType.TypeIs);
				}
				return treeNode;
			}

			private static TreeNode MatchEquality(List<Token> tokens, ref int i)
			{
				TreeNode treeNode = MatchAddOrSub(tokens, ref i);
				if (treeNode != null)
				{
					treeNode = MatchZeroOrMore(tokens, ref i, treeNode, MatchAddOrSub, false, false, TokenType.Equal, TokenType.NotEqual, TokenType.Less, TokenType.LessEqual, TokenType.Greater, TokenType.GreaterEqual);
				}
				return treeNode;
			}

			private static TreeNode MatchAddOrSub(List<Token> tokens, ref int i)
			{
				TreeNode treeNode = MatchMultOrDiv(tokens, ref i);
				if (treeNode != null)
				{
					treeNode = MatchZeroOrMore(tokens, ref i, treeNode, MatchMultOrDiv, false, false, TokenType.Add, TokenType.Subtract);
				}
				return treeNode;
			}

			private static TreeNode MatchMultOrDiv(List<Token> tokens, ref int i)
			{
				TreeNode treeNode = MatchPower(tokens, ref i);
				if (treeNode != null)
				{
					treeNode = MatchZeroOrMore(tokens, ref i, treeNode, MatchPower, false, false, TokenType.Multiply, TokenType.Divide, TokenType.Modulo);
				}
				return treeNode;
			}

			private static TreeNode MatchPower(List<Token> tokens, ref int i)
			{
				TreeNode treeNode = MatchNegation(tokens, ref i);
				if (treeNode != null)
				{
					treeNode = MatchZeroOrMore(tokens, ref i, treeNode, MatchNegation, false, false, TokenType.Power);
				}
				return treeNode;
			}

			private static TreeNode MatchNegation(List<Token> tokens, ref int i)
			{
				if (tokens[i].Type == TokenType.Subtract || tokens[i].Type == TokenType.Not)
				{
					TreeNode treeNode = new TreeNode(tokens[i]);
					i++;
					if (i >= tokens.Count)
					{
						throw new Exception("Unexpected end of file");
					}
					TreeNode treeNode2 = MatchAccess(tokens, ref i);
					if (treeNode2 != null)
					{
						treeNode.AddRight(treeNode2);
						return treeNode;
					}
					throw new Exception("Expected expression after negation");
				}
				return MatchAccess(tokens, ref i);
			}

			private static TreeNode MatchAccess(List<Token> tokens, ref int i)
			{
				TreeNode treeNode = MatchLiteral(tokens, ref i);
				if (treeNode != null)
				{
					treeNode = MatchZeroOrMore(tokens, ref i, treeNode, MatchLiteral, false, false, TokenType.GoInto);
				}
				return treeNode;
			}

			private static TreeNode MatchLiteral(List<Token> tokens, ref int i)
			{
				if (i >= tokens.Count)
				{
					throw new Exception("Unexpected end of file");
				}
				Token token = tokens[i];
				if (token.Type == TokenType.String)
				{
					i++;
					return new TreeNode(token);
				}
				if (token.Type == TokenType.Null)
				{
					i++;
					return new TreeNode(token);
				}
				if (token.Type == TokenType.ArrayCreation)
				{
					i++;
					if (i >= tokens.Count)
					{
						throw new Exception("Unexpected end of file");
					}
					TreeNode treeNode = new TreeNode(token);
					if (tokens[i].Type != TokenType.RightSquareBracket)
					{
						TreeNode treeNode2 = MatchSimpleExpression(tokens, ref i);
						if (treeNode2 == null)
						{
							ThrowEx("Rogue array creation", treeNode.TokenItem);
						}
						treeNode2 = MatchZeroOrMore(tokens, ref i, treeNode2, MatchSimpleExpression, false, false, TokenType.Comma);
						treeNode.AddLeft(treeNode2);
					}
					ValidateNext(tokens, ref i, TokenType.RightSquareBracket);
					return treeNode;
				}
				TreeNode treeNode3 = null;
				TreeNode treeNode4 = null;
				if (token.Type == TokenType.Number)
				{
					i++;
					treeNode4 = new TreeNode(token);
				}
				if (treeNode4 == null && token.Type == TokenType.LeftParan)
				{
					TreeNode treeNode5 = new TreeNode(token);
					i++;
					TreeNode treeNode6 = MatchSimpleExpression(tokens, ref i);
					if (treeNode6 == null)
					{
						ThrowEx("Rogue '('", treeNode5.TokenItem);
					}
					treeNode5.AddLeft(treeNode6);
					ValidateNext(tokens, ref i, TokenType.RightParan);
					treeNode4 = treeNode5;
				}
				if (token.Type == TokenType.Bool)
				{
					i++;
					treeNode4 = new TreeNode(token);
				}
				if (treeNode4 == null && treeNode3 == null && token.Type == TokenType.CreateVariable)
				{
					TreeNode result = new TreeNode(token);
					i++;
					token.Value = ValidateNext(tokens, ref i, TokenType.Variable).Value;
					return result;
				}
				if (treeNode4 == null)
				{
					treeNode4 = MatchFuncOrVar(tokens, ref i);
				}
				if (treeNode4 != null)
				{
					treeNode4 = MatchArrayAccess(tokens, treeNode4, ref i);
				}
				if (treeNode3 != null)
				{
					if (treeNode4 != null)
					{
						treeNode3.Children.Add(treeNode4);
						return treeNode3;
					}
					ThrowEx("Expected variable or literal after " + GetCleanName(treeNode3.TokenItem.Type), treeNode3.TokenItem);
				}
				return treeNode4;
			}

			private static TreeNode MatchFuncOrVar(List<Token> tokens, ref int i)
			{
				Token token = tokens[i];
				if (token.Type == TokenType.Variable)
				{
					TreeNode treeNode = new TreeNode(token);
					i++;
					if (i < tokens.Count && tokens[i].Type == TokenType.LeftParan)
					{
						treeNode.TokenItem.Type = TokenType.FunctionArgs;
						i++;
						if (i < tokens.Count && tokens[i].Type != TokenType.RightParan)
						{
							TreeNode root = MatchSimpleExpression(tokens, ref i);
							root = MatchZeroOrMore(tokens, ref i, root, MatchSimpleExpression, false, false, TokenType.Comma);
							treeNode.AddLeft(root);
						}
						ValidateNext(tokens, ref i, TokenType.RightParan);
					}
					return treeNode;
				}
				return null;
			}

			private static TreeNode MatchArrayAccess(List<Token> tokens, TreeNode root, ref int i)
			{
				while (i < tokens.Count && tokens[i].Type == TokenType.LeftSquareBracket)
				{
					Token token = tokens[i];
					i++;
					TreeNode treeNode = MatchSimpleExpression(tokens, ref i);
					if (treeNode == null)
					{
						ThrowEx("Rogue '['", token);
					}
					ValidateNext(tokens, ref i, TokenType.RightSquareBracket);
					TreeNode treeNode2 = new TreeNode(new Token(TokenType.ArrayAccess, treeNode, token.Line, token.Col));
					treeNode2.AddLeft(root);
					root = treeNode2;
				}
				return root;
			}

			private static TreeNode MatchZeroOrMore(List<Token> tokens, ref int i, TreeNode root, MatcherDelegate check, bool canEnd, bool reverse, params TokenType[] symbol)
			{
				if (i < tokens.Count)
				{
					Token token = tokens[i];
					TreeNode treeNode = root;
					while (symbol.Contains(token.Type))
					{
						TreeNode treeNode2 = new TreeNode(token);
						if (reverse && symbol.Contains(treeNode.TokenItem.Type))
						{
							treeNode2.AddLeft(treeNode.Right);
							treeNode.ReplaceChild(treeNode.Right, treeNode2);
						}
						else
						{
							treeNode2.AddLeft(treeNode);
							root = treeNode2;
						}
						i++;
						if (i >= tokens.Count)
						{
							if (canEnd)
							{
								return treeNode2;
							}
							ThrowEx("Can't end on " + GetCleanName(token.Type), token);
						}
						TreeNode treeNode3 = check(tokens, ref i);
						if (treeNode3 == null)
						{
							if (canEnd)
							{
								return treeNode2;
							}
							ThrowEx("Can't end on " + GetCleanName(token.Type), token);
						}
						treeNode2.AddRight(treeNode3);
						treeNode = treeNode2;
						if (i >= tokens.Count)
						{
							break;
						}
						token = tokens[i];
					}
				}
				return root;
			}

			private static Token ValidateNext(List<Token> tokens, ref int pos, TokenType type)
			{
				if (pos < tokens.Count)
				{
					if (tokens[pos].Type != type)
					{
						ThrowEx("Expecting " + GetCleanName(type) + " but got " + tokens[pos].Type, tokens[pos]);
					}
					pos++;
					return tokens[pos - 1];
				}
				throw new Exception("Expecting " + GetCleanName(type) + " but got end of file");
			}

			private static void ThrowEx(string message, Token t)
			{
				throw new Exception(message + string.Format(", at line {0} - {1}", t.Line + 1, t.Col + 1));
			}
		}

		public abstract class ScriptWorld
		{
			private Dictionary<string, object> _tempVars = new Dictionary<string, object>();

			public virtual bool IsRestricted(Type type)
			{
				return false;
			}

			public bool TryGetVar(string name, out object value)
			{
				return _tempVars.TryGetValue(name, out value);
			}

			public bool HasVar(string name)
			{
				return _tempVars.ContainsKey(name);
			}

			public bool SaveVar(string name, object value, bool force)
			{
				if (force)
				{
					_tempVars[name] = value;
					return true;
				}
				if (_tempVars.ContainsKey(name))
				{
					_tempVars[name] = value;
					return true;
				}
				return false;
			}

			public void ResetTempVars()
			{
				_tempVars.Clear();
			}

			public abstract Type GetTypeFromName(string name);

			public abstract bool IsProtected();
		}

		public class TempVar
		{
			public string Name;

			public object Value;

			public TempVar(string name, object value)
			{
				Name = name;
				Value = value;
			}

			public TempVar(string name)
			{
				Name = name;
				Value = null;
			}

			public TempVar Val(object value)
			{
				Value = value;
				return this;
			}
		}

		public class TempVarType
		{
			public string Name;

			public Type Value;

			public TempVarType(string name, Type value)
			{
				Name = name;
				Value = value;
			}

			public TempVarType(string name)
			{
				Name = name;
				Value = null;
			}
		}

		public class TempVariableResult : VariableResult
		{
			public TempVar Var;

			public object Index;

			public bool Indexed;

			public TempVariableResult Set(TempVar var)
			{
				Var = var;
				return this;
			}

			public void Reset()
			{
				Var = null;
				Index = null;
				Indexed = false;
			}

			public object GetValue()
			{
				if (!Indexed)
				{
					return Var.Value;
				}
				return GetArrayValue(Var.Value, Index);
			}

			public Type GetVarType()
			{
				object value = Var.Value;
				if (value == null)
				{
					return null;
				}
				if (!Indexed)
				{
					return value.GetType();
				}
				return GetEnumerableType(value);
			}

			public void SetValue(object input)
			{
				if (Indexed)
				{
					if (!SetArrayValue(Var.Value, Index, input, null))
					{
						throw new Exception("Tried to index into non index variable");
					}
				}
				else
				{
					Var.Value = input;
				}
			}

			public void SetIndex(object index)
			{
				Index = index;
				Indexed = true;
			}

			public bool HasIndex()
			{
				return Indexed;
			}
		}

		public class LocalVariableResult : VariableResult
		{
			public ScriptWorld World;

			public string Key;

			public object Index;

			public bool Indexed;

			public LocalVariableResult Set(ScriptWorld w, string k)
			{
				World = w;
				Key = k;
				return this;
			}

			public void Reset()
			{
				World = null;
				Key = null;
				Index = null;
				Indexed = false;
			}

			public Type GetVarType()
			{
				object underlying = GetUnderlying();
				if (underlying == null)
				{
					return null;
				}
				if (!Indexed)
				{
					return underlying.GetType();
				}
				return GetEnumerableType(underlying);
			}

			public object GetValue()
			{
				if (!Indexed)
				{
					return GetUnderlying();
				}
				return GetArrayValue(GetUnderlying(), Index);
			}

			private object GetUnderlying()
			{
				object value;
				if (!World.TryGetVar(Key, out value))
				{
					return null;
				}
				return value;
			}

			public void SetValue(object input)
			{
				if (Indexed)
				{
					if (!SetArrayValue(GetUnderlying(), Index, input, null))
					{
						throw new Exception("Tried to index into non index variable");
					}
				}
				else
				{
					World.SaveVar(Key, input, true);
				}
			}

			public void SetIndex(object index)
			{
				Index = index;
				Indexed = true;
			}

			public bool HasIndex()
			{
				return Index != null;
			}
		}

		public class SubIndexVariableResult : VariableResult
		{
			public object Object;

			public object Index;

			public bool Indexed;

			public SubIndexVariableResult Set(object obj, object index)
			{
				Object = obj;
				Index = index;
				Indexed = true;
				return this;
			}

			public void Reset()
			{
				Object = null;
				Index = null;
				Indexed = false;
			}

			public object GetValue()
			{
				return GetArrayValue(Object, Index);
			}

			public Type GetVarType()
			{
				return GetEnumerableType(Object);
			}

			public void SetValue(object input)
			{
				if (!SetArrayValue(Object, Index, input, null))
				{
					throw new Exception("Tried to index into non index variable");
				}
			}

			public void SetIndex(object index)
			{
				Index = index;
			}

			public bool HasIndex()
			{
				return Indexed;
			}
		}

		public class ReflectionVariableResult : VariableResult
		{
			public object Context;

			public PropertyInfo Property;

			public FieldInfo Field;

			public object Index;

			public ReflectionVariableResult Set(object context, PropertyInfo property)
			{
				Context = context;
				Property = property;
				return this;
			}

			public ReflectionVariableResult Set(object context, FieldInfo field)
			{
				Context = context;
				Field = field;
				return this;
			}

			public void Reset()
			{
				Context = null;
				Property = null;
				Field = null;
				Index = null;
			}

			public object GetValue()
			{
				bool indexed;
				object obj = GetObject(out indexed);
				if (Index != null && !indexed)
				{
					return GetArrayValue(obj, Index);
				}
				return obj;
			}

			private object GetObject(out bool indexed)
			{
				indexed = false;
				if (Property != null)
				{
					if (Index != null && Property.GetIndexParameters().Length != 0)
					{
						indexed = true;
						return Property.GetValue(Context, new object[1] { Index });
					}
					return Property.GetValue(Context, null);
				}
				return Field.GetValue(Context);
			}

			private object GetObject()
			{
				if (!(Property != null))
				{
					return Field.GetValue(Context);
				}
				return Property.GetValue(Context, null);
			}

			public Type GetVarType()
			{
				if (!(Property != null))
				{
					return Field.FieldType;
				}
				return Property.PropertyType;
			}

			public void SetValue(object input)
			{
				Type varType = GetVarType();
				if (Index == null || !SetArrayValue(GetObject(), Index, input, GetArrayVariableType(varType, true)))
				{
					if (Property != null)
					{
						Property.SetValue(Context, ConvertValue(input, varType), (Index == null) ? null : new object[1] { Index });
					}
					else
					{
						Field.SetValue(Context, ConvertValue(input, varType));
					}
				}
			}

			public void SetIndex(object index)
			{
				Index = index;
			}

			public bool HasIndex()
			{
				return Index != null;
			}
		}

		public interface VariableResult
		{
			void Reset();

			object GetValue();

			void SetValue(object input);

			void SetIndex(object index);

			bool HasIndex();

			Type GetVarType();
		}

		public enum TokenType
		{
			Null = 0,
			Add = 1,
			Subtract = 2,
			Multiply = 3,
			Divide = 4,
			Assign = 5,
			Not = 6,
			Or = 7,
			And = 8,
			Equal = 9,
			NotEqual = 10,
			Less = 11,
			LessEqual = 12,
			Greater = 13,
			GreaterEqual = 14,
			FunctionArgs = 16,
			Number = 17,
			String = 18,
			Bool = 19,
			Variable = 20,
			GoInto = 21,
			Power = 22,
			LeftParan = 23,
			ArrayAccess = 24,
			Comma = 25,
			EndLine = 27,
			If = 28,
			Else = 29,
			Block = 30,
			CreateVariable = 31,
			ArrayCreation = 32,
			ForEach = 33,
			RightParan = 34,
			LeftBracket = 35,
			RightBracket = 36,
			LeftSquareBracket = 37,
			RightSquareBracket = 38,
			In = 39,
			Questionmark = 40,
			Colon = 41,
			InlineIf = 42,
			TypeIs = 43,
			Break = 44,
			Modulo = 45
		}

		public class Token
		{
			public TokenType Type;

			public object Value;

			public int Line;

			public int Col;

			public Token(TokenType type, int line, int col)
			{
				Type = type;
				Line = line;
				Col = col;
			}

			public Token(TokenType type, object value, int line, int col)
			{
				Type = type;
				Value = value;
				Line = line;
				Col = col;
			}

			public override string ToString()
			{
				if (Value != null)
				{
					return string.Concat(Type, ": ", Value);
				}
				return Type.ToString();
			}
		}

		public class TreeNode
		{
			public Token TokenItem;

			public TreeNode Parent;

			public List<TreeNode> Children = new List<TreeNode>();

			public PropertyInfo CachedProperty;

			public FieldInfo CachedField;

			public MethodBase CachedMethod;

			public ParameterInfo[] CachedParameters;

			public bool CachedParamArray;

			public TreeNode Left
			{
				get
				{
					if (Children.Count <= 0)
					{
						return null;
					}
					return Children[0];
				}
				set
				{
					if (Children.Count > 0)
					{
						Children[0] = value;
						value.Parent = this;
					}
					else
					{
						AddLeft(value);
					}
				}
			}

			public TreeNode Right
			{
				get
				{
					if (Children.Count <= 1)
					{
						return null;
					}
					return Children[Children.Count - 1];
				}
				set
				{
					if (Children.Count > 1)
					{
						Children[Children.Count - 1] = value;
						value.Parent = this;
					}
					else
					{
						AddRight(value);
					}
				}
			}

			public void ClearCache()
			{
				CachedProperty = null;
				CachedField = null;
				CachedMethod = null;
				CachedParameters = null;
				CachedParamArray = false;
			}

			public TreeNode(TokenType type, int line, int col)
			{
				TokenItem = new Token(type, line, col);
			}

			public TreeNode(Token token)
			{
				TokenItem = token;
			}

			public void AddLeft(TreeNode node)
			{
				if (Children.Count > 0 && Children[0] == null)
				{
					Children[0] = node;
				}
				else
				{
					Children.Insert(0, node);
				}
				node.Parent = this;
			}

			public bool IsType(TokenType type)
			{
				return TokenItem.Type == type;
			}

			public void AddRight(TreeNode node)
			{
				if (Children.Count == 0)
				{
					Children.Add(null);
				}
				Children.Add(node);
				node.Parent = this;
			}

			public void ReplaceChild(TreeNode child, TreeNode nChild)
			{
				int index = Children.IndexOf(child);
				Children[index] = nChild;
				nChild.Parent = this;
			}

			public override string ToString()
			{
				if (TokenItem != null)
				{
					return string.Format("{0} ({1})", TokenItem, WriteTree(this));
				}
				return "null";
			}
		}

		public class LineParseException : Exception
		{
			public LineParseException(string msg)
				: base(msg)
			{
			}
		}

		public static KeyValuePair<string, TokenType>[] Operators = new KeyValuePair<string, TokenType>[36]
		{
			new KeyValuePair<string, TokenType>("+", TokenType.Add),
			new KeyValuePair<string, TokenType>("-", TokenType.Subtract),
			new KeyValuePair<string, TokenType>("*", TokenType.Multiply),
			new KeyValuePair<string, TokenType>("/", TokenType.Divide),
			new KeyValuePair<string, TokenType>("%", TokenType.Modulo),
			new KeyValuePair<string, TokenType>("^", TokenType.Power),
			new KeyValuePair<string, TokenType>(">=", TokenType.GreaterEqual),
			new KeyValuePair<string, TokenType>("<=", TokenType.LessEqual),
			new KeyValuePair<string, TokenType>("==", TokenType.Equal),
			new KeyValuePair<string, TokenType>("!=", TokenType.NotEqual),
			new KeyValuePair<string, TokenType>("=", TokenType.Assign),
			new KeyValuePair<string, TokenType>("<", TokenType.Less),
			new KeyValuePair<string, TokenType>(">", TokenType.Greater),
			new KeyValuePair<string, TokenType>(".", TokenType.GoInto),
			new KeyValuePair<string, TokenType>(",", TokenType.Comma),
			new KeyValuePair<string, TokenType>("||", TokenType.Or),
			new KeyValuePair<string, TokenType>("&&", TokenType.And),
			new KeyValuePair<string, TokenType>("!", TokenType.Not),
			new KeyValuePair<string, TokenType>("{", TokenType.LeftBracket),
			new KeyValuePair<string, TokenType>("}", TokenType.RightBracket),
			new KeyValuePair<string, TokenType>("(", TokenType.LeftParan),
			new KeyValuePair<string, TokenType>(")", TokenType.RightParan),
			new KeyValuePair<string, TokenType>("~[", TokenType.ArrayCreation),
			new KeyValuePair<string, TokenType>("[", TokenType.LeftSquareBracket),
			new KeyValuePair<string, TokenType>("]", TokenType.RightSquareBracket),
			new KeyValuePair<string, TokenType>(";", TokenType.EndLine),
			new KeyValuePair<string, TokenType>("if", TokenType.If),
			new KeyValuePair<string, TokenType>("else", TokenType.Else),
			new KeyValuePair<string, TokenType>("foreach", TokenType.ForEach),
			new KeyValuePair<string, TokenType>("null", TokenType.Null),
			new KeyValuePair<string, TokenType>("var", TokenType.CreateVariable),
			new KeyValuePair<string, TokenType>("in", TokenType.In),
			new KeyValuePair<string, TokenType>(":", TokenType.Colon),
			new KeyValuePair<string, TokenType>("?", TokenType.Questionmark),
			new KeyValuePair<string, TokenType>("is", TokenType.TypeIs),
			new KeyValuePair<string, TokenType>("break", TokenType.Break)
		};

		public static HashSet<string> NoPostLetter = new HashSet<string> { "if", "else", "foreach", "null", "var", "in", "is", "break" };

		public static KeyValuePair<string, bool>[] Bools = new KeyValuePair<string, bool>[4]
		{
			new KeyValuePair<string, bool>("True", true),
			new KeyValuePair<string, bool>("true", true),
			new KeyValuePair<string, bool>("False", false),
			new KeyValuePair<string, bool>("false", false)
		};

		public static Dictionary<string, MethodBase> Functions = new Dictionary<string, MethodBase>
		{
			{
				"Abs",
				typeof(Math).GetMethod("Abs", new Type[1] { typeof(double) })
			},
			{
				"Pow",
				typeof(Math).GetMethod("Pow", new Type[2]
				{
					typeof(double),
					typeof(double)
				})
			},
			{
				"Sqrt",
				typeof(Math).GetMethod("Sqrt", new Type[1] { typeof(double) })
			},
			{
				"Log",
				typeof(Math).GetMethod("Log", new Type[2]
				{
					typeof(double),
					typeof(double)
				})
			},
			{
				"Log10",
				typeof(Math).GetMethod("Log10", new Type[1] { typeof(double) })
			},
			{
				"Round",
				typeof(Math).GetMethod("Round", new Type[1] { typeof(double) })
			},
			{
				"Ceil",
				typeof(Math).GetMethod("Ceiling", new Type[1] { typeof(double) })
			},
			{
				"Floor",
				typeof(Math).GetMethod("Floor", new Type[1] { typeof(double) })
			},
			{
				"Min",
				typeof(Math).GetMethod("Min", new Type[2]
				{
					typeof(double),
					typeof(double)
				})
			},
			{
				"Max",
				typeof(Math).GetMethod("Max", new Type[2]
				{
					typeof(double),
					typeof(double)
				})
			},
			{
				"Sign",
				typeof(Math).GetMethod("Sign", new Type[2]
				{
					typeof(double),
					typeof(double)
				})
			},
			{
				"Sin",
				typeof(Math).GetMethod("Sin", new Type[1] { typeof(double) })
			},
			{
				"Cos",
				typeof(Math).GetMethod("Cos", new Type[1] { typeof(double) })
			},
			{
				"String",
				typeof(LineParse).GetMethod("InString", new Type[1] { typeof(object) })
			},
			{
				"FormatString",
				typeof(LineParse).GetMethod("FormatString", new Type[2]
				{
					typeof(double),
					typeof(string)
				})
			},
			{
				"Debug",
				typeof(LineParse).GetMethod("Debug", new Type[1] { typeof(object) })
			},
			{
				"Random",
				typeof(LineParse).GetMethod("Random", new Type[0])
			},
			{
				"RandomRange",
				typeof(LineParse).GetMethod("RandomRange", new Type[2]
				{
					typeof(double),
					typeof(double)
				})
			},
			{
				"RandomInteger",
				typeof(LineParse).GetMethod("RandomInteger", new Type[2]
				{
					typeof(int),
					typeof(int)
				})
			},
			{
				"Lerp",
				typeof(LineParse).GetMethod("Lerp", new Type[3]
				{
					typeof(double),
					typeof(double),
					typeof(double)
				})
			},
			{
				"Clamp",
				typeof(LineParse).GetMethod("Clamp", new Type[3]
				{
					typeof(double),
					typeof(double),
					typeof(double)
				})
			},
			{
				"Clamp01",
				typeof(LineParse).GetMethod("Clamp01", new Type[1] { typeof(double) })
			}
		};

		public static Dictionary<string, MethodBase> QueryFunctions = new Dictionary<string, MethodBase>
		{
			{
				"Any",
				typeof(LineParse).GetMethod("Any", new Type[3]
				{
					typeof(IEnumerable),
					typeof(TreeNode),
					typeof(ScriptWorld)
				})
			},
			{
				"All",
				typeof(LineParse).GetMethod("All", new Type[3]
				{
					typeof(IEnumerable),
					typeof(TreeNode),
					typeof(ScriptWorld)
				})
			},
			{
				"AnyAndAll",
				typeof(LineParse).GetMethod("AnyAndAll", new Type[3]
				{
					typeof(IEnumerable),
					typeof(TreeNode),
					typeof(ScriptWorld)
				})
			},
			{
				"None",
				typeof(LineParse).GetMethod("None", new Type[3]
				{
					typeof(IEnumerable),
					typeof(TreeNode),
					typeof(ScriptWorld)
				})
			},
			{
				"ForEach",
				typeof(LineParse).GetMethod("ForEach", new Type[3]
				{
					typeof(IEnumerable),
					typeof(TreeNode),
					typeof(ScriptWorld)
				})
			},
			{
				"Select",
				typeof(LineParse).GetMethod("Select", new Type[3]
				{
					typeof(IEnumerable),
					typeof(TreeNode),
					typeof(ScriptWorld)
				})
			},
			{
				"SelectMany",
				typeof(LineParse).GetMethod("SelectMany", new Type[3]
				{
					typeof(IEnumerable),
					typeof(TreeNode),
					typeof(ScriptWorld)
				})
			},
			{
				"Count",
				typeof(LineParse).GetMethod("Count", new Type[3]
				{
					typeof(IEnumerable),
					typeof(TreeNode),
					typeof(ScriptWorld)
				})
			},
			{
				"Where",
				typeof(LineParse).GetMethod("Where", new Type[3]
				{
					typeof(IEnumerable),
					typeof(TreeNode),
					typeof(ScriptWorld)
				})
			},
			{
				"OfType",
				typeof(LineParse).GetMethod("OfType", new Type[3]
				{
					typeof(IEnumerable),
					typeof(Type),
					typeof(ScriptWorld)
				})
			},
			{
				"FindFirst",
				typeof(LineParse).GetMethod("FindFirst", new Type[3]
				{
					typeof(IEnumerable),
					typeof(TreeNode),
					typeof(ScriptWorld)
				})
			},
			{
				"First",
				typeof(LineParse).GetMethod("First", new Type[1] { typeof(IEnumerable) })
			},
			{
				"Last",
				typeof(LineParse).GetMethod("Last", new Type[1] { typeof(IEnumerable) })
			},
			{
				"FindIndex",
				typeof(LineParse).GetMethod("FindIndex", new Type[3]
				{
					typeof(IEnumerable),
					typeof(TreeNode),
					typeof(ScriptWorld)
				})
			},
			{
				"OrderBy",
				typeof(LineParse).GetMethod("OrderBy", new Type[3]
				{
					typeof(IEnumerable),
					typeof(TreeNode),
					typeof(ScriptWorld)
				})
			},
			{
				"OrderByDescending",
				typeof(LineParse).GetMethod("OrderByDescending", new Type[3]
				{
					typeof(IEnumerable),
					typeof(TreeNode),
					typeof(ScriptWorld)
				})
			},
			{
				"Distinct",
				typeof(LineParse).GetMethod("Distinct", new Type[1] { typeof(IEnumerable) })
			},
			{
				"Duplicates",
				typeof(LineParse).GetMethod("Duplicates", new Type[1] { typeof(IEnumerable) })
			},
			{
				"Sum",
				typeof(LineParse).GetMethod("Sum", new Type[3]
				{
					typeof(IEnumerable),
					typeof(TreeNode),
					typeof(ScriptWorld)
				})
			},
			{
				"Max",
				typeof(LineParse).GetMethod("Max", new Type[3]
				{
					typeof(IEnumerable),
					typeof(TreeNode),
					typeof(ScriptWorld)
				})
			},
			{
				"Min",
				typeof(LineParse).GetMethod("Min", new Type[3]
				{
					typeof(IEnumerable),
					typeof(TreeNode),
					typeof(ScriptWorld)
				})
			},
			{
				"Average",
				typeof(LineParse).GetMethod("Average", new Type[3]
				{
					typeof(IEnumerable),
					typeof(TreeNode),
					typeof(ScriptWorld)
				})
			},
			{
				"Size",
				typeof(LineParse).GetMethod("Size", new Type[1] { typeof(IEnumerable) })
			},
			{
				"GetRandomElement",
				typeof(LineParse).GetMethod("GetRandomElement", new Type[1] { typeof(IEnumerable) })
			}
		};

		public static HashSet<string> AlterResult = new HashSet<string> { "Select", "SelectMany" };

		public static Dictionary<string, object> Constants = new Dictionary<string, object>
		{
			{
				"PI",
				Math.PI
			},
			{
				"E",
				Math.E
			},
			{
				"Infinity",
				double.PositiveInfinity
			}
		};

		public static HashSet<TokenType> Comparisons = new HashSet<TokenType>
		{
			TokenType.Less,
			TokenType.LessEqual,
			TokenType.GreaterEqual,
			TokenType.Greater
		};

		private static ObjectPool<TempVariableResult> _tempVarPool = new ObjectPool<TempVariableResult>(() => new TempVariableResult(), delegate(TempVariableResult x)
		{
			x.Reset();
		});

		private static ObjectPool<LocalVariableResult> _localVarPool = new ObjectPool<LocalVariableResult>(() => new LocalVariableResult(), delegate(LocalVariableResult x)
		{
			x.Reset();
		});

		private static ObjectPool<SubIndexVariableResult> _subIndexVarPool = new ObjectPool<SubIndexVariableResult>(() => new SubIndexVariableResult(), delegate(SubIndexVariableResult x)
		{
			x.Reset();
		});

		private static ObjectPool<ReflectionVariableResult> _reflectionVarPool = new ObjectPool<ReflectionVariableResult>(() => new ReflectionVariableResult(), delegate(ReflectionVariableResult x)
		{
			x.Reset();
		});

		public static Regex NumberLiteral = new Regex("\\G(\\d+(\\.\\d+)?)");

		public static Regex StringLiteral = new Regex("\\G\"([^\"]*)\"");

		public static Regex StringLiteral2 = new Regex("\\G'([^']*)'");

		public static Regex SymbolReg = new Regex("\\G(\\w+)");

		public static object ScriptLock = new object();

		public static bool RunningScript = false;

		private static List<TreeNode> _cachedArrayCreation = new List<TreeNode>();

		private static Type[] _OPTypeCache = new Type[2];

		private static List<MethodBase> _elligableMethods = new List<MethodBase>();

		private static List<object> _argumentObjects = new List<object>();

		private static ObjectPool<List<TreeNode>> _cachedArgs = new ObjectPool<List<TreeNode>>(() => new List<TreeNode>(), delegate(List<TreeNode> x)
		{
			x.Clear();
		});

		private static object[] _emptyArgs = new object[0];

		private static System.Random _rnd = new System.Random();

		public static string GetCleanName(TokenType t)
		{
			string text = null;
			for (int i = 0; i < Operators.Length; i++)
			{
				if (Operators[i].Value == t)
				{
					text = Operators[i].Key;
					break;
				}
			}
			return "'" + (text ?? t.ToString()) + "'";
		}

		public static void ClaimVariable(VariableResult r)
		{
			TempVariableResult r2;
			LocalVariableResult r3;
			SubIndexVariableResult r4;
			ReflectionVariableResult r5;
			if ((r2 = r as TempVariableResult) != null)
			{
				ClaimVariable(r2);
			}
			else if ((r3 = r as LocalVariableResult) != null)
			{
				ClaimVariable(r3);
			}
			else if ((r4 = r as SubIndexVariableResult) != null)
			{
				ClaimVariable(r4);
			}
			else if ((r5 = r as ReflectionVariableResult) != null)
			{
				ClaimVariable(r5);
			}
		}

		public static void ClaimVariable(TempVariableResult r)
		{
			_tempVarPool.Release(r);
		}

		public static void ClaimVariable(LocalVariableResult r)
		{
			_localVarPool.Release(r);
		}

		public static void ClaimVariable(SubIndexVariableResult r)
		{
			_subIndexVarPool.Release(r);
		}

		public static void ClaimVariable(ReflectionVariableResult r)
		{
			_reflectionVarPool.Release(r);
		}

		public static TreeNode Parse(string input)
		{
			List<Token> tokens = new List<Token>();
			input = input.TrimStart();
			int lastLine = 0;
			int curLine = 0;
			int pos = 0;
			while (pos < input.Length)
			{
				if (!GetToken(input, ref pos, ref curLine, ref lastLine, tokens))
				{
					throw new Exception("No match for:\n" + input.Substring(pos) + " at line: " + (curLine + 1));
				}
			}
			return EBNF.StartMatch(tokens);
		}

		private static bool StartsWith(string input, string match, int startAt)
		{
			for (int i = 0; i < match.Length; i++)
			{
				if (i + startAt >= input.Length || input[i + startAt] != match[i])
				{
					return false;
				}
			}
			return true;
		}

		private static bool GetToken(string input, ref int pos, ref int curLine, ref int lastLine, List<Token> tokens)
		{
			if (input[pos] == '\n')
			{
				pos++;
				curLine++;
				lastLine = pos;
				return true;
			}
			if (char.IsWhiteSpace(input[pos]))
			{
				pos++;
				return true;
			}
			if (StartsWith(input, "//", pos))
			{
				pos += 2;
				while (pos < input.Length)
				{
					if (input[pos] == '\n')
					{
						pos++;
						curLine++;
						lastLine = pos;
						break;
					}
					pos++;
				}
				return true;
			}
			for (int i = 0; i < Operators.Length; i++)
			{
				KeyValuePair<string, TokenType> keyValuePair = Operators[i];
				if (StartsWith(input, keyValuePair.Key, pos) && (!NoPostLetter.Contains(keyValuePair.Key) || pos + keyValuePair.Key.Length >= input.Length || !char.IsLetterOrDigit(input[pos + keyValuePair.Key.Length])))
				{
					tokens.Add(new Token(keyValuePair.Value, curLine, pos - lastLine));
					pos += keyValuePair.Key.Length;
					return true;
				}
			}
			Match match = NumberLiteral.Match(input, pos);
			if (match.Success)
			{
				tokens.Add(new Token(TokenType.Number, Convert.ToDouble(match.Value, CultureInfo.InvariantCulture), curLine, pos - lastLine));
				pos += match.Value.Length;
				return true;
			}
			for (int j = 0; j < Bools.Length; j++)
			{
				KeyValuePair<string, bool> keyValuePair2 = Bools[j];
				if (StartsWith(input, keyValuePair2.Key, pos))
				{
					tokens.Add(new Token(TokenType.Bool, keyValuePair2.Value, curLine, pos - lastLine));
					pos += keyValuePair2.Key.Length;
					return true;
				}
			}
			match = StringLiteral.Match(input, pos);
			if (!match.Success)
			{
				match = StringLiteral2.Match(input, pos);
			}
			if (match.Success)
			{
				string value = match.Groups[1].Value;
				FixLineString(value, pos + 1, ref curLine, ref lastLine);
				tokens.Add(new Token(TokenType.String, value, curLine, pos - lastLine));
				pos += match.Value.Length;
				return true;
			}
			match = SymbolReg.Match(input, pos);
			if (match.Success)
			{
				tokens.Add(new Token(TokenType.Variable, match.Value, curLine, pos - lastLine));
				pos += match.Value.Length;
				return true;
			}
			return false;
		}

		private static void FixLineString(string s, int offset, ref int curLine, ref int lastLine)
		{
			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] == '\n')
				{
					curLine++;
					lastLine = offset + i + 1;
				}
			}
		}

		public static object Execute(TreeNode node, ScriptWorld world, bool keepTempVars = false)
		{
			lock (ScriptLock)
			{
				try
				{
					RunningScript = true;
					if (!keepTempVars)
					{
						world.ResetTempVars();
					}
					object value = GetValue(ExecuteTree(node, null, world, null));
					_localVarPool.ReleaseAll();
					_tempVarPool.ReleaseAll();
					_reflectionVarPool.ReleaseAll();
					return value;
				}
				finally
				{
					RunningScript = false;
				}
			}
		}

		public static string WriteTree(TreeNode node, int indent = 0, TreeNode emph = null)
		{
			string text = "";
			if (node != null)
			{
				if (emph == node)
				{
					text += " >>";
				}
				switch (node.TokenItem.Type)
				{
				case TokenType.LeftParan:
					text = text + Indent(indent) + "(" + WriteTree(node.Left, 0, emph) + ")";
					break;
				case TokenType.Null:
					text = text + Indent(indent) + "null";
					break;
				case TokenType.Add:
					text = text + Indent(indent) + "(" + WriteTree(node.Left, 0, emph) + " + " + WriteTree(node.Right, 0, emph) + ")";
					break;
				case TokenType.Subtract:
					text = ((node.Left != null) ? (text + Indent(indent) + "(" + WriteTree(node.Left, 0, emph) + " - " + WriteTree(node.Right, 0, emph) + ")") : (text + Indent(indent) + "-(" + WriteTree(node.Right, 0, emph) + ")"));
					break;
				case TokenType.Multiply:
					text = text + Indent(indent) + "(" + WriteTree(node.Left, 0, emph) + " * " + WriteTree(node.Right, 0, emph) + ")";
					break;
				case TokenType.Divide:
					text = text + Indent(indent) + "(" + WriteTree(node.Left, 0, emph) + " / " + WriteTree(node.Right, 0, emph) + ")";
					break;
				case TokenType.Modulo:
					text = text + Indent(indent) + "(" + WriteTree(node.Left, 0, emph) + " % " + WriteTree(node.Right, 0, emph) + ")";
					break;
				case TokenType.Assign:
					text = text + Indent(indent) + "(" + WriteTree(node.Left, 0, emph) + " = " + WriteTree(node.Right, 0, emph) + ")";
					break;
				case TokenType.Not:
					text = text + Indent(indent) + "!(" + WriteTree(node.Right, 0, emph) + ")";
					break;
				case TokenType.Or:
					text = text + Indent(indent) + "(" + WriteTree(node.Left, 0, emph) + " || " + WriteTree(node.Right, 0, emph) + ")";
					break;
				case TokenType.And:
					text = text + Indent(indent) + "(" + WriteTree(node.Left, 0, emph) + " && " + WriteTree(node.Right, 0, emph) + ")";
					break;
				case TokenType.TypeIs:
					text = text + Indent(indent) + "(" + WriteTree(node.Left, 0, emph) + " is " + WriteTree(node.Right, 0, emph) + ")";
					break;
				case TokenType.Equal:
					text = text + Indent(indent) + "(" + WriteTree(node.Left, 0, emph) + " == " + WriteTree(node.Right, 0, emph) + ")";
					break;
				case TokenType.NotEqual:
					text = text + Indent(indent) + "(" + WriteTree(node.Left, 0, emph) + " != " + WriteTree(node.Right, 0, emph) + ")";
					break;
				case TokenType.Less:
					text = text + Indent(indent) + "(" + WriteTree(node.Left, 0, emph) + " < " + WriteTree(node.Right, 0, emph) + ")";
					break;
				case TokenType.LessEqual:
					text = text + Indent(indent) + "(" + WriteTree(node.Left, 0, emph) + " <= " + WriteTree(node.Right, 0, emph) + ")";
					break;
				case TokenType.Greater:
					text = text + Indent(indent) + "(" + WriteTree(node.Left, 0, emph) + " > " + WriteTree(node.Right, 0, emph) + ")";
					break;
				case TokenType.GreaterEqual:
					text = text + Indent(indent) + "(" + WriteTree(node.Left, 0, emph) + " >= " + WriteTree(node.Right, 0, emph) + ")";
					break;
				case TokenType.FunctionArgs:
					text = text + Indent(indent) + node.TokenItem.Value.ToString() + "(" + WriteTree(node.Left, 0, emph) + ")";
					break;
				case TokenType.String:
					text = text + Indent(indent) + "\"" + node.TokenItem.Value.ToString() + "\"";
					break;
				case TokenType.Number:
				case TokenType.Bool:
				case TokenType.Variable:
					text = text + Indent(indent) + node.TokenItem.Value.ToString();
					break;
				case TokenType.GoInto:
					text = text + Indent(indent) + WriteTree(node.Left, 0, emph) + "." + WriteTree(node.Right, 0, emph);
					break;
				case TokenType.Power:
					text = text + Indent(indent) + "(" + WriteTree(node.Left, 0, emph) + " ^ " + WriteTree(node.Right, 0, emph) + ")";
					break;
				case TokenType.ArrayAccess:
				{
					TreeNode node2 = (TreeNode)node.TokenItem.Value;
					text = text + Indent(indent) + WriteTree(node.Left, 0, emph) + "[" + WriteTree(node2, 0, emph) + "]";
					break;
				}
				case TokenType.Comma:
					text = text + Indent(indent) + WriteTree(node.Left, 0, emph) + ", " + WriteTree(node.Right, 0, emph);
					break;
				case TokenType.EndLine:
					text = ((node.Right != null) ? (text + WriteTree(node.Left, indent, emph) + ";\n" + WriteTree(node.Right, indent, emph)) : (text + WriteTree(node.Left, indent, emph) + ";"));
					break;
				case TokenType.If:
					text = ((node.Right.TokenItem.Type != TokenType.Else) ? (text + Indent(indent) + "if (" + WriteTree(node.Left, 0, emph) + ")\n" + SurroundWithBracket(indent + 1, node.Right)) : (text + Indent(indent) + "if (" + WriteTree(node.Left, 0, emph) + ")\n" + WriteTree(node.Right, indent, emph)));
					break;
				case TokenType.Else:
					text = text + SurroundWithBracket(indent + 1, node.Left) + "\n" + Indent(indent) + "else\n" + SurroundWithBracket(indent + 1, node.Right);
					break;
				case TokenType.Block:
					text = ((node.Right != null) ? (text + SurroundWithBracket(indent, node.Left) + "\n" + WriteTree(node.Right, 0, emph)) : (text + SurroundWithBracket(indent, node.Left)));
					break;
				case TokenType.CreateVariable:
					text = text + Indent(indent) + "var " + node.TokenItem.Value.ToString();
					break;
				case TokenType.ArrayCreation:
				{
					StringBuilder stringBuilder = new StringBuilder(Indent(indent) + "~[ ");
					for (int i = 0; i < node.Children.Count; i++)
					{
						stringBuilder.Append(WriteTree(node.Children[i], 0, emph));
						if (i < node.Children.Count - 1)
						{
							stringBuilder.Append("; ");
						}
					}
					stringBuilder.Append(" ]");
					text += stringBuilder.ToString();
					break;
				}
				case TokenType.ForEach:
					text = string.Concat(text, Indent(indent), "foreach (", node.TokenItem.Value, " in ", WriteTree(node.Left, 0, emph), ")\n", SurroundWithBracket(indent + 1, node.Right));
					break;
				case TokenType.Break:
					text = text + Indent(indent) + "break";
					break;
				}
				if (emph == node)
				{
					text += "<< ";
				}
			}
			else
			{
				text = text + Indent(indent) + "null";
			}
			return text;
		}

		private static string SurroundWithBracket(int i, TreeNode node)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(Indent(i));
			stringBuilder.AppendLine("{");
			stringBuilder.AppendLine(WriteTree(node, i));
			stringBuilder.Append(Indent(i));
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}

		private static string Indent(int i)
		{
			if (i == 0)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int j = 0; j < i; j++)
			{
				stringBuilder.Append("    ");
			}
			return stringBuilder.ToString();
		}

		private static void Traverse(TreeNode node, TokenType separator, List<TreeNode> result)
		{
			while (node.IsType(separator))
			{
				result.Add(node.Right);
				node = node.Left;
			}
			result.Add(node);
			if (result.Count > 1)
			{
				result.Reverse();
			}
		}

		private static TreeNode GetFirst(TreeNode node, TokenType separator)
		{
			while (node.IsType(separator))
			{
				node = node.Left;
			}
			return node;
		}

		private static object ExecuteTree(TreeNode node, object context, ScriptWorld world, TempVar tempVar)
		{
			bool hitBreak = false;
			return ExecuteTree(node, context, world, tempVar, ref hitBreak);
		}

		private static object ExecuteTree(TreeNode node, object context, ScriptWorld world, TempVar tempVar, ref bool hitBreak)
		{
			if (node == null)
			{
				return null;
			}
			try
			{
				switch (node.TokenItem.Type)
				{
				case TokenType.EndLine:
					if (node.Right == null)
					{
						return ExecuteTree(node.Left, context, world, tempVar, ref hitBreak);
					}
					ExecuteTree(node.Left, context, world, tempVar, ref hitBreak);
					return hitBreak ? null : ExecuteTree(node.Right, context, world, tempVar, ref hitBreak);
				case TokenType.Null:
					return null;
				case TokenType.LeftParan:
				case TokenType.Comma:
					return (node.Children.Count > 0) ? ExecuteTree(node.Left, context, world, tempVar) : null;
				case TokenType.Add:
				{
					object value16 = GetValue(ExecuteTree(node.Left, context, world, tempVar));
					object value17 = GetValue(ExecuteTree(node.Right, context, world, tempVar));
					object obj;
					if ((obj = value16) is double)
					{
						double num8 = (double)obj;
						if ((obj = value17) is double)
						{
							double num9 = (double)obj;
							return num8 + num9;
						}
					}
					if (value16 != null && value17 != null)
					{
						_OPTypeCache[0] = value16.GetType();
						_OPTypeCache[1] = value17.GetType();
						MethodInfo method3 = _OPTypeCache[0].GetMethod("op_Addition", _OPTypeCache);
						if (method3 != null)
						{
							return method3.Invoke(null, new object[2] { value16, value17 });
						}
						return value16.ToString() + value17.ToString();
					}
					throw new Exception("Tried to add non addable types");
				}
				case TokenType.Subtract:
				{
					object obj3 = ((node.Left == null) ? null : GetValue(ExecuteTree(node.Left, context, world, tempVar)));
					object value19 = GetValue(ExecuteTree(node.Right, context, world, tempVar));
					object obj;
					if (obj3 == null && (obj = value19) is double)
					{
						double num10 = (double)obj;
						return 0.0 - num10;
					}
					if ((obj = obj3) is double)
					{
						double num11 = (double)obj;
						if ((obj = value19) is double)
						{
							double num12 = (double)obj;
							return num11 - num12;
						}
					}
					if (obj3 != null && value19 != null)
					{
						_OPTypeCache[0] = obj3.GetType();
						_OPTypeCache[1] = value19.GetType();
						MethodInfo method4 = _OPTypeCache[0].GetMethod("op_Subtraction", _OPTypeCache);
						if (method4 != null)
						{
							return method4.Invoke(null, new object[2] { obj3, value19 });
						}
					}
					throw new Exception("Tried to subtract non subtractable types");
				}
				case TokenType.Multiply:
				{
					object value13 = GetValue(ExecuteTree(node.Left, context, world, tempVar));
					object value14 = GetValue(ExecuteTree(node.Right, context, world, tempVar));
					object obj;
					if ((obj = value13) is double)
					{
						double num5 = (double)obj;
						if ((obj = value14) is double)
						{
							double num6 = (double)obj;
							return num5 * num6;
						}
					}
					if (value13 != null && value14 != null)
					{
						_OPTypeCache[0] = value13.GetType();
						if ((obj = value14) is double)
						{
							double num7 = (double)obj;
							_OPTypeCache[1] = typeof(float);
							MethodInfo method = _OPTypeCache[0].GetMethod("op_Multiply", _OPTypeCache);
							if (method != null)
							{
								return method.Invoke(null, new object[2]
								{
									value13,
									(float)num7
								});
							}
						}
						else
						{
							_OPTypeCache[1] = value14.GetType();
							MethodInfo method2 = _OPTypeCache[0].GetMethod("op_Multiply", _OPTypeCache);
							if (method2 != null)
							{
								return method2.Invoke(null, new object[2] { value13, value14 });
							}
						}
					}
					throw new Exception("Tried to multiply non numbers");
				}
				case TokenType.Divide:
				{
					object value5 = GetValue(ExecuteTree(node.Left, context, world, tempVar));
					object value6 = GetValue(ExecuteTree(node.Right, context, world, tempVar));
					object obj = value5;
					if (value5 is double)
					{
						double num3 = (double)obj;
						if ((obj = value6) is double)
						{
							double num4 = (double)obj;
							return num3 / num4;
						}
					}
					throw new Exception("Tried to divide non numbers");
				}
				case TokenType.Modulo:
				{
					object value = GetValue(ExecuteTree(node.Left, context, world, tempVar));
					object value2 = GetValue(ExecuteTree(node.Right, context, world, tempVar));
					object obj = value;
					if (value is double)
					{
						double num = (double)obj;
						if ((obj = value2) is double)
						{
							double num2 = (double)obj;
							return num % num2;
						}
					}
					throw new Exception("Tried to mod non numbers");
				}
				case TokenType.Power:
				{
					object value3 = GetValue(ExecuteTree(node.Left, context, world, tempVar));
					object value4 = GetValue(ExecuteTree(node.Right, context, world, tempVar));
					object obj;
					if ((obj = value3) is double)
					{
						double x = (double)obj;
						if ((obj = value4) is double)
						{
							double y = (double)obj;
							return Math.Pow(x, y);
						}
					}
					if ((obj = value3) is bool)
					{
						bool flag2 = (bool)obj;
						if ((obj = value4) is bool)
						{
							bool flag3 = (bool)obj;
							return flag2 ^ flag3;
						}
					}
					throw new Exception("Tried to take power of non numbers");
				}
				case TokenType.Not:
				{
					object obj;
					if ((obj = GetValue(ExecuteTree(node.Right, context, world, tempVar))) is bool)
					{
						bool flag4 = (bool)obj;
						return !flag4;
					}
					throw new Exception("Tried to invert non bool");
				}
				case TokenType.Or:
				{
					object obj;
					if ((obj = GetValue(ExecuteTree(node.Left, context, world, tempVar))) is bool)
					{
						if ((bool)obj)
						{
							return true;
						}
						if ((obj = GetValue(ExecuteTree(node.Right, context, world, tempVar))) is bool)
						{
							bool flag5 = (bool)obj;
							return flag5;
						}
						throw new Exception("Tried logic or on non bools");
					}
					throw new Exception("Tried logic or on non bools");
				}
				case TokenType.And:
				{
					object obj;
					if ((obj = GetValue(ExecuteTree(node.Left, context, world, tempVar))) is bool)
					{
						if (!(bool)obj)
						{
							return false;
						}
						if ((obj = GetValue(ExecuteTree(node.Right, context, world, tempVar))) is bool)
						{
							bool flag6 = (bool)obj;
							return flag6;
						}
						throw new Exception("Tried logic and on non bools");
					}
					throw new Exception("Tried logic and on non bools");
				}
				case TokenType.TypeIs:
				{
					object value15 = GetValue(ExecuteTree(node.Left, context, world, tempVar));
					Type type;
					if ((object)(type = GetValue(ExecuteTree(node.Right, context, world, tempVar)) as Type) != null)
					{
						return type.IsInstanceOfType(value15);
					}
					throw new Exception("Tried is on none Type");
				}
				case TokenType.Equal:
				{
					object value18 = GetValue(ExecuteTree(node.Left, context, world, tempVar));
					object o2 = EnumIfEnum(value18, node.Right, context, world, tempVar);
					return SafeEquals(value18, o2);
				}
				case TokenType.NotEqual:
				{
					object value8 = GetValue(ExecuteTree(node.Left, context, world, tempVar));
					object o = EnumIfEnum(value8, node.Right, context, world, tempVar);
					return !SafeEquals(value8, o);
				}
				case TokenType.Less:
				case TokenType.LessEqual:
				case TokenType.Greater:
				case TokenType.GreaterEqual:
					return ExecuteTreeComparison(node, context, world, true, tempVar).HasValue;
				case TokenType.FunctionArgs:
				{
					string text = node.TokenItem.Value.ToString();
					MethodBase value11 = null;
					List<TreeNode> list = _cachedArgs.Get();
					List<TreeNode> list2 = ParseArgs(node, list);
					object[] objs;
					if (context != null)
					{
						if (context is IEnumerable && QueryFunctions.TryGetValue(text, out value11))
						{
							MethodInfo methodInfo = (MethodInfo)value11;
							if (methodInfo.IsGenericMethod)
							{
								value11 = methodInfo.MakeGenericMethod((Type)ExecuteTree(list2[0], null, world, null));
							}
							object result = FixNumber(value11.Invoke(null, GetArgObjects(node, PrePassArguments(node, list2, context, world, tempVar, value11), value11, world, tempVar)));
							_cachedArgs.Release(list);
							return result;
						}
						value11 = ExtractMethod((context as Type) ?? context.GetType(), node, world, tempVar, null, list2, false, false, out objs);
						_cachedArgs.Release(list);
						if (value11 != null)
						{
							return FixNumber(value11.Invoke(context, objs));
						}
						throw new Exception("Failed finding function " + text);
					}
					if (Functions.TryGetValue(text, out value11))
					{
						object result2 = FixNumber(value11.Invoke(null, GetArgObjects(node, PrePassArguments(node, list2, null, world, tempVar, value11), value11, world, tempVar)));
						_cachedArgs.Release(list);
						return result2;
					}
					value11 = ExtractMethod(world.GetType(), node, world, tempVar, null, list2, false, false, out objs);
					if (value11 != null)
					{
						_cachedArgs.Release(list);
						return FixNumber(value11.Invoke(world, objs));
					}
					Type typeFromName = world.GetTypeFromName(text);
					if (typeFromName != null)
					{
						value11 = ExtractMethod(typeFromName, node, world, tempVar, null, list2, false, true, out objs);
						_cachedArgs.Release(list);
						if (value11 != null)
						{
							return FixNumber(((ConstructorInfo)value11).Invoke(objs));
						}
						throw new Exception("Failed finding constructor for " + text);
					}
					_cachedArgs.Release(list);
					throw new Exception("Failed finding function " + text);
				}
				case TokenType.Number:
					return (double)node.TokenItem.Value;
				case TokenType.String:
					return node.TokenItem.Value.ToString();
				case TokenType.Bool:
					return (bool)node.TokenItem.Value;
				case TokenType.Variable:
				{
					string text2 = node.TokenItem.Value.ToString();
					if (context == null)
					{
						if (tempVar != null && tempVar.Name.Equals(text2))
						{
							return _tempVarPool.Get().Set(tempVar);
						}
						if (world.HasVar(text2))
						{
							return _localVarPool.Get().Set(world, text2);
						}
						object value20;
						if (Constants.TryGetValue(text2, out value20))
						{
							return value20;
						}
						VariableResult variableValue = GetVariableValue(world, world, node, world.IsProtected(), false);
						if (variableValue != null)
						{
							return variableValue;
						}
						Type typeFromName2 = world.GetTypeFromName(text2);
						if (typeFromName2 != null)
						{
							if (world.IsRestricted(typeFromName2))
							{
								throw new Exception(typeFromName2.FullName + " is not accessible");
							}
							return typeFromName2;
						}
						throw new Exception("Member not found: " + text2);
					}
					return GetVariableValue(context, world, node, world.IsProtected());
				}
				case TokenType.ArrayAccess:
				{
					object obj2 = ExecuteTree(node.Left, context, world, tempVar);
					object value9 = GetValue(ExecuteTree((TreeNode)node.TokenItem.Value, null, world, tempVar));
					VariableResult variableResult;
					if ((variableResult = obj2 as VariableResult) == null)
					{
						return GetArrayValue(GetValue(obj2), value9);
					}
					if (variableResult.HasIndex())
					{
						object value10 = variableResult.GetValue();
						ClaimVariable(variableResult);
						return _subIndexVarPool.Get().Set(value10, value9);
					}
					variableResult.SetIndex(value9);
					return variableResult;
				}
				case TokenType.GoInto:
				{
					object value7 = GetValue(ExecuteTree(node.Left, context, world, tempVar));
					if (value7 == null)
					{
						throw new Exception("Reference null exception when getting " + node.Right.TokenItem.Value);
					}
					return ExecuteTree(node.Right, value7, world, tempVar);
				}
				case TokenType.Assign:
				{
					if (node.Left.IsType(TokenType.CreateVariable))
					{
						string text3 = node.Left.TokenItem.Value.ToString();
						if (world.HasVar(text3))
						{
							throw new Exception("Cannot declare existing variable: " + text3);
						}
						object value21 = GetValue(ExecuteTree(node.Right, context, world, tempVar));
						world.SaveVar(text3, value21, true);
						return value21;
					}
					VariableResult obj4 = ExecuteTree(node.Left, context, world, tempVar) as VariableResult;
					if (obj4 == null)
					{
						throw new Exception("Could not assign to expression: " + WriteTree(node.Left));
					}
					object obj5 = EnumIfEnum(obj4.GetVarType(), node.Right, context, world, tempVar);
					obj4.SetValue(obj5);
					ClaimVariable(obj4);
					return obj5;
				}
				case TokenType.If:
				{
					object value12 = GetValue(ExecuteTree(node.Left, context, world, tempVar));
					if (value12 is bool)
					{
						if (node.Right.TokenItem.Type == TokenType.Else)
						{
							return ((bool)value12) ? ExecuteTree(node.Right.Left, context, world, tempVar, ref hitBreak) : ExecuteTree(node.Right.Right, context, world, tempVar, ref hitBreak);
						}
						return ((bool)value12) ? ExecuteTree(node.Right, context, world, tempVar, ref hitBreak) : null;
					}
					throw new Exception("Couldn't evaluate if statement to bool");
				}
				case TokenType.Block:
					ExecuteTree(node.Left, context, world, tempVar, ref hitBreak);
					return hitBreak ? null : ExecuteTree(node.Right, context, world, tempVar, ref hitBreak);
				case TokenType.CreateVariable:
					world.SaveVar(node.TokenItem.Value.ToString(), null, true);
					return null;
				case TokenType.ArrayCreation:
				{
					if (node.Left == null)
					{
						return new object[0];
					}
					_cachedArrayCreation.Clear();
					Traverse(node.Left, TokenType.Comma, _cachedArrayCreation);
					object[] array = new object[_cachedArrayCreation.Count];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = GetValue(ExecuteTree(_cachedArrayCreation[i], context, world, tempVar));
					}
					return array;
				}
				case TokenType.ForEach:
				{
					IEnumerable enumerable;
					if ((enumerable = GetValue(ExecuteTree(node.Left, context, world, tempVar)) as IEnumerable) != null)
					{
						TempVar tempVar2 = new TempVar(node.TokenItem.Value.ToString());
						bool hitBreak2 = false;
						foreach (object item in enumerable)
						{
							ExecuteTree(node.Right, context, world, tempVar2.Val(item), ref hitBreak2);
							if (hitBreak2)
							{
								break;
							}
						}
						return null;
					}
					throw new Exception("Tried enumerating non enumerable");
				}
				case TokenType.InlineIf:
				{
					bool flag = (bool)GetValue(ExecuteTree(node.Left, context, world, tempVar));
					return ExecuteTree(node.Children[flag ? 1 : 2], context, world, tempVar);
				}
				case TokenType.Break:
					hitBreak = true;
					return null;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
			catch (LineParseException)
			{
				throw;
			}
			catch (Exception innerException)
			{
				while (innerException.InnerException != null)
				{
					innerException = innerException.InnerException;
				}
				string text4 = "";
				try
				{
					text4 = " - at " + WriteTree(GetNearestParent(node), 0, node);
				}
				catch
				{
				}
				throw new LineParseException(innerException.GetType().Name + ": " + innerException.Message + text4);
			}
		}

		private static TreeNode GetNearestParent(TreeNode n)
		{
			while (n.Parent != null && !n.Parent.IsType(TokenType.EndLine) && !n.Parent.IsType(TokenType.Block) && !n.Parent.IsType(TokenType.If) && !n.Parent.IsType(TokenType.Else) && !n.Parent.IsType(TokenType.ForEach))
			{
				n = n.Parent;
			}
			return n;
		}

		public static bool IsNumeric(Type o)
		{
			TypeCode typeCode = Type.GetTypeCode(o);
			if ((uint)(typeCode - 5) <= 10u)
			{
				return true;
			}
			return false;
		}

		public static Type GetType(TreeNode node, ScriptWorld world)
		{
			lock (ScriptLock)
			{
				world.ResetTempVars();
				return SubGetType(node, null, world, null);
			}
		}

		private static Type SubGetType(TreeNode node, object context, ScriptWorld world, TempVarType tempVar, bool allowReadOnly = true)
		{
			if (node == null)
			{
				return null;
			}
			try
			{
				switch (node.TokenItem.Type)
				{
				case TokenType.EndLine:
				{
					Type result = SubGetType(node.Left, context, world, tempVar);
					if (node.Right != null)
					{
						return SubGetType(node.Right, context, world, tempVar);
					}
					return result;
				}
				case TokenType.LeftParan:
				case TokenType.Comma:
					return (node.Left != null) ? SubGetType(node.Left, context, world, tempVar) : null;
				case TokenType.Add:
				{
					Type type6 = SubGetType(node.Left, context, world, tempVar);
					Type type7 = SubGetType(node.Right, context, world, tempVar);
					Type typeFromHandle4 = typeof(double);
					Type typeFromHandle5 = typeof(string);
					if (type6 == typeFromHandle4 && type7 == typeFromHandle4)
					{
						return typeFromHandle4;
					}
					if (type6 != null && type7 != null)
					{
						_OPTypeCache[0] = type6;
						_OPTypeCache[1] = type7;
						MethodInfo method = _OPTypeCache[0].GetMethod("op_Addition", _OPTypeCache);
						if (method != null)
						{
							return method.ReturnType;
						}
					}
					return typeFromHandle5;
				}
				case TokenType.Subtract:
				{
					Type type10 = ((node.Left == null) ? null : SubGetType(node.Left, context, world, tempVar));
					Type type11 = SubGetType(node.Right, context, world, tempVar);
					Type typeFromHandle7 = typeof(double);
					if (type10 == typeFromHandle7 || type11 == typeFromHandle7)
					{
						return typeFromHandle7;
					}
					if (type10 != null && type11 != null)
					{
						_OPTypeCache[0] = type10;
						_OPTypeCache[1] = type11;
						MethodInfo method2 = _OPTypeCache[0].GetMethod("op_Subtraction", _OPTypeCache);
						if (method2 != null)
						{
							return method2.ReturnType;
						}
					}
					throw new Exception("Types do not match operator");
				}
				case TokenType.Multiply:
				{
					Type type18 = SubGetType(node.Left, context, world, tempVar);
					Type type19 = SubGetType(node.Right, context, world, tempVar);
					Type typeFromHandle11 = typeof(double);
					if (type18 == typeFromHandle11 && type19 == typeFromHandle11)
					{
						return typeFromHandle11;
					}
					throw new Exception("Types do not match operator");
				}
				case TokenType.Divide:
				{
					Type type28 = SubGetType(node.Left, context, world, tempVar);
					Type type29 = SubGetType(node.Right, context, world, tempVar);
					Type typeFromHandle18 = typeof(double);
					if (type28 == typeFromHandle18 && type29 == typeFromHandle18)
					{
						return typeFromHandle18;
					}
					throw new Exception("Types do not match operator");
				}
				case TokenType.Modulo:
				{
					Type type26 = SubGetType(node.Left, context, world, tempVar);
					Type type27 = SubGetType(node.Right, context, world, tempVar);
					Type typeFromHandle17 = typeof(double);
					if (type26 == typeFromHandle17 && type27 == typeFromHandle17)
					{
						return typeFromHandle17;
					}
					throw new Exception("Types do not match operator");
				}
				case TokenType.Not:
				{
					Type type4 = SubGetType(node.Right, context, world, tempVar);
					Type typeFromHandle3 = typeof(bool);
					if (type4.IsAssignableFrom(typeFromHandle3))
					{
						return typeFromHandle3;
					}
					throw new Exception("Types do not match operator");
				}
				case TokenType.Or:
				{
					Type type24 = SubGetType(node.Left, context, world, tempVar);
					Type type25 = SubGetType(node.Right, context, world, tempVar);
					Type typeFromHandle16 = typeof(bool);
					if (type24.IsAssignableFrom(typeFromHandle16) && type25.IsAssignableFrom(typeFromHandle16))
					{
						return typeFromHandle16;
					}
					throw new Exception("Types do not match operator");
				}
				case TokenType.And:
				{
					Type type8 = SubGetType(node.Left, context, world, tempVar);
					Type type9 = SubGetType(node.Right, context, world, tempVar);
					Type typeFromHandle6 = typeof(bool);
					if (type8.IsAssignableFrom(typeFromHandle6) && type9.IsAssignableFrom(typeFromHandle6))
					{
						return typeFromHandle6;
					}
					throw new Exception("Types do not match operator");
				}
				case TokenType.Equal:
					SubGetType(node.Left, context, world, tempVar);
					SubGetType(node.Right, context, world, tempVar);
					return typeof(bool);
				case TokenType.NotEqual:
					SubGetType(node.Left, context, world, tempVar);
					SubGetType(node.Right, context, world, tempVar);
					return typeof(bool);
				case TokenType.Less:
				{
					Type type2 = SubGetType(node.Left, context, world, tempVar);
					Type type3 = SubGetType(node.Right, context, world, tempVar);
					Type typeFromHandle = typeof(double);
					Type typeFromHandle2 = typeof(bool);
					if (type2 == typeFromHandle && type3 == typeFromHandle)
					{
						return typeFromHandle2;
					}
					throw new Exception("Types do not match operator");
				}
				case TokenType.LessEqual:
				{
					Type type22 = SubGetType(node.Left, context, world, tempVar);
					Type type23 = SubGetType(node.Right, context, world, tempVar);
					Type typeFromHandle14 = typeof(double);
					Type typeFromHandle15 = typeof(bool);
					if (type22 == typeFromHandle14 && type23 == typeFromHandle14)
					{
						return typeFromHandle15;
					}
					throw new Exception("Types do not match operator");
				}
				case TokenType.Greater:
				{
					Type type20 = SubGetType(node.Left, context, world, tempVar);
					Type type21 = SubGetType(node.Right, context, world, tempVar);
					Type typeFromHandle12 = typeof(double);
					Type typeFromHandle13 = typeof(bool);
					if (type20 == typeFromHandle12 && type21 == typeFromHandle12)
					{
						return typeFromHandle13;
					}
					throw new Exception("Types do not match operator");
				}
				case TokenType.GreaterEqual:
				{
					Type type12 = SubGetType(node.Left, context, world, tempVar);
					Type type13 = SubGetType(node.Right, context, world, tempVar);
					Type typeFromHandle8 = typeof(double);
					Type typeFromHandle9 = typeof(bool);
					if (type12 == typeFromHandle8 && type13 == typeFromHandle8)
					{
						return typeFromHandle9;
					}
					throw new Exception("Types do not match operator");
				}
				case TokenType.FunctionArgs:
				{
					string text2 = node.TokenItem.Value.ToString();
					MethodBase value = null;
					List<TreeNode> list = _cachedArgs.Get();
					List<TreeNode> list2 = ParseArgs(node, list);
					object[] objs;
					if (context != null)
					{
						bool flag = context is IEnumerable;
						Type type14 = context as Type;
						if (type14 != null)
						{
							flag = typeof(IEnumerable).IsAssignableFrom(type14);
						}
						if (flag && QueryFunctions.TryGetValue(text2, out value))
						{
							if (((MethodInfo)value).ReturnType == typeof(IEnumerable))
							{
								if (AlterResult.Contains(text2))
								{
									Type type15 = SubGetType(list2[0], null, world, new TempVarType("x", GetArrayVariableType(type14 ?? context.GetType(), false)));
									_cachedArgs.Release(list);
									if (type15 != null)
									{
										return type15.MakeArrayType();
									}
									return null;
								}
								_cachedArgs.Release(list);
								return type14 ?? context.GetType();
							}
							_cachedArgs.Release(list);
							if (((MethodInfo)value).ReturnType == typeof(object))
							{
								return FixNumberType(GetArrayVariableType(type14 ?? context.GetType(), false));
							}
							return FixNumberType(((MethodInfo)value).ReturnType);
						}
						value = ExtractMethod(type14 ?? context.GetType(), node, world, null, tempVar, list2, true, false, out objs);
						_cachedArgs.Release(list);
						if (value != null)
						{
							return FixNumberType(((MethodInfo)value).ReturnType);
						}
						throw new Exception("Failed finding function " + text2);
					}
					if (Functions.TryGetValue(text2, out value))
					{
						Type result2 = FixNumberType(((MethodInfo)value).ReturnType);
						_cachedArgs.Release(list);
						return result2;
					}
					value = ExtractMethod(world.GetType(), node, world, null, tempVar, list2, true, false, out objs);
					if (value != null)
					{
						_cachedArgs.Release(list);
						return FixNumberType(((MethodInfo)value).ReturnType);
					}
					Type typeFromName = world.GetTypeFromName(text2);
					if (typeFromName != null)
					{
						value = ExtractMethod(typeFromName, node, world, null, tempVar, list2, false, true, out objs);
						_cachedArgs.Release(list);
						if (value != null)
						{
							return FixNumberType(typeFromName);
						}
						throw new Exception("Failed finding constructor for " + text2);
					}
					_cachedArgs.Release(list);
					throw new Exception("Failed finding function " + text2);
				}
				case TokenType.Number:
					return typeof(double);
				case TokenType.String:
					return typeof(string);
				case TokenType.Bool:
					return typeof(bool);
				case TokenType.Variable:
				{
					string text3 = node.TokenItem.Value.ToString();
					if (context == null)
					{
						if (tempVar != null && tempVar.Name.Equals(text3))
						{
							return tempVar.Value;
						}
						object value2;
						if (world.TryGetVar(text3, out value2))
						{
							return value2 as Type;
						}
						object value3;
						if (Constants.TryGetValue(text3, out value3))
						{
							return value3.GetType();
						}
						Type variableType = GetVariableType(world, node, world.IsProtected(), false, allowReadOnly);
						if (variableType != null)
						{
							return variableType;
						}
						Type typeFromName2 = world.GetTypeFromName(text3);
						if (typeFromName2 != null)
						{
							return typeFromName2;
						}
						throw new Exception("Member not found " + text3);
					}
					return GetVariableType(context, node, world.IsProtected(), true, allowReadOnly);
				}
				case TokenType.GoInto:
					return SubGetType(node.Right, SubGetType(node.Left, context, world, tempVar), world, tempVar, allowReadOnly);
				case TokenType.Power:
				{
					Type type16 = SubGetType(node.Left, context, world, tempVar);
					Type type17 = SubGetType(node.Left, context, world, tempVar);
					Type typeFromHandle10 = typeof(double);
					if (type16 == typeFromHandle10 && type17 == typeFromHandle10)
					{
						return typeFromHandle10;
					}
					throw new Exception("Types do not match operator");
				}
				case TokenType.ArrayAccess:
					return GetArrayVariableType(SubGetType(node.Left, context, world, tempVar), true);
				case TokenType.If:
					if (!SubGetType(node.Left, context, world, tempVar).IsAssignableFrom(typeof(bool)))
					{
						throw new Exception("If statement not testing boolean value");
					}
					if (node.Right.TokenItem.Type == TokenType.Else)
					{
						SubGetType(node.Right.Right, context, world, tempVar);
						return SubGetType(node.Right.Left, context, world, tempVar);
					}
					return SubGetType(node.Right, context, world, tempVar);
				case TokenType.Block:
					return SubGetType(node.Right, context, world, tempVar);
				case TokenType.ArrayCreation:
					return SubGetType(GetFirst(node.Left, TokenType.Comma), context, world, tempVar).MakeArrayType();
				case TokenType.ForEach:
				{
					Type arrayVariableType = GetArrayVariableType(SubGetType(node.Left, context, world, tempVar), false);
					TempVarType tempVar2 = new TempVarType(node.TokenItem.Value.ToString(), arrayVariableType);
					return SubGetType(node.Right, context, world, tempVar2);
				}
				case TokenType.InlineIf:
				{
					Type type5 = SubGetType(node.Left, context, world, tempVar);
					if (!type5.IsAssignableFrom(typeof(bool)))
					{
						throw new Exception("Inline if not testing boolean value");
					}
					type5 = SubGetType(node.Children[2], context, world, tempVar);
					return SubGetType(node.Children[1], context, world, tempVar) ?? type5;
				}
				case TokenType.TypeIs:
					return typeof(bool);
				case TokenType.CreateVariable:
					world.SaveVar(node.TokenItem.Value.ToString(), null, true);
					return null;
				case TokenType.Assign:
				{
					Type type = SubGetType(node.Right, context, world, tempVar);
					if (node.Left.IsType(TokenType.CreateVariable))
					{
						string text = node.Left.TokenItem.Value.ToString();
						if (world.HasVar(text))
						{
							throw new Exception("Cannot declare existing variable: " + text);
						}
						world.SaveVar(text, type, true);
						return type;
					}
					SubGetType(node.Left, context, world, tempVar, false);
					return type;
				}
				default:
					return null;
				}
			}
			catch (LineParseException)
			{
				throw;
			}
			catch (Exception innerException)
			{
				while (innerException.InnerException != null)
				{
					innerException = innerException.InnerException;
				}
				string text4 = "";
				try
				{
					text4 = " - at " + WriteTree(GetNearestParent(node), 0, node);
				}
				catch
				{
				}
				throw new LineParseException(innerException.GetType().Name + ": " + innerException.Message + text4);
			}
		}

		private static Type GetObjectType(object obj)
		{
			return (obj as Type) ?? obj.GetType();
		}

		private static object GetArrayValue(object obj, object index)
		{
			IList list;
			if ((list = obj as IList) != null)
			{
				return list[Convert.ToInt32(index)];
			}
			IDictionary dictionary;
			if ((dictionary = obj as IDictionary) != null)
			{
				object key = ConvertValue(index, dictionary.GetType().GetGenericArguments()[0]);
				if (dictionary.Contains(key))
				{
					return dictionary[key];
				}
				throw new KeyNotFoundException();
			}
			IEnumerable enumerable;
			if ((enumerable = obj as IEnumerable) != null)
			{
				int num = Convert.ToInt32(index);
				if (num < 0)
				{
					throw new IndexOutOfRangeException();
				}
				int num2 = 0;
				foreach (object item in enumerable)
				{
					if (num2 == num)
					{
						return item;
					}
					num2++;
				}
				throw new IndexOutOfRangeException();
			}
			throw new Exception("Tried to index into non index variable");
		}

		private static bool SetArrayValue(object obj, object index, object value, Type t)
		{
			IList list;
			if ((list = obj as IList) != null)
			{
				list[Convert.ToInt32(index)] = ConvertValue(value, t);
				return true;
			}
			IDictionary dictionary;
			if ((dictionary = obj as IDictionary) != null)
			{
				dictionary[index] = ConvertValue(value, t);
				return true;
			}
			return false;
		}

		private static Type GetEnumerableType(object obj)
		{
			Type type = obj.GetType();
			if (obj.GetType().IsArray)
			{
				return obj.GetType().GetElementType();
			}
			if (type.IsGenericType && obj is IEnumerable)
			{
				if (!(obj is IDictionary))
				{
					return type.GetGenericArguments()[0];
				}
				return type.GetGenericArguments()[1];
			}
			return null;
		}

		private static object EnumIfEnum(Type left, TreeNode right, object context, ScriptWorld world, TempVar tempVar)
		{
			object obj = null;
			if (left != null && left.IsEnum && right.IsType(TokenType.Variable))
			{
				string text = right.TokenItem.Value.ToString();
				try
				{
					obj = Enum.Parse(left, text);
				}
				catch (Exception)
				{
					throw new Exception("Failed to parse enum " + left.Name + ": " + text);
				}
			}
			return obj ?? GetValue(ExecuteTree(right, context, world, tempVar));
		}

		private static object EnumIfEnum(object left, TreeNode right, object context, ScriptWorld world, TempVar tempVar)
		{
			object obj = null;
			if (left != null && right.IsType(TokenType.Variable))
			{
				Type type = left.GetType();
				if (type.IsEnum)
				{
					string text = right.TokenItem.Value.ToString();
					try
					{
						obj = Enum.Parse(type, text);
					}
					catch (Exception)
					{
						throw new Exception("Failed to parse enum " + type.Name + ": " + text);
					}
				}
			}
			return obj ?? GetValue(ExecuteTree(right, context, world, tempVar));
		}

		private static double? ExecuteTreeComparison(TreeNode node, object context, ScriptWorld world, bool fromLeft, TempVar tmp)
		{
			if (Comparisons.Contains(node.TokenItem.Type))
			{
				double? num = ExecuteTreeComparison(node.Left, context, world, true, tmp);
				double? num2 = ExecuteTreeComparison(node.Right, context, world, false, tmp);
				if (!num.HasValue || !num2.HasValue)
				{
					return null;
				}
				double? result = (fromLeft ? num2 : num);
				switch (node.TokenItem.Type)
				{
				case TokenType.Less:
					if (!(num.Value < num2.Value))
					{
						return null;
					}
					return result;
				case TokenType.LessEqual:
					if (!(num.Value <= num2.Value))
					{
						return null;
					}
					return result;
				case TokenType.Greater:
					if (!(num.Value > num2.Value))
					{
						return null;
					}
					return result;
				case TokenType.GreaterEqual:
					if (!(num.Value >= num2.Value))
					{
						return null;
					}
					return result;
				default:
					return null;
				}
			}
			object value;
			if ((value = GetValue(ExecuteTree(node, context, world, tmp))) is double)
			{
				return (double)value;
			}
			throw new Exception("Tried to compare non-numbers");
		}

		private static MethodBase ExtractMethod(Type t, TreeNode funcNode, ScriptWorld world, TempVar tmp, TempVarType tmp2, List<TreeNode> args, bool type, bool constructor, out object[] objs)
		{
			object[] args2 = PrePassArguments(args, world, tmp, tmp2, type);
			string value = funcNode.TokenItem.Value.ToString();
			if (funcNode.CachedMethod != null && funcNode.CachedMethod.ReflectedType == t)
			{
				if (type)
				{
					GetArgTypes(funcNode, args2, funcNode.CachedMethod, world, tmp2);
					objs = null;
				}
				else
				{
					objs = GetArgObjects(funcNode, args2, funcNode.CachedMethod, world, tmp);
				}
				return funcNode.CachedMethod;
			}
			lock (_elligableMethods)
			{
				_elligableMethods.Clear();
				objs = null;
				MethodBase[] array;
				if (!constructor)
				{
					MethodBase[] methods = t.GetMethods(GetBindings(world.IsProtected()));
					array = methods;
				}
				else
				{
					MethodBase[] methods = t.GetConstructors(GetBindings(world.IsProtected()));
					array = methods;
				}
				MethodBase[] array2 = array;
				foreach (MethodBase methodBase in array2)
				{
					if ((constructor || methodBase.Name.Equals(value)) && MatchArguments(methodBase, args))
					{
						_elligableMethods.Add(methodBase);
					}
				}
				if (_elligableMethods.Count == 1)
				{
					MethodBase methodBase2 = _elligableMethods[0];
					if (funcNode.CachedMethod != methodBase2)
					{
						funcNode.ClearCache();
					}
					if (type)
					{
						GetArgTypes(funcNode, args2, methodBase2, world, tmp2);
					}
					else
					{
						objs = GetArgObjects(funcNode, args2, methodBase2, world, tmp);
					}
					funcNode.CachedMethod = methodBase2;
					return methodBase2;
				}
				int num = -1;
				if (funcNode.CachedMethod != null)
				{
					for (int j = 0; j < _elligableMethods.Count; j++)
					{
						MethodBase methodBase3 = _elligableMethods[j];
						if (!(methodBase3 == funcNode.CachedMethod))
						{
							continue;
						}
						num = j;
						try
						{
							if (type)
							{
								GetArgTypes(funcNode, args2, methodBase3, world, tmp2);
							}
							else
							{
								objs = GetArgObjects(funcNode, args2, methodBase3, world, tmp);
							}
							return methodBase3;
						}
						catch (Exception)
						{
							funcNode.ClearCache();
						}
						break;
					}
				}
				for (int k = 0; k < _elligableMethods.Count; k++)
				{
					if (k == num)
					{
						continue;
					}
					MethodBase methodBase4 = _elligableMethods[k];
					try
					{
						if (type)
						{
							GetArgTypes(funcNode, args2, methodBase4, world, tmp2);
						}
						else
						{
							objs = GetArgObjects(funcNode, args2, methodBase4, world, tmp);
						}
						funcNode.CachedMethod = methodBase4;
						return methodBase4;
					}
					catch (Exception)
					{
						funcNode.ClearCache();
					}
				}
			}
			return null;
		}

		private static object[] PrePassArguments(List<TreeNode> args, ScriptWorld world, TempVar tmp, TempVarType tmp2, bool type)
		{
			if (args == null)
			{
				return null;
			}
			object[] array = new object[args.Count];
			for (int i = 0; i < args.Count; i++)
			{
				if (args[i].IsType(TokenType.Variable))
				{
					array[i] = args[i];
				}
				else
				{
					array[i] = (type ? SubGetType(args[i], null, world, tmp2) : GetValue(ExecuteTree(args[i], null, world, tmp)));
				}
			}
			return array;
		}

		private static object[] PrePassArguments(TreeNode node, List<TreeNode> args, object context, ScriptWorld world, TempVar tmp, MethodBase info)
		{
			if (args == null)
			{
				if (context != null)
				{
					return new object[1] { context };
				}
				return null;
			}
			object[] array = new object[args.Count + ((context != null) ? 1 : 0)];
			int num = 0;
			if (context != null)
			{
				array[0] = context;
				num++;
			}
			ParameterInfo[] array2;
			if (node.CachedParameters != null)
			{
				array2 = node.CachedParameters;
			}
			else
			{
				array2 = (node.CachedParameters = info.GetParameters());
				node.CachedParamArray = array2.Length != 0 && array2[array2.Length - 1].GetCustomAttributes(typeof(ParamArrayAttribute), false).Length != 0;
			}
			for (int i = 0; i < args.Count; i++)
			{
				array[num] = ((args[i].IsType(TokenType.Variable) || (num < array2.Length && array2[num].ParameterType == typeof(TreeNode))) ? args[i] : GetValue(ExecuteTree(args[i], null, world, tmp)));
				num++;
			}
			return array;
		}

		private static bool MatchArguments(MethodBase m, List<TreeNode> args)
		{
			ParameterInfo[] parameters = m.GetParameters();
			if (args == null)
			{
				if (parameters.Length == 0)
				{
					return true;
				}
				for (int i = 0; i < parameters.Length; i++)
				{
					if (parameters[i].ParameterType != typeof(ScriptWorld) && !parameters[i].IsOptional && (i < parameters.Length - 1 || parameters[i].GetCustomAttributes(typeof(ParamArrayAttribute), false).Length == 0))
					{
						return false;
					}
				}
			}
			else if (parameters.Length > args.Count)
			{
				for (int j = args.Count; j < parameters.Length; j++)
				{
					if (parameters[j].ParameterType != typeof(ScriptWorld) && !parameters[j].IsOptional && (j < parameters.Length - 1 || parameters[j].GetCustomAttributes(typeof(ParamArrayAttribute), false).Length == 0))
					{
						return false;
					}
				}
			}
			else if (args.Count > parameters.Length)
			{
				if (parameters.Length == 0)
				{
					return false;
				}
				if (parameters[parameters.Length - 1].GetCustomAttributes(typeof(ParamArrayAttribute), false).Length == 0)
				{
					return false;
				}
			}
			return true;
		}

		private static List<TreeNode> ParseArgs(TreeNode node, List<TreeNode> output)
		{
			if (node.Left == null)
			{
				return null;
			}
			Traverse(node.Left, TokenType.Comma, output);
			return output;
		}

		private static void GetArgTypes(TreeNode funcNode, object[] args, MethodBase m, ScriptWorld world, TempVarType tmp)
		{
			string text = funcNode.TokenItem.Value.ToString();
			if (args == null)
			{
				args = _emptyArgs;
			}
			bool flag = false;
			ParameterInfo[] array;
			if (funcNode.CachedParameters != null)
			{
				array = funcNode.CachedParameters;
				flag = funcNode.CachedParamArray;
			}
			else
			{
				array = m.GetParameters();
				flag = array.Length != 0 && array[array.Length - 1].GetCustomAttributes(typeof(ParamArrayAttribute), false).Length != 0;
				funcNode.CachedParameters = array;
				funcNode.CachedParamArray = flag;
			}
			for (int i = 0; i < array.Length; i++)
			{
				ParameterInfo parameterInfo = array[i];
				if (flag && i == array.Length - 1)
				{
					Type elementType = parameterInfo.ParameterType.GetElementType();
					for (int j = i; j < args.Length; j++)
					{
						Type c;
						if ((object)(c = args[j] as Type) != null && !FixNumberType(elementType).IsAssignableFrom(c))
						{
							throw new Exception(string.Format("Could not convert parameter {0} of {1} from '{2}' to {3}", i + 1, text, args[j], elementType.Name));
						}
					}
				}
				else
				{
					if (parameterInfo.ParameterType == typeof(ScriptWorld))
					{
						continue;
					}
					if (i >= args.Length)
					{
						if (!parameterInfo.IsOptional)
						{
							throw new Exception("Parameter length does not match for function " + text + ". Expected: " + string.Join(", ", array.Select((ParameterInfo x) => x.Name).ToArray()));
						}
					}
					else
					{
						if (parameterInfo.ParameterType == typeof(TreeNode))
						{
							continue;
						}
						TreeNode treeNode;
						Type c2;
						if ((treeNode = args[i] as TreeNode) != null)
						{
							if (!treeNode.IsType(TokenType.Variable) || !parameterInfo.ParameterType.IsEnum)
							{
								Type type = SubGetType(treeNode, null, world, tmp);
								if (type != null && !FixNumberType(parameterInfo.ParameterType).IsAssignableFrom(type))
								{
									throw new Exception(string.Format("Could not convert parameter {0} of {1} from '{2}' to {3}", i + 1, text, args[i], parameterInfo.ParameterType.Name));
								}
							}
						}
						else if ((object)(c2 = args[i] as Type) != null && !FixNumberType(parameterInfo.ParameterType).IsAssignableFrom(c2))
						{
							throw new Exception(string.Format("Could not convert parameter {0} of {1} from '{2}' to {3}", i + 1, text, args[i], parameterInfo.ParameterType.Name));
						}
					}
				}
			}
		}

		private static object[] GetArgObjects(TreeNode funcNode, object[] args, MethodBase m, ScriptWorld world, TempVar tmp)
		{
			string text = funcNode.TokenItem.Value.ToString();
			lock (_argumentObjects)
			{
				_argumentObjects.Clear();
				if (args == null)
				{
					args = _emptyArgs;
				}
				bool flag = false;
				ParameterInfo[] array;
				if (funcNode.CachedParameters != null)
				{
					array = funcNode.CachedParameters;
					flag = funcNode.CachedParamArray;
				}
				else
				{
					array = m.GetParameters();
					flag = array.Length != 0 && array[array.Length - 1].GetCustomAttributes(typeof(ParamArrayAttribute), false).Length != 0;
					funcNode.CachedParameters = array;
					funcNode.CachedParamArray = flag;
				}
				for (int i = 0; i < array.Length; i++)
				{
					ParameterInfo parameterInfo = array[i];
					TreeNode treeNode;
					if (flag && i == array.Length - 1)
					{
						Type elementType = parameterInfo.ParameterType.GetElementType();
						Array array2 = Array.CreateInstance(elementType, args.Length - i);
						for (int j = i; j < args.Length; j++)
						{
							try
							{
								array2.SetValue(ConvertValue(args[j], elementType), j - i);
							}
							catch (Exception)
							{
								throw new Exception(string.Format("Could not convert parameter {0} of {1} from '{2}' to {3}", i + 1, text, args[j], elementType.Name));
							}
						}
						_argumentObjects.Add(array2);
					}
					else if (parameterInfo.ParameterType == typeof(ScriptWorld))
					{
						_argumentObjects.Add(world);
					}
					else if (i >= args.Length)
					{
						if (!parameterInfo.IsOptional)
						{
							throw new Exception("Parameter length does not match for function " + text + ". Expected: " + string.Join(", ", array.Select((ParameterInfo x) => x.Name).ToArray()));
						}
						_argumentObjects.Add(parameterInfo.DefaultValue);
					}
					else if (parameterInfo.ParameterType == typeof(TreeNode))
					{
						_argumentObjects.Add(args[i]);
					}
					else if ((treeNode = args[i] as TreeNode) != null)
					{
						if (treeNode.IsType(TokenType.Variable) && parameterInfo.ParameterType.IsEnum)
						{
							_argumentObjects.Add(Enum.Parse(parameterInfo.ParameterType, treeNode.TokenItem.Value.ToString()));
							continue;
						}
						try
						{
							_argumentObjects.Add(ConvertValue(GetValue(ExecuteTree(treeNode, null, world, tmp)), parameterInfo.ParameterType));
						}
						catch (Exception)
						{
							throw new Exception(string.Format("Could not convert parameter {0} of {1} from '{2}' to {3}", i + 1, text, args[i], parameterInfo.ParameterType.Name));
						}
					}
					else
					{
						try
						{
							_argumentObjects.Add(ConvertValue(args[i], parameterInfo.ParameterType));
						}
						catch (Exception)
						{
							throw new Exception(string.Format("Could not convert parameter {0} of {1} from '{2}' to {3}", i + 1, text, args[i], parameterInfo.ParameterType.Name));
						}
					}
				}
				return _argumentObjects.ToArray();
			}
		}

		private static object ConvertValue(object input, Type type)
		{
			if (type == null)
			{
				return input;
			}
			if (input == null)
			{
				return null;
			}
			if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				type = type.GetGenericArguments()[0];
			}
			if (type == typeof(object))
			{
				return input;
			}
			if (type.IsInstanceOfType(input) || input.GetType().IsAssignableFrom(type))
			{
				return input;
			}
			if (type.IsEnum && input is string)
			{
				return Enum.Parse(type, input.ToString());
			}
			if (type.IsArray && input.GetType().IsArray)
			{
				return ConvertValues((object[])input, type.GetElementType());
			}
			if (!(input is string) && input is IEnumerable && typeof(IEnumerable).IsAssignableFrom(type))
			{
				return input;
			}
			if (type == typeof(bool) && !(input is bool))
			{
				throw new Exception("Cannot convert " + input.GetType().Name + " to boolean");
			}
			return Convert.ChangeType(input, type);
		}

		private static object ConvertValues(object[] input, Type type)
		{
			Array array = Array.CreateInstance(type, input.Length);
			for (int i = 0; i < input.Length; i++)
			{
				array.SetValue(ConvertValue(input[i], type), i);
			}
			return array;
		}

		private static bool SafeEquals(object o1, object o2)
		{
			if (o1 == null)
			{
				return o2 == null;
			}
			return o1.Equals(o2);
		}

		private static object GetValue(object input)
		{
			if (input == null)
			{
				return null;
			}
			VariableResult variableResult;
			if ((variableResult = input as VariableResult) != null)
			{
				object value = variableResult.GetValue();
				ClaimVariable(variableResult);
				return FixNumber(value);
			}
			return FixNumber(input);
		}

		private static object FixNumber(object input)
		{
			if (input is int || input is float || input is uint || input is byte)
			{
				return Convert.ToDouble(input);
			}
			return input;
		}

		private static VariableResult GetVariableValue(object obj, ScriptWorld world, TreeNode node, bool protect, bool throwOnError = true)
		{
			string text = node.TokenItem.Value.ToString();
			if (node.CachedField != null)
			{
				return _reflectionVarPool.Get().Set(obj, node.CachedField);
			}
			if (node.CachedProperty != null)
			{
				return _reflectionVarPool.Get().Set(obj, node.CachedProperty);
			}
			Type type = (obj as Type) ?? obj.GetType();
			if (world.IsRestricted(type))
			{
				throw new Exception(type.FullName + " is not accessible");
			}
			BindingFlags bindings = GetBindings(protect);
			MemberInfo memberRecursive = GetMemberRecursive(type, text, bindings, 3);
			FieldInfo fieldInfo;
			if ((object)(fieldInfo = memberRecursive as FieldInfo) != null)
			{
				node.CachedField = fieldInfo;
				return _reflectionVarPool.Get().Set(obj, fieldInfo);
			}
			PropertyInfo propertyInfo;
			if ((object)(propertyInfo = memberRecursive as PropertyInfo) != null)
			{
				node.CachedProperty = propertyInfo;
				return _reflectionVarPool.Get().Set(obj, propertyInfo);
			}
			if (throwOnError)
			{
				throw new Exception("Member not found " + text);
			}
			return null;
		}

		private static MemberInfo GetMemberRecursive(Type type, string name, BindingFlags bindings, int maxRecurse, int cur = 1)
		{
			if (type == null)
			{
				return null;
			}
			MemberInfo[] member = type.GetMember(name, bindings);
			if (member != null && member.Length != 0)
			{
				return member[0];
			}
			if (cur != maxRecurse)
			{
				return GetMemberRecursive(type.BaseType, name, bindings, maxRecurse, cur + 1);
			}
			return null;
		}

		private static Type FixNumberType(Type type)
		{
			if (!IsNumeric(type))
			{
				return type;
			}
			return typeof(double);
		}

		private static Type GetVariableType(object obj, TreeNode node, bool protect, bool throwOnError = true, bool allowReadOnly = true)
		{
			string text = node.TokenItem.Value.ToString();
			if (node.CachedField != null)
			{
				if (protect && !allowReadOnly && node.CachedField.IsInitOnly)
				{
					throw new Exception("Tried to write to readonly field: " + text);
				}
				return node.CachedField.FieldType;
			}
			if (node.CachedProperty != null)
			{
				return node.CachedProperty.PropertyType;
			}
			Type type = (obj as Type) ?? obj.GetType();
			Type typeFromHandle = typeof(object);
			if (type == typeFromHandle)
			{
				return typeFromHandle;
			}
			BindingFlags bindings = GetBindings(protect);
			FieldInfo field = type.GetField(text, bindings);
			if (field != null)
			{
				node.CachedField = field;
				if (protect && !allowReadOnly && node.CachedField.IsInitOnly)
				{
					throw new Exception("Tried to write to readonly field: " + text);
				}
				return FixNumberType(field.FieldType);
			}
			PropertyInfo property = type.GetProperty(text, bindings);
			if (property != null)
			{
				node.CachedProperty = property;
				return FixNumberType(property.PropertyType);
			}
			Type[] types = Assembly.GetAssembly(type).GetTypes();
			for (int i = 0; i < types.Length; i++)
			{
				if (types[i].BaseType == type)
				{
					Type variableType = GetVariableType(types[i], text, node, protect, types, allowReadOnly);
					if (variableType != null)
					{
						return variableType;
					}
				}
			}
			if (throwOnError)
			{
				throw new Exception("Member not found " + text);
			}
			return null;
		}

		private static Type GetVariableType(Type t, string name, TreeNode node, bool protect, Type[] types, bool allowReadOnly = true)
		{
			BindingFlags bindings = GetBindings(protect);
			FieldInfo field = t.GetField(name, bindings);
			if (field != null)
			{
				node.CachedField = field;
				if (protect && !allowReadOnly && node.CachedField.IsInitOnly)
				{
					throw new Exception("Tried to write to readonly field: " + name);
				}
				return FixNumberType(field.FieldType);
			}
			PropertyInfo property = t.GetProperty(name, bindings);
			if (property != null)
			{
				node.CachedProperty = property;
				return FixNumberType(property.PropertyType);
			}
			for (int i = 0; i < types.Length; i++)
			{
				if (types[i].BaseType == t)
				{
					Type variableType = GetVariableType(types[i], name, node, protect, types, allowReadOnly);
					if (variableType != null)
					{
						return variableType;
					}
				}
			}
			return null;
		}

		private static Type GetArrayVariableType(Type ft, bool onlyValue)
		{
			if (ft.IsArray)
			{
				ft = ft.GetElementType();
			}
			else if (ft.GetGenericTypeDefinition() == typeof(Dictionary<, >))
			{
				ft = ((!onlyValue) ? typeof(KeyValuePair<, >).MakeGenericType(ft.GetGenericArguments()) : ft.GetGenericArguments()[1]);
			}
			else if (ft.GetGenericTypeDefinition() == typeof(IEnumerable<>))
			{
				ft = ft.GetGenericArguments()[0];
			}
			else
			{
				Type type = ft.GetInterface("IEnumerable`1");
				if (type != null)
				{
					return type.GetGenericArguments()[0];
				}
			}
			return ft;
		}

		public static BindingFlags GetBindings(bool protect)
		{
			if (!protect)
			{
				return BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
			}
			return BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;
		}

		public static string InString(object obj)
		{
			return obj.ToString();
		}

		public static string FormatString(double obj, string format)
		{
			return obj.ToString(format);
		}

		public static bool Any(IEnumerable en, TreeNode tree, ScriptWorld world)
		{
			TempVar tempVar = new TempVar("x", null);
			IList list;
			if ((list = en as IList) != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if ((bool)GetValue(ExecuteTree(tree, null, world, tempVar.Val(list[i]))))
					{
						return true;
					}
				}
			}
			else
			{
				foreach (object item in en)
				{
					if ((bool)GetValue(ExecuteTree(tree, null, world, tempVar.Val(item))))
					{
						return true;
					}
				}
			}
			return false;
		}

		public static void ForEach(IEnumerable en, TreeNode tree, ScriptWorld world)
		{
			TempVar tempVar = new TempVar("x", null);
			IList list;
			if ((list = en as IList) != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					object value = list[i];
					ExecuteTree(tree, null, world, tempVar.Val(value));
				}
				return;
			}
			foreach (object item in en)
			{
				ExecuteTree(tree, null, world, tempVar.Val(item));
			}
		}

		public static IEnumerable Select(IEnumerable en, TreeNode tree, ScriptWorld world)
		{
			TempVar tmp = new TempVar("x", null);
			IList list;
			IList l = (list = en as IList);
			if (list != null)
			{
				for (int i = 0; i < l.Count; i++)
				{
					yield return GetValue(ExecuteTree(tree, null, world, tmp.Val(l[i])));
				}
				yield break;
			}
			foreach (object item in en)
			{
				yield return GetValue(ExecuteTree(tree, null, world, tmp.Val(item)));
			}
		}

		public static IEnumerable SelectMany(IEnumerable en, TreeNode tree, ScriptWorld world)
		{
			TempVar tmp = new TempVar("x", null);
			IList list;
			IList ll = (list = en as IList);
			if (list != null)
			{
				for (int i = 0; i < ll.Count; i++)
				{
					IEnumerable enumerable;
					if ((enumerable = GetValue(ExecuteTree(tree, null, world, tmp.Val(ll[i]))) as IEnumerable) == null)
					{
						continue;
					}
					foreach (object item in enumerable)
					{
						yield return item;
					}
				}
				yield break;
			}
			foreach (object item2 in en)
			{
				IEnumerable enumerable2;
				if ((enumerable2 = GetValue(ExecuteTree(tree, null, world, tmp.Val(item2))) as IEnumerable) == null)
				{
					continue;
				}
				foreach (object item3 in enumerable2)
				{
					yield return item3;
				}
			}
		}

		public static IEnumerable Where(IEnumerable en, TreeNode tree, ScriptWorld world)
		{
			TempVar tmp = new TempVar("x", null);
			IList list;
			IList l = (list = en as IList);
			if (list != null)
			{
				for (int i = 0; i < l.Count; i++)
				{
					object obj = l[i];
					if ((bool)GetValue(ExecuteTree(tree, null, world, tmp.Val(obj))))
					{
						yield return obj;
					}
				}
				yield break;
			}
			foreach (object item in en)
			{
				if ((bool)GetValue(ExecuteTree(tree, null, world, tmp.Val(item))))
				{
					yield return item;
				}
			}
		}

		public static IEnumerable<T> OfType<T>(IEnumerable en, Type t, ScriptWorld world)
		{
			IList list;
			IList l = (list = en as IList);
			if (list != null)
			{
				for (int i = 0; i < l.Count; i++)
				{
					object obj;
					if ((obj = l[i]) is T)
					{
						yield return (T)obj;
					}
				}
				yield break;
			}
			foreach (object item in en)
			{
				object obj;
				if ((obj = item) is T)
				{
					yield return (T)obj;
				}
			}
		}

		public static object FindFirst(IEnumerable en, TreeNode tree, ScriptWorld world)
		{
			TempVar tempVar = new TempVar("x", null);
			IList list;
			if ((list = en as IList) != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					object obj = list[i];
					if ((bool)GetValue(ExecuteTree(tree, null, world, tempVar.Val(obj))))
					{
						return obj;
					}
				}
			}
			else
			{
				foreach (object item in en)
				{
					if ((bool)GetValue(ExecuteTree(tree, null, world, tempVar.Val(item))))
					{
						return item;
					}
				}
			}
			return null;
		}

		public static int FindIndex(IEnumerable en, TreeNode tree, ScriptWorld world)
		{
			TempVar tempVar = new TempVar("x", null);
			IList list;
			if ((list = en as IList) != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					object value = list[i];
					if ((bool)GetValue(ExecuteTree(tree, null, world, tempVar.Val(value))))
					{
						return i;
					}
				}
			}
			else
			{
				int num = 0;
				foreach (object item in en)
				{
					if ((bool)GetValue(ExecuteTree(tree, null, world, tempVar.Val(item))))
					{
						return num;
					}
					num++;
				}
			}
			return -1;
		}

		public static object First(IEnumerable en)
		{
			IList list;
			if ((list = en as IList) != null)
			{
				if (list.Count <= 0)
				{
					return null;
				}
				return list[0];
			}
			IEnumerator enumerator = en.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					return enumerator.Current;
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return null;
		}

		public static object Last(IEnumerable en)
		{
			object result = null;
			IList list;
			if ((list = en as IList) != null)
			{
				if (list.Count <= 0)
				{
					return null;
				}
				return list[list.Count - 1];
			}
			foreach (object item in en)
			{
				result = item;
			}
			return result;
		}

		public static IEnumerable OrderBy(IEnumerable en, TreeNode tree, ScriptWorld world)
		{
			TempVar tmp = new TempVar("x", null);
			IEnumerable<KeyValuePair<object, object>> source = from object x in en
				select new KeyValuePair<object, object>(x, GetValue(ExecuteTree(tree, null, world, tmp.Val(x))));
			foreach (KeyValuePair<object, object> item in source.OrderBy((KeyValuePair<object, object> x) => x.Value))
			{
				yield return item.Key;
			}
		}

		public static IEnumerable OrderByDescending(IEnumerable en, TreeNode tree, ScriptWorld world)
		{
			TempVar tmp = new TempVar("x", null);
			IEnumerable<KeyValuePair<object, object>> source = from object x in en
				select new KeyValuePair<object, object>(x, GetValue(ExecuteTree(tree, null, world, tmp.Val(x))));
			foreach (KeyValuePair<object, object> item in source.OrderByDescending((KeyValuePair<object, object> x) => x.Value))
			{
				yield return item.Key;
			}
		}

		public static object[] Distinct(IEnumerable en)
		{
			HashSet<object> hashSet = new HashSet<object>();
			IList list;
			if ((list = en as IList) != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					hashSet.Add(list[i]);
				}
			}
			else
			{
				foreach (object item in en)
				{
					hashSet.Add(item);
				}
			}
			return hashSet.ToArray();
		}

		public static object[] Duplicates(IEnumerable en)
		{
			HashSet<object> hashSet = new HashSet<object>();
			HashSet<object> hashSet2 = new HashSet<object>();
			IList list;
			if ((list = en as IList) != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (!hashSet.Add(list[i]))
					{
						hashSet2.Add(list[i]);
					}
				}
			}
			else
			{
				foreach (object item in en)
				{
					if (!hashSet.Add(item))
					{
						hashSet2.Add(item);
					}
				}
			}
			return hashSet2.ToArray();
		}

		public static int Count(IEnumerable en, TreeNode tree, ScriptWorld world)
		{
			int num = 0;
			TempVar tempVar = new TempVar("x", null);
			IList list;
			if ((list = en as IList) != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if ((bool)GetValue(ExecuteTree(tree, null, world, tempVar.Val(list[i]))))
					{
						num++;
					}
				}
			}
			else
			{
				foreach (object item in en)
				{
					if ((bool)GetValue(ExecuteTree(tree, null, world, tempVar.Val(item))))
					{
						num++;
					}
				}
			}
			return num;
		}

		public static int Size(IEnumerable en)
		{
			int num = 0;
			IList list;
			if ((list = en as IList) != null)
			{
				return list.Count;
			}
			foreach (object item in en)
			{
				object obj = item;
				num++;
			}
			return num;
		}

		public static bool All(IEnumerable en, TreeNode tree, ScriptWorld world)
		{
			TempVar tempVar = new TempVar("x", null);
			IList list;
			if ((list = en as IList) != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (!(bool)GetValue(ExecuteTree(tree, null, world, tempVar.Val(list[i]))))
					{
						return false;
					}
				}
			}
			else
			{
				foreach (object item in en)
				{
					if (!(bool)GetValue(ExecuteTree(tree, null, world, tempVar.Val(item))))
					{
						return false;
					}
				}
			}
			return true;
		}

		public static bool AnyAndAll(IEnumerable en, TreeNode tree, ScriptWorld world)
		{
			TempVar tempVar = new TempVar("x", null);
			bool result = false;
			IList list;
			if ((list = en as IList) != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					result = true;
					if (!(bool)GetValue(ExecuteTree(tree, null, world, tempVar.Val(list[i]))))
					{
						return false;
					}
				}
			}
			else
			{
				foreach (object item in en)
				{
					result = true;
					if (!(bool)GetValue(ExecuteTree(tree, null, world, tempVar.Val(item))))
					{
						return false;
					}
				}
			}
			return result;
		}

		public static bool None(IEnumerable en, TreeNode tree, ScriptWorld world)
		{
			TempVar tempVar = new TempVar("x", null);
			IList list;
			if ((list = en as IList) != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if ((bool)GetValue(ExecuteTree(tree, null, world, tempVar.Val(list[i]))))
					{
						return false;
					}
				}
			}
			else
			{
				foreach (object item in en)
				{
					if ((bool)GetValue(ExecuteTree(tree, null, world, tempVar.Val(item))))
					{
						return false;
					}
				}
			}
			return true;
		}

		public static double Sum(IEnumerable en, TreeNode tree, ScriptWorld world)
		{
			TempVar tempVar = new TempVar("x", null);
			double num = 0.0;
			IList list;
			if ((list = en as IList) != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					num += (double)GetValue(ExecuteTree(tree, null, world, tempVar.Val(list[i])));
				}
			}
			else
			{
				foreach (object item in en)
				{
					num += (double)GetValue(ExecuteTree(tree, null, world, tempVar.Val(item)));
				}
			}
			return num;
		}

		public static double Max(IEnumerable en, TreeNode tree, ScriptWorld world)
		{
			TempVar tempVar = new TempVar("x", null);
			double num = double.MinValue;
			bool flag = false;
			IList list;
			if ((list = en as IList) != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					flag = true;
					double num2 = (double)GetValue(ExecuteTree(tree, null, world, tempVar.Val(list[i])));
					if (num2 > num)
					{
						num = num2;
					}
				}
			}
			else
			{
				foreach (object item in en)
				{
					flag = true;
					double num3 = (double)GetValue(ExecuteTree(tree, null, world, tempVar.Val(item)));
					if (num3 > num)
					{
						num = num3;
					}
				}
			}
			if (!flag)
			{
				return 0.0;
			}
			return num;
		}

		public static double Min(IEnumerable en, TreeNode tree, ScriptWorld world)
		{
			TempVar tempVar = new TempVar("x", null);
			double num = double.MaxValue;
			bool flag = false;
			IList list;
			if ((list = en as IList) != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					flag = true;
					double num2 = (double)GetValue(ExecuteTree(tree, null, world, tempVar.Val(list[i])));
					if (num2 < num)
					{
						num = num2;
					}
				}
			}
			else
			{
				foreach (object item in en)
				{
					flag = true;
					double num3 = (double)GetValue(ExecuteTree(tree, null, world, tempVar.Val(item)));
					if (num3 < num)
					{
						num = num3;
					}
				}
			}
			if (!flag)
			{
				return 0.0;
			}
			return num;
		}

		public static double Average(IEnumerable en, TreeNode tree, ScriptWorld world)
		{
			TempVar tempVar = new TempVar("x", null);
			double num = 0.0;
			int num2 = 0;
			IList list;
			if ((list = en as IList) != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					num += (double)GetValue(ExecuteTree(tree, null, world, tempVar.Val(list[i])));
					num2++;
				}
			}
			else
			{
				foreach (object item in en)
				{
					num += (double)GetValue(ExecuteTree(tree, null, world, tempVar.Val(item)));
					num2++;
				}
			}
			if (num2 <= 0)
			{
				return 0.0;
			}
			return num / (double)num2;
		}

		public static object GetRandomElement(IEnumerable en)
		{
			List<object> list = en.OfType<object>().ToList();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[RandomInteger(0, list.Count)];
		}

		public static void Debug(object msg)
		{
			UnityEngine.Debug.Log(msg.ToString());
		}

		public static double Random()
		{
			return _rnd.NextDouble();
		}

		public static double RandomRange(double min, double max)
		{
			return min + _rnd.NextDouble() * (max - min);
		}

		public static int RandomInteger(int min, int max)
		{
			return _rnd.Next(min, max);
		}

		public static double Lerp(double a, double b, double t)
		{
			return a * (1.0 - t) + b * t;
		}

		public static double Clamp(double val, double min, double max)
		{
			if (val < min)
			{
				return min;
			}
			if (val > max)
			{
				return max;
			}
			return val;
		}

		public static double Clamp01(double val)
		{
			return Clamp(val, 0.0, 1.0);
		}
	}
}
