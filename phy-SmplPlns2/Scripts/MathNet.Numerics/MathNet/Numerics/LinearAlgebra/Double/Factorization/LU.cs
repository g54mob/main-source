using MathNet.Numerics.LinearAlgebra.Factorization;

namespace MathNet.Numerics.LinearAlgebra.Double.Factorization
{
	internal abstract class LU : LU<double>
	{
		public override double Determinant
		{
			get
			{
				double num = 1.0;
				for (int i = 0; i < Factors.RowCount; i++)
				{
					num = ((Pivots[i] == i) ? (num * Factors.At(i, i)) : (num * (0.0 - Factors.At(i, i))));
				}
				return num;
			}
		}

		protected LU(Matrix<double> factors, int[] pivots)
			: base(factors, pivots)
		{
		}
	}
}
