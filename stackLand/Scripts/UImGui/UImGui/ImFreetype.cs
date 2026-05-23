using System;
using System.Runtime.InteropServices;

namespace UImGui
{
	public static class ImFreetype
	{
		internal enum BuilderFlags
		{
			NoHinting = 1,
			NoAutoHint = 2,
			ForceAutoHint = 4,
			LightHinting = 8,
			MonoHinting = 0x10,
			Bold = 0x20,
			Oblique = 0x40,
			Monochrome = 0x80,
			LoadColor = 0x100,
			Bitmap = 0x200
		}

		public delegate void FreeType_Alloc(uint sz, IntPtr userData);

		public delegate void FreeType_Free(IntPtr ptr, IntPtr userData);

		public static IntPtr GetBuilderForFreeType()
		{
			return ImFreetypeNative.GetBuilderForFreeType();
		}

		public static void SetAllocatorFunctions(FreeType_Alloc alloc_function, FreeType_Free free_function, IntPtr user_data = default(IntPtr))
		{
			ImFreetypeNative.SetAllocatorFunctions(Marshal.GetFunctionPointerForDelegate(alloc_function), Marshal.GetFunctionPointerForDelegate(free_function), user_data);
		}
	}
}
