using System;
using System.Runtime.Serialization;

namespace Assets.Scripts.Core
{
	[Serializable]
	public class WeakRef<T> : WeakReference
	{
		public new T Target => (T)base.Target;

		public WeakRef(T target)
			: base(target)
		{
		}

		public WeakRef(T target, bool trackResurrection)
			: base(target, trackResurrection)
		{
		}

		public WeakRef(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
