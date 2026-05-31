using System;
using System.Collections.Generic;
using UnityEngine;

namespace Language.Lua
{
	public class Assignment : Statement
	{
		public static HashSet<string> MonitoredLocalVariables = new HashSet<string>();

		public static Action<string, object> LocalVariableChanged = null;

		public static HashSet<string> MonitoredVariables = new HashSet<string>();

		public static Action<string, object> VariableChanged = null;

		private static LuaValue VariableTableToMonitor = null;

		public List<Var> VarList = new List<Var>();

		public List<Expr> ExprList = new List<Expr>();

		public static void InitializeVariableMonitoring()
		{
			MonitoredLocalVariables = new HashSet<string>();
			LocalVariableChanged = null;
			MonitoredVariables = new HashSet<string>();
			VariableChanged = null;
			VariableTableToMonitor = null;
		}

		public override LuaValue Execute(LuaTable enviroment, out bool isBreak)
		{
			LuaValue[] array = LuaInterpreterExtensions.EvaluateAll(ExprList, enviroment).ToArray();
			LuaValue[] array2 = LuaMultiValue.UnWrapLuaValues(array);
			for (int i = 0; i < Math.Min(VarList.Count, array2.Length); i++)
			{
				Var var = VarList[i];
				if (var.Accesses.Count == 0)
				{
					if (!(var.Base is VarName varName))
					{
						continue;
					}
					SetKeyValue(enviroment, new LuaString(varName.Name), array[i]);
					if (varName.Name == "Variable")
					{
						VariableTableToMonitor = array[0];
					}
					if (MonitoredLocalVariables.Contains(varName.Name) && array.Length >= 1)
					{
						try
						{
							LocalVariableChanged?.Invoke(varName.Name, array[0].Value);
						}
						catch (Exception exception)
						{
							Debug.LogException(exception);
						}
					}
					continue;
				}
				LuaValue luaValue = var.Base.Evaluate(enviroment);
				for (int j = 0; j < var.Accesses.Count - 1; j++)
				{
					luaValue = var.Accesses[j].Evaluate(luaValue, enviroment);
				}
				Access access = var.Accesses[var.Accesses.Count - 1];
				if (access is NameAccess nameAccess)
				{
					if (luaValue == null || luaValue is LuaNil)
					{
						throw new NullReferenceException("Cannot assign to a null value. Are you trying to assign to a nonexistent table element?.");
					}
					SetKeyValue(luaValue, new LuaString(nameAccess.Name), array[i]);
				}
				else
				{
					KeyAccess keyAccess = access as KeyAccess;
					if (access != null)
					{
						SetKeyValue(luaValue, keyAccess.Key.Evaluate(enviroment), array[i]);
					}
				}
			}
			isBreak = false;
			return null;
		}

		private static void SetKeyValue(LuaValue baseValue, LuaValue key, LuaValue value)
		{
			LuaValue luaValue = LuaNil.Nil;
			if (baseValue is LuaTable luaTable)
			{
				try
				{
					if (luaTable.ContainsKey(key))
					{
						luaTable.SetKeyValue(key, value);
						return;
					}
					if (luaTable.MetaTable != null)
					{
						luaValue = luaTable.MetaTable.GetValue("__newindex");
					}
					if (luaValue == LuaNil.Nil)
					{
						luaTable.SetKeyValue(key, value);
						return;
					}
				}
				finally
				{
					if (baseValue == VariableTableToMonitor && key != null && value != null && MonitoredVariables.Contains(key.ToString()))
					{
						try
						{
							VariableChanged?.Invoke(key.ToString(), value.Value);
						}
						catch (Exception exception)
						{
							Debug.LogException(exception);
						}
					}
				}
			}
			else if (baseValue is LuaUserdata luaUserdata)
			{
				if (luaUserdata.MetaTable != null)
				{
					luaValue = luaUserdata.MetaTable.GetValue("__newindex");
				}
				if (luaValue == LuaNil.Nil)
				{
					throw new Exception("Assign field of userdata without __newindex defined.");
				}
			}
			if (luaValue is LuaFunction luaFunction)
			{
				luaFunction.Invoke(new LuaValue[3] { baseValue, key, value });
			}
			else
			{
				SetKeyValue(luaValue, key, value);
			}
		}
	}
}
