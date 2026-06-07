using System;
using UnityEngine;

namespace Assets.Packages.DevConsole.Commands.Arguments
{
	public class Vector3ArgumentParser : IArgumentParser<Vector3>
	{
		public string HelpMessage => "x,y,z";

		public int Priority => 10;

		public bool TryParse(string value, out Vector3 result)
		{
			if (!string.IsNullOrEmpty(value))
			{
				string[] array = value.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length == 3 && float.TryParse(array[0].Trim(), out var result2) && float.TryParse(array[1].Trim(), out var result3) && float.TryParse(array[2].Trim(), out var result4))
				{
					result = new Vector3(result2, result3, result4);
					return true;
				}
			}
			result = Vector3.zero;
			return false;
		}
	}
}
