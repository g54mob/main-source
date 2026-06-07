using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Utilities
{
	public struct complex
	{
		public float imag;

		public float real;

		public readonly float arg => math.atan2(imag, real);

		public readonly complex conj => new complex(real, 0f - imag);

		public readonly float mag => math.length((float2)this);

		public readonly float magSq => math.lengthsq((float2)this);

		public complex(float real, float imag)
		{
			this.real = real;
			this.imag = imag;
		}

		public static explicit operator complex(float2 vec)
		{
			return new complex(vec.x, vec.y);
		}

		public static explicit operator float2(complex com)
		{
			return new float2(com.real, com.imag);
		}

		public static implicit operator complex(float real)
		{
			return new complex(real, 0f);
		}

		public static complex operator -(complex a, complex b)
		{
			return new complex(a.real - b.real, a.imag - b.imag);
		}

		public static complex operator -(complex a)
		{
			return new complex(0f - a.real, 0f - a.imag);
		}

		public static complex operator *(complex a, complex b)
		{
			return new complex(a.real * b.real - a.imag * b.imag, a.imag * b.real + a.real * b.imag);
		}

		public static complex operator *(complex a, float b)
		{
			return new complex(a.real * b, a.imag * b);
		}

		public static complex operator *(float a, complex b)
		{
			return new complex(b.real * a, b.imag * a);
		}

		public static complex operator /(complex a, complex b)
		{
			float num = 1f / (b.real * b.real + b.imag * b.imag);
			return a * b.conj * num;
		}

		public static complex operator /(complex a, float b)
		{
			return a * (1f / b);
		}

		public static complex operator +(complex a, complex b)
		{
			return new complex(a.real + b.real, a.imag + b.imag);
		}

		public static complex FromArgMag(float arg, float mag)
		{
			complex complex2 = default(complex);
			math.sincos(arg, out complex2.imag, out complex2.real);
			return complex2 * mag;
		}

		public override readonly string ToString()
		{
			return $"{real} + {imag}i";
		}
	}
}
