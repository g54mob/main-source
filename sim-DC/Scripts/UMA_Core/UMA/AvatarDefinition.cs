using System;
using System.Collections.Generic;

namespace UMA
{
	[Serializable]
	public struct AvatarDefinition
	{
		public string RaceName;

		public string[] Wardrobe;

		public SharedColorDef[] Colors;

		public DnaDef[] Dna;

		public void SetColors(OverlayColorData[] CurrentColors)
		{
		}

		public void SetDefaultColors(string[] colorNames, uint[] colors)
		{
		}

		public void SetDNA(UMAPredefinedDNA dna)
		{
		}

		public void SetDNA(DnaValue[] dna)
		{
		}

		public void SetDNA(string[] names, float[] values)
		{
		}

		public string ToCompressedString(string seperator = "\n")
		{
			return null;
		}

		public static AvatarDefinition FromCompressedString(string compressed, char seperator = '\n')
		{
			return default(AvatarDefinition);
		}

		public static AvatarDefinition FromCompressedStringV1(string compressed, char seperator = '\n')
		{
			return default(AvatarDefinition);
		}

		public static AvatarDefinition FromCompressedStringV2(string compressed, char seperator = '\n')
		{
			return default(AvatarDefinition);
		}

		private static SharedColorDef[] UnpackColors(string s)
		{
			return null;
		}

		private static void UnpackAColor(List<SharedColorDef> Colors, string s)
		{
		}

		public byte[] ToASCIIString()
		{
			return null;
		}

		public static AvatarDefinition FromASCIIString(byte[] asciiString)
		{
			return default(AvatarDefinition);
		}

		public static string Base64Encode(string plainText)
		{
			return null;
		}

		public static string Base64Decode(string base64EncodedData)
		{
			return null;
		}
	}
}
