using System;
using System.Reflection;

namespace UniJSON
{
	public static class ConcreteCast
	{
		public static string GetMethodName(Type src, Type dst)
		{
			return $"Cast{src.Name}To{dst.Name}";
		}

		public static MethodInfo GetMethod(Type src, Type dst)
		{
			string methodName = GetMethodName(src, dst);
			return typeof(ConcreteCast).GetMethod(methodName, BindingFlags.Static | BindingFlags.Public);
		}

		public static byte CastByteToByte(byte src)
		{
			return src;
		}

		public static ushort CastByteToUInt16(byte src)
		{
			return src;
		}

		public static uint CastByteToUInt32(byte src)
		{
			return src;
		}

		public static ulong CastByteToUInt64(byte src)
		{
			return src;
		}

		public static sbyte CastByteToSByte(byte src)
		{
			return (sbyte)src;
		}

		public static short CastByteToInt16(byte src)
		{
			return src;
		}

		public static int CastByteToInt32(byte src)
		{
			return src;
		}

		public static long CastByteToInt64(byte src)
		{
			return src;
		}

		public static float CastByteToSingle(byte src)
		{
			return (int)src;
		}

		public static double CastByteToDouble(byte src)
		{
			return (int)src;
		}

		public static byte CastUInt16ToByte(ushort src)
		{
			return (byte)src;
		}

		public static ushort CastUInt16ToUInt16(ushort src)
		{
			return src;
		}

		public static uint CastUInt16ToUInt32(ushort src)
		{
			return src;
		}

		public static ulong CastUInt16ToUInt64(ushort src)
		{
			return src;
		}

		public static sbyte CastUInt16ToSByte(ushort src)
		{
			return (sbyte)src;
		}

		public static short CastUInt16ToInt16(ushort src)
		{
			return (short)src;
		}

		public static int CastUInt16ToInt32(ushort src)
		{
			return src;
		}

		public static long CastUInt16ToInt64(ushort src)
		{
			return src;
		}

		public static float CastUInt16ToSingle(ushort src)
		{
			return (int)src;
		}

		public static double CastUInt16ToDouble(ushort src)
		{
			return (int)src;
		}

		public static byte CastUInt32ToByte(uint src)
		{
			return (byte)src;
		}

		public static ushort CastUInt32ToUInt16(uint src)
		{
			return (ushort)src;
		}

		public static uint CastUInt32ToUInt32(uint src)
		{
			return src;
		}

		public static ulong CastUInt32ToUInt64(uint src)
		{
			return src;
		}

		public static sbyte CastUInt32ToSByte(uint src)
		{
			return (sbyte)src;
		}

		public static short CastUInt32ToInt16(uint src)
		{
			return (short)src;
		}

		public static int CastUInt32ToInt32(uint src)
		{
			return (int)src;
		}

		public static long CastUInt32ToInt64(uint src)
		{
			return src;
		}

		public static float CastUInt32ToSingle(uint src)
		{
			return src;
		}

		public static double CastUInt32ToDouble(uint src)
		{
			return src;
		}

		public static byte CastUInt64ToByte(ulong src)
		{
			return (byte)src;
		}

		public static ushort CastUInt64ToUInt16(ulong src)
		{
			return (ushort)src;
		}

		public static uint CastUInt64ToUInt32(ulong src)
		{
			return (uint)src;
		}

		public static ulong CastUInt64ToUInt64(ulong src)
		{
			return src;
		}

		public static sbyte CastUInt64ToSByte(ulong src)
		{
			return (sbyte)src;
		}

		public static short CastUInt64ToInt16(ulong src)
		{
			return (short)src;
		}

		public static int CastUInt64ToInt32(ulong src)
		{
			return (int)src;
		}

		public static long CastUInt64ToInt64(ulong src)
		{
			return (long)src;
		}

		public static float CastUInt64ToSingle(ulong src)
		{
			return src;
		}

		public static double CastUInt64ToDouble(ulong src)
		{
			return src;
		}

		public static byte CastSByteToByte(sbyte src)
		{
			return (byte)src;
		}

		public static ushort CastSByteToUInt16(sbyte src)
		{
			return (ushort)src;
		}

		public static uint CastSByteToUInt32(sbyte src)
		{
			return (uint)src;
		}

		public static ulong CastSByteToUInt64(sbyte src)
		{
			return (ulong)src;
		}

		public static sbyte CastSByteToSByte(sbyte src)
		{
			return src;
		}

		public static short CastSByteToInt16(sbyte src)
		{
			return src;
		}

		public static int CastSByteToInt32(sbyte src)
		{
			return src;
		}

		public static long CastSByteToInt64(sbyte src)
		{
			return src;
		}

		public static float CastSByteToSingle(sbyte src)
		{
			return src;
		}

		public static double CastSByteToDouble(sbyte src)
		{
			return src;
		}

		public static byte CastInt16ToByte(short src)
		{
			return (byte)src;
		}

		public static ushort CastInt16ToUInt16(short src)
		{
			return (ushort)src;
		}

		public static uint CastInt16ToUInt32(short src)
		{
			return (uint)src;
		}

		public static ulong CastInt16ToUInt64(short src)
		{
			return (ulong)src;
		}

		public static sbyte CastInt16ToSByte(short src)
		{
			return (sbyte)src;
		}

		public static short CastInt16ToInt16(short src)
		{
			return src;
		}

		public static int CastInt16ToInt32(short src)
		{
			return src;
		}

		public static long CastInt16ToInt64(short src)
		{
			return src;
		}

		public static float CastInt16ToSingle(short src)
		{
			return src;
		}

		public static double CastInt16ToDouble(short src)
		{
			return src;
		}

		public static byte CastInt32ToByte(int src)
		{
			return (byte)src;
		}

		public static ushort CastInt32ToUInt16(int src)
		{
			return (ushort)src;
		}

		public static uint CastInt32ToUInt32(int src)
		{
			return (uint)src;
		}

		public static ulong CastInt32ToUInt64(int src)
		{
			return (ulong)src;
		}

		public static sbyte CastInt32ToSByte(int src)
		{
			return (sbyte)src;
		}

		public static short CastInt32ToInt16(int src)
		{
			return (short)src;
		}

		public static int CastInt32ToInt32(int src)
		{
			return src;
		}

		public static long CastInt32ToInt64(int src)
		{
			return src;
		}

		public static float CastInt32ToSingle(int src)
		{
			return src;
		}

		public static double CastInt32ToDouble(int src)
		{
			return src;
		}

		public static byte CastInt64ToByte(long src)
		{
			return (byte)src;
		}

		public static ushort CastInt64ToUInt16(long src)
		{
			return (ushort)src;
		}

		public static uint CastInt64ToUInt32(long src)
		{
			return (uint)src;
		}

		public static ulong CastInt64ToUInt64(long src)
		{
			return (ulong)src;
		}

		public static sbyte CastInt64ToSByte(long src)
		{
			return (sbyte)src;
		}

		public static short CastInt64ToInt16(long src)
		{
			return (short)src;
		}

		public static int CastInt64ToInt32(long src)
		{
			return (int)src;
		}

		public static long CastInt64ToInt64(long src)
		{
			return src;
		}

		public static float CastInt64ToSingle(long src)
		{
			return src;
		}

		public static double CastInt64ToDouble(long src)
		{
			return src;
		}

		public static byte CastSingleToByte(float src)
		{
			return (byte)src;
		}

		public static ushort CastSingleToUInt16(float src)
		{
			return (ushort)src;
		}

		public static uint CastSingleToUInt32(float src)
		{
			return (uint)src;
		}

		public static ulong CastSingleToUInt64(float src)
		{
			return (ulong)src;
		}

		public static sbyte CastSingleToSByte(float src)
		{
			return (sbyte)src;
		}

		public static short CastSingleToInt16(float src)
		{
			return (short)src;
		}

		public static int CastSingleToInt32(float src)
		{
			return (int)src;
		}

		public static long CastSingleToInt64(float src)
		{
			return (long)src;
		}

		public static float CastSingleToSingle(float src)
		{
			return src;
		}

		public static double CastSingleToDouble(float src)
		{
			return src;
		}

		public static byte CastDoubleToByte(double src)
		{
			return (byte)src;
		}

		public static ushort CastDoubleToUInt16(double src)
		{
			return (ushort)src;
		}

		public static uint CastDoubleToUInt32(double src)
		{
			return (uint)src;
		}

		public static ulong CastDoubleToUInt64(double src)
		{
			return (ulong)src;
		}

		public static sbyte CastDoubleToSByte(double src)
		{
			return (sbyte)src;
		}

		public static short CastDoubleToInt16(double src)
		{
			return (short)src;
		}

		public static int CastDoubleToInt32(double src)
		{
			return (int)src;
		}

		public static long CastDoubleToInt64(double src)
		{
			return (long)src;
		}

		public static float CastDoubleToSingle(double src)
		{
			return (float)src;
		}

		public static double CastDoubleToDouble(double src)
		{
			return src;
		}
	}
}
