using System;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace MathNet.Numerics.LinearAlgebra.Single.Factorization
{
	internal abstract class QR : QR<float>
	{
		public override float Determinant
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
					num *= (double)FullR.At(i, i);
					if (Math.Abs(FullR.At(i, i)).AlmostEqual(0f))
					{
						return 0f;
					}
				}
				return Convert.ToSingle(Math.Abs(num));
			}
		}

		public override bool IsFullRank
		{
			get
			{
				for (int i = 0; i < FullR.ColumnCount; i++)
				{
					if (Math.Abs(FullR.At(i, i)).AlmostEqual(0f))
					{
						return false;
					}
				}
				return true;
			}
		}

		protected QR(Matrix<float> q, Matrix<float> rFull, QRMethod method)
			: base(q, rFull, method)
		{
		}
	}
}
