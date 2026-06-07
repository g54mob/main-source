using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Noesis
{
	public static class GUI
	{
		private delegate void NoesisSoftwareKeyboardCallback(IntPtr cPtrFocused, bool open);

		private delegate void NoesisUpdateCursorCallback(IntPtr cPtrView, IntPtr cursorPtr);

		private delegate void NoesisOpenUrlCallback(IntPtr url);

		private delegate void NoesisPlayAudioCallback(IntPtr sound, float volume);

		private struct Deps
		{
			public XamlDependencyCallback Callback { get; set; }
		}

		private delegate void NoesisXamlDependencyCallback(int callbackId, IntPtr uri, int type);

		private struct Faces
		{
			public FontFaceInfoCallback Callback { get; set; }
		}

		private delegate void NoesisFontFaceInfoCallback(int callbackId, int index, IntPtr familyName, int weight, int style, int stretch);

		private delegate void NoesisLoadAssemblyCallback(IntPtr assembly);

		private static bool _initialized;

		private static SoftwareKeyboardCallback _softwareKeyboardCallback;

		private static NoesisSoftwareKeyboardCallback _softwareKeyboard;

		private static UpdateCursorCallback _updateCursorCallback;

		private static NoesisUpdateCursorCallback _updateCursor;

		private static OpenUrlCallback _openUrlCallback;

		private static NoesisOpenUrlCallback _openUrl;

		private static PlayAudioCallback _playAudioCallback;

		private static NoesisPlayAudioCallback _playAudio;

		private static NoesisXamlDependencyCallback _xamlDep;

		private static Dictionary<int, Deps> _depsCallbacks;

		private static NoesisFontFaceInfoCallback _fontFaces;

		private static Dictionary<int, Faces> _facesCallbacks;

		private static LoadAssemblyCallback _loadAssemblyCallback;

		private static NoesisLoadAssemblyCallback _loadAssembly;

		public static bool IsInspectorConnected => false;

		public static string GetBuildVersion()
		{
			return null;
		}

		public static void DisableInspector()
		{
		}

		public static void UpdateInspector()
		{
		}

		public static void SetLicense(string name, string key)
		{
		}

		public static void Init()
		{
		}

		public static void Shutdown()
		{
		}

		public static void SetXamlProvider(XamlProvider provider)
		{
		}

		public static void SetTextureProvider(TextureProvider provider)
		{
		}

		public static void SetFontProvider(FontProvider provider)
		{
		}

		public static void SetFontFallbacks(string[] familyNames)
		{
		}

		public static void SetFontDefaultProperties(float size, FontWeight weight, FontStretch stretch, FontStyle style)
		{
		}

		public static void LoadApplicationResources(string filename)
		{
		}

		public static void SetApplicationResources(ResourceDictionary resources)
		{
		}

		public static ResourceDictionary GetApplicationResources()
		{
			return null;
		}

		public static void SetSoftwareKeyboardCallback(SoftwareKeyboardCallback callback)
		{
		}

		public static void SetCursorCallback(UpdateCursorCallback callback)
		{
		}

		public static void SetOpenUrlCallback(OpenUrlCallback callback)
		{
		}

		public static void OpenUrl(string url)
		{
		}

		public static void SetPlayAudioCallback(PlayAudioCallback callback)
		{
		}

		public static void PlayAudio(Uri uri, float volume)
		{
		}

		public static void GetXamlDependencies(Stream xaml, string baseUri, XamlDependencyCallback callback)
		{
		}

		public static object LoadXaml(Stream stream, string filename)
		{
			return null;
		}

		public static object LoadXaml(string filename)
		{
			return null;
		}

		public static object ParseXaml(string xamlText)
		{
			return null;
		}

		public static Stream LoadXamlResource(string filename)
		{
			return null;
		}

		public static void EnumFontFaces(Stream font, FontFaceInfoCallback callback)
		{
		}

		public static void LoadComponent(object component, string filename)
		{
		}

		public static void SetLoadAssemblyCallback(LoadAssemblyCallback callback)
		{
		}

		public static View CreateView(FrameworkElement content)
		{
			return null;
		}

		public static void UnregisterNativeTypes()
		{
		}

		[MonoPInvokeCallback(typeof(NoesisSoftwareKeyboardCallback))]
		private static void OnSoftwareKeyboard(IntPtr cPtrFocused, bool open)
		{
		}

		[MonoPInvokeCallback(typeof(NoesisUpdateCursorCallback))]
		private static void OnUpdateCursor(IntPtr cPtrView, IntPtr cursorPtr)
		{
		}

		[MonoPInvokeCallback(typeof(NoesisOpenUrlCallback))]
		private static void OnOpenUrl(IntPtr url)
		{
		}

		[MonoPInvokeCallback(typeof(NoesisPlayAudioCallback))]
		private static void OnPlayAudio(IntPtr sound, float volume)
		{
		}

		[MonoPInvokeCallback(typeof(NoesisXamlDependencyCallback))]
		private static void OnXamlDependency(int callbackId, IntPtr uri, int type)
		{
		}

		[MonoPInvokeCallback(typeof(NoesisFontFaceInfoCallback))]
		private static void OnFontFace(int callbackId, int index, IntPtr familyName, int weight, int style, int stretch)
		{
		}

		[MonoPInvokeCallback(typeof(NoesisLoadAssemblyCallback))]
		private static void OnLoadAssembly(IntPtr assemblyPtr)
		{
		}

		[PreserveSig]
		private static extern IntPtr Noesis_GetBuildVersion();

		[PreserveSig]
		private static extern void Noesis_DisableInspector();

		[PreserveSig]
		private static extern bool Noesis_IsInspectorConnected();

		[PreserveSig]
		private static extern void Noesis_UpdateInspector();

		[PreserveSig]
		private static extern void Noesis_SetLicense(string Name, string key);

		[PreserveSig]
		private static extern void Noesis_Init();

		[PreserveSig]
		private static extern void Noesis_Shutdown();

		[PreserveSig]
		private static extern void Noesis_SetXamlProvider(HandleRef provider);

		[PreserveSig]
		private static extern void Noesis_SetTextureProvider(HandleRef provider);

		[PreserveSig]
		private static extern void Noesis_SetFontProvider(HandleRef provider);

		[PreserveSig]
		private static extern void Noesis_SetFontFallbacks(string[] familyNames, int count);

		[PreserveSig]
		private static extern void Noesis_SetFontDefaultProperties(float size, int weight, int stretch, int style);

		[PreserveSig]
		private static extern void Noesis_SetApplicationResources(HandleRef resources);

		[PreserveSig]
		private static extern IntPtr Noesis_GetApplicationResources();

		[PreserveSig]
		private static extern void Noesis_SetSoftwareKeyboardCallback(NoesisSoftwareKeyboardCallback callback);

		[PreserveSig]
		private static extern void Noesis_SetCursorCallback(NoesisUpdateCursorCallback callback);

		[PreserveSig]
		private static extern void Noesis_SetOpenUrlCallback(NoesisOpenUrlCallback callback);

		[PreserveSig]
		private static extern void Noesis_SetPlayAudioCallback(NoesisPlayAudioCallback callback);

		[PreserveSig]
		private static extern void Noesis_GetXamlDependencies(HandleRef stream, string baseUri, int callbackId, NoesisXamlDependencyCallback callback);

		[PreserveSig]
		private static extern IntPtr Noesis_LoadStreamXaml(HandleRef stream, string filename);

		[PreserveSig]
		private static extern IntPtr Noesis_LoadXaml(string filename);

		[PreserveSig]
		private static extern IntPtr Noesis_ParseXaml(string xamlText);

		[PreserveSig]
		private static extern IntPtr Noesis_LoadXamlResource(string filename);

		[PreserveSig]
		private static extern void Noesis_EnumFontFaces(HandleRef stream, int callbackId, NoesisFontFaceInfoCallback callback);

		[PreserveSig]
		private static extern void Noesis_LoadComponent(HandleRef component, string filename);

		[PreserveSig]
		private static extern void Noesis_SetLoadAssemblyCallback(NoesisLoadAssemblyCallback callback);
	}
}
