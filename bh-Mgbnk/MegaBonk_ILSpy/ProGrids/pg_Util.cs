using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace ProGrids;

public static class pg_Util
{
	private abstract class SnapEnabledOverride
	{
		public abstract bool IsEnabled();
	}

	private class SnapIsEnabledOverride : SnapEnabledOverride
	{
		private bool m_SnapIsEnabled;

		public SnapIsEnabledOverride(bool snapIsEnabled)
		{
			m_SnapIsEnabled = snapIsEnabled;
		}

		public override bool IsEnabled()
		{
			return m_SnapIsEnabled;
		}
	}

	private class ConditionalSnapOverride : SnapEnabledOverride
	{
		public Func<bool> m_IsEnabledDelegate;

		public ConditionalSnapOverride(Func<bool> d)
		{
			m_IsEnabledDelegate = d;
		}

		public override bool IsEnabled()
		{
			//IL_0046: Expected I4, but got O
			Func<bool> isEnabledDelegate = m_IsEnabledDelegate;
			if (m_IsEnabledDelegate != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ rax_v1 (System.Func`1<System.Boolean>)+18] (should have been resolved before IL gen)");
				bool result = default(bool);
				return result;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<object, bool> _003C_003E9__26_0;

		public static Func<object, bool> _003C_003E9__26_2;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CSnapIsEnabled_003Eb__26_0(object x)
		{
			//IL_0088: Expected I4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172480]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (x == null)
			{
				return false;
			}
			string text = x.ToString();
			if (text != null)
			{
				return text.Contains("ProGridsNoSnap");
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CSnapIsEnabled_003Eb__26_2(object x)
		{
			//IL_0088: Expected I4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172481]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (x == null)
			{
				return false;
			}
			string text = x.ToString();
			if (text != null)
			{
				return text.Contains("ProGridsConditionalSnap");
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public string valid;

		internal bool _003CColorWithString_003Eb__0(char c)
		{
			//IL_0045: Expected I4, but got O
			if (valid != null)
			{
				return valid.Contains(c);
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public Component c;

		public MethodInfo mi;

		internal bool _003CSnapIsEnabled_003Eb__1()
		{
			//IL_005c: Expected O, but got I4
			//IL_007a: Expected O, but got I
			//IL_0082: Expected I, but got O
			//IL_00b6: Expected O, but got I4
			//IL_00d3: Expected I4, but got O
			if ((object)mi != null)
			{
				object obj = mi.Invoke(c, null);
				bool flag = obj == null;
				object[] array = null;
				_003C_003Ec__DisplayClass26_0 obj2 = (_003C_003Ec__DisplayClass26_0)(object)mi;
				object obj3 = 0;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B08]");
					array = (object[])0;
					nint num = (nint)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rdx_v5 (Il2CppClass<System.Object>)+40]");
					bool flag2 = 0 != (nint)array[4];
					obj2 = (_003C_003Ec__DisplayClass26_0)obj;
					obj3 = 0;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
						object obj4 = default(object);
						return (byte)(int)obj4 != 0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
					bool result = default(bool);
					return result;
				}
			}
			throw new NullReferenceException();
		}

		internal bool _003CSnapIsEnabled_003Eb__3()
		{
			//IL_005c: Expected O, but got I4
			//IL_007a: Expected O, but got I
			//IL_0082: Expected I, but got O
			//IL_00b6: Expected O, but got I4
			//IL_00d3: Expected I4, but got O
			if ((object)mi != null)
			{
				object obj = mi.Invoke(c, null);
				bool flag = obj == null;
				object[] array = null;
				_003C_003Ec__DisplayClass26_0 obj2 = (_003C_003Ec__DisplayClass26_0)(object)mi;
				object obj3 = 0;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B08]");
					array = (object[])0;
					nint num = (nint)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rdx_v5 (Il2CppClass<System.Object>)+40]");
					bool flag2 = 0 != (nint)array[4];
					obj2 = (_003C_003Ec__DisplayClass26_0)obj;
					obj3 = 0;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
						object obj4 = default(object);
						return (byte)(int)obj4 != 0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
					bool result = default(bool);
					return result;
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public string assembly;

		internal bool _003CGetType_003Eb__0(Assembly x)
		{
			//IL_006d: Expected I4, but got O
			if ((object)x != null)
			{
				string fullName = x.FullName;
				if (fullName != null)
				{
					return fullName.Contains(assembly);
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private const float EPSILON = 0.0001f;

	private static Dictionary<Transform, SnapEnabledOverride> m_SnapOverrideCache;

	private static Dictionary<Type, bool> m_NoSnapAttributeTypeCache;

	private static Dictionary<Type, MethodInfo> m_ConditionalSnapAttributeCache;

	public unsafe static Color ColorWithString(string value)
	{
		//IL_01cb: Expected native int or pointer, but got O
		//IL_01d9: Expected native int or pointer, but got O
		//IL_01e7: Expected native int or pointer, but got O
		//IL_0189: Expected native int or pointer, but got O
		//IL_0196: Expected native int or pointer, but got O
		//IL_01a3: Expected native int or pointer, but got O
		//IL_01b0: Expected native int or pointer, but got O
		_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass0_0();
		CS_0024_003C_003E8__locals3.valid = "01234567890.,";
		Func<char, bool> predicate = delegate(char c)
		{
			//IL_0045: Expected I4, but got O
			if (CS_0024_003C_003E8__locals3.valid == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return CS_0024_003C_003E8__locals3.valid.Contains(c);
		};
		IEnumerable<char> source = Enumerable.Where(value, predicate);
		char[] val = Enumerable.ToArray(source);
		string text = ((string)null).CreateString(val);
		string[] array = text.Split(',');
		Color color = default(Color);
		if (array.Length >= 4)
		{
			if (array.Length > 0)
			{
				float r = float.Parse(array[0]);
				if (array.Length > 1)
				{
					float g = float.Parse(array[1]);
					if (array.Length > 2)
					{
						float b = float.Parse(array[2]);
						if (array.Length > 3)
						{
							float a = float.Parse(array[3]);
							((Color*)(nint)color)->r = r;
							((Color*)(nint)color)->g = g;
							((Color*)(nint)color)->b = b;
							((Color*)(nint)color)->a = a;
							return color;
						}
					}
				}
			}
			return (Color)new IndexOutOfRangeException();
		}
		((Color*)(nint)color)->r = 1f;
		((Color*)(nint)color)->b = 1f;
		((Color*)(nint)color)->a = 1f;
		return color;
	}

	private unsafe static Vector3 VectorToMask(Vector3 vec)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_006e: Invalid comparison between O and F4
		//IL_001c: Expected F4, but got I4
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_00a8: Invalid comparison between O and F4
		//IL_0038: Expected F4, but got I4
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		//IL_00e2: Invalid comparison between O and F4
		//IL_0107: Expected native int or pointer, but got O
		//IL_0114: Expected native int or pointer, but got O
		//IL_0121: Expected native int or pointer, but got O
		//IL_0046: Expected F4, but got I4
		float x = vec.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = x & 0;
		float x2 = ((System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon)) ? 0f : 1f);
		float y = vec.y;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj2 = y & 0;
		float y2 = ((System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon)) ? 0f : 1f);
		float z = vec.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj3 = z & 0;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon);
		float z2 = 1f;
		if (!flag)
		{
			z2 = 0f;
		}
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = x2;
		((Vector3*)(nint)vector)->y = y2;
		((Vector3*)(nint)vector)->z = z2;
		return vector;
	}

	private static Axis MaskToAxis(Vector3 vec)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		float x = vec.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = x & 0;
		bool flag = (nint)obj <= 0;
		Axis axis = Axis.None;
		if (!flag)
		{
			axis = Axis.X;
		}
		Axis axis2 = axis | Axis.Y;
		float y = vec.y;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj2 = y & 0;
		if ((nint)obj2 <= 0)
		{
			axis2 = axis;
		}
		Axis result = axis2 | Axis.Z;
		float z = vec.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj3 = z & 0;
		if ((nint)obj3 <= 0)
		{
			result = axis2;
		}
		return result;
	}

	private static Axis BestAxis(Vector3 vec)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		float x = vec.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = x & 0;
		float y = vec.y;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj2 = y & 0;
		float z = vec.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj3 = z & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
		{
			return Axis.X;
		}
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
		Axis result = Axis.Z;
		if (!flag)
		{
			bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
			result = Axis.Z;
			if (!flag2)
			{
				result = Axis.Y;
			}
		}
		return result;
	}

	public static Axis CalcDragAxis(Vector3 movement, Camera cam)
	{
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Expected O, but got Unknown
		//IL_035b: Invalid comparison between O and F4
		//IL_0049: Expected F4, but got I4
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Expected O, but got Unknown
		//IL_0395: Invalid comparison between O and F4
		//IL_0065: Expected F4, but got I4
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Expected O, but got Unknown
		//IL_03cf: Invalid comparison between O and F4
		//IL_0073: Expected F4, but got I4
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0495: Unknown result type (might be due to invalid IL or missing references)
		//IL_049a: Expected O, but got Unknown
		//IL_04b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bd: Expected O, but got Unknown
		//IL_03fa: Expected I, but got O
		//IL_0ab6: Expected O, but got I4
		//IL_0abe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac3: Expected O, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_04e8: Expected O, but got I4
		//IL_0455: Unknown result type (might be due to invalid IL or missing references)
		//IL_045a: Expected O, but got Unknown
		//IL_0a26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2b: Expected O, but got Unknown
		//IL_0333: Expected I4, but got O
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected O, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		//IL_0851: Expected I, but got O
		//IL_08dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e1: Expected O, but got Unknown
		//IL_06cf: Expected I, but got O
		//IL_075a: Unknown result type (might be due to invalid IL or missing references)
		//IL_075f: Expected O, but got Unknown
		//IL_0919: Expected I, but got O
		//IL_09a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a9: Expected O, but got Unknown
		//IL_0797: Expected I, but got O
		//IL_0822: Unknown result type (might be due to invalid IL or missing references)
		//IL_0827: Expected O, but got Unknown
		//IL_0504: Expected I, but got O
		//IL_058f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0594: Expected O, but got Unknown
		//IL_05cc: Expected I, but got O
		//IL_0657: Unknown result type (might be due to invalid IL or missing references)
		//IL_065c: Expected O, but got Unknown
		//IL_06a9: Expected O, but got I4
		//IL_06b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b7: Expected I4, but got Unknown
		float x = movement.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = x & 0;
		float num = ((System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon)) ? 0f : 1f);
		float y = movement.y;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj2 = y & 0;
		float num2 = ((System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon)) ? 0f : 1f);
		float z = movement.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj3 = z & 0;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon);
		float num3 = 1f;
		if (!flag)
		{
			num3 = 0f;
		}
		float num4 = num2 + num;
		float num5 = num4 + num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001803D4825h\"");
		Axis result;
		if (num5 != 2f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj4 = num & 0;
			bool flag2 = (nint)obj4 <= 0;
			Axis axis = Axis.None;
			if (!flag2)
			{
				axis = Axis.X;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj5 = num2 & 0;
			Axis axis2 = axis | Axis.Y;
			float num6 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj6 = num6 & 0;
			if ((nint)obj5 <= 0)
			{
				axis2 = axis;
			}
			object obj7 = obj6 ^ obj6;
			object obj8 = obj6 & obj7;
			bool flag3 = (nint)obj8 < 0;
			bool flag4 = (nint)obj6 < 0;
			bool flag5 = obj6 == null;
			bool flag6 = flag4 == flag3;
			object obj9 = !flag6;
			object obj10 = obj9 | flag5;
			if (obj10 == null)
			{
				axis2 |= Axis.Z;
			}
			object obj11 = axis2 - 1;
			if (!flag5)
			{
				object obj12 = obj11 - 1;
				if (!flag5)
				{
					object obj13 = obj12 - 1;
					if (flag5 || (nint)obj13 != 1)
					{
						result = Axis.None;
						goto IL_06bc;
					}
					if ((object)cam != null)
					{
						Transform transform = cam.transform;
						if ((object)transform != null)
						{
							Vector3 forward = transform.forward;
							nint num7 = (nint)typeof(Vector3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v670 @ rax_v41 (Il2CppClass<UnityEngine.Vector3>)+B8]");
							nint num8 = 0;
							float num9 = forward.y;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v671 @ rcx_v39 (Il2CppStaticFields<UnityEngine.Vector3>)+40]");
							float num10 = num9 * 0f;
							float num11 = forward.x * (float)Vector3.rightVector;
							float num12 = forward.z;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v671 @ rcx_v39 (Il2CppStaticFields<UnityEngine.Vector3>)+44]");
							float num13 = num12 * 0f;
							float num14 = num10 + num11;
							float num15 = num14 + num13;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
							object obj14 = num15 & 0;
							Transform transform2 = cam.transform;
							if ((object)transform2 != null)
							{
								Vector3 forward2 = transform2.forward;
								nint num16 = (nint)typeof(Vector3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v748 @ rax_v45 (Il2CppClass<UnityEngine.Vector3>)+B8]");
								nint num17 = 0;
								float num18 = forward2.y;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rcx_v43 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
								float num19 = num18 * 0f;
								float num20 = forward2.x * (float)Vector3.upVector;
								float num21 = forward2.z;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rcx_v43 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
								float num22 = num21 * 0f;
								float num23 = num19 + num20;
								float num24 = num23 + num22;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
								object obj15 = num24 & 0;
								bool flag7 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14);
								object obj16 = obj15 - obj14;
								bool flag8 = obj16 == null;
								bool flag9 = !flag7;
								bool flag10 = !flag8;
								object obj17 = flag10 & flag9;
								result = (Axis)(obj17 + 1);
								goto IL_06bc;
							}
						}
					}
				}
				else if ((object)cam != null)
				{
					Transform transform3 = cam.transform;
					if ((object)transform3 != null)
					{
						Vector3 forward3 = transform3.forward;
						nint num25 = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rax_v28 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num26 = 0;
						float num27 = forward3.y;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rcx_v28 (Il2CppStaticFields<UnityEngine.Vector3>)+40]");
						float num28 = num27 * 0f;
						float num29 = forward3.x * (float)Vector3.rightVector;
						float num30 = forward3.z;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rcx_v28 (Il2CppStaticFields<UnityEngine.Vector3>)+44]");
						float num31 = num30 * 0f;
						float num32 = num28 + num29;
						float num33 = num32 + num31;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
						object obj18 = num33 & 0;
						Transform transform4 = cam.transform;
						if ((object)transform4 != null)
						{
							Vector3 forward4 = transform4.forward;
							nint num34 = (nint)typeof(Vector3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v723 @ rax_v32 (Il2CppClass<UnityEngine.Vector3>)+B8]");
							nint num35 = 0;
							float num36 = forward4.y;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rcx_v32 (Il2CppStaticFields<UnityEngine.Vector3>)+4C]");
							float num37 = num36 * 0f;
							float num38 = forward4.x * (float)Vector3.forwardVector;
							float num39 = forward4.z;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rcx_v32 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
							float num40 = num39 * 0f;
							float num41 = num37 + num38;
							float num42 = num41 + num40;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
							object obj19 = num42 & 0;
							result = ((System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj19) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj18)) ? Axis.X : Axis.Z);
							goto IL_06bc;
						}
					}
				}
			}
			else if ((object)cam != null)
			{
				Transform transform5 = cam.transform;
				if ((object)transform5 != null)
				{
					Vector3 forward5 = transform5.forward;
					nint num43 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v634 @ rax_v15 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num44 = 0;
					float num45 = forward5.y;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ rcx_v16 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
					float num46 = num45 * 0f;
					float num47 = forward5.x * (float)Vector3.upVector;
					float num48 = forward5.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ rcx_v16 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
					float num49 = num48 * 0f;
					float num50 = num46 + num47;
					float num51 = num50 + num49;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
					object obj20 = num51 & 0;
					Transform transform6 = cam.transform;
					if ((object)transform6 != null)
					{
						Vector3 forward6 = transform6.forward;
						nint num52 = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v709 @ rax_v19 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num53 = 0;
						float num54 = forward6.y;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v710 @ rcx_v20 (Il2CppStaticFields<UnityEngine.Vector3>)+4C]");
						float num55 = num54 * 0f;
						float num56 = forward6.x * (float)Vector3.forwardVector;
						float num57 = forward6.z;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v710 @ rcx_v20 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
						float num58 = num57 * 0f;
						float num59 = num55 + num56;
						float num60 = num59 + num58;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
						object obj21 = num60 & 0;
						bool flag11 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj21) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj20);
						result = Axis.Z;
						if (!flag11)
						{
							result = Axis.Y;
						}
						goto IL_06bc;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (Axis)ex;
		}
		nint num61 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rax_v52 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num62 = 0;
		float num63 = (float)Vector3.oneVector - num;
		object obj22 = default(object);
		float num64 = (float)obj22 - num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rcx_v49 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float num65 = 0f - num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj23 = num63 & 0;
		bool flag12 = (nint)obj23 <= 0;
		Axis axis3 = Axis.None;
		if (!flag12)
		{
			axis3 = Axis.X;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj24 = num64 & 0;
		Axis axis4 = axis3 | Axis.Y;
		if ((nint)obj24 <= 0)
		{
			axis4 = axis3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj25 = num65 & 0;
		result = axis4 | Axis.Z;
		if ((nint)obj25 <= 0)
		{
			result = axis4;
		}
		goto IL_06bc;
		IL_06bc:
		return result;
	}

	public static float ValueFromMask(Vector3 val, Vector3 mask)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0023: Invalid comparison between O and F4
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_005a: Invalid comparison between O and F4
		float x = mask.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = x & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.0001f))
		{
			float y = mask.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj2 = y & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.0001f))
			{
				return val.z;
			}
			return val.y;
		}
		return val.x;
	}

	public unsafe static Vector3 SnapValue(Vector3 val, float snapValue)
	{
		//IL_0054: Expected native int or pointer, but got O
		//IL_0061: Expected native int or pointer, but got O
		//IL_006e: Expected native int or pointer, but got O
		float x = Snap(val.x, snapValue);
		float y = Snap(val.y, snapValue);
		float z = Snap(val.z, snapValue);
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = x;
		((Vector3*)(nint)vector)->y = y;
		((Vector3*)(nint)vector)->z = z;
		return vector;
	}

	private unsafe static Type GetType(string type, string assembly = null)
	{
		//IL_0104: Expected O, but got Ref
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass7_0();
		Type result;
		if (CS_0024_003C_003E8__locals4 != null)
		{
			CS_0024_003C_003E8__locals4.assembly = assembly;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802694D0");
			Type type2 = default(Type);
			bool flag = ((object)type2).Equals((object)null);
			bool flag2 = !flag;
			result = type2;
			if (flag2)
			{
				goto IL_027f;
			}
			AppDomain curDomain = AppDomain.getCurDomain();
			if (curDomain != null)
			{
				Assembly[] assemblies = curDomain.GetAssemblies();
				bool flag3 = CS_0024_003C_003E8__locals4.assembly == null;
				Assembly[] array = assemblies;
				if (!flag3)
				{
					Func<Assembly, bool> predicate = delegate(Assembly x)
					{
						//IL_006d: Expected I4, but got O
						if ((object)x != null)
						{
							string fullName = x.FullName;
							if (fullName != null)
							{
								return fullName.Contains(CS_0024_003C_003E8__locals4.assembly);
							}
						}
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					};
					IEnumerable<Assembly> enumerable = Enumerable.Where(assemblies, predicate);
					array = (Assembly[])enumerable;
				}
				if (array != null)
				{
					IEnumerator<Assembly> enumerator = ((IEnumerable<Assembly>)array).GetEnumerator();
					IEnumerator enumerator2 = default(IEnumerator);
					object obj = (object)(&enumerator2);
					result = type2;
					object obj2 = default(object);
					while (true)
					{
						if (enumerator2 != null)
						{
							if (enumerator2.MoveNext())
							{
								if (enumerator2 != null)
								{
									Assembly current = ((IEnumerator<Assembly>)enumerator2).Current;
									if ((object)current != null)
									{
										Type type3 = current.GetType(type);
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805B5BF0");
										bool flag4 = obj2 == null;
										result = type3;
										if (!flag4)
										{
											if (obj != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
											}
											result = type3;
											break;
										}
										continue;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							if (obj != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
							}
							break;
						}
						throw new NullReferenceException();
					}
					goto IL_027f;
				}
			}
		}
		throw new NullReferenceException();
		IL_027f:
		return result;
	}

	public static void SetUnityGridEnabled(bool isEnabled)
	{
		Type type = GetType("UnityEditor.AnnotationUtility");
		PropertyInfo property = type.GetProperty("showGrid", (BindingFlags)40);
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object value = default(object);
		property.SetValue(null, value, (BindingFlags)40, null, null, null);
	}

	public static bool GetUnityGridEnabled()
	{
		//IL_00f2: Expected I4, but got O
		//IL_0055: Expected I, but got O
		//IL_0079: Expected O, but got I
		//IL_0081: Expected I, but got O
		//IL_00bf: Expected I4, but got O
		Type type = GetType("UnityEditor.AnnotationUtility");
		if ((object)type != null)
		{
			PropertyInfo property = type.GetProperty("showGrid", (BindingFlags)40);
			nint num = (nint)property;
			object value = property.GetValue(null, null);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B08]");
			object obj = 0;
			nint num2 = (nint)value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdx_v7 (Il2CppClass<System.Object>)+40]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ r8_v7+40]");
			if (num3 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
				object obj2 = default(object);
				return (byte)(int)obj2 != 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			throw new NullReferenceException();
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe static Vector3 SnapValue(Vector3 val, Vector3 mask, float snapValue)
	{
		//IL_00c6: Expected O, but got I
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0110: Invalid comparison between F4 and O
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_016e: Invalid comparison between F4 and O
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_013f: Invalid comparison between F4 and O
		//IL_018a: Expected native int or pointer, but got O
		//IL_0197: Expected native int or pointer, but got O
		//IL_01a4: Expected native int or pointer, but got O
		//IL_0053: Expected O, but got I
		//IL_0086: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = 0;
		float x = mask.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj2 = x & 0;
		float x2 = val.x;
		float num = val.y;
		float num2 = val.z;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.0001f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
			float num3 = Snap(val.x, snapValue);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			obj = 0;
			x2 = num3;
		}
		object obj3 = mask.y & obj;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.0001f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
		{
			float num4 = Snap(num, snapValue);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			obj = 0;
			num = num4;
		}
		object obj4 = mask.z & obj;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.0001f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
		{
			float num5 = Snap(num2, snapValue);
			num2 = num5;
		}
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = x2;
		((Vector3*)(nint)vector)->y = num;
		((Vector3*)(nint)vector)->z = num2;
		return vector;
	}

	public unsafe static Vector3 SnapToCeil(Vector3 val, Vector3 mask, float snapValue)
	{
		//IL_00f3: Expected O, but got I
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected O, but got Unknown
		//IL_013d: Invalid comparison between F4 and O
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_019b: Invalid comparison between F4 and O
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Expected O, but got Unknown
		//IL_016c: Invalid comparison between F4 and O
		//IL_01b7: Expected native int or pointer, but got O
		//IL_01c4: Expected native int or pointer, but got O
		//IL_01d1: Expected native int or pointer, but got O
		//IL_005b: Expected O, but got I
		//IL_009d: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = 0;
		float x = mask.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj2 = x & 0;
		float x2 = val.x;
		float num = val.y;
		float num2 = val.z;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.0001f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
			float num3 = val.x / snapValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FEB80");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			obj = 0;
			x2 = num3 * snapValue;
		}
		object obj3 = mask.y & obj;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.0001f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
		{
			float num4 = num / snapValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FEB80");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			obj = 0;
			num = num4 * snapValue;
		}
		object obj4 = mask.z & obj;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.0001f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
		{
			float num5 = num2 / snapValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FEB80");
			num2 = num5 * snapValue;
		}
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = x2;
		((Vector3*)(nint)vector)->y = num;
		((Vector3*)(nint)vector)->z = num2;
		return vector;
	}

	public unsafe static Vector3 SnapToFloor(Vector3 val, float snapValue)
	{
		//IL_004e: Expected native int or pointer, but got O
		//IL_008d: Expected native int or pointer, but got O
		//IL_00b3: Expected native int or pointer, but got O
		float num = val.x / snapValue;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
		float x = num * snapValue;
		float num2 = val.y / snapValue;
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = x;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
		float y = num2 * snapValue;
		float num3 = val.z / snapValue;
		((Vector3*)(nint)vector)->y = y;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
		float z = num3 * snapValue;
		((Vector3*)(nint)vector)->z = z;
		return vector;
	}

	public unsafe static Vector3 SnapToFloor(Vector3 val, Vector3 mask, float snapValue)
	{
		//IL_00f3: Expected O, but got I
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected O, but got Unknown
		//IL_013d: Invalid comparison between F4 and O
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_019b: Invalid comparison between F4 and O
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Expected O, but got Unknown
		//IL_016c: Invalid comparison between F4 and O
		//IL_01b7: Expected native int or pointer, but got O
		//IL_01c4: Expected native int or pointer, but got O
		//IL_01d1: Expected native int or pointer, but got O
		//IL_005b: Expected O, but got I
		//IL_009d: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = 0;
		float x = mask.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj2 = x & 0;
		float x2 = val.x;
		float num = val.y;
		float num2 = val.z;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.0001f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
			float num3 = val.x / snapValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			obj = 0;
			x2 = num3 * snapValue;
		}
		object obj3 = mask.y & obj;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.0001f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
		{
			float num4 = num / snapValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			obj = 0;
			num = num4 * snapValue;
		}
		object obj4 = mask.z & obj;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.0001f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
		{
			float num5 = num2 / snapValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
			num2 = num5 * snapValue;
		}
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = x2;
		((Vector3*)(nint)vector)->y = num;
		((Vector3*)(nint)vector)->z = num2;
		return vector;
	}

	public static float Snap(float val, float round)
	{
		//IL_0022: Invalid comparison between F4 and I4
		//IL_0120: Invalid comparison between F4 and I4
		//IL_005d: Invalid comparison between F4 and I4
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		float num = val / round;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
		float num3 = default(float);
		float num4;
		if (!(num < 0f))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FD990");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [18262EC90h]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001803D644Fh\"");
			if (num != 0f)
			{
				float num2 = num + 0.5f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
				return num2 * round;
			}
			object obj = num3 & 1;
			bool flag = obj == null;
			num4 = num3;
			if (!flag)
			{
				float num5 = num3 + 1f;
				return num5 * round;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FD990");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [18262ED10h]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001803D64B1h\"");
			if (num == 0f)
			{
				object obj2 = num3 & 1;
				bool flag2 = obj2 == null;
				num4 = num3;
				if (!flag2)
				{
					float num6 = num3 - 1f;
					return num6 * round;
				}
			}
			else
			{
				float num7 = num - 0.5f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FEB80");
				num4 = num7;
			}
		}
		return num4 * round;
	}

	public static float SnapToFloor(float val, float snapValue)
	{
		float num = val / snapValue;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
		return num * snapValue;
	}

	public static float SnapToCeil(float val, float snapValue)
	{
		float num = val / snapValue;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FEB80");
		return num * snapValue;
	}

	public unsafe static Vector3 CeilFloor(Vector3 v)
	{
		//IL_000e: Invalid comparison between I4 and F4
		//IL_0021: Expected F4, but got I8
		//IL_0061: Expected native int or pointer, but got O
		//IL_0074: Invalid comparison between I4 and F4
		//IL_0087: Expected F4, but got I8
		//IL_00d3: Expected native int or pointer, but got O
		//IL_00e6: Invalid comparison between I4 and F4
		//IL_00f9: Expected F4, but got I8
		//IL_0038: Expected F4, but got I4
		//IL_009d: Expected native int or pointer, but got O
		//IL_00af: Expected native int or pointer, but got O
		//IL_00c1: Expected native int or pointer, but got O
		//IL_0046: Expected F4, but got I4
		//IL_0054: Expected F4, but got I4
		bool flag = 0f > v.x;
		float x = 4.2949673E+09f;
		if (!flag)
		{
			x = 1f;
		}
		((Vector3*)(nint)v)->x = x;
		bool flag2 = 0f > v.y;
		float y = 4.2949673E+09f;
		if (!flag2)
		{
			y = 1f;
		}
		((Vector3*)(nint)v)->y = y;
		bool flag3 = 0f > v.z;
		float z = 4.2949673E+09f;
		if (!flag3)
		{
			z = 1f;
		}
		((Vector3*)(nint)v)->z = z;
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = v.x;
		((Vector3*)(nint)vector)->z = v.z;
		return vector;
	}

	public static void ClearSnapEnabledCache()
	{
		m_SnapOverrideCache.Clear();
	}

	public unsafe static bool SnapIsEnabled(Transform t)
	{
		//IL_0708: Expected O, but got I
		//IL_070c: Expected I4, but got O
		//IL_009c: Expected O, but got I4
		//IL_00b3: Expected O, but got I4
		//IL_0730: Expected I4, but got O
		//IL_0140: Expected I, but got O
		//IL_0174: Expected I, but got O
		//IL_0521: Unknown result type (might be due to invalid IL or missing references)
		//IL_0526: Expected O, but got Unknown
		//IL_0745: Expected I, but got O
		//IL_01f5: Expected I, but got O
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected Ref, but got Unknown
		//IL_0509: Expected I, but got O
		//IL_054b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0550: Expected O, but got Unknown
		//IL_05b5: Expected I, but got O
		//IL_0601: Expected I, but got O
		//IL_02da: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Expected O, but got Unknown
		//IL_02e4: Expected I, but got O
		//IL_0635: Expected I, but got O
		//IL_065b: Expected I, but got O
		//IL_0951: Expected O, but got I
		//IL_0385: Expected I, but got O
		//IL_0694: Expected I4, but got O
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Expected O, but got Unknown
		//IL_0416: Expected I, but got O
		//IL_0462: Expected I, but got O
		//IL_0496: Expected I, but got O
		//IL_0913: Expected O, but got I
		//IL_04db: Expected I, but got O
		Dictionary<object, object> snapOverrideCache = (Dictionary<object, object>)(object)m_SnapOverrideCache;
		if (m_SnapOverrideCache != null)
		{
			if (!((Dictionary<object, object>)(object)m_SnapOverrideCache).TryGetValue((object)t, out object value))
			{
				bool flag = (object)t == null;
				nint num = (nint)(&value);
				if (!flag)
				{
					MonoBehaviour[] components = t.GetComponents<MonoBehaviour>();
					bool flag2 = components == null;
					num = (nint)(&value);
					snapOverrideCache = (Dictionary<object, object>)(object)t;
					if (!flag2)
					{
						bool value2 = false;
						object obj = 0;
						IEnumerable<object> enumerable = null;
						num = (nint)(&value);
						object obj2 = 0;
						object obj3 = default(object);
						IEnumerable<object> enumerable2 = default(IEnumerable<object>);
						object obj4 = default(object);
						object obj6 = default(object);
						object obj8 = default(object);
						while (true)
						{
							object value3;
							Dictionary<object, object> snapOverrideCache2;
							if ((nint)obj2 < components.Length)
							{
								_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals27 = new _003C_003Ec__DisplayClass26_0();
								if ((nint)obj < components.Length)
								{
									bool flag3 = CS_0024_003C_003E8__locals27 == null;
									snapOverrideCache = (Dictionary<object, object>)(object)CS_0024_003C_003E8__locals27;
									if (flag3)
									{
										break;
									}
									CS_0024_003C_003E8__locals27.c = components[obj];
									bool flag4 = CS_0024_003C_003E8__locals27.c != null;
									num = unchecked((nint)null);
									if (!flag4)
									{
										goto IL_0518;
									}
									snapOverrideCache = (Dictionary<object, object>)(object)CS_0024_003C_003E8__locals27.c;
									bool flag5 = (object)CS_0024_003C_003E8__locals27.c == null;
									num = unchecked((nint)null);
									if (flag5)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_is_inst\"");
									bool flag6 = m_NoSnapAttributeTypeCache == null;
									num = unchecked((nint)null);
									snapOverrideCache = (Dictionary<object, object>)(object)m_NoSnapAttributeTypeCache;
									if (flag6)
									{
										break;
									}
									bool flag7 = ((Dictionary<object, bool>)(object)m_NoSnapAttributeTypeCache).TryGetValue(obj3, out value2);
									num = (nint)(&value2);
									if (!flag7)
									{
										bool flag8 = obj3 == null;
										num = (nint)(&value2);
										snapOverrideCache = (Dictionary<object, object>)(object)m_NoSnapAttributeTypeCache;
										if (flag8)
										{
											break;
										}
										nint num2 = (nint)obj3;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v897 @ rax_v107 (Il2CppClass<System.Object>)+208] (should have been resolved before IL gen)");
										Func<object, bool> predicate = _003C_003Ec._003C_003E9__26_0;
										if (_003C_003Ec._003C_003E9__26_0 == null)
										{
											predicate = (_003C_003Ec._003C_003E9__26_0 = delegate(object x)
											{
												//IL_0088: Expected I4, but got O
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172480]");
												if ((nint)0 == 0)
												{
													_ = 1;
												}
												if (x == null)
												{
													return false;
												}
												string text = x.ToString();
												if (text == null)
												{
													NullReferenceException ex2 = new NullReferenceException();
													return (byte)(int)ex2 != 0;
												}
												return text.Contains("ProGridsNoSnap");
											});
										}
										bool flag9 = Enumerable.Any(enumerable2, predicate);
										bool flag10 = m_NoSnapAttributeTypeCache == null;
										num = (flag9 ? 1 : 0);
										snapOverrideCache = (Dictionary<object, object>)(object)m_NoSnapAttributeTypeCache;
										if (flag10)
										{
											break;
										}
										((Dictionary<object, bool>)(object)m_NoSnapAttributeTypeCache).Add(obj3, flag9);
										value2 = flag9;
										enumerable = enumerable2;
										num = (flag9 ? 1 : 0);
									}
									if (value2)
									{
										SnapIsEnabledOverride snapIsEnabledOverride = new SnapIsEnabledOverride(snapIsEnabled: false);
										bool snapIsEnabled = !value2;
										snapIsEnabledOverride.m_SnapIsEnabled = snapIsEnabled;
										bool flag11 = m_SnapOverrideCache == null;
										snapOverrideCache = (Dictionary<object, object>)(object)snapIsEnabledOverride;
										if (flag11)
										{
											break;
										}
										value3 = snapIsEnabledOverride;
										snapOverrideCache2 = (Dictionary<object, object>)(object)m_SnapOverrideCache;
										goto IL_09f4;
									}
									snapOverrideCache = (Dictionary<object, object>)(object)m_ConditionalSnapAttributeCache;
									if (m_ConditionalSnapAttributeCache == null)
									{
										break;
									}
									if (((Dictionary<object, object>)(object)m_ConditionalSnapAttributeCache).TryGetValue(obj3, out *(object*)(CS_0024_003C_003E8__locals27 + 24)))
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1813EC3D0");
										bool flag12 = obj4 != null;
										num = unchecked((nint)null);
										if (!flag12)
										{
											goto IL_0518;
										}
										Func<bool> isEnabledDelegate = delegate
										{
											//IL_005c: Expected O, but got I4
											//IL_007a: Expected O, but got I
											//IL_0082: Expected I, but got O
											//IL_00b6: Expected O, but got I4
											//IL_00d3: Expected I4, but got O
											if ((object)CS_0024_003C_003E8__locals27.mi != null)
											{
												object obj9 = CS_0024_003C_003E8__locals27.mi.Invoke(CS_0024_003C_003E8__locals27.c, null);
												bool flag29 = obj9 == null;
												object[] array = null;
												_003C_003Ec__DisplayClass26_0 mi = (_003C_003Ec__DisplayClass26_0)(object)CS_0024_003C_003E8__locals27.mi;
												object obj10 = 0;
												if (!flag29)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B08]");
													array = (object[])0;
													nint num8 = (nint)obj9;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rdx_v5 (Il2CppClass<System.Object>)+40]");
													bool flag30 = 0 != (nint)array[4];
													mi = (_003C_003Ec__DisplayClass26_0)obj9;
													obj10 = 0;
													if (!flag30)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
														object obj11 = default(object);
														return (byte)(int)obj11 != 0;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
													bool result = default(bool);
													return result;
												}
											}
											throw new NullReferenceException();
										};
										ConditionalSnapOverride conditionalSnapOverride = new ConditionalSnapOverride(null);
										conditionalSnapOverride._002Ector(null);
										snapOverrideCache = (Dictionary<object, object>)(conditionalSnapOverride + 16);
										conditionalSnapOverride.m_IsEnabledDelegate = isEnabledDelegate;
										bool flag13 = m_SnapOverrideCache == null;
										num = 0;
										if (flag13)
										{
											break;
										}
										((Dictionary<object, object>)(object)m_SnapOverrideCache).Add((object)t, (object)conditionalSnapOverride);
										bool flag14 = (object)CS_0024_003C_003E8__locals27.mi == null;
										num = (nint)conditionalSnapOverride;
										snapOverrideCache = (Dictionary<object, object>)(object)CS_0024_003C_003E8__locals27.mi;
										if (flag14)
										{
											break;
										}
										object obj5 = CS_0024_003C_003E8__locals27.mi.Invoke(CS_0024_003C_003E8__locals27.c, null);
										bool flag15 = obj5 == null;
										num = unchecked((nint)null);
										snapOverrideCache = (Dictionary<object, object>)(object)CS_0024_003C_003E8__locals27.mi;
										if (flag15)
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B08]");
										nint num3 = 0;
										nint num4 = (nint)obj5;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v511 @ rdx_v25 (Il2CppClass<System.Object>)+40]");
										nint num5 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ r8_v16 (Il2CppMethodInfo)+40]");
										bool flag16 = num5 != 0;
										nint num6 = unchecked((nint)null);
										Dictionary<object, object> dictionary = (Dictionary<object, object>)obj5;
										num = num3;
										snapOverrideCache = (Dictionary<object, object>)obj5;
										if (!flag16)
										{
											goto IL_0682;
										}
									}
									else
									{
										Func<object, bool> predicate = _003C_003Ec._003C_003E9__26_2;
										if (_003C_003Ec._003C_003E9__26_2 == null)
										{
											predicate = (_003C_003Ec._003C_003E9__26_2 = delegate(object x)
											{
												//IL_0088: Expected I4, but got O
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172481]");
												if ((nint)0 == 0)
												{
													_ = 1;
												}
												if (x == null)
												{
													return false;
												}
												string text = x.ToString();
												if (text == null)
												{
													NullReferenceException ex2 = new NullReferenceException();
													return (byte)(int)ex2 != 0;
												}
												return text.Contains("ProGridsConditionalSnap");
											});
										}
										if (!Enumerable.Any(enumerable, predicate))
										{
											bool flag17 = m_ConditionalSnapAttributeCache == null;
											num = 0;
											snapOverrideCache = (Dictionary<object, object>)(object)m_ConditionalSnapAttributeCache;
											if (flag17)
											{
												break;
											}
											((Dictionary<object, object>)(object)m_ConditionalSnapAttributeCache).Add(obj3, (object)null);
											obj++;
											num = unchecked((nint)null);
											obj2 = obj;
											continue;
										}
										bool flag18 = obj3 == null;
										num = 0;
										snapOverrideCache = (Dictionary<object, object>)enumerable;
										if (flag18)
										{
											break;
										}
										MethodInfo method = ((Type)obj3).GetMethod("IsSnapEnabled", (BindingFlags)116);
										CS_0024_003C_003E8__locals27.mi = method;
										bool flag19 = m_ConditionalSnapAttributeCache == null;
										num = 116;
										snapOverrideCache = (Dictionary<object, object>)(object)m_ConditionalSnapAttributeCache;
										if (flag19)
										{
											break;
										}
										((Dictionary<object, object>)(object)m_ConditionalSnapAttributeCache).Add(obj3, (object)CS_0024_003C_003E8__locals27.mi);
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1813EC3D0");
										bool flag20 = obj6 == null;
										num = unchecked((nint)null);
										if (flag20)
										{
											goto IL_0518;
										}
										Func<bool> isEnabledDelegate2 = delegate
										{
											//IL_005c: Expected O, but got I4
											//IL_007a: Expected O, but got I
											//IL_0082: Expected I, but got O
											//IL_00b6: Expected O, but got I4
											//IL_00d3: Expected I4, but got O
											if ((object)CS_0024_003C_003E8__locals27.mi != null)
											{
												object obj9 = CS_0024_003C_003E8__locals27.mi.Invoke(CS_0024_003C_003E8__locals27.c, null);
												bool flag29 = obj9 == null;
												object[] array = null;
												_003C_003Ec__DisplayClass26_0 mi = (_003C_003Ec__DisplayClass26_0)(object)CS_0024_003C_003E8__locals27.mi;
												object obj10 = 0;
												if (!flag29)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B08]");
													array = (object[])0;
													nint num8 = (nint)obj9;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rdx_v5 (Il2CppClass<System.Object>)+40]");
													bool flag30 = 0 != (nint)array[4];
													mi = (_003C_003Ec__DisplayClass26_0)obj9;
													obj10 = 0;
													if (!flag30)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
														object obj11 = default(object);
														return (byte)(int)obj11 != 0;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
													bool result = default(bool);
													return result;
												}
											}
											throw new NullReferenceException();
										};
										ConditionalSnapOverride conditionalSnapOverride2 = new ConditionalSnapOverride(null);
										conditionalSnapOverride2._002Ector(null);
										snapOverrideCache = (Dictionary<object, object>)(conditionalSnapOverride2 + 16);
										conditionalSnapOverride2.m_IsEnabledDelegate = isEnabledDelegate2;
										bool flag21 = m_SnapOverrideCache == null;
										num = 0;
										if (flag21)
										{
											break;
										}
										((Dictionary<object, object>)(object)m_SnapOverrideCache).Add((object)t, (object)conditionalSnapOverride2);
										bool flag22 = (object)CS_0024_003C_003E8__locals27.mi == null;
										num = (nint)conditionalSnapOverride2;
										snapOverrideCache = (Dictionary<object, object>)(object)CS_0024_003C_003E8__locals27.mi;
										if (flag22)
										{
											break;
										}
										object obj7 = CS_0024_003C_003E8__locals27.mi.Invoke(CS_0024_003C_003E8__locals27.c, null);
										bool flag23 = obj7 == null;
										num = unchecked((nint)null);
										snapOverrideCache = (Dictionary<object, object>)(object)CS_0024_003C_003E8__locals27.mi;
										if (flag23)
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B08]");
										num = 0;
										nint num4 = (nint)obj7;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v511 @ rdx_v25 (Il2CppClass<System.Object>)+40]");
										nint num7 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ r8_v1 (Il2CppMethodInfo)+40]");
										bool flag24 = num7 != 0;
										snapOverrideCache = (Dictionary<object, object>)obj7;
										if (!flag24)
										{
											nint num3 = num;
											nint num6 = unchecked((nint)null);
											Dictionary<object, object> dictionary = (Dictionary<object, object>)obj7;
											goto IL_0682;
										}
										bool flag25 = ((Dictionary<Transform, SnapEnabledOverride>)(object)snapOverrideCache).TryGetValue((Transform)num, out *(SnapEnabledOverride*)num);
									}
									bool flag26 = ((Dictionary<Transform, SnapEnabledOverride>)(object)snapOverrideCache).TryGetValue((Transform)num, out *(SnapEnabledOverride*)num);
								}
								IndexOutOfRangeException ex = new IndexOutOfRangeException();
								return (byte)(int)ex != 0;
							}
							SnapIsEnabledOverride snapIsEnabledOverride2 = new SnapIsEnabledOverride(snapIsEnabled: false);
							snapIsEnabledOverride2.m_SnapIsEnabled = true;
							bool flag27 = m_SnapOverrideCache == null;
							snapOverrideCache = (Dictionary<object, object>)(object)snapIsEnabledOverride2;
							if (flag27)
							{
								break;
							}
							value3 = snapIsEnabledOverride2;
							snapOverrideCache2 = (Dictionary<object, object>)(object)m_SnapOverrideCache;
							goto IL_09f4;
							IL_09f4:
							snapOverrideCache2.Add(t, value3);
							return true;
							IL_0518:
							obj++;
							obj2 = obj;
							continue;
							IL_0682:
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
							return (byte)(int)obj8 != 0;
						}
					}
				}
			}
			else
			{
				bool flag28 = value == null;
				nint num = (nint)(&value);
				snapOverrideCache = (Dictionary<object, object>)value;
				if (!flag28)
				{
					return (byte)(int)((Dictionary<TKey, TValue>)value).get_Item((TKey)0) != 0;
				}
			}
		}
		throw new NullReferenceException();
	}

	static pg_Util()
	{
		Dictionary<Transform, SnapEnabledOverride> snapOverrideCache = new Dictionary<Transform, SnapEnabledOverride>();
		m_SnapOverrideCache = snapOverrideCache;
		Dictionary<Type, bool> noSnapAttributeTypeCache = new Dictionary<Type, bool>();
		m_NoSnapAttributeTypeCache = noSnapAttributeTypeCache;
		Dictionary<Type, MethodInfo> conditionalSnapAttributeCache = new Dictionary<Type, MethodInfo>();
		m_ConditionalSnapAttributeCache = conditionalSnapAttributeCache;
	}
}
