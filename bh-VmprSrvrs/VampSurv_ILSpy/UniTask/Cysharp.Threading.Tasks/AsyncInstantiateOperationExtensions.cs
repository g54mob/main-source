using System;
using System.Threading;
using System.Threading.Tasks.Sources;
using Cpp2ILInjected;
using Cysharp.Threading.Tasks.Internal;
using UnityEngine;

namespace Cysharp.Threading.Tasks;

public static class AsyncInstantiateOperationExtensions
{
	private sealed class AsyncInstantiateOperationConfiguredSource : IUniTaskSource<UnityEngine.Object[]>, IUniTaskSource, IValueTaskSource, IValueTaskSource<UnityEngine.Object[]>, IPlayerLoopItem, ITaskPoolNode<AsyncInstantiateOperationConfiguredSource>
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9;

			public static Action<object> _003C_003E9__14_0;

			static _003C_003Ec()
			{
				_003C_003Ec obj = new _003C_003Ec();
				_003C_003E9 = obj;
			}

			internal int _003C_002Ecctor_003Eb__4_0()
			{
				//IL_0013: Expected I, but got O
				nint num = (nint)typeof(AsyncInstantiateOperationConfiguredSource);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v3 (Il2CppClass<Cysharp.Threading.Tasks.AsyncInstantiateOperationExtensions+AsyncInstantiateOperationConfiguredSource>)+B8]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v4 (Il2CppStaticFields<Cysharp.Threading.Tasks.AsyncInstantiateOperationExtensions+AsyncInstantiateOperationConfiguredSource>)+4]");
				return 0;
			}

			internal unsafe void _003CCreate_003Eb__14_0(object state)
			{
				//IL_004a: Unknown result type (might be due to invalid IL or missing references)
				//IL_004f: Expected O, but got Unknown
				//IL_0064: Expected O, but got I
				if (state != null)
				{
					bool flag = (object)state.GetType() != typeof(AsyncInstantiateOperationConfiguredSource);
					object obj = null;
					if (!flag)
					{
						obj = state;
					}
					if (obj != null)
					{
						UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(obj + 80);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v4 (System.Object)+28]");
						bool flag2 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->TrySetCanceled((CancellationToken)0);
						return;
					}
				}
				else
				{
					NullReferenceException ex = new NullReferenceException();
				}
				throw new InvalidCastException();
			}
		}

		private static TaskPool<AsyncInstantiateOperationConfiguredSource> pool;

		private AsyncInstantiateOperationConfiguredSource nextNode;

		private AsyncInstantiateOperation asyncOperation;

		private IProgress<float> progress;

		private CancellationToken cancellationToken;

		private CancellationTokenRegistration cancellationTokenRegistration;

		private bool cancelImmediately;

		private bool completed;

		private UniTaskCompletionSourceCore<UnityEngine.Object[]> core;

		private Action<AsyncOperation> continuationAction;

		public unsafe ref AsyncInstantiateOperationConfiguredSource NextNode
		{
			get
			{
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_000b: Expected Ref, but got Unknown
				return ref *(AsyncInstantiateOperationConfiguredSource*)(this + 16);
			}
		}

		static AsyncInstantiateOperationConfiguredSource()
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type type2 = default(Type);
			Type type = type2;
			Func<int> getSize = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003B10");
			TaskPool.RegisterSizeGetter(type, getSize);
		}

		private AsyncInstantiateOperationConfiguredSource()
		{
			Action<AsyncOperation> action = Continuation;
			continuationAction = action;
		}

		public unsafe static IUniTaskSource<UnityEngine.Object[]> Create(AsyncInstantiateOperation asyncOperation, PlayerLoopTiming timing, IProgress<float> progress, CancellationToken cancellationToken, bool cancelImmediately, out short token)
		{
			//IL_0070: Expected I, but got O
			if ((object)cancellationToken != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ r9 (System.Threading.CancellationToken)+20]");
				ref short token2 = default(ref short);
				if ((nint)0 >= (nint)2)
				{
					return (IUniTaskSource<UnityEngine.Object[]>)AutoResetUniTaskCompletionSource<object>.CreateFromCanceled(cancellationToken, out token2);
				}
			}
			nint num = (nint)typeof(AsyncInstantiateOperationConfiguredSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rcx_v4 (Il2CppClass<Cysharp.Threading.Tasks.AsyncInstantiateOperationExtensions+AsyncInstantiateOperationConfiguredSource>)+B8]");
			AsyncInstantiateOperationConfiguredSource asyncInstantiateOperationConfiguredSource = default(AsyncInstantiateOperationConfiguredSource);
			AsyncInstantiateOperationConfiguredSource asyncInstantiateOperationConfiguredSource2;
			if (!((TaskPool<AsyncInstantiateOperationConfiguredSource>*)null)->TryPop(out var result))
			{
				asyncInstantiateOperationConfiguredSource = new AsyncInstantiateOperationConfiguredSource();
				Action<AsyncOperation> action = asyncInstantiateOperationConfiguredSource.Continuation;
				asyncInstantiateOperationConfiguredSource.continuationAction = action;
				asyncInstantiateOperationConfiguredSource2 = asyncInstantiateOperationConfiguredSource;
			}
			else
			{
				asyncInstantiateOperationConfiguredSource2 = result;
			}
			if (asyncInstantiateOperationConfiguredSource2 != null)
			{
				asyncInstantiateOperationConfiguredSource2.asyncOperation = asyncOperation;
				if (asyncInstantiateOperationConfiguredSource != null)
				{
					asyncInstantiateOperationConfiguredSource.progress = progress;
					if (asyncInstantiateOperationConfiguredSource != null)
					{
						asyncInstantiateOperationConfiguredSource.cancellationToken = cancellationToken;
						if (asyncInstantiateOperationConfiguredSource != null)
						{
							bool flag = default(bool);
							asyncInstantiateOperationConfiguredSource.cancelImmediately = flag;
							if (asyncInstantiateOperationConfiguredSource != null)
							{
								asyncInstantiateOperationConfiguredSource.completed = false;
								if (asyncInstantiateOperationConfiguredSource != null && asyncOperation != null)
								{
									asyncOperation.completed += asyncInstantiateOperationConfiguredSource.continuationAction;
									if (flag && (object)cancellationToken != null)
									{
										Action<object> callback = _003C_003Ec._003C_003E9__14_0;
										if (_003C_003Ec._003C_003E9__14_0 == null)
										{
											callback = (_003C_003Ec._003C_003E9__14_0 = delegate(object state)
											{
												//IL_004a: Unknown result type (might be due to invalid IL or missing references)
												//IL_004f: Expected O, but got Unknown
												//IL_0064: Expected O, but got I
												if (state != null)
												{
													bool flag2 = (object)state.GetType() != typeof(AsyncInstantiateOperationConfiguredSource);
													object obj = null;
													if (!flag2)
													{
														obj = state;
													}
													if (obj != null)
													{
														UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(obj + 80);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v4 (System.Object)+28]");
														bool flag3 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->TrySetCanceled((CancellationToken)0);
														return;
													}
												}
												else
												{
													NullReferenceException ex = new NullReferenceException();
												}
												throw new InvalidCastException();
											});
										}
										CancellationTokenRegistration cancellationTokenRegistration = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext(cancellationToken, callback, asyncInstantiateOperationConfiguredSource);
										if (asyncInstantiateOperationConfiguredSource == null)
										{
											goto IL_0292;
										}
										asyncInstantiateOperationConfiguredSource.cancellationTokenRegistration = (CancellationTokenRegistration)cancellationTokenRegistration.m_callbackInfo;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v25 (System.Threading.CancellationTokenRegistration)+10]");
										_ = 0;
									}
									PlayerLoopHelper.AddAction(timing, asyncInstantiateOperationConfiguredSource);
									if (asyncInstantiateOperationConfiguredSource != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rax_v56 (Cysharp.Threading.Tasks.AsyncInstantiateOperationExtensions+AsyncInstantiateOperationConfiguredSource)+60]");
										ref short token2 = ref *(short*)null;
										return asyncInstantiateOperationConfiguredSource;
									}
								}
							}
						}
					}
				}
			}
			goto IL_0292;
			IL_0292:
			return (IUniTaskSource<UnityEngine.Object[]>)new NullReferenceException();
		}

		public unsafe UnityEngine.Object[] GetResult(short token)
		{
			//IL_014d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Expected O, but got Unknown
			//IL_017d: Expected O, but got I4
			object obj = default(object);
			UniTaskCompletionSourceCore<UnityEngine.Object[]> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<UnityEngine.Object[]>)(obj + 80);
			UnityEngine.Object[] result = ((UniTaskCompletionSourceCore<UnityEngine.Object[]>*)uniTaskCompletionSourceCore)->GetResult(token);
			UniTaskCompletionSourceCore<UnityEngine.Object[]> uniTaskCompletionSourceCore2 = default(UniTaskCompletionSourceCore<UnityEngine.Object[]>);
			UnityEngine.Object[] result2 = uniTaskCompletionSourceCore2.GetResult(token);
			object obj2 = 0;
			return result;
		}

		void IUniTaskSource.GetResult(short token)
		{
			UnityEngine.Object[] result = GetResult(token);
		}

		public unsafe UniTaskStatus GetStatus(short token)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 80);
			return ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->GetStatus(token);
		}

		public unsafe UniTaskStatus UnsafeGetStatus()
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 80);
			return ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->UnsafeGetStatus();
		}

		public unsafe void OnCompleted(Action<object> continuation, object state, short token)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 80);
			((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->OnCompleted(continuation, state, token);
		}

		public unsafe bool MoveNext()
		{
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Expected O, but got Unknown
			//IL_0187: Expected O, but got I4
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Expected O, but got Unknown
			if (!completed && asyncOperation != null)
			{
				if ((object)this.cancellationToken != null)
				{
					CancellationToken cancellationToken = this.cancellationToken;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v22 (System.Threading.CancellationToken)+20]");
					if ((nint)0 >= (nint)2)
					{
						UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 80);
						bool flag = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->TrySetCanceled(this.cancellationToken);
						goto IL_009a;
					}
				}
				if (progress != null)
				{
					float num = asyncOperation.progress;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180496590");
				}
				object obj = asyncOperation;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rcx_v11 (System.Object)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rcx_v11 (System.Object)+10]");
				object obj2 = AsyncOperation.get_isDone_Injected((IntPtr)0);
				if (obj2 == null)
				{
					return true;
				}
				AsyncInstantiateOperation asyncInstantiateOperation = asyncOperation;
				UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<object>)(this + 80);
				bool flag3 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore2)->TrySetResult(asyncInstantiateOperation.m_Result);
				return false;
			}
			goto IL_009a;
			IL_009a:
			return false;
		}

		private unsafe bool TryReturn()
		{
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Expected O, but got Unknown
			//IL_006d: Expected I4, but got O
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_0038: Expected O, but got I4
			//IL_005a: Expected I, but got O
			UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 80);
			((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->Reset();
			if (asyncOperation != null)
			{
				asyncOperation.completed -= continuationAction;
				asyncOperation = null;
				progress = null;
				CancellationTokenRegistration cancellationTokenRegistration = (CancellationTokenRegistration)(this + 48);
				cancellationToken = (CancellationToken)0;
				((CancellationTokenRegistration*)cancellationTokenRegistration)->Dispose();
				cancelImmediately = false;
				nint num = (nint)typeof(AsyncInstantiateOperationConfiguredSource);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rcx_v8 (Il2CppClass<Cysharp.Threading.Tasks.AsyncInstantiateOperationExtensions+AsyncInstantiateOperationConfiguredSource>)+B8]");
				return ((TaskPool<object>*)null)->TryPush(this);
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		private unsafe void Continuation(AsyncOperation _)
		{
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Expected O, but got Unknown
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Expected O, but got Unknown
			if (completed)
			{
				return;
			}
			completed = true;
			if ((object)this.cancellationToken != null)
			{
				CancellationToken cancellationToken = this.cancellationToken;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v6 (System.Threading.CancellationToken)+20]");
				if ((nint)0 >= (nint)2)
				{
					UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 80);
					bool flag = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->TrySetCanceled(this.cancellationToken);
					return;
				}
			}
			AsyncInstantiateOperation asyncInstantiateOperation = asyncOperation;
			UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<object>)(this + 80);
			bool flag2 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore2)->TrySetResult(asyncInstantiateOperation.m_Result);
		}
	}

	private sealed class AsyncInstantiateOperationConfiguredSource<T> : IUniTaskSource<T[]>, IUniTaskSource, IValueTaskSource, IValueTaskSource<T[]>, IPlayerLoopItem, ITaskPoolNode<AsyncInstantiateOperationConfiguredSource<T>> where T : UnityEngine.Object
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9;

			public static Action<object> _003C_003E9__14_0;

			static _003C_003Ec()
			{
				//IL_0035: Expected O, but got I
				//IL_004a: Expected O, but got I
				nint num = 0;
				object obj = null;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v10 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncInstantiateOperationExtensions+AsyncInstantiateOperationConfiguredSource`1+<>c>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v12+B8]");
				object obj3 = 0;
				obj3 = obj;
			}

			internal int _003C_002Ecctor_003Eb__4_0()
			{
				//IL_0020: Expected O, but got I
				//IL_0036: Expected O, but got I
				//IL_008a: Expected O, but got I
				//IL_0063: Expected O, but got I
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncInstantiateOperationExtensions+AsyncInstantiateOperationConfiguredSource`1+<>c>)+28]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v5+135]");
				object obj2 = (nint)0 & (nint)1;
				if (obj2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v5+B8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v9+4]");
					return 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0570");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v6+B8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v7+4]");
				return 0;
			}

			internal unsafe void _003CCreate_003Eb__14_0(object state)
			{
				//IL_006a: Unknown result type (might be due to invalid IL or missing references)
				//IL_006f: Expected O, but got Unknown
				//IL_0085: Expected O, but got I
				nint num = 0;
				if (state != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rcx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncInstantiateOperationExtensions+AsyncInstantiateOperationConfiguredSource`1+<>c>)+18]");
					bool flag = state != null;
					object obj = null;
					if (!flag)
					{
						obj = state;
					}
					if (obj != null)
					{
						UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(obj + 80);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rdx_v4 (System.Object)+28]");
						bool flag2 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->TrySetCanceled((CancellationToken)0);
						return;
					}
				}
				else
				{
					NullReferenceException ex = new NullReferenceException();
				}
				throw new InvalidCastException();
			}
		}

		private static TaskPool<AsyncInstantiateOperationConfiguredSource<T>> pool;

		private AsyncInstantiateOperationConfiguredSource<T> nextNode;

		private AsyncInstantiateOperation<T> asyncOperation;

		private IProgress<float> progress;

		private CancellationToken cancellationToken;

		private CancellationTokenRegistration cancellationTokenRegistration;

		private bool cancelImmediately;

		private bool completed;

		private UniTaskCompletionSourceCore<T[]> core;

		private Action<AsyncOperation> continuationAction;

		public unsafe ref AsyncInstantiateOperationConfiguredSource<T> NextNode
		{
			get
			{
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_000b: Expected Ref, but got Unknown
				return ref *(AsyncInstantiateOperationConfiguredSource<T>*)(this + 16);
			}
		}

		static AsyncInstantiateOperationConfiguredSource()
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_0078: Expected O, but got I
			//IL_008d: Expected O, but got I
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rbx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncInstantiateOperationExtensions+AsyncInstantiateOperationConfiguredSource`1>)+10]");
			Type type;
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj2 = default(object);
				object obj = obj2 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				Type type2 = default(Type);
				type = type2;
			}
			else
			{
				type = null;
			}
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v14 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncInstantiateOperationExtensions+AsyncInstantiateOperationConfiguredSource`1>)+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v16+B8]");
			object obj4 = 0;
			Func<int> getSize = null;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003B10");
			TaskPool.RegisterSizeGetter(type, getSize);
		}

		private AsyncInstantiateOperationConfiguredSource()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncInstantiateOperationExtensions+AsyncInstantiateOperationConfiguredSource`1>)+30]");
			Action<AsyncOperation> action = new Action<AsyncOperation>(this, (IntPtr)0);
			nint num = 0;
		}

		public unsafe static IUniTaskSource<T[]> Create(AsyncInstantiateOperation<T> asyncOperation, PlayerLoopTiming timing, IProgress<float> progress, CancellationToken cancellationToken, bool cancelImmediately, out short token)
		{
			//IL_006c: Expected O, but got I
			//IL_0081: Expected O, but got I
			//IL_0091: Expected O, but got I
			//IL_00a6: Expected O, but got I
			//IL_00b6: Expected O, but got I
			//IL_00f5: Expected O, but got I
			//IL_010a: Expected O, but got I
			//IL_0124: Expected O, but got I
			//IL_0139: Expected O, but got I
			//IL_0149: Expected O, but got I
			//IL_0511: Expected O, but got I
			//IL_0521: Expected O, but got I
			//IL_0254: Expected O, but got I
			//IL_02b2: Expected O, but got I
			//IL_02c7: Expected O, but got I
			//IL_02d7: Expected O, but got I
			//IL_02ec: Expected O, but got I
			//IL_02fc: Expected O, but got I
			//IL_0343: Expected O, but got I
			//IL_0358: Expected O, but got I
			//IL_0368: Expected O, but got I
			//IL_037d: Expected O, but got I
			//IL_03a6: Expected O, but got I
			//IL_03bb: Expected O, but got I
			//IL_03cc: Expected O, but got I
			//IL_03e1: Expected O, but got I
			//IL_03f1: Expected O, but got I
			//IL_0406: Expected O, but got I
			if ((object)cancellationToken != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ r9 (System.Threading.CancellationToken)+20]");
				if ((nint)0 >= (nint)2)
				{
					ref short token2 = default(ref short);
					return (IUniTaskSource<T[]>)AutoResetUniTaskCompletionSource<object>.CreateFromCanceled(cancellationToken, out token2);
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ stack_38+20]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rax_v10+C0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ stack_38+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rax_v13+C0]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v14+58]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183AEA500");
			object obj6 = default(object);
			object obj9 = default(object);
			object obj16;
			if (obj6 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ stack_38+20]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ rax_v116+C0]");
				object obj8 = 0;
				obj9 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ stack_38+20]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rax_v122+C0]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v638 @ rax_v123+70]");
				object obj12 = 0;
				object obj13 = obj9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v712 @ r8_v28+30]");
				Action<AsyncOperation> action = new Action<AsyncOperation>(obj13, (IntPtr)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ r14_v6+20]");
				object obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v709 @ rcx_v76+C0]");
				object obj15 = 0;
				obj16 = obj9;
			}
			else
			{
				object obj17 = default(object);
				obj16 = obj17;
			}
			if (obj16 != null && obj9 != null && obj9 != null && obj9 != null && obj9 != null)
			{
				_ = 0;
				if (obj9 != null && asyncOperation != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ rax_v120 (System.Object)+78]");
					asyncOperation.completed += (Action<AsyncOperation>)0;
					object obj18 = default(object);
					if (obj18 != null && (object)cancellationToken != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ stack_38+20]");
						object obj19 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v979 @ rax_v43+C0]");
						object obj20 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v981 @ rax_v44+20]");
						object obj21 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v994 @ rax_v46+B8]");
						object obj22 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v996 @ rax_v47+8]");
						Action<object> callback = (Action<object>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v996 @ rax_v47+8]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ stack_38+20]");
							object obj23 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1111 @ rax_v60+C0]");
							object obj24 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1113 @ rax_v61+20]");
							object obj25 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1126 @ rax_v63+B8]");
							object obj26 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1145 @ r8_v14+80]");
							Action<object> action2 = new Action<object>(obj26, (IntPtr)0);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ stack_38+20]");
							object obj27 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1143 @ rax_v67+C0]");
							object obj28 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ stack_38+20]");
							object obj29 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1159 @ rax_v70+C0]");
							object obj30 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1161 @ rax_v71+20]");
							object obj31 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v73+B8]");
							object obj32 = 0;
							callback = action2;
						}
						CancellationTokenRegistration cancellationTokenRegistration = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext(cancellationToken, callback, obj9);
						if (obj9 == null)
						{
							goto IL_04d0;
						}
						_ = cancellationTokenRegistration.m_callbackInfo;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rax_v50 (System.Threading.CancellationTokenRegistration)+10]");
						_ = 0;
					}
					PlayerLoopHelper.AddAction(timing, (IPlayerLoopItem)obj9);
					if (obj9 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ rax_v120 (System.Object)+60]");
						ref short token2 = ref *(short*)null;
						return (IUniTaskSource<T[]>)obj9;
					}
				}
			}
			goto IL_04d0;
			IL_04d0:
			return (IUniTaskSource<T[]>)new NullReferenceException();
		}

		public T[] GetResult(short token)
		{
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Expected O, but got Unknown
			//IL_0128: Expected O, but got I
			//IL_0138: Expected O, but got I
			//IL_0155: Expected O, but got I4
			object obj2 = default(object);
			object obj = obj2 + 80;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ stack_18_v2+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdx_v1+C0]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183EF9100");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184120080");
			object obj5 = 0;
			T[] result = default(T[]);
			return result;
		}

		void IUniTaskSource.GetResult(short token)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18411FFB0");
		}

		public unsafe UniTaskStatus GetStatus(short token)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 80);
			return ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->GetStatus(token);
		}

		public unsafe UniTaskStatus UnsafeGetStatus()
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 80);
			return ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->UnsafeGetStatus();
		}

		public unsafe void OnCompleted(Action<object> continuation, object state, short token)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 80);
			((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->OnCompleted(continuation, state, token);
		}

		public unsafe bool MoveNext()
		{
			//IL_005e: Expected O, but got I
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Expected O, but got Unknown
			//IL_00a4: Expected O, but got I
			//IL_01a4: Expected O, but got I4
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Expected O, but got Unknown
			//IL_015d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.AsyncInstantiateOperationExtensions+AsyncInstantiateOperationConfiguredSource`1<T>)+49]");
			if ((nint)0 == 0 && asyncOperation != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.AsyncInstantiateOperationExtensions+AsyncInstantiateOperationConfiguredSource`1<T>)+28]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.AsyncInstantiateOperationExtensions+AsyncInstantiateOperationConfiguredSource`1<T>)+28]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rax_v23+20]");
					if ((nint)0 >= (nint)2)
					{
						UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 80);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.AsyncInstantiateOperationExtensions+AsyncInstantiateOperationConfiguredSource`1<T>)+28]");
						bool flag = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->TrySetCanceled((CancellationToken)0);
						goto IL_00ad;
					}
				}
				if (progress != null)
				{
					float num = asyncOperation.progress;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180496590");
				}
				object obj2 = asyncOperation;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rcx_v11 (System.Object)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rcx_v11 (System.Object)+10]");
				object obj3 = AsyncOperation.get_isDone_Injected((IntPtr)0);
				if (obj3 == null)
				{
					return true;
				}
				AsyncInstantiateOperation<T> asyncInstantiateOperation = asyncOperation;
				UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<object>)(this + 80);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rdx_v8 (UnityEngine.AsyncInstantiateOperation`1<T>)+20]");
				bool flag3 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore2)->TrySetResult(0);
				return false;
			}
			goto IL_00ad;
			IL_00ad:
			return false;
		}

		private unsafe bool TryReturn()
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			//IL_00c5: Expected I4, but got O
			//IL_004b: Expected O, but got I
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Expected O, but got Unknown
			//IL_0097: Expected O, but got I
			UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 80);
			((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->Reset();
			if (asyncOperation != null)
			{
				AsyncInstantiateOperation<T> asyncInstantiateOperation = asyncOperation;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.AsyncInstantiateOperationExtensions+AsyncInstantiateOperationConfiguredSource`1<T>)+78]");
				asyncInstantiateOperation.completed -= (Action<AsyncOperation>)0;
				asyncOperation = null;
				progress = null;
				CancellationTokenRegistration cancellationTokenRegistration = (CancellationTokenRegistration)(this + 48);
				_ = 0;
				((CancellationTokenRegistration*)cancellationTokenRegistration)->Dispose();
				_ = 0;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v9 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncInstantiateOperationExtensions+AsyncInstantiateOperationConfiguredSource`1>)+58]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rax_v16+B8]");
				return ((TaskPool<object>*)null)->TryPush(this);
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		private unsafe void Continuation(AsyncOperation _)
		{
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected O, but got Unknown
			//IL_00c5: Expected O, but got I
			//IL_0045: Expected O, but got I
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Expected O, but got Unknown
			//IL_008b: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.AsyncInstantiateOperationExtensions+AsyncInstantiateOperationConfiguredSource`1<T>)+49]");
			if ((nint)0 != 0)
			{
				return;
			}
			int num = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.AsyncInstantiateOperationExtensions+AsyncInstantiateOperationConfiguredSource`1<T>)+28]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.AsyncInstantiateOperationExtensions+AsyncInstantiateOperationConfiguredSource`1<T>)+28]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v8+20]");
				if ((nint)0 >= (nint)2)
				{
					UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 80);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.AsyncInstantiateOperationExtensions+AsyncInstantiateOperationConfiguredSource`1<T>)+28]");
					bool flag = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->TrySetCanceled((CancellationToken)0);
					return;
				}
			}
			AsyncInstantiateOperation<T> asyncInstantiateOperation = asyncOperation;
			UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<object>)(this + 80);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdx_v2 (UnityEngine.AsyncInstantiateOperation`1<T>)+20]");
			bool flag2 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore2)->TrySetResult(0);
		}
	}

	public unsafe static UniTask<UnityEngine.Object[]> WithCancellation<T>(AsyncInstantiateOperation asyncOperation, CancellationToken cancellationToken)
	{
		//IL_001b: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		//IL_0039: Expected I, but got O
		object obj = default(object);
		bool cancelImmediately = default(bool);
		UniTask<UnityEngine.Object[]> uniTask = ToUniTask((AsyncInstantiateOperation)(&obj), (IProgress<float>)cancellationToken, PlayerLoopTiming.Initialization, (CancellationToken)8, cancelImmediately);
		AsyncInstantiateOperation asyncInstantiateOperation = (AsyncInstantiateOperation)uniTask;
		((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)uniTask.source;
		return (UniTask<UnityEngine.Object[]>)asyncOperation;
	}

	public unsafe static UniTask<UnityEngine.Object[]> WithCancellation<T>(AsyncInstantiateOperation asyncOperation, CancellationToken cancellationToken, bool cancelImmediately)
	{
		//IL_001b: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		//IL_0039: Expected I, but got O
		object obj = default(object);
		bool cancelImmediately2 = default(bool);
		UniTask<UnityEngine.Object[]> uniTask = ToUniTask((AsyncInstantiateOperation)(&obj), (IProgress<float>)cancellationToken, PlayerLoopTiming.Initialization, (CancellationToken)8, cancelImmediately2);
		AsyncInstantiateOperation asyncInstantiateOperation = (AsyncInstantiateOperation)uniTask;
		((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)uniTask.source;
		return (UniTask<UnityEngine.Object[]>)asyncOperation;
	}

	public unsafe static UniTask<UnityEngine.Object[]> ToUniTask(AsyncInstantiateOperation asyncOperation, IProgress<float> progress = null, PlayerLoopTiming timing = PlayerLoopTiming.Update, CancellationToken cancellationToken = default(CancellationToken), bool cancelImmediately = false)
	{
		//IL_019f: Expected O, but got I4
		//IL_005a: Expected O, but got Ref
		//IL_0141: Expected O, but got I
		//IL_014a: Expected O, but got I4
		//IL_00c0: Expected O, but got I4
		//IL_00c0: Expected I4, but got O
		//IL_00cd: Expected O, but got I4
		//IL_015d->IL0185: Incompatible stack heights: 1 vs 0
		//IL_00ea->IL0185: Incompatible stack heights: 1 vs 0
		while (progress == null)
		{
			Error.ThrowArgumentNullExceptionCore("asyncOperation");
		}
		CancellationToken cancellationToken2 = default(CancellationToken);
		UniTask<object> uniTask2 = default(UniTask<object>);
		if ((object)cancellationToken2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ stack_28 (System.Threading.CancellationToken)+20]");
			if ((nint)0 >= (nint)2)
			{
				UniTask<object> uniTask = UniTask.FromCanceled<object>((CancellationToken)(&uniTask2));
				AsyncInstantiateOperation asyncInstantiateOperation = (AsyncInstantiateOperation)uniTask2;
				IntPtr ptr = default(IntPtr);
				((AsyncOperation)asyncOperation).m_Ptr = ptr;
				goto IL_0185;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [progress @ rdx (System.IProgress`1<System.Single>)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [progress @ rdx (System.IProgress`1<System.Single>)+10]");
		object obj = AsyncOperation.get_isDone_Injected((IntPtr)0);
		if (obj == null)
		{
			bool cancelImmediately2 = default(bool);
			ref short token = default(ref short);
			IUniTaskSource<UnityEngine.Object[]> uniTaskSource = AsyncInstantiateOperationConfiguredSource.Create((AsyncInstantiateOperation)progress, (PlayerLoopTiming)cancellationToken, (IProgress<float>)timing, cancellationToken2, cancelImmediately2, out token);
			AsyncInstantiateOperation asyncInstantiateOperation = (AsyncInstantiateOperation)0;
			((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4500");
		}
		else
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v13 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [progress @ rdx (System.IProgress`1<System.Single>)+20]");
			uniTask2 = new UniTask<object>(0);
			AsyncInstantiateOperation asyncInstantiateOperation = (AsyncInstantiateOperation)0;
			((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)0;
		}
		goto IL_0185;
		IL_0185:
		return (UniTask<UnityEngine.Object[]>)asyncOperation;
	}

	public static UniTask<T[]> WithCancellation<T>(AsyncInstantiateOperation<T> asyncOperation, CancellationToken cancellationToken) where T : UnityEngine.Object
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ r9+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182EF95D0");
		object obj = default(object);
		AsyncInstantiateOperation<T> asyncInstantiateOperation = (AsyncInstantiateOperation<T>)obj;
		return (UniTask<T[]>)asyncOperation;
	}

	public static UniTask<T[]> WithCancellation<T>(AsyncInstantiateOperation<T> asyncOperation, CancellationToken cancellationToken, bool cancelImmediately) where T : UnityEngine.Object
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_28+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182EF95D0");
		object obj = default(object);
		AsyncInstantiateOperation<T> asyncInstantiateOperation = (AsyncInstantiateOperation<T>)obj;
		return (UniTask<T[]>)asyncOperation;
	}

	public unsafe static UniTask<T[]> ToUniTask<T>(AsyncInstantiateOperation<T> asyncOperation, IProgress<float> progress = null, PlayerLoopTiming timing = PlayerLoopTiming.Update, CancellationToken cancellationToken = default(CancellationToken), bool cancelImmediately = false) where T : UnityEngine.Object
	{
		//IL_01f4: Expected O, but got I4
		//IL_015f: Expected O, but got I
		//IL_016f: Expected O, but got I
		//IL_00d1: Expected O, but got Ref
		//IL_01bb: Expected O, but got I
		//IL_01c4: Expected O, but got I4
		//IL_01cf->IL01da: Incompatible stack heights: 1 vs 0
		//IL_014a->IL01da: Incompatible stack heights: 1 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ stack_38+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ stack_38+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		if (progress != null)
		{
			object obj = default(object);
			UniTask<object> uniTask2 = default(UniTask<object>);
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ stack_28+20]");
				if ((nint)0 >= (nint)2)
				{
					UniTask<object> uniTask = UniTask.FromCanceled<object>((CancellationToken)(&uniTask2));
					AsyncInstantiateOperation<T> asyncInstantiateOperation = (AsyncInstantiateOperation<T>)uniTask2;
					goto IL_01da;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [progress @ rdx (System.IProgress`1<System.Single>)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [progress @ rdx (System.IProgress`1<System.Single>)+10]");
			object obj2 = AsyncOperation.get_isDone_Injected((IntPtr)0);
			if (obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18411F840");
				_ = 0;
				_ = 0;
				object obj3 = default(object);
				AsyncInstantiateOperation<T> asyncInstantiateOperation = (AsyncInstantiateOperation<T>)obj3;
				_ = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ stack_38+38]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rax_v17+30]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ rcx_v14+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [progress @ rdx (System.IProgress`1<System.Single>)+20]");
				uniTask2 = new UniTask<object>(0);
				AsyncInstantiateOperation<T> asyncInstantiateOperation = (AsyncInstantiateOperation<T>)0;
				_ = 0;
			}
		}
		else
		{
			Error.ThrowArgumentNullExceptionCore("asyncOperation");
		}
		goto IL_01da;
		IL_01da:
		return (UniTask<T[]>)asyncOperation;
	}
}
