using System;
using System.Collections.Generic;
using UnityEngine;

namespace FullSerializer.Internal.DirectConverters
{
	public class Vector3Int_DirectConverter : fsDirectConverter<Vector3Int>
	{
		private const string AXIS_X_NAME = "X";

		private const string AXIS_Y_NAME = "Y";

		private const string AXIS_Z_NAME = "Z";

		protected override fsResult DoSerialize(Vector3Int model, Dictionary<string, fsData> serialized)
		{
			return fsResult.Success + SerializeMember(serialized, null, "X", model.x) + SerializeMember(serialized, null, "Y", model.y) + SerializeMember(serialized, null, "Z", model.z);
		}

		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref Vector3Int model)
		{
			fsResult success = fsResult.Success;
			int value = model.x;
			fsResult obj = success + DeserializeMember<int>(data, null, "X", out value);
			model.x = value;
			int value2 = model.y;
			fsResult obj2 = obj + DeserializeMember<int>(data, null, "Y", out value2);
			model.y = value2;
			int value3 = model.z;
			fsResult result = obj2 + DeserializeMember<int>(data, null, "Z", out value3);
			model.z = value3;
			return result;
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return default(Vector3Int);
		}
	}
}
