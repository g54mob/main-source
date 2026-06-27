using System;
using System.Collections.Generic;
using UnityEngine;

namespace FullSerializer.Internal.DirectConverters
{
	public class Vector2_DirectConverter : fsDirectConverter<Vector2>
	{
		private const string AXIS_X_NAME = "X";

		private const string AXIS_Y_NAME = "Y";

		protected override fsResult DoSerialize(Vector2 model, Dictionary<string, fsData> serialized)
		{
			return fsResult.Success + SerializeMember(serialized, null, "X", model.x) + SerializeMember(serialized, null, "Y", model.y);
		}

		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref Vector2 model)
		{
			fsResult success = fsResult.Success;
			float value = model.x;
			fsResult obj = success + DeserializeMember<float>(data, null, "X", out value);
			model.x = value;
			float value2 = model.y;
			fsResult result = obj + DeserializeMember<float>(data, null, "Y", out value2);
			model.y = value2;
			return result;
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return default(Vector2);
		}
	}
}
