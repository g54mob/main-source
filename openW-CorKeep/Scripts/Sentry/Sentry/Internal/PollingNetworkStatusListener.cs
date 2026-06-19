using System;
using System.Threading;
using System.Threading.Tasks;
using Sentry.Extensibility;

namespace Sentry.Internal
{
	internal class PollingNetworkStatusListener : INetworkStatusListener
	{
		private readonly SentryOptions? _options;

		private readonly IPing? _testPing;

		internal int _delayInMilliseconds;

		private readonly int _maxDelayInMilliseconds;

		private readonly Func<int, int> _backoffFunction;

		private volatile bool _online = true;

		private Lazy<IPing> LazyPing => new Lazy<IPing>(delegate
		{
			if (_testPing != null)
			{
				return _testPing;
			}
			Uri uri = new Uri(_options.Dsn);
			return new TcpPing(uri.DnsSafeHost, uri.Port);
		});

		private IPing Ping => LazyPing.Value;

		public bool Online
		{
			get
			{
				return _online;
			}
			set
			{
				_online = value;
			}
		}

		public PollingNetworkStatusListener(SentryOptions options, int initialDelayInMilliseconds = 500, int maxDelayInMilliseconds = 32000, Func<int, int>? backoffFunction = null)
		{
			_options = options;
			_delayInMilliseconds = initialDelayInMilliseconds;
			_maxDelayInMilliseconds = maxDelayInMilliseconds;
			_backoffFunction = backoffFunction ?? ((Func<int, int>)((int x) => x * 2));
		}

		internal PollingNetworkStatusListener(IPing testPing, int initialDelayInMilliseconds = 500, int maxDelayInMilliseconds = 32000, Func<int, int>? backoffFunction = null)
		{
			_testPing = testPing;
			_delayInMilliseconds = initialDelayInMilliseconds;
			_maxDelayInMilliseconds = maxDelayInMilliseconds;
			_backoffFunction = backoffFunction ?? ((Func<int, int>)((int x) => x * 2));
		}

		public async Task WaitForNetworkOnlineAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			while (!cancellationToken.IsCancellationRequested)
			{
				try
				{
					await Task.Delay(_delayInMilliseconds, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (await Ping.IsAvailableAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
					{
						Online = true;
						break;
					}
					if (_delayInMilliseconds < _maxDelayInMilliseconds)
					{
						_delayInMilliseconds = _backoffFunction(_delayInMilliseconds);
					}
				}
				catch (OperationCanceledException)
				{
					break;
				}
			}
		}
	}
}
