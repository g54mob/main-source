using System;
using System.Runtime.CompilerServices;
using LitMotion.Adapters;

namespace LitMotion
{
	public struct MotionSequenceBuilder : IDisposable
	{
		internal MotionSequenceBuilderSource source;

		internal ushort version;

		internal MotionSequenceBuilder(MotionSequenceBuilderSource source)
		{
			this.source = source;
			version = source.Version;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly MotionSequenceBuilder Append(MotionHandle handle)
		{
			CheckIsDisposed();
			source.Append(handle);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly MotionSequenceBuilder AppendInterval(float interval)
		{
			CheckIsDisposed();
			source.AppendInterval(interval);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly MotionSequenceBuilder Insert(float position, MotionHandle handle)
		{
			CheckIsDisposed();
			source.Insert(position, handle);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly MotionSequenceBuilder Join(MotionHandle handle)
		{
			CheckIsDisposed();
			source.Join(handle);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public MotionHandle Run()
		{
			return Run(null);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public MotionHandle Run(Action<MotionBuilder<double, NoOptions, DoubleMotionAdapter>> configuration)
		{
			CheckIsDisposed();
			MotionHandle result = source.Schedule(configuration);
			Dispose();
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Dispose()
		{
			CheckIsDisposed();
			MotionSequenceBuilderSource.Return(source);
			source = null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private readonly void CheckIsDisposed()
		{
			if (source == null || source.Version != version)
			{
				throw new InvalidOperationException("MotionSequenuceBuilder is either not initialized or has already run.");
			}
		}
	}
}
