using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NAudio.Dmo
{
	internal static class DmoInterop
	{
		[PreserveSig]
		public static extern int DMOEnum([In] ref Guid guidCategory, DmoEnumFlags flags, int inTypes, [In] DmoPartialMediaType[] inTypesArray, int outTypes, [In] DmoPartialMediaType[] outTypesArray, out IEnumDmo enumDmo);

		[PreserveSig]
		public static extern int MoFreeMediaType([In] ref DmoMediaType mediaType);

		[PreserveSig]
		public static extern int MoInitMediaType([In][Out] ref DmoMediaType mediaType, int formatBlockBytes);

		[PreserveSig]
		public static extern int DMOGetName([In] ref Guid clsidDMO, [Out] StringBuilder name);
	}
}
