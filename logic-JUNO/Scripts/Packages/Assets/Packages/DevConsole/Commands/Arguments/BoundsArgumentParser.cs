using System;
using UnityEngine;

namespace Assets.Packages.DevConsole.Commands.Arguments
{
	public class BoundsArgumentParser : IArgumentParser<Bounds>
	{
		public string HelpMessage => "center_x,center_y,center_z,size_x,size_y,size_z";

		public int Priority => 10;

		public bool TryParse(string value, out Bounds result)
		{
			if (!string.IsNullOrEmpty(value))
			{
				string[] array = value.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length == 6 && float.TryParse(array[0].Trim(), out var result2) && float.TryParse(array[1].Trim(), out var result3) && float.TryParse(array[2].Trim(), out var result4) && float.TryParse(array[3].Trim(), out var result5) && float.TryParse(array[4].Trim(), out var result6) && float.TryParse(array[5].Trim(), out var result7))
				{
					result = new Bounds(new Vector3(result2, result3, result4), new Vector3(result5, result6, result7));
					return true;
				}
			}
			result = default(Bounds);
			return false;
		}
	}
}
