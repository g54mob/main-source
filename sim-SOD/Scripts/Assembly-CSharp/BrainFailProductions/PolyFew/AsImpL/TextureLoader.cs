using System.IO;
using UnityEngine;

namespace BrainFailProductions.PolyFew.AsImpL
{
	public class TextureLoader : MonoBehaviour
	{
		private class TgaHeader
		{
			public byte identSize;

			public byte colorMapType;

			public byte imageType;

			public ushort colorMapStart;

			public ushort colorMapLength;

			public byte colorMapBits;

			public ushort xStart;

			public ushort ySstart;

			public ushort width;

			public ushort height;

			public byte bits;

			public byte descriptor;
		}

		public static Texture2D LoadTextureFromUrl(string url)
		{
			return null;
		}

		public static Texture2D LoadTexture(string fileName)
		{
			return null;
		}

		public static Texture2D LoadTGA(string fileName)
		{
			return null;
		}

		public static Texture2D LoadDDSManual(string ddsPath)
		{
			return null;
		}

		public static Texture2D LoadTGA(Stream TGAStream)
		{
			return null;
		}

		private static TgaHeader LoadTgaHeader(BinaryReader r)
		{
			return null;
		}
	}
}
