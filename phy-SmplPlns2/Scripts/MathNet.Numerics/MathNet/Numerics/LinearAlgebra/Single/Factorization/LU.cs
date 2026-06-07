using MathNet.Numerics.LinearAlgebra.Factorization;

namespace MathNet.Numerics.LinearAlgebra.Single.Factorization
{
	internal abstract class LU : LU<float>
	{
		public override float Determinant
		{
			get
			{
				float num = 1f;
				for (int i = 0; i < Factors.RowCount; i++)
				{
					num = ((Pivots[i] == i) ? (num * Factors.At(i, i)) : (num * (0f - Factors.At(i, i))));
				}
				return num;
			}
		}

		protected LU(Matrix<float> factors, int[] pivots)
			: base(factors, pivots)
		{
		}
	}
}
