using System;
using System.Diagnostics;
using DV.Platform.Windows;
using UnityEngine;

namespace DV.Platform
{
	public static class DVWindow
	{
		[Conditional("UNITY_STANDALONE")]
		public static void SetWindowTitle(string title)
		{
			try
			{
				DVWindow_Native.SetWindowTitle(title);
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogError("Failed to set window title:");
				UnityEngine.Debug.LogException(exception);
			}
		}
	}
}
