using System;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Util;

namespace Amazon.Runtime.Internal
{
	public class TokenBucket
	{
		private const int MaxAttempts = 15;

		private readonly object _bucketLock = new object();

		private readonly double _minFillRate;

		private readonly double _minCapacity;

		private readonly double _beta;

		private readonly double _scaleConstant;

		private readonly double _smooth;

		private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		protected double? FillRate { get; set; }

		protected double? MaxCapacity { get; set; }

		protected double CurrentCapacity { get; set; }

		protected double? LastTimestamp { get; set; }

		protected double MeasuredTxRate { get; set; }

		protected double LastTxRateBucket { get; set; }

		protected long RequestCount { get; set; }

		protected double LastMaxRate { get; set; }

		protected double LastThrottleTime { get; set; }

		protected double TimeWindow { get; set; }

		protected bool Enabled { get; set; }

		public TokenBucket()
			: this(0.5, 1.0, 0.7, 0.4, 0.8)
		{
		}

		public TokenBucket(double minFillRate, double minCapacity, double beta, double scaleConstant, double smooth)
		{
			_minFillRate = minFillRate;
			_minCapacity = minCapacity;
			_beta = beta;
			_scaleConstant = scaleConstant;
			_smooth = smooth;
			LastTxRateBucket = Math.Floor(GetTimestamp());
			LastThrottleTime = GetTimestamp();
		}

		public bool TryAcquireToken(double amount, bool failFast)
		{
			bool? flag = SetupAcquireToken(amount);
			if (flag.HasValue)
			{
				return flag.Value;
			}
			for (int i = 0; i < 15; i++)
			{
				int num = ObtainCapacity(amount);
				if (num == 0)
				{
					break;
				}
				if (failFast || i + 1 == 15)
				{
					return false;
				}
				WaitForToken(num);
			}
			return true;
		}

		public async Task<bool> TryAcquireTokenAsync(double amount, bool failFast, CancellationToken cancellationToken)
		{
			bool? flag = SetupAcquireToken(amount);
			if (flag.HasValue)
			{
				return flag.Value;
			}
			for (int attempt = 0; attempt < 15; attempt++)
			{
				int num = ObtainCapacity(amount);
				if (num == 0)
				{
					break;
				}
				if (failFast || attempt + 1 == 15)
				{
					return false;
				}
				await WaitForTokenAsync(num, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			return true;
		}

		private bool? SetupAcquireToken(double amount)
		{
			if (amount <= 0.0)
			{
				return false;
			}
			lock (_bucketLock)
			{
				if (!Enabled)
				{
					return true;
				}
				TokenBucketRefill();
			}
			return null;
		}

		private int ObtainCapacity(double amount)
		{
			double currentCapacity;
			double value;
			lock (_bucketLock)
			{
				if (amount <= CurrentCapacity)
				{
					CurrentCapacity -= amount;
					return 0;
				}
				currentCapacity = CurrentCapacity;
				value = FillRate.Value;
			}
			return CalculateWait(amount, currentCapacity, value);
		}

		public void UpdateClientSendingRate(bool isThrottlingError)
		{
			lock (_bucketLock)
			{
				UpdateMeasuredRate();
				double val;
				if (isThrottlingError)
				{
					double rateToUse = (LastMaxRate = (Enabled ? Math.Min(MeasuredTxRate, FillRate.Value) : MeasuredTxRate));
					CalculateTimeWindow();
					LastThrottleTime = GetTimestamp();
					val = CUBICThrottle(rateToUse);
					Enabled = true;
				}
				else
				{
					CalculateTimeWindow();
					val = CUBICSuccess(GetTimestamp());
				}
				double newRps = Math.Min(val, 2.0 * MeasuredTxRate);
				TokenBucketUpdateRate(newRps);
			}
		}

		protected virtual void TokenBucketRefill()
		{
			double timestamp = GetTimestamp();
			if (!LastTimestamp.HasValue)
			{
				LastTimestamp = timestamp;
				return;
			}
			double num = (timestamp - LastTimestamp.Value) * FillRate.Value;
			CurrentCapacity = Math.Min(MaxCapacity.Value, CurrentCapacity + num);
			LastTimestamp = timestamp;
		}

		protected virtual void TokenBucketUpdateRate(double newRps)
		{
			TokenBucketRefill();
			FillRate = Math.Max(newRps, _minFillRate);
			MaxCapacity = Math.Max(newRps, _minCapacity);
			CurrentCapacity = Math.Min(CurrentCapacity, MaxCapacity.Value);
		}

		protected virtual void UpdateMeasuredRate()
		{
			double num = Math.Floor(GetTimestamp() * 2.0) / 2.0;
			RequestCount++;
			if (num > LastTxRateBucket)
			{
				double num2 = (double)RequestCount / (num - LastTxRateBucket);
				MeasuredTxRate = num2 * _smooth + MeasuredTxRate * (1.0 - _smooth);
				RequestCount = 0L;
				LastTxRateBucket = num;
			}
		}

		protected virtual void CalculateTimeWindow()
		{
			TimeWindow = Math.Pow(LastMaxRate * (1.0 - _beta) / _scaleConstant, 1.0 / 3.0);
		}

		protected virtual double CUBICSuccess(double timestamp)
		{
			timestamp -= LastThrottleTime;
			return _scaleConstant * Math.Pow(timestamp - TimeWindow, 3.0) + LastMaxRate;
		}

		protected virtual double CUBICThrottle(double rateToUse)
		{
			return rateToUse * _beta;
		}

		protected virtual int CalculateWait(double amount, double currentCapacity, double fillRate)
		{
			return (int)((amount - currentCapacity) / fillRate * 1000.0);
		}

		protected virtual void WaitForToken(int delayMs)
		{
			AWSSDKUtils.Sleep(delayMs);
		}

		protected virtual async Task WaitForTokenAsync(int delayMs, CancellationToken cancellationToken)
		{
			await Task.Delay(delayMs, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		protected virtual double GetTimestamp()
		{
			return GetTimeInSeconds();
		}

		private static double GetTimeInSeconds()
		{
			return (DateTime.UtcNow - _epoch).TotalSeconds;
		}
	}
}
