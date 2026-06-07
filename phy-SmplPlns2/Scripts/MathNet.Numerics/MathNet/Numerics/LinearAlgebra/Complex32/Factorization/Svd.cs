using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace MathNet.Numerics.LinearAlgebra.Complex32.Factorization
{
	internal abstract class Svd : Svd<MathNet.Numerics.Complex32>
	{
		public override int Rank
		{
			get
			{
				double tolerance = base.S.AbsoluteMaximum().Magnitude.EpsilonOf() * (float)Math.Max(base.U.RowCount, base.VT.RowCount);
				return base.S.Count((MathNet.Numerics.Complex32 t) => (double)t.Magnitude > tolerance);
			}
		}

		public override double L2Norm => base.S[0].Magnitude;

		public override MathNet.Numerics.Complex32 ConditionNumber
		{
			get
			{
				int index = Math.Min(base.U.RowCount, base.VT.ColumnCount) - 1;
				return base.S[0].Magnitude / base.S[index].Magnitude;
			}
		}

		public override MathNet.Numerics.Complex32 Determinant
		{
			get
			{
				if (base.U.RowCount != base.VT.ColumnCount)
				{
					throw new ArgumentException("Matrix must be square.");
				}
				MathNet.Numerics.Complex32 one = MathNet.Numerics.Complex32.One;
				foreach (MathNet.Numerics.Complex32 item in (IEnumerable<MathNet.Numerics.Complex32>)base.S)
				{
					one *= item;
					if (item.Magnitude.AlmostEqual(0f))
					{
						return 0;
					}
				}
				return one.Magnitude;
			}
		}

		protected Svd(Vector<MathNet.Numerics.Complex32> s, Matrix<MathNet.Numerics.Complex32> u, Matrix<MathNet.Numerics.Complex32> vt, bool vectorsComputed)
			: base(s, u, vt, vectorsComputed)
		{
		}
	}
}
