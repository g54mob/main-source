using System;

namespace Assets.Scripts.Craft.Parts.Events
{
	public class PartConnectionChangedEventArgs : EventArgs
	{
		public bool IsSymmetryOperation { get; }

		public PartConnection PartConnection { get; }

		public PartConnectionChangedEventArgs(PartConnection partConnection, bool isSymmetryOperation)
		{
			PartConnection = partConnection;
			IsSymmetryOperation = isSymmetryOperation;
		}
	}
}
