using System.Runtime.CompilerServices;

namespace CommunityToolkit.HighPerformance.Helpers.Internals
{
	internal static class RefEnumerableHelper
	{
		public static void Clear<T>(ref T r0, nint length, nint step)
		{
			nint num = 0;
			while (length >= 8)
			{
				Unsafe.Add(ref r0, num) = default(T);
				Unsafe.Add(ref r0, num += step) = default(T);
				Unsafe.Add(ref r0, num += step) = default(T);
				Unsafe.Add(ref r0, num += step) = default(T);
				Unsafe.Add(ref r0, num += step) = default(T);
				Unsafe.Add(ref r0, num += step) = default(T);
				Unsafe.Add(ref r0, num += step) = default(T);
				Unsafe.Add(ref r0, num += step) = default(T);
				length -= 8;
				num += step;
			}
			if (length >= 4)
			{
				Unsafe.Add(ref r0, num) = default(T);
				Unsafe.Add(ref r0, num += step) = default(T);
				Unsafe.Add(ref r0, num += step) = default(T);
				Unsafe.Add(ref r0, num += step) = default(T);
				length -= 4;
				num += step;
			}
			while (length > 0)
			{
				Unsafe.Add(ref r0, num) = default(T);
				length--;
				num += step;
			}
		}

		public static void CopyTo<T>(ref T sourceRef, ref T destinationRef, nint length, nint sourceStep)
		{
			nint num = 0;
			nint num2 = 0;
			while (length >= 8)
			{
				Unsafe.Add(ref destinationRef, num2 + 0) = Unsafe.Add(ref sourceRef, num);
				Unsafe.Add(ref destinationRef, num2 + 1) = Unsafe.Add(ref sourceRef, num += sourceStep);
				Unsafe.Add(ref destinationRef, num2 + 2) = Unsafe.Add(ref sourceRef, num += sourceStep);
				Unsafe.Add(ref destinationRef, num2 + 3) = Unsafe.Add(ref sourceRef, num += sourceStep);
				Unsafe.Add(ref destinationRef, num2 + 4) = Unsafe.Add(ref sourceRef, num += sourceStep);
				Unsafe.Add(ref destinationRef, num2 + 5) = Unsafe.Add(ref sourceRef, num += sourceStep);
				Unsafe.Add(ref destinationRef, num2 + 6) = Unsafe.Add(ref sourceRef, num += sourceStep);
				Unsafe.Add(ref destinationRef, num2 + 7) = Unsafe.Add(ref sourceRef, num += sourceStep);
				length -= 8;
				num += sourceStep;
				num2 += 8;
			}
			if (length >= 4)
			{
				Unsafe.Add(ref destinationRef, num2 + 0) = Unsafe.Add(ref sourceRef, num);
				Unsafe.Add(ref destinationRef, num2 + 1) = Unsafe.Add(ref sourceRef, num += sourceStep);
				Unsafe.Add(ref destinationRef, num2 + 2) = Unsafe.Add(ref sourceRef, num += sourceStep);
				Unsafe.Add(ref destinationRef, num2 + 3) = Unsafe.Add(ref sourceRef, num += sourceStep);
				length -= 4;
				num += sourceStep;
				num2 += 4;
			}
			while (length > 0)
			{
				Unsafe.Add(ref destinationRef, num2) = Unsafe.Add(ref sourceRef, num);
				length--;
				num += sourceStep;
				num2++;
			}
		}

		public static void CopyTo<T>(ref T sourceRef, ref T destinationRef, nint length, nint sourceStep, nint destinationStep)
		{
			nint num = 0;
			nint num2 = 0;
			while (length >= 8)
			{
				Unsafe.Add(ref destinationRef, num2) = Unsafe.Add(ref sourceRef, num);
				Unsafe.Add(ref destinationRef, num2 += destinationStep) = Unsafe.Add(ref sourceRef, num += sourceStep);
				Unsafe.Add(ref destinationRef, num2 += destinationStep) = Unsafe.Add(ref sourceRef, num += sourceStep);
				Unsafe.Add(ref destinationRef, num2 += destinationStep) = Unsafe.Add(ref sourceRef, num += sourceStep);
				Unsafe.Add(ref destinationRef, num2 += destinationStep) = Unsafe.Add(ref sourceRef, num += sourceStep);
				Unsafe.Add(ref destinationRef, num2 += destinationStep) = Unsafe.Add(ref sourceRef, num += sourceStep);
				Unsafe.Add(ref destinationRef, num2 += destinationStep) = Unsafe.Add(ref sourceRef, num += sourceStep);
				Unsafe.Add(ref destinationRef, num2 += destinationStep) = Unsafe.Add(ref sourceRef, num += sourceStep);
				length -= 8;
				num += sourceStep;
				num2 += destinationStep;
			}
			if (length >= 4)
			{
				Unsafe.Add(ref destinationRef, num2) = Unsafe.Add(ref sourceRef, num);
				Unsafe.Add(ref destinationRef, num2 += destinationStep) = Unsafe.Add(ref sourceRef, num += sourceStep);
				Unsafe.Add(ref destinationRef, num2 += destinationStep) = Unsafe.Add(ref sourceRef, num += sourceStep);
				Unsafe.Add(ref destinationRef, num2 += destinationStep) = Unsafe.Add(ref sourceRef, num += sourceStep);
				length -= 4;
				num += sourceStep;
				num2 += destinationStep;
			}
			while (length > 0)
			{
				Unsafe.Add(ref destinationRef, num2) = Unsafe.Add(ref sourceRef, num);
				length--;
				num += sourceStep;
				num2 += destinationStep;
			}
		}

		public static void CopyFrom<T>(ref T sourceRef, ref T destinationRef, nint length, nint sourceStep)
		{
			nint num = 0;
			nint num2 = 0;
			while (length >= 8)
			{
				Unsafe.Add(ref destinationRef, num2) = Unsafe.Add(ref sourceRef, num);
				Unsafe.Add(ref destinationRef, num2 += sourceStep) = Unsafe.Add(ref sourceRef, num + 1);
				Unsafe.Add(ref destinationRef, num2 += sourceStep) = Unsafe.Add(ref sourceRef, num + 2);
				Unsafe.Add(ref destinationRef, num2 += sourceStep) = Unsafe.Add(ref sourceRef, num + 3);
				Unsafe.Add(ref destinationRef, num2 += sourceStep) = Unsafe.Add(ref sourceRef, num + 4);
				Unsafe.Add(ref destinationRef, num2 += sourceStep) = Unsafe.Add(ref sourceRef, num + 5);
				Unsafe.Add(ref destinationRef, num2 += sourceStep) = Unsafe.Add(ref sourceRef, num + 6);
				Unsafe.Add(ref destinationRef, num2 += sourceStep) = Unsafe.Add(ref sourceRef, num + 7);
				length -= 8;
				num += 8;
				num2 += sourceStep;
			}
			if (length >= 4)
			{
				Unsafe.Add(ref destinationRef, num2) = Unsafe.Add(ref sourceRef, num);
				Unsafe.Add(ref destinationRef, num2 += sourceStep) = Unsafe.Add(ref sourceRef, num + 1);
				Unsafe.Add(ref destinationRef, num2 += sourceStep) = Unsafe.Add(ref sourceRef, num + 2);
				Unsafe.Add(ref destinationRef, num2 += sourceStep) = Unsafe.Add(ref sourceRef, num + 3);
				length -= 4;
				num += 4;
				num2 += sourceStep;
			}
			while (length > 0)
			{
				Unsafe.Add(ref destinationRef, num2) = Unsafe.Add(ref sourceRef, num);
				length--;
				num++;
				num2 += sourceStep;
			}
		}

		public static void Fill<T>(ref T r0, nint length, nint step, T value)
		{
			nint num = 0;
			while (length >= 8)
			{
				Unsafe.Add(ref r0, num) = value;
				Unsafe.Add(ref r0, num += step) = value;
				Unsafe.Add(ref r0, num += step) = value;
				Unsafe.Add(ref r0, num += step) = value;
				Unsafe.Add(ref r0, num += step) = value;
				Unsafe.Add(ref r0, num += step) = value;
				Unsafe.Add(ref r0, num += step) = value;
				Unsafe.Add(ref r0, num += step) = value;
				length -= 8;
				num += step;
			}
			if (length >= 4)
			{
				Unsafe.Add(ref r0, num) = value;
				Unsafe.Add(ref r0, num += step) = value;
				Unsafe.Add(ref r0, num += step) = value;
				Unsafe.Add(ref r0, num += step) = value;
				length -= 4;
				num += step;
			}
			while (length > 0)
			{
				Unsafe.Add(ref r0, num) = value;
				length--;
				num += step;
			}
		}
	}
}
