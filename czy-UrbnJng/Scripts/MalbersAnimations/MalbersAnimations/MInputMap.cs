using System;
using System.Collections.Generic;
using MalbersAnimations.Scriptables;

namespace MalbersAnimations
{
	[Serializable]
	public class MInputMap
	{
		public StringReference name = new StringReference("New Map");

		public List<InputRow> inputs;

		public int selectedIndex;
	}
}
