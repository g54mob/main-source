using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace VampireSurvivors;

public static class EnumCache
{
	private static Dictionary<Type, SerializationType> enumSerializationTypeCache;

	public unsafe static SerializationType GetSerializationTypeForEnum(Type enumType)
	{
		//IL_03f4: Expected O, but got I
		//IL_05dc: Expected I4, but got O
		//IL_044f: Expected O, but got I4
		//IL_0457: Unknown result type (might be due to invalid IL or missing references)
		//IL_045c: Expected O, but got Unknown
		//IL_00a3: Expected O, but got I8
		//IL_00b0: Expected O, but got I8
		//IL_028e: Expected O, but got Ref
		//IL_02b7: Expected O, but got Ref
		//IL_02bf: Expected O, but got I
		//IL_00fa: Expected I, but got O
		//IL_0110: Expected O, but got I
		//IL_01a3: Expected O, but got I4
		//IL_0576: Expected O, but got I
		//IL_0148: Expected O, but got I
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Expected O, but got Unknown
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Expected O, but got Unknown
		//IL_03a3: Expected O, but got I4
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Expected I4, but got Unknown
		//IL_04e3: Expected O, but got I4
		//IL_01b0: Expected O, but got I
		//IL_0242: Expected O, but got I4
		//IL_0258: Expected O, but got I
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Expected O, but got Unknown
		//IL_0611: Expected I, but got O
		//IL_021b: Expected O, but got I
		//IL_0230: Expected O, but got I
		Dictionary<Type, SerializationType> dictionary = enumSerializationTypeCache;
		if (enumSerializationTypeCache != null)
		{
			int num = enumSerializationTypeCache.FindEntry(enumType);
			if (num < 0)
			{
				if ((object)enumType == null)
				{
					ArgumentNullException ex = new ArgumentNullException("enumType");
					ex._002Ector("enumType");
					throw ex;
				}
				Array enumValues = enumType.GetEnumValues();
				if (enumValues != null)
				{
					IEnumerator enumerator = enumValues.GetEnumerator();
					object obj = -9223372036854775808L;
					object obj2 = 9223372036854775807L;
					IntPtr intPtr = default(IntPtr);
					IntPtr intPtr2 = default(IntPtr);
					object obj15 = default(object);
					while (true)
					{
						object obj10;
						object obj4;
						if (intPtr != (IntPtr)0)
						{
							if (((Dictionary<Type, SerializationType>)null).FindEntry(typeof(IEnumerator)) == 0)
							{
								break;
							}
							bool flag = intPtr == (IntPtr)0;
							nint num2 = unchecked((nint)null);
							if (!flag)
							{
								object obj3 = (nint)intPtr;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ r10_v9+12E]");
								if ((nint)0 >= (nint)0)
								{
									goto IL_0188;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ r10_v9+B0]");
								obj4 = 0;
								System.Int32Enum int32Enum = (System.Int32Enum)0;
								while (true)
								{
									object obj5 = (int)int32Enum + (int)int32Enum;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v714 @ r8_v17+v632 @ rax_v57*8]");
									if (0 == (nint)typeof(IEnumerator))
									{
										break;
									}
									int32Enum++;
									System.Int32Enum num3 = int32Enum;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ r10_v9+12E]");
									if ((nint)num3 < (nint)0)
									{
										continue;
									}
									goto IL_0188;
								}
								object obj6 = (int)int32Enum + (int)int32Enum;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v714 @ r8_v17+8+v706 @ rcx_v43*8]");
								object obj7 = (nint)0 + (nint)1;
								object obj8 = obj7 << 4;
								object obj9 = obj8 + 312;
								obj10 = obj9 + obj3;
								goto IL_055c;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
						IL_055c:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v713 @ rdx_v24] (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEB8]");
						object obj11 = 0;
						if (intPtr2 != (IntPtr)0)
						{
							object obj12 = (nint)intPtr2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rcx_v37+40]");
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rdx_v26+40]");
							if (num4 == 0)
							{
								object obj13 = obj2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rax_v49 (Il2CppMethodInfo)+10]");
								if ((nint)obj13 > 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rax_v49 (Il2CppMethodInfo)+10]");
									obj2 = 0;
								}
								object obj14 = obj;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rax_v49 (Il2CppMethodInfo)+10]");
								if ((nint)obj14 < 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rax_v49 (Il2CppMethodInfo)+10]");
									obj = 0;
								}
								nint num2 = (nint)typeof(Math);
								continue;
							}
							throw new InvalidCastException();
						}
						throw new NullReferenceException();
						IL_0188:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
						obj10 = obj15;
						obj4 = 1;
						goto IL_055c;
					}
					object obj16 = (object)(&intPtr);
					nint num5 = ((Dictionary<Type, SerializationType>)obj16).FindEntry(typeof(IDisposable));
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					object obj17 = (object)(&intPtr);
					obj17 = num5;
					if (num5 != 0)
					{
						int num6 = ((Dictionary<Type, SerializationType>)null).FindEntry(typeof(IDisposable));
					}
					object obj18 = obj - obj2;
					bool flag2 = (nint)obj18 <= 255;
					System.Int32Enum int32Enum2 = (System.Int32Enum)0;
					if (!flag2)
					{
						if ((nint)obj18 > 32767)
						{
							object obj19 = obj18 - 2147483647;
							object obj20 = obj18 ^ 0x7FFFFFFF;
							object obj21 = obj18 ^ obj19;
							object obj22 = obj20 & obj21;
							bool flag3 = (nint)obj22 < 0;
							bool flag4 = (nint)obj19 < 0;
							bool flag5 = obj19 == null;
							bool flag6 = flag4 == flag3;
							bool flag7 = !flag5;
							object obj23 = flag7 & flag6;
							int32Enum2 = (System.Int32Enum)(obj23 + 2);
						}
						else
						{
							int32Enum2 = (System.Int32Enum)1;
						}
					}
					if (enumSerializationTypeCache != null)
					{
						bool flag8 = ((Dictionary<object, System.Int32Enum>)(object)enumSerializationTypeCache).TryInsert((object)enumType, int32Enum2, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
						return (SerializationType)int32Enum2;
					}
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rbx_v1 (System.Collections.Generic.Dictionary`2<System.Type, VampireSurvivors.SerializationType>)+18]");
				object obj24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rbx_v1 (System.Collections.Generic.Dictionary`2<System.Type, VampireSurvivors.SerializationType>)+18]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v19+18]");
					if ((nint)num < (nint)0)
					{
						object obj25 = num * 2;
						object obj26 = num + obj25;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v19+30+v387 @ rax_v27*8]");
						return SerializationType.Byte;
					}
					IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
					return (SerializationType)ex2;
				}
			}
		}
		throw new NullReferenceException();
	}

	static EnumCache()
	{
		Dictionary<Type, SerializationType> dictionary = new Dictionary<Type, SerializationType>();
		enumSerializationTypeCache = dictionary;
	}
}
