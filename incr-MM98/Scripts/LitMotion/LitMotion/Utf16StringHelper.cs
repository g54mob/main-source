using System.Runtime.CompilerServices;

namespace LitMotion
{
	internal static class Utf16StringHelper
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteInt32(ref char[] buffer, ref int bufferOffset, int value)
		{
			WriteInt64(ref buffer, ref bufferOffset, value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteInt64(ref char[] buffer, ref int bufferOffset, long value)
		{
			long num = value;
			if (value < 0)
			{
				if (value == long.MinValue)
				{
					ArrayHelper.EnsureBufferCapacity(ref buffer, bufferOffset + 20);
					buffer[bufferOffset++] = '-';
					buffer[bufferOffset++] = '9';
					buffer[bufferOffset++] = '2';
					buffer[bufferOffset++] = '2';
					buffer[bufferOffset++] = '3';
					buffer[bufferOffset++] = '3';
					buffer[bufferOffset++] = '7';
					buffer[bufferOffset++] = '2';
					buffer[bufferOffset++] = '0';
					buffer[bufferOffset++] = '3';
					buffer[bufferOffset++] = '6';
					buffer[bufferOffset++] = '8';
					buffer[bufferOffset++] = '5';
					buffer[bufferOffset++] = '4';
					buffer[bufferOffset++] = '7';
					buffer[bufferOffset++] = '7';
					buffer[bufferOffset++] = '5';
					buffer[bufferOffset++] = '8';
					buffer[bufferOffset++] = '0';
					buffer[bufferOffset++] = '8';
				}
				ArrayHelper.EnsureBufferCapacity(ref buffer, bufferOffset + 1);
				buffer[bufferOffset++] = '-';
				num = -value;
			}
			if (num < 10000)
			{
				if (num < 10)
				{
					ArrayHelper.EnsureBufferCapacity(ref buffer, bufferOffset + 1);
					goto IL_06a4;
				}
				if (num < 100)
				{
					ArrayHelper.EnsureBufferCapacity(ref buffer, bufferOffset + 2);
					goto IL_0679;
				}
				if (num < 1000)
				{
					ArrayHelper.EnsureBufferCapacity(ref buffer, bufferOffset + 3);
					goto IL_064e;
				}
				ArrayHelper.EnsureBufferCapacity(ref buffer, bufferOffset + 4);
				goto IL_0620;
			}
			long num2 = num / 10000;
			num -= num2 * 10000;
			if (num2 < 10000)
			{
				if (num2 < 10)
				{
					ArrayHelper.EnsureBufferCapacity(ref buffer, bufferOffset + 5);
					goto IL_060b;
				}
				if (num2 < 100)
				{
					ArrayHelper.EnsureBufferCapacity(ref buffer, bufferOffset + 6);
					goto IL_05e0;
				}
				if (num2 < 1000)
				{
					ArrayHelper.EnsureBufferCapacity(ref buffer, bufferOffset + 7);
					goto IL_05b5;
				}
				ArrayHelper.EnsureBufferCapacity(ref buffer, bufferOffset + 8);
				goto IL_0587;
			}
			long num3 = num2 / 10000;
			num2 -= num3 * 10000;
			if (num3 < 10000)
			{
				if (num3 < 10)
				{
					ArrayHelper.EnsureBufferCapacity(ref buffer, bufferOffset + 9);
					goto IL_0572;
				}
				if (num3 < 100)
				{
					ArrayHelper.EnsureBufferCapacity(ref buffer, bufferOffset + 10);
					goto IL_0547;
				}
				if (num3 < 1000)
				{
					ArrayHelper.EnsureBufferCapacity(ref buffer, bufferOffset + 11);
					goto IL_051c;
				}
				ArrayHelper.EnsureBufferCapacity(ref buffer, bufferOffset + 12);
				goto IL_04ee;
			}
			long num4 = num3 / 10000;
			num3 -= num4 * 10000;
			if (num4 < 10000)
			{
				if (num4 < 10)
				{
					ArrayHelper.EnsureBufferCapacity(ref buffer, bufferOffset + 13);
					goto IL_04d9;
				}
				if (num4 < 100)
				{
					ArrayHelper.EnsureBufferCapacity(ref buffer, bufferOffset + 14);
					goto IL_04ae;
				}
				if (num4 < 1000)
				{
					ArrayHelper.EnsureBufferCapacity(ref buffer, bufferOffset + 15);
					goto IL_0483;
				}
				ArrayHelper.EnsureBufferCapacity(ref buffer, bufferOffset + 16);
				goto IL_0455;
			}
			long num5 = num4 / 10000;
			num4 -= num5 * 10000;
			if (num5 < 10000)
			{
				if (num5 < 10)
				{
					ArrayHelper.EnsureBufferCapacity(ref buffer, bufferOffset + 17);
					goto IL_043f;
				}
				if (num5 < 100)
				{
					ArrayHelper.EnsureBufferCapacity(ref buffer, bufferOffset + 18);
					goto IL_0411;
				}
				if (num5 < 1000)
				{
					ArrayHelper.EnsureBufferCapacity(ref buffer, bufferOffset + 19);
					goto IL_03e3;
				}
				ArrayHelper.EnsureBufferCapacity(ref buffer, bufferOffset + 20);
			}
			long num6;
			buffer[bufferOffset++] = (char)(48 + (num6 = num5 * 8389 >> 23));
			num5 -= num6 * 1000;
			goto IL_03e3;
			IL_051c:
			buffer[bufferOffset++] = (char)(48 + (num6 = num3 * 5243 >> 19));
			num3 -= num6 * 100;
			goto IL_0547;
			IL_05e0:
			buffer[bufferOffset++] = (char)(48 + (num6 = num2 * 6554 >> 16));
			num2 -= num6 * 10;
			goto IL_060b;
			IL_0455:
			buffer[bufferOffset++] = (char)(48 + (num6 = num4 * 8389 >> 23));
			num4 -= num6 * 1000;
			goto IL_0483;
			IL_05b5:
			buffer[bufferOffset++] = (char)(48 + (num6 = num2 * 5243 >> 19));
			num2 -= num6 * 100;
			goto IL_05e0;
			IL_060b:
			buffer[bufferOffset++] = (char)(48 + num2);
			goto IL_0620;
			IL_0547:
			buffer[bufferOffset++] = (char)(48 + (num6 = num3 * 6554 >> 16));
			num3 -= num6 * 10;
			goto IL_0572;
			IL_0572:
			buffer[bufferOffset++] = (char)(48 + num3);
			goto IL_0587;
			IL_0587:
			buffer[bufferOffset++] = (char)(48 + (num6 = num2 * 8389 >> 23));
			num2 -= num6 * 1000;
			goto IL_05b5;
			IL_0620:
			buffer[bufferOffset++] = (char)(48 + (num6 = num * 8389 >> 23));
			num -= num6 * 1000;
			goto IL_064e;
			IL_064e:
			buffer[bufferOffset++] = (char)(48 + (num6 = num * 5243 >> 19));
			num -= num6 * 100;
			goto IL_0679;
			IL_0679:
			buffer[bufferOffset++] = (char)(48 + (num6 = num * 6554 >> 16));
			num -= num6 * 10;
			goto IL_06a4;
			IL_06a4:
			buffer[bufferOffset++] = (char)(48 + num);
			return;
			IL_04ee:
			buffer[bufferOffset++] = (char)(48 + (num6 = num3 * 8389 >> 23));
			num3 -= num6 * 1000;
			goto IL_051c;
			IL_0483:
			buffer[bufferOffset++] = (char)(48 + (num6 = num4 * 5243 >> 19));
			num4 -= num6 * 100;
			goto IL_04ae;
			IL_03e3:
			buffer[bufferOffset++] = (char)(48 + (num6 = num5 * 5243 >> 19));
			num5 -= num6 * 100;
			goto IL_0411;
			IL_04ae:
			buffer[bufferOffset++] = (char)(48 + (num6 = num4 * 6554 >> 16));
			num4 -= num6 * 10;
			goto IL_04d9;
			IL_0411:
			buffer[bufferOffset++] = (char)(48 + (num6 = num5 * 6554 >> 16));
			num5 -= num6 * 10;
			goto IL_043f;
			IL_04d9:
			buffer[bufferOffset++] = (char)(48 + num4);
			goto IL_04ee;
			IL_043f:
			buffer[bufferOffset++] = (char)(48 + num5);
			goto IL_0455;
		}
	}
}
