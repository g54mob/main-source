using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Cysharp.Threading.Tasks
{
	public static class UnityBindingExtensions
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CBindToCore_003Ed__12<TSource, TObject> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public bool rebindOnError;

			public Action<TObject, TSource> bindAction;

			public TObject bindTarget;

			private bool _003Crepeat_003E5__2;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__3;

			private object _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

			private UniTask.Awaiter _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CBindToCore_003Ed__2 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<string> source;

			public CancellationToken cancellationToken;

			public bool rebindOnError;

			public Text text;

			private bool _003Crepeat_003E5__2;

			private IUniTaskAsyncEnumerator<string> _003Ce_003E5__3;

			private object _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

			private UniTask.Awaiter _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CBindToCore_003Ed__6<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<T> source;

			public CancellationToken cancellationToken;

			public bool rebindOnError;

			public Text text;

			private bool _003Crepeat_003E5__2;

			private IUniTaskAsyncEnumerator<T> _003Ce_003E5__3;

			private object _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

			private UniTask.Awaiter _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CBindToCore_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<bool> source;

			public CancellationToken cancellationToken;

			public bool rebindOnError;

			public Selectable selectable;

			private bool _003Crepeat_003E5__2;

			private IUniTaskAsyncEnumerator<bool> _003Ce_003E5__3;

			private object _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

			private UniTask.Awaiter _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		public static void BindTo(this IUniTaskAsyncEnumerable<string> source, Text text, bool rebindOnError = true)
		{
		}

		public static void BindTo(this IUniTaskAsyncEnumerable<string> source, Text text, CancellationToken cancellationToken, bool rebindOnError = true)
		{
		}

		[AsyncStateMachine(typeof(_003CBindToCore_003Ed__2))]
		private static UniTaskVoid BindToCore(IUniTaskAsyncEnumerable<string> source, Text text, CancellationToken cancellationToken, bool rebindOnError)
		{
			return default(UniTaskVoid);
		}

		public static void BindTo<T>(this IUniTaskAsyncEnumerable<T> source, Text text, bool rebindOnError = true)
		{
		}

		public static void BindTo<T>(this IUniTaskAsyncEnumerable<T> source, Text text, CancellationToken cancellationToken, bool rebindOnError = true)
		{
		}

		public static void BindTo<T>(this AsyncReactiveProperty<T> source, Text text, bool rebindOnError = true)
		{
		}

		[AsyncStateMachine(typeof(_003CBindToCore_003Ed__6<>))]
		private static UniTaskVoid BindToCore<T>(IUniTaskAsyncEnumerable<T> source, Text text, CancellationToken cancellationToken, bool rebindOnError)
		{
			return default(UniTaskVoid);
		}

		public static void BindTo(this IUniTaskAsyncEnumerable<bool> source, Selectable selectable, bool rebindOnError = true)
		{
		}

		public static void BindTo(this IUniTaskAsyncEnumerable<bool> source, Selectable selectable, CancellationToken cancellationToken, bool rebindOnError = true)
		{
		}

		[AsyncStateMachine(typeof(_003CBindToCore_003Ed__9))]
		private static UniTaskVoid BindToCore(IUniTaskAsyncEnumerable<bool> source, Selectable selectable, CancellationToken cancellationToken, bool rebindOnError)
		{
			return default(UniTaskVoid);
		}

		public static void BindTo<TSource, TObject>(this IUniTaskAsyncEnumerable<TSource> source, TObject monoBehaviour, Action<TObject, TSource> bindAction, bool rebindOnError = true) where TObject : MonoBehaviour
		{
		}

		public static void BindTo<TSource, TObject>(this IUniTaskAsyncEnumerable<TSource> source, TObject bindTarget, Action<TObject, TSource> bindAction, CancellationToken cancellationToken, bool rebindOnError = true)
		{
		}

		[AsyncStateMachine(typeof(_003CBindToCore_003Ed__12<, >))]
		private static UniTaskVoid BindToCore<TSource, TObject>(IUniTaskAsyncEnumerable<TSource> source, TObject bindTarget, Action<TObject, TSource> bindAction, CancellationToken cancellationToken, bool rebindOnError)
		{
			return default(UniTaskVoid);
		}
	}
}
