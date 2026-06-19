using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace QFSW.QC.Suggestors
{
	public class CommandSuggestion : IQcSuggestion
	{
		private struct ParsedCommandNameInfo
		{
			public string RawName;

			public string CommandName;

			public string GenericSignature;

			public string[] GenericArgNames;
		}

		private readonly CommandData _command;

		private readonly string[] _paramNames;

		private readonly int _numOptionalParams;

		private readonly string _overrideSignature;

		private readonly int _bakedParamCount;

		private readonly Dictionary<string, Type[]> _genericSignatureCache = new Dictionary<string, Type[]>();

		private readonly Dictionary<ParameterInfo, IQcSuggestorTag[]> _parameterTagsCache = new Dictionary<ParameterInfo, IQcSuggestorTag[]>();

		private readonly StringBuilder _stringBuilder = new StringBuilder();

		private ParsedCommandNameInfo _currentCommandNameCache;

		private bool _isUsingOverride => !string.IsNullOrEmpty(_overrideSignature);

		public string FullSignature => _command.CommandSignature;

		public string PrimarySignature
		{
			get
			{
				if (!_isUsingOverride)
				{
					return _command.CommandName;
				}
				return _overrideSignature;
			}
		}

		public string SecondarySignature { get; }

		public CommandData Command => _command;

		public CommandSuggestion(CommandData command, int numOptionalParams = 0, string overrideSignature = null, int bakedParamCount = 0)
		{
			_command = command;
			_overrideSignature = overrideSignature;
			_bakedParamCount = bakedParamCount;
			_numOptionalParams = numOptionalParams;
			_paramNames = _command.ParameterSignature.Split(' ');
			for (int i = _paramNames.Length - _numOptionalParams; i < _paramNames.Length; i++)
			{
				if (i < command.MethodParamData.Length)
				{
					string text = command.MethodParamData[i].DefaultValue?.ToString();
					_paramNames[i] = (string.IsNullOrEmpty(text) ? ("[" + _paramNames[i] + "]") : ("[" + _paramNames[i] + "=" + text + "]"));
				}
			}
			int count = (_isUsingOverride ? _bakedParamCount : 0);
			string text2 = string.Join(" ", _paramNames.Skip(count));
			SecondarySignature = (string.IsNullOrEmpty(text2) ? _command.GenericSignature : (_command.GenericSignature + " " + text2));
		}

		public bool MatchesPrompt(string prompt)
		{
			UpdateCurrentCache(prompt);
			if (_currentCommandNameCache.CommandName == _command.CommandName)
			{
				if (_isUsingOverride)
				{
					return prompt.StartsWith(_overrideSignature);
				}
				return true;
			}
			return false;
		}

		public string GetCompletion(string prompt)
		{
			return PrimarySignature;
		}

		public string GetCompletionTail(string prompt)
		{
			UpdateCurrentCache(prompt);
			_stringBuilder.Clear();
			int a = prompt.SplitScoped(' ').Count((string x) => !string.IsNullOrWhiteSpace(x)) - 1;
			a = Mathf.Max(a, 0);
			int num = _command.ParamCount - a;
			if (prompt == _currentCommandNameCache.CommandName)
			{
				_stringBuilder.Append(_command.GenericSignature);
			}
			for (int num2 = 0; num2 < num; num2++)
			{
				if (num2 > 0 || !prompt.EndsWith(" "))
				{
					_stringBuilder.Append(' ');
				}
				int num3 = num2 + a;
				_stringBuilder.Append(_paramNames[num3]);
			}
			return _stringBuilder.ToString();
		}

		public SuggestionContext? GetInnerSuggestionContext(SuggestionContext context)
		{
			UpdateCurrentCache(context.Prompt);
			if (_isUsingOverride && context.Prompt == _overrideSignature)
			{
				return null;
			}
			bool flag = context.Prompt.EndsWith(" ") && context.Prompt.GetMaxScopeDepthAtEnd() == 0;
			string[] array = (from x in context.Prompt.SplitScoped(' ')
				where !string.IsNullOrWhiteSpace(x)
				select x).ToArray();
			int num = array.Length - 1;
			if (flag)
			{
				num++;
			}
			if (num <= 0 || num > _command.ParamCount)
			{
				return null;
			}
			int paramIndex = num - 1;
			SuggestionContext value = context;
			value.Depth++;
			value.TargetType = GetParameterType(paramIndex);
			value.Tags = GetParameterTags(paramIndex);
			value.Prompt = (flag ? string.Empty : array.LastOrDefault());
			return value;
		}

		private void UpdateCurrentCache(string prompt)
		{
			string text = prompt.SplitScopedFirst(' ');
			if (text != _currentCommandNameCache.RawName)
			{
				_currentCommandNameCache = ParseCommandNameInfo(text);
			}
		}

		private ParsedCommandNameInfo ParseCommandNameInfo(string rawName)
		{
			string[] array = rawName.Split(new char[1] { '<' }, 2);
			ParsedCommandNameInfo result = new ParsedCommandNameInfo
			{
				RawName = rawName,
				CommandName = array[0]
			};
			if (_command.IsGeneric)
			{
				result.GenericSignature = ((array.Length > 1) ? ("<" + array[1]) : "");
				result.GenericArgNames = result.GenericSignature.ReduceScope('<', '>').SplitScoped(',');
			}
			return result;
		}

		private Type[] ParseGenericTypes(ParsedCommandNameInfo commandNameInfo)
		{
			return commandNameInfo.GenericArgNames.Select(QuantumParser.ParseType).ToArray();
		}

		private Type[] GetParameterTypes(ParsedCommandNameInfo commandNameInfo)
		{
			if (!_command.IsGeneric)
			{
				return _command.ParamTypes;
			}
			if (_genericSignatureCache.TryGetValue(commandNameInfo.GenericSignature, out var value))
			{
				return value;
			}
			try
			{
				Type[] genericTypeArguments = ParseGenericTypes(_currentCommandNameCache);
				value = _command.MakeGenericArguments(genericTypeArguments);
			}
			catch
			{
				value = _command.ParamTypes;
			}
			return _genericSignatureCache[commandNameInfo.GenericSignature] = value;
		}

		private Type GetParameterType(int paramIndex)
		{
			return GetParameterTypes(_currentCommandNameCache)[paramIndex];
		}

		private IQcSuggestorTag[] GetParameterTags(int paramIndex)
		{
			ParameterInfo parameterInfo = _command.MethodParamData[paramIndex];
			if (_parameterTagsCache.TryGetValue(parameterInfo, out var value))
			{
				return value;
			}
			return _parameterTagsCache[parameterInfo] = parameterInfo.GetCustomAttributes<SuggestorTagAttribute>().SelectMany((SuggestorTagAttribute x) => x.GetSuggestorTags()).ToArray();
		}
	}
}
