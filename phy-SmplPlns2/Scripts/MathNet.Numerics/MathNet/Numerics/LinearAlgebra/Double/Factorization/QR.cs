using System;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace MathNet.Numerics.LinearAlgebra.Double.Factorization
{
	internal abstract class QR : QR<double>
	{
		public override double Determinant
		{
			get
			{
				if (FullR.RowCount != FullR.ColumnCount)
				{
					throw new ArgumentException("Matrix must be square.");
				}
				double num = 1.0;
				for (int i = 0; i < FullR.ColumnCount; i++)
				{
					num *= FullR.At(i, i);
					if (Math.Abs(FullR.At(i, i)).AlmostEqual(0.0))
					{
						return 0.0;
					}
				}
				return Math.Abs(num);
			}
		}

		public override bool IsFullRank
		{
			get
			{
				for (int i = 0; i < FullR.ColumnCount; i++)
				{
					if (Math.Abs(FullR.At(i, i)).AlmostEqual(0.0))
					{
						return false;
					}
				}
				return true;
			}
		}

		protected QR(Matrix<double> q, Matrix<double> rFull, QRMethod method)
			: base(q, rFull, method)
		{
		}
	}
}
