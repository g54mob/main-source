using System;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace MathNet.Numerics.LinearAlgebra.Single.Factorization
{
	internal abstract class Cholesky : Cholesky<float>
	{
		public override float Determinant
		{
			get
			{
				float num = 1f;
				for (int i = 0; i < base.Factor.RowCount; i++)
				{
					float num2 = base.Factor.At(i, i);
					num *= num2 * num2;
				}
				return num;
			}
		}

		public override float DeterminantLn
		{
			get
			{
				float num = 0f;
				for (int i = 0; i < base.Factor.RowCount; i++)
				{
					num += 2f * Convert.ToSingle(Math.Log(base.Factor.At(i, i)));
				}
				return num;
			}
		}

		protected Cholesky(Matrix<float> factor)
			: base(factor)
		{
		}
	}
}
