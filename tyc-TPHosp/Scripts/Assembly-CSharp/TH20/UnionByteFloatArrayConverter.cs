using System;
using FullSerializerSave;

namespace TH20
{
	public class UnionByteFloatArrayConverter : fsDirectConverter
	{
		public override Type ModelType => typeof(UnionByteFloatArray);

		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			UnionByteFloatArray unionByteFloatArray = (UnionByteFloatArray)instance;
			if (unionByteFloatArray.Bytes == null)
			{
				serialized = fsData.Null;
			}
			else
			{
				serialized = new fsData(Convert.ToBase64String(unionByteFloatArray.Bytes));
			}
			return fsResult.Success;
		}

		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			if (data.IsNull)
			{
				instance = default(UnionByteFloatArray);
			}
			else
			{
				instance = new UnionByteFloatArray
				{
					Bytes = Convert.FromBase64String(data.AsString)
				};
			}
			return fsResult.Success;
		}
	}
}
