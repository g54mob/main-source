using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Physics
{
	public struct SliceAeroData
	{
		public float alpha;

		public float slipAngle;

		public float3 freeStreamVelocity;

		public float3 freeStreamDirection;

		public float freeStreamSpeed;

		public float freeStreamMach;

		public float reynoldsPerMeter;

		public float effectiveAlpha;

		public float effectiveChordLength;

		public float3 d_alpha_vel;

		public override readonly string ToString()
		{
			return $"a {alpha}, slip {slipAngle}\nvel {freeStreamVelocity}\ndir {freeStreamDirection}\nspd {freeStreamSpeed}, mach {freeStreamMach}, rpm {reynoldsPerMeter}, ecl {effectiveChordLength}\nd = {d_alpha_vel}";
		}
	}
}
