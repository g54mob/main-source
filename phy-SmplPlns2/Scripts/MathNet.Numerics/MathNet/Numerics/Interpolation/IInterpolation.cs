namespace MathNet.Numerics.Interpolation
{
	public interface IInterpolation
	{
		bool SupportsDifferentiation { get; }

		bool SupportsIntegration { get; }

		double Interpolate(double t);

		double Differentiate(double t);

		double Differentiate2(double t);

		double Integrate(double t);

		double Integrate(double a, double b);
	}
}
