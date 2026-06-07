using MathNet.Numerics.LinearAlgebra.Factorization;

namespace MathNet.Numerics.LinearAlgebra.Complex32.Factorization
{
	internal abstract class LU : LU<MathNet.Numerics.Complex32>
	{
		public override MathNet.Numerics.Complex32 Determinant
		{
			get
			{
				MathNet.Numerics.Complex32 one = MathNet.Numerics.Complex32.One;
				for (int i = 0; i < Factors.RowCount; i++)
				{
					if (Pivots[i] != i)
					{
						one *= -Factors.At(i, i);
					}
					else
					{
						one *= Factors.At(i, i);
					}
				}
				return one;
			}
		}

		protected LU(Matrix<MathNet.Numerics.Complex32> factors, int[] pivots)
			: base(factors, pivots)
		{
		}
	}
}
