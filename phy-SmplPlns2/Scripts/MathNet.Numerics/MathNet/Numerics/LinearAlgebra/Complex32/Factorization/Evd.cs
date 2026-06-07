using System;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace MathNet.Numerics.LinearAlgebra.Complex32.Factorization
{
	internal abstract class Evd : Evd<MathNet.Numerics.Complex32>
	{
		public override MathNet.Numerics.Complex32 Determinant
		{
			get
			{
				System.Numerics.Complex one = System.Numerics.Complex.One;
				for (int i = 0; i < base.EigenValues.Count; i++)
				{
					one *= base.EigenValues[i];
					if (((MathNet.Numerics.Complex32)base.EigenValues[i]).AlmostEqual(MathNet.Numerics.Complex32.Zero))
					{
						return 0;
					}
				}
				return new MathNet.Numerics.Complex32(Convert.ToSingle(one.Magnitude), 0f);
			}
		}

		public override int Rank
		{
			get
			{
				int num = 0;
				for (int i = 0; i < base.EigenValues.Count; i++)
				{
					if (!((MathNet.Numerics.Complex32)base.EigenValues[i]).AlmostEqual(MathNet.Numerics.Complex32.Zero))
					{
						num++;
					}
				}
				return num;
			}
		}

		public override bool IsFullRank
		{
			get
			{
				for (int i = 0; i < base.EigenValues.Count; i++)
				{
					if (base.EigenValues[i].AlmostEqual(System.Numerics.Complex.Zero))
					{
						return false;
					}
				}
				return true;
			}
		}

		protected Evd(Matrix<MathNet.Numerics.Complex32> eigenVectors, Vector<System.Numerics.Complex> eigenValues, Matrix<MathNet.Numerics.Complex32> blockDiagonal, bool isSymmetric)
			: base(eigenVectors, eigenValues, blockDiagonal, isSymmetric)
		{
		}
	}
}
