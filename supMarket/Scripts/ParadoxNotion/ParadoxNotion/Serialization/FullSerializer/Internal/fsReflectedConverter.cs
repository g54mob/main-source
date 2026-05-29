using System;

namespace ParadoxNotion.Serialization.FullSerializer.Internal
{
	public class fsReflectedConverter : fsConverter
	{
		public override bool CanProcess(Type type)
		{
			return false;
		}

		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			serialized = null;
			return default(fsResult);
		}

		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			return default(fsResult);
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return null;
		}
	}
}
