using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coherence.Log;

namespace Coherence.Interpolation
{
	public class SampleBuffer<T> : IEnumerable<Sample<T>>, IEnumerable
	{
		public struct AdjecentSamplesResult
		{
			public Sample<T> Sample0;

			public Sample<T> Sample1;

			public Sample<T> Sample2;

			public Sample<T> Sample3;

			public bool IsLastSample;

			public AdjecentSamplesResult(Sample<T> sample0, Sample<T> sample1, Sample<T> sample2, Sample<T> sample3, bool isLastSample)
			{
				Sample0 = default(Sample<T>);
				Sample1 = default(Sample<T>);
				Sample2 = default(Sample<T>);
				Sample3 = default(Sample<T>);
				IsLastSample = false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetEnumerator_003Ed__24 : IEnumerator<Sample<T>>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Sample<T> _003C_003E2__current;

			public SampleBuffer<T> _003C_003E4__this;

			private int _003Ci_003E5__2;

			Sample<T> IEnumerator<Sample<T>>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(Sample<T>);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CGetEnumerator_003Ed__24(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private const int initialCapacity = 20;

		private const int sampleCountForMeasuringInterval = 5;

		private const int sampleCountForMeasuringLatency = 5;

		private readonly Logger logger;

		private Sample<T>[] data;

		private int head;

		private int tail;

		public (Sample<T> First, Sample<T> Second)? VirtualSamples { get; set; }

		public int Capacity => 0;

		public int Count { get; private set; }

		public Sample<T> this[int index]
		{
			get
			{
				return default(Sample<T>);
			}
			set
			{
			}
		}

		public Sample<T>? Last
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		[IteratorStateMachine(typeof(SampleBuffer<>._003CGetEnumerator_003Ed__24))]
		public IEnumerator<Sample<T>> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public void SetLast(Sample<T> value)
		{
		}

		public void PushFront(Sample<T> sample)
		{
		}

		public Sample<T>? PopBack()
		{
			return null;
		}

		public AdjecentSamplesResult GetAdjacentSamples(double time, bool ignoreVirtualSamples)
		{
			return default(AdjecentSamplesResult);
		}

		private int ClampIndex(int index)
		{
			return 0;
		}

		private int GetLastSampleIndexBefore(double time)
		{
			return 0;
		}

		private int GetFirstSampleIndexAfter(double time)
		{
			return 0;
		}

		public void RemoveOutdatedSamples(double time, int numberOfSamplesToStayBehind)
		{
		}

		public bool TryMeasureSampleInterval(out double measuredSampleInterval)
		{
			measuredSampleInterval = default(double);
			return false;
		}

		public bool TryMeasureSampleLatency(out double measuredNetworkLatency)
		{
			measuredNetworkLatency = default(double);
			return false;
		}

		public void Reset()
		{
		}

		private void GrowBuffer()
		{
		}

		public override string ToString()
		{
			return null;
		}

		private void RemoveAllButLastSample()
		{
		}
	}
}
