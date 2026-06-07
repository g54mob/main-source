using System;

namespace ReedSolomon
{
	internal sealed class GenericGF
	{
		public static GenericGF QR_CODE_FIELD_256 = new GenericGF(285, 256, 0);

		public static GenericGF DATA_MATRIX_FIELD_256 = new GenericGF(301, 256, 1);

		private const int INITIALIZATION_THRESHOLD = 0;

		private int[] expTable;

		private int[] logTable;

		private GenericGFPoly zero;

		private GenericGFPoly one;

		private readonly int size;

		private readonly int primitive;

		private readonly int generatorBase;

		private bool initialized;

		internal GenericGFPoly Zero
		{
			get
			{
				CheckInit();
				return zero;
			}
		}

		internal GenericGFPoly One
		{
			get
			{
				CheckInit();
				return one;
			}
		}

		public int Size
		{
			get
			{
				return size;
			}
		}

		public int GeneratorBase
		{
			get
			{
				return generatorBase;
			}
		}

		public GenericGF(int primitive, int size, int genBase)
		{
			this.primitive = primitive;
			this.size = size;
			generatorBase = genBase;
			if (size <= 0)
			{
				Initialize();
			}
		}

		private void Initialize()
		{
			expTable = new int[size];
			logTable = new int[size];
			int num = 1;
			for (int i = 0; i < size; i++)
			{
				expTable[i] = num;
				num <<= 1;
				if (num >= size)
				{
					num ^= primitive;
					num &= size - 1;
				}
			}
			for (int j = 0; j < size - 1; j++)
			{
				logTable[expTable[j]] = j;
			}
			zero = new GenericGFPoly(this, new int[1]);
			one = new GenericGFPoly(this, new int[1] { 1 });
			initialized = true;
		}

		private void CheckInit()
		{
			if (!initialized)
			{
				Initialize();
			}
		}

		internal GenericGFPoly BuildMonomial(int degree, int coefficient)
		{
			CheckInit();
			if (degree < 0)
			{
				throw new ArgumentException();
			}
			if (coefficient == 0)
			{
				return zero;
			}
			int[] array = new int[degree + 1];
			array[0] = coefficient;
			return new GenericGFPoly(this, array);
		}

		internal static int AddOrSubtract(int a, int b)
		{
			return a ^ b;
		}

		internal int Exp(int a)
		{
			CheckInit();
			return expTable[a];
		}

		internal int Log(int a)
		{
			CheckInit();
			if (a == 0)
			{
				throw new ArgumentException();
			}
			return logTable[a];
		}

		internal int Inverse(int a)
		{
			CheckInit();
			if (a == 0)
			{
				throw new ArithmeticException();
			}
			return expTable[size - logTable[a] - 1];
		}

		internal int Multiply(int a, int b)
		{
			CheckInit();
			if (a == 0 || b == 0)
			{
				return 0;
			}
			return expTable[(logTable[a] + logTable[b]) % (size - 1)];
		}

		public override string ToString()
		{
			return string.Format("GF(0x{0},{1})", primitive.ToString("X"), size);
		}
	}
}
