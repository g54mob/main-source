using System.Numerics;

namespace MathNet.Numerics.Providers.FourierTransform
{
	public interface IFourierTransformProvider
	{
		bool IsAvailable();

		void InitializeVerify();

		void FreeResources();

		void Forward(Complex32[] samples, FourierTransformScaling scaling);

		void Forward(Complex[] samples, FourierTransformScaling scaling);

		void Backward(Complex32[] spectrum, FourierTransformScaling scaling);

		void Backward(Complex[] spectrum, FourierTransformScaling scaling);

		void ForwardReal(float[] samples, int n, FourierTransformScaling scaling);

		void ForwardReal(double[] samples, int n, FourierTransformScaling scaling);

		void BackwardReal(float[] spectrum, int n, FourierTransformScaling scaling);

		void BackwardReal(double[] spectrum, int n, FourierTransformScaling scaling);

		void ForwardMultidim(Complex32[] samples, int[] dimensions, FourierTransformScaling scaling);

		void ForwardMultidim(Complex[] samples, int[] dimensions, FourierTransformScaling scaling);

		void BackwardMultidim(Complex32[] spectrum, int[] dimensions, FourierTransformScaling scaling);

		void BackwardMultidim(Complex[] spectrum, int[] dimensions, FourierTransformScaling scaling);
	}
}
