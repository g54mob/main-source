using System;
using UnityEngine;

namespace Jundroo.DevConsole.Commands.Arguments
{
	internal class RectArgumentParser : IArgumentParser<Rect>
	{
		public string HelpMessage => "left,top,width,height (values are floats)";

		public int Priority => 10;

		public bool TryParse(string value, out Rect result)
		{
			if (!string.IsNullOrEmpty(value))
			{
				string[] array = value.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length == 4 && float.TryParse(array[0].Trim(), out var result2) && float.TryParse(array[1].Trim(), out var result3) && float.TryParse(array[2].Trim(), out var result4) && float.TryParse(array[3].Trim(), out var result5))
				{
					result = new Rect(result2, result3, result4, result5);
					return true;
				}
			}
			result = default(Rect);
			return false;
		}
	}
}
