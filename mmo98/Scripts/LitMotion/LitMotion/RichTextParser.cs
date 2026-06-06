using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace LitMotion
{
	[BurstCompile]
	internal static class RichTextParser
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void GetSymbols_00000122_0024PostfixBurstDelegate(ref FixedString32Bytes source, Allocator allocator, out UnsafeList<RichTextSymbol32Bytes> symbols, out int charCount);

		internal static class GetSymbols_00000122_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<GetSymbols_00000122_0024PostfixBurstDelegate>(GetSymbols).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref FixedString32Bytes source, Allocator allocator, out UnsafeList<RichTextSymbol32Bytes> symbols, out int charCount)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref FixedString32Bytes, Allocator, ref UnsafeList<RichTextSymbol32Bytes>, ref int, void>)functionPointer)(ref source, allocator, ref symbols, ref charCount);
						return;
					}
				}
				GetSymbols_0024BurstManaged(ref source, allocator, out symbols, out charCount);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void GetSymbols_00000123_0024PostfixBurstDelegate(ref FixedString64Bytes source, Allocator allocator, out UnsafeList<RichTextSymbol64Bytes> symbols, out int charCount);

		internal static class GetSymbols_00000123_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<GetSymbols_00000123_0024PostfixBurstDelegate>(GetSymbols).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref FixedString64Bytes source, Allocator allocator, out UnsafeList<RichTextSymbol64Bytes> symbols, out int charCount)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref FixedString64Bytes, Allocator, ref UnsafeList<RichTextSymbol64Bytes>, ref int, void>)functionPointer)(ref source, allocator, ref symbols, ref charCount);
						return;
					}
				}
				GetSymbols_0024BurstManaged(ref source, allocator, out symbols, out charCount);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void GetSymbols_00000124_0024PostfixBurstDelegate(ref FixedString128Bytes source, Allocator allocator, out UnsafeList<RichTextSymbol128Bytes> symbols, out int charCount);

		internal static class GetSymbols_00000124_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<GetSymbols_00000124_0024PostfixBurstDelegate>(GetSymbols).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref FixedString128Bytes source, Allocator allocator, out UnsafeList<RichTextSymbol128Bytes> symbols, out int charCount)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref FixedString128Bytes, Allocator, ref UnsafeList<RichTextSymbol128Bytes>, ref int, void>)functionPointer)(ref source, allocator, ref symbols, ref charCount);
						return;
					}
				}
				GetSymbols_0024BurstManaged(ref source, allocator, out symbols, out charCount);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void GetSymbols_00000125_0024PostfixBurstDelegate(ref FixedString512Bytes source, Allocator allocator, out UnsafeList<RichTextSymbol512Bytes> symbols, out int charCount);

		internal static class GetSymbols_00000125_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<GetSymbols_00000125_0024PostfixBurstDelegate>(GetSymbols).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref FixedString512Bytes source, Allocator allocator, out UnsafeList<RichTextSymbol512Bytes> symbols, out int charCount)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref FixedString512Bytes, Allocator, ref UnsafeList<RichTextSymbol512Bytes>, ref int, void>)functionPointer)(ref source, allocator, ref symbols, ref charCount);
						return;
					}
				}
				GetSymbols_0024BurstManaged(ref source, allocator, out symbols, out charCount);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void GetSymbols_00000126_0024PostfixBurstDelegate(ref FixedString4096Bytes source, Allocator allocator, out UnsafeList<RichTextSymbol4096Bytes> symbols, out int charCount);

		internal static class GetSymbols_00000126_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<GetSymbols_00000126_0024PostfixBurstDelegate>(GetSymbols).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref FixedString4096Bytes source, Allocator allocator, out UnsafeList<RichTextSymbol4096Bytes> symbols, out int charCount)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref FixedString4096Bytes, Allocator, ref UnsafeList<RichTextSymbol4096Bytes>, ref int, void>)functionPointer)(ref source, allocator, ref symbols, ref charCount);
						return;
					}
				}
				GetSymbols_0024BurstManaged(ref source, allocator, out symbols, out charCount);
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EGetSymbols_00000122_0024PostfixBurstDelegate))]
		public static void GetSymbols(ref FixedString32Bytes source, Allocator allocator, out UnsafeList<RichTextSymbol32Bytes> symbols, out int charCount)
		{
			GetSymbols_00000122_0024BurstDirectCall.Invoke(ref source, allocator, out symbols, out charCount);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EGetSymbols_00000123_0024PostfixBurstDelegate))]
		public static void GetSymbols(ref FixedString64Bytes source, Allocator allocator, out UnsafeList<RichTextSymbol64Bytes> symbols, out int charCount)
		{
			GetSymbols_00000123_0024BurstDirectCall.Invoke(ref source, allocator, out symbols, out charCount);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EGetSymbols_00000124_0024PostfixBurstDelegate))]
		public static void GetSymbols(ref FixedString128Bytes source, Allocator allocator, out UnsafeList<RichTextSymbol128Bytes> symbols, out int charCount)
		{
			GetSymbols_00000124_0024BurstDirectCall.Invoke(ref source, allocator, out symbols, out charCount);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EGetSymbols_00000125_0024PostfixBurstDelegate))]
		public static void GetSymbols(ref FixedString512Bytes source, Allocator allocator, out UnsafeList<RichTextSymbol512Bytes> symbols, out int charCount)
		{
			GetSymbols_00000125_0024BurstDirectCall.Invoke(ref source, allocator, out symbols, out charCount);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EGetSymbols_00000126_0024PostfixBurstDelegate))]
		public static void GetSymbols(ref FixedString4096Bytes source, Allocator allocator, out UnsafeList<RichTextSymbol4096Bytes> symbols, out int charCount)
		{
			GetSymbols_00000126_0024BurstDirectCall.Invoke(ref source, allocator, out symbols, out charCount);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void GetSymbols_0024BurstManaged(ref FixedString32Bytes source, Allocator allocator, out UnsafeList<RichTextSymbol32Bytes> symbols, out int charCount)
		{
			symbols = new UnsafeList<RichTextSymbol32Bytes>(32, allocator);
			charCount = 0;
			NativeText fs = new NativeText(32, Allocator.Temp);
			FixedString32Bytes.Enumerator enumerator = source.GetEnumerator();
			RichTextSymbolType richTextSymbolType = RichTextSymbolType.Text;
			Unicode.Rune rune = default(Unicode.Rune);
			while (enumerator.MoveNext())
			{
				Unicode.Rune current = enumerator.Current;
				if (current.value == 60 && richTextSymbolType != RichTextSymbolType.TagStart && richTextSymbolType != RichTextSymbolType.TagEnd)
				{
					if (fs.Length > 0)
					{
						FixedString32Bytes fs2 = default(FixedString32Bytes);
						FixedStringMethods.CopyFrom(ref fs2, in fs);
						symbols.Add(new RichTextSymbol32Bytes(richTextSymbolType, in fs2));
						if (richTextSymbolType == RichTextSymbolType.Text)
						{
							charCount += FixedStringHelper.GetUtf8CharCount(ref fs2);
						}
						fs.Clear();
					}
					FixedStringMethods.Append(ref fs, current);
					richTextSymbolType = RichTextSymbolType.TagStart;
				}
				else if (current.value == 47 && rune.value == 60)
				{
					FixedStringMethods.Append(ref fs, current);
					richTextSymbolType = RichTextSymbolType.TagEnd;
				}
				else if (current.value == 62 && (richTextSymbolType == RichTextSymbolType.TagStart || richTextSymbolType == RichTextSymbolType.TagEnd))
				{
					FixedStringMethods.Append(ref fs, current);
					if (fs.Length > 0)
					{
						FixedString32Bytes fs3 = default(FixedString32Bytes);
						FixedStringMethods.CopyFrom(ref fs3, in fs);
						symbols.Add(new RichTextSymbol32Bytes(richTextSymbolType, in fs3));
						if (richTextSymbolType == RichTextSymbolType.Text)
						{
							charCount += FixedStringHelper.GetUtf8CharCount(ref fs3);
						}
						fs.Clear();
					}
					richTextSymbolType = RichTextSymbolType.Text;
				}
				else
				{
					FixedStringMethods.Append(ref fs, current);
				}
				rune = current;
			}
			if (fs.Length > 0)
			{
				FixedString32Bytes fs4 = default(FixedString32Bytes);
				FixedStringMethods.CopyFrom(ref fs4, in fs);
				symbols.Add(new RichTextSymbol32Bytes(richTextSymbolType, in fs4));
				charCount += FixedStringHelper.GetUtf8CharCount(ref fs4);
			}
			fs.Dispose();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void GetSymbols_0024BurstManaged(ref FixedString64Bytes source, Allocator allocator, out UnsafeList<RichTextSymbol64Bytes> symbols, out int charCount)
		{
			symbols = new UnsafeList<RichTextSymbol64Bytes>(32, allocator);
			charCount = 0;
			NativeText fs = new NativeText(64, Allocator.Temp);
			FixedString64Bytes.Enumerator enumerator = source.GetEnumerator();
			RichTextSymbolType richTextSymbolType = RichTextSymbolType.Text;
			Unicode.Rune rune = default(Unicode.Rune);
			while (enumerator.MoveNext())
			{
				Unicode.Rune current = enumerator.Current;
				if (current.value == 60 && richTextSymbolType != RichTextSymbolType.TagStart && richTextSymbolType != RichTextSymbolType.TagEnd)
				{
					if (fs.Length > 0)
					{
						FixedString64Bytes fs2 = default(FixedString64Bytes);
						FixedStringMethods.CopyFrom(ref fs2, in fs);
						symbols.Add(new RichTextSymbol64Bytes(richTextSymbolType, in fs2));
						if (richTextSymbolType == RichTextSymbolType.Text)
						{
							charCount += FixedStringHelper.GetUtf8CharCount(ref fs2);
						}
						fs.Clear();
					}
					FixedStringMethods.Append(ref fs, current);
					richTextSymbolType = RichTextSymbolType.TagStart;
				}
				else if (current.value == 47 && rune.value == 60)
				{
					FixedStringMethods.Append(ref fs, current);
					richTextSymbolType = RichTextSymbolType.TagEnd;
				}
				else if (current.value == 62 && (richTextSymbolType == RichTextSymbolType.TagStart || richTextSymbolType == RichTextSymbolType.TagEnd))
				{
					FixedStringMethods.Append(ref fs, current);
					if (fs.Length > 0)
					{
						FixedString64Bytes fs3 = default(FixedString64Bytes);
						FixedStringMethods.CopyFrom(ref fs3, in fs);
						symbols.Add(new RichTextSymbol64Bytes(richTextSymbolType, in fs3));
						if (richTextSymbolType == RichTextSymbolType.Text)
						{
							charCount += FixedStringHelper.GetUtf8CharCount(ref fs3);
						}
						fs.Clear();
					}
					richTextSymbolType = RichTextSymbolType.Text;
				}
				else
				{
					FixedStringMethods.Append(ref fs, current);
				}
				rune = current;
			}
			if (fs.Length > 0)
			{
				FixedString64Bytes fs4 = default(FixedString64Bytes);
				FixedStringMethods.CopyFrom(ref fs4, in fs);
				symbols.Add(new RichTextSymbol64Bytes(richTextSymbolType, in fs4));
				charCount += FixedStringHelper.GetUtf8CharCount(ref fs4);
			}
			fs.Dispose();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void GetSymbols_0024BurstManaged(ref FixedString128Bytes source, Allocator allocator, out UnsafeList<RichTextSymbol128Bytes> symbols, out int charCount)
		{
			symbols = new UnsafeList<RichTextSymbol128Bytes>(32, allocator);
			charCount = 0;
			NativeText fs = new NativeText(128, Allocator.Temp);
			FixedString128Bytes.Enumerator enumerator = source.GetEnumerator();
			RichTextSymbolType richTextSymbolType = RichTextSymbolType.Text;
			Unicode.Rune rune = default(Unicode.Rune);
			while (enumerator.MoveNext())
			{
				Unicode.Rune current = enumerator.Current;
				if (current.value == 60 && richTextSymbolType != RichTextSymbolType.TagStart && richTextSymbolType != RichTextSymbolType.TagEnd)
				{
					if (fs.Length > 0)
					{
						FixedString128Bytes fs2 = default(FixedString128Bytes);
						FixedStringMethods.CopyFrom(ref fs2, in fs);
						symbols.Add(new RichTextSymbol128Bytes(richTextSymbolType, in fs2));
						if (richTextSymbolType == RichTextSymbolType.Text)
						{
							charCount += FixedStringHelper.GetUtf8CharCount(ref fs2);
						}
						fs.Clear();
					}
					FixedStringMethods.Append(ref fs, current);
					richTextSymbolType = RichTextSymbolType.TagStart;
				}
				else if (current.value == 47 && rune.value == 60)
				{
					FixedStringMethods.Append(ref fs, current);
					richTextSymbolType = RichTextSymbolType.TagEnd;
				}
				else if (current.value == 62 && (richTextSymbolType == RichTextSymbolType.TagStart || richTextSymbolType == RichTextSymbolType.TagEnd))
				{
					FixedStringMethods.Append(ref fs, current);
					if (fs.Length > 0)
					{
						FixedString128Bytes fs3 = default(FixedString128Bytes);
						FixedStringMethods.CopyFrom(ref fs3, in fs);
						symbols.Add(new RichTextSymbol128Bytes(richTextSymbolType, in fs3));
						if (richTextSymbolType == RichTextSymbolType.Text)
						{
							charCount += FixedStringHelper.GetUtf8CharCount(ref fs3);
						}
						fs.Clear();
					}
					richTextSymbolType = RichTextSymbolType.Text;
				}
				else
				{
					FixedStringMethods.Append(ref fs, current);
				}
				rune = current;
			}
			if (fs.Length > 0)
			{
				FixedString128Bytes fs4 = default(FixedString128Bytes);
				FixedStringMethods.CopyFrom(ref fs4, in fs);
				symbols.Add(new RichTextSymbol128Bytes(richTextSymbolType, in fs4));
				charCount += FixedStringHelper.GetUtf8CharCount(ref fs4);
			}
			fs.Dispose();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void GetSymbols_0024BurstManaged(ref FixedString512Bytes source, Allocator allocator, out UnsafeList<RichTextSymbol512Bytes> symbols, out int charCount)
		{
			symbols = new UnsafeList<RichTextSymbol512Bytes>(32, allocator);
			charCount = 0;
			NativeText fs = new NativeText(512, Allocator.Temp);
			FixedString512Bytes.Enumerator enumerator = source.GetEnumerator();
			RichTextSymbolType richTextSymbolType = RichTextSymbolType.Text;
			Unicode.Rune rune = default(Unicode.Rune);
			while (enumerator.MoveNext())
			{
				Unicode.Rune current = enumerator.Current;
				if (current.value == 60 && richTextSymbolType != RichTextSymbolType.TagStart && richTextSymbolType != RichTextSymbolType.TagEnd)
				{
					if (fs.Length > 0)
					{
						FixedString512Bytes fs2 = default(FixedString512Bytes);
						FixedStringMethods.CopyFrom(ref fs2, in fs);
						symbols.Add(new RichTextSymbol512Bytes(richTextSymbolType, in fs2));
						if (richTextSymbolType == RichTextSymbolType.Text)
						{
							charCount += FixedStringHelper.GetUtf8CharCount(ref fs2);
						}
						fs.Clear();
					}
					FixedStringMethods.Append(ref fs, current);
					richTextSymbolType = RichTextSymbolType.TagStart;
				}
				else if (current.value == 47 && rune.value == 60)
				{
					FixedStringMethods.Append(ref fs, current);
					richTextSymbolType = RichTextSymbolType.TagEnd;
				}
				else if (current.value == 62 && (richTextSymbolType == RichTextSymbolType.TagStart || richTextSymbolType == RichTextSymbolType.TagEnd))
				{
					FixedStringMethods.Append(ref fs, current);
					if (fs.Length > 0)
					{
						FixedString512Bytes fs3 = default(FixedString512Bytes);
						FixedStringMethods.CopyFrom(ref fs3, in fs);
						symbols.Add(new RichTextSymbol512Bytes(richTextSymbolType, in fs3));
						if (richTextSymbolType == RichTextSymbolType.Text)
						{
							charCount += FixedStringHelper.GetUtf8CharCount(ref fs3);
						}
						fs.Clear();
					}
					richTextSymbolType = RichTextSymbolType.Text;
				}
				else
				{
					FixedStringMethods.Append(ref fs, current);
				}
				rune = current;
			}
			if (fs.Length > 0)
			{
				FixedString512Bytes fs4 = default(FixedString512Bytes);
				FixedStringMethods.CopyFrom(ref fs4, in fs);
				symbols.Add(new RichTextSymbol512Bytes(richTextSymbolType, in fs4));
				charCount += FixedStringHelper.GetUtf8CharCount(ref fs4);
			}
			fs.Dispose();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void GetSymbols_0024BurstManaged(ref FixedString4096Bytes source, Allocator allocator, out UnsafeList<RichTextSymbol4096Bytes> symbols, out int charCount)
		{
			symbols = new UnsafeList<RichTextSymbol4096Bytes>(32, allocator);
			charCount = 0;
			NativeText fs = new NativeText(4096, Allocator.Temp);
			FixedString4096Bytes.Enumerator enumerator = source.GetEnumerator();
			RichTextSymbolType richTextSymbolType = RichTextSymbolType.Text;
			Unicode.Rune rune = default(Unicode.Rune);
			while (enumerator.MoveNext())
			{
				Unicode.Rune current = enumerator.Current;
				if (current.value == 60 && richTextSymbolType != RichTextSymbolType.TagStart && richTextSymbolType != RichTextSymbolType.TagEnd)
				{
					if (fs.Length > 0)
					{
						FixedString4096Bytes fs2 = default(FixedString4096Bytes);
						FixedStringMethods.CopyFrom(ref fs2, in fs);
						symbols.Add(new RichTextSymbol4096Bytes(richTextSymbolType, in fs2));
						if (richTextSymbolType == RichTextSymbolType.Text)
						{
							charCount += FixedStringHelper.GetUtf8CharCount(ref fs2);
						}
						fs.Clear();
					}
					FixedStringMethods.Append(ref fs, current);
					richTextSymbolType = RichTextSymbolType.TagStart;
				}
				else if (current.value == 47 && rune.value == 60)
				{
					FixedStringMethods.Append(ref fs, current);
					richTextSymbolType = RichTextSymbolType.TagEnd;
				}
				else if (current.value == 62 && (richTextSymbolType == RichTextSymbolType.TagStart || richTextSymbolType == RichTextSymbolType.TagEnd))
				{
					FixedStringMethods.Append(ref fs, current);
					if (fs.Length > 0)
					{
						FixedString4096Bytes fs3 = default(FixedString4096Bytes);
						FixedStringMethods.CopyFrom(ref fs3, in fs);
						symbols.Add(new RichTextSymbol4096Bytes(richTextSymbolType, in fs3));
						if (richTextSymbolType == RichTextSymbolType.Text)
						{
							charCount += FixedStringHelper.GetUtf8CharCount(ref fs3);
						}
						fs.Clear();
					}
					richTextSymbolType = RichTextSymbolType.Text;
				}
				else
				{
					FixedStringMethods.Append(ref fs, current);
				}
				rune = current;
			}
			if (fs.Length > 0)
			{
				FixedString4096Bytes fs4 = default(FixedString4096Bytes);
				FixedStringMethods.CopyFrom(ref fs4, in fs);
				symbols.Add(new RichTextSymbol4096Bytes(richTextSymbolType, in fs4));
				charCount += FixedStringHelper.GetUtf8CharCount(ref fs4);
			}
			fs.Dispose();
		}
	}
}
