using System;
using Unity.Mathematics.Geometry;

namespace Assets.Scripts.Design.Symmetry.Events
{
	public class SymmetryMirrorPlaneChangeEventArgs : EventArgs
	{
		public Plane NewMirrorPlane { get; }

		public Plane PreviousMirrorPlane { get; }

		public SymmetryMirrorPlaneChangeEventArgs(Plane previousMirrorPlane, Plane newMirrorPlane)
		{
			PreviousMirrorPlane = previousMirrorPlane;
			NewMirrorPlane = newMirrorPlane;
		}
	}
}
