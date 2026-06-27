using System;
using System.Collections.Generic;
using UnityEngine;

namespace FullSerializer.Internal.DirectConverters
{
	public class Vector3_DirectConverter : fsDirectConverter<Vector3>
	{
		private const string AXIS_X_NAME = "X";

		private const string AXIS_Y_NAME = "Y";

		private const string AXIS_Z_NAME = "Z";

		protected override fsResult DoSerialize(Vector3 model, Dictionary<string, fsData> serialized)
		{
			return fsResult.Success + SerializeMember(serialized, null, "X", model.x) + SerializeMember(serialized, null, "Y", model.y) + SerializeMember(serialized, null, "Z", model.z);
		}

		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref Vector3 model)
		{
			fsResult success = fsResult.Success;
			float value = model.x;
			fsResult obj = success + DeserializeMemberIfNaN<float>(data, null, "X", out value);
			model.x = value;
			float value2 = model.y;
			fsResult obj2 = obj + DeserializeMemberIfNaN<float>(data, null, "Y", out value2);
			model.y = value2;
			float value3 = model.z;
			fsResult result = obj2 + DeserializeMemberIfNaN<float>(data, null, "Z", out value3);
			model.z = value3;
			return result;
		}

		private fsResult DeserializeMemberIfNaN<T>(Dictionary<string, fsData> data, Type overrideConverterType, string name, out T value)
		{
			if (!data.TryGetValue(name, out var value2))
			{
				value = default(T);
				return fsResult.Fail("Unable to find member \"" + name + "\"");
			}
			if (value2.IsNaN)
			{
				value = default(T);
				return fsResult.Success;
			}
			return DeserializeMember<T>(data, overrideConverterType, name, out value);
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return default(Vector3);
		}
	}
}
