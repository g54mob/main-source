namespace ModApi.Craft.Parts
{
	public struct PartMass
	{
		public float Dry;

		public float Wet;

		public float Total => Wet + Dry;

		public PartMass(float dry = 0f, float wet = 0f)
		{
			Wet = wet;
			Dry = dry;
		}

		public static PartMass operator *(PartMass a, float scalar)
		{
			return new PartMass(a.Dry * scalar, a.Wet * scalar);
		}

		public static PartMass operator *(float scalar, PartMass a)
		{
			return new PartMass(a.Dry * scalar, a.Wet * scalar);
		}

		public static PartMass operator +(PartMass a, PartMass b)
		{
			return new PartMass(a.Dry + b.Dry, a.Wet + b.Wet);
		}
	}
}
