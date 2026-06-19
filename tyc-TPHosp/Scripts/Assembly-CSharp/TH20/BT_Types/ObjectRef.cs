using System;

namespace TH20.BT_Types
{
	[Serializable]
	public class ObjectRef<T> : ObjectRefBase
	{
		public T Get { get; protected set; }

		protected ObjectRef()
		{
		}

		protected ObjectRef(T obj)
		{
			Get = obj;
		}

		public bool IsValid()
		{
			return Get != null;
		}

		public override string ToString()
		{
			if (Get == null)
			{
				return "null";
			}
			return Get.ToString();
		}

		public override void NullIfDestroyed()
		{
			if (Get is Entity entity && entity.HasBeenDestroyed())
			{
				Get = default(T);
			}
		}
	}
}
