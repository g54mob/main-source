using System;

namespace ParadoxNotion.Serialization.FullSerializer.Internal
{
	public class fsPrimitiveConverter : fsConverter
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

		private static bool UseBool(Type type)
		{
			return false;
		}

		private static bool UseInt64(Type type)
		{
			return false;
		}

		private static bool UseDouble(Type type)
		{
			return false;
		}

		private static bool UseString(Type type)
		{
			return false;
		}

		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			serialized = null;
			return default(fsResult);
		}

		public override fsResult TryDeserialize(fsData storage, ref object instance, Type storageType)
		{
			return default(fsResult);
		}
	}
}
