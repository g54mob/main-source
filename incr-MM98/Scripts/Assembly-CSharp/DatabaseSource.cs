using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Text;
using UnityEngine.Localization.SmartFormat.Core.Extensions;
using UnityEngine.Localization.SmartFormat.Core.Formatting;

[Serializable]
public class DatabaseSource : ISource
{
	public class DatabaseLocalizationContext
	{
		private readonly Dictionary<string, DatabaseVariable> _cache = new Dictionary<string, DatabaseVariable>();

		public void Set(string key, object value)
		{
			if (_cache.TryGetValue(key, out var value2))
			{
				value2.Value = value;
			}
			else
			{
				_cache.Add(key, new DatabaseVariable(value));
			}
		}

		public DatabaseVariable Get(string key)
		{
			if (_cache.TryGetValue(key, out var value))
			{
				return value;
			}
			return _cache[key] = new DatabaseVariable();
		}
	}

	public static readonly DatabaseLocalizationContext Context = new DatabaseLocalizationContext();

	public string[] selector = new string[3] { "database", "data", "db" };

	public string databaseNotFoundFormat = "DB.<{0}>";

	public bool TryEvaluateSelector(ISelectorInfo selectorInfo)
	{
		if (selector.Contains(selectorInfo.SelectorText))
		{
			return HandleSelector(selectorInfo);
		}
		if (selectorInfo.CurrentValue == Context)
		{
			return HandleContext(selectorInfo);
		}
		return false;
	}

	private bool HandleSelector(ISelectorInfo selectorInfo)
	{
		selectorInfo.Result = Context;
		return true;
	}

	private bool HandleContext(ISelectorInfo selectorInfo)
	{
		DatabaseVariable databaseVariable = Context.Get(selectorInfo.SelectorText);
		FormatCache formatCache = selectorInfo.FormatDetails.FormatCache;
		if (formatCache != null && !formatCache.VariableTriggers.Contains(databaseVariable))
		{
			formatCache.VariableTriggers.Add(databaseVariable);
		}
		if (databaseVariable.Initialized)
		{
			selectorInfo.Result = databaseVariable.GetSourceValue(selectorInfo);
		}
		else
		{
			selectorInfo.Result = ZString.Format(databaseNotFoundFormat, selectorInfo.SelectorText);
		}
		return true;
	}
}
