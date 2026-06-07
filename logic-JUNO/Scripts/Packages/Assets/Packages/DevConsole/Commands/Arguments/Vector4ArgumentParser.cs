using System;
using UnityEngine;

namespace Assets.Packages.DevConsole.Commands.Arguments
{
	public class Vector4ArgumentParser : IArgumentParser<Vector4>
	{
		public string HelpMessage => "x,y,z,w";

		public int Priority => 10;

		public bool TryParse(string value, out Vector4 result)
		{
			if (!string.IsNullOrEmpty(value))
			{
				string[] array = value.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length == 4 && float.TryParse(array[0].Trim(), out var result2) && float.TryParse(array[1].Trim(), out var result3) && float.TryParse(array[2].Trim(), out var result4) && float.TryParse(array[3].Trim(), out var result5))
				{
					result = new Vector4(result2, result3, result4, result5);
					return true;
				}
			}
			result = Vector4.zero;
			return false;
		}
	}
}
