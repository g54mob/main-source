using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Noesis;
using NoesisApp;
using UnityEngine;

public class NoesisUnity
{
	private delegate void UnityLogCallback(int level, string message);

	public class IME
	{
		public static TextBox focused;

		public static string compositionString;

		public static void Open(UIElement focused_)
		{
		}

		public static void Close()
		{
		}

		public static void Update(View view)
		{
		}

		private static void UpdateCursor()
		{
		}
	}

	public class TouchKeyboard
	{
		public static UIElement focused;

		public static string undoString;

		public static TouchScreenKeyboard keyboard;

		public static void Open(UIElement focused_)
		{
		}

		public static void Update()
		{
		}

		public static void Close()
		{
		}
	}

	private static bool _initialized;

	private static NoesisSettings _settings;

	private static UnityLogCallback _unityLog;

	private static bool _muted;

	public static bool Initialized => false;

	public static void InitCore()
	{
	}

	public static void Init()
	{
	}

	private static void SetLogLevel()
	{
	}

	private static void SetLicense()
	{
	}

	private static void SetApplicationResources()
	{
	}

	private static void SetDefaultFont()
	{
	}

	private static void SetDefaultFontParams()
	{
	}

	public static void LoadComponent(object component, [CallerFilePath] string filename = "")
	{
	}

	public static bool HasFamily(Stream stream, string family)
	{
		return false;
	}

	private static void RegisterProviders()
	{
	}

	private static void RegisterLog()
	{
	}

	public static void MuteLog()
	{
	}

	public static void UnmuteLog()
	{
	}

	[MonoPInvokeCallback(typeof(UnityLogCallback))]
	private static void UnityLog(int level, string message)
	{
	}

	private static void RegisterError()
	{
	}

	private static void OnUnhandledException(Exception e)
	{
	}

	private static void SoftwareKeyboard(UIElement focused, bool open)
	{
	}

	private static void UpdateCursor(View view, Noesis.Cursor cursor)
	{
	}

	private static void OpenUrl(string url)
	{
	}

	private static void PlayAudio(Uri uri, float volume)
	{
	}

	private static MediaPlayer CreateMediaPlayer(MediaElement mediaElement, Uri uri, object user)
	{
		return null;
	}

	[PreserveSig]
	private static extern void Noesis_SetLogLevel(int generalLogLevel, int bindingLogLevel);

	[PreserveSig]
	private static extern void Noesis_RegisterUnityLogCallback(UnityLogCallback logCallback);

	[PreserveSig]
	private static extern bool Noesis_HasFamily(IntPtr stream, string family);
}
