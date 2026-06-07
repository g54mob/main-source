using System;

namespace Assets.Scripts.Design.Symmetry.Events
{
	public class SymmetryModeChangeEventArgs : EventArgs
	{
		public SymmetryMode NewMode { get; }

		public SymmetryMode PreviousMode { get; }

		public SymmetryModeChangeEventArgs(SymmetryMode previousMode, SymmetryMode newMode)
		{
			PreviousMode = previousMode;
			NewMode = newMode;
		}
	}
}
