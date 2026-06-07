using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace MathNet.Numerics.LinearAlgebra.Complex.Factorization
{
	internal abstract class LU : LU<System.Numerics.Complex>
	{
		public override System.Numerics.Complex Determinant
		{
			get
			{
				System.Numerics.Complex one = System.Numerics.Complex.One;
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

		protected LU(Matrix<System.Numerics.Complex> factors, int[] pivots)
			: base(factors, pivots)
		{
		}
	}
}
