using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace DV.Platform.Windows
{
	public static class DVWindow_Native
	{
		private const string UNITY_CLASS_NAME = "UnityWndClass";

		[DllImport("user32.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr FindWindow([MarshalAs(UnmanagedType.LPStr)] string lpClassName, [MarshalAs(UnmanagedType.LPStr)] string lpWindowName);

		[DllImport("user32.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern bool SetWindowText(IntPtr hWnd, [MarshalAs(UnmanagedType.LPStr)] string lpString);

		public static void SetWindowTitle(string title)
		{
			SetWindowText(FindWindow("UnityWndClass", Application.productName), title);
		}
	}
}
