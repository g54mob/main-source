using Coherence.SimulationFrame;
using UnityEngine;

namespace Coherence.Interpolation
{
	public sealed class BindingInterpolator<T>
	{
		private const float DelaySmoothTimeIncrease = 1f;

		private const float DelaySmoothTimeDecrease = 5f;

		public const float VirtualSamplesInvervalFactor = 0.8f;

		private double sampleRate;

		public InterpolationSettings Settings;

		public double Time;

		private double delayVelocity;

		private double? lastDelaySmoothTime;

		private readonly SampleBuffer<T> buffer;

		private readonly IInterpolator<T> interpolator;

		private readonly ISmoothing<T> smoothing;

		public double SampleRate
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public bool IsInterpolationNone => false;

		public double MeasuredSampleInterval { get; private set; }

		public double NetworkLatency { get; private set; }

		public double Delay { get; private set; }

		public double TargetDelay => 0.0;

		public bool IsStopped { get; private set; }

		public T LastInterpolatedValue { get; set; }

		public bool HasLastInterpolatedValue { get; private set; }

		public SampleBuffer<T> Buffer => null;

		public ISmoothing<T> Smoothing => null;

		public BindingInterpolator(InterpolationSettings settings, double sampleRate)
		{
		}

		public Sample<T>? GetLastSample()
		{
			return null;
		}

		public void AppendSample(T value, bool stopped, AbsoluteSimulationFrame sampleFrame, AbsoluteSimulationFrame localFrame)
		{
		}

		public void AppendSample(T value, bool stopped, bool isSampleTimeValid, double sampleTime, double localTime)
		{
		}

		public void RemoveOutdatedSamples(double time)
		{
		}

		public void Reset()
		{
		}

		public T GetValueAt(double time, bool ignoreVirtualSamples = true)
		{
			return default(T);
		}

		public T PerformInterpolation(T currentValue, double time)
		{
			return default(T);
		}

		private void SetVirtualSamples(Sample<T> previousSample)
		{
		}

		public T GetSecondVirtualSampleValue(double virtualSampleTime)
		{
			return default(T);
		}

		private double Step(double newTime)
		{
			return 0.0;
		}

		private void UpdateDelay(double time)
		{
		}

		private void UpdateNetworkLatency(double networkLatency)
		{
		}

		private bool IsBeyondTeleportDistance(T value)
		{
			return false;
		}

		public bool IsBeyondTeleportDistance(int a, int b)
		{
			return false;
		}

		public bool IsBeyondTeleportDistance(float a, float b)
		{
			return false;
		}

		public bool IsBeyondTeleportDistance(Vector2 a, Vector2 b)
		{
			return false;
		}

		public bool IsBeyondTeleportDistance(Vector3 a, Vector3 b)
		{
			return false;
		}

		public bool IsBeyondTeleportDistance(Quaternion a, Quaternion b)
		{
			return false;
		}

		public InterpolationResult<T> CalculateInterpolationPercentage(double time, bool ignoreVirtualSamples)
		{
			return default(InterpolationResult<T>);
		}
	}
}
