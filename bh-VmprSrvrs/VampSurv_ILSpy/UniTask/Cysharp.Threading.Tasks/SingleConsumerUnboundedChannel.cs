using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks.Sources;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

internal class SingleConsumerUnboundedChannel<T> : Channel<T>
{
	private sealed class SingleConsumerUnboundedChannelWriter : ChannelWriter<T>
	{
		private readonly SingleConsumerUnboundedChannel<T> parent;

		public SingleConsumerUnboundedChannelWriter(SingleConsumerUnboundedChannel<T> parent)
		{
			nint num = 0;
			IntPtr intPtr = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v11 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelWriter>>)] (should have been resolved before IL gen)");
			this.parent = parent;
		}

		public unsafe override bool TryWrite(T item)
		{
			//IL_0008: Expected O, but got Ref
			//IL_001e: Expected O, but got I
			//IL_0034: Expected O, but got I
			//IL_0454: Unknown result type (might be due to invalid IL or missing references)
			//IL_0459: Expected O, but got Unknown
			//IL_046b: Expected O, but got Ref
			//IL_0474: Expected O, but got I4
			//IL_0065: Expected O, but got I8
			//IL_0088: Expected O, but got Ref
			//IL_009b: Expected O, but got Ref
			//IL_0139: Expected O, but got I
			//IL_018b: Expected O, but got I
			//IL_01a1: Expected O, but got I
			//IL_01af: Expected O, but got Ref
			//IL_033f: Expected O, but got I8
			//IL_035e: Expected O, but got I
			//IL_01ef: Expected O, but got I
			//IL_0205: Expected O, but got I
			//IL_021f: Expected O, but got Ref
			//IL_0512: Expected O, but got I
			//IL_0525: Expected O, but got Ref
			//IL_0557: Expected I, but got O
			//IL_024a: Expected O, but got I
			//IL_026e: Expected I, but got O
			//IL_028c: Expected O, but got I
			//IL_02d5: Expected I, but got O
			//IL_0391: Expected I, but got O
			//IL_02f4: Expected O, but got I
			//IL_03c3: Expected I, but got O
			//IL_03e7: Expected O, but got I
			object obj2 = default(object);
			object obj = (object)(&obj2);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ r9_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelWriter>)+28]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2+FC]");
			object obj4 = (nint)0 + (nint)15;
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2+FC]");
			if ((nint)obj5 <= 0)
			{
				obj4 = 1152921504606846960L;
			}
			object obj6 = obj4 & -16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			object obj7 = (object)(&obj2);
			obj = 0;
			SingleConsumerUnboundedChannel<T> singleConsumerUnboundedChannel = parent;
			if (parent != null)
			{
				_ = singleConsumerUnboundedChannel.completedTaskSource;
				_ = 0;
				object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 152));
				object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+10]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+98]");
				if ((nint)0 != 0)
				{
					Monitor.ThrowLockTakenException();
					throw null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+8]");
				if ((nint)0 == 0)
				{
					ArgumentNullException ex = new ArgumentNullException("obj");
					throw ex;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+98]");
				T val;
				if ((nint)0 != 0)
				{
					ArgumentException ex2 = new ArgumentException();
					val = (T)null;
					throw ex2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+8]");
				Monitor.Enter(0);
				SingleConsumerUnboundedChannel<T> singleConsumerUnboundedChannel2 = parent;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rcx_v25 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+50]");
				if ((nint)0 != 0)
				{
					object obj10 = default(object);
					if (obj10 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+8]");
						bool flag = (nint)0 == 0;
						val = (T)4294967295L;
						if (flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
							object obj11 = default(object);
							throw obj11;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+8]");
						Monitor.Exit(0);
					}
					return false;
				}
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rcx_v28 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelWriter>)+28]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ rax_v44+28]");
				object obj13 = (nint)0 >> 31;
				val = (T)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 136));
				if (obj13 != null)
				{
					val = item;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				bool flag2 = singleConsumerUnboundedChannel2.completedTaskSource == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2+FC]");
				nint num3 = 0;
				if (flag2)
				{
					throw new NullReferenceException();
				}
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rcx_v32 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelWriter>)+28]");
				object obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rax_v47+28]");
				object obj15 = (nint)0 >> 31;
				bool flag3 = obj15 != null;
				object obj16 = (object)(&obj2);
				if (!flag3)
				{
					obj16 = obj7;
				}
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ rcx_v35 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelWriter>)+30]");
				val = (T)0;
				obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v259 @ rdx_v3 (T)+10] (should have been resolved before IL gen)");
				SingleConsumerUnboundedChannel<T> singleConsumerUnboundedChannel3 = parent;
				bool flag4 = parent == null;
				num3 = (nint)singleConsumerUnboundedChannel2.completedTaskSource;
				if (flag4)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rax_v51 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+28]");
				object obj17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rax_v51 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+28]");
				bool flag5 = (nint)0 == 0;
				num3 = (nint)singleConsumerUnboundedChannel2.completedTaskSource;
				if (flag5)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rsi_v14+68]");
				obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+98]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+8]");
					bool flag6 = (nint)0 == 0;
					num3 = (nint)singleConsumerUnboundedChannel2.completedTaskSource;
					if (flag6)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
						val = (T)null;
						object obj18 = default(object);
						throw obj18;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+8]");
					Monitor.Exit(0);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rsi_v14+68]");
				if ((nint)0 == 0)
				{
					goto IL_05c2;
				}
				SingleConsumerUnboundedChannel<T> singleConsumerUnboundedChannel4 = parent;
				bool flag7 = parent == null;
				num3 = (nint)singleConsumerUnboundedChannel2.completedTaskSource;
				if (!flag7)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v55 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+28]");
					bool flag8 = (nint)0 == 0;
					num3 = (nint)singleConsumerUnboundedChannel2.completedTaskSource;
					if (!flag8)
					{
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ rdx_v22 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelWriter>)+40]");
						object obj19 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v617 @ rax_v57] (should have been resolved before IL gen)");
						goto IL_05c2;
					}
				}
			}
			throw new NullReferenceException();
			IL_05c2:
			return true;
		}

		public unsafe override bool TryComplete(Exception error = null)
		{
			//IL_005c: Expected O, but got Ref
			//IL_00d8: Expected O, but got I8
			//IL_00e0: Expected O, but got Ref
			//IL_0549: Expected O, but got I8
			//IL_0551: Expected O, but got Ref
			//IL_00fe: Expected O, but got I
			//IL_0122: Expected O, but got I8
			//IL_012a: Expected O, but got Ref
			//IL_0159: Expected O, but got I8
			//IL_0161: Expected O, but got Ref
			//IL_0185: Expected O, but got I
			//IL_018d: Expected I, but got O
			//IL_01cf: Expected O, but got I
			//IL_01d7: Expected O, but got Ref
			//IL_066f: Expected I, but got O
			//IL_04be: Expected I4, but got O
			//IL_031c: Expected O, but got I
			//IL_0324: Expected O, but got Ref
			//IL_0225: Expected O, but got Ref
			//IL_038b: Expected O, but got I
			//IL_0393: Expected O, but got Ref
			//IL_02ba: Expected O, but got Ref
			//IL_03c0: Expected O, but got Ref
			//IL_05bd: Expected O, but got I4
			//IL_02dd: Expected O, but got I
			//IL_02e6: Expected I, but got O
			//IL_02ee: Expected I4, but got O
			//IL_02f6: Expected O, but got Ref
			//IL_03e4: Expected O, but got I
			//IL_03ed: Expected I, but got O
			//IL_03fe: Expected O, but got Ref
			//IL_0422: Expected O, but got I4
			//IL_028e: Expected I, but got O
			//IL_0296: Expected I4, but got O
			//IL_0494: Expected O, but got I
			object obj = default(object);
			if (obj == null)
			{
				object obj2 = default(object);
				if (obj2 != null)
				{
					bool flag = obj != null;
					IUniTaskSource uniTaskSource = (IUniTaskSource)(&obj);
					UniTaskStatus uniTaskStatus;
					if (!flag)
					{
						Monitor.Enter(obj2);
						SingleConsumerUnboundedChannel<T> singleConsumerUnboundedChannel = parent;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rcx_v34 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+50]");
						object obj7 = default(object);
						if ((nint)0 == 0)
						{
							_ = 1;
							SingleConsumerUnboundedChannel<T> singleConsumerUnboundedChannel2 = parent;
							bool flag2 = parent == null;
							Exception ex = (Exception)4294967295L;
							uniTaskSource = (IUniTaskSource)(&obj);
							if (!flag2)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v441 @ rax_v58 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+28]");
								object obj3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v441 @ rax_v58 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+28]");
								bool flag3 = (nint)0 == 0;
								ex = (Exception)4294967295L;
								uniTaskSource = (IUniTaskSource)(&obj);
								if (!flag3)
								{
									bool flag4 = singleConsumerUnboundedChannel2.completedTaskSource == null;
									ex = (Exception)4294967295L;
									uniTaskSource = (IUniTaskSource)(&obj);
									if (!flag4)
									{
										nint num = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ rdx_v26 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelWriter>)+48]");
										object obj4 = 0;
										nint num2 = (nint)obj4;
										nint num3 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ rdx_v27 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelWriter>)+48]");
										uniTaskStatus = UniTaskStatus.Pending;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v699 @ rax_v60] (should have been resolved before IL gen)");
										object obj5 = default(object);
										bool flag5 = obj5 != null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ rdx_v27 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelWriter>)+48]");
										ex = (Exception)0;
										uniTaskSource = (IUniTaskSource)(&obj);
										if (!flag5)
										{
											SingleConsumerUnboundedChannel<T> singleConsumerUnboundedChannel3 = parent;
											if (error != null)
											{
												bool flag6 = parent == null;
												uniTaskSource = (IUniTaskSource)(&obj);
												if (flag6)
												{
													throw new NullReferenceException();
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v74 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+30]");
												if ((nint)0 == 0)
												{
													UniTask uniTask = UniTask.FromException(error);
													uniTaskSource = uniTask.source;
													_ = uniTask.source;
													num2 = unchecked((nint)null);
													uniTaskStatus = (UniTaskStatus)error;
												}
												else
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v74 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+30]");
													bool flag7 = (nint)0 == 0;
													uniTaskSource = (IUniTaskSource)(&obj);
													if (flag7)
													{
														throw new NullReferenceException();
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v74 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+30]");
													bool flag8 = ((UniTaskCompletionSource)0).TrySetException(error);
													num2 = unchecked((nint)null);
													uniTaskStatus = (UniTaskStatus)error;
													uniTaskSource = (IUniTaskSource)(&obj);
												}
											}
											else
											{
												bool flag9 = parent == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ rdx_v27 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelWriter>)+48]");
												ex = (Exception)0;
												uniTaskSource = (IUniTaskSource)(&obj);
												if (flag9)
												{
													throw new NullReferenceException();
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v74 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+30]");
												if ((nint)0 == 0)
												{
													uniTaskSource = (IUniTaskSource)UniTask.CompletedTask;
													if (parent == null)
													{
														throw new NullReferenceException();
													}
													_ = UniTask.CompletedTask;
												}
												else
												{
													bool flag10 = parent == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ rdx_v27 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelWriter>)+48]");
													ex = (Exception)0;
													uniTaskSource = (IUniTaskSource)(&obj);
													if (flag10)
													{
														throw new NullReferenceException();
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v74 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+30]");
													bool flag11 = (nint)0 == 0;
													uniTaskSource = (IUniTaskSource)(&obj);
													if (flag11)
													{
														ex = (Exception)uniTaskStatus;
														throw new NullReferenceException();
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v74 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+30]");
													bool flag12 = ((UniTaskCompletionSource)0).TrySignalCompletion(UniTaskStatus.Succeeded);
													num2 = unchecked((nint)null);
													uniTaskStatus = UniTaskStatus.Succeeded;
													uniTaskSource = (IUniTaskSource)(&obj);
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ rcx_v38+68]");
											bool flag13 = (nint)0 == 0;
											ex = (Exception)uniTaskStatus;
											if (!flag13)
											{
												SingleConsumerUnboundedChannel<T> singleConsumerUnboundedChannel4 = parent;
												if (parent == null)
												{
													throw new NullReferenceException();
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v671 @ rax_v76 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+28]");
												if ((nint)0 == 0)
												{
													throw new NullReferenceException();
												}
												nint num4 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ rdx_v33 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelWriter>)+50]");
												object obj6 = 0;
												nint num5 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1088 @ rax_v78] (should have been resolved before IL gen)");
												ex = error;
											}
										}
										num2 = (nint)parent;
										if (parent != null)
										{
											uniTaskStatus = (UniTaskStatus)ex;
											if (obj7 != null)
											{
												if (obj2 == null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
													uniTaskStatus = UniTaskStatus.Pending;
													object obj8 = default(object);
													throw obj8;
												}
												Monitor.Exit(obj2);
											}
											return true;
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						if (obj7 != null)
						{
							bool flag14 = obj2 == null;
							Exception ex = (Exception)4294967295L;
							uniTaskSource = (IUniTaskSource)(&obj);
							if (flag14)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
								object obj9 = default(object);
								throw obj9;
							}
							Monitor.Exit(obj2);
						}
						return false;
					}
					ArgumentException ex2 = new ArgumentException();
					uniTaskStatus = UniTaskStatus.Pending;
					throw ex2;
				}
				ArgumentNullException ex3 = new ArgumentNullException("obj");
				throw ex3;
			}
			Monitor.ThrowLockTakenException();
			throw null;
		}
	}

	private sealed class SingleConsumerUnboundedChannelReader : ChannelReader<T>, IUniTaskSource<bool>, IUniTaskSource, IValueTaskSource, IValueTaskSource<bool>
	{
		private sealed class ReadAllAsyncEnumerable : IUniTaskAsyncEnumerable<T>, IUniTaskAsyncEnumerator<T>, IUniTaskAsyncDisposable
		{
			private readonly Action<object> CancellationCallback1Delegate;

			private readonly Action<object> CancellationCallback2Delegate;

			private readonly SingleConsumerUnboundedChannelReader parent;

			private CancellationToken cancellationToken1;

			private CancellationToken cancellationToken2;

			private CancellationTokenRegistration cancellationTokenRegistration1;

			private CancellationTokenRegistration cancellationTokenRegistration2;

			private T current;

			private bool cacheValue;

			private bool running;

			public unsafe T Current
			{
				get
				{
					//IL_0008: Expected O, but got Ref
					//IL_0018: Expected O, but got I
					//IL_0037: Expected O, but got I
					//IL_0047: Expected O, but got I
					//IL_005d: Expected O, but got I
					//IL_0232: Unknown result type (might be due to invalid IL or missing references)
					//IL_0237: Expected O, but got Unknown
					//IL_0251: Expected O, but got I
					//IL_0261: Expected O, but got I
					//IL_0271: Expected O, but got I
					//IL_0281: Expected O, but got I
					//IL_0291: Expected O, but got I
					//IL_02a1: Expected O, but got I
					//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
					//IL_02b3: Expected O, but got Unknown
					//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
					//IL_02c1: Expected O, but got Unknown
					//IL_02f6: Expected O, but got I
					//IL_0306: Expected O, but got I
					//IL_0316: Expected O, but got I
					//IL_008e: Expected O, but got I8
					//IL_01c9: Expected O, but got I
					//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
					//IL_01db: Expected O, but got Unknown
					//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
					//IL_01e9: Expected O, but got Unknown
					//IL_00b0: Expected O, but got I
					//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
					//IL_00c2: Expected O, but got Unknown
					//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
					//IL_00d0: Expected O, but got Unknown
					//IL_0112: Expected O, but got I
					//IL_012a: Expected O, but got I
					//IL_013a: Expected O, but got I
					//IL_014a: Expected O, but got I
					//IL_015a: Expected O, but got I
					//IL_0167: Unknown result type (might be due to invalid IL or missing references)
					//IL_016c: Expected O, but got Unknown
					//IL_0175: Unknown result type (might be due to invalid IL or missing references)
					//IL_017a: Expected O, but got Unknown
					//IL_0375: Expected O, but got I
					//IL_0385: Expected O, but got I
					//IL_0395: Expected O, but got I
					//IL_03a5: Expected O, but got I
					//IL_03b5: Expected O, but got I
					//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
					//IL_03c7: Expected O, but got Unknown
					//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
					//IL_03d5: Expected O, but got Unknown
					object obj2 = default(object);
					object obj = (object)(&obj2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8+20]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rax_v1+C0]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r9_v1+28]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rax_v2+FC]");
					object obj6 = (nint)0 + (nint)15;
					object obj7 = obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rax_v2+FC]");
					if ((nint)obj7 <= 0)
					{
						obj6 = 1152921504606846960L;
					}
					object obj8 = obj6 & -16;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8+20]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8+20]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v5+C0]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v1+8]");
					object obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v6+80]");
					object obj13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rcx_v2+110]");
					object obj14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rcx_v2+118]");
					object obj15 = 0 + this;
					object obj16 = obj15 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v7+28]");
					if ((nint)0 >= (nint)0)
					{
						obj16 = obj15;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ r8_v1+C0]");
					object obj17 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v8+8]");
					object obj18 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v5+80]");
					object obj19 = 0;
					if (obj16 == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v3+50]");
						object obj20 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v3+58]");
						object obj21 = 0 + this;
						object obj22 = obj21 - 16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v13+28]");
						if ((nint)0 >= (nint)0)
						{
							obj22 = obj21;
						}
						object obj23 = obj22;
						if (obj22 == null)
						{
							return (T)new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8+20]");
						object obj24 = 0;
						object obj25 = obj23;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v15+C0]");
						object obj26 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rcx_v13+8]");
						object obj27 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rax_v16+80]");
						object obj28 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdx_v8+F0]");
						object obj29 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdx_v8+F8]");
						object obj30 = 0 + this;
						object obj31 = obj30 - 16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v17+28]");
						if ((nint)0 >= (nint)0)
						{
							obj31 = obj30;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v168 @ r9_v6+178] (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8+20]");
						object obj32 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v19+C0]");
						object obj33 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rcx_v15+8]");
						object obj34 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v20+80]");
						object obj35 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rcx_v16+F0]");
						object obj36 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rcx_v16+F8]");
						obj8 = 0 + this;
						object obj37 = obj8 - 16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v21+28]");
						if ((nint)0 >= (nint)0)
						{
							obj37 = obj8;
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v3+F0]");
						object obj38 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v3+F8]");
						object obj39 = 0 + this;
						object obj37 = obj39 - 16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v12+28]");
						if ((nint)0 >= (nint)0)
						{
							obj37 = obj39;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
					T result = default(T);
					return result;
				}
			}

			public ReadAllAsyncEnumerable(SingleConsumerUnboundedChannelReader parent, CancellationToken cancellationToken)
			{
				//IL_00c9: Expected O, but got I
				//IL_00d9: Expected O, but got I
				//IL_00e9: Expected O, but got I
				//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fb: Expected O, but got Unknown
				//IL_0104: Unknown result type (might be due to invalid IL or missing references)
				//IL_0109: Expected O, but got Unknown
				//IL_003d: Expected O, but got I
				//IL_004d: Expected O, but got I
				//IL_005d: Expected O, but got I
				//IL_006a: Unknown result type (might be due to invalid IL or missing references)
				//IL_006f: Expected O, but got Unknown
				//IL_0078: Unknown result type (might be due to invalid IL or missing references)
				//IL_007d: Expected O, but got Unknown
				//IL_0173: Expected O, but got I
				//IL_0183: Expected O, but got I
				//IL_0193: Expected O, but got I
				//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
				//IL_01a5: Expected O, but got Unknown
				//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
				//IL_01b3: Expected O, but got Unknown
				//IL_01e9: Expected O, but got I
				//IL_01f9: Expected O, but got I
				//IL_0209: Expected O, but got I
				//IL_0216: Unknown result type (might be due to invalid IL or missing references)
				//IL_021b: Expected O, but got Unknown
				//IL_0224: Unknown result type (might be due to invalid IL or missing references)
				//IL_0229: Expected O, but got Unknown
				nint method = default(nint);
				Action<object> action = new Action<object>(null, method);
				method = 0;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v2 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rcx_v6+80]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rdx_v3+10]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rdx_v3+18]");
				object obj4 = 0 + this;
				object obj5 = obj4 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rcx_v7+28]");
				if ((nint)0 >= (nint)0)
				{
				}
				obj5 = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ r8_v5 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+10]");
				Action<object> action2 = new Action<object>(null, (IntPtr)0);
				nint num2 = 0;
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdx_v6 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v13+80]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rdx_v7+30]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rdx_v7+38]");
				object obj9 = 0 + this;
				object obj10 = obj9 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rcx_v14+28]");
				if ((nint)0 < (nint)0)
				{
					obj10 = action2;
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rcx_v16 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v9+80]");
					object obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rcx_v17+50]");
					object obj13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rcx_v17+58]");
					object obj14 = 0 + this;
					object obj15 = obj14 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rax_v10+28]");
					if ((nint)0 < (nint)0)
					{
						obj15 = parent;
					}
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rcx_v19 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
					object obj16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v13+80]");
					object obj17 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ rcx_v20+70]");
					object obj18 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ rcx_v20+78]");
					object obj19 = 0 + this;
					object obj20 = obj19 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rax_v14+28]");
					if ((nint)0 >= (nint)0)
					{
						/*Error: End of method reached without returning.*/;
					}
					obj20 = cancellationToken;
				}
			}

			public IUniTaskAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
			{
				//IL_04ff: Expected O, but got I
				//IL_050f: Expected O, but got I
				//IL_051f: Expected O, but got I
				//IL_052c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0531: Expected O, but got Unknown
				//IL_053a: Unknown result type (might be due to invalid IL or missing references)
				//IL_053f: Expected O, but got Unknown
				//IL_0028: Expected O, but got I
				//IL_0038: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_0055: Unknown result type (might be due to invalid IL or missing references)
				//IL_005a: Expected O, but got Unknown
				//IL_0063: Unknown result type (might be due to invalid IL or missing references)
				//IL_0068: Expected O, but got Unknown
				//IL_0111: Expected O, but got I
				//IL_0121: Expected O, but got I
				//IL_0131: Expected O, but got I
				//IL_013e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0143: Expected O, but got Unknown
				//IL_014c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0151: Expected O, but got Unknown
				//IL_00d1: Expected O, but got I
				//IL_00e7: Expected O, but got I
				//IL_02bb: Expected O, but got I
				//IL_02cb: Expected O, but got I
				//IL_02db: Expected O, but got I
				//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
				//IL_02ed: Expected O, but got Unknown
				//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
				//IL_02fb: Expected O, but got Unknown
				//IL_0199: Expected O, but got I
				//IL_01a9: Expected O, but got I
				//IL_01b9: Expected O, but got I
				//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
				//IL_01cb: Expected O, but got Unknown
				//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
				//IL_01d9: Expected O, but got Unknown
				//IL_05a4: Expected O, but got I
				//IL_05b4: Expected O, but got I
				//IL_05c4: Expected O, but got I
				//IL_05d1: Unknown result type (might be due to invalid IL or missing references)
				//IL_05d6: Expected O, but got Unknown
				//IL_05df: Unknown result type (might be due to invalid IL or missing references)
				//IL_05e4: Expected O, but got Unknown
				//IL_0460: Expected O, but got I
				//IL_0470: Expected O, but got I
				//IL_0480: Expected O, but got I
				//IL_048d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0492: Expected O, but got Unknown
				//IL_049b: Unknown result type (might be due to invalid IL or missing references)
				//IL_04a0: Expected O, but got Unknown
				//IL_06eb: Expected O, but got I4
				//IL_0343: Expected O, but got I
				//IL_0353: Expected O, but got I
				//IL_0363: Expected O, but got I
				//IL_0370: Unknown result type (might be due to invalid IL or missing references)
				//IL_0375: Expected O, but got Unknown
				//IL_037e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0383: Expected O, but got Unknown
				//IL_0240: Expected O, but got I
				//IL_0250: Expected O, but got I
				//IL_0260: Expected O, but got I
				//IL_026d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0272: Expected O, but got Unknown
				//IL_027b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0280: Expected O, but got Unknown
				//IL_065e: Expected O, but got I
				//IL_066e: Expected O, but got I
				//IL_067e: Expected O, but got I
				//IL_068b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0690: Expected O, but got Unknown
				//IL_0699: Unknown result type (might be due to invalid IL or missing references)
				//IL_069e: Expected O, but got Unknown
				//IL_03ea: Expected O, but got I
				//IL_03fa: Expected O, but got I
				//IL_040a: Expected O, but got I
				//IL_0417: Unknown result type (might be due to invalid IL or missing references)
				//IL_041c: Expected O, but got Unknown
				//IL_0425: Unknown result type (might be due to invalid IL or missing references)
				//IL_042a: Expected O, but got Unknown
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rcx_v2 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v3+80]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rcx_v3+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rcx_v3+138]");
				object obj4 = 0 + this;
				object obj5 = obj4 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v4+28]");
				if ((nint)0 >= (nint)0)
				{
					obj5 = obj4;
				}
				if (obj5 == null)
				{
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v11 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v11+80]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v12+70]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v12+78]");
					object obj9 = 0 + this;
					object obj10 = obj9 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v12+28]");
					if ((nint)0 >= (nint)0)
					{
						obj10 = obj9;
					}
					if (obj10 != (object)cancellationToken)
					{
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rcx_v65 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
						object obj11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rax_v77+80]");
						object obj12 = --128;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804EC8C0");
					}
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rcx_v18 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
					object obj13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v19+80]");
					object obj14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rcx_v19+70]");
					object obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rcx_v19+78]");
					object obj16 = 0 + this;
					object obj17 = obj16 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rax_v20+28]");
					if ((nint)0 >= (nint)0)
					{
						obj17 = obj16;
					}
					if ((nint)obj17 > 0)
					{
						nint num5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rcx_v50 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
						object obj18 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rax_v58+80]");
						object obj19 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rcx_v51+70]");
						object obj20 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rcx_v51+78]");
						object obj21 = 0 + this;
						object cancellationToken2 = obj21 - 16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rax_v59+28]");
						if ((nint)0 >= (nint)0)
						{
							cancellationToken2 = obj21;
						}
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rcx_v52 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
						object obj22 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v376 @ rax_v61+80]");
						object obj23 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v377 @ rcx_v53+10]");
						object obj24 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v377 @ rcx_v53+18]");
						object obj25 = 0 + this;
						object callback = obj25 - 16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rax_v62+28]");
						if ((nint)0 >= (nint)0)
						{
							callback = obj25;
						}
						CancellationTokenRegistration cancellationTokenRegistration = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext((CancellationToken)cancellationToken2, (Action<object>)callback, this);
						nint num7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ rcx_v58 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
						object obj26 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rax_v66+80]");
						object obj27 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rcx_v59+B0]");
						object obj28 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rcx_v59+B8]");
						object obj29 = 0 + this;
						object obj30 = obj29 - 16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rax_v67+28]");
						if ((nint)0 < (nint)0)
						{
							obj30 = cancellationTokenRegistration.m_callbackInfo;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rax_v64 (System.Threading.CancellationTokenRegistration)+10]");
							_ = 0;
						}
					}
					nint num8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rcx_v24 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
					object obj31 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rax_v24+80]");
					object obj32 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rcx_v25+90]");
					object obj33 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rcx_v25+98]");
					object obj34 = 0 + this;
					object obj35 = obj34 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ rax_v25+28]");
					if ((nint)0 >= (nint)0)
					{
						obj35 = obj34;
					}
					if ((nint)obj35 > 0)
					{
						nint num9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ rcx_v35 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
						object obj36 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rax_v39+80]");
						object obj37 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ rcx_v36+90]");
						object obj38 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ rcx_v36+98]");
						object obj39 = 0 + this;
						object cancellationToken3 = obj39 - 16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ rax_v40+28]");
						if ((nint)0 >= (nint)0)
						{
							cancellationToken3 = obj39;
						}
						nint num10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rcx_v37 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
						object obj40 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v42+80]");
						object obj41 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v566 @ rcx_v38+30]");
						object obj42 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v566 @ rcx_v38+38]");
						object obj43 = 0 + this;
						object callback2 = obj43 - 16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ rax_v43+28]");
						if ((nint)0 >= (nint)0)
						{
							callback2 = obj43;
						}
						CancellationTokenRegistration cancellationTokenRegistration2 = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext((CancellationToken)cancellationToken3, (Action<object>)callback2, this);
						nint num11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v681 @ rcx_v43 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
						object obj44 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rax_v47+80]");
						object obj45 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v490 @ rcx_v44+D0]");
						object obj46 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v490 @ rcx_v44+D8]");
						object obj47 = 0 + this;
						object obj48 = obj47 - 16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v487 @ rax_v48+28]");
						if ((nint)0 < (nint)0)
						{
							obj48 = cancellationTokenRegistration2.m_callbackInfo;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v641 @ rax_v45 (System.Threading.CancellationTokenRegistration)+10]");
							_ = 0;
						}
					}
					nint num12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v527 @ rcx_v29 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
					object obj49 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v528 @ rax_v28+80]");
					object obj50 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rcx_v30+130]");
					object obj51 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rcx_v30+138]");
					object obj52 = 0 + this;
					object obj53 = obj52 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ rax_v29+28]");
					if ((nint)0 < (nint)0)
					{
						obj53 = 1;
					}
					return this;
				}
				object obj54 = new InvalidOperationException();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E209C0");
				throw obj54;
			}

			public UniTask<bool> MoveNextAsync()
			{
				//IL_0101: Expected O, but got I
				//IL_0111: Expected O, but got I
				//IL_0121: Expected O, but got I
				//IL_0131: Expected O, but got I
				//IL_0141: Expected O, but got I
				//IL_0156: Expected O, but got I
				//IL_015f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0164: Expected O, but got Unknown
				//IL_019a: Expected O, but got I4
				//IL_0015: Expected O, but got I
				//IL_0025: Expected O, but got I
				//IL_0035: Expected O, but got I
				//IL_0045: Expected O, but got I
				//IL_0055: Expected O, but got I
				//IL_006a: Expected O, but got I
				//IL_0073: Unknown result type (might be due to invalid IL or missing references)
				//IL_0078: Expected O, but got Unknown
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8+20]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2+C0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ r9_v1+8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v3+80]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rdx_v1+110]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rdx_v1+118]");
				nint num = default(nint);
				object obj6 = 0 + num;
				object obj7 = obj6 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v4+28]");
				object obj14 = default(object);
				if ((nint)0 < (nint)0)
				{
					obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8+20]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v6+C0]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rcx_v5+8]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rax_v7+80]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v6+50]");
					object obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v6+58]");
					object obj13 = 0 + num;
					obj14 = obj13 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v8+28]");
					if ((nint)0 >= (nint)0)
					{
						obj14 = obj13;
					}
				}
				object obj15 = obj14;
				if (obj14 != null)
				{
					object obj16 = obj15;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v171 @ r9_v2+188] (should have been resolved before IL gen)");
					object obj17 = default(object);
					ReadAllAsyncEnumerable readAllAsyncEnumerable = (ReadAllAsyncEnumerable)obj17;
					return (UniTask<bool>)this;
				}
				return (UniTask<bool>)new NullReferenceException();
			}

			public unsafe UniTask DisposeAsync()
			{
				//IL_0005: Expected native int or pointer, but got O
				//IL_0020: Expected O, but got I
				//IL_0030: Expected O, but got I
				//IL_0040: Expected O, but got I
				//IL_004d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0052: Expected O, but got Unknown
				//IL_005b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0060: Expected O, but got Unknown
				//IL_00be: Expected O, but got I
				//IL_00ce: Expected O, but got I
				//IL_00de: Expected O, but got I
				//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f0: Expected O, but got Unknown
				//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fe: Expected O, but got Unknown
				//IL_0131: Expected native int or pointer, but got O
				UniTask uniTask = default(UniTask);
				System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ r9_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rax_v2+80]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ r9_v2+B0]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ r9_v2+B8]");
				CancellationTokenRegistration cancellationTokenRegistration = (CancellationTokenRegistration)(0 + this);
				CancellationTokenRegistration cancellationTokenRegistration2 = (CancellationTokenRegistration)(cancellationTokenRegistration - 16);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rax_v3+28]");
				if ((nint)0 >= (nint)0)
				{
					cancellationTokenRegistration2 = cancellationTokenRegistration;
				}
				((CancellationTokenRegistration*)cancellationTokenRegistration2)->Dispose();
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rcx_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v6+80]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rcx_v4+D0]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rcx_v4+D8]");
				CancellationTokenRegistration cancellationTokenRegistration3 = (CancellationTokenRegistration)(0 + this);
				CancellationTokenRegistration cancellationTokenRegistration4 = (CancellationTokenRegistration)(cancellationTokenRegistration3 - 16);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v7+28]");
				if ((nint)0 >= (nint)0)
				{
					cancellationTokenRegistration4 = cancellationTokenRegistration3;
				}
				((CancellationTokenRegistration*)cancellationTokenRegistration4)->Dispose();
				System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
				return uniTask;
			}

			private static void CancellationCallback1(object state)
			{
				//IL_0086: Expected O, but got I
				//IL_0096: Expected O, but got I
				//IL_00a6: Expected O, but got I
				//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
				//IL_00bb: Expected O, but got Unknown
				//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c9: Expected O, but got Unknown
				//IL_0111: Expected O, but got I
				//IL_0121: Expected O, but got I
				//IL_0131: Expected O, but got I
				//IL_0141: Unknown result type (might be due to invalid IL or missing references)
				//IL_0146: Expected O, but got Unknown
				//IL_014f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0154: Expected O, but got Unknown
				//IL_01a1: Expected O, but got I
				//IL_01c4: Expected O, but got I
				nint num = 0;
				bool flag = state == null;
				object obj = null;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
					bool flag2 = state != null;
					obj = null;
					if (!flag2)
					{
						obj = state;
					}
					if (obj == null)
					{
						goto IL_01ce;
					}
				}
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v10 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rcx_v5+80]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdx_v2+50]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdx_v2+58]");
				object obj5 = 0 + obj;
				object obj6 = obj5 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v11+28]");
				if ((nint)0 >= (nint)0)
				{
					obj6 = obj5;
				}
				object obj7 = obj6;
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v14 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v9+80]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v3+70]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v3+78]");
				object obj11 = 0 + obj;
				object obj12 = obj11 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v15+28]");
				if ((nint)0 >= (nint)0)
				{
					obj12 = obj11;
				}
				object obj13 = obj12;
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v18 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+50]");
				object obj14 = 0;
				object obj15 = obj14;
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ r8_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+50]");
				object obj16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v251 @ rdi_v2 (should have been resolved before IL gen)");
				goto IL_01ce;
				IL_01ce:
				throw new InvalidCastException();
			}

			private static void CancellationCallback2(object state)
			{
				//IL_0086: Expected O, but got I
				//IL_0096: Expected O, but got I
				//IL_00a6: Expected O, but got I
				//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
				//IL_00bb: Expected O, but got Unknown
				//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c9: Expected O, but got Unknown
				//IL_0111: Expected O, but got I
				//IL_0121: Expected O, but got I
				//IL_0131: Expected O, but got I
				//IL_0141: Unknown result type (might be due to invalid IL or missing references)
				//IL_0146: Expected O, but got Unknown
				//IL_014f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0154: Expected O, but got Unknown
				//IL_01a1: Expected O, but got I
				//IL_01c4: Expected O, but got I
				nint num = 0;
				bool flag = state == null;
				object obj = null;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
					bool flag2 = state != null;
					obj = null;
					if (!flag2)
					{
						obj = state;
					}
					if (obj == null)
					{
						goto IL_01ce;
					}
				}
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v10 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rcx_v5+80]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdx_v2+50]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdx_v2+58]");
				object obj5 = 0 + obj;
				object obj6 = obj5 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v11+28]");
				if ((nint)0 >= (nint)0)
				{
					obj6 = obj5;
				}
				object obj7 = obj6;
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v14 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+8]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v9+80]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v3+90]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v3+98]");
				object obj11 = 0 + obj;
				object obj12 = obj11 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v15+28]");
				if ((nint)0 >= (nint)0)
				{
					obj12 = obj11;
				}
				object obj13 = obj12;
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v18 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+50]");
				object obj14 = 0;
				object obj15 = obj14;
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ r8_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader+ReadAllAsyncEnumerable>)+50]");
				object obj16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v251 @ rdi_v2 (should have been resolved before IL gen)");
				goto IL_01ce;
				IL_01ce:
				throw new InvalidCastException();
			}
		}

		private readonly Action<object> CancellationCallbackDelegate;

		private readonly SingleConsumerUnboundedChannel<T> parent;

		private CancellationToken cancellationToken;

		private CancellationTokenRegistration cancellationTokenRegistration;

		private UniTaskCompletionSourceCore<bool> core;

		internal bool isWaiting;

		public unsafe override UniTask Completion
		{
			get
			{
				//IL_01be: Expected O, but got I
				//IL_0267: Expected native int or pointer, but got O
				//IL_0184: Expected O, but got I
				//IL_00d3: Expected O, but got I
				//IL_00ef: Expected O, but got I
				//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fd: Expected O, but got Unknown
				//IL_0114: Unknown result type (might be due to invalid IL or missing references)
				//IL_0119: Expected O, but got Unknown
				//IL_0122: Unknown result type (might be due to invalid IL or missing references)
				//IL_0127: Expected O, but got Unknown
				//IL_0134: Unknown result type (might be due to invalid IL or missing references)
				//IL_0139: Expected O, but got Unknown
				//IL_027f: Expected O, but got I4
				//IL_028f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0294: Expected O, but got Unknown
				SingleConsumerUnboundedChannel<T> singleConsumerUnboundedChannel = parent;
				IUniTaskSource uniTaskSource;
				IUniTaskSource source;
				if (parent != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v2 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+30]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v2 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+50]");
						if ((nint)0 == 0)
						{
							UniTaskCompletionSource uniTaskCompletionSource = new UniTaskCompletionSource();
							if (parent != null)
							{
								SingleConsumerUnboundedChannel<T> singleConsumerUnboundedChannel2 = parent;
								if (parent != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v10 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+30]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
										bool flag = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v10 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+30]");
										uniTaskSource = (IUniTaskSource)0;
										if (flag)
										{
											goto IL_01c3;
										}
										object obj = (nint)(&uniTaskSource) >> 12;
										object obj2 = obj & 0x1FFFFF;
										object obj3 = obj2 >> 6;
										object obj4 = obj2 & 0x3F;
										object obj5 = obj3 * 8;
										object obj6 = 6603577472L + obj5;
										nint num2;
										do
										{
											object obj7 = 1 << (int)obj4;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdx_v7+462E0]");
											object obj8 = 0 | obj7;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdx_v7+462E0]");
											nint num = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdx_v7+462E0]");
											if (num == 0)
											{
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdx_v7+462E0]");
											num2 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdx_v7+462E0]");
										}
										while (num2 != 0);
										source = uniTaskSource;
										goto IL_025f;
									}
								}
							}
						}
						else if (parent != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v2 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+38]");
							source = (IUniTaskSource)0;
							goto IL_025f;
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v2 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+30]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v2 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+30]");
							uniTaskSource = (IUniTaskSource)0;
							goto IL_01c3;
						}
					}
				}
				return (UniTask)new NullReferenceException();
				IL_01c3:
				source = uniTaskSource;
				goto IL_025f;
				IL_025f:
				UniTask uniTask = default(UniTask);
				System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, source);
				return uniTask;
			}
		}

		public SingleConsumerUnboundedChannelReader(SingleConsumerUnboundedChannel<T> parent)
		{
			//IL_001b: Expected O, but got I
			nint method = default(nint);
			Action<object> cancellationCallbackDelegate = new Action<object>(null, method);
			method = 0;
			CancellationCallbackDelegate = cancellationCallbackDelegate;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v6 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v97 @ rax_v6] (should have been resolved before IL gen)");
			this.parent = parent;
		}

		public unsafe override bool TryRead(out T item)
		{
			//IL_0008: Expected O, but got Ref
			//IL_07f2: Expected O, but got I
			//IL_0808: Expected O, but got I
			//IL_0931: Unknown result type (might be due to invalid IL or missing references)
			//IL_0936: Expected O, but got Unknown
			//IL_0042: Expected O, but got Ref
			//IL_0055: Expected O, but got Ref
			//IL_0070: Expected O, but got I
			//IL_001f: Expected O, but got I8
			//IL_083e: Expected O, but got I4
			//IL_0103: Expected O, but got I
			//IL_012d: Expected O, but got I
			//IL_020b: Expected O, but got I
			//IL_021e: Expected O, but got Ref
			//IL_01bc: Expected O, but got I4
			//IL_01db: Expected O, but got I
			//IL_02d0: Expected O, but got I
			//IL_02d8: Expected I, but got O
			//IL_0723: Expected O, but got I
			//IL_0422: Expected O, but got I
			//IL_0520: Expected O, but got I
			//IL_0547: Expected I, but got O
			//IL_0557: Expected O, but got I
			//IL_063d: Expected O, but got I
			//IL_065a: Expected O, but got I
			//IL_065a: Expected O, but got I
			//IL_08a0: Expected O, but got I4
			//IL_046b: Expected O, but got I
			//IL_069f: Expected I, but got O
			//IL_05b0: Expected I, but got O
			//IL_05c0: Expected O, but got I
			//IL_04b0: Expected I, but got O
			//IL_06be: Expected O, but got I
			//IL_05df: Expected O, but got I
			//IL_04d8: Expected O, but got I
			//IL_03f7: Expected O, but got I
			object obj2 = default(object);
			object obj = (object)(&obj2);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader>)+48]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v3+FC]");
			object obj4 = (nint)0 + (nint)15;
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v3+FC]");
			if ((nint)obj5 <= 0)
			{
				obj4 = 1152921504606846960L;
			}
			object obj6 = obj4 & -16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			SingleConsumerUnboundedChannel<T> singleConsumerUnboundedChannel = parent;
			_ = singleConsumerUnboundedChannel.completedTaskSource;
			_ = 0;
			object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
			object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
			IUniTaskSource uniTaskSource = (IUniTaskSource)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
					object obj11;
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
						Monitor.Enter(0);
						SingleConsumerUnboundedChannel<T> singleConsumerUnboundedChannel2 = parent;
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rdx_v34 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader>)+30]");
						object obj9 = 0;
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v407 @ rax_v72] (should have been resolved before IL gen)");
						object obj10 = default(object);
						nint num4;
						UniTaskStatus uniTaskStatus;
						if (obj10 == null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
								bool flag = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v3+FC]");
								num4 = 0;
								obj11 = 0;
								if (flag)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
									uniTaskStatus = UniTaskStatus.Pending;
									object obj12 = default(object);
									throw obj12;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
								Monitor.Exit(0);
							}
							return false;
						}
						SingleConsumerUnboundedChannel<T> singleConsumerUnboundedChannel3 = parent;
						nint num5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v579 @ rcx_v50 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader>)+40]");
						object obj13 = 0;
						_ = ref obj2;
						object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 120));
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v580 @ rdx_v37+10] (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
						uniTaskStatus = (UniTaskStatus)(int)(&obj2);
						SingleConsumerUnboundedChannel<T> singleConsumerUnboundedChannel4 = parent;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v735 @ rax_v83 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+50]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v3+FC]");
						num4 = 0;
						if (!flag2)
						{
							bool flag3 = singleConsumerUnboundedChannel4.completedTaskSource == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v3+FC]");
							num4 = 0;
							if (flag3)
							{
								throw new NullReferenceException();
							}
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v921 @ rdx_v42 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader>)+30]");
							object obj15 = 0;
							num4 = (nint)obj15;
							nint num7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v924 @ rdx_v43 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader>)+30]");
							uniTaskStatus = UniTaskStatus.Pending;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v922 @ rax_v90] (should have been resolved before IL gen)");
							object obj16 = default(object);
							if (obj16 == null)
							{
								SingleConsumerUnboundedChannel<T> singleConsumerUnboundedChannel5 = parent;
								if (parent != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v93 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+48]");
									if ((nint)0 == 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v93 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+30]");
										if ((nint)0 == 0)
										{
											uniTaskSource = (IUniTaskSource)UniTask.CompletedTask;
											if (parent == null)
											{
												throw new NullReferenceException();
											}
											_ = UniTask.CompletedTask;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
												if ((nint)0 == 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
													uniTaskStatus = UniTaskStatus.Pending;
													object obj17 = default(object);
													throw obj17;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
												Monitor.Exit(0);
											}
										}
										else
										{
											bool flag4 = parent == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v924 @ rdx_v43 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader>)+30]");
											Exception ex = (Exception)0;
											if (flag4)
											{
												throw new NullReferenceException();
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v93 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+30]");
											if ((nint)0 == 0)
											{
												ex = (Exception)uniTaskStatus;
												throw new NullReferenceException();
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v93 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+30]");
											bool flag5 = ((UniTaskCompletionSource)0).TrySignalCompletion(UniTaskStatus.Succeeded);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
												bool flag6 = (nint)0 == 0;
												num4 = unchecked((nint)null);
												uniTaskStatus = UniTaskStatus.Succeeded;
												if (flag6)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
													uniTaskStatus = UniTaskStatus.Pending;
													object obj18 = default(object);
													throw obj18;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
												Monitor.Exit(0);
											}
										}
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v93 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+30]");
										if ((nint)0 == 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v93 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+48]");
											UniTask uniTask = UniTask.FromException((Exception)0);
											uniTaskSource = uniTask.source;
											bool flag7 = parent == null;
											num4 = unchecked((nint)null);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v93 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+48]");
											Exception ex2 = (Exception)0;
											if (flag7)
											{
												throw new NullReferenceException();
											}
											_ = uniTask.source;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
												bool flag8 = (nint)0 == 0;
												num4 = unchecked((nint)null);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v93 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+48]");
												Exception ex = (Exception)0;
												if (flag8)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
													ex2 = null;
													object obj19 = default(object);
													throw obj19;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
												Monitor.Exit(0);
											}
										}
										else
										{
											if (parent == null)
											{
												throw new NullReferenceException();
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v93 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+30]");
											if ((nint)0 == 0)
											{
												throw new NullReferenceException();
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v93 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+48]");
											Exception ex2 = (Exception)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v93 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+30]");
											nint num8 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v93 (Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1<T>)+48]");
											bool flag9 = ((UniTaskCompletionSource)num8).TrySetException((Exception)0);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
												bool flag10 = (nint)0 == 0;
												num4 = unchecked((nint)null);
												if (flag10)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
													uniTaskStatus = UniTaskStatus.Pending;
													object obj20 = default(object);
													throw obj20;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
												Monitor.Exit(0);
											}
										}
									}
									goto IL_072d;
								}
								throw new NullReferenceException();
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
								object obj21 = default(object);
								throw obj21;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
							Monitor.Exit(0);
						}
						goto IL_072d;
					}
					ArgumentException ex3 = new ArgumentException();
					obj11 = 0;
					throw ex3;
				}
				ArgumentNullException ex4 = new ArgumentNullException("obj");
				throw ex4;
			}
			Monitor.ThrowLockTakenException();
			throw null;
			IL_072d:
			return true;
		}

		public unsafe override UniTask<bool> WaitToReadAsync(CancellationToken cancellationToken)
		{
			//IL_00b0: Expected O, but got Ref
			//IL_0525: Expected O, but got I4
			//IL_00d7: Expected O, but got I
			//IL_00ec: Expected O, but got I
			//IL_00fc: Expected O, but got I
			//IL_010c: Expected O, but got I
			//IL_0114: Expected I, but got O
			//IL_0124: Expected O, but got I
			//IL_0134: Expected O, but got I
			//IL_0144: Expected O, but got I
			//IL_017e: Expected O, but got I
			//IL_019d: Expected O, but got Ref
			//IL_0469: Expected O, but got Ref
			//IL_034b: Expected O, but got Ref
			//IL_0353: Expected I, but got O
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e1: Expected O, but got Unknown
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Expected O, but got Unknown
			//IL_0238: Expected O, but got Ref
			//IL_023e: Expected O, but got I
			//IL_02d2: Expected I, but got O
			//IL_0424: Expected O, but got Ref
			//IL_042c: Expected I, but got O
			//IL_027a: Expected O, but got I
			//IL_027a: Expected O, but got I
			//IL_028e: Expected O, but got I
			//IL_02b5: Expected O, but got I
			//IL_02c5: Expected O, but got I
			//IL_04ba: Expected O, but got I4
			//IL_03c9: Expected O, but got Ref
			//IL_03d9: Expected O, but got I
			//IL_049d: Expected O, but got I4
			//IL_054d: Expected O, but got I4
			CancellationToken cancellationToken2 = default(CancellationToken);
			nint num = default(nint);
			if (num != 0 && (nint)0 >= (nint)2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1831F0830");
				SingleConsumerUnboundedChannelReader singleConsumerUnboundedChannelReader = (SingleConsumerUnboundedChannelReader)cancellationToken2;
			}
			else
			{
				object obj = default(object);
				if (obj != null)
				{
					Monitor.ThrowLockTakenException();
					throw null;
				}
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArgumentNullException ex = new ArgumentNullException("obj");
					throw ex;
				}
				bool flag = obj != null;
				object obj3 = (object)(&obj);
				if (flag)
				{
					ArgumentException ex2 = new ArgumentException();
					CancellationToken cancellationToken3 = (CancellationToken)0;
					throw ex2;
				}
				Monitor.Enter(obj2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ rdx (System.Threading.CancellationToken)+18]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v623 @ r9_v2+20]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v600 @ rax_v47+C0]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ rdx_v21+30]");
				object obj7 = 0;
				nint num2 = (nint)obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v623 @ r9_v2+20]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rax_v49+C0]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v605 @ rdx_v22+30]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v602 @ rax_v48] (should have been resolved before IL gen)");
				object obj11 = default(object);
				object obj13 = default(object);
				CancellationToken cancellationToken4;
				if (obj11 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ rdx (System.Threading.CancellationToken)+18]");
					object obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ rdx (System.Threading.CancellationToken)+18]");
					bool flag2 = (nint)0 == 0;
					obj3 = (object)(&obj);
					if (flag2)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v59+50]");
					if ((nint)0 == 0)
					{
						CancellationTokenRegistration cancellationTokenRegistration = (CancellationTokenRegistration)(cancellationToken + 40);
						((CancellationTokenRegistration*)cancellationTokenRegistration)->Dispose();
						UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(cancellationToken + 64);
						((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->Reset();
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ rdx (System.Threading.CancellationToken)+20]");
						bool flag3 = (nint)0 <= (nint)0;
						obj3 = (object)(&obj);
						CancellationToken cancellationToken3 = (CancellationToken)0;
						Action<object> action = (Action<object>)obj7;
						if (!flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ rdx (System.Threading.CancellationToken)+20]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ rdx (System.Threading.CancellationToken)+10]");
							CancellationTokenRegistration cancellationTokenRegistration2 = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext((CancellationToken)num3, (Action<object>)0, cancellationToken);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1040 @ rax_v88 (System.Threading.CancellationTokenRegistration)+10]");
							obj3 = 0;
							_ = cancellationTokenRegistration2.m_callbackInfo;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1040 @ rax_v88 (System.Threading.CancellationTokenRegistration)+10]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ rdx (System.Threading.CancellationToken)+20]");
							cancellationToken3 = (CancellationToken)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ rdx (System.Threading.CancellationToken)+10]");
							action = (Action<object>)0;
						}
						num = (nint)action;
						if (obj13 != null)
						{
							if (obj2 == null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
								object obj14 = 0;
								object obj15 = default(object);
								throw obj15;
							}
							Monitor.Exit(obj2);
						}
						cancellationToken4 = cancellationToken;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ rdx (System.Threading.CancellationToken)+18]");
						bool flag4 = (nint)0 == 0;
						obj3 = (object)(&obj);
						num = (nint)obj7;
						if (flag4)
						{
							num2 = num;
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v59+48]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1831F0DB0");
							if (obj13 != null)
							{
								bool flag5 = obj2 == null;
								obj3 = (object)(&obj);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v59+48]");
								object obj14 = 0;
								num = 0;
								if (flag5)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
									obj10 = 0;
									object obj16 = default(object);
									throw obj16;
								}
								Monitor.Exit(obj2);
							}
							cancellationToken4 = cancellationToken2;
						}
						else
						{
							cancellationToken4 = (CancellationToken)CompletedTasks.False;
							if (obj13 != null)
							{
								bool flag6 = obj2 == null;
								obj3 = (object)(&obj);
								num = (nint)obj7;
								if (flag6)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
									obj10 = 0;
									object obj17 = default(object);
									throw obj17;
								}
								Monitor.Exit(obj2);
							}
						}
					}
				}
				else
				{
					cancellationToken4 = (CancellationToken)CompletedTasks.True;
					if (obj13 != null)
					{
						bool flag7 = obj2 == null;
						obj3 = (object)(&obj);
						if (flag7)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
							object obj18 = default(object);
							throw obj18;
						}
						Monitor.Exit(obj2);
					}
				}
				SingleConsumerUnboundedChannelReader singleConsumerUnboundedChannelReader = (SingleConsumerUnboundedChannelReader)cancellationToken4;
			}
			return (UniTask<bool>)this;
		}

		public unsafe void SingalContinuation()
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 64);
			bool flag = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->TrySetResult(result: true);
		}

		public unsafe void SingalCancellation(CancellationToken cancellationToken)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 64);
			bool flag = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->TrySetCanceled(cancellationToken);
		}

		public unsafe void SingalCompleted(Exception error)
		{
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 64);
			if (error == null)
			{
				bool flag = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->TrySetResult(result: false);
			}
			else
			{
				bool flag2 = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->TrySetException(error);
			}
		}

		public override IUniTaskAsyncEnumerable<T> ReadAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			//IL_0026: Expected O, but got I
			nint num = 0;
			IUniTaskAsyncEnumerable<T> result = null;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdx_v2 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader>)+58]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v42 @ r10_v1] (should have been resolved before IL gen)");
			return result;
		}

		unsafe bool IUniTaskSource<bool>.GetResult(short token)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 64);
			return ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->GetResult(token);
		}

		unsafe void IUniTaskSource.GetResult(short token)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 64);
			bool result = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->GetResult(token);
		}

		unsafe UniTaskStatus IUniTaskSource.GetStatus(short token)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 64);
			return ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->GetStatus(token);
		}

		unsafe void IUniTaskSource.OnCompleted(Action<object> continuation, object state, short token)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 64);
			((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->OnCompleted(continuation, state, token);
		}

		unsafe UniTaskStatus IUniTaskSource.UnsafeGetStatus()
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 64);
			return ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->UnsafeGetStatus();
		}

		private static void CancellationCallback(object state)
		{
			//IL_0076: Expected O, but got I
			//IL_0091: Expected O, but got I
			//IL_00b4: Expected O, but got I
			nint num = 0;
			if (state != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader>)+8]");
				bool flag = state != null;
				object obj = null;
				if (!flag)
				{
					obj = state;
				}
				if (obj == null)
				{
					goto IL_00ea;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v3 (System.Object)+20]");
				object obj2 = 0;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v11 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader>)+68]");
				object obj3 = 0;
				object obj4 = obj3;
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1+SingleConsumerUnboundedChannelReader>)+68]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v118 @ rbp_v1 (should have been resolved before IL gen)");
			}
			NullReferenceException ex = new NullReferenceException();
			goto IL_00ea;
			IL_00ea:
			throw new InvalidCastException();
		}
	}

	private readonly Queue<T> items;

	private readonly SingleConsumerUnboundedChannelReader readerSource;

	private UniTaskCompletionSource completedTaskSource;

	private UniTask completedTask;

	private Exception completionError;

	private bool closed;

	public SingleConsumerUnboundedChannel()
	{
		//IL_003e: Expected O, but got I
		//IL_007d: Expected O, but got I
		//IL_009d: Expected O, but got I
		//IL_00cd: Expected O, but got I
		//IL_00f7: Expected O, but got I
		nint num = 0;
		IntPtr intPtr = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v14 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1>>)] (should have been resolved before IL gen)");
		nint num2 = 0;
		UniTaskCompletionSource uniTaskCompletionSource = null;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdx_v2 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1>)+20]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v44 @ r8_v3] (should have been resolved before IL gen)");
		completedTaskSource = uniTaskCompletionSource;
		nint num4 = 0;
		object obj2 = null;
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdx_v5 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1>)+38]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v136 @ r9_v1] (should have been resolved before IL gen)");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdx_v7 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1>)+40]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v143 @ r9_v2] (should have been resolved before IL gen)");
		nint num7 = 0;
		object obj5 = null;
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rdx_v9 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1>)+58]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v169 @ r9_v3] (should have been resolved before IL gen)");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rcx_v19 (Il2CppRgctx<Cysharp.Threading.Tasks.SingleConsumerUnboundedChannel`1>)+60]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v222 @ rax_v23] (should have been resolved before IL gen)");
	}
}
