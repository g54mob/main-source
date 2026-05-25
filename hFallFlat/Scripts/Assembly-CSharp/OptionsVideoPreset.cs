public struct OptionsVideoPreset
{
	public int preset;

	public int clouds;

	public int shadows;

	public int texture;

	public int ao;

	public int aa;

	public int vsync;

	public int hdr;

	public int bloom;

	public int dof;

	public int chroma;

	public int exposure;

	public static OptionsVideoPreset Create(int qualityLevel)
	{
		switch (qualityLevel)
		{
		case 1:
			return new OptionsVideoPreset
			{
				preset = 1,
				clouds = 0,
				shadows = 0,
				texture = 0,
				ao = 0,
				aa = 0,
				vsync = 0,
				hdr = 0,
				bloom = 0,
				dof = 0,
				chroma = 0,
				exposure = 0
			};
		case 2:
			return new OptionsVideoPreset
			{
				preset = 2,
				clouds = 1,
				shadows = 1,
				texture = 1,
				ao = 0,
				aa = 0,
				vsync = 0,
				hdr = 0,
				bloom = 0,
				dof = 0,
				chroma = 0,
				exposure = 0
			};
		case 3:
			return new OptionsVideoPreset
			{
				preset = 3,
				clouds = 2,
				shadows = 2,
				texture = 2,
				ao = 0,
				aa = 0,
				vsync = 1,
				hdr = 1,
				bloom = 0,
				dof = 0,
				chroma = 0,
				exposure = 0
			};
		case 4:
			return new OptionsVideoPreset
			{
				preset = 4,
				clouds = 3,
				shadows = 3,
				texture = 2,
				ao = 2,
				aa = 2,
				vsync = 1,
				hdr = 1,
				bloom = 1,
				dof = 0,
				chroma = 1,
				exposure = 1
			};
		case 5:
			return new OptionsVideoPreset
			{
				preset = 5,
				clouds = 4,
				shadows = 4,
				texture = 2,
				ao = 1,
				aa = 3,
				vsync = 1,
				hdr = 1,
				bloom = 1,
				dof = 1,
				chroma = 1,
				exposure = 1
			};
		default:
			return default(OptionsVideoPreset);
		}
	}
}
