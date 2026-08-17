using System;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

public class UniTaskSynchronizationContext : SynchronizationContext
{
	[StructLayout((LayoutKind)3)]
	private struct Callback(SendOrPostCallback callback, object state)
	{
		private readonly SendOrPostCallback callback = callback;

		private readonly object state = state;

		public void Invoke()
		{
			SendOrPostCallback sendOrPostCallback = callback;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private const int MaxArrayLength = 2146435071;

	private const int InitialSize = 16;

	private static SpinLock gate;

	private static bool dequing;

	private static int actionListCount;

	private static Callback[] actionList;

	private static int waitingListCount;

	private static Callback[] waitingList;

	private static int opCount;

	public override void Send(SendOrPostCallback d, object state)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: d.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
	}

	public unsafe override void Post(SendOrPostCallback d, object state)
	{
		//IL_0018: Expected I, but got O
		//IL_07a8: Expected O, but got I4
		//IL_0223: Expected O, but got Ref
		//IL_0646: Expected O, but got I4
		//IL_02bd: Expected O, but got I4
		//IL_0240: Expected O, but got I4
		//IL_0093: Expected O, but got I4
		//IL_046a: Expected O, but got I4
		//IL_04a8: Expected I, but got O
		//IL_059f: Expected I, but got O
		//IL_02e7: Expected I, but got O
		//IL_00bd: Expected I, but got O
		//IL_0355: Expected O, but got I
		//IL_012b: Expected O, but got I
		//IL_07f7: Expected I, but got O
		//IL_0695: Expected I, but got O
		//IL_03b0: Expected O, but got I
		//IL_0186: Expected O, but got I
		//IL_0850: Expected I, but got O
		//IL_0866: Expected O, but got I
		//IL_06ee: Expected I, but got O
		//IL_0704: Expected O, but got I
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e1: Expected O, but got Unknown
		//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Expected O, but got Unknown
		//IL_040a: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Expected O, but got Unknown
		//IL_0418: Unknown result type (might be due to invalid IL or missing references)
		//IL_041d: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected O, but got Unknown
		//IL_0970: Expected O, but got I4
		//IL_0980: Unknown result type (might be due to invalid IL or missing references)
		//IL_0985: Expected O, but got Unknown
		//IL_08f4: Expected O, but got I4
		//IL_0904: Unknown result type (might be due to invalid IL or missing references)
		//IL_0909: Expected O, but got Unknown
		nint num = (nint)typeof(UniTaskSynchronizationContext);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v4 (Il2CppClass<Cysharp.Threading.Tasks.UniTaskSynchronizationContext>)+B8]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v4 (Il2CppClass<Cysharp.Threading.Tasks.UniTaskSynchronizationContext>)+B8]");
		bool lockTaken = default(bool);
		((SpinLock*)null)->Enter(ref lockTaken);
		int length = default(int);
		object obj13 = default(object);
		if (!dequing)
		{
			Callback[] array = actionList;
			if (array.Length == actionListCount)
			{
				object obj = actionListCount + actionListCount;
				if ((nint)obj > 2146435071)
				{
					obj = 2146435071;
				}
				Callback[] array2 = new Callback[obj];
				Array array3 = actionList;
				if (actionList == null)
				{
					ArgumentNullException ex = new ArgumentNullException("sourceArray");
					throw ex;
				}
				if (array2 == null)
				{
					ArgumentNullException ex2 = new ArgumentNullException("destinationArray");
					throw ex2;
				}
				nint num3 = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1102 @ rax_v132 (Il2CppClass<System.Array>)+132]");
				if ((nint)0 <= (nint)0)
				{
					IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
					throw ex3;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ r10_v19 (System.Array)+10]");
				int sourceIndex;
				if ((nint)0 == 0)
				{
					sourceIndex = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ r10_v19 (System.Array)+10]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1327 @ rax_v150+8]");
					sourceIndex = 0;
				}
				nint num4 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1347 @ rax_v139 (Il2CppClass<System.Array>)+132]");
				if ((nint)0 <= (nint)0)
				{
					IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
					throw ex4;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ rax_v115 (Callback[])+10]");
				int destinationIndex;
				if ((nint)0 == 0)
				{
					destinationIndex = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ rax_v115 (Callback[])+10]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1400 @ rax_v149+8]");
					destinationIndex = 0;
				}
				Array.Copy(actionList, sourceIndex, array2, destinationIndex, length);
				actionList = array2;
				nint num5 = (nint)typeof(UniTaskSynchronizationContext);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rdx_v63 (Il2CppClass<Cysharp.Threading.Tasks.UniTaskSynchronizationContext>)+B8]");
				object obj4 = (nint)0 + (nint)16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				if ((nint)0 != 0)
				{
					object obj5 = obj4 >> 12;
					object obj6 = obj5 & 0x1FFFFF;
					object obj7 = obj6 >> 6;
					object obj8 = obj7 * 8;
					object obj9 = 6603577472L + obj8;
					object obj10 = obj6 & 0x3F;
					nint num7;
					do
					{
						object obj11 = 1 << (int)obj10;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1419 @ rdx_v64+462E0]");
						object obj12 = 0 | obj11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1419 @ rdx_v64+462E0]");
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1419 @ rdx_v64+462E0]");
						if (num6 == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1419 @ rdx_v64+462E0]");
						num7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1419 @ rdx_v64+462E0]");
					}
					while (num7 != 0);
				}
			}
			Callback[] array4 = actionList;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
			bool flag = actionListCount >= array4.Length;
			ArgumentNullException ex5 = (ArgumentNullException)(&obj13);
			if (!flag)
			{
				object obj14 = actionListCount + 2;
				object obj15 = obj14 + obj14;
				int num8 = actionListCount + 1;
				actionListCount = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185D722F0");
				ex5 = null;
				return;
			}
			throw new IndexOutOfRangeException();
		}
		Callback[] array5 = waitingList;
		if (waitingList != null)
		{
			if (array5.Length == waitingListCount)
			{
				object obj16 = waitingListCount + waitingListCount;
				if ((nint)obj16 > 2146435071)
				{
					obj16 = 2146435071;
				}
				Callback[] array6 = new Callback[obj16];
				Array array7 = waitingList;
				if (waitingList == null)
				{
					ArgumentNullException ex6 = new ArgumentNullException("sourceArray");
					num2 = (nint)ex6;
					throw ex6;
				}
				if (array6 == null)
				{
					ArgumentNullException ex7 = new ArgumentNullException("destinationArray");
					throw ex7;
				}
				nint num9 = (nint)array7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rax_v68 (Il2CppClass<System.Array>)+132]");
				if ((nint)0 <= (nint)0)
				{
					IndexOutOfRangeException ex8 = new IndexOutOfRangeException();
					throw ex8;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ r10_v12 (System.Array)+10]");
				int sourceIndex2;
				if ((nint)0 == 0)
				{
					sourceIndex2 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ r10_v12 (System.Array)+10]");
					object obj17 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1340 @ rax_v81+8]");
					sourceIndex2 = 0;
				}
				nint num10 = (nint)array6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ rax_v70 (Il2CppClass<System.Array>)+132]");
				if ((nint)0 <= (nint)0)
				{
					IndexOutOfRangeException ex9 = new IndexOutOfRangeException();
					throw ex9;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v641 @ rax_v65 (Callback[])+10]");
				int destinationIndex2;
				if ((nint)0 == 0)
				{
					destinationIndex2 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v641 @ rax_v65 (Callback[])+10]");
					object obj18 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1403 @ rax_v80+8]");
					destinationIndex2 = 0;
				}
				Array.Copy(waitingList, sourceIndex2, array6, destinationIndex2, length);
				waitingList = array6;
				nint num11 = (nint)typeof(UniTaskSynchronizationContext);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ rdx_v31 (Il2CppClass<Cysharp.Threading.Tasks.UniTaskSynchronizationContext>)+B8]");
				object obj19 = (nint)0 + (nint)32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				if ((nint)0 != 0)
				{
					object obj20 = obj19 >> 12;
					object obj21 = obj20 & 0x1FFFFF;
					object obj22 = obj21 >> 6;
					object obj23 = obj22 * 8;
					object obj24 = 6603577472L + obj23;
					object obj25 = obj21 & 0x3F;
					nint num13;
					do
					{
						object obj26 = 1 << (int)obj25;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1425 @ rdx_v32+462E0]");
						object obj27 = 0 | obj26;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1425 @ rdx_v32+462E0]");
						nint num12 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1425 @ rdx_v32+462E0]");
						if (num12 == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1425 @ rdx_v32+462E0]");
						num13 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1425 @ rdx_v32+462E0]");
					}
					while (num13 != 0);
				}
			}
			Callback[] array8 = waitingList;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
			bool flag2 = waitingList == null;
			num2 = (nint)(&obj13);
			if (!flag2)
			{
				bool flag3 = waitingListCount >= array8.Length;
				num2 = (nint)(&obj13);
				if (!flag3)
				{
					object obj28 = waitingListCount + 2;
					object obj29 = obj28 + obj28;
					int num14 = waitingListCount + 1;
					waitingListCount = num14;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185D722F0");
					num2 = unchecked((nint)null);
					return;
				}
				throw new IndexOutOfRangeException();
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public override void OperationStarted()
	{
		opCount++;
	}

	public override void OperationCompleted()
	{
		opCount--;
	}

	public override SynchronizationContext CreateCopy()
	{
		return this;
	}

	internal unsafe static void Run()
	{
		//IL_0018: Expected I, but got O
		//IL_0064: Expected I, but got O
		//IL_0077: Expected O, but got I4
		//IL_02f7: Expected I, but got O
		//IL_0148: Expected I, but got O
		//IL_01ff: Expected I4, but got I8
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_00ae: Expected I, but got O
		//IL_0344: Expected I, but got O
		//IL_035a: Expected O, but got I
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected O, but got Unknown
		//IL_0236: Expected I, but got O
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		nint num = (nint)typeof(UniTaskSynchronizationContext);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v4 (Il2CppClass<Cysharp.Threading.Tasks.UniTaskSynchronizationContext>)+B8]");
		bool lockTaken = default(bool);
		((SpinLock*)null)->Enter(ref lockTaken);
		if (actionListCount == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185D722F0");
			nint num2 = unchecked((nint)null);
			return;
		}
		dequing = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185D722F0");
		object obj = 0;
		Callback callback = default(Callback);
		bool lockTaken2 = default(bool);
		while (true)
		{
			nint num2 = (nint)typeof(UniTaskSynchronizationContext);
			if ((nint)obj < actionListCount)
			{
				Callback[] array = actionList;
				if (actionList == null)
				{
					break;
				}
				if ((nint)obj < array.Length)
				{
					num2 = (nint)actionList;
					if (actionList == null)
					{
						break;
					}
					object obj2 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rcx_v7 (Il2CppClass<Cysharp.Threading.Tasks.UniTaskSynchronizationContext>)+18]");
					if ((nint)obj2 < 0)
					{
						object obj3 = obj + 2;
						object obj4 = obj3 + obj3;
						_ = 0;
						callback.Invoke();
						obj++;
						continue;
					}
				}
				throw new IndexOutOfRangeException();
			}
			nint num3 = (nint)typeof(UniTaskSynchronizationContext);
			Thread.BeginCriticalRegion();
			if (!lockTaken2)
			{
				object obj5 = gate & 0x80000001L;
				if ((long)obj5 == 2147483648L)
				{
					SpinLock spinLock = (SpinLock)(gate | 1);
					bool flag = (object)gate == (object)gate;
					if ((object)gate == (object)gate)
					{
						gate = spinLock;
					}
					if (flag)
					{
						goto IL_0204;
					}
					lockTaken2 = false;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v29 (Il2CppClass<Cysharp.Threading.Tasks.UniTaskSynchronizationContext>)+B8]");
			((SpinLock*)null)->ContinueTryEnter(-1, ref lockTaken2);
			goto IL_0204;
			IL_0204:
			dequing = false;
			actionListCount = waitingListCount;
			actionList = waitingList;
			waitingListCount = 0;
			waitingList = actionList;
			nint num4 = (nint)typeof(UniTaskSynchronizationContext);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v594 @ rax_v45 (Il2CppClass<Cysharp.Threading.Tasks.UniTaskSynchronizationContext>)+B8]");
			object obj6 = (nint)0 + (nint)32;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185D722F0");
			num2 = unchecked((nint)null);
			return;
		}
		throw new NullReferenceException();
	}

	static UniTaskSynchronizationContext()
	{
		//IL_003a: Expected O, but got I8
		gate = (SpinLock)2147483648L;
		dequing = false;
		actionListCount = 0;
		Callback[] array = new Callback[16];
		actionList = array;
		waitingListCount = 0;
		Callback[] array2 = new Callback[16];
		waitingList = array2;
	}
}
