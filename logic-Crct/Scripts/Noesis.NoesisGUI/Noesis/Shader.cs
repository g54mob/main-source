using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public struct Shader
	{
		public enum Enum
		{
			RGBA = 0,
			Mask = 1,
			Clear = 2,
			Path_Solid = 3,
			Path_Linear = 4,
			Path_Radial = 5,
			Path_Pattern = 6,
			Path_Pattern_Clamp = 7,
			Path_Pattern_Repeat = 8,
			Path_Pattern_MirrorU = 9,
			Path_Pattern_MirrorV = 10,
			Path_Pattern_Mirror = 11,
			Path_AA_Solid = 12,
			Path_AA_Linear = 13,
			Path_AA_Radial = 14,
			Path_AA_Pattern = 15,
			Path_AA_Pattern_Clamp = 16,
			Path_AA_Pattern_Repeat = 17,
			Path_AA_Pattern_MirrorU = 18,
			Path_AA_Pattern_MirrorV = 19,
			Path_AA_Pattern_Mirror = 20,
			SDF_Solid = 21,
			SDF_Linear = 22,
			SDF_Radial = 23,
			SDF_Pattern = 24,
			SDF_Pattern_Clamp = 25,
			SDF_Pattern_Repeat = 26,
			SDF_Pattern_MirrorU = 27,
			SDF_Pattern_MirrorV = 28,
			SDF_Pattern_Mirror = 29,
			SDF_LCD_Solid = 30,
			SDF_LCD_Linear = 31,
			SDF_LCD_Radial = 32,
			SDF_LCD_Pattern = 33,
			SDF_LCD_Pattern_Clamp = 34,
			SDF_LCD_Pattern_Repeat = 35,
			SDF_LCD_Pattern_MirrorU = 36,
			SDF_LCD_Pattern_MirrorV = 37,
			SDF_LCD_Pattern_Mirror = 38,
			Opacity_Solid = 39,
			Opacity_Linear = 40,
			Opacity_Radial = 41,
			Opacity_Pattern = 42,
			Opacity_Pattern_Clamp = 43,
			Opacity_Pattern_Repeat = 44,
			Opacity_Pattern_MirrorU = 45,
			Opacity_Pattern_MirrorV = 46,
			Opacity_Pattern_Mirror = 47,
			Upsample = 48,
			Downsample = 49,
			Shadow = 50,
			Blur = 51,
			Custom_Effect = 52,
			Count = 53
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		public struct Vertex
		{
			public enum Enum
			{
				Pos = 0,
				PosColor = 1,
				PosTex0 = 2,
				PosTex0Rect = 3,
				PosTex0RectTile = 4,
				PosColorCoverage = 5,
				PosTex0Coverage = 6,
				PosTex0CoverageRect = 7,
				PosTex0CoverageRectTile = 8,
				PosColorTex1_SDF = 9,
				PosTex0Tex1_SDF = 10,
				PosTex0Tex1Rect_SDF = 11,
				PosTex0Tex1RectTile_SDF = 12,
				PosColorTex1 = 13,
				PosTex0Tex1 = 14,
				PosTex0Tex1Rect = 15,
				PosTex0Tex1RectTile = 16,
				PosColorTex0Tex1 = 17,
				PosTex0Tex1_Downsample = 18,
				PosColorTex1Rect = 19,
				PosColorTex0RectImagePos = 20,
				Count = 21
			}

			[StructLayout((LayoutKind)0, Size = 1)]
			public struct Format
			{
				public enum Enum
				{
					Pos = 0,
					PosColor = 1,
					PosTex0 = 2,
					PosTex0Rect = 3,
					PosTex0RectTile = 4,
					PosColorCoverage = 5,
					PosTex0Coverage = 6,
					PosTex0CoverageRect = 7,
					PosTex0CoverageRectTile = 8,
					PosColorTex1 = 9,
					PosTex0Tex1 = 10,
					PosTex0Tex1Rect = 11,
					PosTex0Tex1RectTile = 12,
					PosColorTex0Tex1 = 13,
					PosColorTex1Rect = 14,
					PosColorTex0RectImagePos = 15,
					Count = 16
				}

				[StructLayout((LayoutKind)0, Size = 1)]
				public struct Attr
				{
					[Flags]
					public enum Enum
					{
						Pos = 1,
						Color = 2,
						Tex0 = 4,
						Tex1 = 8,
						Coverage = 0x10,
						Rect = 0x20,
						Tile = 0x40,
						ImagePos = 0x80
					}

					[StructLayout((LayoutKind)0, Size = 1)]
					public struct Type
					{
						public enum Enum
						{
							Float = 0,
							Float2 = 1,
							Float4 = 2,
							UByte4Norm = 3,
							UShort4Norm = 4,
							Count = 5
						}
					}
				}
			}
		}

		private readonly byte v;

		public int Index => 0;

		public string Name => null;

		public static Vertex.Enum VertexForShader(Enum shader)
		{
			return default(Vertex.Enum);
		}

		public static Vertex.Format.Enum FormatForVertex(Vertex.Enum vertex)
		{
			return default(Vertex.Format.Enum);
		}

		public static int SizeForFormat(Vertex.Format.Enum format)
		{
			return 0;
		}

		public static Vertex.Format.Attr.Enum AttributesForFormat(Vertex.Format.Enum format)
		{
			return default(Vertex.Format.Attr.Enum);
		}

		public static Vertex.Format.Attr.Type.Enum TypeForAttr(Vertex.Format.Attr.Enum attr)
		{
			return default(Vertex.Format.Attr.Type.Enum);
		}

		public static int SizeForType(Vertex.Format.Attr.Type.Enum type)
		{
			return 0;
		}
	}
}
