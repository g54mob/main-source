using System;
using System.Collections.Generic;
using System.IO;

namespace ScheduleOne.Graffiti
{
	[Serializable]
	public class SprayStroke
	{
		public const int MinStrokeLength = 6;

		public const int AngleThreshold_Degrees = 10;

		public const float MaxStrokeDeviation = 5f;

		public const int ForwardSampleCount = 5;

		public const byte StrokeSize_LegacyDefault = 16;

		public const byte StrokeSize_Small = 10;

		public const byte StrokeSize_Medium = 16;

		public const byte StrokeSize_Large = 24;

		public const byte StrokeSize_ExtraLarge = 32;

		public static readonly byte[] StrokeSizePresets;

		public const byte StrokeSize_Min = 10;

		public const byte StrokeSize_Max = 32;

		public UShort2 Start;

		public UShort2 End;

		public ESprayColor Color;

		public byte StrokeSize;

		public SprayStroke(UShort2 start, UShort2 end, ESprayColor color, byte strokeSize)
		{
		}

		public SprayStroke GetCopy()
		{
			return null;
		}

		public SprayStroke()
		{
		}

		public List<PixelData> GetPixelsFromStroke()
		{
			return null;
		}

		public static List<SprayStroke> GetStrokesFromPixels(List<UShort2> coords, ESprayColor color, byte strokeSize, SpraySurface surface)
		{
			return null;
		}

		public void Serialize(BinaryWriter writer)
		{
		}

		public static SprayStroke Deserialize(BinaryReader reader)
		{
			return null;
		}

		public static List<SprayStroke> CopyAndShiftStrokes(List<SprayStroke> strokes, UShort2 shift)
		{
			return null;
		}

		public static void GetBounds(List<SprayStroke> strokes, out UShort2 min, out UShort2 max)
		{
			min = default(UShort2);
			max = default(UShort2);
		}
	}
}
