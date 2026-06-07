using System;
using Unity.Mathematics;

namespace Assets.Scripts.Design.Symmetry.Events
{
	public class SymmetryRadialAxisChangeEventArgs : EventArgs
	{
		public (float3 Axis, float3 Point) NewAxis { get; }

		public (float3 Axis, float3 Point) PreviousAxis { get; }

		public SymmetryRadialAxisChangeEventArgs((float3 Axis, float3 Point) previousAxis, (float3 Axis, float3 Point) newAxis)
		{
			PreviousAxis = previousAxis;
			NewAxis = newAxis;
		}
	}
}
