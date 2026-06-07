using System;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace MathNet.Numerics.LinearAlgebra.Complex32.Factorization
{
	internal abstract class QR : QR<MathNet.Numerics.Complex32>
	{
		public override MathNet.Numerics.Complex32 Determinant
		{
			get
			{
				if (FullR.RowCount != FullR.ColumnCount)
				{
					throw new ArgumentException("Matrix must be square.");
				}
				MathNet.Numerics.Complex32 one = MathNet.Numerics.Complex32.One;
				for (int i = 0; i < FullR.ColumnCount; i++)
				{
					one *= FullR.At(i, i);
					if (FullR.At(i, i).Magnitude.AlmostEqual(0f))
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
					if (FullR.At(i, i).Magnitude.AlmostEqual(0f))
					{
						return false;
					}
				}
				return true;
			}
		}

		protected QR(Matrix<MathNet.Numerics.Complex32> q, Matrix<MathNet.Numerics.Complex32> rFull, QRMethod method)
			: base(q, rFull, method)
		{
		}
	}
}
