using System;
using System.Collections;
using System.Threading;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks.Internal;

internal sealed class ContinuationQueue
{
	private const int MaxArrayLength = 2146435071;

	private const int InitialSize = 16;

	private readonly PlayerLoopTiming timing;

	private SpinLock gate;

	private bool dequing;

	private int actionListCount;

	private Action[] actionList;

	private int waitingListCount;

	private Action[] waitingList;

	public ContinuationQueue(PlayerLoopTiming timing)
	{
		//IL_003c: Expected O, but got I8
		gate = (SpinLock)2147483648L;
		Action[] array = new Action[16];
		actionList = array;
		Action[] array2 = new Action[16];
		waitingList = array2;
		this.timing = timing;
	}

	public unsafe void Enqueue(Action continuation)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0408: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Expected O, but got Unknown
		//IL_00ab: Expected O, but got I
		//IL_0441: Unknown result type (might be due to invalid IL or missing references)
		//IL_0446: Expected O, but got Unknown
		//IL_02e8: Expected O, but got I4
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		//IL_00d4: Expected O, but got I4
		//IL_0312: Expected I, but got O
		//IL_00fe: Expected I, but got O
		//IL_0380: Expected O, but got I
		//IL_016c: Expected O, but got I
		//IL_06c4: Expected I, but got O
		//IL_0620: Expected I, but got O
		//IL_03db: Expected O, but got I
		//IL_01c7: Expected O, but got I
		ArgumentNullException ex = default(ArgumentNullException);
		SpinLock spinLock = (SpinLock)(ex + 20);
		bool lockTaken = default(bool);
		((SpinLock*)spinLock)->Enter(ref lockTaken);
		int length = default(int);
		if (((Exception)ex)._message == null)
		{
			IDictionary data = ((Exception)ex)._data;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v26 (System.Collections.IDictionary)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ stack_8_v2 (System.ArgumentNullException)+1C]");
			bool flag = num != 0;
			ArgumentNullException ex2 = ex;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ stack_8_v2 (System.ArgumentNullException)+1C]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ stack_8_v2 (System.ArgumentNullException)+1C]");
				object obj = num2 + 0;
				if ((nint)obj > 2146435071)
				{
					obj = 2146435071;
				}
				Action[] array = new Action[obj];
				Array data2 = (Array)((Exception)ex)._data;
				if (((Exception)ex)._data == null)
				{
					ArgumentNullException ex3 = new ArgumentNullException("sourceArray");
					throw ex3;
				}
				if (array == null)
				{
					ArgumentNullException ex4 = new ArgumentNullException("destinationArray");
					throw ex4;
				}
				nint num3 = (nint)data2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v799 @ rax_v92 (Il2CppClass<System.Array>)+132]");
				if ((nint)0 <= (nint)0)
				{
					IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
					throw ex5;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ r10_v15 (System.Array)+10]");
				int sourceIndex;
				if ((nint)0 == 0)
				{
					sourceIndex = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ r10_v15 (System.Array)+10]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v860 @ rax_v110+8]");
					sourceIndex = 0;
				}
				nint num4 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v877 @ rax_v99 (Il2CppClass<System.Array>)+132]");
				if ((nint)0 <= (nint)0)
				{
					IndexOutOfRangeException ex6 = new IndexOutOfRangeException();
					throw ex6;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rax_v91 (System.Action[])+10]");
				int destinationIndex;
				if ((nint)0 == 0)
				{
					destinationIndex = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rax_v91 (System.Action[])+10]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ rax_v109+8]");
					destinationIndex = 0;
				}
				Array.Copy((Array)((Exception)ex)._data, sourceIndex, array, destinationIndex, length);
				((Exception)ex)._data = (IDictionary)(object)array;
				ex2 = ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ stack_8_v2 (System.ArgumentNullException)+1C]");
			_ = (nint)0 + (nint)1;
			if (lockTaken)
			{
				SpinLock spinLock2 = (SpinLock)(ex + 20);
				((SpinLock*)spinLock2)->Exit(useMemoryBarrier: false);
			}
			return;
		}
		string helpURL = ((Exception)ex)._helpURL;
		bool flag2 = ((Exception)ex)._helpURL == null;
		ArgumentNullException ex7 = ex;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdx_v16 (System.String)+18]");
			bool flag3 = 0 != (nint)((Exception)ex)._innerException;
			ArgumentNullException ex8 = ex;
			if (!flag3)
			{
				object obj4 = (object)((Exception)ex)._innerException + (object)((Exception)ex)._innerException;
				if ((nint)obj4 > 2146435071)
				{
					obj4 = 2146435071;
				}
				Action[] array2 = new Action[obj4];
				Array helpURL2 = (Array)(object)((Exception)ex)._helpURL;
				if (((Exception)ex)._helpURL == null)
				{
					ArgumentNullException ex9 = new ArgumentNullException("sourceArray");
					ex7 = ex9;
					throw ex9;
				}
				if (array2 == null)
				{
					ArgumentNullException ex10 = new ArgumentNullException("destinationArray");
					throw ex10;
				}
				nint num5 = (nint)helpURL2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rax_v48 (Il2CppClass<System.Array>)+132]");
				if ((nint)0 <= (nint)0)
				{
					IndexOutOfRangeException ex11 = new IndexOutOfRangeException();
					throw ex11;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ r10_v9 (System.Array)+10]");
				int sourceIndex2;
				if ((nint)0 == 0)
				{
					sourceIndex2 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ r10_v9 (System.Array)+10]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v870 @ rax_v61+8]");
					sourceIndex2 = 0;
				}
				nint num6 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rax_v50 (Il2CppClass<System.Array>)+132]");
				if ((nint)0 <= (nint)0)
				{
					IndexOutOfRangeException ex12 = new IndexOutOfRangeException();
					throw ex12;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ rax_v47 (System.Action[])+10]");
				int destinationIndex;
				if ((nint)0 == 0)
				{
					destinationIndex = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ rax_v47 (System.Action[])+10]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v926 @ rax_v60+8]");
					destinationIndex = 0;
				}
				Array.Copy((Array)(object)((Exception)ex)._helpURL, sourceIndex2, array2, destinationIndex, length);
				((Exception)ex)._helpURL = (string)(object)array2;
				ex8 = ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Exception innerException = (Exception)(((Exception)ex)._innerException + 1);
			((Exception)ex)._innerException = innerException;
			if (lockTaken)
			{
				SpinLock spinLock3 = (SpinLock)(ex + 20);
				((SpinLock*)spinLock3)->Exit(useMemoryBarrier: false);
			}
			return;
		}
		throw new NullReferenceException();
	}

	public int Clear()
	{
		actionListCount = 0;
		Action[] array = new Action[16];
		actionList = array;
		waitingListCount = 0;
		Action[] array2 = new Action[16];
		waitingList = array2;
		return waitingListCount + actionListCount;
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
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00dc: Expected O, but got I4
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected O, but got Unknown
		//IL_00f1: Expected O, but got I
		//IL_0126: Expected O, but got I
		//IL_0136: Expected O, but got I
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected O, but got Unknown
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected O, but got Unknown
		object obj = default(object);
		SpinLock spinLock = (SpinLock)(obj + 20);
		bool lockTaken = default(bool);
		((SpinLock*)spinLock)->Enter(ref lockTaken);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2+1C]");
		if ((nint)0 != 0)
		{
			_ = 1;
			if (lockTaken)
			{
				spinLock = (SpinLock)(obj + 20);
				((SpinLock*)spinLock)->Exit(useMemoryBarrier: false);
			}
			SpinLock spinLock2 = (SpinLock)0;
			object obj4 = default(object);
			bool lockTaken2 = default(bool);
			while (true)
			{
				SpinLock spinLock3 = spinLock2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2+1C]");
				if ((nint)spinLock3 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2+20]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2+20]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rdi_v4+20+v225 @ rbx_v8 (System.Threading.SpinLock)*8]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2+20]");
						spinLock = (SpinLock)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2+20]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rdi_v4+20+v225 @ rbx_v8 (System.Threading.SpinLock)*8]");
							if ((nint)0 == 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v224 @ rdi_v7+18] (should have been resolved before IL gen)");
							spinLock2 = (SpinLock)(spinLock2 + 1);
							continue;
						}
					}
					throw new NullReferenceException();
				}
				SpinLock spinLock4 = (SpinLock)(obj4 + 20);
				((SpinLock*)spinLock4)->Enter(ref lockTaken2);
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ stack_8_v4+28]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ stack_8_v4+30]");
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ stack_8_v4+20]");
				_ = 0;
				if (lockTaken2)
				{
					SpinLock spinLock5 = (SpinLock)(obj4 + 20);
					((SpinLock*)spinLock5)->Exit(useMemoryBarrier: false);
				}
				return;
			}
			throw new NullReferenceException();
		}
		if (lockTaken)
		{
			SpinLock spinLock6 = (SpinLock)(obj + 20);
			((SpinLock*)spinLock6)->Exit(useMemoryBarrier: false);
		}
	}
}
