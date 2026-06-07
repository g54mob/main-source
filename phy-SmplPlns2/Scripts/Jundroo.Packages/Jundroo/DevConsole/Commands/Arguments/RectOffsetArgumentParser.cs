using System;
using UnityEngine;

namespace Jundroo.DevConsole.Commands.Arguments
{
	internal class RectOffsetArgumentParser : IArgumentParser<RectOffset>
	{
		public string HelpMessage => "left,right,top,bottom (values are integers)";

		public int Priority => 10;

		public bool TryParse(string value, out RectOffset result)
		{
			if (!string.IsNullOrEmpty(value))
			{
				string[] array = value.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length == 4 && int.TryParse(array[0].Trim(), out var result2) && int.TryParse(array[1].Trim(), out var result3) && int.TryParse(array[2].Trim(), out var result4) && int.TryParse(array[3].Trim(), out var result5))
				{
					result = new RectOffset(result2, result3, result4, result5);
					return true;
				}
			}
			result = new RectOffset();
			return false;
		}
	}
}
