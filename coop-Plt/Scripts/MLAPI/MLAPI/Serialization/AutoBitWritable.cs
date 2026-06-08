using System.IO;
using System.Reflection;
using MLAPI.Serialization.Pooled;

namespace MLAPI.Serialization
{
	public abstract class AutoBitWritable : IBitWritable
	{
		public virtual void Write(Stream stream)
		{
			FieldInfo[] fieldsForType = SerializationManager.GetFieldsForType(GetType());
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(stream);
			for (int i = 0; i < fieldsForType.Length; i++)
			{
				pooledBitWriter.WriteObjectPacked(fieldsForType[i].GetValue(this));
			}
		}

		public virtual void Read(Stream stream)
		{
			FieldInfo[] fieldsForType = SerializationManager.GetFieldsForType(GetType());
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			for (int i = 0; i < fieldsForType.Length; i++)
			{
				fieldsForType[i].SetValue(this, pooledBitReader.ReadObjectPacked(fieldsForType[i].FieldType));
			}
		}
	}
}
