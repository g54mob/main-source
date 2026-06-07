using System;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace MathNet.Numerics.LinearAlgebra.Double.Factorization
{
	internal abstract class Cholesky : Cholesky<double>
	{
		public override double Determinant
		{
			get
			{
				double num = 1.0;
				for (int i = 0; i < base.Factor.RowCount; i++)
				{
					double num2 = base.Factor.At(i, i);
					num *= num2 * num2;
				}
				return num;
			}
		}

		public override double DeterminantLn
		{
			get
			{
				double num = 0.0;
				for (int i = 0; i < base.Factor.RowCount; i++)
				{
					num += 2.0 * Math.Log(base.Factor.At(i, i));
				}
				return num;
			}
		}

		protected Cholesky(Matrix<double> factor)
			: base(factor)
		{
		}
	}
}
