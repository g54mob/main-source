using System;
using System.Collections.Generic;

namespace Infrastructure.Project.Registration.Native
{
	public abstract class NativeMappedPrefabsGroupHandler<TKey, TValue> : NativePrefabsGroupHandler where TKey : Enum where TValue : g
	{
		private Dictionary<TKey, PrefabPassport<TValue>> sxf;

		public IReadOnlyDictionary<TKey, PrefabPassport<TValue>> xmq => null;

		public sealed override void isj()
		{
		}

		protected abstract Dictionary<TKey, TValue> isr();
	}
}
