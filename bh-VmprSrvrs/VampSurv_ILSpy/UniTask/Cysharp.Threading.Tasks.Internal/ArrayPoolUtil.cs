using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks.Internal;

internal static class ArrayPoolUtil
{
	public struct RentArray<T>(T[] array, int length, ArrayPool<T> pool) : IDisposable
	{
		public readonly T[] Array = (T[])(object)pool;

		public readonly int Length;

		private ArrayPool<T> pool;

		public void Dispose()
		{
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected I4, but got Unknown
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804DA9F0");
			object obj = default(object);
			bool clearArray = (byte)(obj ^ 1) != 0;
			System.Runtime.CompilerServices.Unsafe.As<RentArray<T>, RentArray<UniTask>>(ref this).DisposeManually(clearArray);
		}

		public unsafe void DisposeManually(bool clearArray)
		{
			//IL_004f: Expected O, but got Ref
			if (Array != null)
			{
				if (clearArray)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Internal.ArrayPoolUtil+RentArray`1<T>)+8]");
					System.Array.Clear((Array)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this), 0, 0);
				}
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1835C4360");
				Array = null;
			}
		}
	}

	[MethodImpl((MethodImplOptions)256)]
	internal static void EnsureCapacity<T>(ref T[] array, int index, ArrayPool<T> pool)
	{
		T[] array2 = array;
		if (array2.Length <= index)
		{
			EnsureCapacityCore(ref array, index, pool);
		}
	}

	[MethodImpl((MethodImplOptions)8)]
	private unsafe static void EnsureCapacityCore<T>(ref T[] array, int index, ArrayPool<T> pool)
	{
		//IL_0051: Expected O, but got I4
		T[] array2 = array;
		if (array2.Length <= index)
		{
			int num = array2.Length;
			object obj = array2.Length + array2.Length;
			if (index >= (nint)obj)
			{
				num = index;
			}
			int minimumLength = num + num;
			Array array3 = pool.Rent(minimumLength);
			int length = default(int);
			Array.Copy(array, 0, array3, 0, length);
			bool flag = RuntimeHelpersAbstraction.IsWellKnownNoReferenceContainsType<T>();
			bool clearArray = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			pool.Return(array, clearArray);
			ref T[] reference = ref *(T[]*)array3;
		}
	}

	public unsafe static RentArray<T> Materialize<T>(IEnumerable<T> source)
	{
		//IL_006f: Expected O, but got I
		//IL_05f5: Expected O, but got I
		//IL_06c6: Expected O, but got I4
		//IL_06d7: Expected O, but got I4
		//IL_00ae: Expected O, but got I
		//IL_00cd: Expected O, but got I
		//IL_0407: Expected O, but got I
		//IL_042e: Expected O, but got I
		//IL_03e3: Expected O, but got I4
		//IL_011c: Expected O, but got I4
		//IL_012c: Expected O, but got I
		//IL_0636: Expected O, but got I
		//IL_014a: Expected O, but got I
		//IL_0179: Expected O, but got I
		//IL_0465: Expected O, but got I
		//IL_0475: Expected O, but got I
		//IL_048a: Expected O, but got I
		//IL_0198: Expected O, but got I
		//IL_01a8: Expected O, but got I
		//IL_01bd: Expected O, but got I
		//IL_04bf: Expected O, but got I
		//IL_04d9: Expected O, but got I
		//IL_01d2: Expected O, but got I
		//IL_01f1: Expected O, but got I
		//IL_0208: Expected O, but got Ref
		//IL_0219: Expected O, but got I4
		//IL_0222: Expected O, but got I4
		//IL_0557: Expected O, but got I
		//IL_04ee: Expected O, but got I
		//IL_04f7: Expected O, but got I4
		//IL_0576: Expected O, but got I
		//IL_058f: Expected O, but got I4
		//IL_05b7: Expected O, but got I
		//IL_05ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d3: Expected O, but got Unknown
		//IL_0505: Unknown result type (might be due to invalid IL or missing references)
		//IL_050a: Expected O, but got Unknown
		//IL_0266: Expected O, but got I4
		//IL_0698: Expected O, but got I4
		//IL_06a8: Expected O, but got I
		//IL_0284: Expected O, but got I
		//IL_02a3: Expected O, but got I
		//IL_02b3: Expected O, but got I
		//IL_0668: Unknown result type (might be due to invalid IL or missing references)
		//IL_066d: Expected O, but got Unknown
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Expected O, but got Unknown
		//IL_034b: Expected O, but got I
		//IL_035b: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8+38]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		object obj35;
		object obj36;
		object obj37;
		object obj38;
		if (obj2 == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8+38]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8+38]");
			object obj4 = 0;
			object obj5 = default(object);
			if (obj5 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj6 = default(object);
				bool flag = obj6 == null;
				object obj8 = default(object);
				object obj7 = obj8;
				object obj9 = 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v15+58]");
				object obj10 = 0;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8+38]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					obj7 = obj6;
					object obj12 = default(object);
					obj9 = obj12;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rcx_v77+58]");
					obj10 = 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8+38]");
				object obj13 = 0;
				if (obj9 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8+38]");
					object obj14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v520 @ rax_v67+40]");
					object obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rax_v69+B8]");
					object obj16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8+38]");
					object obj17 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1835C3FB0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8+38]");
					object obj18 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					object obj20 = default(object);
					object obj19 = (object)(&obj20);
					object obj22 = default(object);
					object obj21 = obj22;
					object obj23 = 0;
					object obj24 = 0;
					object obj25 = default(object);
					while (true)
					{
						if (obj20 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							if (obj25 == null)
							{
								break;
							}
							bool flag2 = obj20 == null;
							obj24 = 0;
							if (!flag2)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8+38]");
								object obj26 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180480F30");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8+38]");
								object obj27 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v966 @ rax_v93+88]");
								object obj28 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v799 @ rsi_v12+38]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
								}
								if (obj22 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v582 @ rax_v74+18]");
									bool flag3 = 0 > (nint)obj23;
									object obj29 = obj20;
									object obj30 = obj22;
									if (!flag3)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v799 @ rsi_v12+38]");
										object obj31 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1020 @ r9_v16+10]");
										obj29 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182EECE30");
										obj30 = obj22;
									}
									object obj32 = obj23 + 1;
									object obj33 = obj23 + 2;
									object obj34 = obj33 + obj33;
									obj23 = obj32;
									continue;
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					if (obj19 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					}
					obj35 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v550 @ rax_v70+8]");
					obj36 = 0;
					obj37 = obj23;
					obj38 = obj22;
					goto IL_0760;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8+38]");
				object obj13 = 0;
				object obj39 = default(object);
				bool flag4 = obj39 == null;
				object obj7 = obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v15+28]");
				object obj10 = 0;
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8+38]");
					object obj40 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v567 @ rax_v27+40]");
					object obj41 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rax_v29+B8]");
					object obj42 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ rax_v30+8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8+38]");
						object obj43 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1835C3FB0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8+38]");
						object obj44 = 0;
						object obj45 = obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ r9_v5+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_052e;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ r9_v5+B0]");
						object obj46 = 0;
						object obj47 = 0;
						while (true)
						{
							object obj48 = obj47 + obj47;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v716 @ r8_v15+v721 @ rax_v45*8]");
							nint num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v676 @ rcx_v22+28]");
							if (num == 0)
							{
								break;
							}
							obj47++;
							object obj49 = obj47;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ r9_v5+12E]");
							if ((nint)obj49 < 0)
							{
								continue;
							}
							goto IL_052e;
						}
						object obj50 = obj47 + obj47;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v716 @ r8_v15+8+v839 @ rcx_v33*8]");
						object obj51 = (nint)0 + (nint)5;
						object obj52 = obj51 << 4;
						object obj53 = obj52 + 312;
						object obj54 = obj53 + obj45;
						goto IL_053d;
					}
					return (RentArray<T>)new NullReferenceException();
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047E1C0");
			obj37 = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v10+18]");
			obj37 = 0;
		}
		obj36 = 0;
		obj38 = obj2;
		object obj55 = 0;
		goto IL_0753;
		IL_0760:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804DAA70");
		object obj56 = default(object);
		IEnumerable<T> enumerable = (IEnumerable<T>)obj56;
		return (RentArray<T>)source;
		IL_0753:
		obj35 = obj55;
		goto IL_0760;
		IL_052e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
		goto IL_053d;
		IL_053d:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v836 @ rax_v34] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8+38]");
		object obj57 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ rax_v30+8]");
		obj36 = 0;
		object obj58 = default(object);
		obj37 = obj58;
		object obj59 = default(object);
		obj38 = obj59;
		obj55 = 0;
		goto IL_0753;
	}
}
