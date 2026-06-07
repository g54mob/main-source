using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Physics
{
	public struct SliceData
	{
		public RuntimeAirfoil airfoil;

		public float spanPosition;

		public float spanWidth;

		public float chordLength;

		public float3 quarterChordPos;

		public float3 airfoilRight;

		public float3 airfoilUp;

		public float3 airfoilForward;

		public StandardPhysicsFunctions.StandardAirfoilParams standardAirfoilParams;

		public float3 panelRootLeading;

		public float3 panelRootTrailing;

		public float3 panelTipLeading;

		public float3 panelTipTrailing;

		public readonly float3x3 AirfoilBasis => new float3x3(airfoilRight, airfoilUp, airfoilForward);

		public readonly float2 ZRange => new float2(quarterChordPos.z + chordLength * 0.25f, quarterChordPos.z - chordLength * 0.75f);

		public override readonly string ToString()
		{
			return $"qc-pos: {quarterChordPos}, sw {spanWidth}, cl {chordLength}\n{airfoilRight}\n{airfoilUp}\n{airfoilForward}";
		}
	}
}
