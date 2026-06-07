using System;

namespace Noesis
{
	internal class NamedObject : BaseComponent
	{
		private string _name;

		public NamedObject(string name, IntPtr cPtr)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
