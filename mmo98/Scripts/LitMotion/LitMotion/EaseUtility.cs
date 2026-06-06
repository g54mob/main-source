using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Mathematics;

namespace LitMotion
{
	[BurstCompile]
	public static class EaseUtility
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float Evaluate_00000017_0024PostfixBurstDelegate(float t, Ease ease);

		internal static class Evaluate_00000017_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<Evaluate_00000017_0024PostfixBurstDelegate>(Evaluate).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float t, Ease ease)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, Ease, float>)functionPointer)(t, ease);
					}
				}
				return Evaluate_0024BurstManaged(t, ease);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float Linear_00000018_0024PostfixBurstDelegate(float x);

		internal static class Linear_00000018_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<Linear_00000018_0024PostfixBurstDelegate>(Linear).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return Linear_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float InSine_00000019_0024PostfixBurstDelegate(float x);

		internal static class InSine_00000019_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<InSine_00000019_0024PostfixBurstDelegate>(InSine).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return InSine_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float OutSine_0000001A_0024PostfixBurstDelegate(float x);

		internal static class OutSine_0000001A_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<OutSine_0000001A_0024PostfixBurstDelegate>(OutSine).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return OutSine_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float InOutSine_0000001B_0024PostfixBurstDelegate(float x);

		internal static class InOutSine_0000001B_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<InOutSine_0000001B_0024PostfixBurstDelegate>(InOutSine).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return InOutSine_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float InQuad_0000001C_0024PostfixBurstDelegate(float x);

		internal static class InQuad_0000001C_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<InQuad_0000001C_0024PostfixBurstDelegate>(InQuad).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return InQuad_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float OutQuad_0000001D_0024PostfixBurstDelegate(float x);

		internal static class OutQuad_0000001D_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<OutQuad_0000001D_0024PostfixBurstDelegate>(OutQuad).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return OutQuad_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float InOutQuad_0000001E_0024PostfixBurstDelegate(float x);

		internal static class InOutQuad_0000001E_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<InOutQuad_0000001E_0024PostfixBurstDelegate>(InOutQuad).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return InOutQuad_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float InCubic_0000001F_0024PostfixBurstDelegate(float x);

		internal static class InCubic_0000001F_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<InCubic_0000001F_0024PostfixBurstDelegate>(InCubic).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return InCubic_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float OutCubic_00000020_0024PostfixBurstDelegate(float x);

		internal static class OutCubic_00000020_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<OutCubic_00000020_0024PostfixBurstDelegate>(OutCubic).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return OutCubic_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float InOutCubic_00000021_0024PostfixBurstDelegate(float x);

		internal static class InOutCubic_00000021_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<InOutCubic_00000021_0024PostfixBurstDelegate>(InOutCubic).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return InOutCubic_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float InQuart_00000022_0024PostfixBurstDelegate(float x);

		internal static class InQuart_00000022_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<InQuart_00000022_0024PostfixBurstDelegate>(InQuart).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return InQuart_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float OutQuart_00000023_0024PostfixBurstDelegate(float x);

		internal static class OutQuart_00000023_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<OutQuart_00000023_0024PostfixBurstDelegate>(OutQuart).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return OutQuart_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float InOutQuart_00000024_0024PostfixBurstDelegate(float x);

		internal static class InOutQuart_00000024_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<InOutQuart_00000024_0024PostfixBurstDelegate>(InOutQuart).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return InOutQuart_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float InQuint_00000025_0024PostfixBurstDelegate(float x);

		internal static class InQuint_00000025_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<InQuint_00000025_0024PostfixBurstDelegate>(InQuint).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return InQuint_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float OutQuint_00000026_0024PostfixBurstDelegate(float x);

		internal static class OutQuint_00000026_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<OutQuint_00000026_0024PostfixBurstDelegate>(OutQuint).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return OutQuint_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float InOutQuint_00000027_0024PostfixBurstDelegate(float x);

		internal static class InOutQuint_00000027_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<InOutQuint_00000027_0024PostfixBurstDelegate>(InOutQuint).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return InOutQuint_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float InExpo_00000028_0024PostfixBurstDelegate(float x);

		internal static class InExpo_00000028_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<InExpo_00000028_0024PostfixBurstDelegate>(InExpo).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return InExpo_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float OutExpo_00000029_0024PostfixBurstDelegate(float x);

		internal static class OutExpo_00000029_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<OutExpo_00000029_0024PostfixBurstDelegate>(OutExpo).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return OutExpo_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float InOutExpo_0000002A_0024PostfixBurstDelegate(float x);

		internal static class InOutExpo_0000002A_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<InOutExpo_0000002A_0024PostfixBurstDelegate>(InOutExpo).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return InOutExpo_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float InCirc_0000002B_0024PostfixBurstDelegate(float x);

		internal static class InCirc_0000002B_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<InCirc_0000002B_0024PostfixBurstDelegate>(InCirc).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return InCirc_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float OutCirc_0000002C_0024PostfixBurstDelegate(float x);

		internal static class OutCirc_0000002C_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<OutCirc_0000002C_0024PostfixBurstDelegate>(OutCirc).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return OutCirc_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float InOutCirc_0000002D_0024PostfixBurstDelegate(float x);

		internal static class InOutCirc_0000002D_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<InOutCirc_0000002D_0024PostfixBurstDelegate>(InOutCirc).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return InOutCirc_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float InBack_0000002E_0024PostfixBurstDelegate(float x);

		internal static class InBack_0000002E_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<InBack_0000002E_0024PostfixBurstDelegate>(InBack).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return InBack_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float OutBack_0000002F_0024PostfixBurstDelegate(float x);

		internal static class OutBack_0000002F_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<OutBack_0000002F_0024PostfixBurstDelegate>(OutBack).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return OutBack_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float InOutBack_00000030_0024PostfixBurstDelegate(float x);

		internal static class InOutBack_00000030_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<InOutBack_00000030_0024PostfixBurstDelegate>(InOutBack).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return InOutBack_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float InElastic_00000031_0024PostfixBurstDelegate(float x);

		internal static class InElastic_00000031_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<InElastic_00000031_0024PostfixBurstDelegate>(InElastic).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return InElastic_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float OutElastic_00000032_0024PostfixBurstDelegate(float x);

		internal static class OutElastic_00000032_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<OutElastic_00000032_0024PostfixBurstDelegate>(OutElastic).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return OutElastic_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float InOutElastic_00000033_0024PostfixBurstDelegate(float x);

		internal static class InOutElastic_00000033_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<InOutElastic_00000033_0024PostfixBurstDelegate>(InOutElastic).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return InOutElastic_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float InBounce_00000034_0024PostfixBurstDelegate(float x);

		internal static class InBounce_00000034_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<InBounce_00000034_0024PostfixBurstDelegate>(InBounce).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return InBounce_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float OutBounce_00000035_0024PostfixBurstDelegate(float x);

		internal static class OutBounce_00000035_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<OutBounce_00000035_0024PostfixBurstDelegate>(OutBounce).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return OutBounce_0024BurstManaged(x);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float InOutBounce_00000036_0024PostfixBurstDelegate(float x);

		internal static class InOutBounce_00000036_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<InOutBounce_00000036_0024PostfixBurstDelegate>(InOutBounce).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(float x)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<float, float>)functionPointer)(x);
					}
				}
				return InOutBounce_0024BurstManaged(x);
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EEvaluate_00000017_0024PostfixBurstDelegate))]
		public static float Evaluate(float t, Ease ease)
		{
			return Evaluate_00000017_0024BurstDirectCall.Invoke(t, ease);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002ELinear_00000018_0024PostfixBurstDelegate))]
		public static float Linear(float x)
		{
			return Linear_00000018_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInSine_00000019_0024PostfixBurstDelegate))]
		public static float InSine(float x)
		{
			return InSine_00000019_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EOutSine_0000001A_0024PostfixBurstDelegate))]
		public static float OutSine(float x)
		{
			return OutSine_0000001A_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInOutSine_0000001B_0024PostfixBurstDelegate))]
		public static float InOutSine(float x)
		{
			return InOutSine_0000001B_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInQuad_0000001C_0024PostfixBurstDelegate))]
		public static float InQuad(float x)
		{
			return InQuad_0000001C_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EOutQuad_0000001D_0024PostfixBurstDelegate))]
		public static float OutQuad(float x)
		{
			return OutQuad_0000001D_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInOutQuad_0000001E_0024PostfixBurstDelegate))]
		public static float InOutQuad(float x)
		{
			return InOutQuad_0000001E_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInCubic_0000001F_0024PostfixBurstDelegate))]
		public static float InCubic(float x)
		{
			return InCubic_0000001F_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EOutCubic_00000020_0024PostfixBurstDelegate))]
		public static float OutCubic(float x)
		{
			return OutCubic_00000020_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInOutCubic_00000021_0024PostfixBurstDelegate))]
		public static float InOutCubic(float x)
		{
			return InOutCubic_00000021_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInQuart_00000022_0024PostfixBurstDelegate))]
		public static float InQuart(float x)
		{
			return InQuart_00000022_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EOutQuart_00000023_0024PostfixBurstDelegate))]
		public static float OutQuart(float x)
		{
			return OutQuart_00000023_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInOutQuart_00000024_0024PostfixBurstDelegate))]
		public static float InOutQuart(float x)
		{
			return InOutQuart_00000024_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInQuint_00000025_0024PostfixBurstDelegate))]
		public static float InQuint(float x)
		{
			return InQuint_00000025_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EOutQuint_00000026_0024PostfixBurstDelegate))]
		public static float OutQuint(float x)
		{
			return OutQuint_00000026_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInOutQuint_00000027_0024PostfixBurstDelegate))]
		public static float InOutQuint(float x)
		{
			return InOutQuint_00000027_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInExpo_00000028_0024PostfixBurstDelegate))]
		public static float InExpo(float x)
		{
			return InExpo_00000028_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EOutExpo_00000029_0024PostfixBurstDelegate))]
		public static float OutExpo(float x)
		{
			return OutExpo_00000029_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInOutExpo_0000002A_0024PostfixBurstDelegate))]
		public static float InOutExpo(float x)
		{
			return InOutExpo_0000002A_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInCirc_0000002B_0024PostfixBurstDelegate))]
		public static float InCirc(float x)
		{
			return InCirc_0000002B_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EOutCirc_0000002C_0024PostfixBurstDelegate))]
		public static float OutCirc(float x)
		{
			return OutCirc_0000002C_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInOutCirc_0000002D_0024PostfixBurstDelegate))]
		public static float InOutCirc(float x)
		{
			return InOutCirc_0000002D_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInBack_0000002E_0024PostfixBurstDelegate))]
		public static float InBack(float x)
		{
			return InBack_0000002E_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EOutBack_0000002F_0024PostfixBurstDelegate))]
		public static float OutBack(float x)
		{
			return OutBack_0000002F_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInOutBack_00000030_0024PostfixBurstDelegate))]
		public static float InOutBack(float x)
		{
			return InOutBack_00000030_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInElastic_00000031_0024PostfixBurstDelegate))]
		public static float InElastic(float x)
		{
			return InElastic_00000031_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EOutElastic_00000032_0024PostfixBurstDelegate))]
		public static float OutElastic(float x)
		{
			return OutElastic_00000032_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInOutElastic_00000033_0024PostfixBurstDelegate))]
		public static float InOutElastic(float x)
		{
			return InOutElastic_00000033_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInBounce_00000034_0024PostfixBurstDelegate))]
		public static float InBounce(float x)
		{
			return InBounce_00000034_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EOutBounce_00000035_0024PostfixBurstDelegate))]
		public static float OutBounce(float x)
		{
			return OutBounce_00000035_0024BurstDirectCall.Invoke(x);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInOutBounce_00000036_0024PostfixBurstDelegate))]
		public static float InOutBounce(float x)
		{
			return InOutBounce_00000036_0024BurstDirectCall.Invoke(x);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float Evaluate_0024BurstManaged(float t, Ease ease)
		{
			return ease switch
			{
				Ease.InSine => InSine(t), 
				Ease.OutSine => OutSine(t), 
				Ease.InOutSine => InOutSine(t), 
				Ease.InQuad => InQuad(t), 
				Ease.OutQuad => OutQuad(t), 
				Ease.InOutQuad => InOutQuad(t), 
				Ease.InCubic => InCubic(t), 
				Ease.OutCubic => OutCubic(t), 
				Ease.InOutCubic => InOutCubic(t), 
				Ease.InQuart => InQuart(t), 
				Ease.OutQuart => OutQuart(t), 
				Ease.InOutQuart => InOutQuart(t), 
				Ease.InQuint => InQuint(t), 
				Ease.OutQuint => OutQuint(t), 
				Ease.InOutQuint => InOutQuint(t), 
				Ease.InExpo => InExpo(t), 
				Ease.OutExpo => OutExpo(t), 
				Ease.InOutExpo => InOutExpo(t), 
				Ease.InCirc => InCirc(t), 
				Ease.OutCirc => OutCirc(t), 
				Ease.InOutCirc => InOutCirc(t), 
				Ease.InElastic => InElastic(t), 
				Ease.OutElastic => OutElastic(t), 
				Ease.InOutElastic => InOutElastic(t), 
				Ease.InBack => InBack(t), 
				Ease.OutBack => OutBack(t), 
				Ease.InOutBack => InOutBack(t), 
				Ease.InBounce => InBounce(t), 
				Ease.OutBounce => OutBounce(t), 
				Ease.InOutBounce => InOutBounce(t), 
				_ => t, 
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float Linear_0024BurstManaged(float x)
		{
			return x;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float InSine_0024BurstManaged(float x)
		{
			return 1f - math.cos(x * MathF.PI / 2f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float OutSine_0024BurstManaged(float x)
		{
			return math.sin(x * MathF.PI / 2f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float InOutSine_0024BurstManaged(float x)
		{
			return (0f - (math.cos(MathF.PI * x) - 1f)) / 2f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float InQuad_0024BurstManaged(float x)
		{
			return x * x;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float OutQuad_0024BurstManaged(float x)
		{
			return 1f - (1f - x) * (1f - x);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float InOutQuad_0024BurstManaged(float x)
		{
			if (!(x < 0.5f))
			{
				return 1f - math.pow(-2f * x + 2f, 2f) / 2f;
			}
			return 2f * x * x;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float InCubic_0024BurstManaged(float x)
		{
			return x * x * x;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float OutCubic_0024BurstManaged(float x)
		{
			return 1f - math.pow(1f - x, 3f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float InOutCubic_0024BurstManaged(float x)
		{
			if (!(x < 0.5f))
			{
				return 1f - math.pow(-2f * x + 2f, 3f) / 2f;
			}
			return 4f * x * x * x;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float InQuart_0024BurstManaged(float x)
		{
			return x * x * x * x;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float OutQuart_0024BurstManaged(float x)
		{
			return 1f - math.pow(1f - x, 4f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float InOutQuart_0024BurstManaged(float x)
		{
			if (!((double)x < 0.5))
			{
				return 1f - math.pow(-2f * x + 2f, 4f) / 2f;
			}
			return 8f * x * x * x * x;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float InQuint_0024BurstManaged(float x)
		{
			return x * x * x * x * x;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float OutQuint_0024BurstManaged(float x)
		{
			return 1f - math.pow(1f - x, 5f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float InOutQuint_0024BurstManaged(float x)
		{
			if (!(x < 0.5f))
			{
				return 1f - math.pow(-2f * x + 2f, 5f) / 2f;
			}
			return 16f * x * x * x * x * x;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float InExpo_0024BurstManaged(float x)
		{
			if (x != 0f)
			{
				return math.pow(2f, 10f * x - 10f);
			}
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float OutExpo_0024BurstManaged(float x)
		{
			if (x != 1f)
			{
				return 1f - math.pow(2f, -10f * x);
			}
			return 1f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float InOutExpo_0024BurstManaged(float x)
		{
			if (x != 0f)
			{
				if (x != 1f)
				{
					if (!(x < 0.5f))
					{
						return (2f - math.pow(2f, -20f * x + 10f)) / 2f;
					}
					return math.pow(2f, 20f * x - 10f) / 2f;
				}
				return 1f;
			}
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float InCirc_0024BurstManaged(float x)
		{
			return 1f - math.sqrt(1f - math.pow(x, 2f));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float OutCirc_0024BurstManaged(float x)
		{
			return math.sqrt(1f - math.pow(x - 1f, 2f));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float InOutCirc_0024BurstManaged(float x)
		{
			if (!((double)x < 0.5))
			{
				return (math.sqrt(1f - math.pow(-2f * x + 2f, 2f)) + 1f) / 2f;
			}
			return (1f - math.sqrt(1f - math.pow(2f * x, 2f))) / 2f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float InBack_0024BurstManaged(float x)
		{
			return 2.70158f * x * x * x - 1.70158f * x * x;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float OutBack_0024BurstManaged(float x)
		{
			return 1f + 2.70158f * math.pow(x - 1f, 3f) + 1.70158f * math.pow(x - 1f, 2f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float InOutBack_0024BurstManaged(float x)
		{
			if (!(x < 0.5f))
			{
				return (math.pow(2f * x - 2f, 2f) * (3.5949094f * (x * 2f - 2f) + 2.5949094f) + 2f) / 2f;
			}
			return math.pow(2f * x, 2f) * (7.189819f * x - 2.5949094f) / 2f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float InElastic_0024BurstManaged(float x)
		{
			if (x != 0f)
			{
				if (x != 1f)
				{
					return (0f - math.pow(2f, 10f * x - 10f)) * math.sin((x * 10f - 10.75f) * (MathF.PI * 2f / 3f));
				}
				return 1f;
			}
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float OutElastic_0024BurstManaged(float x)
		{
			if (x != 0f)
			{
				if (x != 1f)
				{
					return math.pow(2f, -10f * x) * math.sin((x * 10f - 0.75f) * (MathF.PI * 2f / 3f)) + 1f;
				}
				return 1f;
			}
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float InOutElastic_0024BurstManaged(float x)
		{
			if (x != 0f)
			{
				if (x != 1f)
				{
					if (!(x < 0.5f))
					{
						return math.pow(2f, -20f * x + 10f) * math.sin((20f * x - 11.125f) * (MathF.PI * 4f / 9f)) / 2f + 1f;
					}
					return (0f - math.pow(2f, 20f * x - 10f) * math.sin((20f * x - 11.125f) * (MathF.PI * 4f / 9f))) / 2f;
				}
				return 1f;
			}
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float InBounce_0024BurstManaged(float x)
		{
			return 1f - OutBounce(1f - x);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float OutBounce_0024BurstManaged(float x)
		{
			float num = x;
			if (num < 0.36363637f)
			{
				return 7.5625f * num * num;
			}
			if (num < 0.72727275f)
			{
				return 7.5625f * (num -= 0.54545456f) * num + 0.75f;
			}
			if ((double)num < 0.9090909090909091)
			{
				return 7.5625f * (num -= 0.8181818f) * num + 0.9375f;
			}
			return 7.5625f * (num -= 21f / 22f) * num + 63f / 64f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float InOutBounce_0024BurstManaged(float x)
		{
			if (!(x < 0.5f))
			{
				return (1f + OutBounce(2f * x - 1f)) / 2f;
			}
			return (1f - OutBounce(1f - 2f * x)) / 2f;
		}
	}
}
