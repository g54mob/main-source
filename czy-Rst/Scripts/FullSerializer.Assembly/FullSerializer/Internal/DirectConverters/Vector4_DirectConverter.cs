using System;
using System.Collections.Generic;
using UnityEngine;

namespace FullSerializer.Internal.DirectConverters
{
	public class Vector4_DirectConverter : fsDirectConverter<Vector4>
	{
		private const string AXIS_X_NAME = "X";

		private const string AXIS_Y_NAME = "Y";

		private const string AXIS_Z_NAME = "Z";

		private const string AXIS_W_NAME = "W";

		protected override fsResult DoSerialize(Vector4 model, Dictionary<string, fsData> serialized)
		{
			return fsResult.Success + SerializeMember(serialized, null, "X", model.x) + SerializeMember(serialized, null, "Y", model.y) + SerializeMember(serialized, null, "Z", model.z) + SerializeMember(serialized, null, "W", model.w);
		}

		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref Vector4 model)
		{
			fsResult success = fsResult.Success;
			float value = model.x;
			fsResult obj = success + DeserializeMember<float>(data, null, "X", out value);
			model.x = value;
			float value2 = model.y;
			fsResult obj2 = obj + DeserializeMember<float>(data, null, "Y", out value2);
			model.y = value2;
			float value3 = model.z;
			fsResult obj3 = obj2 + DeserializeMember<float>(data, null, "Z", out value3);
			model.z = value3;
			float value4 = model.w;
			fsResult result = obj3 + DeserializeMember<float>(data, null, "Z", out value4);
			model.w = value4;
			return result;
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return default(Vector4);
		}
	}
}
