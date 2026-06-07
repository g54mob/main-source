using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Mono.Cecil;

internal static class MultiTargetShims
{
	private static readonly object[] _NoArgs = new object[0];

	public static string Replace(this string self, string oldValue, string newValue, StringComparison comparison)
	{
		return self.Replace(oldValue, newValue);
	}

	public static bool Contains(this string self, string value, StringComparison comparison)
	{
		return self.Contains(value);
	}

	public static int GetHashCode(this string self, StringComparison comparison)
	{
		return self.GetHashCode();
	}

	public static int IndexOf(this string self, char value, StringComparison comparison)
	{
		return self.IndexOf(value);
	}

	public static int IndexOf(this string self, string value, StringComparison comparison)
	{
		return self.IndexOf(value);
	}

	public static Module[] GetModules(this Assembly asm)
	{
		return asm.Modules.ToArray();
	}

	public static Module GetModule(this Assembly asm, string name)
	{
		return asm.Modules.FirstOrDefault((Module module) => module.Name == name);
	}

	public static byte[] GetBuffer(this MemoryStream ms)
	{
		long position = ms.Position;
		byte[] array = new byte[ms.Length];
		ms.Read(array, 0, array.Length);
		ms.Position = position;
		return array;
	}

	public static TypeReference GetConstraintType(this GenericParameterConstraint constraint)
	{
		return constraint.ConstraintType;
	}
}
