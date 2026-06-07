using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace MathNet.Numerics.LinearAlgebra.Double.Factorization
{
	internal abstract class Evd : Evd<double>
	{
		public override double Determinant
		{
			get
			{
				System.Numerics.Complex one = System.Numerics.Complex.One;
				for (int i = 0; i < base.EigenValues.Count; i++)
				{
					one *= base.EigenValues[i];
					if (base.EigenValues[i].AlmostEqual(System.Numerics.Complex.Zero))
					{
						return 0.0;
					}
				}
				return one.Magnitude;
			}
		}

		public override int Rank
		{
			get
			{
				int num = 0;
				for (int i = 0; i < base.EigenValues.Count; i++)
				{
					if (!base.EigenValues[i].AlmostEqual(System.Numerics.Complex.Zero))
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

		protected Evd(Matrix<double> eigenVectors, Vector<System.Numerics.Complex> eigenValues, Matrix<double> blockDiagonal, bool isSymmetric)
			: base(eigenVectors, eigenValues, blockDiagonal, isSymmetric)
		{
		}
	}
}
