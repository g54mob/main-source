using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace LitMotion
{
	[BurstCompile]
	internal static class FixedStringHelper
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate int GetUtf8CharCount_00000074_0024PostfixBurstDelegate(ref FixedString32Bytes runes);

		internal static class GetUtf8CharCount_00000074_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<GetUtf8CharCount_00000074_0024PostfixBurstDelegate>(GetUtf8CharCount).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static int Invoke(ref FixedString32Bytes runes)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<ref FixedString32Bytes, int>)functionPointer)(ref runes);
					}
				}
				return GetUtf8CharCount_0024BurstManaged(ref runes);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void Interpolate_00000076_0024PostfixBurstDelegate(ref FixedString32Bytes start, ref FixedString32Bytes end, float t, ScrambleMode scrambleMode, bool richTextEnabled, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString32Bytes result);

		internal static class Interpolate_00000076_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<Interpolate_00000076_0024PostfixBurstDelegate>(Interpolate).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref FixedString32Bytes start, ref FixedString32Bytes end, float t, ScrambleMode scrambleMode, bool richTextEnabled, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString32Bytes result)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref FixedString32Bytes, ref FixedString32Bytes, float, ScrambleMode, bool, ref Unity.Mathematics.Random, ref FixedString64Bytes, ref FixedString32Bytes, void>)functionPointer)(ref start, ref end, t, scrambleMode, richTextEnabled, ref randomState, ref customScrambleChars, ref result);
						return;
					}
				}
				Interpolate_0024BurstManaged(ref start, ref end, t, scrambleMode, richTextEnabled, ref randomState, ref customScrambleChars, out result);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate int GetUtf8CharCount_0000007B_0024PostfixBurstDelegate(ref FixedString64Bytes runes);

		internal static class GetUtf8CharCount_0000007B_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<GetUtf8CharCount_0000007B_0024PostfixBurstDelegate>(GetUtf8CharCount).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static int Invoke(ref FixedString64Bytes runes)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<ref FixedString64Bytes, int>)functionPointer)(ref runes);
					}
				}
				return GetUtf8CharCount_0024BurstManaged(ref runes);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void Interpolate_0000007D_0024PostfixBurstDelegate(ref FixedString64Bytes start, ref FixedString64Bytes end, float t, ScrambleMode scrambleMode, bool richTextEnabled, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString64Bytes result);

		internal static class Interpolate_0000007D_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<Interpolate_0000007D_0024PostfixBurstDelegate>(Interpolate).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref FixedString64Bytes start, ref FixedString64Bytes end, float t, ScrambleMode scrambleMode, bool richTextEnabled, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString64Bytes result)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref FixedString64Bytes, ref FixedString64Bytes, float, ScrambleMode, bool, ref Unity.Mathematics.Random, ref FixedString64Bytes, ref FixedString64Bytes, void>)functionPointer)(ref start, ref end, t, scrambleMode, richTextEnabled, ref randomState, ref customScrambleChars, ref result);
						return;
					}
				}
				Interpolate_0024BurstManaged(ref start, ref end, t, scrambleMode, richTextEnabled, ref randomState, ref customScrambleChars, out result);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate int GetUtf8CharCount_00000082_0024PostfixBurstDelegate(ref FixedString128Bytes runes);

		internal static class GetUtf8CharCount_00000082_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<GetUtf8CharCount_00000082_0024PostfixBurstDelegate>(GetUtf8CharCount).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static int Invoke(ref FixedString128Bytes runes)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<ref FixedString128Bytes, int>)functionPointer)(ref runes);
					}
				}
				return GetUtf8CharCount_0024BurstManaged(ref runes);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void Interpolate_00000084_0024PostfixBurstDelegate(ref FixedString128Bytes start, ref FixedString128Bytes end, float t, ScrambleMode scrambleMode, bool richTextEnabled, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString128Bytes result);

		internal static class Interpolate_00000084_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<Interpolate_00000084_0024PostfixBurstDelegate>(Interpolate).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref FixedString128Bytes start, ref FixedString128Bytes end, float t, ScrambleMode scrambleMode, bool richTextEnabled, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString128Bytes result)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref FixedString128Bytes, ref FixedString128Bytes, float, ScrambleMode, bool, ref Unity.Mathematics.Random, ref FixedString64Bytes, ref FixedString128Bytes, void>)functionPointer)(ref start, ref end, t, scrambleMode, richTextEnabled, ref randomState, ref customScrambleChars, ref result);
						return;
					}
				}
				Interpolate_0024BurstManaged(ref start, ref end, t, scrambleMode, richTextEnabled, ref randomState, ref customScrambleChars, out result);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate int GetUtf8CharCount_00000089_0024PostfixBurstDelegate(ref FixedString512Bytes runes);

		internal static class GetUtf8CharCount_00000089_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<GetUtf8CharCount_00000089_0024PostfixBurstDelegate>(GetUtf8CharCount).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static int Invoke(ref FixedString512Bytes runes)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<ref FixedString512Bytes, int>)functionPointer)(ref runes);
					}
				}
				return GetUtf8CharCount_0024BurstManaged(ref runes);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void Interpolate_0000008B_0024PostfixBurstDelegate(ref FixedString512Bytes start, ref FixedString512Bytes end, float t, ScrambleMode scrambleMode, bool richTextEnabled, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString512Bytes result);

		internal static class Interpolate_0000008B_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<Interpolate_0000008B_0024PostfixBurstDelegate>(Interpolate).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref FixedString512Bytes start, ref FixedString512Bytes end, float t, ScrambleMode scrambleMode, bool richTextEnabled, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString512Bytes result)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref FixedString512Bytes, ref FixedString512Bytes, float, ScrambleMode, bool, ref Unity.Mathematics.Random, ref FixedString64Bytes, ref FixedString512Bytes, void>)functionPointer)(ref start, ref end, t, scrambleMode, richTextEnabled, ref randomState, ref customScrambleChars, ref result);
						return;
					}
				}
				Interpolate_0024BurstManaged(ref start, ref end, t, scrambleMode, richTextEnabled, ref randomState, ref customScrambleChars, out result);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate int GetUtf8CharCount_00000090_0024PostfixBurstDelegate(ref FixedString4096Bytes runes);

		internal static class GetUtf8CharCount_00000090_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<GetUtf8CharCount_00000090_0024PostfixBurstDelegate>(GetUtf8CharCount).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static int Invoke(ref FixedString4096Bytes runes)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<ref FixedString4096Bytes, int>)functionPointer)(ref runes);
					}
				}
				return GetUtf8CharCount_0024BurstManaged(ref runes);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void Interpolate_00000092_0024PostfixBurstDelegate(ref FixedString4096Bytes start, ref FixedString4096Bytes end, float t, ScrambleMode scrambleMode, bool richTextEnabled, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString4096Bytes result);

		internal static class Interpolate_00000092_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<Interpolate_00000092_0024PostfixBurstDelegate>(Interpolate).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref FixedString4096Bytes start, ref FixedString4096Bytes end, float t, ScrambleMode scrambleMode, bool richTextEnabled, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString4096Bytes result)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref FixedString4096Bytes, ref FixedString4096Bytes, float, ScrambleMode, bool, ref Unity.Mathematics.Random, ref FixedString64Bytes, ref FixedString4096Bytes, void>)functionPointer)(ref start, ref end, t, scrambleMode, richTextEnabled, ref randomState, ref customScrambleChars, ref result);
						return;
					}
				}
				Interpolate_0024BurstManaged(ref start, ref end, t, scrambleMode, richTextEnabled, ref randomState, ref customScrambleChars, out result);
			}
		}

		private static readonly char[] LowercaseChars = new char[26]
		{
			'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
			'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
			'u', 'v', 'w', 'x', 'y', 'z'
		};

		private static readonly char[] UppercaseChars = new char[26]
		{
			'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
			'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
			'U', 'V', 'W', 'X', 'Y', 'Z'
		};

		private static readonly char[] NumeralsChars = new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

		private static readonly char[] AllChars = new char[62]
		{
			'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
			'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
			'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D',
			'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
			'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
			'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7',
			'8', '9'
		};

		private static char GetScrambleChar(ScrambleMode scrambleMode, ref Unity.Mathematics.Random random)
		{
			return scrambleMode switch
			{
				ScrambleMode.None => '\0', 
				ScrambleMode.Uppercase => UppercaseChars[random.NextInt(0, UppercaseChars.Length)], 
				ScrambleMode.Lowercase => LowercaseChars[random.NextInt(0, LowercaseChars.Length)], 
				ScrambleMode.Numerals => NumeralsChars[random.NextInt(0, NumeralsChars.Length)], 
				ScrambleMode.All => AllChars[random.NextInt(0, AllChars.Length)], 
				_ => '\0', 
			};
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EGetUtf8CharCount_00000074_0024PostfixBurstDelegate))]
		public static int GetUtf8CharCount(ref FixedString32Bytes runes)
		{
			return GetUtf8CharCount_00000074_0024BurstDirectCall.Invoke(ref runes);
		}

		private static Unicode.Rune GetRuneOf(ref FixedString32Bytes text, int charIndex)
		{
			int num = 0;
			FixedString32Bytes.Enumerator enumerator = text.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (num == charIndex)
				{
					return enumerator.Current;
				}
				num++;
			}
			return Unicode.BadRune;
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInterpolate_00000076_0024PostfixBurstDelegate))]
		public static void Interpolate(ref FixedString32Bytes start, ref FixedString32Bytes end, float t, ScrambleMode scrambleMode, bool richTextEnabled, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString32Bytes result)
		{
			Interpolate_00000076_0024BurstDirectCall.Invoke(ref start, ref end, t, scrambleMode, richTextEnabled, ref randomState, ref customScrambleChars, out result);
		}

		private static void FillText(ref FixedString32Bytes start, ref FixedString32Bytes end, float t, ScrambleMode scrambleMode, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString32Bytes result)
		{
			int utf8CharCount = GetUtf8CharCount(ref start);
			int utf8CharCount2 = GetUtf8CharCount(ref end);
			int num = math.max(utf8CharCount, utf8CharCount2);
			int num2 = (int)math.round((float)num * t);
			FixedString32Bytes.Enumerator enumerator = start.GetEnumerator();
			FixedString32Bytes.Enumerator enumerator2 = end.GetEnumerator();
			result = default(FixedString32Bytes);
			for (int i = 0; i < num; i++)
			{
				bool flag = enumerator.MoveNext();
				bool flag2 = enumerator2.MoveNext();
				if (i < num2)
				{
					if (flag2)
					{
						FixedStringMethods.Append(ref result, enumerator2.Current);
					}
				}
				else if (flag)
				{
					FixedStringMethods.Append(ref result, enumerator.Current);
				}
			}
			FillScrambleChars(ref result, scrambleMode, ref randomState, ref customScrambleChars, num - num2);
		}

		private static void FillRichText(ref UnsafeList<RichTextSymbol32Bytes> startSymbols, ref UnsafeList<RichTextSymbol32Bytes> endSymbols, int startTextUtf8Length, int endTextUtf8Length, float t, ScrambleMode scrambleMode, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString32Bytes result)
		{
			int num = math.max(startTextUtf8Length, endTextUtf8Length);
			int num2 = (int)math.round((float)num * t);
			int resultRichTextLength;
			FixedString32Bytes input = SliceSymbols(ref endSymbols, 0, num2, out resultRichTextLength);
			int resultRichTextLength2;
			FixedString32Bytes input2 = SliceSymbols(ref startSymbols, num2 + 1, num - 1, out resultRichTextLength2);
			result = default(FixedString32Bytes);
			FixedStringMethods.Append(ref result, in input);
			FixedStringMethods.Append(ref result, in input2);
			FillScrambleChars(ref result, scrambleMode, ref randomState, ref customScrambleChars, num - (resultRichTextLength + resultRichTextLength2));
		}

		private static void FillScrambleChars(ref FixedString32Bytes target, ScrambleMode scrambleMode, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, int count)
		{
			if (scrambleMode == ScrambleMode.None)
			{
				return;
			}
			if (randomState.state == 0)
			{
				randomState.InitState();
			}
			if (scrambleMode == ScrambleMode.Custom)
			{
				int utf8CharCount = GetUtf8CharCount(ref customScrambleChars);
				for (int i = 0; i < count; i++)
				{
					FixedStringMethods.Append(ref target, GetRuneOf(ref customScrambleChars, randomState.NextInt(0, utf8CharCount)));
				}
			}
			else
			{
				for (int j = 0; j < count; j++)
				{
					FixedStringMethods.Append(ref target, GetScrambleChar(scrambleMode, ref randomState));
				}
			}
		}

		private unsafe static FixedString32Bytes SliceSymbols(ref UnsafeList<RichTextSymbol32Bytes> symbols, int from, int to, out int resultRichTextLength)
		{
			FixedString32Bytes fs = default(FixedString32Bytes);
			RichTextSymbol32Bytes* ptr = symbols.Ptr;
			int num = 0;
			int num2 = 0;
			resultRichTextLength = 0;
			for (int i = 0; i < symbols.Length; i++)
			{
				RichTextSymbol32Bytes* ptr2 = ptr + i;
				switch (ptr2->Type)
				{
				case RichTextSymbolType.Text:
				{
					FixedString32Bytes.Enumerator enumerator = ptr2->Text.GetEnumerator();
					while (enumerator.MoveNext())
					{
						Unicode.Rune current = enumerator.Current;
						if (from <= num && num < to)
						{
							FixedStringMethods.Append(ref fs, current);
							resultRichTextLength++;
						}
						num++;
						if (num >= to && num2 == 0)
						{
							goto end_IL_0037;
						}
					}
					continue;
				}
				case RichTextSymbolType.TagStart:
					FixedStringMethods.Append(ref fs, in ptr2->Text);
					num2++;
					continue;
				case RichTextSymbolType.TagEnd:
					FixedStringMethods.Append(ref fs, in ptr2->Text);
					num2--;
					if (num < to || num2 != 0)
					{
						continue;
					}
					break;
				default:
					continue;
					end_IL_0037:
					break;
				}
				break;
			}
			return fs;
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EGetUtf8CharCount_0000007B_0024PostfixBurstDelegate))]
		public static int GetUtf8CharCount(ref FixedString64Bytes runes)
		{
			return GetUtf8CharCount_0000007B_0024BurstDirectCall.Invoke(ref runes);
		}

		private static Unicode.Rune GetRuneOf(ref FixedString64Bytes text, int charIndex)
		{
			int num = 0;
			FixedString64Bytes.Enumerator enumerator = text.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (num == charIndex)
				{
					return enumerator.Current;
				}
				num++;
			}
			return Unicode.BadRune;
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInterpolate_0000007D_0024PostfixBurstDelegate))]
		public static void Interpolate(ref FixedString64Bytes start, ref FixedString64Bytes end, float t, ScrambleMode scrambleMode, bool richTextEnabled, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString64Bytes result)
		{
			Interpolate_0000007D_0024BurstDirectCall.Invoke(ref start, ref end, t, scrambleMode, richTextEnabled, ref randomState, ref customScrambleChars, out result);
		}

		private static void FillText(ref FixedString64Bytes start, ref FixedString64Bytes end, float t, ScrambleMode scrambleMode, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString64Bytes result)
		{
			int utf8CharCount = GetUtf8CharCount(ref start);
			int utf8CharCount2 = GetUtf8CharCount(ref end);
			int num = math.max(utf8CharCount, utf8CharCount2);
			int num2 = (int)math.round((float)num * t);
			FixedString64Bytes.Enumerator enumerator = start.GetEnumerator();
			FixedString64Bytes.Enumerator enumerator2 = end.GetEnumerator();
			result = default(FixedString64Bytes);
			for (int i = 0; i < num; i++)
			{
				bool flag = enumerator.MoveNext();
				bool flag2 = enumerator2.MoveNext();
				if (i < num2)
				{
					if (flag2)
					{
						FixedStringMethods.Append(ref result, enumerator2.Current);
					}
				}
				else if (flag)
				{
					FixedStringMethods.Append(ref result, enumerator.Current);
				}
			}
			FillScrambleChars(ref result, scrambleMode, ref randomState, ref customScrambleChars, num - num2);
		}

		private static void FillRichText(ref UnsafeList<RichTextSymbol64Bytes> startSymbols, ref UnsafeList<RichTextSymbol64Bytes> endSymbols, int startTextUtf8Length, int endTextUtf8Length, float t, ScrambleMode scrambleMode, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString64Bytes result)
		{
			int num = math.max(startTextUtf8Length, endTextUtf8Length);
			int num2 = (int)math.round((float)num * t);
			int resultRichTextLength;
			FixedString64Bytes input = SliceSymbols(ref endSymbols, 0, num2, out resultRichTextLength);
			int resultRichTextLength2;
			FixedString64Bytes input2 = SliceSymbols(ref startSymbols, num2 + 1, num - 1, out resultRichTextLength2);
			result = default(FixedString64Bytes);
			FixedStringMethods.Append(ref result, in input);
			FixedStringMethods.Append(ref result, in input2);
			FillScrambleChars(ref result, scrambleMode, ref randomState, ref customScrambleChars, num - (resultRichTextLength + resultRichTextLength2));
		}

		private static void FillScrambleChars(ref FixedString64Bytes target, ScrambleMode scrambleMode, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, int count)
		{
			if (scrambleMode == ScrambleMode.None)
			{
				return;
			}
			if (randomState.state == 0)
			{
				randomState.InitState();
			}
			if (scrambleMode == ScrambleMode.Custom)
			{
				int utf8CharCount = GetUtf8CharCount(ref customScrambleChars);
				for (int i = 0; i < count; i++)
				{
					FixedStringMethods.Append(ref target, GetRuneOf(ref customScrambleChars, randomState.NextInt(0, utf8CharCount)));
				}
			}
			else
			{
				for (int j = 0; j < count; j++)
				{
					FixedStringMethods.Append(ref target, GetScrambleChar(scrambleMode, ref randomState));
				}
			}
		}

		private unsafe static FixedString64Bytes SliceSymbols(ref UnsafeList<RichTextSymbol64Bytes> symbols, int from, int to, out int resultRichTextLength)
		{
			FixedString64Bytes fs = default(FixedString64Bytes);
			RichTextSymbol64Bytes* ptr = symbols.Ptr;
			int num = 0;
			int num2 = 0;
			resultRichTextLength = 0;
			for (int i = 0; i < symbols.Length; i++)
			{
				RichTextSymbol64Bytes* ptr2 = ptr + i;
				switch (ptr2->Type)
				{
				case RichTextSymbolType.Text:
				{
					FixedString64Bytes.Enumerator enumerator = ptr2->Text.GetEnumerator();
					while (enumerator.MoveNext())
					{
						Unicode.Rune current = enumerator.Current;
						if (from <= num && num < to)
						{
							FixedStringMethods.Append(ref fs, current);
							resultRichTextLength++;
						}
						num++;
						if (num >= to && num2 == 0)
						{
							goto end_IL_0037;
						}
					}
					continue;
				}
				case RichTextSymbolType.TagStart:
					FixedStringMethods.Append(ref fs, in ptr2->Text);
					num2++;
					continue;
				case RichTextSymbolType.TagEnd:
					FixedStringMethods.Append(ref fs, in ptr2->Text);
					num2--;
					if (num < to || num2 != 0)
					{
						continue;
					}
					break;
				default:
					continue;
					end_IL_0037:
					break;
				}
				break;
			}
			return fs;
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EGetUtf8CharCount_00000082_0024PostfixBurstDelegate))]
		public static int GetUtf8CharCount(ref FixedString128Bytes runes)
		{
			return GetUtf8CharCount_00000082_0024BurstDirectCall.Invoke(ref runes);
		}

		private static Unicode.Rune GetRuneOf(ref FixedString128Bytes text, int charIndex)
		{
			int num = 0;
			FixedString128Bytes.Enumerator enumerator = text.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (num == charIndex)
				{
					return enumerator.Current;
				}
				num++;
			}
			return Unicode.BadRune;
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInterpolate_00000084_0024PostfixBurstDelegate))]
		public static void Interpolate(ref FixedString128Bytes start, ref FixedString128Bytes end, float t, ScrambleMode scrambleMode, bool richTextEnabled, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString128Bytes result)
		{
			Interpolate_00000084_0024BurstDirectCall.Invoke(ref start, ref end, t, scrambleMode, richTextEnabled, ref randomState, ref customScrambleChars, out result);
		}

		private static void FillText(ref FixedString128Bytes start, ref FixedString128Bytes end, float t, ScrambleMode scrambleMode, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString128Bytes result)
		{
			int utf8CharCount = GetUtf8CharCount(ref start);
			int utf8CharCount2 = GetUtf8CharCount(ref end);
			int num = math.max(utf8CharCount, utf8CharCount2);
			int num2 = (int)math.round((float)num * t);
			FixedString128Bytes.Enumerator enumerator = start.GetEnumerator();
			FixedString128Bytes.Enumerator enumerator2 = end.GetEnumerator();
			result = default(FixedString128Bytes);
			for (int i = 0; i < num; i++)
			{
				bool flag = enumerator.MoveNext();
				bool flag2 = enumerator2.MoveNext();
				if (i < num2)
				{
					if (flag2)
					{
						FixedStringMethods.Append(ref result, enumerator2.Current);
					}
				}
				else if (flag)
				{
					FixedStringMethods.Append(ref result, enumerator.Current);
				}
			}
			FillScrambleChars(ref result, scrambleMode, ref randomState, ref customScrambleChars, num - num2);
		}

		private static void FillRichText(ref UnsafeList<RichTextSymbol128Bytes> startSymbols, ref UnsafeList<RichTextSymbol128Bytes> endSymbols, int startTextUtf8Length, int endTextUtf8Length, float t, ScrambleMode scrambleMode, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString128Bytes result)
		{
			int num = math.max(startTextUtf8Length, endTextUtf8Length);
			int num2 = (int)math.round((float)num * t);
			int resultRichTextLength;
			FixedString128Bytes input = SliceSymbols(ref endSymbols, 0, num2, out resultRichTextLength);
			int resultRichTextLength2;
			FixedString128Bytes input2 = SliceSymbols(ref startSymbols, num2 + 1, num - 1, out resultRichTextLength2);
			result = default(FixedString128Bytes);
			FixedStringMethods.Append(ref result, in input);
			FixedStringMethods.Append(ref result, in input2);
			FillScrambleChars(ref result, scrambleMode, ref randomState, ref customScrambleChars, num - (resultRichTextLength + resultRichTextLength2));
		}

		private static void FillScrambleChars(ref FixedString128Bytes target, ScrambleMode scrambleMode, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, int count)
		{
			if (scrambleMode == ScrambleMode.None)
			{
				return;
			}
			if (randomState.state == 0)
			{
				randomState.InitState();
			}
			if (scrambleMode == ScrambleMode.Custom)
			{
				int utf8CharCount = GetUtf8CharCount(ref customScrambleChars);
				for (int i = 0; i < count; i++)
				{
					FixedStringMethods.Append(ref target, GetRuneOf(ref customScrambleChars, randomState.NextInt(0, utf8CharCount)));
				}
			}
			else
			{
				for (int j = 0; j < count; j++)
				{
					FixedStringMethods.Append(ref target, GetScrambleChar(scrambleMode, ref randomState));
				}
			}
		}

		private unsafe static FixedString128Bytes SliceSymbols(ref UnsafeList<RichTextSymbol128Bytes> symbols, int from, int to, out int resultRichTextLength)
		{
			FixedString128Bytes fs = default(FixedString128Bytes);
			RichTextSymbol128Bytes* ptr = symbols.Ptr;
			int num = 0;
			int num2 = 0;
			resultRichTextLength = 0;
			for (int i = 0; i < symbols.Length; i++)
			{
				RichTextSymbol128Bytes* ptr2 = ptr + i;
				switch (ptr2->Type)
				{
				case RichTextSymbolType.Text:
				{
					FixedString128Bytes.Enumerator enumerator = ptr2->Text.GetEnumerator();
					while (enumerator.MoveNext())
					{
						Unicode.Rune current = enumerator.Current;
						if (from <= num && num < to)
						{
							FixedStringMethods.Append(ref fs, current);
							resultRichTextLength++;
						}
						num++;
						if (num >= to && num2 == 0)
						{
							goto end_IL_0037;
						}
					}
					continue;
				}
				case RichTextSymbolType.TagStart:
					FixedStringMethods.Append(ref fs, in ptr2->Text);
					num2++;
					continue;
				case RichTextSymbolType.TagEnd:
					FixedStringMethods.Append(ref fs, in ptr2->Text);
					num2--;
					if (num < to || num2 != 0)
					{
						continue;
					}
					break;
				default:
					continue;
					end_IL_0037:
					break;
				}
				break;
			}
			return fs;
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EGetUtf8CharCount_00000089_0024PostfixBurstDelegate))]
		public static int GetUtf8CharCount(ref FixedString512Bytes runes)
		{
			return GetUtf8CharCount_00000089_0024BurstDirectCall.Invoke(ref runes);
		}

		private static Unicode.Rune GetRuneOf(ref FixedString512Bytes text, int charIndex)
		{
			int num = 0;
			FixedString512Bytes.Enumerator enumerator = text.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (num == charIndex)
				{
					return enumerator.Current;
				}
				num++;
			}
			return Unicode.BadRune;
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInterpolate_0000008B_0024PostfixBurstDelegate))]
		public static void Interpolate(ref FixedString512Bytes start, ref FixedString512Bytes end, float t, ScrambleMode scrambleMode, bool richTextEnabled, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString512Bytes result)
		{
			Interpolate_0000008B_0024BurstDirectCall.Invoke(ref start, ref end, t, scrambleMode, richTextEnabled, ref randomState, ref customScrambleChars, out result);
		}

		private static void FillText(ref FixedString512Bytes start, ref FixedString512Bytes end, float t, ScrambleMode scrambleMode, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString512Bytes result)
		{
			int utf8CharCount = GetUtf8CharCount(ref start);
			int utf8CharCount2 = GetUtf8CharCount(ref end);
			int num = math.max(utf8CharCount, utf8CharCount2);
			int num2 = (int)math.round((float)num * t);
			FixedString512Bytes.Enumerator enumerator = start.GetEnumerator();
			FixedString512Bytes.Enumerator enumerator2 = end.GetEnumerator();
			result = default(FixedString512Bytes);
			for (int i = 0; i < num; i++)
			{
				bool flag = enumerator.MoveNext();
				bool flag2 = enumerator2.MoveNext();
				if (i < num2)
				{
					if (flag2)
					{
						FixedStringMethods.Append(ref result, enumerator2.Current);
					}
				}
				else if (flag)
				{
					FixedStringMethods.Append(ref result, enumerator.Current);
				}
			}
			FillScrambleChars(ref result, scrambleMode, ref randomState, ref customScrambleChars, num - num2);
		}

		private static void FillRichText(ref UnsafeList<RichTextSymbol512Bytes> startSymbols, ref UnsafeList<RichTextSymbol512Bytes> endSymbols, int startTextUtf8Length, int endTextUtf8Length, float t, ScrambleMode scrambleMode, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString512Bytes result)
		{
			int num = math.max(startTextUtf8Length, endTextUtf8Length);
			int num2 = (int)math.round((float)num * t);
			int resultRichTextLength;
			FixedString512Bytes input = SliceSymbols(ref endSymbols, 0, num2, out resultRichTextLength);
			int resultRichTextLength2;
			FixedString512Bytes input2 = SliceSymbols(ref startSymbols, num2 + 1, num - 1, out resultRichTextLength2);
			result = default(FixedString512Bytes);
			FixedStringMethods.Append(ref result, in input);
			FixedStringMethods.Append(ref result, in input2);
			FillScrambleChars(ref result, scrambleMode, ref randomState, ref customScrambleChars, num - (resultRichTextLength + resultRichTextLength2));
		}

		private static void FillScrambleChars(ref FixedString512Bytes target, ScrambleMode scrambleMode, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, int count)
		{
			if (scrambleMode == ScrambleMode.None)
			{
				return;
			}
			if (randomState.state == 0)
			{
				randomState.InitState();
			}
			if (scrambleMode == ScrambleMode.Custom)
			{
				int utf8CharCount = GetUtf8CharCount(ref customScrambleChars);
				for (int i = 0; i < count; i++)
				{
					FixedStringMethods.Append(ref target, GetRuneOf(ref customScrambleChars, randomState.NextInt(0, utf8CharCount)));
				}
			}
			else
			{
				for (int j = 0; j < count; j++)
				{
					FixedStringMethods.Append(ref target, GetScrambleChar(scrambleMode, ref randomState));
				}
			}
		}

		private unsafe static FixedString512Bytes SliceSymbols(ref UnsafeList<RichTextSymbol512Bytes> symbols, int from, int to, out int resultRichTextLength)
		{
			FixedString512Bytes fs = default(FixedString512Bytes);
			RichTextSymbol512Bytes* ptr = symbols.Ptr;
			int num = 0;
			int num2 = 0;
			resultRichTextLength = 0;
			for (int i = 0; i < symbols.Length; i++)
			{
				RichTextSymbol512Bytes* ptr2 = ptr + i;
				switch (ptr2->Type)
				{
				case RichTextSymbolType.Text:
				{
					FixedString512Bytes.Enumerator enumerator = ptr2->Text.GetEnumerator();
					while (enumerator.MoveNext())
					{
						Unicode.Rune current = enumerator.Current;
						if (from <= num && num < to)
						{
							FixedStringMethods.Append(ref fs, current);
							resultRichTextLength++;
						}
						num++;
						if (num >= to && num2 == 0)
						{
							goto end_IL_0037;
						}
					}
					continue;
				}
				case RichTextSymbolType.TagStart:
					FixedStringMethods.Append(ref fs, in ptr2->Text);
					num2++;
					continue;
				case RichTextSymbolType.TagEnd:
					FixedStringMethods.Append(ref fs, in ptr2->Text);
					num2--;
					if (num < to || num2 != 0)
					{
						continue;
					}
					break;
				default:
					continue;
					end_IL_0037:
					break;
				}
				break;
			}
			return fs;
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EGetUtf8CharCount_00000090_0024PostfixBurstDelegate))]
		public static int GetUtf8CharCount(ref FixedString4096Bytes runes)
		{
			return GetUtf8CharCount_00000090_0024BurstDirectCall.Invoke(ref runes);
		}

		private static Unicode.Rune GetRuneOf(ref FixedString4096Bytes text, int charIndex)
		{
			int num = 0;
			FixedString4096Bytes.Enumerator enumerator = text.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (num == charIndex)
				{
					return enumerator.Current;
				}
				num++;
			}
			return Unicode.BadRune;
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EInterpolate_00000092_0024PostfixBurstDelegate))]
		public static void Interpolate(ref FixedString4096Bytes start, ref FixedString4096Bytes end, float t, ScrambleMode scrambleMode, bool richTextEnabled, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString4096Bytes result)
		{
			Interpolate_00000092_0024BurstDirectCall.Invoke(ref start, ref end, t, scrambleMode, richTextEnabled, ref randomState, ref customScrambleChars, out result);
		}

		private static void FillText(ref FixedString4096Bytes start, ref FixedString4096Bytes end, float t, ScrambleMode scrambleMode, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString4096Bytes result)
		{
			int utf8CharCount = GetUtf8CharCount(ref start);
			int utf8CharCount2 = GetUtf8CharCount(ref end);
			int num = math.max(utf8CharCount, utf8CharCount2);
			int num2 = (int)math.round((float)num * t);
			FixedString4096Bytes.Enumerator enumerator = start.GetEnumerator();
			FixedString4096Bytes.Enumerator enumerator2 = end.GetEnumerator();
			result = default(FixedString4096Bytes);
			for (int i = 0; i < num; i++)
			{
				bool flag = enumerator.MoveNext();
				bool flag2 = enumerator2.MoveNext();
				if (i < num2)
				{
					if (flag2)
					{
						FixedStringMethods.Append(ref result, enumerator2.Current);
					}
				}
				else if (flag)
				{
					FixedStringMethods.Append(ref result, enumerator.Current);
				}
			}
			FillScrambleChars(ref result, scrambleMode, ref randomState, ref customScrambleChars, num - num2);
		}

		private static void FillRichText(ref UnsafeList<RichTextSymbol4096Bytes> startSymbols, ref UnsafeList<RichTextSymbol4096Bytes> endSymbols, int startTextUtf8Length, int endTextUtf8Length, float t, ScrambleMode scrambleMode, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString4096Bytes result)
		{
			int num = math.max(startTextUtf8Length, endTextUtf8Length);
			int num2 = (int)math.round((float)num * t);
			int resultRichTextLength;
			FixedString4096Bytes input = SliceSymbols(ref endSymbols, 0, num2, out resultRichTextLength);
			int resultRichTextLength2;
			FixedString4096Bytes input2 = SliceSymbols(ref startSymbols, num2 + 1, num - 1, out resultRichTextLength2);
			result = default(FixedString4096Bytes);
			FixedStringMethods.Append(ref result, in input);
			FixedStringMethods.Append(ref result, in input2);
			FillScrambleChars(ref result, scrambleMode, ref randomState, ref customScrambleChars, num - (resultRichTextLength + resultRichTextLength2));
		}

		private static void FillScrambleChars(ref FixedString4096Bytes target, ScrambleMode scrambleMode, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, int count)
		{
			if (scrambleMode == ScrambleMode.None)
			{
				return;
			}
			if (randomState.state == 0)
			{
				randomState.InitState();
			}
			if (scrambleMode == ScrambleMode.Custom)
			{
				int utf8CharCount = GetUtf8CharCount(ref customScrambleChars);
				for (int i = 0; i < count; i++)
				{
					FixedStringMethods.Append(ref target, GetRuneOf(ref customScrambleChars, randomState.NextInt(0, utf8CharCount)));
				}
			}
			else
			{
				for (int j = 0; j < count; j++)
				{
					FixedStringMethods.Append(ref target, GetScrambleChar(scrambleMode, ref randomState));
				}
			}
		}

		private unsafe static FixedString4096Bytes SliceSymbols(ref UnsafeList<RichTextSymbol4096Bytes> symbols, int from, int to, out int resultRichTextLength)
		{
			FixedString4096Bytes fs = default(FixedString4096Bytes);
			RichTextSymbol4096Bytes* ptr = symbols.Ptr;
			int num = 0;
			int num2 = 0;
			resultRichTextLength = 0;
			for (int i = 0; i < symbols.Length; i++)
			{
				RichTextSymbol4096Bytes* ptr2 = ptr + i;
				switch (ptr2->Type)
				{
				case RichTextSymbolType.Text:
				{
					FixedString4096Bytes.Enumerator enumerator = ptr2->Text.GetEnumerator();
					while (enumerator.MoveNext())
					{
						Unicode.Rune current = enumerator.Current;
						if (from <= num && num < to)
						{
							FixedStringMethods.Append(ref fs, current);
							resultRichTextLength++;
						}
						num++;
						if (num >= to && num2 == 0)
						{
							goto end_IL_0037;
						}
					}
					continue;
				}
				case RichTextSymbolType.TagStart:
					FixedStringMethods.Append(ref fs, in ptr2->Text);
					num2++;
					continue;
				case RichTextSymbolType.TagEnd:
					FixedStringMethods.Append(ref fs, in ptr2->Text);
					num2--;
					if (num < to || num2 != 0)
					{
						continue;
					}
					break;
				default:
					continue;
					end_IL_0037:
					break;
				}
				break;
			}
			return fs;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static int GetUtf8CharCount_0024BurstManaged(ref FixedString32Bytes runes)
		{
			int num = 0;
			FixedString32Bytes.Enumerator enumerator = runes.GetEnumerator();
			while (enumerator.MoveNext())
			{
				num++;
			}
			return num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void Interpolate_0024BurstManaged(ref FixedString32Bytes start, ref FixedString32Bytes end, float t, ScrambleMode scrambleMode, bool richTextEnabled, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString32Bytes result)
		{
			if (richTextEnabled)
			{
				RichTextParser.GetSymbols(ref start, Allocator.Temp, out var symbols, out var charCount);
				RichTextParser.GetSymbols(ref end, Allocator.Temp, out var symbols2, out var charCount2);
				FillRichText(ref symbols, ref symbols2, charCount, charCount2, t, scrambleMode, ref randomState, ref customScrambleChars, out result);
				symbols.Dispose();
				symbols2.Dispose();
			}
			else
			{
				FillText(ref start, ref end, t, scrambleMode, ref randomState, ref customScrambleChars, out result);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static int GetUtf8CharCount_0024BurstManaged(ref FixedString64Bytes runes)
		{
			int num = 0;
			FixedString64Bytes.Enumerator enumerator = runes.GetEnumerator();
			while (enumerator.MoveNext())
			{
				num++;
			}
			return num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void Interpolate_0024BurstManaged(ref FixedString64Bytes start, ref FixedString64Bytes end, float t, ScrambleMode scrambleMode, bool richTextEnabled, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString64Bytes result)
		{
			if (richTextEnabled)
			{
				RichTextParser.GetSymbols(ref start, Allocator.Temp, out var symbols, out var charCount);
				RichTextParser.GetSymbols(ref end, Allocator.Temp, out var symbols2, out var charCount2);
				FillRichText(ref symbols, ref symbols2, charCount, charCount2, t, scrambleMode, ref randomState, ref customScrambleChars, out result);
				symbols.Dispose();
				symbols2.Dispose();
			}
			else
			{
				FillText(ref start, ref end, t, scrambleMode, ref randomState, ref customScrambleChars, out result);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static int GetUtf8CharCount_0024BurstManaged(ref FixedString128Bytes runes)
		{
			int num = 0;
			FixedString128Bytes.Enumerator enumerator = runes.GetEnumerator();
			while (enumerator.MoveNext())
			{
				num++;
			}
			return num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void Interpolate_0024BurstManaged(ref FixedString128Bytes start, ref FixedString128Bytes end, float t, ScrambleMode scrambleMode, bool richTextEnabled, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString128Bytes result)
		{
			if (richTextEnabled)
			{
				RichTextParser.GetSymbols(ref start, Allocator.Temp, out var symbols, out var charCount);
				RichTextParser.GetSymbols(ref end, Allocator.Temp, out var symbols2, out var charCount2);
				FillRichText(ref symbols, ref symbols2, charCount, charCount2, t, scrambleMode, ref randomState, ref customScrambleChars, out result);
				symbols.Dispose();
				symbols2.Dispose();
			}
			else
			{
				FillText(ref start, ref end, t, scrambleMode, ref randomState, ref customScrambleChars, out result);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static int GetUtf8CharCount_0024BurstManaged(ref FixedString512Bytes runes)
		{
			int num = 0;
			FixedString512Bytes.Enumerator enumerator = runes.GetEnumerator();
			while (enumerator.MoveNext())
			{
				num++;
			}
			return num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void Interpolate_0024BurstManaged(ref FixedString512Bytes start, ref FixedString512Bytes end, float t, ScrambleMode scrambleMode, bool richTextEnabled, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString512Bytes result)
		{
			if (richTextEnabled)
			{
				RichTextParser.GetSymbols(ref start, Allocator.Temp, out var symbols, out var charCount);
				RichTextParser.GetSymbols(ref end, Allocator.Temp, out var symbols2, out var charCount2);
				FillRichText(ref symbols, ref symbols2, charCount, charCount2, t, scrambleMode, ref randomState, ref customScrambleChars, out result);
				symbols.Dispose();
				symbols2.Dispose();
			}
			else
			{
				FillText(ref start, ref end, t, scrambleMode, ref randomState, ref customScrambleChars, out result);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static int GetUtf8CharCount_0024BurstManaged(ref FixedString4096Bytes runes)
		{
			int num = 0;
			FixedString4096Bytes.Enumerator enumerator = runes.GetEnumerator();
			while (enumerator.MoveNext())
			{
				num++;
			}
			return num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void Interpolate_0024BurstManaged(ref FixedString4096Bytes start, ref FixedString4096Bytes end, float t, ScrambleMode scrambleMode, bool richTextEnabled, ref Unity.Mathematics.Random randomState, ref FixedString64Bytes customScrambleChars, out FixedString4096Bytes result)
		{
			if (richTextEnabled)
			{
				RichTextParser.GetSymbols(ref start, Allocator.Temp, out var symbols, out var charCount);
				RichTextParser.GetSymbols(ref end, Allocator.Temp, out var symbols2, out var charCount2);
				FillRichText(ref symbols, ref symbols2, charCount, charCount2, t, scrambleMode, ref randomState, ref customScrambleChars, out result);
				symbols.Dispose();
				symbols2.Dispose();
			}
			else
			{
				FillText(ref start, ref end, t, scrambleMode, ref randomState, ref customScrambleChars, out result);
			}
		}
	}
}
