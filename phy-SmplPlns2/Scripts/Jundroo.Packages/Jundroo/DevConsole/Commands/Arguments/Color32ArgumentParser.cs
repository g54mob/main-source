using System;
using UnityEngine;

namespace Jundroo.DevConsole.Commands.Arguments
{
	internal class Color32ArgumentParser : IArgumentParser<Color32>
	{
		public string HelpMessage => "red,green,blue,alpha (values are bytes - 0 to 255)";

		public int Priority => 10;

		public bool TryParse(string value, out Color32 result)
		{
			if (!string.IsNullOrEmpty(value))
			{
				string[] array = value.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length == 4 && byte.TryParse(array[0].Trim(), out var result2) && byte.TryParse(array[1].Trim(), out var result3) && byte.TryParse(array[2].Trim(), out var result4) && byte.TryParse(array[3].Trim(), out var result5))
				{
					result = new Color32(result2, result3, result4, result5);
					return true;
				}
			}
			result = default(Color32);
			return false;
		}
	}
}
