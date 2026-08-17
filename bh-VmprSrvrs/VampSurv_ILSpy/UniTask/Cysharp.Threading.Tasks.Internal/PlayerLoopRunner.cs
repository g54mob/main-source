using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Internal;

internal sealed class PlayerLoopRunner
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action<Exception> _003C_003E9__9_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003C_002Ector_003Eb__9_0(Exception ex)
		{
			Debug.LogException(ex);
		}
	}

	private const int InitialSize = 16;

	private readonly PlayerLoopTiming timing;

	private readonly object runningAndQueueLock;

	private readonly object arrayLock;

	private readonly Action<Exception> unhandledExceptionCallback;

	private int tail;

	private bool running;

	private IPlayerLoopItem[] loopItems;

	private MinimumQueue<IPlayerLoopItem> waitQueue;

	public PlayerLoopRunner(PlayerLoopTiming timing)
	{
		object obj = new object();
		runningAndQueueLock = obj;
		object obj2 = new object();
		arrayLock = obj2;
		IPlayerLoopItem[] array = new IPlayerLoopItem[16];
		loopItems = array;
		MinimumQueue<IPlayerLoopItem> minimumQueue = new MinimumQueue<IPlayerLoopItem>(16);
		waitQueue = minimumQueue;
		Action<Exception> action = _003C_003Ec._003C_003E9__9_0;
		if (_003C_003Ec._003C_003E9__9_0 == null)
		{
			action = (_003C_003Ec._003C_003E9__9_0 = delegate(Exception ex)
			{
				Debug.LogException(ex);
			});
		}
		unhandledExceptionCallback = action;
		this.timing = timing;
	}

	public unsafe void AddAction(IPlayerLoopItem item)
	{
		//IL_03c1: Expected O, but got Ref
		//IL_03aa: Expected I, but got O
		//IL_036e: Expected O, but got I4
		//IL_00a6: Expected O, but got I8
		//IL_0160: Expected O, but got Ref
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected Ref, but got Unknown
		//IL_01c5: Expected O, but got I4
		//IL_01dc: Expected O, but got Ref
		//IL_01ee: Expected O, but got Ref
		//IL_02bb: Expected I, but got O
		//IL_02dc: Expected O, but got Ref
		//IL_020d: Expected O, but got I4
		//IL_0224: Expected O, but got Ref
		//IL_0236: Expected O, but got Ref
		//IL_0328: Expected O, but got Ref
		//IL_0330: Expected I, but got O
		object obj = default(object);
		object obj6 = default(object);
		IPlayerLoopItem playerLoopItem = default(IPlayerLoopItem);
		object obj7;
		if (obj == null)
		{
			object obj2 = default(object);
			nint num2;
			if (obj2 != null)
			{
				object obj4;
				if (obj == null)
				{
					Monitor.Enter(obj2);
					object obj3 = default(object);
					if (!running)
					{
						if (obj3 != null)
						{
							bool flag = obj2 == null;
							obj4 = 4294967295L;
							if (flag)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
								object obj5 = default(object);
								throw obj5;
							}
							Monitor.Exit(obj2);
						}
						if (obj == null)
						{
							if (obj6 != null)
							{
								bool flag2 = obj != null;
								obj7 = (object)(&obj);
								if (!flag2)
								{
									Monitor.Enter(obj6);
									IPlayerLoopItem[] array = loopItems;
									if (array.Length == tail)
									{
										ref IPlayerLoopItem[] reference = ref *(IPlayerLoopItem[]*)(this + 56);
										object obj8 = tail + tail;
										bool flag3 = (nint)obj8 < -2147483648;
										obj7 = (object)(&obj);
										int num = tail;
										ArrayTypeMismatchException ex = (ArrayTypeMismatchException)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference);
										if (!flag3)
										{
											object obj9 = tail + tail;
											bool flag4 = (nint)obj9 > 2147483647;
											obj7 = (object)(&obj);
											num = tail;
											ex = (ArrayTypeMismatchException)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference);
											if (!flag4)
											{
												int newSize = tail + tail;
												Array.Resize(ref reference, newSize);
												num2 = 0;
												goto IL_026d;
											}
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7590");
										nint num3 = 0;
										object obj10 = default(object);
										throw obj10;
									}
									goto IL_026d;
								}
								ArgumentException ex2 = new ArgumentException();
								throw ex2;
							}
							ArgumentNullException ex3 = new ArgumentNullException("obj");
							throw ex3;
						}
						Monitor.ThrowLockTakenException();
						throw null;
					}
					waitQueue.Enqueue(playerLoopItem);
					if (obj3 != null)
					{
						bool flag5 = obj2 == null;
						num2 = 0;
						if (flag5)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
							object obj11 = default(object);
							throw obj11;
						}
						Monitor.Exit(obj2);
					}
					return;
				}
				ArgumentException ex4 = new ArgumentException();
				obj4 = 0;
				throw ex4;
			}
			ArgumentNullException ex5 = new ArgumentNullException("obj");
			num2 = unchecked((nint)null);
			throw ex5;
		}
		Monitor.ThrowLockTakenException();
		obj7 = (object)(&obj);
		throw null;
		IL_026d:
		IPlayerLoopItem[] array2 = loopItems;
		int num4 = tail + 1;
		tail = num4;
		if (playerLoopItem != null)
		{
			nint num5 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj12 = default(object);
			bool flag6 = obj12 == null;
			obj7 = (object)(&obj);
			if (flag6)
			{
				ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
				int num = 0;
				ArrayTypeMismatchException ex = ex6;
				throw ex6;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj13 = default(object);
		if (obj13 != null)
		{
			bool flag7 = obj6 == null;
			obj7 = (object)(&obj);
			nint num2 = (nint)playerLoopItem;
			nint num3 = tail;
			if (flag7)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
				object obj14 = default(object);
				throw obj14;
			}
			Monitor.Exit(obj6);
		}
	}

	public int Clear()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_004b: Expected O, but got I4
		//IL_0061: Expected O, but got I8
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 + 8;
		if (arrayLock != null)
		{
			Monitor.Enter(arrayLock);
			object obj3 = 0;
			int num = 0;
			object obj4 = 4294967295L;
			object obj6 = default(object);
			object obj5;
			while (true)
			{
				IPlayerLoopItem[] array = loopItems;
				if ((nint)obj3 < array.Length)
				{
					bool flag = (nint)obj3 >= array.Length;
					obj4 = obj3;
					if (!flag)
					{
						int num2 = num + 1;
						if (array[obj3] == null)
						{
							num2 = num;
						}
						bool flag2 = array == null;
						obj4 = obj3;
						if (flag2)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						obj3++;
						num = num2;
						obj4 = obj3;
						continue;
					}
					throw new IndexOutOfRangeException();
				}
				tail = 0;
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					bool flag3 = obj == null;
					obj5 = obj;
					if (flag3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
						throw obj6;
					}
					Monitor.Exit(obj);
				}
				return num;
			}
			obj5 = obj;
			throw new NullReferenceException();
		}
		ArgumentNullException ex = new ArgumentNullException("obj");
		throw ex;
	}

	public void Run()
	{
		RunCore();
	}

	private void Initialization()
	{
		RunCore();
	}

	private void LastInitialization()
	{
		RunCore();
	}

	private void EarlyUpdate()
	{
		RunCore();
	}

	private void LastEarlyUpdate()
	{
		RunCore();
	}

	private void FixedUpdate()
	{
		RunCore();
	}

	private void LastFixedUpdate()
	{
		RunCore();
	}

	private void PreUpdate()
	{
		RunCore();
	}

	private void LastPreUpdate()
	{
		RunCore();
	}

	private void Update()
	{
		RunCore();
	}

	private void LastUpdate()
	{
		RunCore();
	}

	private void PreLateUpdate()
	{
		RunCore();
	}

	private void LastPreLateUpdate()
	{
		RunCore();
	}

	private void PostLateUpdate()
	{
		RunCore();
	}

	private void LastPostLateUpdate()
	{
		RunCore();
	}

	private void TimeUpdate()
	{
		RunCore();
	}

	private void LastTimeUpdate()
	{
		RunCore();
	}

	private unsafe void RunCore()
	{
		//IL_0710: Expected O, but got I4
		//IL_008f: Expected O, but got I8
		//IL_0106: Expected O, but got I4
		//IL_0151: Expected O, but got I4
		//IL_0459: Expected I, but got I8
		//IL_0673: Expected O, but got Ref
		//IL_098d: Expected O, but got Ref
		//IL_06a2: Expected O, but got Ref
		//IL_09c1: Expected I, but got O
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_04d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d7: Expected Ref, but got Unknown
		//IL_04e8: Expected O, but got I4
		//IL_0509: Expected O, but got Ref
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e1: Expected O, but got Unknown
		//IL_0528: Expected O, but got I4
		//IL_0549: Expected O, but got Ref
		//IL_02f7: Expected I, but got O
		//IL_061f: Expected I, but got O
		//IL_037c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Expected O, but got Unknown
		object obj = default(object);
		if (obj == null)
		{
			object obj2 = default(object);
			IPlayerLoopItem playerLoopItem;
			if (obj2 != null)
			{
				object obj4;
				if (obj == null)
				{
					Monitor.Enter(obj2);
					running = true;
					object obj3 = default(object);
					if (obj3 != null)
					{
						bool flag = obj2 == null;
						obj4 = 4294967295L;
						if (flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
							object obj5 = default(object);
							throw obj5;
						}
						Monitor.Exit(obj2);
					}
					if (obj == null)
					{
						object obj6 = default(object);
						if (obj6 != null)
						{
							if (obj == null)
							{
								Monitor.Enter(obj6);
								object obj7 = tail - 1;
								int num = 0;
								object obj8 = default(object);
								object obj9 = default(object);
								object obj10 = default(object);
								object obj11 = default(object);
								object obj14 = default(object);
								object obj17 = default(object);
								object obj19 = default(object);
								object obj20 = default(object);
								object obj21 = default(object);
								object obj22 = default(object);
								while (true)
								{
									IPlayerLoopItem[] array = loopItems;
									IPlayerLoopItem[] array2;
									IPlayerLoopItem[] array3;
									if (num < array.Length)
									{
										bool flag2 = num >= array.Length;
										playerLoopItem = (IPlayerLoopItem)num;
										if (flag2)
										{
											throw new IndexOutOfRangeException();
										}
										playerLoopItem = array[num];
										if (array[num] != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
											if (obj8 != null)
											{
												num++;
												continue;
											}
											if (loopItems == null)
											{
												throw new NullReferenceException();
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											playerLoopItem = null;
										}
										while (num < (nint)obj7)
										{
											array2 = loopItems;
											if (loopItems != null)
											{
												if ((nint)obj7 < array2.Length)
												{
													if (array2[obj7] == null)
													{
														obj7--;
														continue;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
													array3 = loopItems;
													if (obj9 != null)
													{
														goto IL_02bf;
													}
													bool flag3 = loopItems == null;
													playerLoopItem = array2[obj7];
													if (!flag3)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														obj7--;
														playerLoopItem = null;
														continue;
													}
													throw new NullReferenceException();
												}
												throw new IndexOutOfRangeException();
											}
											throw new NullReferenceException();
										}
										tail = num;
									}
									if (obj10 == null)
									{
										if (obj11 != null)
										{
											if (obj10 == null)
											{
												Monitor.Enter(obj11);
												running = false;
												nint num2 = unchecked((nint)4294967295L);
												while (true)
												{
													MinimumQueue<IPlayerLoopItem> minimumQueue = waitQueue;
													if (minimumQueue.size != 0)
													{
														IPlayerLoopItem[] array4 = loopItems;
														if (loopItems == null)
														{
															break;
														}
														if (array4.Length == tail)
														{
															ref IPlayerLoopItem[] reference = ref *(IPlayerLoopItem[]*)(this + 56);
															object obj12 = tail + tail;
															bool flag4 = (nint)obj12 < -2147483648;
															int newSize = tail;
															ArrayTypeMismatchException ex = (ArrayTypeMismatchException)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference);
															if (!flag4)
															{
																object obj13 = tail + tail;
																bool flag5 = (nint)obj13 > 2147483647;
																newSize = tail;
																ex = (ArrayTypeMismatchException)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference);
																if (!flag5)
																{
																	int num3 = tail + tail;
																	Array.Resize(ref reference, num3);
																	num2 = num3;
																	goto IL_0583;
																}
															}
															Array.Resize(ref *(IPlayerLoopItem[]*)ex, newSize);
															num2 = 0;
															throw obj14;
														}
														goto IL_0583;
													}
													object obj15 = (object)(&obj10);
													if (obj15 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
														object obj16 = (object)(&obj10);
														if (obj16 == null)
														{
															Array.Resize(ref *(IPlayerLoopItem[]*)6586836376L, (int)num2);
															num2 = unchecked((nint)null);
															throw obj17;
														}
														Monitor.Exit(obj16);
													}
													object obj18 = (object)(&obj);
													if (obj18 != null)
													{
														if (obj19 == null)
														{
															Array.Resize(ref *(IPlayerLoopItem[]*)6586836376L, (int)num2);
															throw obj20;
														}
														Monitor.Exit(obj19);
													}
													return;
													IL_0583:
													IPlayerLoopItem[] array5 = loopItems;
													int num4 = tail + 1;
													tail = num4;
													if (waitQueue != null)
													{
														IPlayerLoopItem playerLoopItem2 = waitQueue.Dequeue();
														bool flag6 = loopItems == null;
														num2 = 0;
														if (!flag6)
														{
															if (playerLoopItem2 != null)
															{
																nint num5 = (nint)array5;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1665 @ rax_v121 (Il2CppClass<Cysharp.Threading.Tasks.IPlayerLoopItem[]>)+40]");
																Array.Resize(ref *(IPlayerLoopItem[]*)playerLoopItem2, 0);
																if (obj21 == null)
																{
																	ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
																	int newSize = 0;
																	ArrayTypeMismatchException ex = ex2;
																	throw ex2;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															num2 = tail;
															continue;
														}
														throw new NullReferenceException();
													}
													throw new NullReferenceException();
												}
												throw new NullReferenceException();
											}
											ArgumentException ex3 = new ArgumentException();
											throw ex3;
										}
										ArgumentNullException ex4 = new ArgumentNullException("obj");
										throw ex4;
									}
									Monitor.ThrowLockTakenException();
									throw null;
									IL_02bf:
									bool flag7 = loopItems == null;
									playerLoopItem = array2[obj7];
									if (!flag7)
									{
										nint num6 = (nint)array3;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										bool flag8 = obj22 == null;
										playerLoopItem = array2[obj7];
										if (flag8)
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										bool flag9 = loopItems == null;
										playerLoopItem = array2[obj7];
										if (!flag9)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											obj7--;
											num++;
											playerLoopItem = null;
											continue;
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
								throw ex5;
							}
							ArgumentException ex6 = new ArgumentException();
							throw ex6;
						}
						ArgumentNullException ex7 = new ArgumentNullException("obj");
						throw ex7;
					}
					Monitor.ThrowLockTakenException();
					return;
				}
				ArgumentException ex8 = new ArgumentException();
				obj4 = 0;
				throw ex8;
			}
			ArgumentNullException ex9 = new ArgumentNullException("obj");
			ex9._002Ector("obj");
			playerLoopItem = null;
			throw ex9;
		}
		Monitor.ThrowLockTakenException();
		throw null;
	}
}
