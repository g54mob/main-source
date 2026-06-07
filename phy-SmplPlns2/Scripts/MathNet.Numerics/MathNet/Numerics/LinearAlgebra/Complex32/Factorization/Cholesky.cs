using MathNet.Numerics.LinearAlgebra.Factorization;

namespace MathNet.Numerics.LinearAlgebra.Complex32.Factorization
{
	internal abstract class Cholesky : Cholesky<MathNet.Numerics.Complex32>
	{
		public override MathNet.Numerics.Complex32 Determinant
		{
			get
			{
				MathNet.Numerics.Complex32 one = MathNet.Numerics.Complex32.One;
				for (int i = 0; i < base.Factor.RowCount; i++)
				{
					MathNet.Numerics.Complex32 complex = base.Factor.At(i, i);
					one *= complex * complex;
				}
				return one;
			}
		}

		public override MathNet.Numerics.Complex32 DeterminantLn
		{
			get
			{
				MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
				for (int i = 0; i < base.Factor.RowCount; i++)
				{
					zero += 2f * base.Factor.At(i, i).NaturalLogarithm();
				}
				return zero;
			}
		}

		protected Cholesky(Matrix<MathNet.Numerics.Complex32> factor)
			: base(factor)
		{
		}
	}
}
