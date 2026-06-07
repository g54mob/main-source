using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Assets.Scripts.Craft.Wings.Physics;
using Unity.Burst;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Airfoils
{
	public static class NACAFoils
	{
		[BurstCompile]
		private class NACA4Digit : StandardAirfoil
		{
			private struct RuntimeData
			{
				public float camberHeight;

				public float camberPos;

				public StandardPhysicsFunctions.StandardAirfoilParams standardParams;
			}

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void Evaluate_00005AE4_0024PostfixBurstDelegate(float chordReynolds, float freeStreamMach, in RuntimeAirfoil airfoil, out SlicePolar polar);

			internal static class Evaluate_00005AE4_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<Evaluate_00005AE4_0024PostfixBurstDelegate>(Evaluate).Value;
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					nint result = 0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public unsafe static void Invoke(float chordReynolds, float freeStreamMach, in RuntimeAirfoil airfoil, out SlicePolar polar)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							((delegate* unmanaged[Cdecl]<float, float, ref RuntimeAirfoil, ref SlicePolar, void>)functionPointer)(chordReynolds, freeStreamMach, ref airfoil, ref polar);
							return;
						}
					}
					Evaluate_0024BurstManaged(chordReynolds, freeStreamMach, in airfoil, out polar);
				}
			}

			private static readonly float3[] DesignParameters = new float3[6]
			{
				new float3(0.9f, 2.81f, -0.118f),
				new float3(0.8f, 1.8f, -0.184f),
				new float3(0.76f, 0.74f, -0.157f),
				new float3(0.75f, 0f, -0.187f),
				new float3(0.76f, -0.74f, -0.222f),
				new float3(0.8f, -1.6f, -0.266f)
			};

			private static FunctionPointer<RuntimeAirfoil.EvaluateAirfoilDelegate> _evaluateFunctionPointer;

			private float _camberHeight;

			private float _camberPosition;

			private float _thicknessScale;

			public override bool LeadingColocated => true;

			public override bool LeadingSmooth => true;

			public override bool TrailingColocated => true;

			public override bool TrailingSmooth => false;

			public override float LeadingEdgeRadius => 1.1019f * _thicknessScale * _thicknessScale;

			public NACA4Digit(int a, int b, int cd)
			{
				if (cd == 0)
				{
					throw new ArgumentException("NACA4Digit: Cannot have a wing with zero thickness");
				}
				_camberHeight = (float)a * 0.01f;
				_camberPosition = (float)b * 0.1f;
				_thicknessScale = (float)cd * 0.01f;
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(RuntimeAirfoil.EvaluateAirfoilDelegate))]
			public static void Evaluate(float chordReynolds, float freeStreamMach, in RuntimeAirfoil airfoil, out SlicePolar polar)
			{
				Evaluate_00005AE4_0024BurstDirectCall.Invoke(chordReynolds, freeStreamMach, in airfoil, out polar);
			}

			public override bool Equals(object obj)
			{
				if (obj is NACA4Digit nACA4Digit)
				{
					float thicknessScale = _thicknessScale;
					float camberHeight = _camberHeight;
					float camberPosition = _camberPosition;
					float thicknessScale2 = nACA4Digit._thicknessScale;
					float camberHeight2 = nACA4Digit._camberHeight;
					float camberPosition2 = nACA4Digit._camberPosition;
					if (thicknessScale == thicknessScale2 && camberHeight == camberHeight2)
					{
						return camberPosition == camberPosition2;
					}
					return false;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return HashCode.Combine(_thicknessScale, _camberHeight, _camberPosition);
			}

			public override RuntimeAirfoil GetRuntimeAirfoil(List<IntPtr> mallocPtrs)
			{
				RuntimeAirfoil airfoil = new RuntimeAirfoil
				{
					function = (_evaluateFunctionPointer.IsCreated ? _evaluateFunctionPointer : (_evaluateFunctionPointer = BurstCompiler.CompileFunctionPointer<RuntimeAirfoil.EvaluateAirfoilDelegate>(Evaluate)))
				};
				StandardAirfoil.SetCustomData(ref airfoil, new RuntimeData
				{
					standardParams = StandardPhysicsFunctions.ComputeStandardAirfoilParameters(this),
					camberHeight = _camberHeight,
					camberPos = _camberPosition
				}, mallocPtrs);
				return airfoil;
			}

			public override float2 SamplePoint(float x)
			{
				float num = 0f;
				float num2;
				if (x != 1f)
				{
					num = FourDigitThickness(x, _thicknessScale);
					num2 = TwoDigitCamber(x, _camberHeight, _camberPosition);
				}
				else
				{
					num2 = TwoDigitCamber(1.0089f, _camberHeight, _camberPosition);
				}
				return math.float2(num2 + num, num2 - num);
			}

			public override float WarpDensity(float x)
			{
				return x * x;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal static void Evaluate_0024BurstManaged(float chordReynolds, float freeStreamMach, in RuntimeAirfoil airfoil, out SlicePolar polar)
			{
				RuntimeData data = airfoil.GetData<RuntimeData>();
				float num = StandardPhysicsFunctions.ComputeStandardLiftGradient(in data.standardParams, chordReynolds);
				float x = math.clamp(data.camberPos - 2f, 0f, 5f);
				float3 float5 = math.lerp(DesignParameters[(int)math.floor(x)], DesignParameters[(int)math.ceil(x)], math.frac(x));
				float5 *= data.camberHeight * 1.6666666f;
				float5.y *= math.radians(1f);
				float alphaZero = StandardPhysicsFunctions.AlphaZeroFromDesignParams(num, float5.x, float5.y);
				float2 float6 = StandardPhysicsFunctions.ComputeStandardMinMaxLift(in data.standardParams, chordReynolds);
				polar = new SlicePolar
				{
					liftGradient = num,
					alphaZero = alphaZero,
					stallPositive = 
					{
						liftMax = float6.y,
						stallSmoothness = float6.y / num * 0.2f
					},
					stallNegative = 
					{
						liftMax = 0f - float6.x,
						stallSmoothness = float6.y / num * 0.2f
					},
					stalledNormalForceMax = 1.5f,
					zeroLiftMoment = 0f,
					aerodynamicCentre = data.standardParams.aerodynamicCentre,
					additionalMoment = 0f
				};
				polar.aerodynamicCentre = data.standardParams.aerodynamicCentre;
				polar.dragCurve = new DragCurve
				{
					criticalAlphaPositive = polar.stallPositive.CalculateCriticalAngle(alphaZero, num),
					criticalAlphaNegative = polar.stallNegative.CalculateCriticalAngle(alphaZero, num),
					zeroLiftDrag = StandardPhysicsFunctions.ComputeStandardZeroLiftDrag(chordReynolds, freeStreamMach, in data.standardParams),
					viscousDragDueToLift = 0.02f
				};
			}
		}

		private class NACA5Digit : StandardAirfoil
		{
			private float _k;

			private float _r;

			private float _thicknessScale;

			public override bool LeadingColocated => true;

			public override bool LeadingSmooth => true;

			public override bool TrailingColocated => true;

			public override bool TrailingSmooth => false;

			public override float LeadingEdgeRadius
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public NACA5Digit(int a, int b, int cd)
			{
				_thicknessScale = (float)cd * 0.01f;
				switch (b)
				{
				case 1:
					_r = 0.058f;
					_k = 60.233334f;
					break;
				case 2:
					_r = 0.126f;
					_k = 8.606667f;
					break;
				case 3:
					_r = 0.2025f;
					_k = 2.6595f;
					break;
				case 4:
					_r = 0.29f;
					_k = 1.1071666f;
					break;
				case 5:
					_r = 0.391f;
					_k = 0.53833336f;
					break;
				default:
					throw new NotImplementedException($"NACA 5-digit non-reflex value for 4th digit {b} not supported.");
				}
			}

			public override bool Equals(object obj)
			{
				if (obj is NACA5Digit nACA5Digit)
				{
					float thicknessScale = _thicknessScale;
					float r = _r;
					float k = _k;
					float thicknessScale2 = nACA5Digit._thicknessScale;
					float r2 = nACA5Digit._r;
					float k2 = nACA5Digit._k;
					if (thicknessScale == thicknessScale2 && r == r2)
					{
						return k == k2;
					}
					return false;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return HashCode.Combine(_thicknessScale, _r, _k);
			}

			public override RuntimeAirfoil GetRuntimeAirfoil(List<IntPtr> mallocPtrs)
			{
				throw new NotImplementedException();
			}

			public override float2 SamplePoint(float x)
			{
				float num = 0f;
				float num2;
				if (x != 1f)
				{
					num = FourDigitThickness(x, _thicknessScale);
					num2 = ThreeDigitCamber(x, _k, _r);
				}
				else
				{
					num2 = ThreeDigitCamber(1.0089f, _k, _r);
				}
				return math.float2(num2 + num, num2 - num);
			}

			public override float WarpDensity(float x)
			{
				return x * x;
			}
		}

		private const float FourDigitThicknessIntercept = 1.0089f;

		public static IAirfoil ParseNACA(string nacaString)
		{
			if (nacaString.StartsWith("NACA", StringComparison.OrdinalIgnoreCase))
			{
				int num = nacaString.Length - 4;
				int num2 = nacaString.IndexOf('-');
				if (num2 != -1)
				{
					num = num2 - 4;
				}
				switch (num)
				{
				case 4:
					if (num2 == -1)
					{
						if (int.TryParse(nacaString.AsSpan(4, 1), out var result4) && int.TryParse(nacaString.AsSpan(5, 1), out var result5) && int.TryParse(nacaString.AsSpan(6, 2), out var result6))
						{
							return new NACA4Digit(result4, result5, result6);
						}
						break;
					}
					throw new NotImplementedException("NACA 4-digit (Modified) airfoils are not supported.");
				case 5:
				{
					if (num2 != -1)
					{
						break;
					}
					bool flag = false;
					if (nacaString[6] == '1')
					{
						flag = true;
					}
					else if (nacaString[6] != '0')
					{
						throw new ArgumentException($"NACA airfoil 3-digit mode {nacaString[6]} not supported.");
					}
					if (int.TryParse(nacaString.AsSpan(4, 1), out var result) && int.TryParse(nacaString.AsSpan(5, 1), out var result2) && int.TryParse(nacaString.AsSpan(7, 2), out var result3))
					{
						if (flag)
						{
							throw new NotImplementedException();
						}
						return new NACA5Digit(result, result2, result3);
					}
					break;
				}
				}
			}
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static float FourDigitThickness(float x, float tc)
		{
			return tc * (1.4845f * math.sqrt(x) + x * (-0.63f + x * (-1.758f + x * (1.4215f + x * -0.5075f))));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static float ThreeDigitCamber(float x, float k, float r)
		{
			if (x < r)
			{
				return k * x * (r * r * (3f - r) + x * (x - 3f * r));
			}
			return k * r * r * r * (1f - x);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static float TwoDigitCamber(float x, float height, float pos)
		{
			if (x < pos)
			{
				float num = x / pos;
				return height * num * (2f - num);
			}
			float num2 = 1f - pos;
			return height * (1f + 2f * pos * (x - 1f) - x * x) / (num2 * num2);
		}
	}
}
