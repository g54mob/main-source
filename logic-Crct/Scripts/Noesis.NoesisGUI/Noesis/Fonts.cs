using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Noesis
{
	public static class Fonts
	{
		private delegate void Callback_GetTypefaces(uint id, Typeface typeface);

		private struct TypefacesInfo
		{
			public List<Typeface> Typefaces;
		}

		private static Callback_GetTypefaces _getTypefaces;

		private static uint _getTypefacesId;

		private static Dictionary<uint, TypefacesInfo> _getTypefacesCallbacks;

		public static ICollection<Typeface> GetTypefaces(Stream stream)
		{
			return null;
		}

		[MonoPInvokeCallback(typeof(Callback_GetTypefaces))]
		private static void OnGetTypefaces(uint id, Typeface typeface)
		{
		}

		[PreserveSig]
		private static extern void Fonts_GetTypefaces(HandleRef stream, uint id, Callback_GetTypefaces callback);
	}
}
