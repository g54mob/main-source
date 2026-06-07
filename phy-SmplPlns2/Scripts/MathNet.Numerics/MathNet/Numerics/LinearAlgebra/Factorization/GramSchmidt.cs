using System;

namespace MathNet.Numerics.LinearAlgebra.Factorization
{
	public abstract class GramSchmidt<T> : QR<T> where T : struct, IEquatable<T>, IFormattable
	{
		protected GramSchmidt(Matrix<T> q, Matrix<T> rFull)
			: base(q, rFull, QRMethod.Full)
		{
		}
	}
}
