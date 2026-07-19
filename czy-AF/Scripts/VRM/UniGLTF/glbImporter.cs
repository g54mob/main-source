using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UniGLTF
{
	public static class glbImporter
	{
		public const string GLB_MAGIC = "glTF";

		public const float GLB_VERSION = 2f;

		public static GlbChunkType ToChunkType(string src)
		{
			if (!(src == "BIN"))
			{
				if (src == "JSON")
				{
					return GlbChunkType.JSON;
				}
				throw new FormatException("unknown chunk type: " + src);
			}
			return GlbChunkType.BIN;
		}

		[Obsolete("Use ParseGlbChunks(bytes)")]
		public static List<GlbChunk> ParseGlbChanks(byte[] bytes)
		{
			return ParseGlbChunks(bytes);
		}

		public static List<GlbChunk> ParseGlbChunks(byte[] bytes)
		{
			if (bytes.Length == 0)
			{
				throw new Exception("empty bytes");
			}
			int num = 0;
			if (Encoding.ASCII.GetString(bytes, 0, 4) != "glTF")
			{
				throw new Exception("invalid magic");
			}
			num += 4;
			uint num2 = BitConverter.ToUInt32(bytes, num);
			if ((float)num2 != 2f)
			{
				Debug.LogWarningFormat("unknown version: {0}", num2);
				return null;
			}
			num += 4;
			num += 4;
			List<GlbChunk> list = new List<GlbChunk>();
			while (num < bytes.Length)
			{
				int num3 = BitConverter.ToInt32(bytes, num);
				num += 4;
				byte[] bytes2 = (from x in bytes.Skip(num).Take(4)
					where x != 0
					select x).ToArray();
				GlbChunkType chunkType = ToChunkType(Encoding.ASCII.GetString(bytes2));
				num += 4;
				list.Add(new GlbChunk
				{
					ChunkType = chunkType,
					Bytes = new ArraySegment<byte>(bytes, num, num3)
				});
				num += num3;
			}
			return list;
		}
	}
}
