using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Assets.Scripts.Craft.Wings.Physics;
using Unity.Burst;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Craft.Wings.Airfoils
{
	[BurstCompile]
	public class InterpolatedAirfoil : StandardAirfoil
	{
		private struct CustomData
		{
			public RuntimeAirfoil airfoil1;

			public RuntimeAirfoil airfoil2;

			public float t;
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void Evaluate_00005AD9_0024PostfixBurstDelegate(float chordReynolds, float freeStreamMach, in RuntimeAirfoil airfoil, out SlicePolar polar);

		internal static class Evaluate_00005AD9_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<Evaluate_00005AD9_0024PostfixBurstDelegate>(Evaluate).Value;
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

		private static FunctionPointer<RuntimeAirfoil.EvaluateAirfoilDelegate> _evaluateFunctionPointer;

		private IAirfoil _airfoilA;

		private IAirfoil _airfoilB;

		public override bool LeadingColocated
		{
			get
			{
				if (_airfoilA.LeadingColocated)
				{
					return _airfoilB.LeadingColocated;
				}
				return false;
			}
		}

		public override bool LeadingSmooth
		{
			get
			{
				if (_airfoilA.LeadingSmooth)
				{
					return _airfoilB.LeadingSmooth;
				}
				return false;
			}
		}

		public float Proportion { get; set; }

		public override bool TrailingColocated
		{
			get
			{
				if (_airfoilA.TrailingColocated)
				{
					return _airfoilB.TrailingColocated;
				}
				return false;
			}
		}

		public override bool TrailingSmooth
		{
			get
			{
				if (_airfoilA.TrailingSmooth)
				{
					return _airfoilB.TrailingSmooth;
				}
				return false;
			}
		}

		public override float LeadingEdgeRadius => math.lerp(_airfoilA.LeadingEdgeRadius, _airfoilB.LeadingEdgeRadius, Proportion);

		public InterpolatedAirfoil(IAirfoil airfoilA, IAirfoil airfoilB, float proportion)
		{
			_airfoilA = airfoilA;
			_airfoilB = airfoilB;
			Proportion = proportion;
		}

		public static InterpolatedAirfoil GetInterpolated(IAirfoil a, IAirfoil b, float t)
		{
			if (a is InterpolatedAirfoil interpolatedAirfoil)
			{
				if (b is InterpolatedAirfoil interpolatedAirfoil2)
				{
					if (interpolatedAirfoil._airfoilA == interpolatedAirfoil2._airfoilA && interpolatedAirfoil._airfoilB == interpolatedAirfoil2._airfoilB)
					{
						return new InterpolatedAirfoil(interpolatedAirfoil._airfoilA, interpolatedAirfoil._airfoilB, math.lerp(interpolatedAirfoil.Proportion, interpolatedAirfoil2.Proportion, t));
					}
				}
				else if (interpolatedAirfoil._airfoilB == b)
				{
					return new InterpolatedAirfoil(interpolatedAirfoil._airfoilA, interpolatedAirfoil._airfoilB, math.lerp(interpolatedAirfoil.Proportion, 1f, t));
				}
			}
			else
			{
				if (!(b is InterpolatedAirfoil interpolatedAirfoil3))
				{
					return new InterpolatedAirfoil(a, b, t);
				}
				if (interpolatedAirfoil3._airfoilA == a)
				{
					return new InterpolatedAirfoil(interpolatedAirfoil3._airfoilA, interpolatedAirfoil3._airfoilB, math.lerp(0f, interpolatedAirfoil3.Proportion, t));
				}
			}
			Debug.LogWarning($"InterpolatedAirfoil structure not understood - nesting: {a} {b} {t}");
			return new InterpolatedAirfoil(a, b, t);
		}

		public override bool Equals(object obj)
		{
			if (obj is InterpolatedAirfoil interpolatedAirfoil)
			{
				IAirfoil airfoilA = _airfoilA;
				IAirfoil airfoilB = _airfoilB;
				IAirfoil airfoilA2 = interpolatedAirfoil._airfoilA;
				IAirfoil airfoilB2 = interpolatedAirfoil._airfoilB;
				if (airfoilA == airfoilA2)
				{
					return airfoilB == airfoilB2;
				}
				return false;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(_airfoilA, _airfoilB, Proportion);
		}

		public override RuntimeAirfoil GetRuntimeAirfoil(List<IntPtr> mallocPtrs)
		{
			RuntimeAirfoil airfoil = new RuntimeAirfoil
			{
				function = (_evaluateFunctionPointer.IsCreated ? _evaluateFunctionPointer : (_evaluateFunctionPointer = BurstCompiler.CompileFunctionPointer<RuntimeAirfoil.EvaluateAirfoilDelegate>(Evaluate)))
			};
			StandardAirfoil.SetCustomData(ref airfoil, new CustomData
			{
				airfoil1 = _airfoilA.GetRuntimeAirfoil(mallocPtrs),
				airfoil2 = _airfoilB.GetRuntimeAirfoil(mallocPtrs),
				t = Proportion
			}, mallocPtrs);
			return airfoil;
		}

		public override float2 SamplePoint(float x)
		{
			return math.lerp(_airfoilA.SamplePoint(x), _airfoilB.SamplePoint(x), Proportion);
		}

		public override float WarpDensity(float x)
		{
			return math.lerp(_airfoilA.WarpDensity(x), _airfoilB.WarpDensity(x), Proportion);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RuntimeAirfoil.EvaluateAirfoilDelegate))]
		private static void Evaluate(float chordReynolds, float freeStreamMach, in RuntimeAirfoil airfoil, out SlicePolar polar)
		{
			Evaluate_00005AD9_0024BurstDirectCall.Invoke(chordReynolds, freeStreamMach, in airfoil, out polar);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void Evaluate_0024BurstManaged(float chordReynolds, float freeStreamMach, in RuntimeAirfoil airfoil, out SlicePolar polar)
		{
			ref readonly CustomData data = ref airfoil.GetData<CustomData>();
			data.airfoil1.function.Invoke(chordReynolds, freeStreamMach, in data.airfoil1, out var polar2);
			data.airfoil2.function.Invoke(chordReynolds, freeStreamMach, in data.airfoil2, out var polar3);
			polar = SlicePolar.Lerp(polar2, polar3, data.t);
		}
	}
}
