using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Internal;

internal static class UnityEqualityComparer
{
	private static class Cache<T>
	{
		public static readonly IEqualityComparer<T> Comparer;

		static Cache()
		{
			//IL_0013: Expected O, but got I
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			//IL_00fd: Expected O, but got I
			//IL_012d: Expected O, but got I
			//IL_0142: Expected O, but got I
			//IL_00a6: Expected O, but got I
			//IL_00bb: Expected O, but got I
			nint num = 0;
			Type type = (Type)num;
			if (num != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj2 = default(object);
				object obj = obj2 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				Type type2 = default(Type);
				type = type2;
			}
			object defaultHelper = GetDefaultHelper(type);
			if (defaultHelper != null)
			{
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					throw new InvalidCastException();
				}
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rax_v47 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.UnityEqualityComparer+Cache`1>)+30]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rax_v49+B8]");
				object obj5 = 0;
				obj5 = obj3;
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj6 = default(object);
				if (obj6 == null)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v11 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.UnityEqualityComparer+Cache`1>)+8]");
				object obj7 = 0;
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v179 @ rcx_v10] (should have been resolved before IL gen)");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rax_v18 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.UnityEqualityComparer+Cache`1>)+30]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ rax_v20+B8]");
				object obj9 = 0;
				object obj10 = default(object);
				obj9 = obj10;
			}
		}
	}

	private sealed class Vector2EqualityComparer : IEqualityComparer<Vector2>
	{
		public bool Equals(Vector2 self, Vector2 vector)
		{
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Expected O, but got Unknown
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Expected O, but got Unknown
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Expected O, but got Unknown
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Expected O, but got Unknown
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Expected O, but got Unknown
			bool flag = (object)vector == (object)self;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA3CEFh\"");
			if (flag)
			{
				goto IL_008a;
			}
			object obj = vector & -2147483649L;
			if ((nint)obj > 2139095040)
			{
				object obj2 = self & -2147483649L;
				if ((nint)obj2 > 2139095040)
				{
					goto IL_008a;
				}
			}
			goto IL_0151;
			IL_008a:
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA3D27h\"");
			object obj3 = default(object);
			object obj4 = default(object);
			if (obj3 == obj4)
			{
				return true;
			}
			object obj5 = obj3 & -2147483649L;
			if ((nint)obj5 > 2139095040)
			{
				object obj6 = obj4 & -2147483649L;
				bool flag2 = (nint)obj6 < 2139095040;
				object obj7 = obj6 - 2139095040;
				bool flag3 = obj7 == null;
				bool flag4 = !flag2;
				bool flag5 = !flag3;
				return flag5 & flag4;
			}
			goto IL_0151;
			IL_0151:
			return false;
		}

		public int GetHashCode(Vector2 obj)
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Expected O, but got Unknown
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Expected O, but got Unknown
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Expected O, but got Unknown
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Expected O, but got Unknown
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Expected O, but got Unknown
			//IL_00c3: Expected I4, but got O
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Expected O, but got Unknown
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Expected O, but got Unknown
			Vector2 vector = default(Vector2);
			object obj2 = vector - 1;
			object obj3 = obj2 & -2147483649L;
			if ((nint)obj3 >= 2139095040)
			{
				vector = (Vector2)(vector & 0x7F800000);
			}
			object obj5 = default(object);
			object obj4 = obj5 - 1;
			object obj6 = obj4 & -2147483649L;
			bool flag = (nint)obj6 < 2139095040;
			object obj7 = obj5;
			if (!flag)
			{
				obj7 = obj5 & 0x7F800000;
			}
			object obj8 = obj7 * 4;
			return obj8 ^ (object)vector;
		}
	}

	private sealed class Vector3EqualityComparer : IEqualityComparer<Vector3>
	{
		public bool Equals(Vector3 self, Vector3 vector)
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Expected O, but got Unknown
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Expected O, but got Unknown
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Expected O, but got Unknown
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Expected O, but got Unknown
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Expected O, but got Unknown
			//IL_01db: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e0: Expected O, but got Unknown
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Expected O, but got Unknown
			bool flag = vector.x == self.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA3DBCh\"");
			if (flag)
			{
				goto IL_009e;
			}
			object obj = vector.x & -2147483649L;
			if ((nint)obj > 2139095040)
			{
				object obj2 = self.x & -2147483649L;
				if ((nint)obj2 > 2139095040)
				{
					goto IL_009e;
				}
			}
			goto IL_0217;
			IL_013c:
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA3E14h\"");
			if (vector.z == self.z)
			{
				return true;
			}
			object obj3 = vector.z & -2147483649L;
			if ((nint)obj3 > 2139095040)
			{
				object obj4 = self.z & -2147483649L;
				bool flag2 = (nint)obj4 < 2139095040;
				object obj5 = obj4 - 2139095040;
				bool flag3 = obj5 == null;
				bool flag4 = !flag2;
				bool flag5 = !flag3;
				return flag5 & flag4;
			}
			goto IL_0217;
			IL_0217:
			return false;
			IL_009e:
			bool flag6 = vector.y == self.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA3DE6h\"");
			if (flag6)
			{
				goto IL_013c;
			}
			object obj6 = vector.y & -2147483649L;
			if ((nint)obj6 > 2139095040)
			{
				object obj7 = self.y & -2147483649L;
				if ((nint)obj7 > 2139095040)
				{
					goto IL_013c;
				}
			}
			goto IL_0217;
		}

		public int GetHashCode(Vector3 obj)
		{
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Expected O, but got Unknown
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Expected O, but got Unknown
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Expected F4, but got Unknown
			//IL_00e9: Expected O, but got F4
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Expected O, but got Unknown
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Expected I4, but got Unknown
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Expected F4, but got Unknown
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Expected F4, but got Unknown
			float num = obj.x;
			float num2 = obj.x - 1f;
			object obj2 = num2 & -2147483649L;
			if ((nint)obj2 >= 2139095040)
			{
				num &= 0x7F800000;
			}
			float num3 = obj.y;
			float num4 = obj.y - 1f;
			object obj3 = num4 & -2147483649L;
			if ((nint)obj3 >= 2139095040)
			{
				num3 &= 0x7F800000;
			}
			float num5 = obj.z;
			float num6 = obj.z - 1f;
			object obj4 = num6 & -2147483649L;
			if ((nint)obj4 >= 2139095040)
			{
				num5 &= 0x7F800000;
			}
			object obj5 = num5 >> 2;
			float num7 = num3 * 4f;
			object obj6 = obj5 ^ num7;
			return obj6 ^ num;
		}
	}

	private sealed class Vector4EqualityComparer : IEqualityComparer<Vector4>
	{
		public bool Equals(Vector4 self, Vector4 vector)
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Expected O, but got Unknown
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Expected O, but got Unknown
			//IL_0225: Unknown result type (might be due to invalid IL or missing references)
			//IL_022a: Expected O, but got Unknown
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Expected O, but got Unknown
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Expected O, but got Unknown
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Expected O, but got Unknown
			//IL_025c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0261: Expected O, but got Unknown
			//IL_0279: Unknown result type (might be due to invalid IL or missing references)
			//IL_027e: Expected O, but got Unknown
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Expected O, but got Unknown
			bool flag = vector.x == self.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA3EACh\"");
			if (flag)
			{
				goto IL_009e;
			}
			object obj = vector.x & -2147483649L;
			if ((nint)obj > 2139095040)
			{
				object obj2 = self.x & -2147483649L;
				if ((nint)obj2 > 2139095040)
				{
					goto IL_009e;
				}
			}
			goto IL_02b5;
			IL_02b5:
			return false;
			IL_013c:
			bool flag2 = vector.z == self.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA3F09h\"");
			if (flag2)
			{
				goto IL_01da;
			}
			object obj3 = vector.z & -2147483649L;
			if ((nint)obj3 > 2139095040)
			{
				object obj4 = self.z & -2147483649L;
				if ((nint)obj4 > 2139095040)
				{
					goto IL_01da;
				}
			}
			goto IL_02b5;
			IL_009e:
			bool flag3 = vector.y == self.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA3EDEh\"");
			if (flag3)
			{
				goto IL_013c;
			}
			object obj5 = vector.y & -2147483649L;
			if ((nint)obj5 > 2139095040)
			{
				object obj6 = self.y & -2147483649L;
				if ((nint)obj6 > 2139095040)
				{
					goto IL_013c;
				}
			}
			goto IL_02b5;
			IL_01da:
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA3F37h\"");
			if (vector.w == self.w)
			{
				return true;
			}
			object obj7 = vector.w & -2147483649L;
			if ((nint)obj7 > 2139095040)
			{
				object obj8 = self.w & -2147483649L;
				bool flag4 = (nint)obj8 < 2139095040;
				object obj9 = obj8 - 2139095040;
				bool flag5 = obj9 == null;
				bool flag6 = !flag4;
				bool flag7 = !flag5;
				return flag7 & flag6;
			}
			goto IL_02b5;
		}

		public int GetHashCode(Vector4 obj)
		{
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected O, but got Unknown
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Expected O, but got Unknown
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Expected F4, but got Unknown
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Expected O, but got Unknown
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Expected F4, but got Unknown
			//IL_019e: Expected O, but got F4
			//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Expected O, but got Unknown
			//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d6: Expected O, but got Unknown
			//IL_01de: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Expected I4, but got Unknown
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Expected F4, but got Unknown
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Expected F4, but got Unknown
			float num = obj.x;
			float num2 = obj.x - 1f;
			object obj2 = num2 & -2147483649L;
			if ((nint)obj2 >= 2139095040)
			{
				num &= 0x7F800000;
			}
			float num3 = obj.y;
			float num4 = obj.y - 1f;
			object obj3 = num4 & -2147483649L;
			if ((nint)obj3 >= 2139095040)
			{
				num3 &= 0x7F800000;
			}
			float num5 = obj.z;
			float num6 = obj.z - 1f;
			object obj4 = num6 & -2147483649L;
			if ((nint)obj4 >= 2139095040)
			{
				num5 &= 0x7F800000;
			}
			float num7 = obj.w;
			float num8 = obj.w - 1f;
			object obj5 = num8 & -2147483649L;
			if ((nint)obj5 >= 2139095040)
			{
				num7 &= 0x7F800000;
			}
			object obj6 = num5 >> 1;
			float num9 = num3 * 4f;
			object obj7 = obj6 ^ num7;
			object obj8 = obj7 >> 1;
			object obj9 = num9 ^ obj8;
			return obj9 ^ num;
		}
	}

	private sealed class ColorEqualityComparer : IEqualityComparer<Color>
	{
		public bool Equals(Color self, Color other)
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Expected O, but got Unknown
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Expected O, but got Unknown
			//IL_0225: Unknown result type (might be due to invalid IL or missing references)
			//IL_022a: Expected O, but got Unknown
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Expected O, but got Unknown
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Expected O, but got Unknown
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Expected O, but got Unknown
			//IL_025c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0261: Expected O, but got Unknown
			//IL_0279: Unknown result type (might be due to invalid IL or missing references)
			//IL_027e: Expected O, but got Unknown
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Expected O, but got Unknown
			bool flag = other.r == self.r;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA3EACh\"");
			if (flag)
			{
				goto IL_009e;
			}
			object obj = other.r & -2147483649L;
			if ((nint)obj > 2139095040)
			{
				object obj2 = self.r & -2147483649L;
				if ((nint)obj2 > 2139095040)
				{
					goto IL_009e;
				}
			}
			goto IL_02b5;
			IL_02b5:
			return false;
			IL_013c:
			bool flag2 = other.b == self.b;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA3F09h\"");
			if (flag2)
			{
				goto IL_01da;
			}
			object obj3 = other.b & -2147483649L;
			if ((nint)obj3 > 2139095040)
			{
				object obj4 = self.b & -2147483649L;
				if ((nint)obj4 > 2139095040)
				{
					goto IL_01da;
				}
			}
			goto IL_02b5;
			IL_009e:
			bool flag3 = other.g == self.g;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA3EDEh\"");
			if (flag3)
			{
				goto IL_013c;
			}
			object obj5 = other.g & -2147483649L;
			if ((nint)obj5 > 2139095040)
			{
				object obj6 = self.g & -2147483649L;
				if ((nint)obj6 > 2139095040)
				{
					goto IL_013c;
				}
			}
			goto IL_02b5;
			IL_01da:
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA3F37h\"");
			if (other.a == self.a)
			{
				return true;
			}
			object obj7 = other.a & -2147483649L;
			if ((nint)obj7 > 2139095040)
			{
				object obj8 = self.a & -2147483649L;
				bool flag4 = (nint)obj8 < 2139095040;
				object obj9 = obj8 - 2139095040;
				bool flag5 = obj9 == null;
				bool flag6 = !flag4;
				bool flag7 = !flag5;
				return flag7 & flag6;
			}
			goto IL_02b5;
		}

		public int GetHashCode(Color obj)
		{
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected O, but got Unknown
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Expected O, but got Unknown
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Expected F4, but got Unknown
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Expected O, but got Unknown
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Expected F4, but got Unknown
			//IL_019e: Expected O, but got F4
			//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Expected O, but got Unknown
			//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d6: Expected O, but got Unknown
			//IL_01de: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Expected I4, but got Unknown
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Expected F4, but got Unknown
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Expected F4, but got Unknown
			float num = obj.r;
			float num2 = obj.r - 1f;
			object obj2 = num2 & -2147483649L;
			if ((nint)obj2 >= 2139095040)
			{
				num &= 0x7F800000;
			}
			float num3 = obj.g;
			float num4 = obj.g - 1f;
			object obj3 = num4 & -2147483649L;
			if ((nint)obj3 >= 2139095040)
			{
				num3 &= 0x7F800000;
			}
			float num5 = obj.b;
			float num6 = obj.b - 1f;
			object obj4 = num6 & -2147483649L;
			if ((nint)obj4 >= 2139095040)
			{
				num5 &= 0x7F800000;
			}
			float num7 = obj.a;
			float num8 = obj.a - 1f;
			object obj5 = num8 & -2147483649L;
			if ((nint)obj5 >= 2139095040)
			{
				num7 &= 0x7F800000;
			}
			object obj6 = num5 >> 1;
			float num9 = num3 * 4f;
			object obj7 = obj6 ^ num7;
			object obj8 = obj7 >> 1;
			object obj9 = num9 ^ obj8;
			return obj9 ^ num;
		}
	}

	private sealed class RectEqualityComparer : IEqualityComparer<Rect>
	{
		public bool Equals(Rect self, Rect other)
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Expected O, but got Unknown
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Expected O, but got Unknown
			//IL_0225: Unknown result type (might be due to invalid IL or missing references)
			//IL_022a: Expected O, but got Unknown
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Expected O, but got Unknown
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Expected O, but got Unknown
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Expected O, but got Unknown
			//IL_025c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0261: Expected O, but got Unknown
			//IL_0279: Unknown result type (might be due to invalid IL or missing references)
			//IL_027e: Expected O, but got Unknown
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Expected O, but got Unknown
			bool flag = other.m_XMin == self.m_XMin;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA3FF2h\"");
			if (flag)
			{
				goto IL_009e;
			}
			object obj = other.m_XMin & -2147483649L;
			if ((nint)obj > 2139095040)
			{
				object obj2 = self.m_XMin & -2147483649L;
				if ((nint)obj2 > 2139095040)
				{
					goto IL_009e;
				}
			}
			goto IL_02b5;
			IL_02b5:
			return false;
			IL_013c:
			bool flag2 = other.m_YMin == self.m_YMin;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA405Ah\"");
			if (flag2)
			{
				goto IL_01da;
			}
			object obj3 = other.m_YMin & -2147483649L;
			if ((nint)obj3 > 2139095040)
			{
				object obj4 = self.m_YMin & -2147483649L;
				if ((nint)obj4 > 2139095040)
				{
					goto IL_01da;
				}
			}
			goto IL_02b5;
			IL_009e:
			bool flag3 = other.m_Width == self.m_Width;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA402Ah\"");
			if (flag3)
			{
				goto IL_013c;
			}
			object obj5 = other.m_Width & -2147483649L;
			if ((nint)obj5 > 2139095040)
			{
				object obj6 = self.m_Width & -2147483649L;
				if ((nint)obj6 > 2139095040)
				{
					goto IL_013c;
				}
			}
			goto IL_02b5;
			IL_01da:
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA408Dh\"");
			if (other.m_Height == self.m_Height)
			{
				return true;
			}
			object obj7 = other.m_Height & -2147483649L;
			if ((nint)obj7 > 2139095040)
			{
				object obj8 = self.m_Height & -2147483649L;
				bool flag4 = (nint)obj8 < 2139095040;
				object obj9 = obj8 - 2139095040;
				bool flag5 = obj9 == null;
				bool flag6 = !flag4;
				bool flag7 = !flag5;
				return flag7 & flag6;
			}
			goto IL_02b5;
		}

		public int GetHashCode(Rect obj)
		{
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected O, but got Unknown
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Expected O, but got Unknown
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Expected F4, but got Unknown
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Expected O, but got Unknown
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Expected F4, but got Unknown
			//IL_019e: Expected O, but got F4
			//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Expected O, but got Unknown
			//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d6: Expected O, but got Unknown
			//IL_01de: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Expected I4, but got Unknown
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Expected F4, but got Unknown
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Expected F4, but got Unknown
			float num = obj.m_XMin;
			float num2 = obj.m_XMin - 1f;
			object obj2 = num2 & -2147483649L;
			if ((nint)obj2 >= 2139095040)
			{
				num &= 0x7F800000;
			}
			float num3 = obj.m_Width;
			float num4 = obj.m_Width - 1f;
			object obj3 = num4 & -2147483649L;
			if ((nint)obj3 >= 2139095040)
			{
				num3 &= 0x7F800000;
			}
			float num5 = obj.m_YMin;
			float num6 = obj.m_YMin - 1f;
			object obj4 = num6 & -2147483649L;
			if ((nint)obj4 >= 2139095040)
			{
				num5 &= 0x7F800000;
			}
			float num7 = obj.m_Height;
			float num8 = obj.m_Height - 1f;
			object obj5 = num8 & -2147483649L;
			if ((nint)obj5 >= 2139095040)
			{
				num7 &= 0x7F800000;
			}
			object obj6 = num5 >> 1;
			float num9 = num3 * 4f;
			object obj7 = obj6 ^ num7;
			object obj8 = obj7 >> 1;
			object obj9 = num9 ^ obj8;
			return obj9 ^ num;
		}
	}

	private sealed class BoundsEqualityComparer : IEqualityComparer<Bounds>
	{
		public bool Equals(Bounds self, Bounds vector)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA41ADh\"");
			if ((object)self.m_Center == (object)vector.m_Center)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA41ADh\"");
				object obj = default(object);
				object obj2 = default(object);
				if (obj == obj2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA41ADh\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [self @ rdx (UnityEngine.Bounds)+8]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vector @ r8 (UnityEngine.Bounds)+8]");
					if (num == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA41ADh\"");
						if ((object)self.m_Extents == (object)vector.m_Extents)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA41ADh\"");
							if (obj2 == obj)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA41ADh\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [self @ rdx (UnityEngine.Bounds)+14]");
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vector @ r8 (UnityEngine.Bounds)+14]");
								if (num2 == 0)
								{
									return true;
								}
							}
						}
					}
				}
			}
			return false;
		}

		public int GetHashCode(Bounds obj)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Expected O, but got Unknown
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected O, but got Unknown
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Expected O, but got Unknown
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Expected O, but got Unknown
			//IL_01ca: Expected O, but got I
			//IL_01e0: Expected O, but got I
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f2: Expected O, but got Unknown
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Expected O, but got Unknown
			//IL_012e: Expected O, but got I
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Expected O, but got Unknown
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Expected O, but got Unknown
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Expected O, but got Unknown
			//IL_0218: Unknown result type (might be due to invalid IL or missing references)
			//IL_021d: Expected O, but got Unknown
			//IL_022a: Unknown result type (might be due to invalid IL or missing references)
			//IL_022f: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Expected O, but got Unknown
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Expected O, but got Unknown
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Expected O, but got Unknown
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Expected O, but got Unknown
			//IL_025d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0262: Expected O, but got Unknown
			//IL_026b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0270: Expected O, but got Unknown
			//IL_02bf: Expected I4, but got O
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Expected O, but got Unknown
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Expected O, but got Unknown
			object obj2 = obj.m_Center - 1;
			object obj3 = obj2 & -2147483649L;
			bool flag = (nint)obj3 < 2139095040;
			Vector3 vector = obj.m_Center;
			if (!flag)
			{
				vector = (Vector3)(obj.m_Center & 0x7F800000);
			}
			object obj5 = default(object);
			object obj4 = obj5 - 1;
			object obj6 = obj4 & -2147483649L;
			bool flag2 = (nint)obj6 < 2139095040;
			object obj7 = obj5;
			if (!flag2)
			{
				obj7 = obj5 & 0x7F800000;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ rdx (UnityEngine.Bounds)+8]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ rdx (UnityEngine.Bounds)+8]");
			object obj9 = -1;
			object obj10 = obj9 & -2147483649L;
			if ((nint)obj10 >= 2139095040)
			{
				obj8 &= 0x7F800000;
			}
			object obj11 = obj8 >> 2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ rdx (UnityEngine.Bounds)+14]");
			object obj12 = 0;
			object obj13 = obj.m_Extents - 1;
			object obj14 = obj13 & -2147483649L;
			bool flag3 = (nint)obj14 < 2139095040;
			Vector3 vector2 = obj.m_Extents;
			if (!flag3)
			{
				vector2 = (Vector3)(obj.m_Extents & 0x7F800000);
			}
			object obj15 = obj5 - 1;
			object obj16 = obj15 & -2147483649L;
			bool flag4 = (nint)obj16 < 2139095040;
			object obj17 = obj5;
			if (!flag4)
			{
				obj17 = obj5 & 0x7F800000;
			}
			object obj18 = obj12 - 1;
			object obj19 = obj18 & -2147483649L;
			if ((nint)obj19 >= 2139095040)
			{
				obj12 &= 0x7F800000;
			}
			object obj20 = obj12 & -4;
			object obj21 = obj17 * 4;
			object obj22 = obj21 ^ (object)vector2;
			object obj23 = obj22 ^ obj7;
			object obj24 = obj23 << 2;
			object obj25 = obj24 ^ obj20;
			object obj26 = obj25 ^ obj11;
			return obj26 ^ (object)vector;
		}
	}

	private sealed class QuaternionEqualityComparer : IEqualityComparer<Quaternion>
	{
		public bool Equals(Quaternion self, Quaternion vector)
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Expected O, but got Unknown
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Expected O, but got Unknown
			//IL_0225: Unknown result type (might be due to invalid IL or missing references)
			//IL_022a: Expected O, but got Unknown
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Expected O, but got Unknown
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Expected O, but got Unknown
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Expected O, but got Unknown
			//IL_025c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0261: Expected O, but got Unknown
			//IL_0279: Unknown result type (might be due to invalid IL or missing references)
			//IL_027e: Expected O, but got Unknown
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Expected O, but got Unknown
			bool flag = vector.x == self.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA3EACh\"");
			if (flag)
			{
				goto IL_009e;
			}
			object obj = vector.x & -2147483649L;
			if ((nint)obj > 2139095040)
			{
				object obj2 = self.x & -2147483649L;
				if ((nint)obj2 > 2139095040)
				{
					goto IL_009e;
				}
			}
			goto IL_02b5;
			IL_02b5:
			return false;
			IL_013c:
			bool flag2 = vector.z == self.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA3F09h\"");
			if (flag2)
			{
				goto IL_01da;
			}
			object obj3 = vector.z & -2147483649L;
			if ((nint)obj3 > 2139095040)
			{
				object obj4 = self.z & -2147483649L;
				if ((nint)obj4 > 2139095040)
				{
					goto IL_01da;
				}
			}
			goto IL_02b5;
			IL_009e:
			bool flag3 = vector.y == self.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA3EDEh\"");
			if (flag3)
			{
				goto IL_013c;
			}
			object obj5 = vector.y & -2147483649L;
			if ((nint)obj5 > 2139095040)
			{
				object obj6 = self.y & -2147483649L;
				if ((nint)obj6 > 2139095040)
				{
					goto IL_013c;
				}
			}
			goto IL_02b5;
			IL_01da:
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185DA3F37h\"");
			if (vector.w == self.w)
			{
				return true;
			}
			object obj7 = vector.w & -2147483649L;
			if ((nint)obj7 > 2139095040)
			{
				object obj8 = self.w & -2147483649L;
				bool flag4 = (nint)obj8 < 2139095040;
				object obj9 = obj8 - 2139095040;
				bool flag5 = obj9 == null;
				bool flag6 = !flag4;
				bool flag7 = !flag5;
				return flag7 & flag6;
			}
			goto IL_02b5;
		}

		public int GetHashCode(Quaternion obj)
		{
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected O, but got Unknown
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Expected O, but got Unknown
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Expected F4, but got Unknown
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Expected O, but got Unknown
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Expected F4, but got Unknown
			//IL_019e: Expected O, but got F4
			//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Expected O, but got Unknown
			//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d6: Expected O, but got Unknown
			//IL_01de: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Expected I4, but got Unknown
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Expected F4, but got Unknown
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Expected F4, but got Unknown
			float num = obj.x;
			float num2 = obj.x - 1f;
			object obj2 = num2 & -2147483649L;
			if ((nint)obj2 >= 2139095040)
			{
				num &= 0x7F800000;
			}
			float num3 = obj.y;
			float num4 = obj.y - 1f;
			object obj3 = num4 & -2147483649L;
			if ((nint)obj3 >= 2139095040)
			{
				num3 &= 0x7F800000;
			}
			float num5 = obj.z;
			float num6 = obj.z - 1f;
			object obj4 = num6 & -2147483649L;
			if ((nint)obj4 >= 2139095040)
			{
				num5 &= 0x7F800000;
			}
			float num7 = obj.w;
			float num8 = obj.w - 1f;
			object obj5 = num8 & -2147483649L;
			if ((nint)obj5 >= 2139095040)
			{
				num7 &= 0x7F800000;
			}
			object obj6 = num5 >> 1;
			float num9 = num3 * 4f;
			object obj7 = obj6 ^ num7;
			object obj8 = obj7 >> 1;
			object obj9 = num9 ^ obj8;
			return obj9 ^ num;
		}
	}

	private sealed class Color32EqualityComparer : IEqualityComparer<Color32>
	{
		public bool Equals(Color32 self, Color32 vector)
		{
			object obj = (object)self >> 24;
			object obj2 = (object)vector >> 24;
			if (obj == obj2 && (object)self == (object)vector)
			{
				object obj3 = (object)self >> 8;
				object obj4 = (object)vector >> 8;
				if (obj3 == obj4)
				{
					object obj5 = (object)self >> 16;
					object obj6 = (object)vector >> 16;
					object obj7 = obj5 - obj6;
					return obj7 == null;
				}
			}
			return false;
		}

		public int GetHashCode(Color32 obj)
		{
			//IL_007b: Expected I4, but got O
			object obj2 = (object)obj >> 8;
			object obj3 = (object)obj >> 16;
			object obj4 = obj2 >> 1;
			object obj5 = obj4 ^ obj3;
			object obj6 = (object)obj >> 24;
			object obj7 = obj5 >> 1;
			object obj8 = obj7 ^ obj6;
			object obj9 = (object)obj << 2;
			return obj8 ^ obj9;
		}
	}

	private sealed class Vector2IntEqualityComparer : IEqualityComparer<Vector2Int>
	{
		public bool Equals(Vector2Int self, Vector2Int vector)
		{
			if ((object)self != (object)vector)
			{
				return false;
			}
			object obj = (object)self >> 32;
			object obj2 = (object)vector >> 32;
			object obj3 = obj - obj2;
			return obj3 == null;
		}

		public int GetHashCode(Vector2Int obj)
		{
			//IL_0029: Expected I4, but got O
			object obj2 = (object)obj >> 32;
			object obj3 = obj2 << 2;
			return obj3 ^ (object)obj;
		}
	}

	private sealed class Vector3IntEqualityComparer : IEqualityComparer<Vector3Int>
	{
		public static readonly Vector3IntEqualityComparer Default;

		public bool Equals(Vector3Int self, Vector3Int vector)
		{
			//IL_0069: Expected O, but got I4
			if (self.m_X == vector.m_X && self.m_Y == vector.m_Y)
			{
				object obj = self.m_Z - vector.m_Z;
				return obj == null;
			}
			return false;
		}

		public int GetHashCode(Vector3Int obj)
		{
			int num = obj.m_Z >> 2;
			int num2 = obj.m_Y << 2;
			int num3 = num ^ num2;
			return num3 ^ obj.m_X;
		}

		static Vector3IntEqualityComparer()
		{
			Vector3IntEqualityComparer vector3IntEqualityComparer = new Vector3IntEqualityComparer();
			Default = vector3IntEqualityComparer;
		}
	}

	private sealed class RangeIntEqualityComparer : IEqualityComparer<RangeInt>
	{
		public bool Equals(RangeInt self, RangeInt vector)
		{
			if ((object)self != (object)vector)
			{
				return false;
			}
			object obj = (object)self >> 32;
			object obj2 = (object)vector >> 32;
			object obj3 = obj - obj2;
			return obj3 == null;
		}

		public int GetHashCode(RangeInt obj)
		{
			//IL_0029: Expected I4, but got O
			object obj2 = (object)obj >> 32;
			object obj3 = obj2 << 2;
			return obj3 ^ (object)obj;
		}
	}

	private sealed class RectIntEqualityComparer : IEqualityComparer<RectInt>
	{
		public bool Equals(RectInt self, RectInt other)
		{
			//IL_0092: Expected O, but got I4
			if (self.m_XMin == other.m_XMin && self.m_Width == other.m_Width && self.m_YMin == other.m_YMin)
			{
				object obj = self.m_Height - other.m_Height;
				return obj == null;
			}
			return false;
		}

		public int GetHashCode(RectInt obj)
		{
			int num = obj.m_YMin >> 1;
			int num2 = num ^ obj.m_Height;
			int num3 = num2 >> 1;
			int num4 = obj.m_Width << 2;
			int num5 = num3 ^ num4;
			return num5 ^ obj.m_XMin;
		}
	}

	private sealed class BoundsIntEqualityComparer : IEqualityComparer<BoundsInt>
	{
		public bool Equals(BoundsInt self, BoundsInt vector)
		{
			//IL_015a: Expected I4, but got O
			//IL_0132: Expected O, but got I
			if (Vector3IntEqualityComparer.Default != null)
			{
				if ((object)self.m_Position == (object)vector.m_Position)
				{
					object obj = (object)vector.m_Position >> 32;
					object obj2 = (object)self.m_Position >> 32;
					if (obj2 == obj)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [self @ rdx (UnityEngine.BoundsInt)+8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vector @ r8 (UnityEngine.BoundsInt)+8]");
						if (num == 0)
						{
							if (Vector3IntEqualityComparer.Default == null)
							{
								goto IL_014c;
							}
							if ((object)self.m_Size == (object)vector.m_Size)
							{
								object obj3 = (object)vector.m_Size >> 32;
								object obj4 = (object)self.m_Size >> 32;
								if (obj4 == obj3)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [self @ rdx (UnityEngine.BoundsInt)+14]");
									nint num2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vector @ r8 (UnityEngine.BoundsInt)+14]");
									object obj5 = num2 - 0;
									return obj5 == null;
								}
							}
						}
					}
				}
				return false;
			}
			goto IL_014c;
			IL_014c:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		public int GetHashCode(BoundsInt obj)
		{
			//IL_00d1: Expected I4, but got O
			//IL_001b: Expected O, but got I
			//IL_0072: Expected O, but got I
			//IL_00be: Expected I4, but got O
			if (Vector3IntEqualityComparer.Default != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ rdx (UnityEngine.BoundsInt)+14]");
				object obj2 = (nint)0 & (nint)(-4);
				object obj3 = (object)obj.m_Size >> 32;
				object obj4 = (object)obj.m_Position >> 32;
				object obj5 = obj3 << 2;
				object obj6 = obj4 ^ obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ rdx (UnityEngine.BoundsInt)+8]");
				object obj7 = (nint)0 >> 2;
				object obj8 = obj6 ^ (object)obj.m_Size;
				object obj9 = obj8 << 2;
				object obj10 = obj9 ^ obj2;
				object obj11 = obj10 ^ obj7;
				return obj11 ^ (object)obj.m_Position;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	public static readonly IEqualityComparer<Vector2> Vector2;

	public static readonly IEqualityComparer<Vector3> Vector3;

	public static readonly IEqualityComparer<Vector4> Vector4;

	public static readonly IEqualityComparer<Color> Color;

	public static readonly IEqualityComparer<Color32> Color32;

	public static readonly IEqualityComparer<Rect> Rect;

	public static readonly IEqualityComparer<Bounds> Bounds;

	public static readonly IEqualityComparer<Quaternion> Quaternion;

	private static readonly RuntimeTypeHandle vector2Type;

	private static readonly RuntimeTypeHandle vector3Type;

	private static readonly RuntimeTypeHandle vector4Type;

	private static readonly RuntimeTypeHandle colorType;

	private static readonly RuntimeTypeHandle color32Type;

	private static readonly RuntimeTypeHandle rectType;

	private static readonly RuntimeTypeHandle boundsType;

	private static readonly RuntimeTypeHandle quaternionType;

	public static readonly IEqualityComparer<Vector2Int> Vector2Int;

	public static readonly IEqualityComparer<Vector3Int> Vector3Int;

	public static readonly IEqualityComparer<RangeInt> RangeInt;

	public static readonly IEqualityComparer<RectInt> RectInt;

	public static readonly IEqualityComparer<BoundsInt> BoundsInt;

	private static readonly RuntimeTypeHandle vector2IntType;

	private static readonly RuntimeTypeHandle vector3IntType;

	private static readonly RuntimeTypeHandle rangeIntType;

	private static readonly RuntimeTypeHandle rectIntType;

	private static readonly RuntimeTypeHandle boundsIntType;

	public static IEqualityComparer<T> GetDefault<T>()
	{
		//IL_002b: Expected O, but got I
		//IL_0068: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rcx_v3 (Il2CppClass<Cysharp.Threading.Tasks.Internal.UnityEqualityComparer+Cache`1<T>>)+135]");
		object obj = (nint)0 & (nint)1;
		if (obj != null)
		{
			return Cache<T>.Comparer;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0570");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v7+B8]");
		return (IEqualityComparer<T>)0;
	}

	private static object GetDefaultHelper(Type type)
	{
		if ((object)type != null)
		{
			RuntimeTypeHandle typeHandle = type.TypeHandle;
			if ((object)typeHandle != (object)vector2Type)
			{
				if ((object)typeHandle != (object)vector3Type)
				{
					if ((object)typeHandle != (object)vector4Type)
					{
						if ((object)typeHandle != (object)colorType)
						{
							if ((object)typeHandle != (object)color32Type)
							{
								if ((object)typeHandle != (object)rectType)
								{
									if ((object)typeHandle != (object)boundsType)
									{
										if ((object)typeHandle != (object)quaternionType)
										{
											if ((object)typeHandle != (object)vector2IntType)
											{
												if ((object)typeHandle != (object)vector3IntType)
												{
													if ((object)typeHandle != (object)rangeIntType)
													{
														if ((object)typeHandle != (object)rectIntType)
														{
															if ((object)typeHandle != (object)boundsIntType)
															{
																return null;
															}
															return BoundsInt;
														}
														return RectInt;
													}
													return RangeInt;
												}
												return Vector3Int;
											}
											return Vector2Int;
										}
										return Quaternion;
									}
									return Bounds;
								}
								return Rect;
							}
							return Color32;
						}
						return Color;
					}
					return Vector4;
				}
				return Vector3;
			}
			return Vector2;
		}
		return new NullReferenceException();
	}

	static UnityEqualityComparer()
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected O, but got Unknown
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Expected O, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Expected O, but got Unknown
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Expected O, but got Unknown
		//IL_0429: Unknown result type (might be due to invalid IL or missing references)
		//IL_042e: Expected O, but got Unknown
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Expected O, but got Unknown
		//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Expected O, but got Unknown
		Vector2EqualityComparer vector = new Vector2EqualityComparer();
		Vector2 = vector;
		Vector3EqualityComparer vector2 = new Vector3EqualityComparer();
		Vector3 = vector2;
		Vector4EqualityComparer vector3 = new Vector4EqualityComparer();
		Vector4 = vector3;
		ColorEqualityComparer color = new ColorEqualityComparer();
		Color = color;
		Color32EqualityComparer color2 = new Color32EqualityComparer();
		Color32 = color2;
		RectEqualityComparer rect = new RectEqualityComparer();
		Rect = rect;
		BoundsEqualityComparer bounds = new BoundsEqualityComparer();
		Bounds = bounds;
		QuaternionEqualityComparer quaternion = new QuaternionEqualityComparer();
		Quaternion = quaternion;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj4 = default(object);
		object obj3 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1119 @ rdx_v19+858] (should have been resolved before IL gen)");
		RuntimeTypeHandle runtimeTypeHandle = default(RuntimeTypeHandle);
		vector2Type = runtimeTypeHandle;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj8 = default(object);
		object obj7 = obj8;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1147 @ rdx_v23+858] (should have been resolved before IL gen)");
		RuntimeTypeHandle runtimeTypeHandle2 = default(RuntimeTypeHandle);
		vector3Type = runtimeTypeHandle2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj10 = default(object);
		object obj9 = obj10 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj12 = default(object);
		object obj11 = obj12;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1165 @ rdx_v27+858] (should have been resolved before IL gen)");
		RuntimeTypeHandle runtimeTypeHandle3 = default(RuntimeTypeHandle);
		vector4Type = runtimeTypeHandle3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj14 = default(object);
		object obj13 = obj14 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj16 = default(object);
		object obj15 = obj16;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1183 @ rdx_v31+858] (should have been resolved before IL gen)");
		RuntimeTypeHandle runtimeTypeHandle4 = default(RuntimeTypeHandle);
		colorType = runtimeTypeHandle4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj18 = default(object);
		object obj17 = obj18 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj20 = default(object);
		object obj19 = obj20;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1201 @ rdx_v35+858] (should have been resolved before IL gen)");
		RuntimeTypeHandle runtimeTypeHandle5 = default(RuntimeTypeHandle);
		color32Type = runtimeTypeHandle5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj22 = default(object);
		object obj21 = obj22 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj24 = default(object);
		object obj23 = obj24;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1219 @ rdx_v39+858] (should have been resolved before IL gen)");
		RuntimeTypeHandle runtimeTypeHandle6 = default(RuntimeTypeHandle);
		rectType = runtimeTypeHandle6;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj26 = default(object);
		object obj25 = obj26 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj28 = default(object);
		object obj27 = obj28;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1237 @ rdx_v43+858] (should have been resolved before IL gen)");
		RuntimeTypeHandle runtimeTypeHandle7 = default(RuntimeTypeHandle);
		boundsType = runtimeTypeHandle7;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj30 = default(object);
		object obj29 = obj30 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj32 = default(object);
		object obj31 = obj32;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1255 @ rdx_v47+858] (should have been resolved before IL gen)");
		RuntimeTypeHandle runtimeTypeHandle8 = default(RuntimeTypeHandle);
		quaternionType = runtimeTypeHandle8;
		Vector2IntEqualityComparer vector2Int = new Vector2IntEqualityComparer();
		Vector2Int = vector2Int;
		Vector3IntEqualityComparer vector3Int = new Vector3IntEqualityComparer();
		Vector3Int = vector3Int;
		RangeIntEqualityComparer rangeInt = new RangeIntEqualityComparer();
		RangeInt = rangeInt;
		RectIntEqualityComparer rectInt = new RectIntEqualityComparer();
		RectInt = rectInt;
		BoundsIntEqualityComparer boundsInt = new BoundsIntEqualityComparer();
		BoundsInt = boundsInt;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj34 = default(object);
		object obj33 = obj34 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj36 = default(object);
		object obj35 = obj36;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1632 @ rdx_v61+858] (should have been resolved before IL gen)");
		RuntimeTypeHandle runtimeTypeHandle9 = default(RuntimeTypeHandle);
		vector2IntType = runtimeTypeHandle9;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj38 = default(object);
		object obj37 = obj38 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj40 = default(object);
		object obj39 = obj40;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1650 @ rdx_v65+858] (should have been resolved before IL gen)");
		RuntimeTypeHandle runtimeTypeHandle10 = default(RuntimeTypeHandle);
		vector3IntType = runtimeTypeHandle10;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj42 = default(object);
		object obj41 = obj42 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj44 = default(object);
		object obj43 = obj44;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1668 @ rdx_v69+858] (should have been resolved before IL gen)");
		RuntimeTypeHandle runtimeTypeHandle11 = default(RuntimeTypeHandle);
		rangeIntType = runtimeTypeHandle11;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj46 = default(object);
		object obj45 = obj46 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj48 = default(object);
		object obj47 = obj48;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1686 @ rdx_v73+858] (should have been resolved before IL gen)");
		RuntimeTypeHandle runtimeTypeHandle12 = default(RuntimeTypeHandle);
		rectIntType = runtimeTypeHandle12;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj50 = default(object);
		object obj49 = obj50 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj52 = default(object);
		object obj51 = obj52;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1704 @ rdx_v77+858] (should have been resolved before IL gen)");
		RuntimeTypeHandle runtimeTypeHandle13 = default(RuntimeTypeHandle);
		boundsIntType = runtimeTypeHandle13;
	}
}
