using System;

namespace FullSerializer
{
	public interface fsISerializationCallbacks
	{
		void OnBeforeSerialize(Type storageType);

		void OnBeforeSerializeInstance(Type storageType);

		void OnAfterSerialize(Type storageType, ref fsData data);

		void OnAfterSerializeInstance(Type storageType, ref fsData data);

		void OnBeforeDeserialize(Type storageType, ref fsData data);

		void OnAfterDeserialize(Type storageType);

		void OnAfterDeserializeInstance(Type storageType);
	}
}
