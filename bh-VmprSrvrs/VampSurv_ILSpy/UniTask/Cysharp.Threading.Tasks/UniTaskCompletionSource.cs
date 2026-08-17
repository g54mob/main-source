using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks.Sources;
using Cpp2ILInjected;
using Unity.IL2CPP.Metadata;

namespace Cysharp.Threading.Tasks;

public class UniTaskCompletionSource : IUniTaskSource, IValueTaskSource, IPromise, IResolvePromise, IRejectPromise, ICancelPromise
{
	private CancellationToken cancellationToken;

	private ExceptionHolder exception;

	private object gate;

	private Action<object> singleContinuation;

	private object singleState;

	private List<(Action<object>, object)> secondaryContinuationList;

	private int intStatus;

	private bool handled;

	public unsafe UniTask Task
	{
		get
		{
			//IL_0009: Expected native int or pointer, but got O
			//IL_0013: Expected native int or pointer, but got O
			//IL_0026: Expected native int or pointer, but got O
			UniTask uniTask = default(UniTask);
			((UniTask*)(nint)uniTask)->token = 0;
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, this);
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
	}

	internal void MarkHandled()
	{
		if (!handled)
		{
			handled = true;
		}
	}

	public bool TrySetResult()
	{
		return TrySignalCompletion(UniTaskStatus.Succeeded);
	}

	public bool TrySetCanceled(CancellationToken cancellationToken = default(CancellationToken))
	{
		if (intStatus == 0)
		{
			this.cancellationToken = cancellationToken;
			return TrySignalCompletion(UniTaskStatus.Canceled);
		}
		return false;
	}

	public bool TrySetException(Exception exception)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		//IL_00cf: Expected O, but got I
		bool flag = exception == null;
		IntPtr intPtr = default(IntPtr);
		nint num = intPtr;
		if (flag)
		{
			goto IL_00d8;
		}
		nint num2 = (nint)typeof(OperationCanceledException);
		num = (nint)exception;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdx_v10 (Il2CppClass<System.OperationCanceledException>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r8_v1 (Il2CppClass<System.Exception>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdx_v10 (Il2CppClass<System.OperationCanceledException>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r8_v1 (Il2CppClass<System.Exception>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v31+FFFFFFF8+v48 @ rax_v26*8]");
			if (0 == (nint)typeof(OperationCanceledException))
			{
				obj3 = 1;
				goto IL_01ae;
			}
		}
		obj3 = 0;
		goto IL_01ae;
		IL_00d8:
		if (intStatus != 0)
		{
			return false;
		}
		if (exception != null)
		{
			ExceptionDispatchInfo exceptionDispatchInfo = new ExceptionDispatchInfo(exception);
			ExceptionHolder exceptionHolder = new ExceptionHolder(exceptionDispatchInfo);
			this.exception = exceptionHolder;
			return TrySignalCompletion(UniTaskStatus.Faulted);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52F00");
		string message = default(string);
		ArgumentNullException ex = new ArgumentNullException("source", message);
		throw ex;
		IL_01ae:
		bool flag2 = obj3 == null;
		Exception ex2 = null;
		if (!flag2)
		{
			ex2 = exception;
		}
		if (ex2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v12 (System.Exception)+90]");
			return TrySetCanceled((CancellationToken)0);
		}
		goto IL_00d8;
	}

	public void GetResult(short token)
	{
		//IL_0042: Expected O, but got I4
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		if (!handled)
		{
			handled = true;
		}
		bool flag = intStatus == 0;
		if (!flag)
		{
			object obj = intStatus - 1;
			if (flag)
			{
				return;
			}
			object obj2 = obj - 1;
			if (flag)
			{
				throw new NullReferenceException();
			}
			if ((nint)obj2 == 1)
			{
				OperationCanceledException ex = new OperationCanceledException(cancellationToken);
				throw ex;
			}
		}
		object obj3 = new InvalidOperationException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E209C0");
		throw obj3;
	}

	public UniTaskStatus GetStatus(short token)
	{
		return (UniTaskStatus)intStatus;
	}

	public UniTaskStatus UnsafeGetStatus()
	{
		return (UniTaskStatus)intStatus;
	}

	public unsafe void OnCompleted(Action<object> continuation, object state, short token)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_032a: Expected I, but got O
		//IL_033a: Expected O, but got Ref
		//IL_0343: Expected O, but got I4
		//IL_04a0: Expected O, but got I4
		//IL_04b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b5: Expected O, but got Unknown
		//IL_02b1: Expected O, but got I
		//IL_02ef: Expected O, but got Ref
		//IL_0247: Expected O, but got I8
		//IL_01aa: Expected O, but got I4
		//IL_0280: Expected O, but got Ref
		//IL_01c7: Expected O, but got Ref
		//IL_0478: Expected O, but got I
		//IL_020f: Expected O, but got Ref
		//IL_0448: Expected O, but got I
		if (gate == null)
		{
			object obj = this + 32;
			object obj2 = new object();
			if (0 == (nint)obj)
			{
				obj = obj2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			if ((nint)0 != 0)
			{
				object obj3 = obj >> 12;
				object obj4 = obj3 & 0x1FFFFF;
				object obj5 = obj4 >> 6;
				object obj6 = obj5 * 8;
				object obj7 = 6603577472L + obj6;
				object obj8 = obj4 & 0x3F;
				nint num2;
				do
				{
					object obj9 = 1 << (int)obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v28+462E0]");
					object obj10 = 0 | obj9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v28+462E0]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v28+462E0]");
					if (num == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v28+462E0]");
					num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v28+462E0]");
				}
				while (num2 != 0);
			}
		}
		object obj11 = default(object);
		if (obj11 == null)
		{
			object obj12 = default(object);
			if (obj12 != null)
			{
				object obj13 = default(object);
				nint num4 = default(nint);
				nint num3;
				(Action<object>, object) tuple2;
				(Action<object>, object) item2;
				if (obj11 == null)
				{
					Monitor.Enter(obj12);
					object obj14 = default(object);
					object obj15;
					if (intStatus == 0)
					{
						Action<object> item = default(Action<object>);
						if (singleContinuation != null)
						{
							if (secondaryContinuationList == null)
							{
								List<(Action<object>, object)> list = new List<(Action<object>, object)>();
								secondaryContinuationList = list;
							}
							(Action<object>, object) tuple = (item, obj13);
							bool flag = secondaryContinuationList == null;
							num3 = 0;
							tuple2 = ((Action<object>, object))0;
							if (!flag)
							{
								(Action<object>, object) tuple3 = default((Action<object>, object));
								secondaryContinuationList.Add(((Action<object>, object))(&tuple3));
								if (obj14 != null)
								{
									bool flag2 = obj12 == null;
									num4 = 0;
									num3 = 0;
									tuple2 = tuple;
									item2 = ((Action<object>, object))(&tuple3);
									if (flag2)
									{
										System.Runtime.CompilerServices.Unsafe.Write((void*)6586836376L, (ValueTuple<Action<object>, object>)((Action<object>)item2, num4));
										item = null;
										(Action<object>, object) tuple4 = default((Action<object>, object));
										throw tuple4;
									}
									Monitor.Exit(obj12);
								}
								return;
							}
							throw new NullReferenceException();
						}
						singleContinuation = item;
						item = (Action<object>)4294967295L;
						singleState = obj13;
						if (obj14 != null)
						{
							bool flag3 = obj12 == null;
							tuple2 = ((Action<object>, object))(&obj11);
							if (flag3)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
								obj15 = num4;
								object obj16 = null;
								object obj17 = default(object);
								throw obj17;
							}
							Monitor.Exit(obj12);
						}
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v736 @ rdx_v7 (System.Action`1<System.Object>)+28]");
					obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v736 @ rdx_v7 (System.Action`1<System.Object>)+18] (should have been resolved before IL gen)");
					if (obj14 != null)
					{
						bool flag4 = obj12 == null;
						tuple2 = ((Action<object>, object))(&obj11);
						object obj16 = obj13;
						if (flag4)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
							object obj18 = default(object);
							throw obj18;
						}
						Monitor.Exit(obj12);
					}
					return;
				}
				ArgumentException ex = new ArgumentException();
				num4 = (nint)obj13;
				short num5 = default(short);
				num3 = num5;
				tuple2 = ((Action<object>, object))(&obj11);
				item2 = ((Action<object>, object))0;
				throw ex;
			}
			ArgumentNullException ex2 = new ArgumentNullException("obj");
			throw ex2;
		}
		Monitor.ThrowLockTakenException();
		throw null;
	}

	private unsafe bool TrySignalCompletion(UniTaskStatus status)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_0291: Expected I, but got O
		//IL_0440: Expected O, but got I4
		//IL_0450: Unknown result type (might be due to invalid IL or missing references)
		//IL_0455: Expected O, but got Unknown
		//IL_0155: Expected I, but got I8
		//IL_03af: Expected O, but got Ref
		//IL_018b: Expected I, but got I8
		//IL_03c5: Expected O, but got Ref
		//IL_01a6: Expected I, but got O
		//IL_01b0: Expected I, but got O
		//IL_0228: Expected O, but got Ref
		bool flag = 0 == intStatus;
		if (0 == intStatus)
		{
			intStatus = (int)status;
		}
		if (!flag)
		{
			return false;
		}
		if (gate == null)
		{
			object obj = this + 32;
			object obj2 = new object();
			if (0 == (nint)obj)
			{
				obj = obj2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			if ((nint)0 != 0)
			{
				object obj3 = obj >> 12;
				object obj4 = obj3 & 0x1FFFFF;
				object obj5 = obj4 >> 6;
				object obj6 = obj5 * 8;
				object obj7 = 6603577472L + obj6;
				object obj8 = obj4 & 0x3F;
				nint num2;
				do
				{
					object obj9 = 1 << (int)obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rdx_v28+462E0]");
					object obj10 = 0 | obj9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rdx_v28+462E0]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rdx_v28+462E0]");
					if (num == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rdx_v28+462E0]");
					num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rdx_v28+462E0]");
				}
				while (num2 != 0);
			}
		}
		object obj11 = default(object);
		if (obj11 == null)
		{
			object obj12 = default(object);
			if (obj12 != null)
			{
				nint num3;
				if (obj11 == null)
				{
					Monitor.Enter(obj12);
					bool flag2 = singleContinuation == null;
					num3 = unchecked((nint)4294967295L);
					List<(Action<object>, object)>.Enumerator enumerator;
					if (!flag2)
					{
						ArgumentException ex = (ArgumentException)(object)singleContinuation;
						bool flag3 = singleContinuation == null;
						num3 = unchecked((nint)4294967295L);
						if (flag3)
						{
							enumerator = (List<(Action<object>, object)>.Enumerator)(&obj11);
							throw new NullReferenceException();
						}
						nint num4 = (nint)((Exception)ex)._innerException;
						num3 = (nint)singleState;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v583._message (System.String) (should have been resolved before IL gen)");
					}
					bool flag4 = secondaryContinuationList == null;
					enumerator = (List<(Action<object>, object)>.Enumerator)(&obj11);
					if (!flag4)
					{
						List<(Action<object>, object)>.Enumerator enumerator2 = default(List<(Action<object>, object)>.Enumerator);
						ArgumentException ex3;
						if (enumerator2.MoveNext())
						{
							ArgumentException ex2 = null;
							ex3 = null;
							enumerator = (List<(Action<object>, object)>.Enumerator)secondaryContinuationList;
							IntPtr intPtr = default(IntPtr);
							num3 = intPtr;
							ArgumentException ex = null;
							throw new NullReferenceException();
						}
						ex3 = null;
						enumerator = (List<(Action<object>, object)>.Enumerator)secondaryContinuationList;
						num3 = 0;
					}
					singleContinuation = null;
					singleState = null;
					secondaryContinuationList = null;
					List<(Action<object>, object)>.Enumerator enumerator3 = (List<(Action<object>, object)>.Enumerator)(&obj11);
					if ((object)enumerator3 != null)
					{
						object obj13 = default(object);
						if (obj13 == null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
							object obj14 = default(object);
							throw obj14;
						}
						Monitor.Exit(obj13);
					}
					return true;
				}
				ArgumentException ex4 = new ArgumentException();
				num3 = unchecked((nint)null);
				throw ex4;
			}
			ArgumentNullException ex5 = new ArgumentNullException("obj");
			ex5._002Ector("obj");
			throw ex5;
		}
		Monitor.ThrowLockTakenException();
		throw null;
	}
}
public class UniTaskCompletionSource<T> : IUniTaskSource<T>, IUniTaskSource, IValueTaskSource, IValueTaskSource<T>, IPromise<T>, IResolvePromise<T>, IRejectPromise, ICancelPromise
{
	private CancellationToken cancellationToken;

	private T result;

	private ExceptionHolder exception;

	private object gate;

	private Action<object> singleContinuation;

	private object singleState;

	private List<(Action<object>, object)> secondaryContinuationList;

	private int intStatus;

	private bool handled;

	public unsafe UniTask<T> Task
	{
		get
		{
			//IL_0008: Expected O, but got Ref
			//IL_0018: Expected O, but got I
			//IL_0037: Expected O, but got I
			//IL_0047: Expected O, but got I
			//IL_005d: Expected O, but got I
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Expected O, but got Unknown
			//IL_00d4: Expected O, but got I
			//IL_00e4: Expected O, but got I
			//IL_008e: Expected O, but got I8
			UniTask<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType> uniTask = default(UniTask<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>);
			object obj = (object)(&uniTask);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8+20]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rax_v1+C0]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r9_v1+8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rax_v2+FC]");
			object obj5 = (nint)0 + (nint)15;
			object obj6 = obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rax_v2+FC]");
			if ((nint)obj6 <= 0)
			{
				obj5 = 1152921504606846960L;
			}
			object obj7 = obj5 & -16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8+20]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v6+C0]");
			object obj9 = 0;
			uniTask = new UniTask<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>((IUniTaskSource<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>)this, 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			UniTask<T> uniTask2 = default(UniTask<T>);
			return uniTask2;
		}
	}

	internal void MarkHandled()
	{
		//IL_001e: Expected O, but got I
		//IL_002e: Expected O, but got I
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_009e: Expected O, but got I
		//IL_00ae: Expected O, but got I
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_0118: Expected O, but got I4
		nint num = 0;
		IntPtr intPtr = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>>)+80]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ r8_v2+110]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ r8_v2+118]");
		object obj3 = 0 + this;
		object obj4 = obj3 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rax_v3+28]");
		if ((nint)0 >= (nint)0)
		{
			obj4 = obj3;
		}
		if (obj4 == null)
		{
			nint num2 = 0;
			IntPtr intPtr2 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v6 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>>)+80]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rcx_v3+110]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rcx_v3+118]");
			object obj7 = 0 + this;
			object obj8 = obj7 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v7+28]");
			if ((nint)0 < (nint)0)
			{
				obj8 = 1;
			}
		}
	}

	public unsafe bool TrySetResult(T result)
	{
		//IL_0008: Expected O, but got Ref
		//IL_002d: Expected O, but got I
		//IL_0043: Expected O, but got I
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_0119: Expected O, but got I
		//IL_0074: Expected O, but got I8
		//IL_0087: Expected O, but got Ref
		//IL_009d: Expected O, but got I
		//IL_00b3: Expected O, but got I
		//IL_0177: Expected O, but got I
		//IL_0197: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ r9_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>)+28]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rax_v2+FC]");
		object obj4 = (nint)0 + (nint)15;
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rax_v2+FC]");
		if ((nint)obj5 <= 0)
		{
			obj4 = 1152921504606846960L;
		}
		object obj6 = obj4 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>)+20]");
		object obj7 = 0;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v49 @ rax_v6] (should have been resolved before IL gen)");
		object obj8 = default(object);
		if (obj8 == null)
		{
			T val = (T)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v5 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>)+28]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v12+28]");
			object obj10 = (nint)0 >> 31;
			if (obj10 != null)
			{
				val = result;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			nint num5 = 0;
			IntPtr intPtr = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v15 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>>)+80]");
			object obj11 = (nint)0 + (nint)32;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v11 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>)+30]");
			object obj12 = 0;
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v129 @ rax_v18] (should have been resolved before IL gen)");
			bool flag = default(bool);
			return flag;
		}
		return false;
	}

	public bool TrySetCanceled(CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0016: Expected O, but got I
		//IL_0074: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rdx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>)+20]");
		object obj = 0;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v14 @ rax_v2] (should have been resolved before IL gen)");
		object obj2 = default(object);
		if (obj2 == null)
		{
			nint num3 = 0;
			IntPtr intPtr = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804EC8C0");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v8 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>)+30]");
			object obj3 = 0;
			object obj4 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v51 @ r9_v2 (should have been resolved before IL gen)");
		}
		return false;
	}

	public bool TrySetException(Exception exception)
	{
		//IL_00d3: Expected O, but got I
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_01f0: Expected O, but got I
		//IL_0206: Expected O, but got I
		//IL_0224: Expected O, but got I
		//IL_009d: Expected O, but got I4
		//IL_014c: Expected O, but got I
		//IL_015c: Expected O, but got I
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_01b2: Expected O, but got I
		//IL_01d0: Expected O, but got I
		if (exception == null)
		{
			goto IL_00bd;
		}
		nint num = (nint)typeof(OperationCanceledException);
		nint num2 = (nint)exception;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v13 (Il2CppClass<System.OperationCanceledException>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ r8_v9 (Il2CppClass<System.Exception>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v13 (Il2CppClass<System.OperationCanceledException>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ r8_v9 (Il2CppClass<System.Exception>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rax_v39+FFFFFFF8+v51 @ rax_v32*8]");
			if (0 == (nint)typeof(OperationCanceledException))
			{
				obj3 = 1;
				goto IL_0286;
			}
		}
		obj3 = 0;
		goto IL_0286;
		IL_022e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52F00");
		string message = default(string);
		ArgumentNullException ex = new ArgumentNullException("source", message);
		throw ex;
		IL_00bd:
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rcx_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>)+20]");
		object obj4 = 0;
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v95 @ rax_v4] (should have been resolved before IL gen)");
		object obj5 = default(object);
		if (obj5 == null)
		{
			if (exception == null)
			{
				goto IL_022e;
			}
			ExceptionDispatchInfo exceptionDispatchInfo = new ExceptionDispatchInfo(exception);
			ExceptionHolder exceptionHolder = new ExceptionHolder(exceptionDispatchInfo);
			nint num6 = 0;
			IntPtr intPtr = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rcx_v20 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>>)+80]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rdx_v9+50]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rdx_v9+58]");
			object obj8 = 0 + this;
			object obj9 = obj8 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rcx_v21+28]");
			if ((nint)0 < (nint)0)
			{
				obj9 = exceptionHolder;
			}
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rcx_v23 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>)+30]");
			object obj10 = 0;
			object obj11 = obj10;
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ rcx_v24 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>)+30]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v199 @ r9_v5 (should have been resolved before IL gen)");
		}
		return false;
		IL_0286:
		bool flag = obj3 == null;
		Exception ex2 = null;
		if (!flag)
		{
			ex2 = exception;
		}
		if (ex2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v15 (System.Exception)+90]");
			object obj13 = 0;
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rcx_v32 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>)+38]");
			object obj14 = 0;
			object obj15 = obj14;
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rcx_v33 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>)+38]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v200 @ r9_v10 (should have been resolved before IL gen)");
			goto IL_022e;
		}
		goto IL_00bd;
	}

	public unsafe T GetResult(short token)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0018: Expected O, but got I
		//IL_0037: Expected O, but got I
		//IL_0047: Expected O, but got I
		//IL_005d: Expected O, but got I
		//IL_0265: Expected O, but got I
		//IL_02a8: Expected O, but got I
		//IL_02b8: Expected O, but got I
		//IL_02c8: Expected O, but got I
		//IL_02e2: Expected O, but got I
		//IL_02f2: Expected O, but got I
		//IL_030a: Expected O, but got I
		//IL_031a: Expected O, but got I
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Expected O, but got Unknown
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_011d: Expected O, but got I
		//IL_012d: Expected O, but got I
		//IL_0145: Expected O, but got I
		//IL_0155: Expected O, but got I
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00c3: Expected O, but got I
		//IL_038c: Expected O, but got I
		//IL_00f5: Expected O, but got I
		//IL_03bf: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r9+20]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rax_v1+C0]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rdx_v1+28]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rax_v2+FC]");
		object obj6 = (nint)0 + (nint)15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rax_v2+FC]");
		object obj16 = default(object);
		object obj17;
		if ((nint)obj6 > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rax_v2+FC]");
			object obj7 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rax_v2+FC]");
			if ((nint)obj7 <= 0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r9+20]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v12+C0]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v3+40]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v70 @ rax_v13] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r9+20]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rax_v15+C0]");
			object obj12 = 0;
			object obj13 = obj12;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v16+80]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v6+F0]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v6+F8]");
			obj16 = 0 + this;
			obj17 = obj16 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v17+28]");
			if ((nint)0 < (nint)0)
			{
				goto IL_035f;
			}
		}
		obj17 = obj16;
		goto IL_035f;
		IL_035f:
		bool flag = obj17 == null;
		if (!flag)
		{
			object obj18 = obj17 - 1;
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r9+20]");
				object obj19 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v39+C0]");
				object obj20 = 0;
				object obj21 = obj20;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rax_v40+80]");
				object obj22 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rcx_v33+30]");
				object obj23 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rcx_v33+38]");
				object obj24 = 0 + this;
				object obj25 = obj24 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v41+28]");
				if ((nint)0 >= (nint)0)
				{
					obj25 = obj24;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				T val = default(T);
				return val;
			}
			object obj26 = obj18 - 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rax_v2+FC]");
			object obj27 = 0;
			UniTaskCompletionSource<T> uniTaskCompletionSource = this;
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r9+20]");
				object obj28 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002B70");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D1AC0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7150");
				throw new NullReferenceException();
			}
			bool flag2 = (nint)obj26 == 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rax_v2+FC]");
			object obj29 = 0;
			if (flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r9+20]");
				object obj30 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002B70");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D1AC0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7150");
				object obj31 = default(object);
				uniTaskCompletionSource = (UniTaskCompletionSource<T>)obj31;
				OperationCanceledException ex = new OperationCanceledException((CancellationToken)obj31);
				throw ex;
			}
		}
		UniTaskCompletionSource<T> uniTaskCompletionSource2 = (UniTaskCompletionSource<T>)(object)new InvalidOperationException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E209C0");
		throw uniTaskCompletionSource2;
	}

	unsafe void IUniTaskSource.GetResult(short token)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0028: Expected O, but got I
		//IL_003e: Expected O, but got I
		//IL_0080: Expected O, but got Ref
		//IL_009d: Expected O, but got I
		//IL_00b3: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r9_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>)+28]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rax_v2+FC]");
		object obj4 = (nint)0 + (nint)15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rax_v2+FC]");
		if ((nint)obj4 <= 0)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		nint num2 = 0;
		object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
		obj = obj5;
		_ = ref obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>)+48]");
		object obj6 = 0;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v2 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>)+48]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v46 @ r10_v1+10] (should have been resolved before IL gen)");
	}

	public UniTaskStatus GetStatus(short token)
	{
		//IL_001e: Expected O, but got I
		//IL_002e: Expected O, but got I
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0085: Expected I4, but got O
		nint num = 0;
		IntPtr intPtr = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>>)+80]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+F0]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+F8]");
		object obj3 = 0 + this;
		object obj4 = obj3 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rax_v3+28]");
		if ((nint)0 >= (nint)0)
		{
			obj4 = obj3;
		}
		return (UniTaskStatus)obj4;
	}

	public UniTaskStatus UnsafeGetStatus()
	{
		//IL_001e: Expected O, but got I
		//IL_002e: Expected O, but got I
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0085: Expected I4, but got O
		nint num = 0;
		IntPtr intPtr = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>>)+80]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+F0]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+F8]");
		object obj3 = 0 + this;
		object obj4 = obj3 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rax_v3+28]");
		if ((nint)0 >= (nint)0)
		{
			obj4 = obj3;
		}
		return (UniTaskStatus)obj4;
	}

	public unsafe void OnCompleted(Action<object> continuation, object state, short token)
	{
		//IL_063c: Expected O, but got I
		//IL_064c: Expected O, but got I
		//IL_0664: Expected O, but got I
		//IL_0671: Unknown result type (might be due to invalid IL or missing references)
		//IL_0676: Expected O, but got Unknown
		//IL_0686: Expected O, but got I
		//IL_068f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0694: Expected O, but got Unknown
		//IL_00d2: Expected O, but got I
		//IL_00e2: Expected O, but got I
		//IL_00fa: Expected O, but got I
		//IL_010a: Expected O, but got I
		//IL_002b: Expected O, but got I
		//IL_003b: Expected O, but got I
		//IL_0053: Expected O, but got I
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_0075: Expected O, but got I
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_06e1: Expected I4, but got O
		//IL_05c5: Expected O, but got Ref
		//IL_05cd: Expected I, but got O
		//IL_05d6: Expected O, but got I4
		//IL_0180: Expected O, but got I
		//IL_0190: Expected O, but got I
		//IL_01a8: Expected O, but got I
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected O, but got Unknown
		//IL_01ca: Expected O, but got I
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Expected O, but got Unknown
		//IL_054c: Expected O, but got I
		//IL_021a: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_0242: Expected O, but got I
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Expected O, but got Unknown
		//IL_0264: Expected O, but got I
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Expected O, but got Unknown
		//IL_058a: Expected O, but got Ref
		//IL_0736: Expected O, but got I
		//IL_0746: Expected O, but got I
		//IL_076d: Expected O, but got I
		//IL_0488: Expected O, but got I
		//IL_04a2: Expected O, but got I
		//IL_04b2: Expected O, but got I
		//IL_04d0: Expected O, but got I
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Expected O, but got Unknown
		//IL_02c6: Expected O, but got I
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected O, but got Unknown
		//IL_0513: Expected O, but got Ref
		//IL_0372: Expected O, but got I
		//IL_0382: Expected O, but got I
		//IL_039a: Expected O, but got I
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Expected O, but got Unknown
		//IL_03bc: Expected O, but got I
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ca: Expected O, but got Unknown
		//IL_07c4: Expected O, but got I4
		//IL_0325: Expected O, but got I
		//IL_0335: Expected O, but got I
		//IL_0353: Expected O, but got I
		//IL_0409: Expected O, but got Ref
		//IL_044b: Expected O, but got Ref
		//IL_0809: Expected O, but got I
		//IL_0811: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ stack_28+20]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2+C0]");
		object obj2 = 0;
		object obj3 = obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3+80]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v3+78]");
		object obj5 = 0 + this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v3+70]");
		object obj6 = 0;
		object obj7 = obj5 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v4+28]");
		if ((nint)0 >= (nint)0)
		{
			obj7 = obj5;
		}
		bool flag = obj7 != null;
		object obj8 = state;
		short num = default(short);
		if (!flag)
		{
			object obj9 = new object();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ stack_28+20]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v74+C0]");
			object obj11 = 0;
			object obj12 = obj11;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v75+80]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdx_v41+78]");
			obj8 = 0 + this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdx_v41+70]");
			object obj14 = 0;
			object obj15 = obj8 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rcx_v76+28]");
			if ((nint)0 >= (nint)0)
			{
				obj15 = obj8;
			}
			if (0 == (nint)obj15)
			{
				obj15 = obj9;
			}
			num = (short)(int)obj9;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ stack_28+20]");
		object obj16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rax_v6+C0]");
		object obj17 = 0;
		object obj18 = obj17;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v7+80]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rcx_v8+70]");
		object obj20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v8+28]");
		object obj21 = default(object);
		if ((nint)0 >= (nint)0 || obj21 == null)
		{
			object obj22 = default(object);
			if (obj22 != null)
			{
				(Action<object>, object) tuple2;
				nint num3;
				(Action<object>, object) item2;
				nint num2;
				if (obj21 == null)
				{
					Monitor.Enter(obj22);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ stack_28+20]");
					object obj23 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rax_v39+C0]");
					object obj24 = 0;
					object obj25 = obj24;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rax_v40+80]");
					object obj26 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rcx_v35+F8]");
					object obj27 = 0 + this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rcx_v35+F0]");
					object obj28 = 0;
					object obj29 = obj27 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rax_v41+28]");
					if ((nint)0 >= (nint)0)
					{
						obj29 = obj27;
					}
					object obj56 = default(object);
					object obj55;
					if (obj29 == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ stack_28+20]");
						object obj30 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rax_v47+C0]");
						object obj31 = 0;
						object obj32 = obj31;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ rax_v48+80]");
						object obj33 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rcx_v43+98]");
						object obj34 = 0 + this;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rcx_v43+90]");
						object obj35 = 0;
						object obj36 = obj34 - 16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v497 @ rax_v49+28]");
						if ((nint)0 >= (nint)0)
						{
							obj36 = obj34;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ stack_28+20]");
						object obj37 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v528 @ rax_v50+C0]");
						object obj38 = 0;
						bool flag2 = obj36 == null;
						object obj39 = obj38;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rcx_v46+80]");
						object obj40 = 0;
						Action<object> item = default(Action<object>);
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ rdx_v27+D8]");
							object obj41 = 0 + this;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ rdx_v27+D0]");
							object obj42 = 0;
							object obj43 = obj41 - 16;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v621 @ rax_v57+28]");
							if ((nint)0 >= (nint)0)
							{
								obj43 = obj41;
							}
							if (obj43 == null)
							{
								List<(Action<object>, object)> list = new List<(Action<object>, object)>();
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ stack_28+20]");
								object obj44 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v803 @ rax_v68+C0]");
								object obj45 = 0;
								object obj46 = obj45;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v805 @ rax_v69+80]");
								object obj47 = (nint)0 + (nint)192;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804EC8C0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ stack_28+20]");
							object obj48 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v768 @ rax_v59+C0]");
							object obj49 = 0;
							object obj50 = obj49;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ rax_v60+80]");
							object obj51 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v771 @ rcx_v56+D8]");
							object obj52 = 0 + this;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v771 @ rcx_v56+D0]");
							object obj53 = 0;
							object obj54 = obj52 - 16;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v774 @ rax_v61+28]");
							if ((nint)0 >= (nint)0)
							{
								obj54 = obj52;
							}
							(Action<object>, object) tuple = (item, state);
							bool flag3 = obj54 == null;
							tuple2 = ((Action<object>, object))0;
							obj55 = state;
							num2 = 0;
							if (!flag3)
							{
								(Action<object>, object) tuple3 = default((Action<object>, object));
								((List<(Action<object>, object)>)obj54).Add(((Action<object>, object))(&tuple3));
								if (obj56 != null)
								{
									bool flag4 = obj22 == null;
									tuple2 = tuple;
									num3 = 0;
									item2 = ((Action<object>, object))(&tuple3);
									num2 = 0;
									if (flag4)
									{
										System.Runtime.CompilerServices.Unsafe.Write((void*)6586836376L, (ValueTuple<Action<object>, object>)((Action<object>)item2, num3));
										obj55 = num3;
										item = null;
										(Action<object>, object) tuple4 = default((Action<object>, object));
										throw tuple4;
									}
									Monitor.Exit(obj22);
								}
								return;
							}
							num = (short)num2;
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rcx_v46+80]");
						object obj57 = --128;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804EC8C0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ stack_28+20]");
						object obj58 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v665 @ r11_v8+C0]");
						object obj59 = 0;
						object obj60 = obj59;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v717 @ rcx_v48+80]");
						item = (Action<object>)((nint)0 + (nint)160);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804EC8C0");
						if (obj56 != null)
						{
							bool flag5 = obj22 == null;
							tuple2 = ((Action<object>, object))(&obj21);
							obj55 = state;
							if (flag5)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
								object obj61 = null;
								object obj62 = default(object);
								throw obj62;
							}
							Monitor.Exit(obj22);
						}
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v672 @ rdx_v11 (System.Action`1<System.Object>)+28]");
					obj55 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v672 @ rdx_v11 (System.Action`1<System.Object>)+18] (should have been resolved before IL gen)");
					if (obj56 != null)
					{
						bool flag6 = obj22 == null;
						tuple2 = ((Action<object>, object))(&obj21);
						object obj61 = state;
						if (flag6)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
							object obj63 = default(object);
							throw obj63;
						}
						Monitor.Exit(obj22);
					}
					return;
				}
				ArgumentException ex = new ArgumentException();
				tuple2 = ((Action<object>, object))(&obj21);
				num3 = (nint)obj8;
				item2 = ((Action<object>, object))0;
				num2 = num;
				throw ex;
			}
			ArgumentNullException ex2 = new ArgumentNullException("obj");
			throw ex2;
		}
		Monitor.ThrowLockTakenException();
		throw null;
	}

	private unsafe bool TrySignalCompletion(UniTaskStatus status)
	{
		//IL_04c4: Expected O, but got I
		//IL_04d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d6: Expected O, but got Unknown
		//IL_04e6: Expected O, but got I
		//IL_04ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f4: Expected O, but got Unknown
		//IL_0867: Expected O, but got I4
		//IL_0043: Expected O, but got I
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_0065: Expected O, but got I
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_001a: Expected O, but got I4
		//IL_05e1: Expected O, but got I
		//IL_05f1: Expected O, but got I
		//IL_00cc: Expected O, but got I
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected I, but got Unknown
		//IL_00ee: Expected O, but got I
		//IL_0136: Expected I, but got O
		//IL_0149: Expected O, but got I
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected O, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected O, but got Unknown
		//IL_046e: Expected I, but got O
		//IL_0883: Expected O, but got I4
		//IL_0893: Unknown result type (might be due to invalid IL or missing references)
		//IL_0898: Expected O, but got Unknown
		//IL_0213: Expected O, but got I
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		//IL_0235: Expected O, but got I
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected O, but got Unknown
		//IL_0755: Expected O, but got I
		//IL_0762: Unknown result type (might be due to invalid IL or missing references)
		//IL_0767: Expected O, but got Unknown
		//IL_0777: Expected O, but got I
		//IL_0780: Unknown result type (might be due to invalid IL or missing references)
		//IL_0785: Expected O, but got Unknown
		//IL_06e6: Expected O, but got Ref
		//IL_0293: Expected O, but got I
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Expected O, but got Unknown
		//IL_02b5: Expected O, but got I
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Expected O, but got Unknown
		//IL_07ce: Expected O, but got I
		//IL_07fc: Expected O, but got I
		//IL_0667: Expected O, but got I
		//IL_0674: Unknown result type (might be due to invalid IL or missing references)
		//IL_0679: Expected I, but got Unknown
		//IL_0689: Expected O, but got I
		//IL_0408: Expected O, but got Ref
		//IL_034c: Expected O, but got I
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Expected O, but got Unknown
		//IL_036e: Expected O, but got I
		//IL_0377: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Expected O, but got Unknown
		//IL_08fc: Expected O, but got I
		//IL_06c4: Expected O, but got Ref
		//IL_0439: Expected I, but got O
		nint num = 0;
		IntPtr intPtr = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v3 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>>)+80]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rcx_v3+F8]");
		object obj2 = 0 + this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rcx_v3+F0]");
		object obj3 = 0;
		object obj4 = obj2 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v4+28]");
		if ((nint)0 >= (nint)0)
		{
			obj4 = obj2;
		}
		bool flag = 0 == (nint)obj4;
		object obj5 = !flag;
		if (obj5 == null)
		{
			obj4 = status;
		}
		if (!flag)
		{
			return false;
		}
		nint num2 = 0;
		IntPtr intPtr2 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v8 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>>)+80]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rcx_v7+78]");
		object obj7 = 0 + this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rcx_v7+70]");
		object obj8 = 0;
		object obj9 = obj7 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v9+28]");
		if ((nint)0 >= (nint)0)
		{
			obj9 = obj7;
		}
		if (obj9 == null)
		{
			object obj10 = new object();
			nint num3 = 0;
			IntPtr intPtr3 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ rcx_v76 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>>)+80]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rdx_v47+78]");
			nint num4 = (nint)(0 + this);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rdx_v47+70]");
			object obj12 = 0;
			nint num5 = num4 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rcx_v77+28]");
			if ((nint)0 >= (nint)0)
			{
				num5 = num4;
			}
			if (0 == num5)
			{
				num5 = (nint)obj10;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag2 = (nint)0 == 0;
			object obj13 = obj10;
			if (!flag2)
			{
				object obj14 = num5 >> 12;
				object obj15 = obj14 & 0x1FFFFF;
				object obj16 = obj15 >> 6;
				object obj17 = obj16 * 8;
				object obj18 = 6603577472L + obj17;
				object obj19 = obj15 & 0x3F;
				nint num7;
				do
				{
					object obj20 = 1 << (int)obj19;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdx_v48+462E0]");
					object obj21 = 0 | obj20;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdx_v48+462E0]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdx_v48+462E0]");
					if (num6 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdx_v48+462E0]");
					num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdx_v48+462E0]");
				}
				while (num7 != 0);
				obj13 = obj10;
			}
		}
		nint num8 = 0;
		IntPtr intPtr4 = num8;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rax_v12 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>>)+80]");
		object obj22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rcx_v12+70]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ rax_v13+28]");
		if ((nint)0 < (nint)0)
		{
			object obj24 = default(object);
			if (obj24 != null)
			{
				Monitor.ThrowLockTakenException();
				throw null;
			}
			object obj25 = default(object);
			if (obj25 != null)
			{
				nint num12;
				if (obj24 == null)
				{
					Monitor.Enter(obj25);
					nint num9 = 0;
					IntPtr intPtr5 = num9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v497 @ rax_v40 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>>)+80]");
					object obj26 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ rcx_v33+98]");
					object obj27 = 0 + this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ rcx_v33+90]");
					object obj28 = 0;
					object obj29 = obj27 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rax_v41+28]");
					if ((nint)0 >= (nint)0)
					{
						obj29 = obj27;
					}
					object obj36;
					if (obj29 != null)
					{
						nint num10 = 0;
						IntPtr intPtr6 = num10;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ rax_v76 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>>)+80]");
						object obj30 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rcx_v65+98]");
						object obj31 = 0 + this;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rcx_v65+90]");
						object obj32 = 0;
						object obj33 = obj31 - 16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v575 @ rax_v77+28]");
						if ((nint)0 >= (nint)0)
						{
							obj33 = obj31;
						}
						object obj13 = obj33;
						nint num11 = 0;
						IntPtr intPtr7 = num11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v684 @ rax_v79 (Il2CppClass<System.ArgumentException>)+80]");
						object obj34 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v685 @ rdx_v40+B8]");
						nint num4 = (nint)(0 + this);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v685 @ rdx_v40+B0]");
						object obj35 = 0;
						num12 = num4 - 16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ rax_v80+28]");
						if ((nint)0 >= (nint)0)
						{
							num12 = num4;
						}
						bool flag3 = obj13 == null;
						ArgumentException ex = (ArgumentException)0;
						if (flag3)
						{
							obj36 = (object)(&obj24);
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ r9_v8 (System.Object)+28]");
						num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v170 @ r9_v8 (System.Object)+18] (should have been resolved before IL gen)");
					}
					nint num13 = 0;
					IntPtr intPtr8 = num13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v611 @ rax_v44 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>>)+80]");
					object obj37 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ rcx_v38+D8]");
					object obj38 = 0 + this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ rcx_v38+D0]");
					object obj39 = 0;
					object obj40 = obj38 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v615 @ rax_v45+28]");
					if ((nint)0 >= (nint)0)
					{
						obj40 = obj38;
					}
					bool flag4 = obj40 == null;
					obj36 = (object)(&obj24);
					if (!flag4)
					{
						nint num14 = 0;
						IntPtr intPtr9 = num14;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v715 @ rax_v60 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>>)+80]");
						object obj41 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v716 @ rcx_v51+D8]");
						object obj42 = 0 + this;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v716 @ rcx_v51+D0]");
						object obj43 = 0;
						object obj44 = obj42 - 16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v719 @ rax_v61+28]");
						if ((nint)0 >= (nint)0)
						{
							obj44 = obj42;
						}
						object obj13 = obj44;
						List<(Action<object>, object)>.Enumerator enumerator = default(List<(Action<object>, object)>.Enumerator);
						ArgumentException ex3;
						if (enumerator.MoveNext())
						{
							ArgumentException ex2 = null;
							obj36 = obj13;
							ex3 = null;
							IntPtr intPtr10 = default(IntPtr);
							num12 = intPtr10;
							ArgumentException ex = null;
							throw new NullReferenceException();
						}
						obj36 = obj13;
						ex3 = null;
					}
					nint num15 = 0;
					IntPtr intPtr11 = num15;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v761 @ rax_v48 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>>)+80]");
					object obj45 = --128;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804EC8C0");
					nint num16 = 0;
					IntPtr intPtr12 = num16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v802 @ rcx_v44 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>>)+80]");
					object obj46 = (nint)0 + (nint)160;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804EC8C0");
					nint num17 = 0;
					IntPtr intPtr13 = num17;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v849 @ rcx_v46 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskCompletionSource`1>>)+80]");
					num12 = (nint)0 + (nint)192;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804EC8C0");
					object obj47 = (object)(&obj24);
					if (obj47 != null)
					{
						object obj48 = default(object);
						bool flag5 = obj48 == null;
						nint num4 = unchecked((nint)null);
						if (flag5)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
							object obj49 = default(object);
							throw obj49;
						}
						Monitor.Exit(obj48);
					}
					return true;
				}
				ArgumentException ex4 = new ArgumentException();
				num12 = unchecked((nint)null);
				throw ex4;
			}
		}
		ArgumentNullException ex5 = new ArgumentNullException("obj");
		ex5._002Ector("obj");
		throw ex5;
	}
}
