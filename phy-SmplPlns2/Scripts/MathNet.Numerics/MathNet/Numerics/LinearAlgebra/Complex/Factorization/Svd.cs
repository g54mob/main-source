using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace MathNet.Numerics.LinearAlgebra.Complex.Factorization
{
	internal abstract class Svd : Svd<System.Numerics.Complex>
	{
		public override int Rank
		{
			get
			{
				double tolerance = base.S.AbsoluteMaximum().Magnitude.EpsilonOf() * (double)Math.Max(base.U.RowCount, base.VT.RowCount);
				return base.S.Count((System.Numerics.Complex t) => t.Magnitude > tolerance);
			}
		}

		public override double L2Norm => base.S[0].Magnitude;

		public override System.Numerics.Complex ConditionNumber
		{
			get
			{
				int index = Math.Min(base.U.RowCount, base.VT.ColumnCount) - 1;
				return base.S[0].Magnitude / base.S[index].Magnitude;
			}
		}

		public override System.Numerics.Complex Determinant
		{
			get
			{
				if (base.U.RowCount != base.VT.ColumnCount)
				{
					throw new ArgumentException("Matrix must be square.");
				}
				System.Numerics.Complex one = System.Numerics.Complex.One;
				foreach (System.Numerics.Complex item in (IEnumerable<System.Numerics.Complex>)base.S)
				{
					one *= item;
					if (item.Magnitude.AlmostEqual(0.0))
					{
						return 0;
					}
				}
				return one.Magnitude;
			}
		}

		protected Svd(Vector<System.Numerics.Complex> s, Matrix<System.Numerics.Complex> u, Matrix<System.Numerics.Complex> vt, bool vectorsComputed)
			: base(s, u, vt, vectorsComputed)
		{
		}
	}
}
