using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityMeshSimplifier
{
	[StructLayout((LayoutKind)0)]
	public class SymmetricMatrix
	{
		public double m0;

		public double m1;

		public double m2;

		public double m3;

		public double m4;

		public double m5;

		public double m6;

		public double m7;

		public double m8;

		public double m9;

		public double this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return 0.0;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public SymmetricMatrix(double c)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public SymmetricMatrix(double m0, double m1, double m2, double m3, double m4, double m5, double m6, double m7, double m8, double m9)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public SymmetricMatrix(double a, double b, double c, double d)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public SymmetricMatrix(Vector3d n, Vector3d p)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SymmetricMatrix operator +(SymmetricMatrix a, SymmetricMatrix b)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal double Determinant1()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal double Determinant2()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal double Determinant3()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal double Determinant4()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal bool ShapeIsGood()
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double Determinant(int a11, int a12, int a13, int a21, int a22, int a23, int a31, int a32, int a33)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Add(ref Vector3d n, ref Vector3d p, double scale = 1.0)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Add(SymmetricMatrix b)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Subtract(ref Vector3d n, ref Vector3d p)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Subtract(SymmetricMatrix b)
		{
		}

		public void Multiply(double a)
		{
		}

		public void Clear()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
