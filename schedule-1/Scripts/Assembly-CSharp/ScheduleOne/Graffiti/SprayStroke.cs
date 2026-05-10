using System;
using System.Collections.Generic;
using System.IO;

namespace ScheduleOne.Graffiti
{
	[Serializable]
	public class SprayStroke
	{
		public const int MIN_STROKE_LENGTH = 6;

		public const int ANGLE_THRESHOLD_DEG = 10;

		public const float MAX_STROKE_DEVIATION = 5f;

		public const int FORWARD_SAMPLE_COUNT = 5;

		public UShort2 Start;

		public UShort2 End;

		public ESprayColor Color;

		public SprayStroke(UShort2 start, UShort2 end, ESprayColor color)
		{
		}

		public SprayStroke()
		{
		}

		public List<PixelData> GetPixelsFromStroke()
		{
			return null;
		}

		public static List<SprayStroke> GetStrokesFromPixels(List<UShort2> coords, ESprayColor color, SpraySurface surface)
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
	}
}
