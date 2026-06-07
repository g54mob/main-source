using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace BCnEncoder.Shared
{
	internal static class BinaryReaderWriterExtensions
	{
		public unsafe static void WriteStruct<T>(this BinaryWriter bw, T t) where T : unmanaged
		{
			int num = Unsafe.SizeOf<T>();
			byte* ptr = stackalloc byte[(int)(uint)num];
			Unsafe.Write(ptr, t);
			Span<byte> span = new Span<byte>(ptr, num);
			bw.Write(span);
		}

		public unsafe static T ReadStruct<T>(this BinaryReader br) where T : unmanaged
		{
			int num = Unsafe.SizeOf<T>();
			byte* ptr = stackalloc byte[(int)(uint)num];
			Span<byte> buffer = new Span<byte>(ptr, num);
			br.Read(buffer);
			return Unsafe.Read<T>(ptr);
		}

		public static void AddPadding(this BinaryWriter bw, uint padding)
		{
			for (int i = 0; i < padding; i++)
			{
				bw.Write((byte)0);
			}
		}

		public static void AddPadding(this BinaryWriter bw, int padding)
		{
			bw.AddPadding((uint)padding);
		}

		public static void SkipPadding(this BinaryReader br, uint padding)
		{
			br.BaseStream.Seek(padding, SeekOrigin.Current);
		}

		public static void SkipPadding(this BinaryReader br, int padding)
		{
			br.SkipPadding((uint)padding);
		}
	}
}
