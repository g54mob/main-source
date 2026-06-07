using System;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace MathNet.Numerics.LinearAlgebra.Complex.Factorization
{
	internal abstract class GramSchmidt : GramSchmidt<System.Numerics.Complex>
	{
		public override System.Numerics.Complex Determinant
		{
			get
			{
				if (FullR.RowCount != FullR.ColumnCount)
				{
					throw new ArgumentException("Matrix must be square.");
				}
				System.Numerics.Complex one = System.Numerics.Complex.One;
				for (int i = 0; i < FullR.ColumnCount; i++)
				{
					one *= FullR.At(i, i);
					if (FullR.At(i, i).Magnitude.AlmostEqual(0.0))
					{
						return 0;
					}
				}
				return one.Magnitude;
			}
		}

		public override bool IsFullRank
		{
			get
			{
				for (int i = 0; i < FullR.ColumnCount; i++)
				{
					if (FullR.At(i, i).Magnitude.AlmostEqual(0.0))
					{
						return false;
					}
				}
				return true;
			}
		}

		protected GramSchmidt(Matrix<System.Numerics.Complex> q, Matrix<System.Numerics.Complex> rFull)
			: base(q, rFull)
		{
		}
	}
}
