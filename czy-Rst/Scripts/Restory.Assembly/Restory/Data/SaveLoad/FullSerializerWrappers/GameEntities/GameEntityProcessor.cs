using System;
using FullSerializer;
using Restory.Data.Base;

namespace Restory.Data.SaveLoad.FullSerializerWrappers.GameEntities
{
	public class GameEntityProcessor : fsObjectProcessor
	{
		public override bool CanProcess(Type type)
		{
			Type typeFromHandle = typeof(RestoryEntityInfoBase);
			if (!type.IsSubclassOf(typeFromHandle))
			{
				return typeFromHandle.IsAssignableFrom(type);
			}
			return true;
		}

		public override void OnBeforeSerialize(Type storageType, object instance)
		{
		}

		public override void OnAfterDeserialize(Type storageType, object instance)
		{
		}

		public override void OnAfterSerialize(Type storageType, object instance, ref fsData data)
		{
		}

		public override void OnBeforeDeserialize(Type storageType, ref fsData data)
		{
		}

		public override void OnBeforeDeserializeAfterInstanceCreation(Type storageType, object instance, ref fsData data)
		{
		}
	}
}
