using System.Runtime.InteropServices;

namespace ShellFileDialogs
{
	[StructLayout((LayoutKind)0, CharSet = CharSet.Auto)]
	internal struct FilterSpec
	{
		internal string Name;

		internal string Spec;

		internal FilterSpec(string name, string spec)
		{
			Name = null;
			Spec = null;
		}
	}
}
