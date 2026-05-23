using System.Reflection;

namespace Utf8Json.Internal
{
	public static class AutomataKeyGen
	{
		public static readonly MethodInfo GetKeyMethod;

		public unsafe static ulong GetKey(ref byte* p, ref int rest)
		{
			return 0uL;
		}

		public static ulong GetKeySafe(byte[] bytes, ref int offset, ref int rest)
		{
			return 0uL;
		}
	}
}
