using System;
using System.Collections.Generic;
using Rhizomatic.Reactive;

namespace GRP
{
	public class ColorBuilder
	{
		public List<ColorField> fields;

		public Part part;

		public void Add(string color, string name, Action<string> set)
		{
		}

		public void Add(State<string> color, string name)
		{
		}
	}
}
