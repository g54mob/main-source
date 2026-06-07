using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Runtime.Console
{
	public class Input
	{
		[field: NonSerialized]
		public string Command { get; }

		[field: NonSerialized]
		public Parameter[] Parameters { get; }

		private Input()
		{
			Command = string.Empty;
			Parameters = Array.Empty<Parameter>();
		}

		public Input(string command, Parameter[] parameters)
			: this()
		{
			Command = command;
			Parameters = parameters ?? Array.Empty<Parameter>();
		}

		public Input(string input)
			: this()
		{
			List<string> list = input.Split('"').Select((string element, int index) => (index % 2 != 0) ? new string[1] { element } : element.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).SelectMany((string[] element) => element)
				.ToList();
			if (list.Count > 0)
			{
				Command = list[0].ToLowerInvariant();
				List<Parameter> list2 = new List<Parameter>();
				for (int num = 1; num < list.Count; num += 2)
				{
					Parameter item = new Parameter(list[num], (num + 1 < list.Count) ? list[num + 1] : string.Empty);
					list2.Add(item);
				}
				Parameters = list2.ToArray();
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder("> " + Command);
			Parameter[] parameters = Parameters;
			foreach (Parameter parameter in parameters)
			{
				stringBuilder.Append(" ");
				stringBuilder.Append(parameter);
			}
			return stringBuilder.ToString();
		}
	}
}
