using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace MathNet.Numerics.LinearAlgebra.Single.Factorization
{
	internal abstract class Svd : Svd<float>
	{
		public override int Rank
		{
			get
			{
				double tolerance = base.S.Maximum().EpsilonOf() * (float)Math.Max(base.U.RowCount, base.VT.RowCount);
				return base.S.Count((float t) => (double)Math.Abs(t) > tolerance);
			}
		}

		public override double L2Norm => Math.Abs(base.S[0]);

		public override float ConditionNumber
		{
			get
			{
				int index = Math.Min(base.U.RowCount, base.VT.ColumnCount) - 1;
				return Math.Abs(base.S[0]) / Math.Abs(base.S[index]);
			}
		}

		public override float Determinant
		{
			get
			{
				if (base.U.RowCount != base.VT.ColumnCount)
				{
					throw new ArgumentException("Matrix must be square.");
				}
				double num = 1.0;
				foreach (float item in (IEnumerable<float>)base.S)
				{
					num *= (double)item;
					if (Math.Abs(item).AlmostEqual(0f))
					{
						return 0f;
					}
				}
				return Convert.ToSingle(Math.Abs(num));
			}
		}

		protected Svd(Vector<float> s, Matrix<float> u, Matrix<float> vt, bool vectorsComputed)
			: base(s, u, vt, vectorsComputed)
		{
		}
	}
}
