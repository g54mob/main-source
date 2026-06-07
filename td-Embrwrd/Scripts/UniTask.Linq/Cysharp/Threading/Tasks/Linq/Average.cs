using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks.Linq
{
	internal static class Average
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAverageAsync_003Ed__0 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<int> source;

			public CancellationToken cancellationToken;

			private long _003Ccount_003E5__2;

			private int _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<int> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

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
		private struct _003CAverageAsync_003Ed__1<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, int> selector;

			private long _003Ccount_003E5__2;

			private int _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

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
		private struct _003CAverageAsync_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<double> source;

			public CancellationToken cancellationToken;

			private long _003Ccount_003E5__2;

			private double _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<double> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

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
		private struct _003CAverageAsync_003Ed__13<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, double> selector;

			private long _003Ccount_003E5__2;

			private double _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

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
		private struct _003CAverageAsync_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<decimal> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<decimal> source;

			public CancellationToken cancellationToken;

			private long _003Ccount_003E5__2;

			private decimal _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<decimal> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

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
		private struct _003CAverageAsync_003Ed__17<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<decimal> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, decimal> selector;

			private long _003Ccount_003E5__2;

			private decimal _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

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
		private struct _003CAverageAsync_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double?> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<int?> source;

			public CancellationToken cancellationToken;

			private long _003Ccount_003E5__2;

			private int? _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<int?> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

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
		private struct _003CAverageAsync_003Ed__21<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double?> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, int?> selector;

			private long _003Ccount_003E5__2;

			private int? _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

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
		private struct _003CAverageAsync_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double?> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<long?> source;

			public CancellationToken cancellationToken;

			private long _003Ccount_003E5__2;

			private long? _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<long?> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

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
		private struct _003CAverageAsync_003Ed__25<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double?> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, long?> selector;

			private long _003Ccount_003E5__2;

			private long? _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

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
		private struct _003CAverageAsync_003Ed__28 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<float?> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<float?> source;

			public CancellationToken cancellationToken;

			private long _003Ccount_003E5__2;

			private float? _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<float?> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

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
		private struct _003CAverageAsync_003Ed__29<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<float?> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, float?> selector;

			private long _003Ccount_003E5__2;

			private float? _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

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
		private struct _003CAverageAsync_003Ed__32 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double?> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<double?> source;

			public CancellationToken cancellationToken;

			private long _003Ccount_003E5__2;

			private double? _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<double?> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

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
		private struct _003CAverageAsync_003Ed__33<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double?> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, double?> selector;

			private long _003Ccount_003E5__2;

			private double? _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

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
		private struct _003CAverageAsync_003Ed__36 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<decimal?> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<decimal?> source;

			public CancellationToken cancellationToken;

			private long _003Ccount_003E5__2;

			private decimal? _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<decimal?> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

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
		private struct _003CAverageAsync_003Ed__37<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<decimal?> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, decimal?> selector;

			private long _003Ccount_003E5__2;

			private decimal? _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

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
		private struct _003CAverageAsync_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<long> source;

			public CancellationToken cancellationToken;

			private long _003Ccount_003E5__2;

			private long _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<long> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

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
		private struct _003CAverageAsync_003Ed__5<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, long> selector;

			private long _003Ccount_003E5__2;

			private long _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

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
		private struct _003CAverageAsync_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<float> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<float> source;

			public CancellationToken cancellationToken;

			private long _003Ccount_003E5__2;

			private float _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<float> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

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
		private struct _003CAverageAsync_003Ed__9<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<float> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, float> selector;

			private long _003Ccount_003E5__2;

			private float _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

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
		private struct _003CAverageAwaitAsync_003Ed__10<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<float> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, UniTask<float>> selector;

			private long _003Ccount_003E5__2;

			private float _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private float _003C_003E7__wrap6;

			private UniTask<float>.Awaiter _003C_003Eu__1;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CAverageAwaitAsync_003Ed__14<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, UniTask<double>> selector;

			private long _003Ccount_003E5__2;

			private double _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private double _003C_003E7__wrap6;

			private UniTask<double>.Awaiter _003C_003Eu__1;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CAverageAwaitAsync_003Ed__18<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<decimal> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, UniTask<decimal>> selector;

			private long _003Ccount_003E5__2;

			private decimal _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private decimal _003C_003E7__wrap6;

			private UniTask<decimal>.Awaiter _003C_003Eu__1;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CAverageAwaitAsync_003Ed__2<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, UniTask<int>> selector;

			private long _003Ccount_003E5__2;

			private int _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private int _003C_003E7__wrap6;

			private UniTask<int>.Awaiter _003C_003Eu__1;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CAverageAwaitAsync_003Ed__22<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double?> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, UniTask<int?>> selector;

			private long _003Ccount_003E5__2;

			private int? _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private UniTask<int?>.Awaiter _003C_003Eu__1;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CAverageAwaitAsync_003Ed__26<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double?> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, UniTask<long?>> selector;

			private long _003Ccount_003E5__2;

			private long? _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private UniTask<long?>.Awaiter _003C_003Eu__1;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CAverageAwaitAsync_003Ed__30<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<float?> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, UniTask<float?>> selector;

			private long _003Ccount_003E5__2;

			private float? _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private UniTask<float?>.Awaiter _003C_003Eu__1;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CAverageAwaitAsync_003Ed__34<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double?> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, UniTask<double?>> selector;

			private long _003Ccount_003E5__2;

			private double? _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private UniTask<double?>.Awaiter _003C_003Eu__1;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CAverageAwaitAsync_003Ed__38<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<decimal?> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, UniTask<decimal?>> selector;

			private long _003Ccount_003E5__2;

			private decimal? _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private UniTask<decimal?>.Awaiter _003C_003Eu__1;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CAverageAwaitAsync_003Ed__6<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, UniTask<long>> selector;

			private long _003Ccount_003E5__2;

			private long _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private long _003C_003E7__wrap6;

			private UniTask<long>.Awaiter _003C_003Eu__1;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CAverageAwaitWithCancellationAsync_003Ed__11<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<float> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, CancellationToken, UniTask<float>> selector;

			private long _003Ccount_003E5__2;

			private float _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private float _003C_003E7__wrap6;

			private UniTask<float>.Awaiter _003C_003Eu__1;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CAverageAwaitWithCancellationAsync_003Ed__15<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, CancellationToken, UniTask<double>> selector;

			private long _003Ccount_003E5__2;

			private double _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private double _003C_003E7__wrap6;

			private UniTask<double>.Awaiter _003C_003Eu__1;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CAverageAwaitWithCancellationAsync_003Ed__19<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<decimal> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, CancellationToken, UniTask<decimal>> selector;

			private long _003Ccount_003E5__2;

			private decimal _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private decimal _003C_003E7__wrap6;

			private UniTask<decimal>.Awaiter _003C_003Eu__1;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CAverageAwaitWithCancellationAsync_003Ed__23<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double?> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, CancellationToken, UniTask<int?>> selector;

			private long _003Ccount_003E5__2;

			private int? _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private UniTask<int?>.Awaiter _003C_003Eu__1;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CAverageAwaitWithCancellationAsync_003Ed__27<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double?> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, CancellationToken, UniTask<long?>> selector;

			private long _003Ccount_003E5__2;

			private long? _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private UniTask<long?>.Awaiter _003C_003Eu__1;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CAverageAwaitWithCancellationAsync_003Ed__3<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, CancellationToken, UniTask<int>> selector;

			private long _003Ccount_003E5__2;

			private int _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private int _003C_003E7__wrap6;

			private UniTask<int>.Awaiter _003C_003Eu__1;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CAverageAwaitWithCancellationAsync_003Ed__31<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<float?> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, CancellationToken, UniTask<float?>> selector;

			private long _003Ccount_003E5__2;

			private float? _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private UniTask<float?>.Awaiter _003C_003Eu__1;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CAverageAwaitWithCancellationAsync_003Ed__35<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double?> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, CancellationToken, UniTask<double?>> selector;

			private long _003Ccount_003E5__2;

			private double? _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private UniTask<double?>.Awaiter _003C_003Eu__1;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CAverageAwaitWithCancellationAsync_003Ed__39<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<decimal?> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, CancellationToken, UniTask<decimal?>> selector;

			private long _003Ccount_003E5__2;

			private decimal? _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private UniTask<decimal?>.Awaiter _003C_003Eu__1;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CAverageAwaitWithCancellationAsync_003Ed__7<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<double> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, CancellationToken, UniTask<long>> selector;

			private long _003Ccount_003E5__2;

			private long _003Csum_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private long _003C_003E7__wrap6;

			private UniTask<long>.Awaiter _003C_003Eu__1;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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

		[AsyncStateMachine(typeof(_003CAverageAsync_003Ed__0))]
		public static UniTask<double> AverageAsync(IUniTaskAsyncEnumerable<int> source, CancellationToken cancellationToken)
		{
			return default(UniTask<double>);
		}

		[AsyncStateMachine(typeof(_003CAverageAsync_003Ed__1<>))]
		public static UniTask<double> AverageAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, int> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<double>);
		}

		[AsyncStateMachine(typeof(_003CAverageAwaitAsync_003Ed__2<>))]
		public static UniTask<double> AverageAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, UniTask<int>> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<double>);
		}

		[AsyncStateMachine(typeof(_003CAverageAwaitWithCancellationAsync_003Ed__3<>))]
		public static UniTask<double> AverageAwaitWithCancellationAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<int>> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<double>);
		}

		[AsyncStateMachine(typeof(_003CAverageAsync_003Ed__4))]
		public static UniTask<double> AverageAsync(IUniTaskAsyncEnumerable<long> source, CancellationToken cancellationToken)
		{
			return default(UniTask<double>);
		}

		[AsyncStateMachine(typeof(_003CAverageAsync_003Ed__5<>))]
		public static UniTask<double> AverageAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, long> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<double>);
		}

		[AsyncStateMachine(typeof(_003CAverageAwaitAsync_003Ed__6<>))]
		public static UniTask<double> AverageAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, UniTask<long>> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<double>);
		}

		[AsyncStateMachine(typeof(_003CAverageAwaitWithCancellationAsync_003Ed__7<>))]
		public static UniTask<double> AverageAwaitWithCancellationAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<long>> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<double>);
		}

		[AsyncStateMachine(typeof(_003CAverageAsync_003Ed__8))]
		public static UniTask<float> AverageAsync(IUniTaskAsyncEnumerable<float> source, CancellationToken cancellationToken)
		{
			return default(UniTask<float>);
		}

		[AsyncStateMachine(typeof(_003CAverageAsync_003Ed__9<>))]
		public static UniTask<float> AverageAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, float> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<float>);
		}

		[AsyncStateMachine(typeof(_003CAverageAwaitAsync_003Ed__10<>))]
		public static UniTask<float> AverageAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, UniTask<float>> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<float>);
		}

		[AsyncStateMachine(typeof(_003CAverageAwaitWithCancellationAsync_003Ed__11<>))]
		public static UniTask<float> AverageAwaitWithCancellationAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<float>> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<float>);
		}

		[AsyncStateMachine(typeof(_003CAverageAsync_003Ed__12))]
		public static UniTask<double> AverageAsync(IUniTaskAsyncEnumerable<double> source, CancellationToken cancellationToken)
		{
			return default(UniTask<double>);
		}

		[AsyncStateMachine(typeof(_003CAverageAsync_003Ed__13<>))]
		public static UniTask<double> AverageAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, double> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<double>);
		}

		[AsyncStateMachine(typeof(_003CAverageAwaitAsync_003Ed__14<>))]
		public static UniTask<double> AverageAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, UniTask<double>> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<double>);
		}

		[AsyncStateMachine(typeof(_003CAverageAwaitWithCancellationAsync_003Ed__15<>))]
		public static UniTask<double> AverageAwaitWithCancellationAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<double>> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<double>);
		}

		[AsyncStateMachine(typeof(_003CAverageAsync_003Ed__16))]
		public static UniTask<decimal> AverageAsync(IUniTaskAsyncEnumerable<decimal> source, CancellationToken cancellationToken)
		{
			return default(UniTask<decimal>);
		}

		[AsyncStateMachine(typeof(_003CAverageAsync_003Ed__17<>))]
		public static UniTask<decimal> AverageAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, decimal> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<decimal>);
		}

		[AsyncStateMachine(typeof(_003CAverageAwaitAsync_003Ed__18<>))]
		public static UniTask<decimal> AverageAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, UniTask<decimal>> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<decimal>);
		}

		[AsyncStateMachine(typeof(_003CAverageAwaitWithCancellationAsync_003Ed__19<>))]
		public static UniTask<decimal> AverageAwaitWithCancellationAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<decimal>> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<decimal>);
		}

		[AsyncStateMachine(typeof(_003CAverageAsync_003Ed__20))]
		public static UniTask<double?> AverageAsync(IUniTaskAsyncEnumerable<int?> source, CancellationToken cancellationToken)
		{
			return default(UniTask<double?>);
		}

		[AsyncStateMachine(typeof(_003CAverageAsync_003Ed__21<>))]
		public static UniTask<double?> AverageAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, int?> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<double?>);
		}

		[AsyncStateMachine(typeof(_003CAverageAwaitAsync_003Ed__22<>))]
		public static UniTask<double?> AverageAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, UniTask<int?>> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<double?>);
		}

		[AsyncStateMachine(typeof(_003CAverageAwaitWithCancellationAsync_003Ed__23<>))]
		public static UniTask<double?> AverageAwaitWithCancellationAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<int?>> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<double?>);
		}

		[AsyncStateMachine(typeof(_003CAverageAsync_003Ed__24))]
		public static UniTask<double?> AverageAsync(IUniTaskAsyncEnumerable<long?> source, CancellationToken cancellationToken)
		{
			return default(UniTask<double?>);
		}

		[AsyncStateMachine(typeof(_003CAverageAsync_003Ed__25<>))]
		public static UniTask<double?> AverageAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, long?> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<double?>);
		}

		[AsyncStateMachine(typeof(_003CAverageAwaitAsync_003Ed__26<>))]
		public static UniTask<double?> AverageAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, UniTask<long?>> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<double?>);
		}

		[AsyncStateMachine(typeof(_003CAverageAwaitWithCancellationAsync_003Ed__27<>))]
		public static UniTask<double?> AverageAwaitWithCancellationAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<long?>> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<double?>);
		}

		[AsyncStateMachine(typeof(_003CAverageAsync_003Ed__28))]
		public static UniTask<float?> AverageAsync(IUniTaskAsyncEnumerable<float?> source, CancellationToken cancellationToken)
		{
			return default(UniTask<float?>);
		}

		[AsyncStateMachine(typeof(_003CAverageAsync_003Ed__29<>))]
		public static UniTask<float?> AverageAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, float?> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<float?>);
		}

		[AsyncStateMachine(typeof(_003CAverageAwaitAsync_003Ed__30<>))]
		public static UniTask<float?> AverageAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, UniTask<float?>> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<float?>);
		}

		[AsyncStateMachine(typeof(_003CAverageAwaitWithCancellationAsync_003Ed__31<>))]
		public static UniTask<float?> AverageAwaitWithCancellationAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<float?>> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<float?>);
		}

		[AsyncStateMachine(typeof(_003CAverageAsync_003Ed__32))]
		public static UniTask<double?> AverageAsync(IUniTaskAsyncEnumerable<double?> source, CancellationToken cancellationToken)
		{
			return default(UniTask<double?>);
		}

		[AsyncStateMachine(typeof(_003CAverageAsync_003Ed__33<>))]
		public static UniTask<double?> AverageAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, double?> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<double?>);
		}

		[AsyncStateMachine(typeof(_003CAverageAwaitAsync_003Ed__34<>))]
		public static UniTask<double?> AverageAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, UniTask<double?>> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<double?>);
		}

		[AsyncStateMachine(typeof(_003CAverageAwaitWithCancellationAsync_003Ed__35<>))]
		public static UniTask<double?> AverageAwaitWithCancellationAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<double?>> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<double?>);
		}

		[AsyncStateMachine(typeof(_003CAverageAsync_003Ed__36))]
		public static UniTask<decimal?> AverageAsync(IUniTaskAsyncEnumerable<decimal?> source, CancellationToken cancellationToken)
		{
			return default(UniTask<decimal?>);
		}

		[AsyncStateMachine(typeof(_003CAverageAsync_003Ed__37<>))]
		public static UniTask<decimal?> AverageAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, decimal?> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<decimal?>);
		}

		[AsyncStateMachine(typeof(_003CAverageAwaitAsync_003Ed__38<>))]
		public static UniTask<decimal?> AverageAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, UniTask<decimal?>> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<decimal?>);
		}

		[AsyncStateMachine(typeof(_003CAverageAwaitWithCancellationAsync_003Ed__39<>))]
		public static UniTask<decimal?> AverageAwaitWithCancellationAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<decimal?>> selector, CancellationToken cancellationToken)
		{
			return default(UniTask<decimal?>);
		}
	}
}
