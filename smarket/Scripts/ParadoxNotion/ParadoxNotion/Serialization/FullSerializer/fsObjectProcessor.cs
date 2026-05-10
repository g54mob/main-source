using System;

namespace ParadoxNotion.Serialization.FullSerializer
{
	public abstract class fsObjectProcessor
	{
		public virtual bool CanProcess(Type type)
		{
			return false;
		}

		public virtual void OnBeforeSerialize(Type storageType, object instance)
		{
		}

		public virtual void OnAfterSerialize(Type storageType, object instance, ref fsData data)
		{
		}

		public virtual void OnBeforeDeserialize(Type storageType, ref fsData data)
		{
		}

		public virtual void OnBeforeDeserializeAfterInstanceCreation(Type storageType, object instance, ref fsData data)
		{
		}

		public virtual void OnAfterDeserialize(Type storageType, object instance)
		{
		}
	}
}
