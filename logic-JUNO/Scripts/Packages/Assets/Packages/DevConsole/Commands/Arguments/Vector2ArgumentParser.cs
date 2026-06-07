using System;
using UnityEngine;

namespace Assets.Packages.DevConsole.Commands.Arguments
{
	public class Vector2ArgumentParser : IArgumentParser<Vector2>
	{
		public string HelpMessage => "x,y";

		public int Priority => 10;

		public bool TryParse(string value, out Vector2 result)
		{
			if (!string.IsNullOrEmpty(value))
			{
				string[] array = value.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length == 2 && float.TryParse(array[0].Trim(), out var result2) && float.TryParse(array[1].Trim(), out var result3))
				{
					result = new Vector2(result2, result3);
					return true;
				}
			}
			result = Vector2.zero;
			return false;
		}
	}
}
