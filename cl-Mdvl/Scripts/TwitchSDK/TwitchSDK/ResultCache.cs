using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TwitchSDK
{
	internal class ResultCache<Value> where Value : class
	{
		private Stopwatch RequestAge;

		private GameTask<Value> Task;

		private TimeSpan MaxAge;

		public ResultCache(TimeSpan maxAge)
		{
			MaxAge = maxAge;
		}

		public GameTask<Value> GetOrInsert(Func<Task<Value>> upsertAction)
		{
			Func<GameTask<Value>> upsertAction2 = () => upsertAction();
			return GetOrInsert(upsertAction2);
		}

		public GameTask<Value> GetOrInsert(Func<GameTask<Value>> upsertAction)
		{
			lock (this)
			{
				if (RequestAge == null || RequestAge.Elapsed > MaxAge)
				{
					Task = upsertAction();
					RequestAge = Stopwatch.StartNew();
				}
				return Task;
			}
		}
	}
	internal class ResultCache<Key, Value> where Value : class
	{
		private struct Result
		{
			public Stopwatch RequestAge;

			public GameTask<Value> Task;
		}

		private TimeSpan MaxAge;

		private Dictionary<Key, Result> Cache = new Dictionary<Key, Result>();

		public ResultCache(TimeSpan maxAge)
		{
			MaxAge = maxAge;
		}

		public GameTask<Value> GetOrInsert(Key key, Func<Task<Value>> upsertAction)
		{
			Func<GameTask<Value>> upsertAction2 = () => upsertAction();
			return GetOrInsert(key, upsertAction2);
		}

		public GameTask<Value> GetOrInsert(Key key, Func<GameTask<Value>> upsertAction)
		{
			lock (this)
			{
				if (Cache.TryGetValue(key, out var value) && value.RequestAge.Elapsed < MaxAge && value.Task.Exception == null)
				{
					return value.Task;
				}
				Cleanup();
				GameTask<Value> gameTask = upsertAction();
				Cache[key] = new Result
				{
					RequestAge = Stopwatch.StartNew(),
					Task = gameTask
				};
				return gameTask;
			}
		}

		private void Cleanup()
		{
			lock (this)
			{
				foreach (Key item in (from a in Cache
					where a.Value.RequestAge.Elapsed >= MaxAge
					select a.Key).ToList())
				{
					Cache.Remove(item);
				}
			}
		}
	}
}
