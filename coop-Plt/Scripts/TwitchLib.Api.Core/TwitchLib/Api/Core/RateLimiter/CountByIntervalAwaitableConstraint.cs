using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TwitchLib.Api.Core.Interfaces;

namespace TwitchLib.Api.Core.RateLimiter
{
	public class CountByIntervalAwaitableConstraint : IAwaitableConstraint
	{
		public IReadOnlyList<DateTime> TimeStamps => _timeStamps.ToList();

		protected LimitedSizeStack<DateTime> _timeStamps { get; }

		private int _count { get; }

		private TimeSpan _timeSpan { get; }

		private SemaphoreSlim _semafore { get; } = new SemaphoreSlim(1, 1);

		private ITime _time { get; }

		public CountByIntervalAwaitableConstraint(int count, TimeSpan timeSpan, ITime time = null)
		{
			if (count <= 0)
			{
				throw new ArgumentException("count should be strictly positive", "count");
			}
			if (timeSpan.TotalMilliseconds <= 0.0)
			{
				throw new ArgumentException("timeSpan should be strictly positive", "timeSpan");
			}
			_count = count;
			_timeSpan = timeSpan;
			_timeStamps = new LimitedSizeStack<DateTime>(_count);
			_time = time ?? TimeSystem.StandardTime;
		}

		public async Task<IDisposable> WaitForReadiness(CancellationToken cancellationToken)
		{
			await _semafore.WaitAsync(cancellationToken);
			int count = 0;
			DateTime now = _time.GetTimeNow();
			DateTime target = now - _timeSpan;
			LinkedListNode<DateTime> element = _timeStamps.First;
			LinkedListNode<DateTime> last = null;
			while (element != null && element.Value > target)
			{
				last = element;
				element = element.Next;
				count++;
			}
			if (count < _count)
			{
				return new DisposeAction(OnEnded);
			}
			TimeSpan timetoWait = last.Value.Add(_timeSpan) - now;
			try
			{
				await _time.GetDelay(timetoWait, cancellationToken);
			}
			catch (Exception)
			{
				_semafore.Release();
				throw;
			}
			return new DisposeAction(OnEnded);
		}

		private void OnEnded()
		{
			DateTime timeNow = _time.GetTimeNow();
			_timeStamps.Push(timeNow);
			OnEnded(timeNow);
			_semafore.Release();
		}

		protected virtual void OnEnded(DateTime now)
		{
		}
	}
}
