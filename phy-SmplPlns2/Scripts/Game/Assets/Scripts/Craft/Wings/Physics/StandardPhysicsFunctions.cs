using System;
using Assets.Scripts.Craft.MeshGen;
using Assets.Scripts.Craft.Wings.Airfoils;
using Assets.Scripts.Craft.Wings.Utilities;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Physics
{
	public static class StandardPhysicsFunctions
	{
		public struct FlapPhysics
		{
			private static readonly SharedStatic<FlapPhysics> SharedStatic = SharedStatic<FlapPhysics>.GetOrCreateUnsafe(0u, -6853965897949319229L, 0L);

			private static StaticNativeArray<float4> _splineData_6111_40;

			private static bool _hasInit = false;

			[ReadOnly]
			private MathUtils.Spline _spline_6111_40_010;

			[ReadOnly]
			private MathUtils.Spline _spline_6111_40_050;

			public static ref readonly FlapPhysics Instance => ref SharedStatic.Data;

			[BurstDiscard]
			public static void EnsureInit()
			{
				if (!_hasInit)
				{
					_splineData_6111_40 = CreateData();
					SharedStatic.Data = new FlapPhysics
					{
						_spline_6111_40_050 = new MathUtils.Spline
						{
							data = _splineData_6111_40.Array.Slice(0, 5),
							preWrapMode = MathUtils.Spline.WrapMode.Clamp,
							postWrapMode = MathUtils.Spline.WrapMode.Extrapolate
						},
						_spline_6111_40_010 = new MathUtils.Spline
						{
							data = _splineData_6111_40.Array.Slice(5, 4),
							preWrapMode = MathUtils.Spline.WrapMode.Clamp,
							postWrapMode = MathUtils.Spline.WrapMode.Extrapolate
						}
					};
				}
			}

			public static float SampleFig39a(float cfc, float tc)
			{
				float2 float5 = math.float2(0.023f, -0.09f);
				float2 float6 = math.float2(0.1894f - 0.06f * tc, 3.23f + 2.3f * tc);
				float2 float7 = math.float2(0.5f, 4.85f + 7.2f * tc);
				return (float.IsNaN(MathUtils.InverseBezier(float5.x, float6.x, float7.x, cfc, 0f, 1.5f)) ? 0f : MathUtils.Bezier(float5.y, float6.y, float7.y, cfc)) * 0.75f + 1.5f;
			}

			public static float SampleFig39b(float cfc, float lg_correction)
			{
				float num = new MathUtils.Linear(-1.1600001f, 2.16f)[lg_correction];
				float num2 = (new MathUtils.Quadratic(-1.69344f, 4.3787f, -1.68934f)[lg_correction] - num) * 2.2222223f;
				return new MathUtils.Linear(num - num2 * 0.05f, num2)[cfc];
			}

			public static float SampleFig50(float chordRatio)
			{
				return new MathUtils.Quadratic(0f, 0.0107007f, 0.0585986f)[chordRatio];
			}

			public static float SampleFig14(float chordRatio)
			{
				return -8.87104f * chordRatio + 10.4243f * math.pow(chordRatio, 0.7f);
			}

			public static float SampleFig15Slat(float radThicknessRatio)
			{
				if (!(radThicknessRatio < 0.077f))
				{
					if (!(radThicknessRatio < 0.1062f))
					{
						return 2.67712f - 9.3985f * radThicknessRatio;
					}
					return 0.0117484f + radThicknessRatio * (38.90736f + radThicknessRatio * -218.53288f);
				}
				return 0.5634f + 10.95f * radThicknessRatio;
			}

			public static float SampleFig16(float deflectionAngleDeg)
			{
				if (!(deflectionAngleDeg < 15f))
				{
					return new MathUtils.Quadratic(1.17975f, -0.00356328f, -0.0005325f)[math.clamp(deflectionAngleDeg, 15f, 43f)];
				}
				return 1f;
			}

			public static float SampleFig36(float flapChordRatio)
			{
				return flapChordRatio * new MathUtils.Quadratic(-0.0041954434f, -0.029659031f, 0.045934748f)[flapChordRatio];
			}

			public void PlainFlapPhysics(float deflection, float surfaceFraction, float coverage, in SliceData data, in SliceAeroData aero, out float liftIncrement, out float clMaxIncrement)
			{
				liftIncrement = deflection * SampleFig39a(surfaceFraction, data.standardAirfoilParams.maxThickness);
				float lg_correction = ComputeStandardLiftGradientCorrection(in data.standardAirfoilParams, aero.effectiveChordLength * aero.reynoldsPerMeter);
				liftIncrement *= SampleFig39b(surfaceFraction, lg_correction);
				liftIncrement *= SampleFig6111_40(surfaceFraction, math.abs(deflection));
				clMaxIncrement = ComputeDeltaClMaxBaseD(data.standardAirfoilParams.maxThickness);
				clMaxIncrement *= ComputeDeltaClMaxCorrection1B(surfaceFraction);
				clMaxIncrement *= ComputeDeltaClMaxCorrection2A(math.abs(deflection)) * math.sign(deflection);
				liftIncrement *= coverage;
				clMaxIncrement *= coverage;
			}

			public float SampleFig6111_40(float cfc, float deflection)
			{
				deflection = math.min(deflection, MathF.PI / 2f);
				float t = math.unlerp(0.1f, 0.5f, math.clamp(cfc, 0f, 0.5f));
				return math.lerp(_spline_6111_40_010.Sample(deflection), _spline_6111_40_050.Sample(deflection), t);
			}

			[BurstDiscard]
			private static StaticNativeArray<float4> CreateData()
			{
				return new StaticNativeArray<float4>(new float4[9]
				{
					new float4(0.17f, 1f, -7f / 18f, -7f / 18f),
					new float4(0.317f, 0.76f, -3.5f, -3.5f),
					new float4(0.406f, 0.614f, -89f / 90f, -89f / 90f),
					new float4(0.66f, 0.498f, -29f / 90f, -29f / 90f),
					new float4(1.0433f, 0.4225f, -11f / 60f, -11f / 60f),
					new float4(0.17f, 1f, 2f / 45f, 2f / 45f),
					new float4(0.394f, 0.833f, -1.4444444f, -1.4444444f),
					new float4(0.59f, 0.6815f, -79f / 180f, -79f / 180f),
					new float4(1.0433f, 0.565f, -1f / 6f, -1f / 6f)
				});
			}
		}

		public struct StandardAirfoilParams
		{
			public float leadingEdgeRadius;

			public float deltaYParameter;

			public float maxThickness;

			public float maxThicknessLocation;

			public float meanThickness;

			public float trailingGradient;

			public float uncorrectedMaxLift;

			public float uncorrectedMinLift;

			public float aerodynamicCentre;
		}

		public static class LookupTables
		{
			private static readonly float3[] ClMaxD1LUT = new float3[48]
			{
				new float3(0f, 0f, 0f),
				new float3(0.017f, 0.055f, 0.055f),
				new float3(0.128f, 0.196f, 0.196f),
				new float3(0.232f, 0.32f, 0.32f),
				new float3(0.329f, 0.401f, 0.401f),
				new float3(0.224f, 0.306f, 0.306f),
				new float3(0.115f, 0.164f, 0.164f),
				new float3(0.07f, 0.106f, 0.106f),
				new float3(0.072f, 0.103f, 0.103f),
				new float3(0.06f, 0.098f, 0.098f),
				new float3(0.031f, 0.057f, 0.057f),
				new float3(0f, 0f, 0f),
				new float3(0f, 0f, 0f),
				new float3(0f, 0f, 0f),
				new float3(0f, 0f, 0.498f),
				new float3(0.145f, 0.34f, 0.669f),
				new float3(0.291f, 0.461f, 0.604f),
				new float3(0.314f, 0.396f, 0.44f),
				new float3(0.22f, 0.251f, 0.286f),
				new float3(0.156f, 0.17f, 0.185f),
				new float3(0.149f, 0.149f, 0.149f),
				new float3(0.145f, 0.164f, 0.175f),
				new float3(0.094f, 0.101f, 0.116f),
				new float3(0f, 0f, 0f),
				new float3(0f, 0f, 0f),
				new float3(0f, 0f, 0f),
				new float3(0f, 0f, 0.23f),
				new float3(0f, 0.229f, 0.428f),
				new float3(0.168f, 0.325f, 0.448f),
				new float3(0.206f, 0.31f, 0.376f),
				new float3(0.133f, 0.176f, 0.242f),
				new float3(0.058f, 0.088f, 0.121f),
				new float3(0.0515f, 0.074f, 0.095f),
				new float3(0.053f, 0.077f, 0.11f),
				new float3(0.03f, 0.051f, 0.092f),
				new float3(0f, 0f, 0f),
				new float3(0f, 0f, 0f),
				new float3(0f, 0f, 0f),
				new float3(0f, 0f, 0.187f),
				new float3(0.031f, 0.18f, 0.36f),
				new float3(0.096f, 0.274f, 0.448f),
				new float3(0.153f, 0.303f, 0.447f),
				new float3(0.139f, 0.215f, 0.288f),
				new float3(0.088f, 0.146f, 0.21f),
				new float3(0.06f, 0.135f, 0.199f),
				new float3(0.095f, 0.17f, 0.24f),
				new float3(0.078f, 0.121f, 0.206f),
				new float3(0f, 0.055f, 0.098f)
			};

			private static readonly float3[] ClMaxD2LUT = new float3[10]
			{
				new float3(0.148f, 0.148f, 0.148f),
				new float3(0.171f, 0.171f, 0.171f),
				new float3(0.194f, 0.194f, 0.194f),
				new float3(0.205f, 0.205f, 0.205f),
				new float3(0.182f, 0.182f, 0.182f),
				new float3(0.119f, 0.119f, 0.119f),
				new float3(0.054f, 0.052f, 0.076f),
				new float3(-0.014f, 0.023f, 0.098f),
				new float3(-0.034f, 0.038f, 0.124f),
				new float3(-0.045f, 0.022f, 0.097f)
			};

			private static readonly float3[] ClMaxD3LUT = new float3[9]
			{
				new float3(0.117f, 0.003f, -0.093f),
				new float3(0.14f, -0.08f, -0.143f),
				new float3(0.067f, -0.085f, -0.146f),
				new float3(0.004f, -0.039f, -0.094f),
				new float3(0.098f, -0.035f, -0.108f),
				new float3(0.173f, -0.07f, -0.203f),
				new float3(0.195f, -0.11f, -0.244f),
				new float3(0.191f, -0.13f, -0.26f),
				new float3(0.179f, -0.154f, -0.27f)
			};

			public static float SampleClMaxD1(float camberAmount, float camberPos, float deltaY)
			{
				if (camberAmount == 0f)
				{
					return 0f;
				}
				deltaY = math.clamp(deltaY * 2f, 0f, 11f);
				int num = (int)math.floor(deltaY);
				int num2 = (int)math.ceil(deltaY);
				float t = math.frac(deltaY);
				camberPos = math.clamp(camberPos * 10f, 1.5f, 5f);
				float num3 = ((camberPos < 3f) ? 1.5f : math.floor(camberPos));
				int num4 = 12 * ((!(camberPos < 3f)) ? ((int)math.floor(camberPos) - 2) : 0);
				int num5 = 12 * math.max((int)math.ceil(camberPos) - 2, 1);
				float num6 = math.max(math.ceil(camberPos), 3f);
				float3 float5 = math.lerp(ClMaxD1LUT[num4 + num], ClMaxD1LUT[num4 + num2], t);
				float3 end = math.lerp(ClMaxD1LUT[num5 + num], ClMaxD1LUT[num5 + num2], t);
				float3 yzw = ((num6 == num3) ? float5 : math.lerp(float5, end, math.unlerp(num3, num6, camberPos)));
				float4 float6 = math.float4(0f, yzw);
				camberAmount = math.clamp(camberAmount * 0.5f, 0f, 3f);
				return math.lerp(float6[(int)math.floor(camberAmount)], float6[(int)math.ceil(camberAmount)], math.frac(camberAmount));
			}

			public static float SampleCLMaxD2(float maxThicknessPos, float deltaY)
			{
				deltaY = math.clamp(deltaY * 2f, 0f, 9f);
				float4 float5 = 0f;
				float5.yzw = math.lerp(ClMaxD2LUT[(int)math.floor(deltaY)], ClMaxD2LUT[(int)math.ceil(deltaY)], math.frac(deltaY));
				maxThicknessPos = math.clamp((maxThicknessPos - 0.3f) * 0.2f, 0f, 3f);
				return math.lerp(float5[(int)math.floor(maxThicknessPos)], float5[(int)math.ceil(maxThicknessPos)], math.frac(maxThicknessPos));
			}

			public static float SampleCLMaxD3(float chordRe, float deltaY)
			{
				deltaY = math.clamp((deltaY - 1f) * 2f, 0f, 7.99f);
				float4 float5 = 0f;
				float5.xyw = math.lerp(ClMaxD3LUT[(int)math.floor(deltaY)], ClMaxD3LUT[(int)math.ceil(deltaY)], math.frac(deltaY));
				float num = math.clamp(math.log10(chordRe), 3f, 25f);
				int num2 = math.clamp((int)math.floor(num * (1f / 3f)) - 1, 0, 2);
				int num3 = math.clamp((int)math.ceil(num * (1f / 3f)) - 1, 1, 3);
				float4 float6 = math.float4(3f, 6f, 9f, 25f);
				if (num2 != num3)
				{
					return math.lerp(float5[num2], float5[num3], math.unlerp(float6[num2], float6[num3], num));
				}
				return float5[num2];
			}
		}

		public static float AlphaZeroFromDesignParams(float liftGradient, float designLift, float designLiftAlpha)
		{
			return designLiftAlpha - designLift / liftGradient;
		}

		public static float ComputeDeltaClMaxBaseA(float thickness)
		{
			float num = math.clamp(thickness * 100f, 0f, 20f);
			return 1.0006014f + num * (0.017165696f + num * (-0.0029546912f + num * (0.00069429877f + num * -2.3856352E-05f)));
		}

		public static float ComputeDeltaClMaxBaseB(float thickness)
		{
			float num = math.clamp(thickness * 100f, 0f, 20f);
			return 0.99420977f + num * (0.020109653f + num * (-0.007094333f + num * (0.0010843289f + num * -3.4036275E-05f)));
		}

		public static float ComputeDeltaClMaxBaseC(float thickness)
		{
			float num = math.clamp(thickness * 100f, 0f, 20f);
			return 0.99228674f + num * (0.021780595f + num * (-0.009394158f + num * (0.001302229f + num * -4.000947E-05f)));
		}

		public static float ComputeDeltaClMaxBaseD(float thickness)
		{
			float num = math.clamp(thickness * 100f, 0f, 20f);
			return 0.9998231f + num * (-0.015542846f + num * (0.016579175f + num * (-0.005565221f + num * (0.00060728774f + num * (-2.5669306E-05f + num * 3.7173203E-07f)))));
		}

		public static float ComputeDeltaClMaxCorrection1A(float flapChord)
		{
			return math.clamp(flapChord, 0f, 0.4f) * 4f;
		}

		public static float ComputeDeltaClMaxCorrection1B(float flapChord)
		{
			float num = math.sqrt(math.clamp(flapChord, 0f, 0.4f));
			return num * (0.9239936f + num * (5.7210026f + num * -7.0263863f));
		}

		public static float ComputeDeltaClMaxCorrection2A(float deflection)
		{
			float num = math.clamp(math.degrees(deflection), 0f, 60f);
			return num * (0.037627116f + num * (-0.0004720635f + num * 2.0462962E-06f));
		}

		public static float ComputeDeltaClMaxCorrection2B(float deflection)
		{
			float num = math.clamp(math.degrees(deflection), 0f, 60f);
			return 0.18228571f + num * (0.029922858f + num * -0.00026857143f);
		}

		public static float ComputeDeltaClMaxCorrection2C(float deflection)
		{
			float num = math.clamp(math.degrees(deflection), 0f, 60f);
			return 0.18789285f + num * (0.031613216f + num * -0.00029660715f);
		}

		public static float ComputeDeltaClMaxCorrection2D(float deflection)
		{
			float num = math.clamp(math.degrees(deflection), 0f, 60f);
			return 0.4001143f + num * (0.025297143f + num * -0.00025142857f);
		}

		public static StandardAirfoilParams ComputeStandardAirfoilParameters(IAirfoil airfoil)
		{
			StandardAirfoilParams airfoilParams = new StandardAirfoilParams
			{
				leadingEdgeRadius = airfoil.LeadingEdgeRadius
			};
			float num = 0f;
			float2 float5 = 0f;
			float2 float6 = 0f;
			float num2 = 0f;
			for (int i = 0; i <= 20; i++)
			{
				float x = (float)i * 0.05f;
				float2 float7 = airfoil.SamplePoint(x);
				float num3 = float7.x - float7.y;
				float num4 = (float7.x + float7.y) * 0.5f;
				num2 += num3;
				if (float5.y < num3)
				{
					float5 = new float2(x, num3);
				}
				if (float6.y < num4)
				{
					float6 = new float2(x, num4);
				}
				if (i == 18)
				{
					num = num3;
				}
			}
			airfoilParams.meanThickness = num2 * 0.05f;
			airfoilParams.maxThickness = float5.y;
			airfoilParams.maxThicknessLocation = float5.x;
			float2 float8 = airfoil.SamplePoint(0.99f);
			float num5 = float8.x - float8.y;
			airfoilParams.trailingGradient = (num - num5) * 5.5555553f;
			airfoilParams.aerodynamicCentre = ComputeSectionAerodynamicCentre(in airfoilParams);
			airfoilParams.deltaYParameter = (airfoil.SamplePoint(0.06f).x - airfoil.SamplePoint(0.0015f).x) * 100f;
			float num6 = math.clamp(airfoilParams.deltaYParameter, 0f, 4.3f);
			float num7 = math.max(0.8f, 0.45f * num6 + 0.3f);
			if (num6 > 2f)
			{
				num7 = math.min(num7, 0.87f + 1.6f * float5.x + (1.1f * float5.x - 0.33f) * (num6 - 0.35f) * (num6 - 0.35f));
			}
			float num8 = LookupTables.SampleClMaxD1(float6.y, float6.x, airfoilParams.deltaYParameter);
			float num9 = LookupTables.SampleCLMaxD2(float5.x, airfoilParams.deltaYParameter);
			airfoilParams.uncorrectedMaxLift = num7 + num8 + num9;
			airfoilParams.uncorrectedMinLift = 0f - num7 + num8 - num9;
			return airfoilParams;
		}

		public static float ComputeStandardLiftGradient(in StandardAirfoilParams airfoil, float chordRe)
		{
			float num = 5.0315f * airfoil.maxThickness + 6.2788f;
			float num2 = ComputeStandardLiftGradientCorrection(in airfoil, chordRe);
			return 1.05f * num * num2;
		}

		public static float ComputeStandardLiftGradientCorrection(in StandardAirfoilParams airfoil, float chordRe)
		{
			float num = math.clamp(airfoil.trailingGradient, 0.05f, 0.25f);
			float num2 = math.clamp(math.log10(chordRe), 6f, 9f);
			float num3 = math.min(0.705167f + 0.9527f * num2, 1f);
			float num4 = 3.07667f - 0.34f * num2;
			float num5 = 2.695f - 2.5f * num4;
			return num3 + num * (num4 + num * num5);
		}

		public static float2 ComputeStandardMinMaxLift(in StandardAirfoilParams airfoil, float chordRe)
		{
			float num = LookupTables.SampleCLMaxD3(chordRe, airfoil.deltaYParameter);
			return math.float2(airfoil.uncorrectedMinLift - num, airfoil.uncorrectedMaxLift + num);
		}

		public static float ComputeStandardSkinFriction(float chordRe, float mach)
		{
			float num = math.clamp(math.log10(chordRe), 4f, 10f);
			float num2 = 0.00694f - math.min(mach, 5f) * 0.00039f - math.clamp(mach - 1f, 0f, 5f) * 0.00072f;
			float num3 = 0.00155f - math.min(mach, 5f) * 9.6E-05f - math.clamp(mach - 1f, 0f, 3f) * 0.00017f;
			float num4 = ((mach > 1f) ? 5.6f : 7f);
			float num5 = math.log(num3 / num2) * ((mach > 1f) ? (-1.8552996f) : (-2.2124622f));
			float num6 = num2 * math.pow(num4, num5);
			return math.pow(num - 5f + num4, 0f - num5) * num6;
		}

		public static float ComputeStandardZeroLiftDrag(float chordRe, float mach, in StandardAirfoilParams airfoil)
		{
			float num = ComputeStandardSkinFriction(chordRe, mach);
			float num2 = ((airfoil.maxThicknessLocation >= 0.3f) ? 1.2f : 2f);
			return num * (1f + num2 * airfoil.meanThickness + 100f * (airfoil.meanThickness * airfoil.meanThickness * airfoil.meanThickness * airfoil.meanThickness)) * 2f;
		}

		public static float ComputePlainSplitFlapIncrementalLoadPressureLocation(float flapChordRatio)
		{
			return 0.5f - 0.25f * flapChordRatio;
		}

		public static float ComputeSlottedFlapIncrementalLoadPressureLocation()
		{
			return 0.44f;
		}

		public static float ComputeSectionAerodynamicCentre(float thicknessRatio, float trailingEdgeAngle)
		{
			float start = new MathUtils.Quadratic(26f, -0.1244f, -0.0013f)[trailingEdgeAngle];
			float end = new MathUtils.Quadratic(28.2f, -0.121f, -5.6E-05f)[trailingEdgeAngle];
			float x = math.unlerp(0.06f, 0.21f, thicknessRatio);
			x = math.pow(x, 0.85f);
			return math.clamp(math.lerp(start, end, x) * 0.01f, 0.22f, 0.28f);
		}

		public static float ComputeSectionAerodynamicCentre(in StandardAirfoilParams airfoilParams)
		{
			float x = 2f * math.atan(airfoilParams.trailingGradient);
			return ComputeSectionAerodynamicCentre(airfoilParams.maxThickness, math.degrees(x));
		}
	}
}
