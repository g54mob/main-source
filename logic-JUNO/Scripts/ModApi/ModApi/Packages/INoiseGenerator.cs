namespace ModApi.Packages
{
	public interface INoiseGenerator
	{
		double GetNoise(double x, double y);

		double GetNoise(double x, double y, double z);
	}
}
