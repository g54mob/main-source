using System;
using JetBrains.Annotations;

namespace FluffyUnderware.DevTools
{
	public interface IPool
	{
		[NotNull]
		string Identifier { get; set; }

		[NotNull]
		PoolSettings Settings { get; }

		int Count { get; }

		[Obsolete]
		[UsedImplicitly]
		void Clear();

		[UsedImplicitly]
		[Obsolete]
		void Reset();

		[Obsolete]
		[UsedImplicitly]
		void Update();
	}
}
