using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks.Sources;
using Cpp2ILInjected;
using Cysharp.Threading.Tasks.Internal;
using UnityEngine;

namespace Cysharp.Threading.Tasks;

public static class EnumeratorAsyncExtensions
{
	private sealed class EnumeratorPromise : IUniTaskSource, IValueTaskSource, IPlayerLoopItem, ITaskPoolNode<EnumeratorPromise>
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9;

			static _003C_003Ec()
			{
				_003C_003Ec obj = new _003C_003Ec();
				_003C_003E9 = obj;
			}

			internal int _003C_002Ecctor_003Eb__4_0()
			{
				//IL_0013: Expected I, but got O
				nint num = (nint)typeof(EnumeratorPromise);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v3 (Il2CppClass<Cysharp.Threading.Tasks.EnumeratorAsyncExtensions+EnumeratorPromise>)+B8]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v4 (Il2CppStaticFields<Cysharp.Threading.Tasks.EnumeratorAsyncExtensions+EnumeratorPromise>)+4]");
				return 0;
			}
		}

		private sealed class _003CConsumeEnumerator_003Ed__19(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state = _003C_003E1__state;

			private object _003C_003E2__current;

			public IEnumerator enumerator;

			private CustomYieldInstruction _003Ccyi_003E5__2;

			private IEnumerator _003CinnerCoroutine_003E5__3;

			object IEnumerator<object>.Current => _003C_003E2__current;

			object IEnumerator.Current => _003C_003E2__current;

			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				//IL_0012: Expected O, but got I8
				//IL_002c: Expected O, but got I8
				while (true)
				{
					int num = _003C_003E1__state;
					if (_003C_003E1__state > 5)
					{
						break;
					}
					object obj = 6442450944L;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ r14_v2+5D49A9C+v32 @ rax_v2 (System.Int32)*4]");
					object obj2 = 0 + 6442450944L;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v59 @ rcx_v3 (should have been resolved before IL gen)");
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		private sealed class _003CUnwrapWaitAsyncOperation_003Ed__22(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state = _003C_003E1__state;

			private object _003C_003E2__current;

			public AsyncOperation asyncOperation;

			object IEnumerator<object>.Current => _003C_003E2__current;

			object IEnumerator.Current => _003C_003E2__current;

			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				//IL_002e: Expected I4, but got I8
				//IL_00ab: Expected O, but got I4
				//IL_00c6->IL0093: Incompatible stack heights: 2 vs 0
				if (_003C_003E1__state <= 1)
				{
					_003C_003E1__state = -1;
					AsyncOperation asyncOperation = this.asyncOperation;
					bool flag = this.asyncOperation == null;
					bool flag2 = asyncOperation.m_Ptr == (IntPtr)0;
					object obj = AsyncOperation.get_isDone_Injected(asyncOperation.m_Ptr);
					if (obj == null)
					{
						_003C_003E2__current = null;
						_003C_003E1__state = 1;
						return true;
					}
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		private sealed class _003CUnwrapWaitForSeconds_003Ed__21(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state = _003C_003E1__state;

			private object _003C_003E2__current;

			public WaitForSeconds waitForSeconds;

			private float _003Csecond_003E5__2;

			private float _003Celapsed_003E5__3;

			object IEnumerator<object>.Current => _003C_003E2__current;

			object IEnumerator.Current => _003C_003E2__current;

			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				//IL_0014: Expected I4, but got I8
				//IL_00cc: Expected I4, but got I8
				//IL_003d: Expected O, but got I
				//IL_0132: Expected O, but got F4
				//IL_004a: Expected I, but got O
				//IL_008b: Expected F4, but got I
				if (_003C_003E1__state == 0)
				{
					_003C_003E1__state = -1;
					object value = waitForSeconds_Seconds.GetValue(waitForSeconds);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEE8]");
					object obj = 0;
					nint num = (nint)value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rdx_v9 (Il2CppClass<System.Object>)+40]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ r8_v11+40]");
					if (num2 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v25 (System.Object)+10]");
						_003Csecond_003E5__2 = 0f;
						_003Celapsed_003E5__3 = 0f;
						goto IL_00d1;
					}
					throw new InvalidCastException();
				}
				if (_003C_003E1__state == 1)
				{
					_003C_003E1__state = -1;
					object obj2 = Time.deltaTime;
					object obj3 = default(object);
					if ((_003Celapsed_003E5__3 = (float)obj3 + _003Celapsed_003E5__3) < _003Csecond_003E5__2)
					{
						goto IL_00d1;
					}
				}
				return false;
				IL_00d1:
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		private static TaskPool<EnumeratorPromise> pool;

		private EnumeratorPromise nextNode;

		private IEnumerator innerEnumerator;

		private CancellationToken cancellationToken;

		private int initialFrame;

		private bool loopRunning;

		private bool calledGetResult;

		private UniTaskCompletionSourceCore<object> core;

		private static readonly FieldInfo waitForSeconds_Seconds;

		public unsafe ref EnumeratorPromise NextNode
		{
			get
			{
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_000b: Expected Ref, but got Unknown
				return ref *(EnumeratorPromise*)(this + 16);
			}
		}

		static EnumeratorPromise()
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Expected O, but got Unknown
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj4 = default(object);
			object obj3 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v168 @ r9_v1+6B8] (should have been resolved before IL gen)");
			FieldInfo fieldInfo = default(FieldInfo);
			waitForSeconds_Seconds = fieldInfo;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj6 = default(object);
			object obj5 = obj6 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type type2 = default(Type);
			Type type = type2;
			Func<int> getSize = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003B10");
			TaskPool.RegisterSizeGetter(type, getSize);
		}

		private EnumeratorPromise()
		{
		}

		public unsafe static IUniTaskSource Create(IEnumerator innerEnumerator, PlayerLoopTiming timing, CancellationToken cancellationToken, out short token)
		{
			//IL_0070: Expected I, but got O
			//IL_016b: Expected I4, but got I8
			if ((object)cancellationToken != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ r8 (System.Threading.CancellationToken)+20]");
				if ((nint)0 >= (nint)2)
				{
					return AutoResetUniTaskCompletionSource.CreateFromCanceled(cancellationToken, out token);
				}
			}
			nint num = (nint)typeof(EnumeratorPromise);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rcx_v4 (Il2CppClass<Cysharp.Threading.Tasks.EnumeratorAsyncExtensions+EnumeratorPromise>)+B8]");
			EnumeratorPromise enumeratorPromise = default(EnumeratorPromise);
			EnumeratorPromise enumeratorPromise2;
			if (!((TaskPool<EnumeratorPromise>*)null)->TryPop(out var result))
			{
				enumeratorPromise = new EnumeratorPromise();
				enumeratorPromise2 = enumeratorPromise;
			}
			else
			{
				enumeratorPromise2 = result;
			}
			IEnumerator enumerator = ConsumeEnumerator(innerEnumerator);
			if (enumeratorPromise2 != null)
			{
				enumeratorPromise2.innerEnumerator = enumerator;
				if (enumeratorPromise != null)
				{
					enumeratorPromise.cancellationToken = cancellationToken;
					if (enumeratorPromise != null)
					{
						enumeratorPromise.loopRunning = true;
						if (enumeratorPromise != null)
						{
							enumeratorPromise.calledGetResult = false;
							if (enumeratorPromise != null)
							{
								enumeratorPromise.initialFrame = -1;
								if (enumeratorPromise != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v38 (Cysharp.Threading.Tasks.EnumeratorAsyncExtensions+EnumeratorPromise)+40]");
									ref short reference = ref *(short*)null;
									if (enumeratorPromise.MoveNext())
									{
										PlayerLoopHelper.AddAction(timing, enumeratorPromise);
									}
									return enumeratorPromise;
								}
							}
						}
					}
				}
			}
			return (IUniTaskSource)new NullReferenceException();
		}

		public unsafe void GetResult(short token)
		{
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Expected O, but got Unknown
			EnumeratorPromise enumeratorPromise = default(EnumeratorPromise);
			enumeratorPromise.calledGetResult = true;
			UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(enumeratorPromise + 48);
			object result = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->GetResult(token);
			if (!enumeratorPromise.loopRunning)
			{
				bool flag = enumeratorPromise.TryReturn();
			}
		}

		public unsafe UniTaskStatus GetStatus(short token)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 48);
			return ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->GetStatus(token);
		}

		public unsafe UniTaskStatus UnsafeGetStatus()
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 48);
			return ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->UnsafeGetStatus();
		}

		public unsafe void OnCompleted(Action<object> continuation, object state, short token)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 48);
			((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->OnCompleted(continuation, state, token);
		}

		public unsafe bool MoveNext()
		{
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Expected O, but got Unknown
			//IL_01ce: Expected I4, but got O
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Expected O, but got Unknown
			if (!calledGetResult)
			{
				if (innerEnumerator != null)
				{
					if ((object)this.cancellationToken != null)
					{
						CancellationToken cancellationToken = this.cancellationToken;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v20 (System.Threading.CancellationToken)+20]");
						if ((nint)0 >= (nint)2)
						{
							loopRunning = false;
							UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 48);
							bool flag = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->TrySetCanceled(this.cancellationToken);
							return false;
						}
					}
					if (initialFrame != -1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184B45BB0");
						object obj = default(object);
						if (initialFrame == (nint)obj)
						{
							return true;
						}
					}
					else if (PlayerLoopHelper.IsMainThread)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184B45BB0");
						int num = default(int);
						initialFrame = num;
					}
					if (innerEnumerator != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						object obj2 = default(object);
						if (obj2 == null)
						{
							loopRunning = false;
							UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<object>)(this + 48);
							bool flag2 = ((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore2)->TrySetResult(null);
							return false;
						}
						return true;
					}
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
			}
			else
			{
				loopRunning = false;
				bool flag3 = TryReturn();
			}
			return false;
		}

		private unsafe bool TryReturn()
		{
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Expected O, but got Unknown
			//IL_0010: Expected O, but got I4
			//IL_001e: Expected I, but got O
			UniTaskCompletionSourceCore<object> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<object>)(this + 48);
			((UniTaskCompletionSourceCore<object>*)uniTaskCompletionSourceCore)->Reset();
			innerEnumerator = null;
			cancellationToken = (CancellationToken)0;
			nint num = (nint)typeof(EnumeratorPromise);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rcx_v5 (Il2CppClass<Cysharp.Threading.Tasks.EnumeratorAsyncExtensions+EnumeratorPromise>)+B8]");
			return ((TaskPool<object>*)null)->TryPush(this);
		}

		private static IEnumerator ConsumeEnumerator(IEnumerator enumerator)
		{
			_003CConsumeEnumerator_003Ed__19 obj = null;
			obj._003C_003E1__state = 0;
			obj.enumerator = enumerator;
			return obj;
		}

		private static IEnumerator UnwrapWaitForSeconds(WaitForSeconds waitForSeconds)
		{
			_003CUnwrapWaitForSeconds_003Ed__21 obj = null;
			obj._003C_003E1__state = 0;
			obj.waitForSeconds = waitForSeconds;
			return obj;
		}

		private static IEnumerator UnwrapWaitAsyncOperation(AsyncOperation asyncOperation)
		{
			_003CUnwrapWaitAsyncOperation_003Ed__22 obj = null;
			obj._003C_003E1__state = 0;
			obj.asyncOperation = asyncOperation;
			return obj;
		}
	}

	private sealed class _003CCore_003Ed__4(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public MonoBehaviour coroutineRunner;

		public IEnumerator inner;

		public AutoResetUniTaskCompletionSource source;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0031: Expected I4, but got I8
			//IL_00b6: Expected I4, but got I8
			//IL_00fd: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)coroutineRunner != null)
				{
					Coroutine coroutine = coroutineRunner.StartCoroutine(inner);
					_003C_003E2__current = coroutine;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_00ef;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if (source == null)
				{
					goto IL_00ef;
				}
				bool flag = source.TrySetResult();
			}
			return false;
			IL_00ef:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	public unsafe static UniTask.Awaiter GetAwaiter<T>(T enumerator) where T : IEnumerator
	{
		//IL_0008: Expected O, but got Ref
		//IL_005b: Expected O, but got I
		//IL_0110: Expected O, but got Ref
		//IL_0132: Expected O, but got I
		//IL_0162: Expected I, but got O
		//IL_00b6: Expected O, but got I4
		//IL_018b: Expected native int or pointer, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ r8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v2 (Il2CppClass<T>)+FC]");
		object obj3 = (nint)0 + (nint)15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v2 (Il2CppClass<T>)+FC]");
		T val;
		if ((nint)obj3 > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			val = (T)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
			_ = 0;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rcx_v3 (Il2CppClass<T>)+28]");
			object obj4 = (nint)0 >> 31;
			if (obj4 == null)
			{
				goto IL_014f;
			}
		}
		val = enumerator;
		goto IL_014f;
		IL_014f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		IEnumerator enumerator2 = (IEnumerator)(object)(IntPtr)obj2;
		if (enumerator2 != null)
		{
			IUniTaskSource uniTaskSource = EnumeratorPromise.Create(enumerator2, PlayerLoopTiming.Update, (CancellationToken)0, out System.Runtime.CompilerServices.Unsafe.As<object, short>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96)));
			_ = 0;
			obj = uniTaskSource;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+60]");
			_ = 0;
			UniTask.Awaiter awaiter = default(UniTask.Awaiter);
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask.Awaiter*)(nint)awaiter)->task, (UniTask)obj);
			return awaiter;
		}
		Error.ThrowArgumentNullExceptionCore("enumerator");
		UniTask.Awaiter result = default(UniTask.Awaiter);
		return result;
	}

	public unsafe static UniTask WithCancellation(IEnumerator enumerator, CancellationToken cancellationToken)
	{
		//IL_002d: Expected native int or pointer, but got O
		//IL_003a: Expected native int or pointer, but got O
		//IL_004c: Expected native int or pointer, but got O
		if (enumerator != null)
		{
			IUniTaskSource source = EnumeratorPromise.Create(enumerator, PlayerLoopTiming.Update, cancellationToken, out var token);
			UniTask uniTask = default(UniTask);
			((UniTask*)(nint)uniTask)->token = 0;
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, source);
			((UniTask*)(nint)uniTask)->token = token;
			return uniTask;
		}
		Error.ThrowArgumentNullExceptionCore("enumerator");
		UniTask result = default(UniTask);
		return result;
	}

	public unsafe static UniTask ToUniTask(IEnumerator enumerator, PlayerLoopTiming timing = PlayerLoopTiming.Update, CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_002c: Expected native int or pointer, but got O
		//IL_0039: Expected native int or pointer, but got O
		//IL_004b: Expected native int or pointer, but got O
		if (enumerator != null)
		{
			IUniTaskSource source = EnumeratorPromise.Create(enumerator, timing, cancellationToken, out var token);
			UniTask uniTask = default(UniTask);
			((UniTask*)(nint)uniTask)->token = 0;
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, source);
			((UniTask*)(nint)uniTask)->token = token;
			return uniTask;
		}
		Error.ThrowArgumentNullExceptionCore("enumerator");
		UniTask result = default(UniTask);
		return result;
	}

	public unsafe static UniTask ToUniTask(IEnumerator enumerator, MonoBehaviour coroutineRunner)
	{
		//IL_006b: Expected native int or pointer, but got O
		AutoResetUniTaskCompletionSource autoResetUniTaskCompletionSource = AutoResetUniTaskCompletionSource.Create();
		_003CCore_003Ed__4 obj = null;
		obj.inner = enumerator;
		obj._003C_003E1__state = 0;
		obj.coroutineRunner = coroutineRunner;
		obj.source = autoResetUniTaskCompletionSource;
		if ((object)coroutineRunner != null)
		{
			Coroutine coroutine = coroutineRunner.StartCoroutine(obj);
			if (autoResetUniTaskCompletionSource != null)
			{
				UniTask uniTask = default(UniTask);
				System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, autoResetUniTaskCompletionSource);
				return uniTask;
			}
		}
		return (UniTask)new NullReferenceException();
	}

	private static IEnumerator Core(IEnumerator inner, MonoBehaviour coroutineRunner, AutoResetUniTaskCompletionSource source)
	{
		_003CCore_003Ed__4 obj = null;
		obj._003C_003E1__state = 0;
		obj.inner = inner;
		obj.coroutineRunner = coroutineRunner;
		obj.source = source;
		return obj;
	}
}
