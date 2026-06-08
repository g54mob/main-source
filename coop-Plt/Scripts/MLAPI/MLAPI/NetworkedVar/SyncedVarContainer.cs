using System.IO;
using System.Reflection;
using MLAPI.Serialization.Pooled;

namespace MLAPI.NetworkedVar
{
	internal class SyncedVarContainer
	{
		internal SyncedVarAttribute attribute;

		internal FieldInfo field;

		internal object fieldInstance;

		internal object value;

		internal bool isDirty;

		internal float lastSyncedTime;

		internal bool IsDirty()
		{
			if (attribute.SendTickrate >= 0f && (attribute.SendTickrate == 0f || NetworkingManager.Singleton.NetworkTime - lastSyncedTime >= 1f / attribute.SendTickrate))
			{
				lastSyncedTime = NetworkingManager.Singleton.NetworkTime;
				object objA = field.GetValue(fieldInstance);
				object objB = value;
				if (!object.Equals(objA, objB) || isDirty)
				{
					isDirty = true;
					value = objA;
					return true;
				}
			}
			return false;
		}

		internal void ResetDirty()
		{
			value = field.GetValue(fieldInstance);
			isDirty = false;
		}

		internal void WriteValue(Stream stream, bool checkDirty = true)
		{
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(stream);
			if (checkDirty)
			{
				IsDirty();
			}
			pooledBitWriter.WriteObjectPacked(value);
		}

		internal void ReadValue(Stream stream)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			value = pooledBitReader.ReadObjectPacked(field.FieldType);
			field.SetValue(fieldInstance, value);
		}
	}
}
