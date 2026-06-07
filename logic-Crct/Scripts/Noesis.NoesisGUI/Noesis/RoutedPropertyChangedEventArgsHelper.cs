using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	internal static class RoutedPropertyChangedEventArgsHelper
	{
		public static T GetOldValue<T>(HandleRef cPtr)
		{
			return default(T);
		}

		public static T GetNewValue<T>(HandleRef cPtr)
		{
			return default(T);
		}

		[PreserveSig]
		private static extern IntPtr Noesis_RoutedPropertyChangedEventArgs_GetOldValue(HandleRef cPtr, int type);

		[PreserveSig]
		private static extern IntPtr Noesis_RoutedPropertyChangedEventArgs_GetNewValue(HandleRef cPtr, int type);
	}
}
