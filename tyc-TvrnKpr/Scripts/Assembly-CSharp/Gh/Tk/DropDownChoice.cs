using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class DropDownChoice : PropertyAttribute
	{
		private static Dictionary<(Type, string), (float time, IList<string> displayNames, IList<string> choices)> _cache;

		private const float _cacheDurationInSeconds = 15f;

		public IList<string> Choices { get; private set; }

		public IList<string> DisplayNames { get; private set; }

		public DropDownChoice(params string[] choices)
		{
		}

		public DropDownChoice(Type type, string staticMethodName)
		{
		}
	}
}
