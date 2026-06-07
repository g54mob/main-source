using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace VoxelMeshGeneration
{
	public struct RGBAtlasColor : IEquatable<RGBAtlasColor>
	{
		public readonly Color32 value;

		public readonly ce.MapType map;

		public static RGBAtlasColor wtv => default(RGBAtlasColor);

		public static RGBAtlasColor wtw => default(RGBAtlasColor);

		public static RGBAtlasColor wtx => default(RGBAtlasColor);

		public static RGBAtlasColor wty => default(RGBAtlasColor);

		public RGBAtlasColor(Color32 value, ce.MapType map = ce.MapType.Albedo)
		{
			this.value = default(Color32);
			this.map = default(ce.MapType);
		}

		public RGBAtlasColor(Color color, ce.MapType map = ce.MapType.Albedo)
		{
			value = default(Color32);
			this.map = default(ce.MapType);
		}

		public RGBAtlasColor(byte r, byte g, byte b, ce.MapType map = ce.MapType.Albedo)
		{
			value = default(Color32);
			this.map = default(ce.MapType);
		}

		[SpecialName]
		public static RGBAtlasColor des(Color a)
		{
			return default(RGBAtlasColor);
		}

		[SpecialName]
		public static RGBAtlasColor det(Color32 a)
		{
			return default(RGBAtlasColor);
		}

		public bool Equals(RGBAtlasColor other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		[SpecialName]
		public static bool deu(RGBAtlasColor a, RGBAtlasColor b)
		{
			return false;
		}

		[SpecialName]
		public static bool dev(RGBAtlasColor a, RGBAtlasColor b)
		{
			return false;
		}
	}
}
