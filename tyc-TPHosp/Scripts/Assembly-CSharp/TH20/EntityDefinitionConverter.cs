#define LOG_LEVEL_VERBOSE
using System;
using FullSerializerSave;
using FullSerializerSave.Internal;

namespace TH20
{
	public class EntityDefinitionConverter : fsReflectedConverter
	{
		public override bool CanProcess(Type type)
		{
			return typeof(IEntityDefinition).IsAssignableFrom(type);
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			if (storageType == typeof(EntityDefinition))
			{
				return new EntityDefinition();
			}
			if (storageType == typeof(IEntityDefinition))
			{
				return new EntityDefinition();
			}
			throw new InvalidOperationException("EntityDefinitionConverter CreateInstance failed" + storageType);
		}

		public override bool RequestInheritanceSupport(Type storageType)
		{
			return true;
		}

		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			fsResult result;
			try
			{
				result = base.TryDeserialize(data, ref instance, storageType);
			}
			catch (Exception ex)
			{
				result = fsResult.Fail(ex.ToString());
				Logging.Info("Exception in EntityDefinitionConverter.TryDeserialize.Should be safe to ignore as this is handled and expected when loading older save files: {0}", ex.ToString());
			}
			if (result.Succeeded)
			{
				return result;
			}
			return base.TryDeserialize(data, ref instance, typeof(EntityDefinition));
		}
	}
}
