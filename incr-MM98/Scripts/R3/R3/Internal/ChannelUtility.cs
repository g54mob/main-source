using System.Threading.Channels;

namespace R3.Internal
{
	internal static class ChannelUtility
	{
		private static readonly UnboundedChannelOptions options = new UnboundedChannelOptions
		{
			SingleWriter = true,
			SingleReader = true,
			AllowSynchronousContinuations = true
		};

		private static readonly BoundedChannelOptions singularBoundedOptions = new BoundedChannelOptions(1)
		{
			SingleWriter = true,
			SingleReader = true,
			AllowSynchronousContinuations = true,
			FullMode = BoundedChannelFullMode.DropOldest
		};

		internal static Channel<T> CreateSingleReadeWriterUnbounded<T>()
		{
			return Channel.CreateUnbounded<T>(options);
		}

		internal static Channel<T> CreateSingleReadeWriterSingularBounded<T>()
		{
			return Channel.CreateBounded<T>(singularBoundedOptions);
		}
	}
}
