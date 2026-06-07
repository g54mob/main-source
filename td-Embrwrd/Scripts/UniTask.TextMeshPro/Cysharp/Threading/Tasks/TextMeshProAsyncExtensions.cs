using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks.CompilerServices;
using TMPro;

namespace Cysharp.Threading.Tasks
{
	public static class TextMeshProAsyncExtensions
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CBindToCore_003Ed__2 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<string> source;

			public CancellationToken cancellationToken;

			public bool rebindOnError;

			public TMP_Text text;

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

			public TMP_Text text;

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

		public static void BindTo(this IUniTaskAsyncEnumerable<string> source, TMP_Text text, bool rebindOnError = true)
		{
		}

		public static void BindTo(this IUniTaskAsyncEnumerable<string> source, TMP_Text text, CancellationToken cancellationToken, bool rebindOnError = true)
		{
		}

		[AsyncStateMachine(typeof(_003CBindToCore_003Ed__2))]
		private static UniTaskVoid BindToCore(IUniTaskAsyncEnumerable<string> source, TMP_Text text, CancellationToken cancellationToken, bool rebindOnError)
		{
			return default(UniTaskVoid);
		}

		public static void BindTo<T>(this IUniTaskAsyncEnumerable<T> source, TMP_Text text, bool rebindOnError = true)
		{
		}

		public static void BindTo<T>(this IUniTaskAsyncEnumerable<T> source, TMP_Text text, CancellationToken cancellationToken, bool rebindOnError = true)
		{
		}

		public static void BindTo<T>(this AsyncReactiveProperty<T> source, TMP_Text text, bool rebindOnError = true)
		{
		}

		[AsyncStateMachine(typeof(_003CBindToCore_003Ed__6<>))]
		private static UniTaskVoid BindToCore<T>(IUniTaskAsyncEnumerable<T> source, TMP_Text text, CancellationToken cancellationToken, bool rebindOnError)
		{
			return default(UniTaskVoid);
		}

		public static IAsyncValueChangedEventHandler<string> GetAsyncValueChangedEventHandler(this TMP_InputField inputField)
		{
			return null;
		}

		public static IAsyncValueChangedEventHandler<string> GetAsyncValueChangedEventHandler(this TMP_InputField inputField, CancellationToken cancellationToken)
		{
			return null;
		}

		public static UniTask<string> OnValueChangedAsync(this TMP_InputField inputField)
		{
			return default(UniTask<string>);
		}

		public static UniTask<string> OnValueChangedAsync(this TMP_InputField inputField, CancellationToken cancellationToken)
		{
			return default(UniTask<string>);
		}

		public static IUniTaskAsyncEnumerable<string> OnValueChangedAsAsyncEnumerable(this TMP_InputField inputField)
		{
			return null;
		}

		public static IUniTaskAsyncEnumerable<string> OnValueChangedAsAsyncEnumerable(this TMP_InputField inputField, CancellationToken cancellationToken)
		{
			return null;
		}

		public static IAsyncEndEditEventHandler<string> GetAsyncEndEditEventHandler(this TMP_InputField inputField)
		{
			return null;
		}

		public static IAsyncEndEditEventHandler<string> GetAsyncEndEditEventHandler(this TMP_InputField inputField, CancellationToken cancellationToken)
		{
			return null;
		}

		public static UniTask<string> OnEndEditAsync(this TMP_InputField inputField)
		{
			return default(UniTask<string>);
		}

		public static UniTask<string> OnEndEditAsync(this TMP_InputField inputField, CancellationToken cancellationToken)
		{
			return default(UniTask<string>);
		}

		public static IUniTaskAsyncEnumerable<string> OnEndEditAsAsyncEnumerable(this TMP_InputField inputField)
		{
			return null;
		}

		public static IUniTaskAsyncEnumerable<string> OnEndEditAsAsyncEnumerable(this TMP_InputField inputField, CancellationToken cancellationToken)
		{
			return null;
		}

		public static IAsyncEndTextSelectionEventHandler<(string, int, int)> GetAsyncEndTextSelectionEventHandler(this TMP_InputField inputField)
		{
			return null;
		}

		public static IAsyncEndTextSelectionEventHandler<(string, int, int)> GetAsyncEndTextSelectionEventHandler(this TMP_InputField inputField, CancellationToken cancellationToken)
		{
			return null;
		}

		public static UniTask<(string, int, int)> OnEndTextSelectionAsync(this TMP_InputField inputField)
		{
			return default(UniTask<(string, int, int)>);
		}

		public static UniTask<(string, int, int)> OnEndTextSelectionAsync(this TMP_InputField inputField, CancellationToken cancellationToken)
		{
			return default(UniTask<(string, int, int)>);
		}

		public static IUniTaskAsyncEnumerable<(string, int, int)> OnEndTextSelectionAsAsyncEnumerable(this TMP_InputField inputField)
		{
			return null;
		}

		public static IUniTaskAsyncEnumerable<(string, int, int)> OnEndTextSelectionAsAsyncEnumerable(this TMP_InputField inputField, CancellationToken cancellationToken)
		{
			return null;
		}

		public static IAsyncTextSelectionEventHandler<(string, int, int)> GetAsyncTextSelectionEventHandler(this TMP_InputField inputField)
		{
			return null;
		}

		public static IAsyncTextSelectionEventHandler<(string, int, int)> GetAsyncTextSelectionEventHandler(this TMP_InputField inputField, CancellationToken cancellationToken)
		{
			return null;
		}

		public static UniTask<(string, int, int)> OnTextSelectionAsync(this TMP_InputField inputField)
		{
			return default(UniTask<(string, int, int)>);
		}

		public static UniTask<(string, int, int)> OnTextSelectionAsync(this TMP_InputField inputField, CancellationToken cancellationToken)
		{
			return default(UniTask<(string, int, int)>);
		}

		public static IUniTaskAsyncEnumerable<(string, int, int)> OnTextSelectionAsAsyncEnumerable(this TMP_InputField inputField)
		{
			return null;
		}

		public static IUniTaskAsyncEnumerable<(string, int, int)> OnTextSelectionAsAsyncEnumerable(this TMP_InputField inputField, CancellationToken cancellationToken)
		{
			return null;
		}

		public static IAsyncDeselectEventHandler<string> GetAsyncDeselectEventHandler(this TMP_InputField inputField)
		{
			return null;
		}

		public static IAsyncDeselectEventHandler<string> GetAsyncDeselectEventHandler(this TMP_InputField inputField, CancellationToken cancellationToken)
		{
			return null;
		}

		public static UniTask<string> OnDeselectAsync(this TMP_InputField inputField)
		{
			return default(UniTask<string>);
		}

		public static UniTask<string> OnDeselectAsync(this TMP_InputField inputField, CancellationToken cancellationToken)
		{
			return default(UniTask<string>);
		}

		public static IUniTaskAsyncEnumerable<string> OnDeselectAsAsyncEnumerable(this TMP_InputField inputField)
		{
			return null;
		}

		public static IUniTaskAsyncEnumerable<string> OnDeselectAsAsyncEnumerable(this TMP_InputField inputField, CancellationToken cancellationToken)
		{
			return null;
		}

		public static IAsyncSelectEventHandler<string> GetAsyncSelectEventHandler(this TMP_InputField inputField)
		{
			return null;
		}

		public static IAsyncSelectEventHandler<string> GetAsyncSelectEventHandler(this TMP_InputField inputField, CancellationToken cancellationToken)
		{
			return null;
		}

		public static UniTask<string> OnSelectAsync(this TMP_InputField inputField)
		{
			return default(UniTask<string>);
		}

		public static UniTask<string> OnSelectAsync(this TMP_InputField inputField, CancellationToken cancellationToken)
		{
			return default(UniTask<string>);
		}

		public static IUniTaskAsyncEnumerable<string> OnSelectAsAsyncEnumerable(this TMP_InputField inputField)
		{
			return null;
		}

		public static IUniTaskAsyncEnumerable<string> OnSelectAsAsyncEnumerable(this TMP_InputField inputField, CancellationToken cancellationToken)
		{
			return null;
		}

		public static IAsyncSubmitEventHandler<string> GetAsyncSubmitEventHandler(this TMP_InputField inputField)
		{
			return null;
		}

		public static IAsyncSubmitEventHandler<string> GetAsyncSubmitEventHandler(this TMP_InputField inputField, CancellationToken cancellationToken)
		{
			return null;
		}

		public static UniTask<string> OnSubmitAsync(this TMP_InputField inputField)
		{
			return default(UniTask<string>);
		}

		public static UniTask<string> OnSubmitAsync(this TMP_InputField inputField, CancellationToken cancellationToken)
		{
			return default(UniTask<string>);
		}

		public static IUniTaskAsyncEnumerable<string> OnSubmitAsAsyncEnumerable(this TMP_InputField inputField)
		{
			return null;
		}

		public static IUniTaskAsyncEnumerable<string> OnSubmitAsAsyncEnumerable(this TMP_InputField inputField, CancellationToken cancellationToken)
		{
			return null;
		}
	}
}
