using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace MathNet.Numerics.LinearAlgebra.Complex.Factorization
{
	internal abstract class Cholesky : Cholesky<System.Numerics.Complex>
	{
		public override System.Numerics.Complex Determinant
		{
			get
			{
				System.Numerics.Complex one = System.Numerics.Complex.One;
				for (int i = 0; i < base.Factor.RowCount; i++)
				{
					System.Numerics.Complex complex = base.Factor.At(i, i);
					one *= complex * complex;
				}
				return one;
			}
		}

		public override System.Numerics.Complex DeterminantLn
		{
			get
			{
				System.Numerics.Complex zero = System.Numerics.Complex.Zero;
				for (int i = 0; i < base.Factor.RowCount; i++)
				{
					zero += 2.0 * base.Factor.At(i, i).Ln();
				}
				return zero;
			}
		}

		protected Cholesky(Matrix<System.Numerics.Complex> factor)
			: base(factor)
		{
		}
	}
}
