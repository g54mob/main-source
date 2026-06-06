using System;

namespace MessagePipe
{
	internal sealed class PredicateFilter<T> : MessageHandlerFilter<T>
	{
		private readonly Func<T, bool> predicate;

		public PredicateFilter(Func<T, bool> predicate)
		{
			this.predicate = predicate;
			base.Order = int.MinValue;
		}

		public override void Handle(T message, Action<T> next)
		{
			if (predicate(message))
			{
				next(message);
			}
		}
	}
}
