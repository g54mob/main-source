using System;
using UnityEngine;

namespace Jundroo.DevConsole.Commands.Arguments
{
	internal class QuaternionArgumentParser : IArgumentParser<Quaternion>
	{
		public string HelpMessage => "x,y,z or x,y,z,w";

		public int Priority => 10;

		public bool TryParse(string value, out Quaternion result)
		{
			if (!string.IsNullOrEmpty(value))
			{
				string[] array = value.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				float result5;
				float result6;
				float result7;
				float result8;
				if (array.Length == 3)
				{
					if (float.TryParse(array[0].Trim(), out var result2) && float.TryParse(array[1].Trim(), out var result3) && float.TryParse(array[2].Trim(), out var result4))
					{
						result = Quaternion.Euler(result2, result3, result4);
						return true;
					}
				}
				else if (array.Length == 4 && float.TryParse(array[0].Trim(), out result5) && float.TryParse(array[1].Trim(), out result6) && float.TryParse(array[2].Trim(), out result7) && float.TryParse(array[3].Trim(), out result8))
				{
					result = new Quaternion(result5, result6, result7, result8);
					return true;
				}
			}
			result = default(Quaternion);
			return false;
		}
	}
}
