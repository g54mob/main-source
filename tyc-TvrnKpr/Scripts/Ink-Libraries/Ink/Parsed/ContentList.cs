using System.Collections.Generic;
using Ink.Runtime;

namespace Ink.Parsed
{
	public class ContentList : Object
	{
		public bool dontFlatten { get; set; }

		public Container runtimeContainer => null;

		public ContentList(List<Object> objects)
		{
		}

		public ContentList(params Object[] objects)
		{
		}

		public ContentList()
		{
		}

		public void TrimTrailingWhitespace()
		{
		}

		public override Ink.Runtime.Object GenerateRuntimeObject()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
