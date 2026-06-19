using System;
using FullSerializerSave;

namespace TH20
{
	public class ByteArrayConverter : fsDirectConverter
	{
		public override Type ModelType => typeof(ByteArray);

		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			ByteArray byteArray = (ByteArray)instance;
			if (byteArray.Bytes == null)
			{
				serialized = fsData.Null;
			}
			else
			{
				serialized = new fsData(Convert.ToBase64String(byteArray.Bytes));
			}
			return fsResult.Success;
		}

		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			if (data.IsNull)
			{
				instance = default(ByteArray);
			}
			else
			{
				instance = new ByteArray
				{
					Bytes = Convert.FromBase64String(data.AsString)
				};
			}
			return fsResult.Success;
		}
	}
}
