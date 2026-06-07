using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Events;
using Jundroo.Common.Expressions;
using Jundroo.Common.Expressions.Tokens;
using Jundroo.DevConsole;
using UnityEngine;

namespace Assets.Dev.Scripts
{
	public class ExpressionTester : MonoBehaviour
	{
		private static AircraftScript _compiledForAircraft;

		private static Dictionary<string, Func<string>> _debugs;

		private static ExpressionTester _instance;

		private static Dictionary<string, string> _results;

		private FlightSceneScript _fss;

		static ExpressionTester()
		{
			_debugs = new Dictionary<string, Func<string>>();
			_results = new Dictionary<string, string>();
			DevConsoleApi.RegisterCommand("DebugExpression", delegate(string s)
			{
				AddDebug(s);
			});
			DevConsoleApi.RegisterCommand("ClearDebugExpressions", delegate
			{
				ClearDebug();
			});
			DevConsoleApi.RegisterCommand("SetExpressionEmit", (bool v) => Parser.ForceFunk = !v);
			DevConsoleApi.RegisterCommand("GetExpressionEmit", delegate
			{
				Debug.Log("Emit: " + !Parser.Funk);
			});
			DevConsoleApi.RegisterCommand<string, string>("ShowExpressionMembers", DumpMembers);
		}

		protected virtual void FixedUpdate()
		{
			if (_compiledForAircraft == null)
			{
				return;
			}
			foreach (string key in _debugs.Keys)
			{
				_results[key] = _debugs[key]();
			}
		}

		protected void OnDestroy()
		{
			if (_fss != null)
			{
				_fss.PlayerAircraftLoaded -= PlayerAircraftLoaded;
			}
		}

		protected virtual void OnGUI()
		{
			if (_debugs.Count == 0)
			{
				base.enabled = false;
				return;
			}
			GUILayout.BeginVertical(GUI.skin.box);
			foreach (KeyValuePair<string, string> result in _results)
			{
				GUILayout.Label(result.Key + ": " + result.Value);
			}
			GUILayout.EndVertical();
		}

		protected virtual void Start()
		{
			_instance = this;
			_fss = FlightSceneScript.Instance;
			if (_fss != null)
			{
				_fss.PlayerAircraftLoaded += PlayerAircraftLoaded;
			}
		}

		private static void AddDebug(string exp)
		{
			if (_compiledForAircraft == null)
			{
				Debug.LogError("Failed to add debug expression: no current aircraft being tracked.");
				return;
			}
			exp = exp.Replace('#', '"');
			Func<string> value = Parser.Process<string>(exp, _compiledForAircraft.MainCockpit.ExpressionContext);
			_debugs.Add(exp, value);
			_results.Add(exp, null);
			if (_instance != null)
			{
				_instance.enabled = true;
			}
		}

		private static string DumpMembers(string exp)
		{
			if (_compiledForAircraft == null)
			{
				return "Failed to dump expression members: no current aircraft being tracked.";
			}
			Context expressionContext = _compiledForAircraft.MainCockpit.ExpressionContext;
			Token token = Parser.Squash(Parser.Parse(exp, allowDataSlotTokens: false), expressionContext);
			Dictionary<string, MethodInfo> properties = expressionContext.GetProperties(token.Type);
			Dictionary<string, MethodInfo> methods = expressionContext.GetMethods(token.Type);
			StringBuilder stringBuilder = new StringBuilder("Member dump for type ");
			stringBuilder.Append(token.Type.Name);
			stringBuilder.AppendLine(" (click to show)");
			if (properties.Count == 0)
			{
				stringBuilder.AppendLine("No accessible properties");
			}
			else
			{
				stringBuilder.AppendLine("Properties:");
				foreach (KeyValuePair<string, MethodInfo> item in properties)
				{
					stringBuilder.Append("    ");
					stringBuilder.Append(item.Key);
					stringBuilder.Append(" : ");
					stringBuilder.AppendLine(item.Value.ReturnType.Name);
				}
			}
			if (methods.Count == 0)
			{
				stringBuilder.AppendLine("No accessible methods");
			}
			else
			{
				stringBuilder.AppendLine("Methods:");
				foreach (KeyValuePair<string, MethodInfo> item2 in methods)
				{
					stringBuilder.Append("    ");
					stringBuilder.Append(item2.Key);
					stringBuilder.Append('(');
					ParameterInfo[] parameters = item2.Value.GetParameters();
					for (int i = 0; i < parameters.Length; i++)
					{
						ParameterInfo parameterInfo = parameters[i];
						stringBuilder.Append(parameterInfo.Name);
						stringBuilder.Append(" : ");
						stringBuilder.Append(parameterInfo.ParameterType.Name);
						if (i != parameters.Length - 1)
						{
							stringBuilder.Append(", ");
						}
					}
					stringBuilder.Append(") : ");
					stringBuilder.AppendLine(item2.Value.ReturnType.Name);
				}
			}
			return stringBuilder.ToString();
		}

		private static void ClearDebug()
		{
			_debugs.Clear();
			_results.Clear();
		}

		private static void ReParse(AircraftScript aircraft)
		{
			_compiledForAircraft = aircraft;
			string[] array = _debugs.Keys.ToArray();
			foreach (string text in array)
			{
				try
				{
					_debugs[text] = Parser.Process<string>(text, aircraft.MainCockpit.ExpressionContext);
				}
				catch (Exception ex)
				{
					string s = "Error: " + ex.Message;
					_debugs[text] = () => s;
				}
			}
		}

		private void PlayerAircraftLoaded(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			if (e.Player.IsPrimaryLocal)
			{
				ReParse(e.Aircraft);
			}
		}
	}
}
