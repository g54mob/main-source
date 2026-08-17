using System;
using System.Runtime.ExceptionServices;
using System.Threading;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks.Internal;

internal sealed class AsyncSubject<T> : IObservable<T>, IObserver<T>
{
	private class Subscription : IDisposable
	{
		private readonly object gate;

		private AsyncSubject<T> parent;

		private IObserver<T> unsubscribeTarget;

		public Subscription(AsyncSubject<T> parent, IObserver<T> unsubscribeTarget)
		{
			object obj = new object();
			gate = obj;
			this.parent = parent;
			this.unsubscribeTarget = unsubscribeTarget;
		}

		public unsafe void Dispose()
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Expected O, but got Unknown
			//IL_007c: Expected I, but got I8
			//IL_0084: Expected O, but got Ref
			//IL_07cb: Expected I, but got I8
			//IL_00a9: Expected O, but got Ref
			//IL_00d1: Expected O, but got Ref
			//IL_089e: Expected I, but got O
			//IL_010b: Expected O, but got Ref
			//IL_013c: Expected O, but got I
			//IL_0158: Expected I, but got O
			//IL_0168: Expected O, but got I
			//IL_01e2: Expected O, but got I4
			//IL_01a4: Expected O, but got I
			//IL_0322: Expected O, but got I
			//IL_034b: Expected O, but got Ref
			//IL_01d4: Expected O, but got I4
			//IL_0219: Expected O, but got I
			//IL_022e: Expected O, but got I
			//IL_0245: Expected O, but got Ref
			//IL_0376: Expected O, but got I
			//IL_0386: Expected O, but got I
			//IL_0396: Expected O, but got I
			//IL_03e9: Expected O, but got Ref
			//IL_0716: Expected O, but got I8
			//IL_0415: Expected I, but got O
			//IL_028e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0293: Expected O, but got Unknown
			//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_02af: Expected O, but got Unknown
			//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cb: Expected O, but got Unknown
			//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02dd: Expected O, but got Unknown
			//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02eb: Expected I, but got Unknown
			//IL_058b: Expected O, but got Ref
			//IL_0a7e: Expected O, but got I4
			//IL_0a8e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a93: Expected O, but got Unknown
			//IL_045b: Expected I, but got O
			//IL_046d: Expected O, but got Ref
			//IL_04b6: Expected O, but got Ref
			//IL_075b: Expected O, but got Ref
			//IL_0307: Expected O, but got I8
			//IL_05d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_05d9: Expected O, but got Unknown
			//IL_05f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_05f5: Expected O, but got Unknown
			//IL_060c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0611: Expected O, but got Unknown
			//IL_061e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0623: Expected O, but got Unknown
			//IL_062c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0631: Expected I, but got Unknown
			//IL_078e: Expected O, but got Ref
			//IL_0ad0: Expected O, but got I4
			//IL_0ae0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ae5: Expected O, but got Unknown
			//IL_068d: Expected O, but got Ref
			//IL_04f9: Expected O, but got I
			//IL_0509: Expected O, but got I
			//IL_0533: Expected O, but got I
			//IL_0543: Expected O, but got I
			//IL_064d: Expected O, but got I8
			//IL_06a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_06a9: Expected O, but got Unknown
			//IL_06dc: Expected O, but got Ref
			//IL_06fa: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2 + 8;
			object obj3 = default(object);
			object obj4 = default(object);
			object obj6 = default(object);
			AsyncSubject<T> asyncSubject;
			AsyncSubject<T> asyncSubject2;
			object obj9;
			object obj10 = default(object);
			object obj5;
			if (obj3 != null)
			{
				Monitor.Enter(obj3);
				if (parent != null)
				{
					bool flag = obj4 != null;
					nint num = unchecked((nint)4294967295L);
					obj5 = (object)(&obj4);
					if (!flag)
					{
						bool flag2 = obj6 == null;
						obj5 = (object)(&obj4);
						nint num3;
						if (!flag2)
						{
							bool flag3 = obj4 != null;
							obj5 = (object)(&obj4);
							IObserver<T> observer;
							if (!flag3)
							{
								Monitor.Enter(obj6);
								asyncSubject = parent;
								bool flag4 = parent == null;
								obj5 = (object)(&obj4);
								if (!flag4)
								{
									Exception lastError = asyncSubject.lastError;
									nint num2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v685 @ rcx_v53 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.AsyncSubject`1+Subscription>)+18]");
									observer = (IObserver<T>)0;
									if (asyncSubject.lastError == null)
									{
										asyncSubject2 = parent;
										goto IL_0203;
									}
									num3 = (nint)lastError;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rdx_v7 (System.IObserver`1<T>)+130]");
									object obj7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ r8_v23 (Il2CppClass<System.Exception>)+130]");
									nint num4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rdx_v7 (System.IObserver`1<T>)+130]");
									if (num4 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ r8_v23 (Il2CppClass<System.Exception>)+C8]");
										object obj8 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v935 @ rax_v138+FFFFFFF8+v837 @ rax_v110*8]");
										if (0 == (nint)observer)
										{
											obj9 = 1;
											goto IL_0951;
										}
									}
									obj9 = 0;
									goto IL_0951;
								}
								throw new NullReferenceException();
							}
							ArgumentException ex = new ArgumentException();
							observer = null;
							throw ex;
						}
						ArgumentNullException ex2 = new ArgumentNullException("obj");
						num3 = unchecked((nint)null);
						num = 0;
						throw ex2;
					}
					Monitor.ThrowLockTakenException();
					throw null;
				}
				if (obj10 != null)
				{
					bool flag5 = obj3 == null;
					nint num = unchecked((nint)4294967295L);
					obj5 = obj;
					if (flag5)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
						object obj11 = default(object);
						throw obj11;
					}
					Monitor.Exit(obj3);
				}
				return;
			}
			ArgumentNullException ex3 = new ArgumentNullException("obj");
			ex3._002Ector("obj");
			throw ex3;
			IL_0203:
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1052 @ rcx_v73 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.AsyncSubject`1+Subscription>)+30]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1069 @ rax_v99+B8]");
			object lastError2 = 0;
			bool flag6 = asyncSubject2 == null;
			obj5 = (object)(&obj4);
			object obj20;
			if (!flag6)
			{
				asyncSubject2.lastError = (Exception)lastError2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				if ((nint)0 == 0)
				{
					goto IL_0709;
				}
				object obj13 = asyncSubject2 + 40;
				object obj14 = obj13 >> 12;
				object obj15 = obj14 & 0x1FFFFF;
				object obj16 = obj15 >> 6;
				object obj17 = obj16 * 8;
				IObserver<T> observer = (IObserver<T>)(6603577472L + obj17);
				nint num3 = (nint)(obj15 & 0x3F);
				nint num7;
				do
				{
					object obj18 = 1 << (int)num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rdx_v7 (System.IObserver`1<T>)+462E0]");
					object obj19 = 0 | obj18;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rdx_v7 (System.IObserver`1<T>)+462E0]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rdx_v7 (System.IObserver`1<T>)+462E0]");
					if (num6 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rdx_v7 (System.IObserver`1<T>)+462E0]");
					num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rdx_v7 (System.IObserver`1<T>)+462E0]");
				}
				while (num7 != 0);
				obj20 = 6603577472L;
				goto IL_09a2;
			}
			throw new NullReferenceException();
			IL_09a2:
			unsubscribeTarget = null;
			parent = null;
			object obj21 = default(object);
			if (obj21 != null)
			{
				bool flag7 = obj6 == null;
				obj5 = (object)(&obj4);
				if (flag7)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
					IObserver<T> observer = null;
					object obj22 = default(object);
					throw obj22;
				}
				Monitor.Exit(obj6);
			}
			if (obj10 != null)
			{
				bool flag8 = obj3 == null;
				obj5 = (object)(&obj4);
				if (flag8)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
					object obj23 = default(object);
					throw obj23;
				}
				Monitor.Exit(obj3);
			}
			return;
			IL_0709:
			obj20 = 6603577472L;
			goto IL_09a2;
			IL_0951:
			bool flag9 = obj9 == null;
			Exception ex4 = null;
			if (!flag9)
			{
				ex4 = asyncSubject.lastError;
			}
			asyncSubject2 = parent;
			if (ex4 == null)
			{
				goto IL_0203;
			}
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1071 @ rcx_v83 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.AsyncSubject`1+Subscription>)+20]");
			object obj24 = 0;
			string className = ex4._className;
			bool flag10 = ex4._className == null;
			obj5 = (object)(&obj4);
			if (!flag10)
			{
				int stringLength = className._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v574 @ r13_v20+20]");
				object obj25 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1143 @ rax_v114+C0]");
				object obj26 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1144 @ rcx_v84+58]");
				object obj27 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v622 @ r14_v21+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				bool flag11 = className._stringLength == 0;
				obj5 = (object)(&obj4);
				if (!flag11)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180507B80");
					object obj28 = default(object);
					bool flag12 = (nint)obj28 < 0;
					nint num3 = unchecked((nint)null);
					IObserver<T> observer = unsubscribeTarget;
					if (!flag12)
					{
						string className2 = ex4._className;
						bool flag13 = ex4._className == null;
						obj20 = obj28;
						num3 = unchecked((nint)null);
						observer = unsubscribeTarget;
						obj5 = (object)(&obj4);
						if (flag13)
						{
							throw new NullReferenceException();
						}
						num3 = className2._stringLength;
						bool flag14 = className2._stringLength == 0;
						obj20 = obj28;
						observer = unsubscribeTarget;
						obj5 = (object)(&obj4);
						if (flag14)
						{
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ r8_v23 (Il2CppClass<System.Exception>)+18]");
						if ((nint)0 != 2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v574 @ r13_v20+20]");
							object obj29 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1538 @ rax_v127+C0]");
							object obj30 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1539 @ r8_v46+60]");
							num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18364ED20");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v574 @ r13_v20+20]");
							object obj31 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1561 @ rax_v129+C0]");
							object obj32 = 0;
							Exception ex5 = null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D0380");
							IObserver<T> observer2 = default(IObserver<T>);
							observer = observer2;
							ex4 = ex5;
						}
						else
						{
							int stringLength2 = className2._stringLength;
							bool flag15 = className2._stringLength == 0;
							obj20 = obj28;
							observer = unsubscribeTarget;
							obj5 = (object)(&obj4);
							if (flag15)
							{
								throw new NullReferenceException();
							}
							object obj33 = 1 - obj28;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v620 @ rbx_v28 (System.Int32)+18]");
							bool flag16 = (nint)obj33 >= 0;
							obj20 = obj28;
							observer = unsubscribeTarget;
							obj5 = (object)(&obj4);
							if (flag16)
							{
								throw new IndexOutOfRangeException();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v620 @ rbx_v28 (System.Int32)+20+v616 @ rax_v126*8]");
							ex4 = (Exception)0;
							observer = unsubscribeTarget;
						}
					}
					bool flag17 = asyncSubject2 == null;
					obj20 = obj28;
					obj5 = (object)(&obj4);
					if (!flag17)
					{
						asyncSubject2.lastError = ex4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
						if ((nint)0 == 0)
						{
							goto IL_0709;
						}
						object obj34 = asyncSubject2 + 40;
						object obj35 = obj34 >> 12;
						object obj36 = obj35 & 0x1FFFFF;
						object obj37 = obj36 >> 6;
						object obj38 = obj37 * 8;
						observer = (IObserver<T>)(6603577472L + obj38);
						num3 = (nint)(obj36 & 0x3F);
						nint num10;
						do
						{
							object obj39 = 1 << (int)num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rdx_v7 (System.IObserver`1<T>)+462E0]");
							object obj40 = 0 | obj39;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rdx_v7 (System.IObserver`1<T>)+462E0]");
							nint num9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rdx_v7 (System.IObserver`1<T>)+462E0]");
							if (num9 == 0)
							{
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rdx_v7 (System.IObserver`1<T>)+462E0]");
							num10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rdx_v7 (System.IObserver`1<T>)+462E0]");
						}
						while (num10 != 0);
						obj20 = 6603577472L;
						goto IL_09a2;
					}
					throw new NullReferenceException();
				}
				ArgumentNullException ex6 = new ArgumentNullException("array");
				throw ex6;
			}
			throw new NullReferenceException();
		}
	}

	private object observerLock;

	private T lastValue;

	private bool hasValue;

	private bool isStopped;

	private bool isDisposed;

	private Exception lastError;

	private IObserver<T> outObserver;

	public T Value
	{
		get
		{
			//IL_00d5: Expected O, but got I4
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rcx_v1 (Cysharp.Threading.Tasks.Internal.AsyncSubject`1<T>)+1B]");
			ObjectDisposedException ex = default(ObjectDisposedException);
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rcx_v1 (Cysharp.Threading.Tasks.Internal.AsyncSubject`1<T>)+1A]");
				if ((nint)0 != 0)
				{
					if (!hasValue)
					{
						return lastValue;
					}
					ExceptionDispatchInfo exceptionDispatchInfo = ExceptionDispatchInfo.Capture((Exception)((AsyncSubject<T>)(object)ex).hasValue);
					throw new NullReferenceException();
				}
				object obj = new InvalidOperationException();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E209C0");
				throw obj;
			}
			ex = new ObjectDisposedException("");
			throw ex;
		}
	}

	public bool HasObservers
	{
		get
		{
			//IL_0020: Expected O, but got I
			//IL_004c: Expected I, but got O
			//IL_005c: Expected O, but got I
			//IL_0098: Expected O, but got I
			Exception ex = lastError;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rdx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.AsyncSubject`1>)+20]");
			object obj = 0;
			if (lastError != null)
			{
				nint num2 = (nint)ex;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v3+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ r8_v3 (Il2CppClass<System.Exception>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v3+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ r8_v3 (Il2CppClass<System.Exception>)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v5+FFFFFFF8+v41 @ rcx_v4*8]");
					if (0 == (nint)obj)
					{
						goto IL_00e1;
					}
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Internal.AsyncSubject`1<T>)+1A]");
			if ((nint)0 != 0)
			{
				goto IL_00e1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Internal.AsyncSubject`1<T>)+1B]");
			return (nint)0 == 0;
			IL_00e1:
			return false;
		}
	}

	public bool IsCompleted
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Internal.AsyncSubject`1<T>)+1A]");
			return false;
		}
	}

	public void OnCompleted()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0175: Expected O, but got I8
		//IL_00b2: Expected O, but got I
		//IL_00c7: Expected O, but got I
		//IL_00de: Expected O, but got I8
		//IL_01ae: Expected O, but got I
		//IL_02ab: Expected O, but got I4
		//IL_01f8: Expected O, but got I
		object obj2 = default(object);
		object obj = obj2 + 8;
		if (observerLock != null)
		{
			Monitor.Enter(observerLock);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Internal.AsyncSubject`1<T>)+1B]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Internal.AsyncSubject`1<T>)+1A]");
				object obj6 = default(object);
				if ((nint)0 == 0)
				{
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rcx_v33 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.AsyncSubject`1>)+28]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v40+B8]");
					object obj4 = 0;
					lastError = (Exception)obj4;
					object obj5 = 4294967295L;
					_ = 1;
					if (obj6 != null)
					{
						if (observerLock == null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
							object obj7 = 0;
							object obj8 = default(object);
							throw obj8;
						}
						Monitor.Exit(observerLock);
					}
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rcx_v38 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.AsyncSubject`1>)+18]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Internal.AsyncSubject`1<T>)+19]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805BF990");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v574 @ rcx_v44 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.AsyncSubject`1>)+18]");
						obj9 = 0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				else if (obj6 != null)
				{
					bool flag = observerLock == null;
					object obj7 = 4294967295L;
					if (flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
						object obj10 = default(object);
						throw obj10;
					}
					Monitor.Exit(observerLock);
				}
				return;
			}
			ObjectDisposedException ex = new ObjectDisposedException("");
			ex._002Ector("");
			throw ex;
		}
		ArgumentNullException ex2 = new ArgumentNullException("obj");
		throw ex2;
	}

	public void OnError(Exception error)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_00cc: Expected O, but got I
		//IL_00e1: Expected O, but got I
		//IL_025e: Expected I4, but got O
		//IL_0272: Expected I, but got O
		if (error != null)
		{
			object obj2 = default(object);
			object obj = obj2 + 32;
			if (observerLock != null)
			{
				object obj3 = obj;
				Monitor.Enter(observerLock);
				nint num = 0;
				nint num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807ACE30");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Internal.AsyncSubject`1<T>)+1A]");
				object obj6 = default(object);
				if ((nint)0 == 0)
				{
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rcx_v34 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.AsyncSubject`1>)+28]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ rax_v43+B8]");
					object obj5 = 0;
					lastError = (Exception)obj5;
					_ = 1;
					hasValue = (byte)(int)error != 0;
					if (obj6 != null)
					{
						bool flag = observerLock == null;
						obj3 = obj;
						if (flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
							num2 = unchecked((nint)null);
							object obj7 = default(object);
							throw obj7;
						}
						Monitor.Exit(observerLock);
					}
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
				}
				else if (obj6 != null)
				{
					bool flag2 = observerLock == null;
					obj3 = obj;
					if (flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
						object obj8 = default(object);
						throw obj8;
					}
					Monitor.Exit(observerLock);
				}
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("obj");
			ex._002Ector("obj");
			throw ex;
		}
		ArgumentNullException ex2 = new ArgumentNullException("error");
		throw ex2;
	}

	public void OnNext(T value)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_01e7: Expected I, but got O
		object obj2 = default(object);
		object obj = obj2 + 8;
		if (observerLock != null)
		{
			Monitor.Enter(observerLock);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Internal.AsyncSubject`1<T>)+1B]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Internal.AsyncSubject`1<T>)+1A]");
				object obj3 = default(object);
				if ((nint)0 == 0)
				{
					_ = 1;
					lastValue = value;
					if (obj3 != null)
					{
						bool flag = observerLock == null;
						nint num = 0;
						if (flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
							nint num2 = unchecked((nint)null);
							object obj4 = default(object);
							throw obj4;
						}
						Monitor.Exit(observerLock);
					}
				}
				else if (obj3 != null)
				{
					bool flag2 = observerLock == null;
					nint num2 = 0;
					if (flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
						object obj5 = default(object);
						throw obj5;
					}
					Monitor.Exit(observerLock);
				}
				return;
			}
			ObjectDisposedException ex = new ObjectDisposedException("");
			ex._002Ector("");
			throw ex;
		}
		ArgumentNullException ex2 = new ArgumentNullException("obj");
		throw ex2;
	}

	public unsafe IDisposable Subscribe(IObserver<T> observer)
	{
		//IL_05a8: Expected I, but got O
		//IL_005c: Expected O, but got Ref
		//IL_0640: Expected I, but got O
		//IL_0137: Expected O, but got I
		//IL_01ec: Expected I, but got O
		//IL_0202: Expected O, but got I
		//IL_0144: Expected I, but got O
		//IL_0154: Expected O, but got I
		//IL_00ee: Expected O, but got Ref
		//IL_01ce: Expected O, but got I4
		//IL_02ce: Expected O, but got I4
		//IL_02d6: Expected O, but got Ref
		//IL_021f: Expected O, but got I
		//IL_0190: Expected O, but got I
		//IL_050d: Expected O, but got I
		//IL_025b: Expected O, but got I
		//IL_0400: Expected O, but got I
		//IL_01c0: Expected O, but got I4
		//IL_0415: Expected O, but got I
		//IL_0425: Expected O, but got I
		//IL_044f: Expected O, but got I
		//IL_045f: Expected O, but got I
		//IL_0557: Expected O, but got I
		//IL_0374: Expected I, but got O
		//IL_037c: Expected O, but got Ref
		//IL_032c: Expected O, but got Ref
		//IL_05c4: Expected O, but got I4
		//IL_03b1: Expected I, but got O
		//IL_04db: Expected O, but got Ref
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		IDisposable result;
		object obj11;
		object obj3;
		nint num7;
		if (observer != null)
		{
			if (obj == null)
			{
				if (obj2 != null)
				{
					bool flag = obj != null;
					obj3 = (object)(&obj);
					nint num2;
					if (!flag)
					{
						Monitor.Enter(obj2);
						nint num = 0;
						num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807ACE30");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Internal.AsyncSubject`1<T>)+1A]");
						if ((nint)0 != 0)
						{
							bool flag2 = obj4 == null;
							object obj5 = this;
							if (!flag2)
							{
								bool flag3 = obj2 == null;
								obj3 = (object)(&obj);
								if (flag3)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
									object obj6 = default(object);
									throw obj6;
								}
								Monitor.Exit(obj2);
								obj5 = obj2;
							}
							if (!hasValue)
							{
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v152 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.AsyncSubject`1>)+18]");
								object obj7 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Internal.AsyncSubject`1<T>)+19]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805BF990");
									nint num4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v692 @ rcx_v118 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.AsyncSubject`1>)+18]");
									obj7 = 0;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
							}
							else
							{
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
							}
							result = EmptyDisposable.Instance;
							goto IL_0757;
						}
						Exception ex = lastError;
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rcx_v34 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.AsyncSubject`1>)+48]");
						object obj8 = 0;
						if (lastError == null)
						{
							goto IL_01e2;
						}
						num7 = (nint)ex;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ rdx_v25+130]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v909 @ r8_v16 (Il2CppMethodInfo)+130]");
						nint num8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ rdx_v25+130]");
						if (num8 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v909 @ r8_v16 (Il2CppMethodInfo)+C8]");
							object obj10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v589 @ rax_v136+FFFFFFF8+v508 @ rax_v121*8]");
							if (0 == (nint)obj8)
							{
								obj11 = 1;
								goto IL_068d;
							}
						}
						obj11 = 0;
						goto IL_068d;
					}
					ArgumentException ex2 = new ArgumentException();
					num2 = unchecked((nint)null);
					throw ex2;
				}
				ArgumentNullException ex3 = new ArgumentNullException("obj");
				throw ex3;
			}
			Monitor.ThrowLockTakenException();
			throw null;
		}
		ArgumentNullException ex4 = new ArgumentNullException("observer");
		num7 = unchecked((nint)null);
		throw ex4;
		IL_0492:
		nint num9 = 0;
		result = null;
		object obj12 = new object();
		if (obj4 != null)
		{
			bool flag4 = obj2 == null;
			obj3 = (object)(&obj);
			if (flag4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
				object obj13 = default(object);
				throw obj13;
			}
			Monitor.Exit(obj2);
		}
		goto IL_0757;
		IL_0757:
		return result;
		IL_068d:
		bool flag5 = obj11 == null;
		Exception ex5 = null;
		if (!flag5)
		{
			ex5 = lastError;
		}
		object obj18;
		Exception ex7;
		if (ex5 != null)
		{
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v891 @ rcx_v91 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.AsyncSubject`1>)+50]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v892 @ rsi_v16+20]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v975 @ rax_v124+C0]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v976 @ rdx_v46+48]");
			num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18364EB20");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v892 @ rsi_v16+20]");
			object obj17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v996 @ rcx_v93+C0]");
			obj18 = 0;
			Exception ex6 = null;
			string className = default(string);
			ex6._className = className;
			ex7 = ex6;
			goto IL_0483;
		}
		goto IL_01e2;
		IL_01e2:
		nint num11 = (nint)lastError;
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v551 @ rcx_v61 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.AsyncSubject`1>)+20]");
		obj18 = 0;
		T val = default(T);
		if (lastError != null)
		{
			num7 = num11;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v912 @ rdx_v1+130]");
			object obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v909 @ r8_v16 (Il2CppMethodInfo)+130]");
			nint num13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v912 @ rdx_v1+130]");
			if (num13 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v909 @ r8_v16 (Il2CppMethodInfo)+C8]");
				object obj20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v756 @ rax_v118+FFFFFFF8+v742 @ rax_v117*8]");
				nint num14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v551 @ rcx_v61 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.AsyncSubject`1>)+20]");
				if (num14 == 0)
				{
					lastError = (Exception)observer;
					ex7 = (Exception)val;
					goto IL_0492;
				}
			}
		}
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_array_new_specific\"");
		object obj21 = default(object);
		bool flag6 = obj21 == null;
		obj18 = 2;
		obj3 = (object)(&obj);
		if (!flag6)
		{
			if (lastError != null)
			{
				object obj22 = obj21;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj23 = default(object);
				bool flag7 = obj23 == null;
				obj3 = (object)(&obj);
				if (flag7)
				{
					ArrayTypeMismatchException ex8 = new ArrayTypeMismatchException();
					throw ex8;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			object obj24 = obj21;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj25 = default(object);
			bool flag8 = obj25 == null;
			num7 = (nint)lastError;
			obj3 = (object)(&obj);
			if (!flag8)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				nint num16 = 0;
				object obj26 = null;
				num7 = (nint)observer;
				nint num17 = 0;
				Exception ex9 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D0380");
				ex7 = ex9;
				obj18 = obj26;
				goto IL_0483;
			}
			ArrayTypeMismatchException ex10 = new ArrayTypeMismatchException();
			obj18 = 0;
			throw ex10;
		}
		ex7 = (Exception)val;
		throw new NullReferenceException();
		IL_0483:
		lastError = ex7;
		goto IL_0492;
	}

	public void Dispose()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0068: Expected O, but got I
		//IL_007d: Expected O, but got I
		//IL_0094: Expected O, but got I8
		object obj2 = default(object);
		object obj = obj2 + 8;
		if (observerLock != null)
		{
			Monitor.Enter(observerLock);
			_ = 1;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rcx_v19 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.AsyncSubject`1>)+98]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rax_v27+B8]");
			object obj4 = 0;
			lastError = (Exception)obj4;
			object obj5 = 4294967295L;
			hasValue = false;
			lastValue = (T)null;
			object obj6 = default(object);
			if (obj6 != null)
			{
				if (observerLock == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
					object obj7 = default(object);
					throw obj7;
				}
				Monitor.Exit(observerLock);
			}
			return;
		}
		ArgumentNullException ex = new ArgumentNullException("obj");
		ex._002Ector("obj");
		throw ex;
	}

	private void ThrowIfDisposed()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Internal.AsyncSubject`1<T>)+1B]");
		if ((nint)0 == 0)
		{
			return;
		}
		ObjectDisposedException ex = new ObjectDisposedException("");
		throw ex;
	}

	public AsyncSubject()
	{
		//IL_0025: Expected O, but got I
		//IL_003a: Expected O, but got I
		object obj = new object();
		observerLock = obj;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rcx_v7 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.AsyncSubject`1>)+28]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v10+B8]");
		object obj3 = 0;
		lastError = (Exception)obj3;
	}
}
