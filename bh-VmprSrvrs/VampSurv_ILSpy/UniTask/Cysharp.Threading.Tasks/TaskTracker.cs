using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Cpp2ILInjected;
using Cysharp.Threading.Tasks.Internal;

namespace Cysharp.Threading.Tasks;

public static class TaskTracker
{
	private static List<KeyValuePair<IUniTaskSource, (string, int, DateTime, string)>> listPool;

	private static readonly WeakDictionary<IUniTaskSource, (string, int, DateTime, string)> tracking;

	private static bool dirty;

	public static void TrackActiveTask(IUniTaskSource task, int skipFrame)
	{
	}

	public static void RemoveTracking(IUniTaskSource task)
	{
	}

	public static bool CheckAndResetDirty()
	{
		dirty = false;
		return dirty;
	}

	public unsafe static void ForEachActiveTask(Action<int, string, UniTaskStatus, DateTime, string> action)
	{
		//IL_0059: Expected I, but got O
		//IL_06a8: Expected O, but got Ref
		//IL_06d7: Expected O, but got Ref
		//IL_09c2: Expected O, but got I8
		//IL_0135: Expected O, but got I4
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		//IL_01fa: Expected O, but got I4
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected O, but got Unknown
		//IL_0265: Expected O, but got I
		//IL_02cf: Expected O, but got I4
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_02ec: Expected O, but got I
		//IL_03b4: Expected O, but got I4
		//IL_0975: Expected I, but got O
		//IL_0361: Expected O, but got I
		//IL_091a: Expected O, but got I4
		//IL_03e8: Expected I, but got O
		//IL_049e: Expected O, but got I4
		//IL_04b4: Expected O, but got I
		//IL_04cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d0: Expected O, but got Unknown
		//IL_0410: Expected O, but got I
		//IL_0435: Expected I, but got O
		//IL_0474: Expected I, but got O
		//IL_0509: Expected I, but got O
		//IL_0548: Expected I, but got O
		//IL_0595: Expected I, but got O
		//IL_05cb: Expected I, but got O
		//IL_05e8: Expected O, but got I4
		//IL_05f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f5: Expected O, but got Unknown
		//IL_0612: Expected I, but got O
		//IL_067c: Expected O, but got Ref
		object obj = default(object);
		if (obj == null)
		{
			object obj2 = default(object);
			if (obj2 != null)
			{
				ref List<KeyValuePair<IUniTaskSource, (string, int, DateTime, string)>> list;
				if (obj == null)
				{
					Monitor.Enter(obj2);
					nint num = (nint)typeof(TaskTracker);
					WeakDictionary<IUniTaskSource, (string, int, DateTime, string)> weakDictionary = tracking;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rdx_v35 (Il2CppClass<Cysharp.Threading.Tasks.TaskTracker>)+B8]");
					int num2 = weakDictionary.ToList(ref *(List<KeyValuePair<IUniTaskSource, (string, int, DateTime, string)>>*)null, clear: false);
					int num3 = 0;
					bool clear = false;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rdx_v35 (Il2CppClass<Cysharp.Threading.Tasks.TaskTracker>)+B8]");
					list = ref *(List<KeyValuePair<IUniTaskSource, (string, int, DateTime, string)>>*)null;
					object obj21 = default(object);
					object obj25 = default(object);
					while (true)
					{
						if (num3 >= num2)
						{
							object obj3 = (object)(&obj);
							if (obj3 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
								object obj4 = (object)(&obj);
								if (obj4 == null)
								{
									int num4 = ((WeakDictionary<IUniTaskSource, (string, int, DateTime, string)>)6586836376L).ToList(ref list, clear);
									throw num4;
								}
								Monitor.Exit(obj4);
							}
							return;
						}
						list = ref *(List<KeyValuePair<IUniTaskSource, (string, int, DateTime, string)>>*)listPool;
						object obj14;
						object obj20;
						nint num11;
						if (listPool != null)
						{
							int num5 = num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rdx_v17 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Cysharp.Threading.Tasks.IUniTaskSource, System.ValueTuple`4<System.String, System.Int32, System.DateTime, System.String>>>&)+18]");
							if ((nint)num5 < (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rdx_v17 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Cysharp.Threading.Tasks.IUniTaskSource, System.ValueTuple`4<System.String, System.Int32, System.DateTime, System.String>>>&)+10]");
								clear = false;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rdx_v17 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Cysharp.Threading.Tasks.IUniTaskSource, System.ValueTuple`4<System.String, System.Int32, System.DateTime, System.String>>>&)+10]");
								if ((int)(~(nint)0) == 0)
								{
									int num6 = num3;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ r8_v15 (System.Boolean)+18]");
									if ((nint)num6 >= (nint)0)
									{
										break;
									}
									object obj5 = num3 * 4;
									object obj6 = num3 + obj5;
									list = ref *(List<KeyValuePair<IUniTaskSource, (string, int, DateTime, string)>>*)listPool;
									if (listPool != null)
									{
										int num7 = num3;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rdx_v17 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Cysharp.Threading.Tasks.IUniTaskSource, System.ValueTuple`4<System.String, System.Int32, System.DateTime, System.String>>>&)+18]");
										if ((nint)num7 < (nint)0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rdx_v17 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Cysharp.Threading.Tasks.IUniTaskSource, System.ValueTuple`4<System.String, System.Int32, System.DateTime, System.String>>>&)+10]");
											list = ref *(List<KeyValuePair<IUniTaskSource, (string, int, DateTime, string)>>*)null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rdx_v17 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Cysharp.Threading.Tasks.IUniTaskSource, System.ValueTuple`4<System.String, System.Int32, System.DateTime, System.String>>>&)+10]");
											if ((nint)0 != 0)
											{
												int num8 = num3;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rdx_v17 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Cysharp.Threading.Tasks.IUniTaskSource, System.ValueTuple`4<System.String, System.Int32, System.DateTime, System.String>>>&)+18]");
												if ((nint)num8 < (nint)0)
												{
													object obj7 = num3 * 4;
													object obj8 = num3 + obj7;
													List<KeyValuePair<IUniTaskSource, (string, int, DateTime, string)>> list2 = listPool;
													if (listPool != null)
													{
														int num9 = num3;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1447 @ rcx_v64 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Cysharp.Threading.Tasks.IUniTaskSource, System.ValueTuple`4<System.String, System.Int32, System.DateTime, System.String>>>)+18]");
														if ((nint)num9 < (nint)0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1447 @ rcx_v64 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Cysharp.Threading.Tasks.IUniTaskSource, System.ValueTuple`4<System.String, System.Int32, System.DateTime, System.String>>>)+10]");
															object obj9 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1447 @ rcx_v64 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Cysharp.Threading.Tasks.IUniTaskSource, System.ValueTuple`4<System.String, System.Int32, System.DateTime, System.String>>>)+10]");
															if ((nint)0 != 0)
															{
																int num10 = num3;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ rcx_v65+18]");
																bool flag = (nint)num10 >= (nint)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rdx_v17 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Cysharp.Threading.Tasks.IUniTaskSource, System.ValueTuple`4<System.String, System.Int32, System.DateTime, System.String>>>&)+10]");
																num11 = 0;
																if (!flag)
																{
																	object obj10 = num3 * 4;
																	object obj11 = num3 + obj10;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ rcx_v65+20+v1481 @ rax_v98*8]");
																	object obj12 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ rcx_v65+20+v1481 @ rax_v98*8]");
																	bool flag2 = (nint)0 == 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rdx_v17 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Cysharp.Threading.Tasks.IUniTaskSource, System.ValueTuple`4<System.String, System.Int32, System.DateTime, System.String>>>&)+10]");
																	num11 = 0;
																	if (!flag2)
																	{
																		object obj13 = obj12;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ r10_v29+12E]");
																		if ((nint)0 >= (nint)0)
																		{
																			goto IL_03a1;
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ r10_v29+B0]");
																		obj14 = 0;
																		int num12 = 0;
																		while (true)
																		{
																			object obj15 = num12 + num12;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1682 @ r8_v32+v1619 @ rax_v113*8]");
																			if (0 == (nint)typeof(IUniTaskSource))
																			{
																				break;
																			}
																			num12++;
																			int num13 = num12;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ r10_v29+12E]");
																			if ((nint)num13 < (nint)0)
																			{
																				continue;
																			}
																			goto IL_03a1;
																		}
																		object obj16 = num12 + num12;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1682 @ r8_v32+8+v1675 @ rcx_v83*8]");
																		object obj17 = (nint)0 + (nint)3;
																		object obj18 = obj17 << 4;
																		object obj19 = obj18 + 312;
																		obj20 = obj19 + obj13;
																		goto IL_0944;
																	}
																	clear = (byte)num11 != 0;
																	throw new NullReferenceException();
																}
																throw new IndexOutOfRangeException();
															}
															throw new NullReferenceException();
														}
														System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
													}
													throw new NullReferenceException();
												}
												num11 = (clear ? 1 : 0);
												throw new IndexOutOfRangeException();
											}
											throw new NullReferenceException();
										}
										System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						}
						throw new NullReferenceException();
						IL_03a1:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
						obj14 = 3;
						obj20 = obj21;
						goto IL_0944;
						IL_0944:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1683 @ rdx_v42] (should have been resolved before IL gen)");
						List<KeyValuePair<IUniTaskSource, (string, int, DateTime, string)>> list3 = listPool;
						bool flag3 = listPool == null;
						num11 = (nint)typeof(TaskTracker);
						list = ref *(List<KeyValuePair<IUniTaskSource, (string, int, DateTime, string)>>*)listPool;
						if (!flag3)
						{
							int num14 = num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v639 @ rdx_v44 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Cysharp.Threading.Tasks.IUniTaskSource, System.ValueTuple`4<System.String, System.Int32, System.DateTime, System.String>>>)+18]");
							bool flag4 = (nint)num14 >= (nint)0;
							num11 = (nint)typeof(TaskTracker);
							list = ref *(List<KeyValuePair<IUniTaskSource, (string, int, DateTime, string)>>*)listPool;
							if (!flag4)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v639 @ rdx_v44 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Cysharp.Threading.Tasks.IUniTaskSource, System.ValueTuple`4<System.String, System.Int32, System.DateTime, System.String>>>)+10]");
								object obj22 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v639 @ rdx_v44 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Cysharp.Threading.Tasks.IUniTaskSource, System.ValueTuple`4<System.String, System.Int32, System.DateTime, System.String>>>)+10]");
								bool flag5 = (nint)0 == 0;
								num11 = (nint)typeof(TaskTracker);
								list = ref *(List<KeyValuePair<IUniTaskSource, (string, int, DateTime, string)>>*)listPool;
								if (!flag5)
								{
									int num15 = num3;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v643 @ rcx_v70+18]");
									bool flag6 = (nint)num15 >= (nint)0;
									num11 = (nint)typeof(TaskTracker);
									list = ref *(List<KeyValuePair<IUniTaskSource, (string, int, DateTime, string)>>*)listPool;
									if (!flag6)
									{
										List<KeyValuePair<IUniTaskSource, (string, int, DateTime, string)>> list4 = listPool;
										bool flag7 = listPool == null;
										num11 = (nint)typeof(TaskTracker);
										list = ref *(List<KeyValuePair<IUniTaskSource, (string, int, DateTime, string)>>*)listPool;
										if (!flag7)
										{
											int num16 = num3;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1090 @ rdx_v45 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Cysharp.Threading.Tasks.IUniTaskSource, System.ValueTuple`4<System.String, System.Int32, System.DateTime, System.String>>>)+18]");
											bool flag8 = (nint)num16 >= (nint)0;
											num11 = (nint)typeof(TaskTracker);
											list = ref *(List<KeyValuePair<IUniTaskSource, (string, int, DateTime, string)>>*)listPool;
											if (!flag8)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1090 @ rdx_v45 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Cysharp.Threading.Tasks.IUniTaskSource, System.ValueTuple`4<System.String, System.Int32, System.DateTime, System.String>>>)+10]");
												list = ref *(List<KeyValuePair<IUniTaskSource, (string, int, DateTime, string)>>*)null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1090 @ rdx_v45 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Cysharp.Threading.Tasks.IUniTaskSource, System.ValueTuple`4<System.String, System.Int32, System.DateTime, System.String>>>)+10]");
												bool flag9 = (nint)0 == 0;
												num11 = (nint)typeof(TaskTracker);
												if (!flag9)
												{
													int num17 = num3;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rdx_v17 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Cysharp.Threading.Tasks.IUniTaskSource, System.ValueTuple`4<System.String, System.Int32, System.DateTime, System.String>>>&)+18]");
													bool flag10 = (nint)num17 >= (nint)0;
													num11 = (nint)typeof(TaskTracker);
													if (!flag10)
													{
														object obj23 = num3 * 4;
														object obj24 = num3 + obj23;
														bool flag11 = action == null;
														num11 = (nint)typeof(TaskTracker);
														if (!flag11)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [action @ rcx (System.Action`5<System.Int32, System.String, Cysharp.Threading.Tasks.UniTaskStatus, System.DateTime, System.String>)+18] (should have been resolved before IL gen)");
															bool flag12 = listPool == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rdx_v17 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Cysharp.Threading.Tasks.IUniTaskSource, System.ValueTuple`4<System.String, System.Int32, System.DateTime, System.String>>>&)+28+v1445…");
															num11 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ r8_v15 (System.Boolean)+30+v1116 @ rax_v92*8]");
															list = ref *(List<KeyValuePair<IUniTaskSource, (string, int, DateTime, string)>>*)null;
															if (!flag12)
															{
																listPool.set_Item(num3, (KeyValuePair<IUniTaskSource, (string, int, DateTime, string)>)(&obj25));
																num3++;
																clear = (byte)(&obj25) != 0;
																list = ref *(List<KeyValuePair<IUniTaskSource, (string, int, DateTime, string)>>*)num3;
																continue;
															}
															throw new NullReferenceException();
														}
														throw new NullReferenceException();
													}
													throw new IndexOutOfRangeException();
												}
												throw new NullReferenceException();
											}
											System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
										}
										throw new NullReferenceException();
									}
									throw new IndexOutOfRangeException();
								}
								throw new NullReferenceException();
							}
							System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						}
						throw new NullReferenceException();
					}
					throw new IndexOutOfRangeException();
				}
				ArgumentException ex = new ArgumentException();
				list = ref *(List<KeyValuePair<IUniTaskSource, (string, int, DateTime, string)>>*)null;
				throw ex;
			}
			ArgumentNullException ex2 = new ArgumentNullException("obj");
			throw ex2;
		}
		Monitor.ThrowLockTakenException();
		throw null;
	}

	private static void TypeBeautify(Type type, StringBuilder sb)
	{
		//IL_01ad: Expected O, but got I4
		//IL_01b6: Expected O, but got I4
		//IL_01bf: Expected O, but got I4
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		//IL_022d: Expected O, but got I4
		Type declaringType = type.DeclaringType;
		if ((object)declaringType != null)
		{
			Type declaringType2 = type.DeclaringType;
			string name = declaringType2.Name;
			string value = name.ToString();
			StringBuilder stringBuilder = sb.Append(value);
			StringBuilder stringBuilder2 = sb.Append(".");
		}
		if (!type.IsGenericType)
		{
			string name2 = type.Name;
			StringBuilder stringBuilder3 = sb.Append(name2);
			return;
		}
		string name3 = type.Name;
		StringComparison comparisonType = default(StringComparison);
		int num = name3.IndexOf("`", 0, name3._stringLength, comparisonType);
		string value2;
		if (num == -1)
		{
			value2 = type.Name;
		}
		else
		{
			string name4 = type.Name;
			value2 = name4.Substring(0, num);
		}
		StringBuilder stringBuilder4 = sb.Append(value2);
		StringBuilder stringBuilder5 = sb.Append("<");
		Type[] genericArguments = type.GetGenericArguments();
		object obj = 1;
		object obj2 = 0;
		object obj3 = 0;
		while ((nint)obj3 < genericArguments.Length)
		{
			if (obj == null)
			{
				StringBuilder stringBuilder6 = sb.Append(", ");
			}
			TypeBeautify(genericArguments[obj2], sb);
			obj2++;
			obj = 0;
			obj3 = obj2;
		}
		StringBuilder stringBuilder7 = sb.Append(">");
	}

	static TaskTracker()
	{
		//IL_0014: Expected I, but got O
		List<KeyValuePair<IUniTaskSource, (string, int, DateTime, string)>> list = new List<KeyValuePair<IUniTaskSource, (string, int, DateTime, string)>>();
		listPool = list;
		WeakDictionary<IUniTaskSource, (string, int, DateTime, string)> weakDictionary = null;
		nint num = unchecked((nint)null);
		_ = 1061158912;
		_ = 2147483648L;
		EqualityComparer<object> equalityComparer = EqualityComparer<object>.Default;
		tracking = weakDictionary;
	}
}
