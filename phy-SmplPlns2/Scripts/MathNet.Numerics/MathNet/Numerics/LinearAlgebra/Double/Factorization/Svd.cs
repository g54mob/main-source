using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace MathNet.Numerics.LinearAlgebra.Double.Factorization
{
	internal abstract class Svd : Svd<double>
	{
		public override int Rank
		{
			get
			{
				double tolerance = base.S.Maximum().EpsilonOf() * (double)Math.Max(base.U.RowCount, base.VT.RowCount);
				return base.S.Count((double t) => Math.Abs(t) > tolerance);
			}
		}

		public override double L2Norm => Math.Abs(base.S[0]);

		public override double ConditionNumber
		{
			get
			{
				int index = Math.Min(base.U.RowCount, base.VT.ColumnCount) - 1;
				return Math.Abs(base.S[0]) / Math.Abs(base.S[index]);
			}
		}

		public override double Determinant
		{
			get
			{
				if (base.U.RowCount != base.VT.ColumnCount)
				{
					throw new ArgumentException("Matrix must be square.");
				}
				double num = 1.0;
				foreach (double item in (IEnumerable<double>)base.S)
				{
					num *= item;
					if (Math.Abs(item).AlmostEqual(0.0))
					{
						return 0.0;
					}
				}
				return Math.Abs(num);
			}
		}

		protected Svd(Vector<double> s, Matrix<double> u, Matrix<double> vt, bool vectorsComputed)
			: base(s, u, vt, vectorsComputed)
		{
		}
	}
}
