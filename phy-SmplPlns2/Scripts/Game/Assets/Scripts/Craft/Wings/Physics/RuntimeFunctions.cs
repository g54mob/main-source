using Assets.Scripts.Craft.MeshGen;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Physics
{
	public static class RuntimeFunctions
	{
		public static void AccumulateSectionForce(ref ForceJacobian wingAccumulator, ref ForceJacobian sliceOutput, in SliceData sliceData)
		{
			sliceOutput.Transform(sliceData.AirfoilBasis);
			sliceOutput.AdjustForPosition(sliceData.quarterChordPos);
			wingAccumulator += sliceOutput;
		}

		public static void CalculateAtmosphere(ref WingInputData data)
		{
			data.atmosphere = Atmosphere.ISA(data.altitude);
		}

		public static void EvaluateAirfoil(in SliceData slice, in SliceAeroData aero, out SlicePolar polar)
		{
			slice.airfoil.function.Invoke(aero.reynoldsPerMeter * slice.chordLength, aero.freeStreamMach, in slice.airfoil, out polar);
		}

		public static void EvaluatePolar(in WingInputData wingInput, in SliceData slice, in SlicePolar polar, in SliceAeroData aero, out ForceJacobian sliceOutput)
		{
			polar.Sample(aero.effectiveAlpha, aero.freeStreamMach, out var cL, out var cD, out var cM);
			float num = aero.freeStreamSpeed * aero.freeStreamSpeed * wingInput.atmosphere.density * aero.effectiveChordLength * slice.spanWidth * 0.5f;
			math.sincos(aero.effectiveAlpha - aero.alpha, out var s, out var c);
			float3 freeStreamDirection = aero.freeStreamDirection;
			freeStreamDirection.y = math.dot(math.float2(0f - s, c), aero.freeStreamDirection.zy);
			freeStreamDirection.z = math.dot(math.float2(c, s), aero.freeStreamDirection.zy);
			float3 float5 = math.left();
			float3 obj = math.cross(freeStreamDirection, float5);
			float3 v = (obj * cL.x + freeStreamDirection * cD.x) * num;
			float3 v2 = (obj * cL.y + freeStreamDirection * cD.y) * num;
			float3 v3 = float5 * (aero.effectiveChordLength * num * cM.x);
			float3 v4 = float5 * (aero.effectiveChordLength * num * cM.y);
			MathUtils.RemoveNaN(ref v);
			MathUtils.RemoveNaN(ref v3);
			MathUtils.RemoveNaN(ref v2);
			MathUtils.RemoveNaN(ref v4);
			sliceOutput = new ForceJacobian
			{
				force = v,
				torque = v3,
				d_force_vel = Matmul(v2, aero.d_alpha_vel),
				d_torque_vel = Matmul(v4, aero.d_alpha_vel),
				d_force_ang = 0f,
				d_torque_ang = 0f
			};
		}

		public static void FillAeroData(in WingInputData input, in SliceData slice, out SliceAeroData res)
		{
			float3 float5 = input.velocity + math.cross(input.angularVelocity, slice.quarterChordPos);
			float3x3 v = math.float3x3(slice.airfoilRight, slice.airfoilUp, slice.airfoilForward);
			res.freeStreamVelocity = math.mul(math.transpose(v), -float5);
			res.freeStreamSpeed = math.length(res.freeStreamVelocity);
			res.freeStreamDirection = res.freeStreamVelocity / res.freeStreamSpeed;
			res.freeStreamMach = res.freeStreamSpeed / input.atmosphere.speedOfSound;
			res.reynoldsPerMeter = res.freeStreamSpeed * input.atmosphere.inverseKinematicViscosity;
			float3 freeStreamVelocity = res.freeStreamVelocity;
			res.effectiveAlpha = (res.alpha = math.atan2(freeStreamVelocity.y, 0f - freeStreamVelocity.z));
			res.slipAngle = math.atan2(freeStreamVelocity.x, freeStreamVelocity.z);
			float num = 1f / (freeStreamVelocity.y * freeStreamVelocity.y + freeStreamVelocity.z * freeStreamVelocity.z);
			res.d_alpha_vel = math.float3(0f, freeStreamVelocity.z * num, (0f - freeStreamVelocity.y) * num);
			res.effectiveChordLength = slice.chordLength;
		}

		public static void TransformToBodySpace(ref ForceJacobian resultJacobian, in float3 wingPosition, in float3x3 wingRotation, float forceScale)
		{
			resultJacobian.Transform(wingRotation);
			resultJacobian.AdjustForPosition(wingPosition);
			resultJacobian *= forceScale;
		}

		private static float3x3 Matmul(float3 mat3x1, float3 mat1x3)
		{
			return math.float3x3(mat1x3.x * mat3x1, mat1x3.y * mat3x1, mat1x3.z * mat3x1);
		}
	}
}
