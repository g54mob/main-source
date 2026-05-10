using System;

namespace ParadoxNotion.Serialization.FullSerializer.Internal
{
	public class fsEnumConverter : fsConverter
	{
		public override bool CanProcess(Type type)
		{
			return false;
		}

		public override bool RequestCycleSupport(Type storageType)
		{
			return false;
		}

		public override bool RequestInheritanceSupport(Type storageType)
		{
			return false;
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return null;
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

		private static bool ArrayContains<T>(T[] values, T value)
		{
			return false;
		}
	}
}
