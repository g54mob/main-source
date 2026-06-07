using System;
using UnityEngine;

namespace Assets.Packages.DevConsole.Commands.Arguments
{
	public class ColorArgumentParser : IArgumentParser<Color>
	{
		public string HelpMessage => "red,green,blue,alpha (values are floats - 0.0 to 1.0)";

		public int Priority => 10;

		public bool TryParse(string value, out Color result)
		{
			if (!string.IsNullOrEmpty(value))
			{
				string[] array = value.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length == 4 && float.TryParse(array[0].Trim(), out var result2) && float.TryParse(array[1].Trim(), out var result3) && float.TryParse(array[2].Trim(), out var result4) && float.TryParse(array[3].Trim(), out var result5))
				{
					result = new Color(result2, result3, result4, result5);
					return true;
				}
			}
			result = default(Color);
			return false;
		}
	}
}
