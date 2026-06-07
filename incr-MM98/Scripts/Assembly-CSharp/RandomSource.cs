using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization.SmartFormat.Core.Extensions;

[Serializable]
public class RandomSource : ISource
{
	public class RandomNumberContext
	{
	}

	public static readonly RandomNumberContext Context = new RandomNumberContext();

	public string[] selector = new string[3] { "random", "rnd", "rng" };

	public string separator = "-";

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
		if (!ParseParameters(selectorInfo.SelectorText, out var minimum, out var maximum))
		{
			return false;
		}
		selectorInfo.Result = UnityEngine.Random.Range(minimum, maximum);
		return true;
	}

	private bool ParseParameters(string selectorText, out int minimum, out int maximum)
	{
		minimum = 0;
		maximum = 0;
		string[] array = selectorText.Split(separator);
		if (array.Length != 2)
		{
			return false;
		}
		if (int.TryParse(array[0], out minimum))
		{
			return int.TryParse(array[1], out maximum);
		}
		return false;
	}
}
