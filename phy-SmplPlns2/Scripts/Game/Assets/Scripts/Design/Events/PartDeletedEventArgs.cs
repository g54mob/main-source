using System;
using Assets.Scripts.Craft.Parts;

namespace Assets.Scripts.Design.Events
{
	public class PartDeletedEventArgs : EventArgs
	{
		public PartScript Part { get; }

		public PartDeletedEventArgs(PartScript part)
		{
			Part = part;
		}
	}
}
