using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GptDeepResearch
{
	// Exception used to handle return values from functions
	public class ReturnException : Exception
	{
		public object Value;
		public ReturnException(object value)
		{
			Value = value;
		}
	}

	// Add after ReturnException class (around line 15)
	public class BreakException : Exception { }
	public class ContinueException : Exception { }



	// The interpreter evaluates the AST using coroutine-based execution
	public class PythonInterpreter
	{
		private Dictionary<string, object> Globals = new Dictionary<string, object>();
		private Dictionary<string, FunctionDefStmt> Functions = new Dictionary<string, FunctionDefStmt>();
		private Stack<Dictionary<string, object>> LocalsStack = new Stack<Dictionary<string, object>>();
		private Stack<HashSet<string>> GlobalDeclsStack = new Stack<HashSet<string>>(); // Add this line

		// Add new field for storing builtin functions (around line 25):
		private Dictionary<string, BuiltinFunctionValue> BuiltinFunctions = new Dictionary<string, BuiltinFunctionValue>();
		private Dictionary<string, ClassValue> Classes = new Dictionary<string, ClassValue>();

		public PythonInterpreter()
		{
			// No special built-in initialization needed here before
			InitializeBuiltinFunctions();
		}

		/// <summary>
		/// Initialize builtin functions with proper arity information
		/// </summary>
		private void InitializeBuiltinFunctions()
		{
			// Core builtin functions
			BuiltinFunctions["v2"] = new BuiltinFunctionValue("v2", 2, (args) => {
				if (args.Length != 2)
					throw new Exception($"v2() takes exactly 2 arguments ({args.Length} given)");
				double x = NumericHelpers.ToDouble(args[0]);
				double y = NumericHelpers.ToDouble(args[1]);
				return new V2Value(x, y);
			});

			// Zero-arg builtin functions that should be auto-called
			BuiltinFunctions["get_pos"] = new BuiltinFunctionValue("get_pos", 0, (args) => {
				// This will be overridden by GameBuiltinMethods, but provide a default
				return new V2Value(0, 0);
			});

			BuiltinFunctions["get_goal"] = new BuiltinFunctionValue("get_goal", 0, (args) => {
				return new V2Value(0, 0);
			});
		}


		// Main entry: execute a list of statements
		public IEnumerator Execute(List<Stmt> statements)
		{
			// Reset iteration counter at start of execution
			ExecutionTracker.ResetIterationCounter();

			foreach (Stmt stmt in statements)
			{
				IEnumerator stmtEnum = ExecStmt(stmt);
				while (stmtEnum.MoveNext())
				{
					yield return stmtEnum.Current;
				}
				// Batched step delay - only yield when batch threshold reached
				if (ExecutionTracker.ShouldYieldForBatch())
				{
					yield return null;
				}
			}
		}

		// Update ExecStmt method to handle GlobalStmt:
		// MODIFY ExecStmt method - ADD line execution notification to each statement type:
		private IEnumerator ExecStmt(Stmt stmt)
		{
			// ADD: Notify line execution at the beginning of each statement
			// ADD: Notify line execution at the beginning of each statement
			ExecutionTracker.NotifyLineExecution(stmt.Line);

			if (stmt is ExpressionStmt es)
			{
				// Evaluate expression and discard result (for side-effects)
				object value = null;
				IEnumerator exprEnum = ExecExpr(es.Expression, val => value = val);
				while (exprEnum.MoveNext())
				{
					yield return exprEnum.Current;
				}
			}
			else if (stmt is AssignStmt asg)
			{
				object value = null;
				IEnumerator exprEnum = ExecExpr(asg.Value, val => value = val);
				while (exprEnum.MoveNext())
				{
					yield return exprEnum.Current;
				}
				SetVariable(asg.Target, value);
			}
			// ADD this new case after AssignStmt:
			else if (stmt is InPlaceAssignStmt ipas)
			{
				// Get current value of variable
				object currentValue = null;
				if (!GetVariable(ipas.Target, out currentValue))
				{
					throw new Exception($"Name '{ipas.Target}' is not defined at line {ipas.Line}");
				}

				// Evaluate the right-hand side
				object rightValue = null;
				IEnumerator exprEnum = ExecExpr(ipas.Value, val => rightValue = val);
				while (exprEnum.MoveNext())
				{
					yield return exprEnum.Current;
				}

				// Perform the in-place operation
				// MODIFY in-place assignment operations in ExecStmt InPlaceAssignStmt case (around line 85):
				// Perform the in-place operation with better type handling
				// MODIFY in-place assignment operations in ExecStmt InPlaceAssignStmt case (around line 85):
				// Perform the in-place operation with better type handling
				object result = null;
				switch (ipas.Op)
				{
					case TokenType.PLUS_ASSIGN:
						if (currentValue is string || rightValue is string)
						{
							result = currentValue.ToString() + rightValue.ToString();
						}
						else if (IsNumeric(currentValue) && IsNumeric(rightValue))
						{
							result = Convert.ToDouble(currentValue) + Convert.ToDouble(rightValue);
						}
						else
						{
							throw new Exception($"Cannot perform += on {currentValue?.GetType()} and {rightValue?.GetType()} at line {ipas.Line}");
						}
						break;
					case TokenType.MINUS_ASSIGN:
						if (IsNumeric(currentValue) && IsNumeric(rightValue))
						{
							result = Convert.ToDouble(currentValue) - Convert.ToDouble(rightValue);
						}
						else
						{
							throw new Exception($"Cannot perform -= on {currentValue?.GetType()} and {rightValue?.GetType()} at line {ipas.Line}");
						}
						break;
					case TokenType.STAR_ASSIGN:
						// Handle string multiplication assignment
						if (currentValue is string str && IsNumeric(rightValue))
						{
							int times = Convert.ToInt32(rightValue);
							if (times < 0) times = 0;
							System.Text.StringBuilder sb = new System.Text.StringBuilder();
							for (int i = 0; i < times; i++)
								sb.Append(str);
							result = sb.ToString();
						}
						else if (IsNumeric(currentValue) && IsNumeric(rightValue))
						{
							result = Convert.ToDouble(currentValue) * Convert.ToDouble(rightValue);
						}
						else
						{
							throw new Exception($"Cannot perform *= on {currentValue?.GetType()} and {rightValue?.GetType()} at line {ipas.Line}");
						}
						break;
					case TokenType.SLASH_ASSIGN:
						if (IsNumeric(currentValue) && IsNumeric(rightValue))
						{
							double divisor = Convert.ToDouble(rightValue);
							if (divisor == 0)
								throw new Exception($"Division by zero in /= at line {ipas.Line}");
							result = Convert.ToDouble(currentValue) / divisor;
						}
						else
						{
							throw new Exception($"Cannot perform /= on {currentValue?.GetType()} and {rightValue?.GetType()} at line {ipas.Line}");
						}
						break;
					default:
						throw new Exception($"Unsupported in-place operator {ipas.Op} at line {ipas.Line}");
				}

				SetVariable(ipas.Target, result);
			}
			// modify PythonInterpreter.cs

			// Add this case in ExecStmt method after InPlaceAssignStmt (around line 130):
			else if (stmt is AttributeAssignStmt attrAssign)
			{
				// Evaluate the target object
				object targetObj = null;
				IEnumerator targetEnum = ExecExpr(attrAssign.Target, val => targetObj = val);
				while (targetEnum.MoveNext())
				{
					yield return targetEnum.Current;
				}

				// Evaluate the value to assign
				object value = null;
				IEnumerator valueEnum = ExecExpr(attrAssign.Value, val => value = val);
				while (valueEnum.MoveNext())
				{
					yield return valueEnum.Current;
				}

				// Set the attribute
				SetAttribute(targetObj, attrAssign.Attribute, value);
			}
			// Add this case after AttributeAssignStmt in ExecStmt:
			else if (stmt is IndexAssignStmt indexAssign)
			{
				// Evaluate the target object
				object targetObj = null;
				IEnumerator targetEnum = ExecExpr(indexAssign.Target, val => targetObj = val);
				while (targetEnum.MoveNext())
				{
					yield return targetEnum.Current;
				}

				// Evaluate the index
				object indexVal = null;
				IEnumerator indexEnum = ExecExpr(indexAssign.Index, val => indexVal = val);
				while (indexEnum.MoveNext())
				{
					yield return indexEnum.Current;
				}

				// Evaluate the value to assign
				object value = null;
				IEnumerator valueEnum = ExecExpr(indexAssign.Value, val => value = val);
				while (valueEnum.MoveNext())
				{
					yield return valueEnum.Current;
				}

				// Set the indexed value
				if (targetObj is DictValue dictObj)
				{
					dictObj.SetItem(indexVal, value);
				}
				else if (targetObj is List<object> listObj)
				{
					int idx = Convert.ToInt32(indexVal);
					if (idx < 0) idx = listObj.Count + idx;
					if (idx < 0 || idx >= listObj.Count)
						throw new Exception($"list index out of range at line {indexAssign.Line}");
					listObj[idx] = value;
				}
				else
				{
					throw new Exception($"'{targetObj?.GetType().Name}' object is not subscriptable at line {indexAssign.Line}");
				}
			}

			else if (stmt is GlobalStmt gs)
			{
				if (GlobalDeclsStack.Count > 0)
				{
					var globalDecls = GlobalDeclsStack.Peek();
					foreach (string name in gs.Names)
					{
						globalDecls.Add(name);
					}
				}
			}
			// Add new ExecStmt case for ClassDefStmt (around line 160):
			else if (stmt is ClassDefStmt classDef)
			{
				// Store class definition
				var classValue = new ClassValue(classDef.Name, classDef.Body, classDef.Docstring);

				// Process methods in the class body
				foreach (var bodyStmt in classDef.Body)
				{
					if (bodyStmt is FunctionDefStmt methodDef)
					{
						classValue.Methods[methodDef.Name] = methodDef;
					}
				}

				Classes[classDef.Name] = classValue;
			}

			else if (stmt is IfStmt ifs)
			{
				object cond = null;
				IEnumerator condEnum = ExecExpr(ifs.Condition, val => cond = val);
				while (condEnum.MoveNext())
				{
					yield return condEnum.Current;
				}
				if (IsTrue(cond))
				{
					if (ifs.ThenBranch != null)
					{
						foreach (Stmt inner in ifs.ThenBranch)
						{
							IEnumerator innerEnum = ExecStmt(inner);
							while (innerEnum.MoveNext())
							{
								yield return innerEnum.Current;
							}
						}
					}
				}
				else if (ifs.ElseBranch != null)
				{
					foreach (Stmt inner in ifs.ElseBranch)
					{
						IEnumerator innerEnum = ExecStmt(inner);
						while (innerEnum.MoveNext())
						{
							yield return innerEnum.Current;
						}
					}
				}
			}
			//replace - Replace while loop in WhileStmt case to use batched delays
			else if (stmt is WhileStmt ws)
			{
				while (true)
				{
					object cond = null;
					var condEnum = ExecExpr(ws.Condition, v => cond = v);
					while (condEnum.MoveNext()) yield return condEnum.Current;
					if (!IsTrue(cond)) break;

					bool shouldBreak = false;
					bool shouldContinue = false;

					foreach (var s in ws.Body)
					{
						var innerEnum = ExecStmt(s);

						// Execute the statement and handle exceptions
						while (true)
						{
							object current = null;
							bool hasNext = false;
							bool gotException = false;

							try
							{
								hasNext = innerEnum.MoveNext();
								if (hasNext)
									current = innerEnum.Current;
							}
							catch (BreakException)
							{
								shouldBreak = true;
								gotException = true;
							}
							catch (ContinueException)
							{
								shouldContinue = true;
								gotException = true;
							}

							if (gotException) break;
							if (!hasNext) break;

							yield return current;
						}

						if (shouldBreak || shouldContinue) break;
					}

					if (shouldBreak) break;
					if (shouldContinue) continue;

					// Use batched step delay instead of every iteration
					if (ExecutionTracker.ShouldYieldForBatch())
					{
						yield return null;
					}
				}
			}
			//replace - Replace for loop in ForStmt case to use batched delays
			else if (stmt is ForStmt fs)
			{
				// Evaluate the iterable
				object iterableObj = null;
				IEnumerator iterEnum = ExecExpr(fs.Iterable, val => iterableObj = val);
				while (iterEnum.MoveNext())
					yield return iterEnum.Current;

				// Check if the object is iterable
				if (iterableObj is List<object> list)
				{
					// Iterate over each item in the list
					foreach (object item in list)
					{
						// Set the loop variable
						SetVariable(fs.Variable, item);

						bool shouldBreak = false;
						bool shouldContinue = false;

						// Execute the loop body
						foreach (Stmt bodyStmt in fs.Body)
						{
							var bodyEnum = ExecStmt(bodyStmt);

							// Execute and handle exceptions
							while (true)
							{
								object current = null;
								bool hasNext = false;
								bool gotException = false;

								try
								{
									hasNext = bodyEnum.MoveNext();
									if (hasNext)
										current = bodyEnum.Current;
								}
								catch (BreakException)
								{
									shouldBreak = true;
									gotException = true;
								}
								catch (ContinueException)
								{
									shouldContinue = true;
									gotException = true;
								}

								if (gotException) break;
								if (!hasNext) break;

								yield return current;
							}

							if (shouldBreak || shouldContinue) break;
						}

						if (shouldBreak) break;
						if (shouldContinue) continue;

						// Use batched step delay instead of every iteration
						if (ExecutionTracker.ShouldYieldForBatch())
						{
							yield return null;
						}
					}
				}
				else if (iterableObj is string str)
				{
					// Iterate over each character in the string
					foreach (char c in str)
					{
						SetVariable(fs.Variable, c.ToString());

						bool shouldBreak = false;
						bool shouldContinue = false;

						foreach (Stmt bodyStmt in fs.Body)
						{
							var bodyEnum = ExecStmt(bodyStmt);

							// Execute and handle exceptions
							while (true)
							{
								object current = null;
								bool hasNext = false;
								bool gotException = false;

								try
								{
									hasNext = bodyEnum.MoveNext();
									if (hasNext)
										current = bodyEnum.Current;
								}
								catch (BreakException)
								{
									shouldBreak = true;
									gotException = true;
								}
								catch (ContinueException)
								{
									shouldContinue = true;
									gotException = true;
								}

								if (gotException) break;
								if (!hasNext) break;

								yield return current;
							}

							if (shouldBreak || shouldContinue) break;
						}

						if (shouldBreak) break;
						if (shouldContinue) continue;

						// Use batched step delay instead of every iteration
						if (ExecutionTracker.ShouldYieldForBatch())
						{
							yield return null;
						}
					}
				}
				else
				{
					throw new Exception($"Object of type '{iterableObj?.GetType().Name}' is not iterable at line {fs.Line}");
				}
			}
			else if (stmt is FunctionDefStmt fdef)
			{
				// Store function definition for later calls
				Functions[fdef.Name] = fdef;
			}
			else if (stmt is ReturnStmt ret)
			{
				object returnValue = null;
				if (ret.Value != null)
				{
					IEnumerator exprEnum = ExecExpr(ret.Value, val => returnValue = val);
					while (exprEnum.MoveNext())
					{
						yield return exprEnum.Current;
					}
				}
				throw new ReturnException(returnValue);
			}
			else if (stmt is PassStmt)
			{
				// Do nothing
			}
			// ADD after PassStmt case in ExecStmt method
			else if (stmt is BreakStmt)
			{
				throw new BreakException();
			}
			else if (stmt is ContinueStmt)
			{
				throw new ContinueException();
			}
			else
			{
				Debug.Log($"instead of throw new Exception: Unknown statement type at line {stmt.Line}");
				yield break;
			}
		}


		private IEnumerator ExecExpr(Expr expr, Action<object> setValue)
		{
			if (expr is NumberExpr ne)
			{
				setValue(ne.Value);
			}
			else if (expr is StringExpr se)
			{
				setValue(se.Value);
			}
			else if (expr is BooleanExpr booe)
			{
				setValue(booe.Value);
			}
			// Update NameExpr handling in ExecExpr to support auto-call (around line 380):
			else if (expr is NameExpr nae)
			{
				string name = nae.Name;
				object val;

				// First check if it's a builtin function
				if (BuiltinFunctions.ContainsKey(name))
				{
					var builtinFunc = BuiltinFunctions[name];
					// Auto-call zero-argument builtin functions
					if (builtinFunc.Arity == 0 && builtinFunc.IsSync)
					{
						val = builtinFunc.SyncInvoke(new object[0]);
					}
					else
					{
						// Return the function object itself for non-zero arity
						val = builtinFunc;
					}
				}
				// Check if it's a class name
				else if (Classes.ContainsKey(name))
				{
					val = Classes[name];
				}
				// Check regular variables
				else if (GetVariable(name, out val))
				{
					// Variable found
				}
				else
				{
					throw new Exception($"Name '{name}' is not defined at line {nae.Line}");
				}

				setValue(val);
			}
			else if (expr is ListExpr le)
			{
				List<object> list = new List<object>();
				foreach (Expr el in le.Elements)
				{
					object elemVal = null;
					IEnumerator elemEnum = ExecExpr(el, val => elemVal = val);
					while (elemEnum.MoveNext())
					{
						yield return elemEnum.Current;
					}
					list.Add(elemVal);
				}
				setValue(list);
			}
			// ADD new case in ExecExpr method after ListExpr case (around line 420 in PythonInterpreter.cs)
			else if (expr is DictExpr de)
			{
				DictValue dict = new DictValue();
				foreach (var pair in de.Pairs)
				{
					object keyVal = null;
					IEnumerator keyEnum = ExecExpr(pair.Key, val => keyVal = val);
					while (keyEnum.MoveNext())
					{
						yield return keyEnum.Current;
					}

					object valueVal = null;
					IEnumerator valueEnum = ExecExpr(pair.Value, val => valueVal = val);
					while (valueEnum.MoveNext())
					{
						yield return valueEnum.Current;
					}

					dict.SetItem(keyVal, valueVal);
				}
				setValue(dict);
			}
			else if (expr is BinaryExpr be)
			{
				object result = null;

				// Handle short-circuiting boolean operators first
				if (be.Op == TokenType.AND)
				{
					object leftVal_and = null;
					IEnumerator leftEnum_and = ExecExpr(be.Left, val => leftVal_and = val);
					while (leftEnum_and.MoveNext())
					{
						yield return leftEnum_and.Current;
					}

					// Short-circuit: if left is false, don't evaluate right
					if (!IsTrue(leftVal_and))
					{
						result = false;
					}
					else
					{
						object rightVal_and = null;
						IEnumerator rightEnum_and = ExecExpr(be.Right, val => rightVal_and = val);
						while (rightEnum_and.MoveNext())
						{
							yield return rightEnum_and.Current;
						}
						result = IsTrue(rightVal_and);
					}
					setValue(result);
					yield break;
				}
				else if (be.Op == TokenType.OR)
				{
					object leftVal_or = null;
					IEnumerator leftEnum_or = ExecExpr(be.Left, val => leftVal_or = val);
					while (leftEnum_or.MoveNext())
					{
						yield return leftEnum_or.Current;
					}

					// Short-circuit: if left is true, don't evaluate right
					if (IsTrue(leftVal_or))
					{
						result = true;
					}
					else
					{
						object rightVal_or = null;
						IEnumerator rightEnum_or = ExecExpr(be.Right, val => rightVal_or = val);
						while (rightEnum_or.MoveNext())
						{
							yield return rightEnum_or.Current;
						}
						result = IsTrue(rightVal_or);
					}
					setValue(result);
					yield break;
				}

				// For all other operators, evaluate both operands first
				object leftVal = null;
				IEnumerator leftEnum = ExecExpr(be.Left, val => leftVal = val);
				while (leftEnum.MoveNext())
				{
					yield return leftEnum.Current;
				}
				object rightVal = null;
				IEnumerator rightEnum = ExecExpr(be.Right, val => rightVal = val);
				while (rightEnum.MoveNext())
				{
					yield return rightEnum.Current;
				}

				switch (be.Op)
				{
					// Existing arithmetic operators
					case TokenType.PLUS:
						if (leftVal is V2Value leftV2 && rightVal is V2Value rightV2)
						{
							result = leftV2 + rightV2;
						}
						else if (leftVal is V2Value leftV2_list && rightVal is List<object> rightList)
						{
							// Convert list to V2Value and add
							V2Value rightV2_converted = V2Value.FromList(rightList);
							result = leftV2_list + rightV2_converted;
						}
						else if (leftVal is List<object> leftList && rightVal is V2Value rightV2_list)
						{
							// Convert list to V2Value and add
							V2Value leftV2_converted = V2Value.FromList(leftList);
							result = leftV2_converted + rightV2_list;
						}
						else if (leftVal is string || rightVal is string)
						{
							result = leftVal.ToString() + rightVal.ToString();
						}
						else if (IsNumeric(leftVal) && IsNumeric(rightVal))
						{
							result = Convert.ToDouble(leftVal) + Convert.ToDouble(rightVal);
						}
						else
						{
							throw new Exception($"Cannot add {leftVal?.GetType()} and {rightVal?.GetType()} at line {be.Line}");
						}
						break;
					case TokenType.MINUS:
						// Handle V2Value subtraction
						if (leftVal is V2Value leftV2_sub && rightVal is V2Value rightV2_sub)
						{
							result = leftV2_sub - rightV2_sub;
						}
						else if (leftVal is V2Value leftV2_list_sub && rightVal is List<object> rightList_sub)
						{
							V2Value rightV2_converted_sub = V2Value.FromList(rightList_sub);
							result = leftV2_list_sub - rightV2_converted_sub;
						}
						else if (leftVal is List<object> leftList_sub && rightVal is V2Value rightV2_list_sub)
						{
							V2Value leftV2_converted_sub = V2Value.FromList(leftList_sub);
							result = leftV2_converted_sub - rightV2_list_sub;
						}
						else if (IsNumeric(leftVal) && IsNumeric(rightVal))
						{
							result = Convert.ToDouble(leftVal) - Convert.ToDouble(rightVal);
						}
						else
						{
							throw new Exception($"Cannot subtract {rightVal?.GetType()} from {leftVal?.GetType()} at line {be.Line}");
						}
						break;
					// MODIFY the TokenType.STAR case in the BinaryExpr section of ExecExpr method
					// Replace the existing STAR case with:

					case TokenType.STAR:
						// Handle V2Value scalar multiplication
						if (leftVal is V2Value leftV2_mul && IsNumeric(rightVal))
						{
							double scalar = Convert.ToDouble(rightVal);
							result = new V2Value(leftV2_mul.X * scalar, leftV2_mul.Y * scalar);
						}
						else if (IsNumeric(leftVal) && rightVal is V2Value rightV2_mul)
						{
							double scalar = Convert.ToDouble(leftVal);
							result = new V2Value(rightV2_mul.X * scalar, rightV2_mul.Y * scalar);
						}
						// Handle string multiplication (Python-style)
						else if (leftVal is string str && IsNumeric(rightVal))
						{
							int times = Convert.ToInt32(rightVal);
							if (times < 0) times = 0;
							System.Text.StringBuilder sb = new System.Text.StringBuilder();
							for (int i = 0; i < times; i++)
								sb.Append(str);
							result = sb.ToString();
						}
						else if (IsNumeric(leftVal) && rightVal is string str2)
						{
							int times = Convert.ToInt32(leftVal);
							if (times < 0) times = 0;
							System.Text.StringBuilder sb = new System.Text.StringBuilder();
							for (int i = 0; i < times; i++)
								sb.Append(str2);
							result = sb.ToString();
						}

						else if (IsNumeric(leftVal) && IsNumeric(rightVal))
						{
							result = Convert.ToDouble(leftVal) * Convert.ToDouble(rightVal);
						}
						else
						{
							throw new Exception($"Cannot multiply {leftVal?.GetType()} and {rightVal?.GetType()} at line {be.Line}");
						}
						break;
					case TokenType.SLASH:
						if (IsNumeric(leftVal) && IsNumeric(rightVal))
						{
							double divisor = Convert.ToDouble(rightVal);
							if (divisor == 0)
								throw new Exception($"Division by zero at line {be.Line}");
							result = Convert.ToDouble(leftVal) / divisor;
						}
						else
						{
							throw new Exception($"Cannot divide {leftVal?.GetType()} by {rightVal?.GetType()} at line {be.Line}");
						}
						break;
					case TokenType.PERCENT:
						if (IsNumeric(leftVal) && IsNumeric(rightVal))
						{
							result = Convert.ToDouble(leftVal) % Convert.ToDouble(rightVal);
						}
						else
						{
							throw new Exception($"Cannot take modulo of {leftVal?.GetType()} and {rightVal?.GetType()} at line {be.Line}");
						}
						break;
					case TokenType.POWER:
						if (IsNumeric(leftVal) && IsNumeric(rightVal))
						{
							result = Math.Pow(Convert.ToDouble(leftVal), Convert.ToDouble(rightVal));
						}
						else
						{
							throw new Exception($"Cannot raise {leftVal?.GetType()} to power of {rightVal?.GetType()} at line {be.Line}");
						}
						break;

					// Comparison operators
					case TokenType.EQ:
						// Handle V2Value equality
						if (leftVal is V2Value leftV2_eq && rightVal is V2Value rightV2_eq)
						{
							result = leftV2_eq == rightV2_eq;
						}
						else if (leftVal is V2Value leftV2_list_eq && rightVal is List<object> rightList_eq)
						{
							try
							{
								V2Value rightV2_converted_eq = V2Value.FromList(rightList_eq);
								result = leftV2_list_eq == rightV2_converted_eq;
							}
							catch
							{
								result = false; // Different types, not equal
							}
						}
						else if (leftVal is List<object> leftList_eq && rightVal is V2Value rightV2_list_eq)
						{
							try
							{
								V2Value leftV2_converted_eq = V2Value.FromList(leftList_eq);
								result = leftV2_converted_eq == rightV2_list_eq;
							}
							catch
							{
								result = false; // Different types, not equal
							}
						}
						else
						{
							result = AreEqual(leftVal, rightVal);
						}
						break;
					case TokenType.NEQ:
						result = !AreEqual(leftVal, rightVal);
						break;
					case TokenType.LT:
						result = CompareValues(leftVal, rightVal) < 0;
						break;
					case TokenType.GT:
						result = CompareValues(leftVal, rightVal) > 0;
						break;
					case TokenType.LTE:
						result = CompareValues(leftVal, rightVal) <= 0;
						break;
					case TokenType.GTE:
						result = CompareValues(leftVal, rightVal) >= 0;
						break;

					// NEW: Bitwise operators
					case TokenType.BIT_AND:
						result = ToInteger(leftVal, be.Line) & ToInteger(rightVal, be.Line);
						break;
					case TokenType.BIT_OR:
						result = ToInteger(leftVal, be.Line) | ToInteger(rightVal, be.Line);
						break;
					case TokenType.BIT_XOR:
						result = ToInteger(leftVal, be.Line) ^ ToInteger(rightVal, be.Line);
						break;
					case TokenType.SHIFT_LEFT:
					{
						long leftInt = ToInteger(leftVal, be.Line);
						long rightInt = ToInteger(rightVal, be.Line);
						if (rightInt < 0 || rightInt > 63)
							throw new Exception($"Shift count {rightInt} is out of range [0-63] at line {be.Line}");
						result = leftInt << (int)rightInt;
					}
					break;
					case TokenType.SHIFT_RIGHT:
					{
						long leftInt = ToInteger(leftVal, be.Line);
						long rightInt = ToInteger(rightVal, be.Line);
						if (rightInt < 0 || rightInt > 63)
							throw new Exception($"Shift count {rightInt} is out of range [0-63] at line {be.Line}");
						result = leftInt >> (int)rightInt;
					}
					break;

					default:
						throw new Exception($"Unsupported binary operator {be.Op} at line {be.Line}");
				}
				setValue(result);
			}
			// MODIFY the UnaryExpr case in ExecExpr method (around line 580 in PythonInterpreter.cs)
			// Replace the existing UnaryExpr case with:
			else if (expr is UnaryExpr ue)
			{
				object operandVal = null;
				IEnumerator operandEnum = ExecExpr(ue.Operand, val => operandVal = val);
				while (operandEnum.MoveNext())
				{
					yield return operandEnum.Current;
				}
				object result = null;
				if (ue.Op == TokenType.MINUS)
				{
					// Handle V2Value unary minus
					if (operandVal is V2Value v2Val)
					{
						result = -v2Val;
					}
					else if (IsNumeric(operandVal))
					{
						result = -Convert.ToDouble(operandVal);
					}
					else
					{
						throw new Exception($"Cannot apply unary minus to {operandVal?.GetType()} at line {ue.Line}");
					}
				}
				else if (ue.Op == TokenType.NOT)
				{
					result = !IsTrue(operandVal);
				}
				else if (ue.Op == TokenType.BIT_NOT)
				{
					long operandInt = ToInteger(operandVal, ue.Line);
					result = ~operandInt;
				}
				else
				{
					throw new Exception($"Unsupported unary operator {ue.Op} at line {ue.Line}");
				}
				setValue(result);
			}
			else if (expr is CallExpr ce)
			{

				// MODIFY the CallExpr case in ExecExpr method (around line 600 in PythonInterpreter.cs)
				// Update the NameExpr callee section to handle class instantiation:

				if (ce.Callee is NameExpr)
				{
					string fname = ((NameExpr)ce.Callee).Name;

					// Check if it's a class name first
					if (Classes.ContainsKey(fname))
					{
						// Class instantiation
						List<object> args = new List<object>();
						foreach (Expr arg in ce.Arguments)
						{
							object argVal = null;
							IEnumerator argEnum = ExecExpr(arg, val => argVal = val);
							while (argEnum.MoveNext())
							{
								yield return argEnum.Current;
							}
							args.Add(argVal);
						}

						ClassValue classValue = Classes[fname];
						ClassInstanceValue instance = classValue.CreateInstance();

						// Look for __init__ method in the class
						if (classValue.Methods.ContainsKey("__init__"))
						{
							FunctionDefStmt initMethod = classValue.Methods["__init__"] as FunctionDefStmt;
							if (initMethod != null)
							{
								// Call __init__ method with 'self' as first argument
								List<object> initArgs = new List<object> { instance };
								initArgs.AddRange(args);

								object initResult = null;
								IEnumerator initEnum = ExecFunction(initMethod, initArgs, val => initResult = val);
								while (initEnum.MoveNext())
									yield return initEnum.Current;
							}
						}

						setValue(instance);
					}
					else
					{
						// Regular function call (existing code)
						List<object> args = new List<object>();
						foreach (Expr arg in ce.Arguments)
						{
							object argVal = null;
							IEnumerator argEnum = ExecExpr(arg, val => argVal = val);
							while (argEnum.MoveNext())
							{
								yield return argEnum.Current;
							}
							args.Add(argVal);
						}
						yield return HandleBuiltinFunction(fname, args, setValue, ce);
					}
				}
				else if (ce.Callee is AttributeExpr ae)
				{
					// Method call on object
					object targetObj = null;
					IEnumerator targetEnum = ExecExpr(ae.Target, val => targetObj = val);
					while (targetEnum.MoveNext())
					{
						yield return targetEnum.Current;
					}
					string method = ae.Name;

					// Handle class instance method calls
					if (targetObj is ClassInstanceValue instanceObj)
					{
						// Look for method in the class
						if (instanceObj.Class.Methods.ContainsKey(method))
						{
							var methodFunc = instanceObj.Class.Methods[method] as FunctionDefStmt;
							if (methodFunc != null)
							{
								// Prepare arguments with 'self' as first parameter
								List<object> methodArgs = new List<object> { instanceObj };

								// Add provided arguments
								foreach (Expr arg in ce.Arguments)
								{
									object argVal = null;
									IEnumerator argEnum = ExecExpr(arg, val => argVal = val);
									while (argEnum.MoveNext())
									{
										yield return argEnum.Current;
									}
									methodArgs.Add(argVal);
								}

								// Execute the method
								object methodResult = null;
								IEnumerator methodEnum = ExecFunction(methodFunc, methodArgs, val => methodResult = val);
								while (methodEnum.MoveNext())
								{
									yield return methodEnum.Current;
								}
								setValue(methodResult);
							}
							else
							{
								throw new Exception($"Method '{method}' is not callable at line {ce.Line}");
							}
						}
						else
						{
							throw new Exception($"'{instanceObj.Class.Name}' object has no method '{method}' at line {ce.Line}");
						}
					}
					else if (targetObj is List<object> listObj)
					{
						// Existing list method handling code stays the same
						if (method == "append")
						{
							if (ce.Arguments.Count != 1)
								throw new Exception($"append() takes 1 argument at line {ce.Line}");
							object argVal = null;
							IEnumerator argEnum = ExecExpr(ce.Arguments[0], val => argVal = val);
							while (argEnum.MoveNext())
							{
								yield return argEnum.Current;
							}
							listObj.Add(argVal);
							setValue(null);
						}
						// ... rest of list methods
					}
					else
					{
						throw new Exception($"'{targetObj?.GetType().Name}' object has no attribute '{method}' at line {ce.Line}");
					}
				}
				else
				{
					throw new Exception($"Invalid function call target at line {ce.Line}");
				}
			}

			// MODIFY the IndexExpr case in ExecExpr method (around line 680 in PythonInterpreter.cs)
			// Replace the existing case with:
			else if (expr is IndexExpr ie)
			{
				object target = null;
				IEnumerator targetEnum = ExecExpr(ie.Target, val => target = val);
				while (targetEnum.MoveNext())
				{
					yield return targetEnum.Current;
				}
				object indexVal = null;
				IEnumerator idxEnum = ExecExpr(ie.Index, val => indexVal = val);
				while (idxEnum.MoveNext())
				{
					yield return idxEnum.Current;
				}

				if (target is List<object> listObj)
				{
					int idx = Convert.ToInt32(indexVal);
					if (idx < 0) idx = listObj.Count + idx;
					if (idx < 0 || idx >= listObj.Count)
						throw new Exception($"list index out of range at line {ie.Line}");
					setValue(listObj[idx]);
				}
				else if (target is DictValue dictObj)
				{
					setValue(dictObj.GetItem(indexVal));
				}
				else if (target is string strObj)
				{
					int idx = Convert.ToInt32(indexVal);
					if (idx < 0) idx = strObj.Length + idx;
					if (idx < 0 || idx >= strObj.Length)
						throw new Exception($"string index out of range at line {ie.Line}");
					setValue(strObj[idx].ToString());
				}
				else
				{
					throw new Exception($"Type {target?.GetType()} is not subscriptable at line {ie.Line}");
				}
			}

			// In the AttributeExpr case of ExecExpr method, add handling for PlayerObject after the existing cases:
			else if (expr is AttributeExpr ae)
			{
				object targetObj = null;
				IEnumerator targetEnum = ExecExpr(ae.Target, val => targetObj = val);
				while (targetEnum.MoveNext())
				{
					yield return targetEnum.Current;
				}

				string attribute = ae.Name;

				if (targetObj is V2Value v2Obj)
				{
					setValue(v2Obj.GetAttribute(attribute));
				}
				else if (targetObj is ClassInstanceValue instanceObj)
				{
					setValue(instanceObj.GetAttribute(attribute));
				}

				else if (targetObj is List<object> listObj && listObj.Count == 2)
				{
					// Support .x and .y access on 2-element lists (treating them like v2)
					switch (attribute.ToLower())
					{
						case "x":
							setValue(NumericHelpers.ToDouble(listObj[0]));
							break;
						case "y":
							setValue(NumericHelpers.ToDouble(listObj[1]));
							break;
						default:
							throw new Exception($"List has no attribute '{attribute}' at line {ae.Line}");
					}
				}
				else if (targetObj is DictValue dictObj)
				{
					// Handle dictionary methods if needed
					throw new Exception($"'{targetObj?.GetType().Name}' object has no attribute '{attribute}' at line {ae.Line}");
				}
				else
				{
					throw new Exception($"'{targetObj?.GetType().Name}' object has no attribute '{attribute}' at line {ae.Line}");
				}
			}

			else if (expr is SliceExpr sle)
			{
				object target = null;
				IEnumerator targetEnum = ExecExpr(sle.Target, val => target = val);
				while (targetEnum.MoveNext())
				{
					yield return targetEnum.Current;
				}
				if (target is List<object> listObj)
				{
					int startIndex = 0;
					int endIndex = listObj.Count;
					if (sle.Start != null)
					{
						object startVal = null;
						IEnumerator startEnum = ExecExpr(sle.Start, val => startVal = val);
						while (startEnum.MoveNext())
						{
							yield return startEnum.Current;
						}
						startIndex = Convert.ToInt32(startVal);
						if (startIndex < 0) startIndex = listObj.Count + startIndex;
						if (startIndex < 0) startIndex = 0;
						if (startIndex > listObj.Count) startIndex = listObj.Count;
					}
					if (sle.End != null)
					{
						object endVal = null;
						IEnumerator endEnum = ExecExpr(sle.End, val => endVal = val);
						while (endEnum.MoveNext())
						{
							yield return endEnum.Current;
						}
						endIndex = Convert.ToInt32(endVal);
						if (endIndex < 0) endIndex = listObj.Count + endIndex;
						if (endIndex < 0) endIndex = 0;
						if (endIndex > listObj.Count) endIndex = listObj.Count;
					}
					List<object> sliceList = new List<object>();
					for (int i = startIndex; i < endIndex; i++)
					{
						sliceList.Add(listObj[i]);
					}
					setValue(sliceList);
				}
				else
				{
					throw new Exception($"Type {target?.GetType()} does not support slicing at line {sle.Line}");
				}
			}
			else
			{
				throw new Exception($"Unknown expression type at line {expr.Line}");
			}
		}

		// ADD new method to PythonInterpreter class (around line 450):
		/// <summary>
		/// Convert object to Python-style string representation
		/// </summary>
		private string ToPythonString(object obj)
		{
			if (obj == null) return "None";

			if (obj is List<object> list)
			{
				var items = new List<string>();
				foreach (var item in list)
				{
					items.Add(ToPythonString(item)); // Recursive for nested lists
				}
				return "[" + string.Join(", ", items) + "]";
			}

			if (obj is string str)
			{
				return "\"" + str + "\""; // Add quotes for strings
			}

			if (obj is bool boolean)
			{
				return boolean ? "True" : "False"; // Python-style boolean
			}

			return obj.ToString();
		}


		private bool AreEqual(object a, object b)
		{
			// Handle null comparisons
			if (a == null && b == null) return true;
			if (a == null || b == null) return false;

			// Handle V2Value comparisons
			if (a is V2Value v2A && b is V2Value v2B)
			{
				return v2A == v2B;
			}

			// Handle V2Value vs List comparisons
			if (a is V2Value v2A_list && b is List<object> listB)
			{
				try
				{
					V2Value v2B_converted = V2Value.FromList(listB);
					return v2A_list == v2B_converted;
				}
				catch
				{
					return false;
				}
			}

			if (a is List<object> listA && b is V2Value v2B_list)
			{
				try
				{
					V2Value v2A_converted = V2Value.FromList(listA);
					return v2A_converted == v2B_list;
				}
				catch
				{
					return false;
				}
			}

			// Handle numeric equality with fuzzy tolerance (0.001 accuracy)
			if (IsNumeric(a) && IsNumeric(b))
			{
				double da = Convert.ToDouble(a);
				double db = Convert.ToDouble(b);
				return Math.Abs(da - db) < 0.001; // Fuzzy equality for game scripting
			}

			// Default equality
			return Equals(a, b);
		}

		// Add this method to your PythonInterpreter class
		// MODIFY HandleBuiltinFunction method - UPDATE print() implementation:
		private IEnumerator HandleBuiltinFunction(string fname, List<object> args, Action<object> setValue, CallExpr ce)
		{
			switch (fname)
			{
				// ADD this new case before "print":
				// Update ToPythonString method usage in str() builtin (around line 590):
				case "str":
					if (args.Count != 1)
						throw new Exception($"str() takes exactly one argument ({args.Count} given) at line {ce.Line}");

					object obj_1 = args[0];
					string strResult = ToPythonString(obj_1);
					// For V2Value and other objects, return their string representation directly
					if (obj_1 is V2Value || obj_1 is DictValue || obj_1 is ClassValue || obj_1 is ClassInstanceValue)
					{
						strResult = obj_1.ToString();
					}
					// Remove quotes from strings when using str() - str() returns the content, not the representation
					else if (obj_1 is string)
					{
						strResult = obj_1.ToString(); // Return string content without quotes
					}
					setValue(strResult);
					break;

				// Add this case before the "print" case (around line 580):
				case "v2":
					if (args.Count != 2)
						throw new Exception($"v2() takes exactly 2 arguments ({args.Count} given) at line {ce.Line}");
					double x = NumericHelpers.ToDouble(args[0]);
					double y = NumericHelpers.ToDouble(args[1]);
					setValue(new V2Value(x, y));
					break;
				// MODIFY HandleBuiltinFunction method print case (around line 380):
				case "print":
					string output = "";
					for (int i = 0; i < args.Count; i++)
					{
						if (i > 0) output += " ";
						// Print raw string values without extra quoting (so print("hi") -> hi)
						if (args[i] is string)
							//	output += args[i].ToString(); // to disable quote surrounding a string
							output += ToPythonString(args[i]);
						else
							output += ToPythonString(args[i]);

					}

					try
					{
						ConsoleManager.AddMessage(output, ConsoleMessageType.Print);
					}
					catch (Exception ex)
					{
						Debug.LogError($"Console manager error: {ex.Message}");
						Debug.Log(output);
					}

					// Force immediate yield for print - bypass batching
					ExecutionTracker.ForceYield();
					yield return new WaitForSecondsRealtime(ScriptRunner.stepDelay);

					setValue(null);
					break;

				// Update the "len" case to handle V2Value and DictValue (around line 630):
				case "len":
					if (args.Count != 1)
						throw new Exception($"len() takes exactly one argument ({args.Count} given) at line {ce.Line}");

					object obj = args[0];
					if (obj is List<object> list)
						setValue(list.Count);
					else if (obj is string str)
						setValue(str.Length);
					else if (obj is DictValue dict)
						setValue(dict.Count);
					else if (obj is V2Value)
						setValue(2); // V2 always has length 2
					else
						throw new Exception($"object of type '{obj?.GetType().Name}' has no len() at line {ce.Line}");
					break;

				case "range":
					if (args.Count == 1)
					{
						// range(stop)
						int stop = Convert.ToInt32(args[0]);
						List<object> rangeList = new List<object>();
						for (int i = 0; i < stop; i++)
							rangeList.Add((double)i);
						setValue(rangeList);
					}
					else if (args.Count == 2)
					{
						// range(start, stop)
						int start = Convert.ToInt32(args[0]);
						int stop = Convert.ToInt32(args[1]);
						List<object> rangeList = new List<object>();
						for (int i = start; i < stop; i++)
							rangeList.Add((double)i);
						setValue(rangeList);
					}
					else if (args.Count == 3)
					{
						// range(start, stop, step)
						int start = Convert.ToInt32(args[0]);
						int stop = Convert.ToInt32(args[1]);
						int step = Convert.ToInt32(args[2]);
						if (step == 0)
							throw new Exception("range() arg 3 must not be zero");

						List<object> rangeList = new List<object>();
						if (step > 0)
						{
							for (int i = start; i < stop; i += step)
								rangeList.Add((double)i);
						}
						else
						{
							for (int i = start; i > stop; i += step)
								rangeList.Add((double)i);
						}
						setValue(rangeList);
					}
					else
					{
						throw new Exception($"range expected at most 3 arguments, got {args.Count} at line {ce.Line}");
					}
					break;

				case "sleep":
					double seconds = 0;
					if (args.Count > 0)
						seconds = Convert.ToDouble(args[0]);
					yield return new WaitForSecondsRealtime((float)seconds);
					setValue(null);
					break;


				// ADD type() builtin before int() case in HandleBuiltinFunction method:
				case "type":
					if (args.Count != 1)
						throw new Exception($"type() takes exactly one argument ({args.Count} given) at line {ce.Line}");

					object typeObj = args[0];
					string typeName;

					if (typeObj == null)
					{
						typeName = "NoneType";
					}
					else if (typeObj is bool)
					{
						typeName = "bool";
					}
					else if (IsNumeric(typeObj))
					{
						// For simplicity, all numbers are reported as 'float' in our Python-like system
						// since we store everything as double internally
						if (typeObj is double d && d == Math.Floor(d) && d >= int.MinValue && d <= int.MaxValue)
						{
							typeName = "int";  // Whole numbers that fit in int range
						}
						else
						{
							typeName = "float";
						}
					}
					else if (typeObj is string)
					{
						typeName = "str";
					}
					else if (typeObj is List<object>)
					{
						typeName = "list";
					}
					else
					{
						// For other Unity/C# objects, return their actual type name
						typeName = typeObj.GetType().Name;
					}

					setValue($"<class '{typeName}'>");
					break;
				case "int":
					if (args.Count != 1)
						throw new Exception($"int() takes exactly one argument ({args.Count} given) at line {ce.Line}");

					object intObj = args[0];
					if (IsNumeric(intObj))
					{
						setValue((double)Convert.ToInt32(intObj)); // Store as double for consistency
					}
					else if (intObj is string intStr)
					{
						if (int.TryParse(intStr.Trim(), out int parsed))
						{
							setValue((double)parsed);
						}
						else
						{
							throw new Exception($"invalid literal for int(): '{intStr}' at line {ce.Line}");
						}
					}
					else
					{
						throw new Exception($"int() argument must be a number or string, not '{intObj?.GetType().Name}' at line {ce.Line}");
					}
					break;
				case "float":
					if (args.Count != 1)
						throw new Exception($"float() takes exactly one argument ({args.Count} given) at line {ce.Line}");

					object floatObj = args[0];
					if (IsNumeric(floatObj))
					{
						setValue(Convert.ToDouble(floatObj));
					}
					else if (floatObj is string floatStr)
					{
						if (double.TryParse(floatStr.Trim(), out double parsed))
						{
							setValue(parsed);
						}
						else
						{
							throw new Exception($"could not convert string to float: '{floatStr}' at line {ce.Line}");
						}
					}
					else
					{
						throw new Exception($"float() argument must be a number or string, not '{floatObj?.GetType().Name}' at line {ce.Line}");
					}
					break;

				case "bin":
					if (args.Count != 1)
						throw new Exception($"bin() takes exactly one arg ({args.Count} given) at line {ce.Line}");

					if (!IsNumeric(args[0]))
						throw new Exception($"bin() expected an integer argument at line {ce.Line}");

					// Convert double -> long so 5.0 => 5
					long value = Convert.ToInt64(args[0]);
					long absVal = value < 0 ? -value : value;
					// Convert to binary string
					string bits = Convert.ToString(absVal, 2);
					string binResult = (value < 0) ? $"-0b{bits}" : $"0b{bits}";
					setValue(binResult);
					break;


				default:
					// Check if it's a game built-in function
					if (GameBuiltinMethods.IsBuiltinFunction(fname))
					{
						var gameBuiltinEnum = GameBuiltinMethods.ExecuteBuiltinFunction(fname, args.ToArray(), setValue);
						while (gameBuiltinEnum.MoveNext())
							yield return gameBuiltinEnum.Current;
					}
					else if (Functions.ContainsKey(fname))
					{
						// User-defined function call
						object funcResult = null;
						IEnumerator funcEnum = ExecFunction(Functions[fname], args, val => funcResult = val);
						while (funcEnum.MoveNext())
							yield return funcEnum.Current;
						setValue(funcResult);
					}
					else
					{
						throw new Exception($"Unknown function '{fname}' at line {ce.Line}");
					}
					break;
			}
		}

		// Executes a user-defined function, yielding a step delay after each statement
		// Update ExecFunction method to push/pop global declarations:
		private IEnumerator ExecFunction(FunctionDefStmt fdef, List<object> args, Action<object> setValue)
		{
			if (args.Count != fdef.Parameters.Count)
				throw new Exception($"Function '{fdef.Name}' expects {fdef.Parameters.Count} arguments, got {args.Count} at line {fdef.Line}");

			// Reset counter when entering function
			ExecutionTracker.ResetIterationCounter();

			// Push new local scope and global declarations set
			var localVars = new Dictionary<string, object>();
			var globalDecls = new HashSet<string>();
			for (int i = 0; i < args.Count; i++)
				localVars[fdef.Parameters[i]] = args[i];
			LocalsStack.Push(localVars);
			GlobalDeclsStack.Push(globalDecls);

			try
			{
				// Drive each statement in the function body
				foreach (var stmt in fdef.Body)
				{
					var stmtEnum = ExecStmt(stmt);

					while (true)
					{
						object cur = null;
						bool hasNext = false;
						bool gotReturn = false;
						bool gotBreak = false;
						bool gotContinue = false;
						object returnValue = null;

						try
						{
							hasNext = stmtEnum.MoveNext();
							if (hasNext)
								cur = stmtEnum.Current;
						}
						catch (ReturnException retEx)
						{
							gotReturn = true;
							returnValue = retEx.Value;
						}
						catch (BreakException)
						{
							gotBreak = true;
						}
						catch (ContinueException)
						{
							gotContinue = true;
						}

						if (gotReturn)
						{
							setValue(returnValue);
							yield break;
						}
						if (gotBreak)
						{
							throw new BreakException();
						}
						if (gotContinue)
						{
							throw new ContinueException();
						}
						if (!hasNext) break;

						// Propagate any nested WaitForSecondsRealtime from sleep()
						yield return cur;
					}

					// Batched step delay between statements in function
					if (ExecutionTracker.ShouldYieldForBatch())
					{
						yield return null;
					}
				}

				// No return hit → produce null
				setValue(null);
			}
			finally
			{
				LocalsStack.Pop();
				GlobalDeclsStack.Pop();
			}
		}

		// Helper that simply iterates each statement in the function body
		private IEnumerable ExecuteFunctionBody(List<Stmt> body)
		{
			foreach (var stmt in body)
			{
				var stmtEnum = ExecStmt(stmt);
				while (stmtEnum.MoveNext())
					yield return stmtEnum.Current;
			}
		}

		// Helper: get variable from local or global scope
		private bool GetVariable(string name, out object value)
		{
			if (LocalsStack.Count > 0)
			{
				var localVars = LocalsStack.Peek();
				if (localVars.ContainsKey(name))
				{
					value = localVars[name];
					return true;
				}
			}
			if (Globals.ContainsKey(name))
			{
				value = Globals[name];
				return true;
			}
			value = null;
			return false;
		}

		// Add this method before SetVariable:
		private void SetVariable(string name, object value)
		{
			if (LocalsStack.Count > 0)
			{
				// Check if variable is declared global in current function
				if (GlobalDeclsStack.Count > 0 && GlobalDeclsStack.Peek().Contains(name))
				{
					Globals[name] = value;
				}
				else
				{
					var localVars = LocalsStack.Peek();
					// assign in local scope
					localVars[name] = value;
				}
			}
			else
			{
				Globals[name] = value;
			}
		}

		// Add support for attribute assignment (obj.attr = value)
		// Add this method after SetVariable:
		private void SetAttribute(object target, string attribute, object value)
		{
			if (target is V2Value v2Obj)
			{
				v2Obj.SetAttribute(attribute, value);
			}
			else if (target is ClassInstanceValue instanceObj)
			{
				instanceObj.SetAttribute(attribute, value);
			}
			else if (target is List<object> listObj && listObj.Count == 2)
			{
				switch (attribute.ToLower())
				{
					case "x":
						listObj[0] = NumericHelpers.ToDouble(value);
						break;
					case "y":
						listObj[1] = NumericHelpers.ToDouble(value);
						break;
					default:
						throw new Exception($"List has no attribute '{attribute}'");
				}
			}
			else
			{
				throw new Exception($"Cannot set attribute '{attribute}' on {target?.GetType().Name}");
			}
		}


		// Helper: truthiness (None/null false, false bool, 0 false, empty string/list false)
		private bool IsTrue(object obj)
		{
			if (obj == null) return false;
			if (obj is bool b) return b;
			if (obj is double d) return d != 0;
			if (obj is string s) return s.Length > 0;
			if (obj is List<object> list) return list.Count > 0;
			return true;
		}

		// MODIFY CompareValues method (around line 430) - Add automatic type coercion:
		private int CompareValues(object a, object b)
		{
			// Handle numeric comparisons with automatic coercion
			if (IsNumeric(a) && IsNumeric(b))
			{
				double da = Convert.ToDouble(a);
				double db = Convert.ToDouble(b);
				return da.CompareTo(db);
			}
			if (a is string sa && b is string sb)
			{
				return string.Compare(sa, sb);
			}
			throw new Exception($"Cannot compare values of types {a?.GetType()} and {b?.GetType()}");
		}

		// Replace the existing IsNumeric method (around line 850) with:
		private bool IsNumeric(object obj)
		{
			return NumericHelpers.IsNumeric(obj);
		}


		// ADD new helper method for bitwise operations:
		private long ToInteger(object obj, int line)
		{
			if (obj == null)
				throw new Exception($"Cannot convert None to integer for bitwise operation at line {line}");

			if (obj is bool b)
				return b ? 1L : 0L;

			if (IsNumeric(obj))
			{
				double d = Convert.ToDouble(obj);
				// Check for reasonable integer range
				if (d > long.MaxValue || d < long.MinValue)
					throw new Exception($"Number {d} is too large for bitwise operations at line {line}");
				return (long)d;
			}

			if (obj is string str)
			{
				if (long.TryParse(str.Trim(), out long result))
					return result;
				throw new Exception($"Cannot convert string '{str}' to integer for bitwise operation at line {line}");
			}

			throw new Exception($"Cannot convert {obj?.GetType().Name} to integer for bitwise operation at line {line}");
		}
	}
}
