using System;
using System.Collections.Generic;
using FishNet.Documenting;
using FishNet.Serializing.Helping;

namespace FishNet.Serializing
{
	[APIExclude]
	public static class WriterExtensions
	{
		internal static HashSet<Type> DefaultPackedTypes;

		static WriterExtensions()
		{
		}

		[CodegenExclude]
		internal static void WriteUInt32(byte[] dst, uint value, ref int position)
		{
		}

		[CodegenExclude]
		internal static void WriteUInt64(byte[] dst, ulong value, ref int position)
		{
		}
	}
}
