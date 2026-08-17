using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks.Sources;
using Cpp2ILInjected;
using Cysharp.Threading.Tasks.CompilerServices;
using Cysharp.Threading.Tasks.Internal;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Cysharp.Threading.Tasks;

public static class UnityAsyncExtensions
{
	public struct AssetBundleRequestAllAssetsAwaiter(AssetBundleRequest asyncOperation) : ICriticalNotifyCompletion, INotifyCompletion
	{
		private AssetBundleRequest asyncOperation = asyncOperation;

		private Action<AsyncOperation> continuationAction = null;

		public bool IsCompleted
		{
			get
			{
				AssetBundleRequest assetBundleRequest = asyncOperation;
				bool flag = ((AsyncOperation)assetBundleRequest).m_Ptr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 25 ConditionalJump @-1, v22 @ ZF_v4 (System.Boolean) --- -1 Nop");
				/*Error: End of method reached without returning.*/;
			}
		}

		public unsafe AssetBundleRequestAllAssetsAwaiter GetAwaiter()
		{
			//IL_000a: Expected native int or pointer, but got O
			AssetBundleRequestAllAssetsAwaiter assetBundleRequestAllAssetsAwaiter = default(AssetBundleRequestAllAssetsAwaiter);
			System.Runtime.CompilerServices.Unsafe.Write(&((AssetBundleRequestAllAssetsAwaiter*)(nint)assetBundleRequestAllAssetsAwaiter)->asyncOperation, asyncOperation);
			return assetBundleRequestAllAssetsAwaiter;
		}

		public UnityEngine.Object[] GetResult()
		{
			AsyncOperation asyncOperation = this.asyncOperation;
			if (continuationAction == null)
			{
				bool flag = asyncOperation.m_Ptr == (IntPtr)0;
				UnityEngine.Object[] result = AssetBundleRequest.get_allAssets_Injected(asyncOperation.m_Ptr);
				this.asyncOperation = null;
				return result;
			}
			this.asyncOperation.completed -= continuationAction;
			continuationAction = null;
			object obj = this.asyncOperation;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rcx_v12 (System.Object)+10]");
			bool flag2 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rcx_v12 (System.Object)+10]");
			UnityEngine.Object[] result2 = AssetBundleRequest.get_allAssets_Injected((IntPtr)0);
			this.asyncOperation = null;
			return result2;
		}

		public void OnCompleted(Action continuation)
		{
			UnsafeOnCompleted(continuation);
		}

		public void UnsafeOnCompleted(Action continuation)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999327C]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (continuationAction == null)
			{
				Action<AsyncOperation> action = PooledDelegate<AsyncOperation>.Create(continuation);
				continuationAction = action;
				asyncOperation.completed += continuationAction;
				return;
			}
			Error.ThrowInvalidOperationExceptionCore("continuation is already registered.");
			throw new NullReferenceException();
		}
	}

	private sealed class AssetBundleRequestAllAssetsConfiguredSource : IUniTaskSource<UnityEngine.Object[]>, IUniTaskSource, IValueTaskSource, IValueTaskSource<UnityEngine.Object[]>, IPlayerLoopItem, ITaskPoolNode<AssetBundleRequestAllAssetsConfiguredSource>
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
				nint num = (nint)typeof(AssetBundleRequestAllAssetsConfiguredSource);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v3 (Il2CppClass<Cysharp.Threading.Tasks.UnityAsyncExtensions+AssetBundleRequestAllAssetsConfiguredSource>)+B8]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v4 (Il2CppStaticFields<Cysharp.Threading.Tasks.UnityAsyncExtensions+AssetBundleRequestAllAssetsConfiguredSource>)+4]");
				return 0;
			}

			internal unsafe void _003CCreate_003Eb__14_0(object state)
			{
				//IL_004a: Unknown result type (might be due to invalid IL or missing references)
				//IL_004f: Expected O, but got Unknown
				//IL_0064: Expected O, but got I
				if (state != null)
				{
					bool flag = (object)state.GetType() != typeof(AssetBundleRequestAllAssetsConfiguredSource);
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

		private static TaskPool<AssetBundleRequestAllAssetsConfiguredSource> pool;

		private AssetBundleRequestAllAssetsConfiguredSource nextNode;

		private AssetBundleRequest asyncOperation;

		private IProgress<float> progress;

		private CancellationToken cancellationToken;

		private CancellationTokenRegistration cancellationTokenRegistration;

		private bool cancelImmediately;

		private bool completed;

		private UniTaskCompletionSourceCore<UnityEngine.Object[]> core;

		private Action<AsyncOperation> continuationAction;

		public unsafe ref AssetBundleRequestAllAssetsConfiguredSource NextNode
		{
			get
			{
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_000b: Expected Ref, but got Unknown
				return ref *(AssetBundleRequestAllAssetsConfiguredSource*)(this + 16);
			}
		}

		static AssetBundleRequestAllAssetsConfiguredSource()
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

		private AssetBundleRequestAllAssetsConfiguredSource()
		{
			Action<AsyncOperation> action = Continuation;
			continuationAction = action;
		}

		public unsafe static IUniTaskSource<UnityEngine.Object[]> Create(AssetBundleRequest asyncOperation, PlayerLoopTiming timing, IProgress<float> progress, CancellationToken cancellationToken, bool cancelImmediately, out short token)
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
			nint num = (nint)typeof(AssetBundleRequestAllAssetsConfiguredSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rcx_v4 (Il2CppClass<Cysharp.Threading.Tasks.UnityAsyncExtensions+AssetBundleRequestAllAssetsConfiguredSource>)+B8]");
			AssetBundleRequestAllAssetsConfiguredSource assetBundleRequestAllAssetsConfiguredSource = default(AssetBundleRequestAllAssetsConfiguredSource);
			AssetBundleRequestAllAssetsConfiguredSource assetBundleRequestAllAssetsConfiguredSource2;
			if (!((TaskPool<AssetBundleRequestAllAssetsConfiguredSource>*)null)->TryPop(out var result))
			{
				assetBundleRequestAllAssetsConfiguredSource = new AssetBundleRequestAllAssetsConfiguredSource();
				Action<AsyncOperation> action = assetBundleRequestAllAssetsConfiguredSource.Continuation;
				assetBundleRequestAllAssetsConfiguredSource.continuationAction = action;
				assetBundleRequestAllAssetsConfiguredSource2 = assetBundleRequestAllAssetsConfiguredSource;
			}
			else
			{
				assetBundleRequestAllAssetsConfiguredSource2 = result;
			}
			if (assetBundleRequestAllAssetsConfiguredSource2 != null)
			{
				assetBundleRequestAllAssetsConfiguredSource2.asyncOperation = asyncOperation;
				if (assetBundleRequestAllAssetsConfiguredSource != null)
				{
					assetBundleRequestAllAssetsConfiguredSource.progress = progress;
					if (assetBundleRequestAllAssetsConfiguredSource != null)
					{
						assetBundleRequestAllAssetsConfiguredSource.cancellationToken = cancellationToken;
						if (assetBundleRequestAllAssetsConfiguredSource != null)
						{
							bool flag = default(bool);
							assetBundleRequestAllAssetsConfiguredSource.cancelImmediately = flag;
							if (assetBundleRequestAllAssetsConfiguredSource != null)
							{
								assetBundleRequestAllAssetsConfiguredSource.completed = false;
								if (assetBundleRequestAllAssetsConfiguredSource != null && asyncOperation != null)
								{
									asyncOperation.completed += assetBundleRequestAllAssetsConfiguredSource.continuationAction;
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
													bool flag2 = (object)state.GetType() != typeof(AssetBundleRequestAllAssetsConfiguredSource);
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
										CancellationTokenRegistration cancellationTokenRegistration = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext(cancellationToken, callback, assetBundleRequestAllAssetsConfiguredSource);
										if (assetBundleRequestAllAssetsConfiguredSource == null)
										{
											goto IL_0292;
										}
										assetBundleRequestAllAssetsConfiguredSource.cancellationTokenRegistration = (CancellationTokenRegistration)cancellationTokenRegistration.m_callbackInfo;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v25 (System.Threading.CancellationTokenRegistration)+10]");
										_ = 0;
									}
									PlayerLoopHelper.AddAction(timing, assetBundleRequestAllAssetsConfiguredSource);
									if (assetBundleRequestAllAssetsConfiguredSource != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rax_v56 (Cysharp.Threading.Tasks.UnityAsyncExtensions+AssetBundleRequestAllAssetsConfiguredSource)+60]");
										ref short token2 = ref *(short*)null;
										return assetBundleRequestAllAssetsConfiguredSource;
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
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Expected O, but got Unknown
			//IL_013f: Expected O, but got I4
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v23 (System.Threading.CancellationToken)+20]");
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
				UnityEngine.Object[] allAssets = asyncOperation.allAssets;
				UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<object>)(this + 80);
				bool flag3 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore2)->TrySetResult(allAssets);
				return false;
			}
			goto IL_009a;
			IL_009a:
			return false;
		}

		private unsafe bool TryReturn()
		{
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Expected O, but got Unknown
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			//IL_001b: Expected O, but got I4
			//IL_003d: Expected I, but got O
			UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 80);
			((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->Reset();
			asyncOperation = null;
			progress = null;
			CancellationTokenRegistration cancellationTokenRegistration = (CancellationTokenRegistration)(this + 48);
			cancellationToken = (CancellationToken)0;
			((CancellationTokenRegistration*)cancellationTokenRegistration)->Dispose();
			cancelImmediately = false;
			nint num = (nint)typeof(AssetBundleRequestAllAssetsConfiguredSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rcx_v7 (Il2CppClass<Cysharp.Threading.Tasks.UnityAsyncExtensions+AssetBundleRequestAllAssetsConfiguredSource>)+B8]");
			return ((TaskPool<object>*)null)->TryPush(this);
		}

		private unsafe void Continuation(AsyncOperation _)
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			if (completed)
			{
				return;
			}
			completed = true;
			bool flag = (object)this.cancellationToken == null;
			UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 80);
			if (!flag)
			{
				CancellationToken cancellationToken = this.cancellationToken;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v16 (System.Threading.CancellationToken)+20]");
				if ((nint)0 >= (nint)2)
				{
					bool flag2 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->TrySetCanceled(this.cancellationToken);
					return;
				}
			}
			object obj = asyncOperation;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rcx_v5 (System.Object)+10]");
			bool flag3 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rcx_v5 (System.Object)+10]");
			object result = AssetBundleRequest.get_allAssets_Injected((IntPtr)0);
			bool flag4 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->TrySetResult(result);
		}
	}

	private sealed class AsyncGPUReadbackRequestAwaiterConfiguredSource : IUniTaskSource<AsyncGPUReadbackRequest>, IUniTaskSource, IValueTaskSource, IValueTaskSource<AsyncGPUReadbackRequest>, IPlayerLoopItem, ITaskPoolNode<AsyncGPUReadbackRequestAwaiterConfiguredSource>
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9;

			public static Action<object> _003C_003E9__11_0;

			static _003C_003Ec()
			{
				_003C_003Ec obj = new _003C_003Ec();
				_003C_003E9 = obj;
			}

			internal int _003C_002Ecctor_003Eb__4_0()
			{
				//IL_0013: Expected I, but got O
				nint num = (nint)typeof(AsyncGPUReadbackRequestAwaiterConfiguredSource);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v3 (Il2CppClass<Cysharp.Threading.Tasks.UnityAsyncExtensions+AsyncGPUReadbackRequestAwaiterConfiguredSource>)+B8]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v4 (Il2CppStaticFields<Cysharp.Threading.Tasks.UnityAsyncExtensions+AsyncGPUReadbackRequestAwaiterConfiguredSource>)+4]");
				return 0;
			}

			internal unsafe void _003CCreate_003Eb__11_0(object state)
			{
				//IL_004a: Unknown result type (might be due to invalid IL or missing references)
				//IL_004f: Expected O, but got Unknown
				//IL_0064: Expected O, but got I
				if (state != null)
				{
					bool flag = (object)state.GetType() != typeof(AsyncGPUReadbackRequestAwaiterConfiguredSource);
					object obj = null;
					if (!flag)
					{
						obj = state;
					}
					if (obj != null)
					{
						UniTaskCompletionSourceCore<AsyncGPUReadbackRequest> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>)(obj + 80);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v4 (System.Object)+28]");
						bool flag2 = ((UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>*)uniTaskCompletionSourceCore)->TrySetCanceled((CancellationToken)0);
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

		private static TaskPool<AsyncGPUReadbackRequestAwaiterConfiguredSource> pool;

		private AsyncGPUReadbackRequestAwaiterConfiguredSource nextNode;

		private AsyncGPUReadbackRequest asyncOperation;

		private CancellationToken cancellationToken;

		private CancellationTokenRegistration cancellationTokenRegistration;

		private bool cancelImmediately;

		private UniTaskCompletionSourceCore<AsyncGPUReadbackRequest> core;

		public unsafe ref AsyncGPUReadbackRequestAwaiterConfiguredSource NextNode
		{
			get
			{
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_000b: Expected Ref, but got Unknown
				return ref *(AsyncGPUReadbackRequestAwaiterConfiguredSource*)(this + 16);
			}
		}

		static AsyncGPUReadbackRequestAwaiterConfiguredSource()
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

		private AsyncGPUReadbackRequestAwaiterConfiguredSource()
		{
		}

		public unsafe static IUniTaskSource<AsyncGPUReadbackRequest> Create(AsyncGPUReadbackRequest asyncOperation, PlayerLoopTiming timing, CancellationToken cancellationToken, bool cancelImmediately, out short token)
		{
			//IL_0106: Expected I, but got O
			//IL_0138: Expected O, but got I
			//IL_00f3: Expected O, but got I
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Expected O, but got Unknown
			//IL_0270: Expected O, but got I
			if ((object)cancellationToken != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ r8 (System.Threading.CancellationToken)+20]");
				if ((nint)0 >= (nint)2)
				{
					IUniTaskSource<AsyncGPUReadbackRequest> uniTaskSource = AutoResetUniTaskCompletionSource<AsyncGPUReadbackRequest>.Create();
					if (uniTaskSource != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rax_v54 (Cysharp.Threading.Tasks.IUniTaskSource`1<UnityEngine.Rendering.AsyncGPUReadbackRequest>)+48]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rax_v54 (Cysharp.Threading.Tasks.IUniTaskSource`1<UnityEngine.Rendering.AsyncGPUReadbackRequest>)+30]");
						if (num == 0)
						{
							UniTaskCompletionSourceCore<AsyncGPUReadbackRequest> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>)(uniTaskSource + 24);
							bool flag = ((UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>*)uniTaskCompletionSourceCore)->TrySetCanceled(cancellationToken);
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rax_v54 (Cysharp.Threading.Tasks.IUniTaskSource`1<UnityEngine.Rendering.AsyncGPUReadbackRequest>)+30]");
						object obj = 0;
						return uniTaskSource;
					}
					goto IL_0275;
				}
			}
			nint num2 = (nint)typeof(AsyncGPUReadbackRequestAwaiterConfiguredSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v5 (Il2CppClass<Cysharp.Threading.Tasks.UnityAsyncExtensions+AsyncGPUReadbackRequestAwaiterConfiguredSource>)+B8]");
			AsyncGPUReadbackRequestAwaiterConfiguredSource asyncGPUReadbackRequestAwaiterConfiguredSource = (((TaskPool<AsyncGPUReadbackRequestAwaiterConfiguredSource>*)null)->TryPop(out var result) ? result : new AsyncGPUReadbackRequestAwaiterConfiguredSource());
			if (asyncGPUReadbackRequestAwaiterConfiguredSource != null)
			{
				asyncGPUReadbackRequestAwaiterConfiguredSource.asyncOperation = (AsyncGPUReadbackRequest)(nint)asyncOperation.m_Ptr;
				if (asyncGPUReadbackRequestAwaiterConfiguredSource != null)
				{
					asyncGPUReadbackRequestAwaiterConfiguredSource.cancellationToken = cancellationToken;
					if (asyncGPUReadbackRequestAwaiterConfiguredSource != null)
					{
						asyncGPUReadbackRequestAwaiterConfiguredSource.cancelImmediately = cancelImmediately;
						if (cancelImmediately && (object)cancellationToken != null)
						{
							Action<object> callback = _003C_003Ec._003C_003E9__11_0;
							if (_003C_003Ec._003C_003E9__11_0 == null)
							{
								callback = (_003C_003Ec._003C_003E9__11_0 = delegate(object state)
								{
									//IL_004a: Unknown result type (might be due to invalid IL or missing references)
									//IL_004f: Expected O, but got Unknown
									//IL_0064: Expected O, but got I
									if (state != null)
									{
										bool flag2 = (object)state.GetType() != typeof(AsyncGPUReadbackRequestAwaiterConfiguredSource);
										object obj2 = null;
										if (!flag2)
										{
											obj2 = state;
										}
										if (obj2 != null)
										{
											UniTaskCompletionSourceCore<AsyncGPUReadbackRequest> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>)(obj2 + 80);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v4 (System.Object)+28]");
											bool flag3 = ((UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>*)uniTaskCompletionSourceCore2)->TrySetCanceled((CancellationToken)0);
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
							CancellationTokenRegistration cancellationTokenRegistration = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext(cancellationToken, callback, asyncGPUReadbackRequestAwaiterConfiguredSource);
							if (asyncGPUReadbackRequestAwaiterConfiguredSource == null)
							{
								goto IL_0275;
							}
							asyncGPUReadbackRequestAwaiterConfiguredSource.cancellationTokenRegistration = (CancellationTokenRegistration)cancellationTokenRegistration.m_callbackInfo;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ rax_v21 (System.Threading.CancellationTokenRegistration)+10]");
							_ = 0;
						}
						PlayerLoopHelper.AddAction(timing, asyncGPUReadbackRequestAwaiterConfiguredSource);
						if (asyncGPUReadbackRequestAwaiterConfiguredSource != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rax_v8 (Cysharp.Threading.Tasks.UnityAsyncExtensions+AsyncGPUReadbackRequestAwaiterConfiguredSource)+68]");
							object obj = 0;
							return asyncGPUReadbackRequestAwaiterConfiguredSource;
						}
					}
				}
			}
			goto IL_0275;
			IL_0275:
			return (IUniTaskSource<AsyncGPUReadbackRequest>)new NullReferenceException();
		}

		public unsafe AsyncGPUReadbackRequest GetResult(short token)
		{
			//IL_00db: Expected native int or pointer, but got O
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Expected O, but got Unknown
			//IL_0100: Expected native int or pointer, but got O
			//IL_011f: Expected O, but got I4
			AsyncGPUReadbackRequest asyncGPUReadbackRequest = default(AsyncGPUReadbackRequest);
			((AsyncGPUReadbackRequest*)(nint)asyncGPUReadbackRequest)->m_Ptr = (IntPtr)0;
			object obj = default(object);
			UniTaskCompletionSourceCore<AsyncGPUReadbackRequest> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>)(obj + 80);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183EF7880");
			IntPtr ptr = default(IntPtr);
			((AsyncGPUReadbackRequest*)(nint)asyncGPUReadbackRequest)->m_Ptr = ptr;
			AsyncGPUReadbackRequest result = ((UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>*)uniTaskCompletionSourceCore)->GetResult(token);
			object obj2 = 0;
			return asyncGPUReadbackRequest;
		}

		void IUniTaskSource.GetResult(short token)
		{
			AsyncGPUReadbackRequest result = GetResult(token);
		}

		public unsafe UniTaskStatus GetStatus(short token)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<AsyncGPUReadbackRequest> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>)(this + 80);
			return ((UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>*)uniTaskCompletionSourceCore)->GetStatus(token);
		}

		public unsafe UniTaskStatus UnsafeGetStatus()
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<AsyncGPUReadbackRequest> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>)(this + 80);
			return ((UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>*)uniTaskCompletionSourceCore)->UnsafeGetStatus();
		}

		public unsafe void OnCompleted(Action<object> continuation, object state, short token)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<AsyncGPUReadbackRequest> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>)(this + 80);
			((UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>*)uniTaskCompletionSourceCore)->OnCompleted(continuation, state, token);
		}

		public unsafe bool MoveNext()
		{
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Expected O, but got Unknown
			//IL_00f5: Expected O, but got I4
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Expected O, but got Unknown
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Expected O, but got Unknown
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Expected O, but got Unknown
			//IL_012d: Expected O, but got I4
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Expected O, but got Unknown
			if ((object)this.cancellationToken != null)
			{
				CancellationToken cancellationToken = this.cancellationToken;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v24 (System.Threading.CancellationToken)+20]");
				if ((nint)0 >= (nint)2)
				{
					UniTaskCompletionSourceCore<AsyncGPUReadbackRequest> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>)(this + 80);
					bool flag = ((UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>*)uniTaskCompletionSourceCore)->TrySetCanceled(this.cancellationToken);
					return false;
				}
			}
			object obj = this + 24;
			object obj2 = ((AsyncGPUReadbackRequest*)obj)->HasError();
			if (obj2 == null)
			{
				object obj3 = this + 24;
				object obj4 = ((AsyncGPUReadbackRequest*)obj3)->IsDone();
				if (obj4 == null)
				{
					return true;
				}
				object obj5 = this + 80;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807058F0");
				return false;
			}
			Exception error = new Exception("AsyncGPUReadbackRequest.hasError = true");
			UniTaskCompletionSourceCore<AsyncGPUReadbackRequest> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>)(this + 80);
			bool flag2 = ((UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>*)uniTaskCompletionSourceCore2)->TrySetException(error);
			return false;
		}

		private unsafe bool TryReturn()
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			//IL_002f: Expected O, but got I4
			//IL_003a: Expected O, but got I4
			//IL_005c: Expected I, but got O
			UniTaskCompletionSourceCore<AsyncGPUReadbackRequest> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>)(this + 80);
			((UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>*)uniTaskCompletionSourceCore)->Reset();
			CancellationTokenRegistration cancellationTokenRegistration = (CancellationTokenRegistration)(this + 48);
			asyncOperation = (AsyncGPUReadbackRequest)0;
			cancellationToken = (CancellationToken)0;
			((CancellationTokenRegistration*)cancellationTokenRegistration)->Dispose();
			cancelImmediately = false;
			nint num = (nint)typeof(AsyncGPUReadbackRequestAwaiterConfiguredSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rcx_v5 (Il2CppClass<Cysharp.Threading.Tasks.UnityAsyncExtensions+AsyncGPUReadbackRequestAwaiterConfiguredSource>)+B8]");
			return ((TaskPool<object>*)null)->TryPush(this);
		}
	}

	public struct AsyncOperationAwaiter(AsyncOperation asyncOperation) : ICriticalNotifyCompletion, INotifyCompletion
	{
		private AsyncOperation asyncOperation = asyncOperation;

		private Action<AsyncOperation> continuationAction = null;

		public bool IsCompleted
		{
			get
			{
				AsyncOperation asyncOperation = this.asyncOperation;
				bool flag = asyncOperation.m_Ptr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 25 ConditionalJump @-1, v22 @ ZF_v4 (System.Boolean) --- -1 Nop");
				/*Error: End of method reached without returning.*/;
			}
		}

		public void GetResult()
		{
			if (continuationAction == null)
			{
				asyncOperation = null;
				return;
			}
			asyncOperation.completed -= continuationAction;
			continuationAction = null;
			asyncOperation = null;
		}

		public void OnCompleted(Action continuation)
		{
			UnsafeOnCompleted(continuation);
		}

		public void UnsafeOnCompleted(Action continuation)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999327C]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (continuationAction == null)
			{
				Action<AsyncOperation> action = PooledDelegate<AsyncOperation>.Create(continuation);
				continuationAction = action;
				asyncOperation.completed += continuationAction;
				return;
			}
			Error.ThrowInvalidOperationExceptionCore("continuation is already registered.");
			throw new NullReferenceException();
		}
	}

	private sealed class AsyncOperationConfiguredSource : IUniTaskSource, IValueTaskSource, IPlayerLoopItem, ITaskPoolNode<AsyncOperationConfiguredSource>
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
				nint num = (nint)typeof(AsyncOperationConfiguredSource);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v3 (Il2CppClass<Cysharp.Threading.Tasks.UnityAsyncExtensions+AsyncOperationConfiguredSource>)+B8]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v4 (Il2CppStaticFields<Cysharp.Threading.Tasks.UnityAsyncExtensions+AsyncOperationConfiguredSource>)+4]");
				return 0;
			}

			internal unsafe void _003CCreate_003Eb__14_0(object state)
			{
				//IL_004a: Unknown result type (might be due to invalid IL or missing references)
				//IL_004f: Expected O, but got Unknown
				//IL_0064: Expected O, but got I
				if (state != null)
				{
					bool flag = (object)state.GetType() != typeof(AsyncOperationConfiguredSource);
					object obj = null;
					if (!flag)
					{
						obj = state;
					}
					if (obj != null)
					{
						UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(obj + 80);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v4 (System.Object)+28]");
						bool flag2 = ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->TrySetCanceled((CancellationToken)0);
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

		private static TaskPool<AsyncOperationConfiguredSource> pool;

		private AsyncOperationConfiguredSource nextNode;

		private AsyncOperation asyncOperation;

		private IProgress<float> progress;

		private CancellationToken cancellationToken;

		private CancellationTokenRegistration cancellationTokenRegistration;

		private bool cancelImmediately;

		private bool completed;

		private UniTaskCompletionSourceCore<AsyncUnit> core;

		private Action<AsyncOperation> continuationAction;

		public unsafe ref AsyncOperationConfiguredSource NextNode
		{
			get
			{
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_000b: Expected Ref, but got Unknown
				return ref *(AsyncOperationConfiguredSource*)(this + 16);
			}
		}

		static AsyncOperationConfiguredSource()
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

		private AsyncOperationConfiguredSource()
		{
			Action<AsyncOperation> action = Continuation;
			continuationAction = action;
		}

		public unsafe static IUniTaskSource Create(AsyncOperation asyncOperation, PlayerLoopTiming timing, IProgress<float> progress, CancellationToken cancellationToken, bool cancelImmediately, out short token)
		{
			//IL_0070: Expected I, but got O
			if ((object)cancellationToken != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ r9 (System.Threading.CancellationToken)+20]");
				ref short token2 = default(ref short);
				if ((nint)0 >= (nint)2)
				{
					return AutoResetUniTaskCompletionSource.CreateFromCanceled(cancellationToken, out token2);
				}
			}
			nint num = (nint)typeof(AsyncOperationConfiguredSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rcx_v4 (Il2CppClass<Cysharp.Threading.Tasks.UnityAsyncExtensions+AsyncOperationConfiguredSource>)+B8]");
			AsyncOperationConfiguredSource asyncOperationConfiguredSource = default(AsyncOperationConfiguredSource);
			AsyncOperationConfiguredSource asyncOperationConfiguredSource2;
			if (!((TaskPool<AsyncOperationConfiguredSource>*)null)->TryPop(out var result))
			{
				asyncOperationConfiguredSource = new AsyncOperationConfiguredSource();
				Action<AsyncOperation> action = asyncOperationConfiguredSource.Continuation;
				asyncOperationConfiguredSource.continuationAction = action;
				asyncOperationConfiguredSource2 = asyncOperationConfiguredSource;
			}
			else
			{
				asyncOperationConfiguredSource2 = result;
			}
			if (asyncOperationConfiguredSource2 != null)
			{
				asyncOperationConfiguredSource2.asyncOperation = asyncOperation;
				if (asyncOperationConfiguredSource != null)
				{
					asyncOperationConfiguredSource.progress = progress;
					if (asyncOperationConfiguredSource != null)
					{
						asyncOperationConfiguredSource.cancellationToken = cancellationToken;
						if (asyncOperationConfiguredSource != null)
						{
							bool flag = default(bool);
							asyncOperationConfiguredSource.cancelImmediately = flag;
							if (asyncOperationConfiguredSource != null)
							{
								asyncOperationConfiguredSource.completed = false;
								if (asyncOperationConfiguredSource != null && asyncOperation != null)
								{
									asyncOperation.completed += asyncOperationConfiguredSource.continuationAction;
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
													bool flag2 = (object)state.GetType() != typeof(AsyncOperationConfiguredSource);
													object obj = null;
													if (!flag2)
													{
														obj = state;
													}
													if (obj != null)
													{
														UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(obj + 80);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v4 (System.Object)+28]");
														bool flag3 = ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->TrySetCanceled((CancellationToken)0);
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
										CancellationTokenRegistration cancellationTokenRegistration = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext(cancellationToken, callback, asyncOperationConfiguredSource);
										if (asyncOperationConfiguredSource == null)
										{
											goto IL_0292;
										}
										asyncOperationConfiguredSource.cancellationTokenRegistration = (CancellationTokenRegistration)cancellationTokenRegistration.m_callbackInfo;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v25 (System.Threading.CancellationTokenRegistration)+10]");
										_ = 0;
									}
									PlayerLoopHelper.AddAction(timing, asyncOperationConfiguredSource);
									if (asyncOperationConfiguredSource != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rax_v56 (Cysharp.Threading.Tasks.UnityAsyncExtensions+AsyncOperationConfiguredSource)+60]");
										ref short token2 = ref *(short*)null;
										return asyncOperationConfiguredSource;
									}
								}
							}
						}
					}
				}
			}
			goto IL_0292;
			IL_0292:
			return (IUniTaskSource)new NullReferenceException();
		}

		public unsafe void GetResult(short token)
		{
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Expected O, but got Unknown
			//IL_016c: Expected O, but got I4
			object obj = default(object);
			UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(obj + 80);
			AsyncUnit result = ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->GetResult(token);
			UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore2 = default(UniTaskCompletionSourceCore<AsyncUnit>);
			AsyncUnit result2 = uniTaskCompletionSourceCore2.GetResult(token);
			object obj2 = 0;
		}

		public unsafe UniTaskStatus GetStatus(short token)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 80);
			return ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->GetStatus(token);
		}

		public unsafe UniTaskStatus UnsafeGetStatus()
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 80);
			return ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->UnsafeGetStatus();
		}

		public unsafe void OnCompleted(Action<object> continuation, object state, short token)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 80);
			((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->OnCompleted(continuation, state, token);
		}

		public unsafe bool MoveNext()
		{
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Expected O, but got Unknown
			//IL_0156: Expected O, but got I4
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Expected O, but got Unknown
			if (!completed && asyncOperation != null)
			{
				if ((object)this.cancellationToken != null)
				{
					CancellationToken cancellationToken = this.cancellationToken;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rax_v24 (System.Threading.CancellationToken)+20]");
					if ((nint)0 >= (nint)2)
					{
						UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 80);
						bool flag = ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->TrySetCanceled(this.cancellationToken);
						goto IL_009a;
					}
				}
				if (progress != null)
				{
					float num = asyncOperation.progress;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180496590");
				}
				object obj = asyncOperation;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rcx_v11 (System.Object)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rcx_v11 (System.Object)+10]");
				object obj2 = AsyncOperation.get_isDone_Injected((IntPtr)0);
				if (obj2 == null)
				{
					return true;
				}
				UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 80);
				bool flag3 = ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore2)->TrySetResult(AsyncUnit.Default);
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
			UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 80);
			((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->Reset();
			if (asyncOperation != null)
			{
				asyncOperation.completed -= continuationAction;
				asyncOperation = null;
				progress = null;
				CancellationTokenRegistration cancellationTokenRegistration = (CancellationTokenRegistration)(this + 48);
				cancellationToken = (CancellationToken)0;
				((CancellationTokenRegistration*)cancellationTokenRegistration)->Dispose();
				cancelImmediately = false;
				nint num = (nint)typeof(AsyncOperationConfiguredSource);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rcx_v8 (Il2CppClass<Cysharp.Threading.Tasks.UnityAsyncExtensions+AsyncOperationConfiguredSource>)+B8]");
				return ((TaskPool<object>*)null)->TryPush(this);
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		private unsafe void Continuation(AsyncOperation _)
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			if (completed)
			{
				return;
			}
			completed = true;
			bool flag = (object)this.cancellationToken == null;
			UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 80);
			if (!flag)
			{
				CancellationToken cancellationToken = this.cancellationToken;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rax_v8 (System.Threading.CancellationToken)+20]");
				if ((nint)0 >= (nint)2)
				{
					bool flag2 = ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->TrySetCanceled(this.cancellationToken);
					return;
				}
			}
			bool flag3 = ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->TrySetResult(AsyncUnit.Default);
		}
	}

	public struct ResourceRequestAwaiter(ResourceRequest asyncOperation) : ICriticalNotifyCompletion, INotifyCompletion
	{
		private ResourceRequest asyncOperation = asyncOperation;

		private Action<AsyncOperation> continuationAction = null;

		public bool IsCompleted
		{
			get
			{
				ResourceRequest resourceRequest = asyncOperation;
				bool flag = ((AsyncOperation)resourceRequest).m_Ptr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 25 ConditionalJump @-1, v22 @ ZF_v4 (System.Boolean) --- -1 Nop");
				/*Error: End of method reached without returning.*/;
			}
		}

		public UnityEngine.Object GetResult()
		{
			//IL_0053: Expected I, but got O
			AsyncOperation asyncOperation = this.asyncOperation;
			if (continuationAction == null)
			{
				if (this.asyncOperation != null)
				{
					nint num = (nint)asyncOperation;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v38 @ rdx_v9 (Il2CppClass<UnityEngine.AsyncOperation>)+178] (should have been resolved before IL gen)");
					this.asyncOperation = null;
					UnityEngine.Object result = default(UnityEngine.Object);
					return result;
				}
			}
			else if (this.asyncOperation != null)
			{
				this.asyncOperation.completed -= continuationAction;
				continuationAction = null;
				if (this.asyncOperation != null)
				{
					UnityEngine.Object result2 = this.asyncOperation.GetResult();
					this.asyncOperation = null;
					return result2;
				}
			}
			return (UnityEngine.Object)(object)new NullReferenceException();
		}

		public void OnCompleted(Action continuation)
		{
			UnsafeOnCompleted(continuation);
		}

		public void UnsafeOnCompleted(Action continuation)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999327C]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (continuationAction == null)
			{
				Action<AsyncOperation> action = PooledDelegate<AsyncOperation>.Create(continuation);
				continuationAction = action;
				asyncOperation.completed += continuationAction;
				return;
			}
			Error.ThrowInvalidOperationExceptionCore("continuation is already registered.");
			throw new NullReferenceException();
		}
	}

	private sealed class ResourceRequestConfiguredSource : IUniTaskSource<UnityEngine.Object>, IUniTaskSource, IValueTaskSource, IValueTaskSource<UnityEngine.Object>, IPlayerLoopItem, ITaskPoolNode<ResourceRequestConfiguredSource>
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
				nint num = (nint)typeof(ResourceRequestConfiguredSource);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v3 (Il2CppClass<Cysharp.Threading.Tasks.UnityAsyncExtensions+ResourceRequestConfiguredSource>)+B8]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v4 (Il2CppStaticFields<Cysharp.Threading.Tasks.UnityAsyncExtensions+ResourceRequestConfiguredSource>)+4]");
				return 0;
			}

			internal unsafe void _003CCreate_003Eb__14_0(object state)
			{
				//IL_004a: Unknown result type (might be due to invalid IL or missing references)
				//IL_004f: Expected O, but got Unknown
				//IL_0064: Expected O, but got I
				if (state != null)
				{
					bool flag = (object)state.GetType() != typeof(ResourceRequestConfiguredSource);
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

		private static TaskPool<ResourceRequestConfiguredSource> pool;

		private ResourceRequestConfiguredSource nextNode;

		private ResourceRequest asyncOperation;

		private IProgress<float> progress;

		private CancellationToken cancellationToken;

		private CancellationTokenRegistration cancellationTokenRegistration;

		private bool cancelImmediately;

		private bool completed;

		private UniTaskCompletionSourceCore<UnityEngine.Object> core;

		private Action<AsyncOperation> continuationAction;

		public unsafe ref ResourceRequestConfiguredSource NextNode
		{
			get
			{
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_000b: Expected Ref, but got Unknown
				return ref *(ResourceRequestConfiguredSource*)(this + 16);
			}
		}

		static ResourceRequestConfiguredSource()
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

		private ResourceRequestConfiguredSource()
		{
			Action<AsyncOperation> action = Continuation;
			continuationAction = action;
		}

		public unsafe static IUniTaskSource<UnityEngine.Object> Create(ResourceRequest asyncOperation, PlayerLoopTiming timing, IProgress<float> progress, CancellationToken cancellationToken, bool cancelImmediately, out short token)
		{
			//IL_0070: Expected I, but got O
			if ((object)cancellationToken != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ r9 (System.Threading.CancellationToken)+20]");
				ref short token2 = default(ref short);
				if ((nint)0 >= (nint)2)
				{
					return (IUniTaskSource<UnityEngine.Object>)AutoResetUniTaskCompletionSource<object>.CreateFromCanceled(cancellationToken, out token2);
				}
			}
			nint num = (nint)typeof(ResourceRequestConfiguredSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rcx_v4 (Il2CppClass<Cysharp.Threading.Tasks.UnityAsyncExtensions+ResourceRequestConfiguredSource>)+B8]");
			ResourceRequestConfiguredSource resourceRequestConfiguredSource = default(ResourceRequestConfiguredSource);
			ResourceRequestConfiguredSource resourceRequestConfiguredSource2;
			if (!((TaskPool<ResourceRequestConfiguredSource>*)null)->TryPop(out var result))
			{
				resourceRequestConfiguredSource = new ResourceRequestConfiguredSource();
				Action<AsyncOperation> action = resourceRequestConfiguredSource.Continuation;
				resourceRequestConfiguredSource.continuationAction = action;
				resourceRequestConfiguredSource2 = resourceRequestConfiguredSource;
			}
			else
			{
				resourceRequestConfiguredSource2 = result;
			}
			if (resourceRequestConfiguredSource2 != null)
			{
				resourceRequestConfiguredSource2.asyncOperation = asyncOperation;
				if (resourceRequestConfiguredSource != null)
				{
					resourceRequestConfiguredSource.progress = progress;
					if (resourceRequestConfiguredSource != null)
					{
						resourceRequestConfiguredSource.cancellationToken = cancellationToken;
						if (resourceRequestConfiguredSource != null)
						{
							bool flag = default(bool);
							resourceRequestConfiguredSource.cancelImmediately = flag;
							if (resourceRequestConfiguredSource != null)
							{
								resourceRequestConfiguredSource.completed = false;
								if (resourceRequestConfiguredSource != null && asyncOperation != null)
								{
									asyncOperation.completed += resourceRequestConfiguredSource.continuationAction;
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
													bool flag2 = (object)state.GetType() != typeof(ResourceRequestConfiguredSource);
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
										CancellationTokenRegistration cancellationTokenRegistration = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext(cancellationToken, callback, resourceRequestConfiguredSource);
										if (resourceRequestConfiguredSource == null)
										{
											goto IL_0292;
										}
										resourceRequestConfiguredSource.cancellationTokenRegistration = (CancellationTokenRegistration)cancellationTokenRegistration.m_callbackInfo;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v25 (System.Threading.CancellationTokenRegistration)+10]");
										_ = 0;
									}
									PlayerLoopHelper.AddAction(timing, resourceRequestConfiguredSource);
									if (resourceRequestConfiguredSource != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rax_v56 (Cysharp.Threading.Tasks.UnityAsyncExtensions+ResourceRequestConfiguredSource)+60]");
										ref short token2 = ref *(short*)null;
										return resourceRequestConfiguredSource;
									}
								}
							}
						}
					}
				}
			}
			goto IL_0292;
			IL_0292:
			return (IUniTaskSource<UnityEngine.Object>)new NullReferenceException();
		}

		public unsafe UnityEngine.Object GetResult(short token)
		{
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Expected O, but got Unknown
			//IL_017b: Expected O, but got I4
			object obj = default(object);
			UniTaskCompletionSourceCore<UnityEngine.Object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<UnityEngine.Object>)(obj + 80);
			UnityEngine.Object result = ((UniTaskCompletionSourceCore<UnityEngine.Object>*)uniTaskCompletionSourceCore)->GetResult(token);
			UniTaskCompletionSourceCore<UnityEngine.Object> uniTaskCompletionSourceCore2 = default(UniTaskCompletionSourceCore<UnityEngine.Object>);
			UnityEngine.Object result2 = uniTaskCompletionSourceCore2.GetResult(token);
			object obj2 = 0;
			return result;
		}

		void IUniTaskSource.GetResult(short token)
		{
			UnityEngine.Object result = GetResult(token);
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
			//IL_0182: Expected O, but got I4
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Expected O, but got Unknown
			if (!completed && asyncOperation != null)
			{
				if ((object)this.cancellationToken != null)
				{
					CancellationToken cancellationToken = this.cancellationToken;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v24 (System.Threading.CancellationToken)+20]");
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
				object result = asyncOperation.GetResult();
				UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<object>)(this + 80);
				bool flag3 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore2)->TrySetResult(result);
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
				nint num = (nint)typeof(ResourceRequestConfiguredSource);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rcx_v8 (Il2CppClass<Cysharp.Threading.Tasks.UnityAsyncExtensions+ResourceRequestConfiguredSource>)+B8]");
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v8 (System.Threading.CancellationToken)+20]");
				if ((nint)0 >= (nint)2)
				{
					UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 80);
					bool flag = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->TrySetCanceled(this.cancellationToken);
					return;
				}
			}
			object result = asyncOperation.GetResult();
			UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<object>)(this + 80);
			bool flag2 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore2)->TrySetResult(result);
		}
	}

	public struct AssetBundleRequestAwaiter(AssetBundleRequest asyncOperation) : ICriticalNotifyCompletion, INotifyCompletion
	{
		private AssetBundleRequest asyncOperation = asyncOperation;

		private Action<AsyncOperation> continuationAction = null;

		public bool IsCompleted
		{
			get
			{
				AssetBundleRequest assetBundleRequest = asyncOperation;
				bool flag = ((AsyncOperation)assetBundleRequest).m_Ptr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 25 ConditionalJump @-1, v22 @ ZF_v4 (System.Boolean) --- -1 Nop");
				/*Error: End of method reached without returning.*/;
			}
		}

		public UnityEngine.Object GetResult()
		{
			//IL_0053: Expected I, but got O
			AsyncOperation asyncOperation = this.asyncOperation;
			if (continuationAction == null)
			{
				if (this.asyncOperation != null)
				{
					nint num = (nint)asyncOperation;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v38 @ rdx_v9 (Il2CppClass<UnityEngine.AsyncOperation>)+178] (should have been resolved before IL gen)");
					this.asyncOperation = null;
					UnityEngine.Object result = default(UnityEngine.Object);
					return result;
				}
			}
			else if (this.asyncOperation != null)
			{
				this.asyncOperation.completed -= continuationAction;
				continuationAction = null;
				if (this.asyncOperation != null)
				{
					UnityEngine.Object result2 = this.asyncOperation.GetResult();
					this.asyncOperation = null;
					return result2;
				}
			}
			return (UnityEngine.Object)(object)new NullReferenceException();
		}

		public void OnCompleted(Action continuation)
		{
			UnsafeOnCompleted(continuation);
		}

		public void UnsafeOnCompleted(Action continuation)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999327C]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (continuationAction == null)
			{
				Action<AsyncOperation> action = PooledDelegate<AsyncOperation>.Create(continuation);
				continuationAction = action;
				asyncOperation.completed += continuationAction;
				return;
			}
			Error.ThrowInvalidOperationExceptionCore("continuation is already registered.");
			throw new NullReferenceException();
		}
	}

	private sealed class AssetBundleRequestConfiguredSource : IUniTaskSource<UnityEngine.Object>, IUniTaskSource, IValueTaskSource, IValueTaskSource<UnityEngine.Object>, IPlayerLoopItem, ITaskPoolNode<AssetBundleRequestConfiguredSource>
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
				nint num = (nint)typeof(AssetBundleRequestConfiguredSource);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v3 (Il2CppClass<Cysharp.Threading.Tasks.UnityAsyncExtensions+AssetBundleRequestConfiguredSource>)+B8]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v4 (Il2CppStaticFields<Cysharp.Threading.Tasks.UnityAsyncExtensions+AssetBundleRequestConfiguredSource>)+4]");
				return 0;
			}

			internal unsafe void _003CCreate_003Eb__14_0(object state)
			{
				//IL_004a: Unknown result type (might be due to invalid IL or missing references)
				//IL_004f: Expected O, but got Unknown
				//IL_0064: Expected O, but got I
				if (state != null)
				{
					bool flag = (object)state.GetType() != typeof(AssetBundleRequestConfiguredSource);
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

		private static TaskPool<AssetBundleRequestConfiguredSource> pool;

		private AssetBundleRequestConfiguredSource nextNode;

		private AssetBundleRequest asyncOperation;

		private IProgress<float> progress;

		private CancellationToken cancellationToken;

		private CancellationTokenRegistration cancellationTokenRegistration;

		private bool cancelImmediately;

		private bool completed;

		private UniTaskCompletionSourceCore<UnityEngine.Object> core;

		private Action<AsyncOperation> continuationAction;

		public unsafe ref AssetBundleRequestConfiguredSource NextNode
		{
			get
			{
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_000b: Expected Ref, but got Unknown
				return ref *(AssetBundleRequestConfiguredSource*)(this + 16);
			}
		}

		static AssetBundleRequestConfiguredSource()
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

		private AssetBundleRequestConfiguredSource()
		{
			Action<AsyncOperation> action = Continuation;
			continuationAction = action;
		}

		public unsafe static IUniTaskSource<UnityEngine.Object> Create(AssetBundleRequest asyncOperation, PlayerLoopTiming timing, IProgress<float> progress, CancellationToken cancellationToken, bool cancelImmediately, out short token)
		{
			//IL_0070: Expected I, but got O
			if ((object)cancellationToken != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ r9 (System.Threading.CancellationToken)+20]");
				ref short token2 = default(ref short);
				if ((nint)0 >= (nint)2)
				{
					return (IUniTaskSource<UnityEngine.Object>)AutoResetUniTaskCompletionSource<object>.CreateFromCanceled(cancellationToken, out token2);
				}
			}
			nint num = (nint)typeof(AssetBundleRequestConfiguredSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rcx_v4 (Il2CppClass<Cysharp.Threading.Tasks.UnityAsyncExtensions+AssetBundleRequestConfiguredSource>)+B8]");
			AssetBundleRequestConfiguredSource assetBundleRequestConfiguredSource = default(AssetBundleRequestConfiguredSource);
			AssetBundleRequestConfiguredSource assetBundleRequestConfiguredSource2;
			if (!((TaskPool<AssetBundleRequestConfiguredSource>*)null)->TryPop(out var result))
			{
				assetBundleRequestConfiguredSource = new AssetBundleRequestConfiguredSource();
				Action<AsyncOperation> action = assetBundleRequestConfiguredSource.Continuation;
				assetBundleRequestConfiguredSource.continuationAction = action;
				assetBundleRequestConfiguredSource2 = assetBundleRequestConfiguredSource;
			}
			else
			{
				assetBundleRequestConfiguredSource2 = result;
			}
			if (assetBundleRequestConfiguredSource2 != null)
			{
				assetBundleRequestConfiguredSource2.asyncOperation = asyncOperation;
				if (assetBundleRequestConfiguredSource != null)
				{
					assetBundleRequestConfiguredSource.progress = progress;
					if (assetBundleRequestConfiguredSource != null)
					{
						assetBundleRequestConfiguredSource.cancellationToken = cancellationToken;
						if (assetBundleRequestConfiguredSource != null)
						{
							bool flag = default(bool);
							assetBundleRequestConfiguredSource.cancelImmediately = flag;
							if (assetBundleRequestConfiguredSource != null)
							{
								assetBundleRequestConfiguredSource.completed = false;
								if (assetBundleRequestConfiguredSource != null && asyncOperation != null)
								{
									asyncOperation.completed += assetBundleRequestConfiguredSource.continuationAction;
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
													bool flag2 = (object)state.GetType() != typeof(AssetBundleRequestConfiguredSource);
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
										CancellationTokenRegistration cancellationTokenRegistration = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext(cancellationToken, callback, assetBundleRequestConfiguredSource);
										if (assetBundleRequestConfiguredSource == null)
										{
											goto IL_0292;
										}
										assetBundleRequestConfiguredSource.cancellationTokenRegistration = (CancellationTokenRegistration)cancellationTokenRegistration.m_callbackInfo;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v25 (System.Threading.CancellationTokenRegistration)+10]");
										_ = 0;
									}
									PlayerLoopHelper.AddAction(timing, assetBundleRequestConfiguredSource);
									if (assetBundleRequestConfiguredSource != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rax_v56 (Cysharp.Threading.Tasks.UnityAsyncExtensions+AssetBundleRequestConfiguredSource)+60]");
										ref short token2 = ref *(short*)null;
										return assetBundleRequestConfiguredSource;
									}
								}
							}
						}
					}
				}
			}
			goto IL_0292;
			IL_0292:
			return (IUniTaskSource<UnityEngine.Object>)new NullReferenceException();
		}

		public unsafe UnityEngine.Object GetResult(short token)
		{
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Expected O, but got Unknown
			//IL_017b: Expected O, but got I4
			object obj = default(object);
			UniTaskCompletionSourceCore<UnityEngine.Object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<UnityEngine.Object>)(obj + 80);
			UnityEngine.Object result = ((UniTaskCompletionSourceCore<UnityEngine.Object>*)uniTaskCompletionSourceCore)->GetResult(token);
			UniTaskCompletionSourceCore<UnityEngine.Object> uniTaskCompletionSourceCore2 = default(UniTaskCompletionSourceCore<UnityEngine.Object>);
			UnityEngine.Object result2 = uniTaskCompletionSourceCore2.GetResult(token);
			object obj2 = 0;
			return result;
		}

		void IUniTaskSource.GetResult(short token)
		{
			UnityEngine.Object result = GetResult(token);
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
			//IL_0182: Expected O, but got I4
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Expected O, but got Unknown
			if (!completed && asyncOperation != null)
			{
				if ((object)this.cancellationToken != null)
				{
					CancellationToken cancellationToken = this.cancellationToken;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v24 (System.Threading.CancellationToken)+20]");
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
				object result = asyncOperation.GetResult();
				UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<object>)(this + 80);
				bool flag3 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore2)->TrySetResult(result);
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
				nint num = (nint)typeof(AssetBundleRequestConfiguredSource);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rcx_v8 (Il2CppClass<Cysharp.Threading.Tasks.UnityAsyncExtensions+AssetBundleRequestConfiguredSource>)+B8]");
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v8 (System.Threading.CancellationToken)+20]");
				if ((nint)0 >= (nint)2)
				{
					UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 80);
					bool flag = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->TrySetCanceled(this.cancellationToken);
					return;
				}
			}
			object result = asyncOperation.GetResult();
			UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<object>)(this + 80);
			bool flag2 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore2)->TrySetResult(result);
		}
	}

	public struct AssetBundleCreateRequestAwaiter(AssetBundleCreateRequest asyncOperation) : ICriticalNotifyCompletion, INotifyCompletion
	{
		private AssetBundleCreateRequest asyncOperation = asyncOperation;

		private Action<AsyncOperation> continuationAction = null;

		public bool IsCompleted
		{
			get
			{
				AssetBundleCreateRequest assetBundleCreateRequest = asyncOperation;
				bool flag = ((AsyncOperation)assetBundleCreateRequest).m_Ptr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 25 ConditionalJump @-1, v22 @ ZF_v4 (System.Boolean) --- -1 Nop");
				/*Error: End of method reached without returning.*/;
			}
		}

		public AssetBundle GetResult()
		{
			//IL_0130->IL0055: Incompatible stack heights: 1 vs 0
			AssetBundleCreateRequest assetBundleCreateRequest = asyncOperation;
			if (continuationAction == null)
			{
				if (asyncOperation != null)
				{
					bool flag = ((AsyncOperation)assetBundleCreateRequest).m_Ptr == (IntPtr)0;
					IntPtr gcHandlePtr = AssetBundleCreateRequest.get_assetBundle_Injected(((AsyncOperation)assetBundleCreateRequest).m_Ptr);
					AssetBundle result = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<AssetBundle>(gcHandlePtr);
					asyncOperation = null;
					return result;
				}
			}
			else if (asyncOperation != null)
			{
				asyncOperation.completed -= continuationAction;
				continuationAction = null;
				if (asyncOperation != null)
				{
					AssetBundle assetBundle = asyncOperation.assetBundle;
					asyncOperation = null;
					return assetBundle;
				}
			}
			throw new NullReferenceException();
		}

		public void OnCompleted(Action continuation)
		{
			UnsafeOnCompleted(continuation);
		}

		public void UnsafeOnCompleted(Action continuation)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999327C]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (continuationAction == null)
			{
				Action<AsyncOperation> action = PooledDelegate<AsyncOperation>.Create(continuation);
				continuationAction = action;
				asyncOperation.completed += continuationAction;
				return;
			}
			Error.ThrowInvalidOperationExceptionCore("continuation is already registered.");
			throw new NullReferenceException();
		}
	}

	private sealed class AssetBundleCreateRequestConfiguredSource : IUniTaskSource<AssetBundle>, IUniTaskSource, IValueTaskSource, IValueTaskSource<AssetBundle>, IPlayerLoopItem, ITaskPoolNode<AssetBundleCreateRequestConfiguredSource>
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
				nint num = (nint)typeof(AssetBundleCreateRequestConfiguredSource);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v3 (Il2CppClass<Cysharp.Threading.Tasks.UnityAsyncExtensions+AssetBundleCreateRequestConfiguredSource>)+B8]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v4 (Il2CppStaticFields<Cysharp.Threading.Tasks.UnityAsyncExtensions+AssetBundleCreateRequestConfiguredSource>)+4]");
				return 0;
			}

			internal unsafe void _003CCreate_003Eb__14_0(object state)
			{
				//IL_004a: Unknown result type (might be due to invalid IL or missing references)
				//IL_004f: Expected O, but got Unknown
				//IL_0064: Expected O, but got I
				if (state != null)
				{
					bool flag = (object)state.GetType() != typeof(AssetBundleCreateRequestConfiguredSource);
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

		private static TaskPool<AssetBundleCreateRequestConfiguredSource> pool;

		private AssetBundleCreateRequestConfiguredSource nextNode;

		private AssetBundleCreateRequest asyncOperation;

		private IProgress<float> progress;

		private CancellationToken cancellationToken;

		private CancellationTokenRegistration cancellationTokenRegistration;

		private bool cancelImmediately;

		private bool completed;

		private UniTaskCompletionSourceCore<AssetBundle> core;

		private Action<AsyncOperation> continuationAction;

		public unsafe ref AssetBundleCreateRequestConfiguredSource NextNode
		{
			get
			{
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_000b: Expected Ref, but got Unknown
				return ref *(AssetBundleCreateRequestConfiguredSource*)(this + 16);
			}
		}

		static AssetBundleCreateRequestConfiguredSource()
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

		private AssetBundleCreateRequestConfiguredSource()
		{
			Action<AsyncOperation> action = Continuation;
			continuationAction = action;
		}

		public unsafe static IUniTaskSource<AssetBundle> Create(AssetBundleCreateRequest asyncOperation, PlayerLoopTiming timing, IProgress<float> progress, CancellationToken cancellationToken, bool cancelImmediately, out short token)
		{
			//IL_0070: Expected I, but got O
			if ((object)cancellationToken != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ r9 (System.Threading.CancellationToken)+20]");
				ref short token2 = default(ref short);
				if ((nint)0 >= (nint)2)
				{
					return (IUniTaskSource<AssetBundle>)AutoResetUniTaskCompletionSource<object>.CreateFromCanceled(cancellationToken, out token2);
				}
			}
			nint num = (nint)typeof(AssetBundleCreateRequestConfiguredSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rcx_v4 (Il2CppClass<Cysharp.Threading.Tasks.UnityAsyncExtensions+AssetBundleCreateRequestConfiguredSource>)+B8]");
			AssetBundleCreateRequestConfiguredSource assetBundleCreateRequestConfiguredSource = default(AssetBundleCreateRequestConfiguredSource);
			AssetBundleCreateRequestConfiguredSource assetBundleCreateRequestConfiguredSource2;
			if (!((TaskPool<AssetBundleCreateRequestConfiguredSource>*)null)->TryPop(out var result))
			{
				assetBundleCreateRequestConfiguredSource = new AssetBundleCreateRequestConfiguredSource();
				Action<AsyncOperation> action = assetBundleCreateRequestConfiguredSource.Continuation;
				assetBundleCreateRequestConfiguredSource.continuationAction = action;
				assetBundleCreateRequestConfiguredSource2 = assetBundleCreateRequestConfiguredSource;
			}
			else
			{
				assetBundleCreateRequestConfiguredSource2 = result;
			}
			if (assetBundleCreateRequestConfiguredSource2 != null)
			{
				assetBundleCreateRequestConfiguredSource2.asyncOperation = asyncOperation;
				if (assetBundleCreateRequestConfiguredSource != null)
				{
					assetBundleCreateRequestConfiguredSource.progress = progress;
					if (assetBundleCreateRequestConfiguredSource != null)
					{
						assetBundleCreateRequestConfiguredSource.cancellationToken = cancellationToken;
						if (assetBundleCreateRequestConfiguredSource != null)
						{
							bool flag = default(bool);
							assetBundleCreateRequestConfiguredSource.cancelImmediately = flag;
							if (assetBundleCreateRequestConfiguredSource != null)
							{
								assetBundleCreateRequestConfiguredSource.completed = false;
								if (assetBundleCreateRequestConfiguredSource != null && asyncOperation != null)
								{
									asyncOperation.completed += assetBundleCreateRequestConfiguredSource.continuationAction;
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
													bool flag2 = (object)state.GetType() != typeof(AssetBundleCreateRequestConfiguredSource);
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
										CancellationTokenRegistration cancellationTokenRegistration = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext(cancellationToken, callback, assetBundleCreateRequestConfiguredSource);
										if (assetBundleCreateRequestConfiguredSource == null)
										{
											goto IL_0292;
										}
										assetBundleCreateRequestConfiguredSource.cancellationTokenRegistration = (CancellationTokenRegistration)cancellationTokenRegistration.m_callbackInfo;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v25 (System.Threading.CancellationTokenRegistration)+10]");
										_ = 0;
									}
									PlayerLoopHelper.AddAction(timing, assetBundleCreateRequestConfiguredSource);
									if (assetBundleCreateRequestConfiguredSource != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rax_v56 (Cysharp.Threading.Tasks.UnityAsyncExtensions+AssetBundleCreateRequestConfiguredSource)+60]");
										ref short token2 = ref *(short*)null;
										return assetBundleCreateRequestConfiguredSource;
									}
								}
							}
						}
					}
				}
			}
			goto IL_0292;
			IL_0292:
			return (IUniTaskSource<AssetBundle>)new NullReferenceException();
		}

		public unsafe AssetBundle GetResult(short token)
		{
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Expected O, but got Unknown
			//IL_017b: Expected O, but got I4
			object obj = default(object);
			UniTaskCompletionSourceCore<AssetBundle> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AssetBundle>)(obj + 80);
			AssetBundle result = ((UniTaskCompletionSourceCore<AssetBundle>*)uniTaskCompletionSourceCore)->GetResult(token);
			UniTaskCompletionSourceCore<AssetBundle> uniTaskCompletionSourceCore2 = default(UniTaskCompletionSourceCore<AssetBundle>);
			AssetBundle result2 = uniTaskCompletionSourceCore2.GetResult(token);
			object obj2 = 0;
			return result;
		}

		void IUniTaskSource.GetResult(short token)
		{
			AssetBundle result = GetResult(token);
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v23 (System.Threading.CancellationToken)+20]");
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
				AssetBundle assetBundle = asyncOperation.assetBundle;
				UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<object>)(this + 80);
				bool flag3 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore2)->TrySetResult(assetBundle);
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
				nint num = (nint)typeof(AssetBundleCreateRequestConfiguredSource);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rcx_v8 (Il2CppClass<Cysharp.Threading.Tasks.UnityAsyncExtensions+AssetBundleCreateRequestConfiguredSource>)+B8]");
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v7 (System.Threading.CancellationToken)+20]");
				if ((nint)0 >= (nint)2)
				{
					UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 80);
					bool flag = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->TrySetCanceled(this.cancellationToken);
					return;
				}
			}
			AssetBundle assetBundle = asyncOperation.assetBundle;
			UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<object>)(this + 80);
			bool flag2 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore2)->TrySetResult(assetBundle);
		}
	}

	public struct UnityWebRequestAsyncOperationAwaiter(UnityWebRequestAsyncOperation asyncOperation) : ICriticalNotifyCompletion, INotifyCompletion
	{
		private UnityWebRequestAsyncOperation asyncOperation = asyncOperation;

		private Action<AsyncOperation> continuationAction = null;

		public bool IsCompleted
		{
			get
			{
				UnityWebRequestAsyncOperation unityWebRequestAsyncOperation = asyncOperation;
				bool flag = ((AsyncOperation)unityWebRequestAsyncOperation).m_Ptr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 25 ConditionalJump @-1, v22 @ ZF_v4 (System.Boolean) --- -1 Nop");
				/*Error: End of method reached without returning.*/;
			}
		}

		public UnityWebRequest GetResult()
		{
			//IL_005b: Expected O, but got I
			//IL_019e: Expected O, but got I4
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Expected O, but got Unknown
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Expected O, but got Unknown
			//IL_0212: Expected O, but got I4
			//IL_021b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0220: Expected O, but got Unknown
			//IL_022d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0232: Expected O, but got Unknown
			AsyncOperation asyncOperation = this.asyncOperation;
			UnityWebRequest unityWebRequest;
			bool num;
			bool num2;
			bool num3;
			if (continuationAction == null)
			{
				if (this.asyncOperation != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rcx_v1 (UnityEngine.AsyncOperation)+20]");
					unityWebRequest = (UnityWebRequest)0;
					this.asyncOperation = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rcx_v1 (UnityEngine.AsyncOperation)+20]");
					if ((nint)0 != 0)
					{
						bool flag = unityWebRequest.m_Ptr == (IntPtr)0;
						num = flag;
						object obj = UnityWebRequest.get_result_Injected(unityWebRequest.m_Ptr);
						object obj2 = obj - 2;
						object obj3 = obj2 & 0xFFFFFFFDL;
						bool flag2 = obj3 == null;
						num2 = flag2;
						bool flag3 = (nint)obj == 3;
						num3 = flag3;
						goto IL_0180;
					}
				}
			}
			else if (this.asyncOperation != null)
			{
				this.asyncOperation.completed -= continuationAction;
				continuationAction = null;
				UnityWebRequest unityWebRequest2 = (UnityWebRequest)(object)this.asyncOperation;
				if (this.asyncOperation != null)
				{
					unityWebRequest = (UnityWebRequest)(object)unityWebRequest2.m_UploadHandler;
					this.asyncOperation = null;
					if (unityWebRequest2.m_UploadHandler != null)
					{
						bool flag4 = unityWebRequest.m_Ptr == (IntPtr)0;
						num = flag4;
						object obj4 = UnityWebRequest.get_result_Injected(unityWebRequest.m_Ptr);
						object obj5 = obj4 - 2;
						object obj6 = obj5 & 0xFFFFFFFDL;
						bool flag5 = obj6 == null;
						num2 = flag5;
						bool flag6 = (nint)obj4 == 3;
						num3 = flag6;
						goto IL_0180;
					}
				}
			}
			throw new NullReferenceException();
			IL_0180:
			return unityWebRequest;
		}

		public void OnCompleted(Action continuation)
		{
			UnsafeOnCompleted(continuation);
		}

		public void UnsafeOnCompleted(Action continuation)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999327C]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (continuationAction == null)
			{
				Action<AsyncOperation> action = PooledDelegate<AsyncOperation>.Create(continuation);
				continuationAction = action;
				asyncOperation.completed += continuationAction;
				return;
			}
			Error.ThrowInvalidOperationExceptionCore("continuation is already registered.");
			throw new NullReferenceException();
		}
	}

	private sealed class UnityWebRequestAsyncOperationConfiguredSource : IUniTaskSource<UnityWebRequest>, IUniTaskSource, IValueTaskSource, IValueTaskSource<UnityWebRequest>, IPlayerLoopItem, ITaskPoolNode<UnityWebRequestAsyncOperationConfiguredSource>
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
				nint num = (nint)typeof(UnityWebRequestAsyncOperationConfiguredSource);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v3 (Il2CppClass<Cysharp.Threading.Tasks.UnityAsyncExtensions+UnityWebRequestAsyncOperationConfiguredSource>)+B8]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v4 (Il2CppStaticFields<Cysharp.Threading.Tasks.UnityAsyncExtensions+UnityWebRequestAsyncOperationConfiguredSource>)+4]");
				return 0;
			}

			internal unsafe void _003CCreate_003Eb__14_0(object state)
			{
				//IL_0051: Expected O, but got I
				//IL_0066: Expected O, but got I
				//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c9: Expected O, but got Unknown
				//IL_00de: Expected O, but got I
				bool flag = (object)state.GetType() != typeof(UnityWebRequestAsyncOperationConfiguredSource);
				object obj = null;
				if (!flag)
				{
					obj = state;
				}
				bool flag2 = obj == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rbx_v6 (System.Object)+18]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rcx_v9+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v10 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v10 (System.Object)+10]");
				UnityWebRequest.Abort_Injected((IntPtr)0);
				UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(obj + 80);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rbx_v6 (System.Object)+28]");
				bool flag4 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->TrySetCanceled((CancellationToken)0);
			}
		}

		private static TaskPool<UnityWebRequestAsyncOperationConfiguredSource> pool;

		private UnityWebRequestAsyncOperationConfiguredSource nextNode;

		private UnityWebRequestAsyncOperation asyncOperation;

		private IProgress<float> progress;

		private CancellationToken cancellationToken;

		private CancellationTokenRegistration cancellationTokenRegistration;

		private bool cancelImmediately;

		private bool completed;

		private UniTaskCompletionSourceCore<UnityWebRequest> core;

		private Action<AsyncOperation> continuationAction;

		public unsafe ref UnityWebRequestAsyncOperationConfiguredSource NextNode
		{
			get
			{
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_000b: Expected Ref, but got Unknown
				return ref *(UnityWebRequestAsyncOperationConfiguredSource*)(this + 16);
			}
		}

		static UnityWebRequestAsyncOperationConfiguredSource()
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

		private UnityWebRequestAsyncOperationConfiguredSource()
		{
			Action<AsyncOperation> action = Continuation;
			continuationAction = action;
		}

		public unsafe static IUniTaskSource<UnityWebRequest> Create(UnityWebRequestAsyncOperation asyncOperation, PlayerLoopTiming timing, IProgress<float> progress, CancellationToken cancellationToken, bool cancelImmediately, out short token)
		{
			//IL_0070: Expected I, but got O
			if ((object)cancellationToken != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ r9 (System.Threading.CancellationToken)+20]");
				ref short token2 = default(ref short);
				if ((nint)0 >= (nint)2)
				{
					return (IUniTaskSource<UnityWebRequest>)AutoResetUniTaskCompletionSource<object>.CreateFromCanceled(cancellationToken, out token2);
				}
			}
			nint num = (nint)typeof(UnityWebRequestAsyncOperationConfiguredSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rcx_v4 (Il2CppClass<Cysharp.Threading.Tasks.UnityAsyncExtensions+UnityWebRequestAsyncOperationConfiguredSource>)+B8]");
			UnityWebRequestAsyncOperationConfiguredSource unityWebRequestAsyncOperationConfiguredSource = default(UnityWebRequestAsyncOperationConfiguredSource);
			UnityWebRequestAsyncOperationConfiguredSource unityWebRequestAsyncOperationConfiguredSource2;
			if (!((TaskPool<UnityWebRequestAsyncOperationConfiguredSource>*)null)->TryPop(out var result))
			{
				unityWebRequestAsyncOperationConfiguredSource = new UnityWebRequestAsyncOperationConfiguredSource();
				Action<AsyncOperation> action = unityWebRequestAsyncOperationConfiguredSource.Continuation;
				unityWebRequestAsyncOperationConfiguredSource.continuationAction = action;
				unityWebRequestAsyncOperationConfiguredSource2 = unityWebRequestAsyncOperationConfiguredSource;
			}
			else
			{
				unityWebRequestAsyncOperationConfiguredSource2 = result;
			}
			if (unityWebRequestAsyncOperationConfiguredSource2 != null)
			{
				unityWebRequestAsyncOperationConfiguredSource2.asyncOperation = asyncOperation;
				if (unityWebRequestAsyncOperationConfiguredSource != null)
				{
					unityWebRequestAsyncOperationConfiguredSource.progress = progress;
					if (unityWebRequestAsyncOperationConfiguredSource != null)
					{
						unityWebRequestAsyncOperationConfiguredSource.cancellationToken = cancellationToken;
						if (unityWebRequestAsyncOperationConfiguredSource != null)
						{
							bool flag = default(bool);
							unityWebRequestAsyncOperationConfiguredSource.cancelImmediately = flag;
							if (unityWebRequestAsyncOperationConfiguredSource != null)
							{
								unityWebRequestAsyncOperationConfiguredSource.completed = false;
								if (unityWebRequestAsyncOperationConfiguredSource != null && asyncOperation != null)
								{
									asyncOperation.completed += unityWebRequestAsyncOperationConfiguredSource.continuationAction;
									if (flag && (object)cancellationToken != null)
									{
										Action<object> callback = _003C_003Ec._003C_003E9__14_0;
										if (_003C_003Ec._003C_003E9__14_0 == null)
										{
											callback = (_003C_003Ec._003C_003E9__14_0 = delegate(object state)
											{
												//IL_0051: Expected O, but got I
												//IL_0066: Expected O, but got I
												//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
												//IL_00c9: Expected O, but got Unknown
												//IL_00de: Expected O, but got I
												bool flag2 = (object)state.GetType() != typeof(UnityWebRequestAsyncOperationConfiguredSource);
												object obj = null;
												if (!flag2)
												{
													obj = state;
												}
												bool flag3 = obj == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rbx_v6 (System.Object)+18]");
												object obj2 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rcx_v9+20]");
												object obj3 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v10 (System.Object)+10]");
												bool flag4 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v10 (System.Object)+10]");
												UnityWebRequest.Abort_Injected((IntPtr)0);
												UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(obj + 80);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rbx_v6 (System.Object)+28]");
												bool flag5 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->TrySetCanceled((CancellationToken)0);
											});
										}
										CancellationTokenRegistration cancellationTokenRegistration = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext(cancellationToken, callback, unityWebRequestAsyncOperationConfiguredSource);
										if (unityWebRequestAsyncOperationConfiguredSource == null)
										{
											goto IL_0292;
										}
										unityWebRequestAsyncOperationConfiguredSource.cancellationTokenRegistration = (CancellationTokenRegistration)cancellationTokenRegistration.m_callbackInfo;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v25 (System.Threading.CancellationTokenRegistration)+10]");
										_ = 0;
									}
									PlayerLoopHelper.AddAction(timing, unityWebRequestAsyncOperationConfiguredSource);
									if (unityWebRequestAsyncOperationConfiguredSource != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rax_v56 (Cysharp.Threading.Tasks.UnityAsyncExtensions+UnityWebRequestAsyncOperationConfiguredSource)+60]");
										ref short token2 = ref *(short*)null;
										return unityWebRequestAsyncOperationConfiguredSource;
									}
								}
							}
						}
					}
				}
			}
			goto IL_0292;
			IL_0292:
			return (IUniTaskSource<UnityWebRequest>)new NullReferenceException();
		}

		public unsafe UnityWebRequest GetResult(short token)
		{
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Expected O, but got Unknown
			//IL_0178: Expected O, but got I4
			object obj = default(object);
			UniTaskCompletionSourceCore<UnityWebRequest> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<UnityWebRequest>)(obj + 80);
			UnityWebRequest result = ((UniTaskCompletionSourceCore<UnityWebRequest>*)uniTaskCompletionSourceCore)->GetResult(token);
			UniTaskCompletionSourceCore<UnityWebRequest> uniTaskCompletionSourceCore2 = default(UniTaskCompletionSourceCore<UnityWebRequest>);
			UnityWebRequest result2 = uniTaskCompletionSourceCore2.GetResult(token);
			object obj2 = 0;
			return result;
		}

		void IUniTaskSource.GetResult(short token)
		{
			UnityWebRequest result = GetResult(token);
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
			//IL_0243: Expected O, but got I4
			//IL_0211: Unknown result type (might be due to invalid IL or missing references)
			//IL_0216: Expected O, but got Unknown
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c1: Expected O, but got Unknown
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Expected O, but got Unknown
			//IL_022e->IL00be: Incompatible stack heights: 1 vs 0
			if (!completed && asyncOperation != null)
			{
				if ((object)this.cancellationToken != null)
				{
					CancellationToken cancellationToken = this.cancellationToken;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rax_v32 (System.Threading.CancellationToken)+20]");
					if ((nint)0 >= (nint)2)
					{
						UnityWebRequestAsyncOperation unityWebRequestAsyncOperation = asyncOperation;
						object obj = unityWebRequestAsyncOperation._003CwebRequest_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rcx_v29 (System.Object)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rcx_v29 (System.Object)+10]");
						UnityWebRequest.Abort_Injected((IntPtr)0);
						UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 80);
						bool flag2 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->TrySetCanceled(this.cancellationToken);
						goto IL_00be;
					}
				}
				if (progress != null)
				{
					float num = asyncOperation.progress;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180496590");
				}
				object obj2 = asyncOperation;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rcx_v15 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rcx_v15 (System.Object)+10]");
				object obj3 = AsyncOperation.get_isDone_Injected((IntPtr)0);
				if (obj3 == null)
				{
					return true;
				}
				UnityWebRequestAsyncOperation unityWebRequestAsyncOperation2 = asyncOperation;
				bool flag4 = UnityWebRequestResultExtensions.IsError(unityWebRequestAsyncOperation2._003CwebRequest_003Ek__BackingField);
				UnityWebRequestAsyncOperation unityWebRequestAsyncOperation3 = asyncOperation;
				if (!flag4)
				{
					UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<object>)(this + 80);
					bool flag5 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore2)->TrySetResult(unityWebRequestAsyncOperation3._003CwebRequest_003Ek__BackingField);
					return false;
				}
				UnityWebRequestException error = new UnityWebRequestException(unityWebRequestAsyncOperation3._003CwebRequest_003Ek__BackingField);
				UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore3 = (UniTaskCompletionSourceCore<object>)(this + 80);
				bool flag6 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore3)->TrySetException(error);
				return false;
			}
			goto IL_00be;
			IL_00be:
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
				nint num = (nint)typeof(UnityWebRequestAsyncOperationConfiguredSource);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rcx_v8 (Il2CppClass<Cysharp.Threading.Tasks.UnityAsyncExtensions+UnityWebRequestAsyncOperationConfiguredSource>)+B8]");
				return ((TaskPool<object>*)null)->TryPush(this);
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		private unsafe void Continuation(AsyncOperation _)
		{
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Expected O, but got Unknown
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Expected O, but got Unknown
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v12 (System.Threading.CancellationToken)+20]");
				if ((nint)0 >= (nint)2)
				{
					UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 80);
					bool flag = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->TrySetCanceled(this.cancellationToken);
					return;
				}
			}
			UnityWebRequestAsyncOperation unityWebRequestAsyncOperation = asyncOperation;
			bool flag2 = UnityWebRequestResultExtensions.IsError(unityWebRequestAsyncOperation._003CwebRequest_003Ek__BackingField);
			UnityWebRequestAsyncOperation unityWebRequestAsyncOperation2 = asyncOperation;
			if (!flag2)
			{
				UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<object>)(this + 80);
				bool flag3 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore2)->TrySetResult(unityWebRequestAsyncOperation2._003CwebRequest_003Ek__BackingField);
			}
			else
			{
				UnityWebRequestException error = new UnityWebRequestException(unityWebRequestAsyncOperation2._003CwebRequest_003Ek__BackingField);
				UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore3 = (UniTaskCompletionSourceCore<object>)(this + 80);
				bool flag4 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore3)->TrySetException(error);
			}
		}
	}

	private sealed class JobHandlePromise : IUniTaskSource, IValueTaskSource, IPlayerLoopItem
	{
		private JobHandle jobHandle;

		private UniTaskCompletionSourceCore<AsyncUnit> core;

		public unsafe static JobHandlePromise Create(JobHandle jobHandle, out short token)
		{
			//IL_0017: Expected O, but got I8
			JobHandlePromise jobHandlePromise = new JobHandlePromise();
			if (jobHandlePromise != null)
			{
				jobHandlePromise.jobHandle = (JobHandle)jobHandle.jobGroup;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal1 @ rax_v2 (Cysharp.Threading.Tasks.UnityAsyncExtensions+JobHandlePromise)+30]");
				ref short reference = ref *(short*)null;
				return jobHandlePromise;
			}
			return (JobHandlePromise)(object)new NullReferenceException();
		}

		public unsafe void GetResult(short token)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 32);
			AsyncUnit result = ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->GetResult(token);
		}

		public unsafe UniTaskStatus GetStatus(short token)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 32);
			return ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->GetStatus(token);
		}

		public unsafe UniTaskStatus UnsafeGetStatus()
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 32);
			return ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->UnsafeGetStatus();
		}

		public unsafe void OnCompleted(Action<object> continuation, object state, short token)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 32);
			((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->OnCompleted(continuation, state, token);
		}

		public unsafe bool MoveNext()
		{
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Expected O, but got Unknown
			//IL_00aa: Expected O, but got I4
			//IL_006f: Expected I, but got O
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Expected O, but got Unknown
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Expected O, but got Unknown
			object obj = this + 16;
			object obj2 = JobHandle.ScheduleBatchedJobsAndIsCompleted(ref *(JobHandle*)obj);
			nint num = (nint)typeof(PlayerLoopHelper);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v6 (Il2CppClass<Cysharp.Threading.Tasks.PlayerLoopHelper>)+E4]");
			if ((nint)0 == 0)
			{
				return true;
			}
			if ((object)jobHandle != null)
			{
				object obj3 = this + 16;
				JobHandle.ScheduleBatchedJobsAndComplete(ref *(JobHandle*)obj3);
			}
			UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 32);
			bool flag = ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->TrySetResult(AsyncUnit.Default);
			return false;
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CWaitAsync_003Ed__40 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public PlayerLoopTiming waitTiming;

		public JobHandle jobHandle;

		public CancellationToken cancellationToken;

		private YieldAwaitable.Awaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0097: Expected O, but got I4
			//IL_00a2: Expected O, but got Ref
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_004e: Expected O, but got Ref
			//IL_0066: Expected I4, but got I8
			//IL_00e7: Expected O, but got Ref
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (YieldAwaitable.Awaiter)0;
				_003C_003E1__state = -1;
				if ((object)jobHandle != null)
				{
					object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 32));
					JobHandle.ScheduleBatchedJobsAndComplete(ref *(JobHandle*)obj);
				}
				CancellationToken cancellationToken = (CancellationToken)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 48));
				((CancellationToken*)cancellationToken)->ThrowIfCancellationRequested();
				_003C_003E1__state = -2;
				if ((object)_003C_003Et__builder != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
			}
			else
			{
				_003C_003E1__state = 0;
				_003C_003Eu__1 = (YieldAwaitable.Awaiter)waitTiming;
				AsyncUniTaskMethodBuilder asyncUniTaskMethodBuilder = (AsyncUniTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				YieldAwaitable.Awaiter awaiter = default(YieldAwaitable.Awaiter);
				((AsyncUniTaskMethodBuilder*)asyncUniTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
			}
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	public unsafe static AssetBundleRequestAllAssetsAwaiter AwaitForAllAssets(AssetBundleRequest asyncOperation)
	{
		//IL_000a: Expected native int or pointer, but got O
		//IL_0017: Expected native int or pointer, but got O
		if (asyncOperation != null)
		{
			AssetBundleRequestAllAssetsAwaiter assetBundleRequestAllAssetsAwaiter = default(AssetBundleRequestAllAssetsAwaiter);
			System.Runtime.CompilerServices.Unsafe.Write(&((AssetBundleRequestAllAssetsAwaiter*)(nint)assetBundleRequestAllAssetsAwaiter)->asyncOperation, null);
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)assetBundleRequestAllAssetsAwaiter, new AssetBundleRequestAllAssetsAwaiter(asyncOperation));
			return assetBundleRequestAllAssetsAwaiter;
		}
		Error.ThrowArgumentNullExceptionCore("asyncOperation");
		AssetBundleRequestAllAssetsAwaiter result = default(AssetBundleRequestAllAssetsAwaiter);
		return result;
	}

	public unsafe static UniTask<UnityEngine.Object[]> AwaitForAllAssets(AssetBundleRequest asyncOperation, CancellationToken cancellationToken)
	{
		//IL_001b: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		//IL_0039: Expected I, but got O
		object obj = default(object);
		bool cancelImmediately = default(bool);
		UniTask<UnityEngine.Object[]> uniTask = AwaitForAllAssets((AssetBundleRequest)(&obj), (IProgress<float>)cancellationToken, PlayerLoopTiming.Initialization, (CancellationToken)8, cancelImmediately);
		AssetBundleRequest assetBundleRequest = (AssetBundleRequest)uniTask;
		((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)uniTask.source;
		return (UniTask<UnityEngine.Object[]>)asyncOperation;
	}

	public unsafe static UniTask<UnityEngine.Object[]> AwaitForAllAssets(AssetBundleRequest asyncOperation, CancellationToken cancellationToken, bool cancelImmediately)
	{
		//IL_001b: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		//IL_0039: Expected I, but got O
		object obj = default(object);
		bool cancelImmediately2 = default(bool);
		UniTask<UnityEngine.Object[]> uniTask = AwaitForAllAssets((AssetBundleRequest)(&obj), (IProgress<float>)cancellationToken, PlayerLoopTiming.Initialization, (CancellationToken)8, cancelImmediately2);
		AssetBundleRequest assetBundleRequest = (AssetBundleRequest)uniTask;
		((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)uniTask.source;
		return (UniTask<UnityEngine.Object[]>)asyncOperation;
	}

	public unsafe static UniTask<UnityEngine.Object[]> AwaitForAllAssets(AssetBundleRequest asyncOperation, IProgress<float> progress = null, PlayerLoopTiming timing = PlayerLoopTiming.Update, CancellationToken cancellationToken = default(CancellationToken), bool cancelImmediately = false)
	{
		//IL_01b8: Expected O, but got I4
		//IL_005a: Expected O, but got Ref
		//IL_00c0: Expected O, but got I4
		//IL_00c0: Expected I4, but got O
		//IL_00cd: Expected O, but got I4
		//IL_0163: Expected O, but got I4
		//IL_00ea->IL019e: Incompatible stack heights: 1 vs 0
		//IL_0176->IL019e: Incompatible stack heights: 2 vs 0
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
				AssetBundleRequest assetBundleRequest = (AssetBundleRequest)uniTask2;
				IntPtr ptr = default(IntPtr);
				((AsyncOperation)asyncOperation).m_Ptr = ptr;
				goto IL_019e;
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
			IUniTaskSource<UnityEngine.Object[]> uniTaskSource = AssetBundleRequestAllAssetsConfiguredSource.Create((AssetBundleRequest)progress, (PlayerLoopTiming)cancellationToken, (IProgress<float>)timing, cancellationToken2, cancelImmediately2, out token);
			AssetBundleRequest assetBundleRequest = (AssetBundleRequest)0;
			((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4500");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [progress @ rdx (System.IProgress`1<System.Single>)+10]");
			bool flag2 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [progress @ rdx (System.IProgress`1<System.Single>)+10]");
			object result = AssetBundleRequest.get_allAssets_Injected((IntPtr)0);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rcx_v18 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			uniTask2 = new UniTask<object>(result);
			AssetBundleRequest assetBundleRequest = (AssetBundleRequest)0;
			((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)0;
		}
		goto IL_019e;
		IL_019e:
		return (UniTask<UnityEngine.Object[]>)asyncOperation;
	}

	public unsafe static UniTask<AsyncGPUReadbackRequest>.Awaiter GetAwaiter(AsyncGPUReadbackRequest asyncOperation)
	{
		//IL_001c: Expected O, but got I4
		//IL_001c: Expected O, but got Ref
		//IL_0037: Expected I, but got O
		//IL_0032: Expected native int or pointer, but got O
		object obj = default(object);
		object obj2 = default(object);
		UniTask<AsyncGPUReadbackRequest> uniTask = ToUniTask((AsyncGPUReadbackRequest)(&obj), (PlayerLoopTiming)(int)(&obj2), (CancellationToken)8);
		((AsyncGPUReadbackRequest*)(nint)asyncOperation)->m_Ptr = (IntPtr)uniTask;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (Cysharp.Threading.Tasks.UniTask`1<UnityEngine.Rendering.AsyncGPUReadbackRequest>)+10]");
		_ = 0;
		return (UniTask<AsyncGPUReadbackRequest>.Awaiter)asyncOperation;
	}

	public unsafe static UniTask<AsyncGPUReadbackRequest> WithCancellation(AsyncGPUReadbackRequest asyncOperation, CancellationToken cancellationToken)
	{
		//IL_0017: Expected O, but got I4
		//IL_0017: Expected O, but got Ref
		//IL_0028: Expected I, but got O
		//IL_0023: Expected native int or pointer, but got O
		object obj = default(object);
		CancellationTokenSource cancellationTokenSource = default(CancellationTokenSource);
		IntPtr intPtr = default(IntPtr);
		UniTask<AsyncGPUReadbackRequest> uniTask = ToUniTask((AsyncGPUReadbackRequest)(&obj), (PlayerLoopTiming)(int)(&cancellationTokenSource), (CancellationToken)8, (byte)(nint)intPtr != 0);
		((AsyncGPUReadbackRequest*)(nint)asyncOperation)->m_Ptr = (IntPtr)uniTask;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rax_v1 (Cysharp.Threading.Tasks.UniTask`1<UnityEngine.Rendering.AsyncGPUReadbackRequest>)+10]");
		_ = 0;
		return (UniTask<AsyncGPUReadbackRequest>)asyncOperation;
	}

	public unsafe static UniTask<AsyncGPUReadbackRequest> WithCancellation(AsyncGPUReadbackRequest asyncOperation, CancellationToken cancellationToken, bool cancelImmediately)
	{
		//IL_0016: Expected O, but got I4
		//IL_0016: Expected O, but got Ref
		//IL_0027: Expected I, but got O
		//IL_0022: Expected native int or pointer, but got O
		object obj = default(object);
		object obj2 = default(object);
		UniTask<AsyncGPUReadbackRequest> uniTask = ToUniTask((AsyncGPUReadbackRequest)(&obj), (PlayerLoopTiming)(int)(&obj2), (CancellationToken)8, cancelImmediately);
		((AsyncGPUReadbackRequest*)(nint)asyncOperation)->m_Ptr = (IntPtr)uniTask;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ rax_v1 (Cysharp.Threading.Tasks.UniTask`1<UnityEngine.Rendering.AsyncGPUReadbackRequest>)+10]");
		_ = 0;
		return (UniTask<AsyncGPUReadbackRequest>)asyncOperation;
	}

	public unsafe static UniTask<AsyncGPUReadbackRequest> ToUniTask(AsyncGPUReadbackRequest asyncOperation, PlayerLoopTiming timing = PlayerLoopTiming.Update, CancellationToken cancellationToken = default(CancellationToken), bool cancelImmediately = false)
	{
		//IL_00c5: Expected O, but got I4
		//IL_0023: Expected O, but got I4
		//IL_0023: Expected I4, but got O
		//IL_0023: Expected O, but got Ref
		//IL_0030: Expected native int or pointer, but got O
		//IL_009f: Expected native int or pointer, but got O
		object obj = ((AsyncGPUReadbackRequest*)(int)timing)->IsDone();
		if (obj == null)
		{
			IntPtr intPtr = default(IntPtr);
			bool cancelImmediately2 = default(bool);
			ref short token = default(ref short);
			IUniTaskSource<AsyncGPUReadbackRequest> uniTaskSource = AsyncGPUReadbackRequestAwaiterConfiguredSource.Create((AsyncGPUReadbackRequest)(&intPtr), (PlayerLoopTiming)cancellationToken, (CancellationToken)cancelImmediately, cancelImmediately2, out token);
			((AsyncGPUReadbackRequest*)(nint)asyncOperation)->m_Ptr = (IntPtr)0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180710600");
		}
		else
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v6 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			((AsyncGPUReadbackRequest*)(nint)asyncOperation)->m_Ptr = (IntPtr)0;
		}
		return (UniTask<AsyncGPUReadbackRequest>)asyncOperation;
	}

	public unsafe static UniTask WithCancellation(AsyncOperation asyncOperation, CancellationToken cancellationToken)
	{
		//IL_0028: Expected native int or pointer, but got O
		UniTask uniTask = default(UniTask);
		CancellationToken cancellationToken2 = default(CancellationToken);
		bool cancelImmediately = default(bool);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, ToUniTask(asyncOperation, null, PlayerLoopTiming.Update, cancellationToken2, cancelImmediately).source);
		return uniTask;
	}

	public unsafe static UniTask WithCancellation(AsyncOperation asyncOperation, CancellationToken cancellationToken, bool cancelImmediately)
	{
		//IL_0028: Expected native int or pointer, but got O
		UniTask uniTask = default(UniTask);
		CancellationToken cancellationToken2 = default(CancellationToken);
		bool cancelImmediately2 = default(bool);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, ToUniTask(asyncOperation, null, PlayerLoopTiming.Update, cancellationToken2, cancelImmediately2).source);
		return uniTask;
	}

	public unsafe static UniTask ToUniTask(AsyncOperation asyncOperation, IProgress<float> progress = null, PlayerLoopTiming timing = PlayerLoopTiming.Update, CancellationToken cancellationToken = default(CancellationToken), bool cancelImmediately = false)
	{
		//IL_0122: Expected O, but got I4
		//IL_014b: Expected native int or pointer, but got O
		//IL_006b: Expected native int or pointer, but got O
		//IL_00c3: Expected native int or pointer, but got O
		//IL_00d4: Expected native int or pointer, but got O
		//IL_0075->IL010b: Incompatible stack heights: 0 vs 1
		while (asyncOperation == null)
		{
			Error.ThrowArgumentNullExceptionCore("asyncOperation");
		}
		CancellationToken cancellationToken2 = default(CancellationToken);
		UniTask uniTask = default(UniTask);
		if ((object)cancellationToken2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ stack_28 (System.Threading.CancellationToken)+20]");
			if ((nint)0 >= (nint)2)
			{
				System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, UniTask.FromCanceled(cancellationToken2).source);
				goto IL_010b;
			}
		}
		bool flag = asyncOperation.m_Ptr == (IntPtr)0;
		object obj = AsyncOperation.get_isDone_Injected(asyncOperation.m_Ptr);
		if (obj == null)
		{
			bool cancelImmediately2 = default(bool);
			ref short token = default(ref short);
			IUniTaskSource source = AsyncOperationConfiguredSource.Create(asyncOperation, timing, progress, cancellationToken2, cancelImmediately2, out token);
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
			short token2 = default(short);
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)uniTask, new UniTask(source, token2));
		}
		else
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, (IUniTaskSource)UniTask.CompletedTask);
		}
		goto IL_010b;
		IL_010b:
		return uniTask;
	}

	public unsafe static ResourceRequestAwaiter GetAwaiter(ResourceRequest asyncOperation)
	{
		//IL_000a: Expected native int or pointer, but got O
		//IL_0017: Expected native int or pointer, but got O
		if (asyncOperation != null)
		{
			ResourceRequestAwaiter resourceRequestAwaiter = default(ResourceRequestAwaiter);
			System.Runtime.CompilerServices.Unsafe.Write(&((ResourceRequestAwaiter*)(nint)resourceRequestAwaiter)->asyncOperation, null);
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)resourceRequestAwaiter, new ResourceRequestAwaiter(asyncOperation));
			return resourceRequestAwaiter;
		}
		Error.ThrowArgumentNullExceptionCore("asyncOperation");
		ResourceRequestAwaiter result = default(ResourceRequestAwaiter);
		return result;
	}

	public unsafe static UniTask<UnityEngine.Object> WithCancellation(ResourceRequest asyncOperation, CancellationToken cancellationToken)
	{
		//IL_001b: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		//IL_0039: Expected I, but got O
		object obj = default(object);
		bool cancelImmediately = default(bool);
		UniTask<UnityEngine.Object> uniTask = ToUniTask((ResourceRequest)(&obj), (IProgress<float>)cancellationToken, PlayerLoopTiming.Initialization, (CancellationToken)8, cancelImmediately);
		ResourceRequest resourceRequest = (ResourceRequest)uniTask;
		((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)uniTask.source;
		return (UniTask<UnityEngine.Object>)asyncOperation;
	}

	public unsafe static UniTask<UnityEngine.Object> WithCancellation(ResourceRequest asyncOperation, CancellationToken cancellationToken, bool cancelImmediately)
	{
		//IL_001b: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		//IL_0039: Expected I, but got O
		object obj = default(object);
		bool cancelImmediately2 = default(bool);
		UniTask<UnityEngine.Object> uniTask = ToUniTask((ResourceRequest)(&obj), (IProgress<float>)cancellationToken, PlayerLoopTiming.Initialization, (CancellationToken)8, cancelImmediately2);
		ResourceRequest resourceRequest = (ResourceRequest)uniTask;
		((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)uniTask.source;
		return (UniTask<UnityEngine.Object>)asyncOperation;
	}

	public unsafe static UniTask<UnityEngine.Object> ToUniTask(ResourceRequest asyncOperation, IProgress<float> progress = null, PlayerLoopTiming timing = PlayerLoopTiming.Update, CancellationToken cancellationToken = default(CancellationToken), bool cancelImmediately = false)
	{
		//IL_01a9: Expected O, but got I4
		//IL_00f2: Expected I, but got O
		//IL_005a: Expected O, but got Ref
		//IL_0154: Expected O, but got I4
		//IL_00c0: Expected O, but got I4
		//IL_00c0: Expected I4, but got O
		//IL_00cd: Expected O, but got I4
		//IL_0167->IL018f: Incompatible stack heights: 1 vs 0
		//IL_00ea->IL018f: Incompatible stack heights: 1 vs 0
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
				ResourceRequest resourceRequest = (ResourceRequest)uniTask2;
				IntPtr ptr = default(IntPtr);
				((AsyncOperation)asyncOperation).m_Ptr = ptr;
				goto IL_018f;
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
			IUniTaskSource<UnityEngine.Object> uniTaskSource = ResourceRequestConfiguredSource.Create((ResourceRequest)progress, (PlayerLoopTiming)cancellationToken, (IProgress<float>)timing, cancellationToken2, cancelImmediately2, out token);
			ResourceRequest resourceRequest = (ResourceRequest)0;
			((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4500");
		}
		else
		{
			nint num = (nint)progress;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v275 @ rdx_v7 (Il2CppClass<System.IProgress`1<System.Single>>)+178] (should have been resolved before IL gen)");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rcx_v14 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			object result = default(object);
			uniTask2 = new UniTask<object>(result);
			ResourceRequest resourceRequest = (ResourceRequest)0;
			((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)0;
		}
		goto IL_018f;
		IL_018f:
		return (UniTask<UnityEngine.Object>)asyncOperation;
	}

	public unsafe static AssetBundleRequestAwaiter GetAwaiter(AssetBundleRequest asyncOperation)
	{
		//IL_000a: Expected native int or pointer, but got O
		//IL_0017: Expected native int or pointer, but got O
		if (asyncOperation != null)
		{
			AssetBundleRequestAwaiter assetBundleRequestAwaiter = default(AssetBundleRequestAwaiter);
			System.Runtime.CompilerServices.Unsafe.Write(&((AssetBundleRequestAwaiter*)(nint)assetBundleRequestAwaiter)->asyncOperation, null);
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)assetBundleRequestAwaiter, new AssetBundleRequestAwaiter(asyncOperation));
			return assetBundleRequestAwaiter;
		}
		Error.ThrowArgumentNullExceptionCore("asyncOperation");
		AssetBundleRequestAwaiter result = default(AssetBundleRequestAwaiter);
		return result;
	}

	public unsafe static UniTask<UnityEngine.Object> WithCancellation(AssetBundleRequest asyncOperation, CancellationToken cancellationToken)
	{
		//IL_001b: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		//IL_0039: Expected I, but got O
		object obj = default(object);
		bool cancelImmediately = default(bool);
		UniTask<UnityEngine.Object> uniTask = ToUniTask((AssetBundleRequest)(&obj), (IProgress<float>)cancellationToken, PlayerLoopTiming.Initialization, (CancellationToken)8, cancelImmediately);
		AssetBundleRequest assetBundleRequest = (AssetBundleRequest)uniTask;
		((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)uniTask.source;
		return (UniTask<UnityEngine.Object>)asyncOperation;
	}

	public unsafe static UniTask<UnityEngine.Object> WithCancellation(AssetBundleRequest asyncOperation, CancellationToken cancellationToken, bool cancelImmediately)
	{
		//IL_001b: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		//IL_0039: Expected I, but got O
		object obj = default(object);
		bool cancelImmediately2 = default(bool);
		UniTask<UnityEngine.Object> uniTask = ToUniTask((AssetBundleRequest)(&obj), (IProgress<float>)cancellationToken, PlayerLoopTiming.Initialization, (CancellationToken)8, cancelImmediately2);
		AssetBundleRequest assetBundleRequest = (AssetBundleRequest)uniTask;
		((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)uniTask.source;
		return (UniTask<UnityEngine.Object>)asyncOperation;
	}

	public unsafe static UniTask<UnityEngine.Object> ToUniTask(AssetBundleRequest asyncOperation, IProgress<float> progress = null, PlayerLoopTiming timing = PlayerLoopTiming.Update, CancellationToken cancellationToken = default(CancellationToken), bool cancelImmediately = false)
	{
		//IL_01a9: Expected O, but got I4
		//IL_00f2: Expected I, but got O
		//IL_005a: Expected O, but got Ref
		//IL_0154: Expected O, but got I4
		//IL_00c0: Expected O, but got I4
		//IL_00c0: Expected I4, but got O
		//IL_00cd: Expected O, but got I4
		//IL_0167->IL018f: Incompatible stack heights: 1 vs 0
		//IL_00ea->IL018f: Incompatible stack heights: 1 vs 0
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
				AssetBundleRequest assetBundleRequest = (AssetBundleRequest)uniTask2;
				IntPtr ptr = default(IntPtr);
				((AsyncOperation)asyncOperation).m_Ptr = ptr;
				goto IL_018f;
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
			IUniTaskSource<UnityEngine.Object> uniTaskSource = AssetBundleRequestConfiguredSource.Create((AssetBundleRequest)progress, (PlayerLoopTiming)cancellationToken, (IProgress<float>)timing, cancellationToken2, cancelImmediately2, out token);
			AssetBundleRequest assetBundleRequest = (AssetBundleRequest)0;
			((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4500");
		}
		else
		{
			nint num = (nint)progress;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v275 @ rdx_v7 (Il2CppClass<System.IProgress`1<System.Single>>)+178] (should have been resolved before IL gen)");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rcx_v14 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			object result = default(object);
			uniTask2 = new UniTask<object>(result);
			AssetBundleRequest assetBundleRequest = (AssetBundleRequest)0;
			((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)0;
		}
		goto IL_018f;
		IL_018f:
		return (UniTask<UnityEngine.Object>)asyncOperation;
	}

	public unsafe static AssetBundleCreateRequestAwaiter GetAwaiter(AssetBundleCreateRequest asyncOperation)
	{
		//IL_000a: Expected native int or pointer, but got O
		//IL_0017: Expected native int or pointer, but got O
		if (asyncOperation != null)
		{
			AssetBundleCreateRequestAwaiter assetBundleCreateRequestAwaiter = default(AssetBundleCreateRequestAwaiter);
			System.Runtime.CompilerServices.Unsafe.Write(&((AssetBundleCreateRequestAwaiter*)(nint)assetBundleCreateRequestAwaiter)->asyncOperation, null);
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)assetBundleCreateRequestAwaiter, new AssetBundleCreateRequestAwaiter(asyncOperation));
			return assetBundleCreateRequestAwaiter;
		}
		Error.ThrowArgumentNullExceptionCore("asyncOperation");
		AssetBundleCreateRequestAwaiter result = default(AssetBundleCreateRequestAwaiter);
		return result;
	}

	public unsafe static UniTask<AssetBundle> WithCancellation(AssetBundleCreateRequest asyncOperation, CancellationToken cancellationToken)
	{
		//IL_001b: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		//IL_0039: Expected I, but got O
		object obj = default(object);
		bool cancelImmediately = default(bool);
		UniTask<AssetBundle> uniTask = ToUniTask((AssetBundleCreateRequest)(&obj), (IProgress<float>)cancellationToken, PlayerLoopTiming.Initialization, (CancellationToken)8, cancelImmediately);
		AssetBundleCreateRequest assetBundleCreateRequest = (AssetBundleCreateRequest)uniTask;
		((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)uniTask.source;
		return (UniTask<AssetBundle>)asyncOperation;
	}

	public unsafe static UniTask<AssetBundle> WithCancellation(AssetBundleCreateRequest asyncOperation, CancellationToken cancellationToken, bool cancelImmediately)
	{
		//IL_001b: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		//IL_0039: Expected I, but got O
		object obj = default(object);
		bool cancelImmediately2 = default(bool);
		UniTask<AssetBundle> uniTask = ToUniTask((AssetBundleCreateRequest)(&obj), (IProgress<float>)cancellationToken, PlayerLoopTiming.Initialization, (CancellationToken)8, cancelImmediately2);
		AssetBundleCreateRequest assetBundleCreateRequest = (AssetBundleCreateRequest)uniTask;
		((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)uniTask.source;
		return (UniTask<AssetBundle>)asyncOperation;
	}

	public unsafe static UniTask<AssetBundle> ToUniTask(AssetBundleCreateRequest asyncOperation, IProgress<float> progress = null, PlayerLoopTiming timing = PlayerLoopTiming.Update, CancellationToken cancellationToken = default(CancellationToken), bool cancelImmediately = false)
	{
		//IL_01b7: Expected O, but got I4
		//IL_005a: Expected O, but got Ref
		//IL_0162: Expected O, but got I4
		//IL_00c0: Expected O, but got I4
		//IL_00c0: Expected I4, but got O
		//IL_0175->IL019d: Incompatible stack heights: 1 vs 0
		//IL_00fd->IL019d: Incompatible stack heights: 1 vs 0
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
				AssetBundleCreateRequest assetBundleCreateRequest = (AssetBundleCreateRequest)uniTask2;
				IntPtr ptr = default(IntPtr);
				((AsyncOperation)asyncOperation).m_Ptr = ptr;
				goto IL_019d;
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
			IUniTaskSource<AssetBundle> uniTaskSource = AssetBundleCreateRequestConfiguredSource.Create((AssetBundleCreateRequest)progress, (PlayerLoopTiming)cancellationToken, (IProgress<float>)timing, cancellationToken2, cancelImmediately2, out token);
			_ = 0;
			((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)0;
			AssetBundleCreateRequest assetBundleCreateRequest = (AssetBundleCreateRequest)uniTaskSource;
			IntPtr ptr2 = default(IntPtr);
			((AsyncOperation)asyncOperation).m_Ptr = ptr2;
			_ = 0;
		}
		else
		{
			AssetBundle assetBundle = ((AssetBundleCreateRequest)progress).assetBundle;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rcx_v15 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			uniTask2 = new UniTask<object>(assetBundle);
			AssetBundleCreateRequest assetBundleCreateRequest = (AssetBundleCreateRequest)0;
			((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)0;
		}
		goto IL_019d;
		IL_019d:
		return (UniTask<AssetBundle>)asyncOperation;
	}

	public unsafe static UnityWebRequestAsyncOperationAwaiter GetAwaiter(UnityWebRequestAsyncOperation asyncOperation)
	{
		//IL_000a: Expected native int or pointer, but got O
		//IL_0017: Expected native int or pointer, but got O
		if (asyncOperation != null)
		{
			UnityWebRequestAsyncOperationAwaiter unityWebRequestAsyncOperationAwaiter = default(UnityWebRequestAsyncOperationAwaiter);
			System.Runtime.CompilerServices.Unsafe.Write(&((UnityWebRequestAsyncOperationAwaiter*)(nint)unityWebRequestAsyncOperationAwaiter)->asyncOperation, null);
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)unityWebRequestAsyncOperationAwaiter, new UnityWebRequestAsyncOperationAwaiter(asyncOperation));
			return unityWebRequestAsyncOperationAwaiter;
		}
		Error.ThrowArgumentNullExceptionCore("asyncOperation");
		UnityWebRequestAsyncOperationAwaiter result = default(UnityWebRequestAsyncOperationAwaiter);
		return result;
	}

	public unsafe static UniTask<UnityWebRequest> WithCancellation(UnityWebRequestAsyncOperation asyncOperation, CancellationToken cancellationToken)
	{
		//IL_001b: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		//IL_0039: Expected I, but got O
		object obj = default(object);
		bool cancelImmediately = default(bool);
		UniTask<UnityWebRequest> uniTask = ToUniTask((UnityWebRequestAsyncOperation)(&obj), (IProgress<float>)cancellationToken, PlayerLoopTiming.Initialization, (CancellationToken)8, cancelImmediately);
		UnityWebRequestAsyncOperation unityWebRequestAsyncOperation = (UnityWebRequestAsyncOperation)uniTask;
		((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)uniTask.source;
		return (UniTask<UnityWebRequest>)asyncOperation;
	}

	public unsafe static UniTask<UnityWebRequest> WithCancellation(UnityWebRequestAsyncOperation asyncOperation, CancellationToken cancellationToken, bool cancelImmediately)
	{
		//IL_001b: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		//IL_0039: Expected I, but got O
		object obj = default(object);
		bool cancelImmediately2 = default(bool);
		UniTask<UnityWebRequest> uniTask = ToUniTask((UnityWebRequestAsyncOperation)(&obj), (IProgress<float>)cancellationToken, PlayerLoopTiming.Initialization, (CancellationToken)8, cancelImmediately2);
		UnityWebRequestAsyncOperation unityWebRequestAsyncOperation = (UnityWebRequestAsyncOperation)uniTask;
		((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)uniTask.source;
		return (UniTask<UnityWebRequest>)asyncOperation;
	}

	public unsafe static UniTask<UnityWebRequest> ToUniTask(UnityWebRequestAsyncOperation asyncOperation, IProgress<float> progress = null, PlayerLoopTiming timing = PlayerLoopTiming.Update, CancellationToken cancellationToken = default(CancellationToken), bool cancelImmediately = false)
	{
		//IL_0214: Expected O, but got I4
		//IL_0116: Expected O, but got I
		//IL_0195: Expected O, but got I
		//IL_005a: Expected O, but got Ref
		//IL_00c8: Expected O, but got I4
		//IL_00c8: Expected I4, but got O
		//IL_01ad: Expected O, but got Ref
		//IL_01bf: Expected O, but got I4
		//IL_017f: Expected O, but got I
		//IL_0241->IL01fa: Incompatible stack heights: 1 vs 0
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
				UnityWebRequestAsyncOperation unityWebRequestAsyncOperation = (UnityWebRequestAsyncOperation)uniTask2;
				IntPtr ptr = default(IntPtr);
				((AsyncOperation)asyncOperation).m_Ptr = ptr;
				return (UniTask<UnityWebRequest>)asyncOperation;
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
			IUniTaskSource<UnityWebRequest> uniTaskSource = UnityWebRequestAsyncOperationConfiguredSource.Create((UnityWebRequestAsyncOperation)progress, (PlayerLoopTiming)cancellationToken, (IProgress<float>)timing, cancellationToken2, cancelImmediately2, out token);
			_ = 0;
			((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)0;
			UnityWebRequestAsyncOperation unityWebRequestAsyncOperation = (UnityWebRequestAsyncOperation)uniTaskSource;
			IntPtr ptr2 = default(IntPtr);
			((AsyncOperation)asyncOperation).m_Ptr = ptr2;
			_ = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [progress @ rdx (System.IProgress`1<System.Single>)+20]");
			if (!UnityWebRequestResultExtensions.IsError((UnityWebRequest)0))
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ rcx_v20 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [progress @ rdx (System.IProgress`1<System.Single>)+20]");
				uniTask2 = new UniTask<object>(0);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [progress @ rdx (System.IProgress`1<System.Single>)+20]");
				UnityWebRequestException ex = new UnityWebRequestException((UnityWebRequest)0);
				UniTask<object> uniTask3 = UniTask.FromException<object>((Exception)(&uniTask2));
			}
			UnityWebRequestAsyncOperation unityWebRequestAsyncOperation = (UnityWebRequestAsyncOperation)0;
			((AsyncOperation)asyncOperation).m_Ptr = (IntPtr)0;
		}
		return (UniTask<UnityWebRequest>)asyncOperation;
	}

	public unsafe static UniTask WaitAsync(JobHandle jobHandle, PlayerLoopTiming waitTiming, CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_002b: Expected native int or pointer, but got O
		_003CWaitAsync_003Ed__40 obj = default(_003CWaitAsync_003Ed__40);
		obj.MoveNext();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1832216A0");
		UniTask uniTask = default(UniTask);
		object source = default(object);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, source);
		return uniTask;
	}

	public unsafe static UniTask.Awaiter GetAwaiter(JobHandle jobHandle)
	{
		//IL_0017: Expected O, but got I8
		//IL_0096: Expected native int or pointer, but got O
		JobHandlePromise jobHandlePromise = new JobHandlePromise();
		if (jobHandlePromise != null)
		{
			jobHandlePromise.jobHandle = (JobHandle)jobHandle.jobGroup;
			PlayerLoopHelper.AddAction(PlayerLoopTiming.EarlyUpdate, jobHandlePromise);
			PlayerLoopHelper.AddAction(PlayerLoopTiming.PreUpdate, jobHandlePromise);
			PlayerLoopHelper.AddAction(PlayerLoopTiming.Update, jobHandlePromise);
			PlayerLoopHelper.AddAction(PlayerLoopTiming.PreLateUpdate, jobHandlePromise);
			PlayerLoopHelper.AddAction(PlayerLoopTiming.PostLateUpdate, jobHandlePromise);
			UniTask.Awaiter awaiter = default(UniTask.Awaiter);
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask.Awaiter*)(nint)awaiter)->task, (UniTask)jobHandlePromise);
			return awaiter;
		}
		return (UniTask.Awaiter)new NullReferenceException();
	}

	public unsafe static UniTask ToUniTask(JobHandle jobHandle, PlayerLoopTiming waitTiming)
	{
		//IL_0017: Expected O, but got I8
		//IL_0032: Expected native int or pointer, but got O
		//IL_003f: Expected native int or pointer, but got O
		//IL_0059: Expected native int or pointer, but got O
		JobHandlePromise jobHandlePromise = new JobHandlePromise();
		if (jobHandlePromise != null)
		{
			jobHandlePromise.jobHandle = (JobHandle)jobHandle.jobGroup;
			PlayerLoopHelper.AddAction(waitTiming, jobHandlePromise);
			UniTask uniTask = default(UniTask);
			((UniTask*)(nint)uniTask)->token = 0;
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, jobHandlePromise);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v3 (Cysharp.Threading.Tasks.UnityAsyncExtensions+JobHandlePromise)+30]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new NullReferenceException();
	}

	public unsafe static UniTask StartAsyncCoroutine(MonoBehaviour monoBehaviour, Func<CancellationToken, UniTask> asyncCoroutine)
	{
		//IL_0059: Expected native int or pointer, but got O
		if ((object)monoBehaviour != null)
		{
			CancellationToken destroyCancellationToken = monoBehaviour.destroyCancellationToken;
			if (asyncCoroutine != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [asyncCoroutine @ r8 (System.Func`2<System.Threading.CancellationToken, Cysharp.Threading.Tasks.UniTask>)+18] (should have been resolved before IL gen)");
				UniTask uniTask = default(UniTask);
				object source = default(object);
				System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, source);
				return uniTask;
			}
		}
		return (UniTask)new NullReferenceException();
	}

	public static AsyncUnityEventHandler GetAsyncEventHandler(UnityEvent unityEvent, CancellationToken cancellationToken)
	{
		return new AsyncUnityEventHandler(unityEvent, cancellationToken, callOnce: false);
	}

	public unsafe static UniTask OnInvokeAsync(UnityEvent unityEvent, CancellationToken cancellationToken)
	{
		//IL_001f: Expected native int or pointer, but got O
		AsyncUnityEventHandler asyncUnityEventHandler = new AsyncUnityEventHandler(unityEvent, cancellationToken, callOnce: true);
		if (asyncUnityEventHandler != null)
		{
			UniTask uniTask = default(UniTask);
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, asyncUnityEventHandler.OnInvokeAsync().source);
			return uniTask;
		}
		return (UniTask)new NullReferenceException();
	}

	public static IUniTaskAsyncEnumerable<AsyncUnit> OnInvokeAsAsyncEnumerable(UnityEvent unityEvent, CancellationToken cancellationToken)
	{
		return new UnityEventHandlerAsyncEnumerable(unityEvent, cancellationToken);
	}

	public static AsyncUnityEventHandler<T> GetAsyncEventHandler<T>(UnityEvent<T> unityEvent, CancellationToken cancellationToken)
	{
		AsyncUnityEventHandler<T> result = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v57 @ r10_v1 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
		return result;
	}

	public unsafe static UniTask<T> OnInvokeAsync<T>(UnityEvent<T> unityEvent, CancellationToken cancellationToken)
	{
		//IL_0008: Expected O, but got Ref
		//IL_006e: Expected O, but got I
		//IL_007e: Expected O, but got I
		//IL_0094: Expected O, but got I
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		//IL_0198: Expected O, but got I
		//IL_00df: Expected O, but got I
		//IL_00ef: Expected O, but got I
		//IL_00c5: Expected O, but got I8
		//IL_0126: Expected O, but got I
		//IL_0134: Expected O, but got Ref
		//IL_0149: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r9 (UnityEngine.Events.UnityEvent`1<T>)+38]");
		bool flag = (nint)0 != 0;
		UnityEvent<T> unityEvent2 = unityEvent;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			UnityEvent<T> unityEvent3 = default(UnityEvent<T>);
			unityEvent2 = unityEvent3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r9 (UnityEngine.Events.UnityEvent`1<T>)+38]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2+20]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v1+FC]");
		object obj5 = (nint)0 + (nint)15;
		object obj6 = obj5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v1+FC]");
		if ((nint)obj6 <= 0)
		{
			obj5 = 1152921504606846960L;
		}
		object obj7 = obj5 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r9 (UnityEngine.Events.UnityEvent`1<T>)+38]");
		object obj8 = 0;
		object obj9 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r9 (UnityEngine.Events.UnityEvent`1<T>)+38]");
		object obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rcx_v4+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v89 @ r10_v1] (should have been resolved before IL gen)");
		if (obj9 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r9 (UnityEngine.Events.UnityEvent`1<T>)+38]");
			object obj12 = 0;
			object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
			_ = ref obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rcx_v6+18]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v107 @ r10_v2+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			UniTask<T> result = default(UniTask<T>);
			return result;
		}
		return (UniTask<T>)new NullReferenceException();
	}

	public static IUniTaskAsyncEnumerable<T> OnInvokeAsAsyncEnumerable<T>(UnityEvent<T> unityEvent, CancellationToken cancellationToken)
	{
		IUniTaskAsyncEnumerable<T> result = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v56 @ r10_v1 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
		return result;
	}

	public static IAsyncClickEventHandler GetAsyncClickEventHandler(Button button)
	{
		if ((object)button != null)
		{
			CancellationToken destroyCancellationToken = button.destroyCancellationToken;
			return new AsyncUnityEventHandler(button.m_OnClick, destroyCancellationToken, callOnce: false);
		}
		return (IAsyncClickEventHandler)new NullReferenceException();
	}

	public static IAsyncClickEventHandler GetAsyncClickEventHandler(Button button, CancellationToken cancellationToken)
	{
		if ((object)button != null)
		{
			return new AsyncUnityEventHandler(button.m_OnClick, cancellationToken, callOnce: false);
		}
		return (IAsyncClickEventHandler)new NullReferenceException();
	}

	public unsafe static UniTask OnClickAsync(Button button)
	{
		//IL_006a: Expected native int or pointer, but got O
		if ((object)button != null)
		{
			CancellationToken destroyCancellationToken = button.destroyCancellationToken;
			AsyncUnityEventHandler asyncUnityEventHandler = new AsyncUnityEventHandler(button.m_OnClick, destroyCancellationToken, callOnce: true);
			if (asyncUnityEventHandler != null)
			{
				UniTask uniTask = default(UniTask);
				System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, asyncUnityEventHandler.OnInvokeAsync().source);
				return uniTask;
			}
		}
		return (UniTask)new NullReferenceException();
	}

	public unsafe static UniTask OnClickAsync(Button button, CancellationToken cancellationToken)
	{
		//IL_005d: Expected native int or pointer, but got O
		if ((object)button != null)
		{
			AsyncUnityEventHandler asyncUnityEventHandler = new AsyncUnityEventHandler(button.m_OnClick, cancellationToken, callOnce: true);
			if (asyncUnityEventHandler != null)
			{
				UniTask uniTask = default(UniTask);
				System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, asyncUnityEventHandler.OnInvokeAsync().source);
				return uniTask;
			}
		}
		return (UniTask)new NullReferenceException();
	}

	public static IUniTaskAsyncEnumerable<AsyncUnit> OnClickAsAsyncEnumerable(Button button)
	{
		if ((object)button != null)
		{
			CancellationToken destroyCancellationToken = button.destroyCancellationToken;
			return new UnityEventHandlerAsyncEnumerable(button.m_OnClick, destroyCancellationToken);
		}
		return (IUniTaskAsyncEnumerable<AsyncUnit>)new NullReferenceException();
	}

	public static IUniTaskAsyncEnumerable<AsyncUnit> OnClickAsAsyncEnumerable(Button button, CancellationToken cancellationToken)
	{
		if ((object)button != null)
		{
			return new UnityEventHandlerAsyncEnumerable(button.m_OnClick, cancellationToken);
		}
		return (IUniTaskAsyncEnumerable<AsyncUnit>)new NullReferenceException();
	}

	public static IAsyncValueChangedEventHandler<bool> GetAsyncValueChangedEventHandler(Toggle toggle)
	{
		if ((object)toggle != null)
		{
			CancellationToken destroyCancellationToken = toggle.destroyCancellationToken;
			return new AsyncUnityEventHandler<bool>(toggle.onValueChanged, destroyCancellationToken, callOnce: false);
		}
		return (IAsyncValueChangedEventHandler<bool>)new NullReferenceException();
	}

	public static IAsyncValueChangedEventHandler<bool> GetAsyncValueChangedEventHandler(Toggle toggle, CancellationToken cancellationToken)
	{
		if ((object)toggle != null)
		{
			return new AsyncUnityEventHandler<bool>(toggle.onValueChanged, cancellationToken, callOnce: false);
		}
		return (IAsyncValueChangedEventHandler<bool>)new NullReferenceException();
	}

	public static UniTask<bool> OnValueChangedAsync(Toggle toggle)
	{
		//IL_000e: Expected O, but got I
		//IL_002c: Expected O, but got I
		IntPtr intPtr = default(IntPtr);
		if (intPtr != (IntPtr)0)
		{
			CancellationToken destroyCancellationToken = ((MonoBehaviour)(nint)intPtr).destroyCancellationToken;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+118]");
			AsyncUnityEventHandler<bool> asyncUnityEventHandler = new AsyncUnityEventHandler<bool>((UnityEvent<bool>)0, destroyCancellationToken, callOnce: true);
			if (asyncUnityEventHandler != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D1F80");
				object obj = default(object);
				Toggle toggle2 = (Toggle)obj;
				return (UniTask<bool>)toggle;
			}
		}
		return (UniTask<bool>)new NullReferenceException();
	}

	public static UniTask<bool> OnValueChangedAsync(Toggle toggle, CancellationToken cancellationToken)
	{
		//IL_001f: Expected O, but got I
		//IL_001f: Expected O, but got I
		if ((object)cancellationToken != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ rdx (System.Threading.CancellationToken)+118]");
			IntPtr intPtr = default(IntPtr);
			AsyncUnityEventHandler<bool> asyncUnityEventHandler = new AsyncUnityEventHandler<bool>((UnityEvent<bool>)0, (CancellationToken)(nint)intPtr, callOnce: true);
			if (asyncUnityEventHandler != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D1F80");
				object obj = default(object);
				Toggle toggle2 = (Toggle)obj;
				return (UniTask<bool>)toggle;
			}
		}
		return (UniTask<bool>)new NullReferenceException();
	}

	public static IUniTaskAsyncEnumerable<bool> OnValueChangedAsAsyncEnumerable(Toggle toggle)
	{
		if ((object)toggle != null)
		{
			CancellationToken destroyCancellationToken = toggle.destroyCancellationToken;
			UnityEventHandlerAsyncEnumerable<bool> result = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4560");
			return result;
		}
		return (IUniTaskAsyncEnumerable<bool>)new NullReferenceException();
	}

	public static IUniTaskAsyncEnumerable<bool> OnValueChangedAsAsyncEnumerable(Toggle toggle, CancellationToken cancellationToken)
	{
		if ((object)toggle != null)
		{
			UnityEventHandlerAsyncEnumerable<bool> result = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4560");
			return result;
		}
		return (IUniTaskAsyncEnumerable<bool>)new NullReferenceException();
	}

	public static IAsyncValueChangedEventHandler<float> GetAsyncValueChangedEventHandler(Scrollbar scrollbar)
	{
		if ((object)scrollbar != null)
		{
			CancellationToken destroyCancellationToken = scrollbar.destroyCancellationToken;
			return new AsyncUnityEventHandler<float>(scrollbar.m_OnValueChanged, destroyCancellationToken, callOnce: false);
		}
		return (IAsyncValueChangedEventHandler<float>)new NullReferenceException();
	}

	public static IAsyncValueChangedEventHandler<float> GetAsyncValueChangedEventHandler(Scrollbar scrollbar, CancellationToken cancellationToken)
	{
		if ((object)scrollbar != null)
		{
			return new AsyncUnityEventHandler<float>(scrollbar.m_OnValueChanged, cancellationToken, callOnce: false);
		}
		return (IAsyncValueChangedEventHandler<float>)new NullReferenceException();
	}

	public static UniTask<float> OnValueChangedAsync(Scrollbar scrollbar)
	{
		//IL_000e: Expected O, but got I
		//IL_002c: Expected O, but got I
		IntPtr intPtr = default(IntPtr);
		if (intPtr != (IntPtr)0)
		{
			CancellationToken destroyCancellationToken = ((MonoBehaviour)(nint)intPtr).destroyCancellationToken;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+118]");
			AsyncUnityEventHandler<float> asyncUnityEventHandler = new AsyncUnityEventHandler<float>((UnityEvent<float>)0, destroyCancellationToken, callOnce: true);
			if (asyncUnityEventHandler != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D23A0");
				object obj = default(object);
				Scrollbar scrollbar2 = (Scrollbar)obj;
				return (UniTask<float>)scrollbar;
			}
		}
		return (UniTask<float>)new NullReferenceException();
	}

	public static UniTask<float> OnValueChangedAsync(Scrollbar scrollbar, CancellationToken cancellationToken)
	{
		//IL_001f: Expected O, but got I
		//IL_001f: Expected O, but got I
		if ((object)cancellationToken != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ rdx (System.Threading.CancellationToken)+118]");
			IntPtr intPtr = default(IntPtr);
			AsyncUnityEventHandler<float> asyncUnityEventHandler = new AsyncUnityEventHandler<float>((UnityEvent<float>)0, (CancellationToken)(nint)intPtr, callOnce: true);
			if (asyncUnityEventHandler != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D23A0");
				object obj = default(object);
				Scrollbar scrollbar2 = (Scrollbar)obj;
				return (UniTask<float>)scrollbar;
			}
		}
		return (UniTask<float>)new NullReferenceException();
	}

	public static IUniTaskAsyncEnumerable<float> OnValueChangedAsAsyncEnumerable(Scrollbar scrollbar)
	{
		if ((object)scrollbar != null)
		{
			CancellationToken destroyCancellationToken = scrollbar.destroyCancellationToken;
			UnityEventHandlerAsyncEnumerable<float> result = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4560");
			return result;
		}
		return (IUniTaskAsyncEnumerable<float>)new NullReferenceException();
	}

	public static IUniTaskAsyncEnumerable<float> OnValueChangedAsAsyncEnumerable(Scrollbar scrollbar, CancellationToken cancellationToken)
	{
		if ((object)scrollbar != null)
		{
			UnityEventHandlerAsyncEnumerable<float> result = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4560");
			return result;
		}
		return (IUniTaskAsyncEnumerable<float>)new NullReferenceException();
	}

	public static IAsyncValueChangedEventHandler<Vector2> GetAsyncValueChangedEventHandler(ScrollRect scrollRect)
	{
		if ((object)scrollRect != null)
		{
			CancellationToken destroyCancellationToken = scrollRect.destroyCancellationToken;
			return new AsyncUnityEventHandler<Vector2>(scrollRect.m_OnValueChanged, destroyCancellationToken, callOnce: false);
		}
		return (IAsyncValueChangedEventHandler<Vector2>)new NullReferenceException();
	}

	public static IAsyncValueChangedEventHandler<Vector2> GetAsyncValueChangedEventHandler(ScrollRect scrollRect, CancellationToken cancellationToken)
	{
		if ((object)scrollRect != null)
		{
			return new AsyncUnityEventHandler<Vector2>(scrollRect.m_OnValueChanged, cancellationToken, callOnce: false);
		}
		return (IAsyncValueChangedEventHandler<Vector2>)new NullReferenceException();
	}

	public static UniTask<Vector2> OnValueChangedAsync(ScrollRect scrollRect)
	{
		//IL_000e: Expected O, but got I
		//IL_002c: Expected O, but got I
		IntPtr intPtr = default(IntPtr);
		if (intPtr != (IntPtr)0)
		{
			CancellationToken destroyCancellationToken = ((MonoBehaviour)(nint)intPtr).destroyCancellationToken;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+68]");
			AsyncUnityEventHandler<Vector2> asyncUnityEventHandler = new AsyncUnityEventHandler<Vector2>((UnityEvent<Vector2>)0, destroyCancellationToken, callOnce: true);
			if (asyncUnityEventHandler != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D2530");
				object obj = default(object);
				ScrollRect scrollRect2 = (ScrollRect)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rax_v7+10]");
				((UnityEngine.Object)scrollRect).m_CachedPtr = (IntPtr)0;
				return (UniTask<Vector2>)scrollRect;
			}
		}
		return (UniTask<Vector2>)new NullReferenceException();
	}

	public static UniTask<Vector2> OnValueChangedAsync(ScrollRect scrollRect, CancellationToken cancellationToken)
	{
		//IL_001f: Expected O, but got I
		//IL_001f: Expected O, but got I
		if ((object)cancellationToken != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ rdx (System.Threading.CancellationToken)+68]");
			IntPtr intPtr = default(IntPtr);
			AsyncUnityEventHandler<Vector2> asyncUnityEventHandler = new AsyncUnityEventHandler<Vector2>((UnityEvent<Vector2>)0, (CancellationToken)(nint)intPtr, callOnce: true);
			if (asyncUnityEventHandler != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D2530");
				object obj = default(object);
				ScrollRect scrollRect2 = (ScrollRect)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v6+10]");
				((UnityEngine.Object)scrollRect).m_CachedPtr = (IntPtr)0;
				return (UniTask<Vector2>)scrollRect;
			}
		}
		return (UniTask<Vector2>)new NullReferenceException();
	}

	public static IUniTaskAsyncEnumerable<Vector2> OnValueChangedAsAsyncEnumerable(ScrollRect scrollRect)
	{
		if ((object)scrollRect != null)
		{
			CancellationToken destroyCancellationToken = scrollRect.destroyCancellationToken;
			UnityEventHandlerAsyncEnumerable<Vector2> result = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4560");
			return result;
		}
		return (IUniTaskAsyncEnumerable<Vector2>)new NullReferenceException();
	}

	public static IUniTaskAsyncEnumerable<Vector2> OnValueChangedAsAsyncEnumerable(ScrollRect scrollRect, CancellationToken cancellationToken)
	{
		if ((object)scrollRect != null)
		{
			UnityEventHandlerAsyncEnumerable<Vector2> result = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4560");
			return result;
		}
		return (IUniTaskAsyncEnumerable<Vector2>)new NullReferenceException();
	}

	public static IAsyncValueChangedEventHandler<float> GetAsyncValueChangedEventHandler(Slider slider)
	{
		if ((object)slider != null)
		{
			CancellationToken destroyCancellationToken = slider.destroyCancellationToken;
			return new AsyncUnityEventHandler<float>(slider.m_OnValueChanged, destroyCancellationToken, callOnce: false);
		}
		return (IAsyncValueChangedEventHandler<float>)new NullReferenceException();
	}

	public static IAsyncValueChangedEventHandler<float> GetAsyncValueChangedEventHandler(Slider slider, CancellationToken cancellationToken)
	{
		if ((object)slider != null)
		{
			return new AsyncUnityEventHandler<float>(slider.m_OnValueChanged, cancellationToken, callOnce: false);
		}
		return (IAsyncValueChangedEventHandler<float>)new NullReferenceException();
	}

	public static UniTask<float> OnValueChangedAsync(Slider slider)
	{
		//IL_000e: Expected O, but got I
		//IL_002c: Expected O, but got I
		IntPtr intPtr = default(IntPtr);
		if (intPtr != (IntPtr)0)
		{
			CancellationToken destroyCancellationToken = ((MonoBehaviour)(nint)intPtr).destroyCancellationToken;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+128]");
			AsyncUnityEventHandler<float> asyncUnityEventHandler = new AsyncUnityEventHandler<float>((UnityEvent<float>)0, destroyCancellationToken, callOnce: true);
			if (asyncUnityEventHandler != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D23A0");
				object obj = default(object);
				Slider slider2 = (Slider)obj;
				return (UniTask<float>)slider;
			}
		}
		return (UniTask<float>)new NullReferenceException();
	}

	public static UniTask<float> OnValueChangedAsync(Slider slider, CancellationToken cancellationToken)
	{
		//IL_001f: Expected O, but got I
		//IL_001f: Expected O, but got I
		if ((object)cancellationToken != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ rdx (System.Threading.CancellationToken)+128]");
			IntPtr intPtr = default(IntPtr);
			AsyncUnityEventHandler<float> asyncUnityEventHandler = new AsyncUnityEventHandler<float>((UnityEvent<float>)0, (CancellationToken)(nint)intPtr, callOnce: true);
			if (asyncUnityEventHandler != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D23A0");
				object obj = default(object);
				Slider slider2 = (Slider)obj;
				return (UniTask<float>)slider;
			}
		}
		return (UniTask<float>)new NullReferenceException();
	}

	public static IUniTaskAsyncEnumerable<float> OnValueChangedAsAsyncEnumerable(Slider slider)
	{
		if ((object)slider != null)
		{
			CancellationToken destroyCancellationToken = slider.destroyCancellationToken;
			UnityEventHandlerAsyncEnumerable<float> result = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4560");
			return result;
		}
		return (IUniTaskAsyncEnumerable<float>)new NullReferenceException();
	}

	public static IUniTaskAsyncEnumerable<float> OnValueChangedAsAsyncEnumerable(Slider slider, CancellationToken cancellationToken)
	{
		if ((object)slider != null)
		{
			UnityEventHandlerAsyncEnumerable<float> result = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4560");
			return result;
		}
		return (IUniTaskAsyncEnumerable<float>)new NullReferenceException();
	}

	public static IAsyncEndEditEventHandler<string> GetAsyncEndEditEventHandler(InputField inputField)
	{
		if ((object)inputField != null)
		{
			CancellationToken destroyCancellationToken = inputField.destroyCancellationToken;
			return (IAsyncEndEditEventHandler<string>)new AsyncUnityEventHandler<object>((UnityEvent<object>)(object)inputField.m_OnDidEndEdit, destroyCancellationToken, callOnce: false);
		}
		return (IAsyncEndEditEventHandler<string>)new NullReferenceException();
	}

	public static IAsyncEndEditEventHandler<string> GetAsyncEndEditEventHandler(InputField inputField, CancellationToken cancellationToken)
	{
		if ((object)inputField != null)
		{
			return (IAsyncEndEditEventHandler<string>)new AsyncUnityEventHandler<object>((UnityEvent<object>)(object)inputField.m_OnDidEndEdit, cancellationToken, callOnce: false);
		}
		return (IAsyncEndEditEventHandler<string>)new NullReferenceException();
	}

	public unsafe static UniTask<string> OnEndEditAsync(InputField inputField)
	{
		//IL_000e: Expected O, but got I
		//IL_002c: Expected O, but got I
		//IL_005c: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		if (intPtr != (IntPtr)0)
		{
			CancellationToken destroyCancellationToken = ((MonoBehaviour)(nint)intPtr).destroyCancellationToken;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+140]");
			AsyncUnityEventHandler<string> asyncUnityEventHandler = (AsyncUnityEventHandler<string>)(object)new AsyncUnityEventHandler<object>((UnityEvent<object>)0, destroyCancellationToken, callOnce: true);
			if (asyncUnityEventHandler != null)
			{
				object obj = default(object);
				UniTask<object> uniTask = ((AsyncUnityEventHandler<object>)(&obj)).OnInvokeAsync();
				InputField inputField2 = (InputField)obj;
				IntPtr cachedPtr = default(IntPtr);
				((UnityEngine.Object)inputField).m_CachedPtr = cachedPtr;
				return (UniTask<string>)inputField;
			}
		}
		return (UniTask<string>)new NullReferenceException();
	}

	public unsafe static UniTask<string> OnEndEditAsync(InputField inputField, CancellationToken cancellationToken)
	{
		//IL_001f: Expected O, but got I
		//IL_001f: Expected O, but got I
		//IL_004f: Expected O, but got Ref
		if ((object)cancellationToken != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ rdx (System.Threading.CancellationToken)+140]");
			IntPtr intPtr = default(IntPtr);
			AsyncUnityEventHandler<string> asyncUnityEventHandler = (AsyncUnityEventHandler<string>)(object)new AsyncUnityEventHandler<object>((UnityEvent<object>)0, (CancellationToken)(nint)intPtr, callOnce: true);
			if (asyncUnityEventHandler != null)
			{
				object obj = default(object);
				UniTask<object> uniTask = ((AsyncUnityEventHandler<object>)(&obj)).OnInvokeAsync();
				InputField inputField2 = (InputField)obj;
				IntPtr cachedPtr = default(IntPtr);
				((UnityEngine.Object)inputField).m_CachedPtr = cachedPtr;
				return (UniTask<string>)inputField;
			}
		}
		return (UniTask<string>)new NullReferenceException();
	}

	public static IUniTaskAsyncEnumerable<string> OnEndEditAsAsyncEnumerable(InputField inputField)
	{
		if ((object)inputField != null)
		{
			CancellationToken destroyCancellationToken = inputField.destroyCancellationToken;
			UnityEventHandlerAsyncEnumerable<string> result = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4560");
			return result;
		}
		return (IUniTaskAsyncEnumerable<string>)new NullReferenceException();
	}

	public static IUniTaskAsyncEnumerable<string> OnEndEditAsAsyncEnumerable(InputField inputField, CancellationToken cancellationToken)
	{
		if ((object)inputField != null)
		{
			UnityEventHandlerAsyncEnumerable<string> result = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4560");
			return result;
		}
		return (IUniTaskAsyncEnumerable<string>)new NullReferenceException();
	}

	public static IAsyncValueChangedEventHandler<string> GetAsyncValueChangedEventHandler(InputField inputField)
	{
		if ((object)inputField != null)
		{
			CancellationToken destroyCancellationToken = inputField.destroyCancellationToken;
			return (IAsyncValueChangedEventHandler<string>)new AsyncUnityEventHandler<object>((UnityEvent<object>)(object)inputField.m_OnValueChanged, destroyCancellationToken, callOnce: false);
		}
		return (IAsyncValueChangedEventHandler<string>)new NullReferenceException();
	}

	public static IAsyncValueChangedEventHandler<string> GetAsyncValueChangedEventHandler(InputField inputField, CancellationToken cancellationToken)
	{
		if ((object)inputField != null)
		{
			return (IAsyncValueChangedEventHandler<string>)new AsyncUnityEventHandler<object>((UnityEvent<object>)(object)inputField.m_OnValueChanged, cancellationToken, callOnce: false);
		}
		return (IAsyncValueChangedEventHandler<string>)new NullReferenceException();
	}

	public unsafe static UniTask<string> OnValueChangedAsync(InputField inputField)
	{
		//IL_000e: Expected O, but got I
		//IL_002c: Expected O, but got I
		//IL_005c: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		if (intPtr != (IntPtr)0)
		{
			CancellationToken destroyCancellationToken = ((MonoBehaviour)(nint)intPtr).destroyCancellationToken;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+148]");
			AsyncUnityEventHandler<string> asyncUnityEventHandler = (AsyncUnityEventHandler<string>)(object)new AsyncUnityEventHandler<object>((UnityEvent<object>)0, destroyCancellationToken, callOnce: true);
			if (asyncUnityEventHandler != null)
			{
				object obj = default(object);
				UniTask<object> uniTask = ((AsyncUnityEventHandler<object>)(&obj)).OnInvokeAsync();
				InputField inputField2 = (InputField)obj;
				IntPtr cachedPtr = default(IntPtr);
				((UnityEngine.Object)inputField).m_CachedPtr = cachedPtr;
				return (UniTask<string>)inputField;
			}
		}
		return (UniTask<string>)new NullReferenceException();
	}

	public unsafe static UniTask<string> OnValueChangedAsync(InputField inputField, CancellationToken cancellationToken)
	{
		//IL_001f: Expected O, but got I
		//IL_001f: Expected O, but got I
		//IL_004f: Expected O, but got Ref
		if ((object)cancellationToken != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ rdx (System.Threading.CancellationToken)+148]");
			IntPtr intPtr = default(IntPtr);
			AsyncUnityEventHandler<string> asyncUnityEventHandler = (AsyncUnityEventHandler<string>)(object)new AsyncUnityEventHandler<object>((UnityEvent<object>)0, (CancellationToken)(nint)intPtr, callOnce: true);
			if (asyncUnityEventHandler != null)
			{
				object obj = default(object);
				UniTask<object> uniTask = ((AsyncUnityEventHandler<object>)(&obj)).OnInvokeAsync();
				InputField inputField2 = (InputField)obj;
				IntPtr cachedPtr = default(IntPtr);
				((UnityEngine.Object)inputField).m_CachedPtr = cachedPtr;
				return (UniTask<string>)inputField;
			}
		}
		return (UniTask<string>)new NullReferenceException();
	}

	public static IUniTaskAsyncEnumerable<string> OnValueChangedAsAsyncEnumerable(InputField inputField)
	{
		if ((object)inputField != null)
		{
			CancellationToken destroyCancellationToken = inputField.destroyCancellationToken;
			UnityEventHandlerAsyncEnumerable<string> result = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4560");
			return result;
		}
		return (IUniTaskAsyncEnumerable<string>)new NullReferenceException();
	}

	public static IUniTaskAsyncEnumerable<string> OnValueChangedAsAsyncEnumerable(InputField inputField, CancellationToken cancellationToken)
	{
		if ((object)inputField != null)
		{
			UnityEventHandlerAsyncEnumerable<string> result = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4560");
			return result;
		}
		return (IUniTaskAsyncEnumerable<string>)new NullReferenceException();
	}

	public static IAsyncValueChangedEventHandler<int> GetAsyncValueChangedEventHandler(Dropdown dropdown)
	{
		if ((object)dropdown != null)
		{
			CancellationToken destroyCancellationToken = dropdown.destroyCancellationToken;
			return new AsyncUnityEventHandler<int>(dropdown.m_OnValueChanged, destroyCancellationToken, callOnce: false);
		}
		return (IAsyncValueChangedEventHandler<int>)new NullReferenceException();
	}

	public static IAsyncValueChangedEventHandler<int> GetAsyncValueChangedEventHandler(Dropdown dropdown, CancellationToken cancellationToken)
	{
		if ((object)dropdown != null)
		{
			return new AsyncUnityEventHandler<int>(dropdown.m_OnValueChanged, cancellationToken, callOnce: false);
		}
		return (IAsyncValueChangedEventHandler<int>)new NullReferenceException();
	}

	public static UniTask<int> OnValueChangedAsync(Dropdown dropdown)
	{
		//IL_000e: Expected O, but got I
		//IL_002c: Expected O, but got I
		IntPtr intPtr = default(IntPtr);
		if (intPtr != (IntPtr)0)
		{
			CancellationToken destroyCancellationToken = ((MonoBehaviour)(nint)intPtr).destroyCancellationToken;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+138]");
			AsyncUnityEventHandler<int> asyncUnityEventHandler = new AsyncUnityEventHandler<int>((UnityEvent<int>)0, destroyCancellationToken, callOnce: true);
			if (asyncUnityEventHandler != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D2110");
				object obj = default(object);
				Dropdown dropdown2 = (Dropdown)obj;
				return (UniTask<int>)dropdown;
			}
		}
		return (UniTask<int>)new NullReferenceException();
	}

	public static UniTask<int> OnValueChangedAsync(Dropdown dropdown, CancellationToken cancellationToken)
	{
		//IL_001f: Expected O, but got I
		//IL_001f: Expected O, but got I
		if ((object)cancellationToken != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ rdx (System.Threading.CancellationToken)+138]");
			IntPtr intPtr = default(IntPtr);
			AsyncUnityEventHandler<int> asyncUnityEventHandler = new AsyncUnityEventHandler<int>((UnityEvent<int>)0, (CancellationToken)(nint)intPtr, callOnce: true);
			if (asyncUnityEventHandler != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D2110");
				object obj = default(object);
				Dropdown dropdown2 = (Dropdown)obj;
				return (UniTask<int>)dropdown;
			}
		}
		return (UniTask<int>)new NullReferenceException();
	}

	public static IUniTaskAsyncEnumerable<int> OnValueChangedAsAsyncEnumerable(Dropdown dropdown)
	{
		if ((object)dropdown != null)
		{
			CancellationToken destroyCancellationToken = dropdown.destroyCancellationToken;
			UnityEventHandlerAsyncEnumerable<int> result = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4560");
			return result;
		}
		return (IUniTaskAsyncEnumerable<int>)new NullReferenceException();
	}

	public static IUniTaskAsyncEnumerable<int> OnValueChangedAsAsyncEnumerable(Dropdown dropdown, CancellationToken cancellationToken)
	{
		if ((object)dropdown != null)
		{
			UnityEventHandlerAsyncEnumerable<int> result = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4560");
			return result;
		}
		return (IUniTaskAsyncEnumerable<int>)new NullReferenceException();
	}
}
