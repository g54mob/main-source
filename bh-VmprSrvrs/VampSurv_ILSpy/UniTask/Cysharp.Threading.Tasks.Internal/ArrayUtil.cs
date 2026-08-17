using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks.Internal;

internal static class ArrayUtil
{
	[MethodImpl((MethodImplOptions)256)]
	public static void EnsureCapacity<T>(ref T[] array, int index)
	{
		T[] array2 = array;
		if (array2.Length <= index)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v61 @ r9_v2 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
		}
	}

	[MethodImpl((MethodImplOptions)8)]
	private unsafe static void EnsureCore<T>(ref T[] array, int index)
	{
		//IL_002e: Expected O, but got I4
		//IL_0098: Expected O, but got I4
		//IL_005c: Expected I, but got O
		//IL_007d: Expected O, but got I
		T[] array2 = array;
		int num = array2.Length;
		object obj = array2.Length + array2.Length;
		if (index >= (nint)obj)
		{
			num = index;
		}
		object obj2 = num + num;
		nint num2 = unchecked((nint)null);
		int length = default(int);
		Array.Copy(array, 0, (Array)num2, 0, length);
		ref T[] reference = ref *(T[]*)num2;
	}

	public unsafe static (T[], int) Materialize<T>(IEnumerable<T> source)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0077: Expected O, but got I
		//IL_0087: Expected O, but got I
		//IL_00aa: Expected O, but got I
		//IL_05a5: Expected O, but got I
		//IL_05e9: Expected O, but got I
		//IL_0537: Expected O, but got I
		//IL_0547: Expected O, but got I
		//IL_0631: Expected O, but got I
		//IL_0712: Expected O, but got Ref
		//IL_0720: Expected O, but got Ref
		//IL_073a: Expected O, but got I
		//IL_0103: Expected O, but got I
		//IL_0122: Expected O, but got I
		//IL_04ae: Expected O, but got I
		//IL_04cd: Expected O, but got I
		//IL_0169: Expected O, but got I4
		//IL_0179: Expected O, but got I
		//IL_04f2: Expected O, but got I
		//IL_0502: Expected O, but got I
		//IL_0646: Expected O, but got I
		//IL_043c: Expected O, but got I
		//IL_044c: Expected O, but got I
		//IL_046c: Expected O, but got I
		//IL_047c: Expected O, but got I
		//IL_0197: Expected O, but got I
		//IL_0202: Expected O, but got I
		//IL_0227: Expected O, but got Ref
		//IL_0235: Expected O, but got I4
		//IL_023e: Expected O, but got I4
		//IL_0282: Expected O, but got I4
		//IL_06af: Expected O, but got I
		//IL_06c2: Expected O, but got Ref
		//IL_06d0: Expected O, but got Ref
		//IL_06ea: Expected O, but got I
		//IL_06fa: Expected O, but got I
		//IL_02a0: Expected O, but got I
		//IL_02ce: Expected O, but got I
		//IL_02de: Expected O, but got I
		//IL_02ec: Expected O, but got Ref
		//IL_0306: Expected O, but got I
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected O, but got Unknown
		//IL_0329: Expected O, but got I
		//IL_0370: Unknown result type (might be due to invalid IL or missing references)
		//IL_0375: Expected O, but got Unknown
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Expected O, but got Unknown
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Expected O, but got Unknown
		//IL_03d9: Expected O, but got I
		//IL_03e9: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+38]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v2+70]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v2+FC]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v2+FC]");
		object obj5 = (nint)0 + (nint)15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v2+FC]");
		if ((nint)obj5 > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			_ = ref obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v2+FC]");
			object obj6 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v2+FC]");
			if ((nint)obj6 <= 0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			_ = ref obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v2+FC]");
			object obj7 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v2+FC]");
			if ((nint)obj7 <= 0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			_ = ref obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+38]");
			object obj8 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj9 = default(object);
		if (obj9 == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+38]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+38]");
			object obj11 = 0;
			object obj12 = default(object);
			if (obj12 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj13 = default(object);
				bool flag = obj13 == null;
				object obj14 = 4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v2+FC]");
				object obj15 = 0;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+38]");
					object obj16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					object obj17 = default(object);
					obj14 = obj17;
					obj15 = obj13;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+38]");
				object obj18 = 0;
				if (obj14 != null)
				{
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_array_new_specific\"");
					IntPtr intPtr = default(IntPtr);
					if (intPtr != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+38]");
						object obj19 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						object obj20 = default(object);
						obj = obj20;
						_ = 0;
						object obj21 = (object)(&obj2);
						_ = ref obj2;
						object obj22 = 0;
						object obj23 = 0;
						object obj24 = default(object);
						while (true)
						{
							if (obj != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
								if (obj24 != null)
								{
									bool flag2 = obj == null;
									obj23 = 0;
									if (!flag2)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+38]");
										object obj25 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D1800");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+38]");
										object obj26 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v721 @ rax_v81+78]");
										object obj27 = 0;
										object obj28 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v722 @ rcx_v42] (should have been resolved before IL gen)");
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+8]");
										object obj29 = 0;
										object obj30 = obj22 + 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+18]");
										obj23 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+8]");
										if ((nint)0 != 0)
										{
											object obj31 = obj29;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rax_v89+104]");
											object obj32 = 0 * obj22;
											object obj33 = obj32 + 32;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+8]");
											obj23 = obj33 + 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
											object obj34 = obj22;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v681 @ rdi_v12+18]");
											if ((nint)obj34 < 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+38]");
												object obj35 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v793 @ rax_v92+70]");
												obj23 = 0;
												obj22 = obj30;
												continue;
											}
											throw new IndexOutOfRangeException();
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								if (obj21 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
								}
								break;
							}
							throw new NullReferenceException();
						}
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+38]");
						object obj36 = 0;
						object obj37 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 176));
						object obj38 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183704A70");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+A0]");
						(T[], int) tuple = ((T[], int))0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+38]");
						return ((T[], int))0;
					}
					return ((T[], int))new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v471 @ rax_v51+50]");
				object obj39 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+38]");
				object obj40 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v494 @ rax_v52] (should have been resolved before IL gen)");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+38]");
				object obj41 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rcx_v26+18]");
				object obj42 = 0;
				_ = 0;
				object obj44 = default(object);
				object obj43 = obj44;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+38]");
				object obj45 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_array_new_specific\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+38]");
				object obj46 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18048C1D0");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+38]");
				object obj47 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rax_v43+18]");
				object obj42 = 0;
				object obj48 = default(object);
				object obj43 = obj48;
			}
		}
		else
		{
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rax_v23+18]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+38]");
			object obj49 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ r9_v3+18]");
			object obj42 = 0;
			object obj43 = obj9;
		}
		object obj50 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 176));
		object obj51 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183704A70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+38]");
		IEnumerable<T> enumerable = (IEnumerable<T>)0;
		return ((T[], int))source;
	}
}
