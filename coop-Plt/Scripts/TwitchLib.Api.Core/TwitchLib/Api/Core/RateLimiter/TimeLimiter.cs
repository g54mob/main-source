using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TwitchLib.Api.Core.Extensions.RateLimiter;
using TwitchLib.Api.Core.Interfaces;

namespace TwitchLib.Api.Core.RateLimiter
{
	public class TimeLimiter : IRateLimiter
	{
		private readonly IAwaitableConstraint _ac;

		internal TimeLimiter(IAwaitableConstraint ac)
		{
			_ac = ac;
		}

		public Task Perform(Func<Task> perform)
		{
			return Perform(perform, CancellationToken.None);
		}

		public Task<T> Perform<T>(Func<Task<T>> perform)
		{
			return Perform(perform, CancellationToken.None);
		}

		public async Task Perform(Func<Task> perform, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			using (await _ac.WaitForReadiness(cancellationToken))
			{
				await perform();
			}
		}

		public async Task<T> Perform<T>(Func<Task<T>> perform, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			using (await _ac.WaitForReadiness(cancellationToken))
			{
				return await perform();
			}
		}

		private static Func<Task> Transform(Action act)
		{
			return delegate
			{
				act();
				return Task.FromResult(0);
			};
		}

		private static Func<Task<T>> Transform<T>(Func<T> compute)
		{
			return () => Task.FromResult(compute());
		}

		public Task Perform(Action perform, CancellationToken cancellationToken)
		{
			Func<Task> perform2 = Transform(perform);
			return Perform(perform2, cancellationToken);
		}

		public Task Perform(Action perform)
		{
			Func<Task> perform2 = Transform(perform);
			return Perform(perform2);
		}

		public Task<T> Perform<T>(Func<T> perform)
		{
			Func<Task<T>> perform2 = Transform(perform);
			return Perform(perform2);
		}

		public Task<T> Perform<T>(Func<T> perform, CancellationToken cancellationToken)
		{
			Func<Task<T>> perform2 = Transform(perform);
			return Perform(perform2, cancellationToken);
		}

		public static TimeLimiter GetFromMaxCountByInterval(int maxCount, TimeSpan timeSpan)
		{
			return new TimeLimiter(new CountByIntervalAwaitableConstraint(maxCount, timeSpan));
		}

		public static TimeLimiter GetPersistentTimeLimiter(int maxCount, TimeSpan timeSpan, Action<DateTime> saveStateAction)
		{
			return GetPersistentTimeLimiter(maxCount, timeSpan, saveStateAction, null);
		}

		public static TimeLimiter GetPersistentTimeLimiter(int maxCount, TimeSpan timeSpan, Action<DateTime> saveStateAction, IEnumerable<DateTime> initialTimeStamps)
		{
			return new TimeLimiter(new PersistentCountByIntervalAwaitableConstraint(maxCount, timeSpan, saveStateAction, initialTimeStamps));
		}

		public static TimeLimiter Compose(params IAwaitableConstraint[] constraints)
		{
			IAwaitableConstraint awaitableConstraint = null;
			foreach (IAwaitableConstraint awaitableConstraint2 in constraints)
			{
				awaitableConstraint = ((awaitableConstraint == null) ? awaitableConstraint2 : awaitableConstraint.Compose(awaitableConstraint2));
			}
			return new TimeLimiter(awaitableConstraint);
		}
	}
}
