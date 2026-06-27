using System;
using System.Collections.Generic;
using UnityEngine;

namespace FullSerializer.Internal.DirectConverters
{
	public class Vector2Int_DirectConverter : fsDirectConverter<Vector2Int>
	{
		private const string AXIS_X_NAME = "X";

		private const string AXIS_Y_NAME = "Y";

		protected override fsResult DoSerialize(Vector2Int model, Dictionary<string, fsData> serialized)
		{
			return fsResult.Success + SerializeMember(serialized, null, "X", model.x) + SerializeMember(serialized, null, "Y", model.y);
		}

		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref Vector2Int model)
		{
			fsResult success = fsResult.Success;
			int value = model.x;
			fsResult obj = success + DeserializeMember<int>(data, null, "X", out value);
			model.x = value;
			int value2 = model.y;
			fsResult result = obj + DeserializeMember<int>(data, null, "Y", out value2);
			model.y = value2;
			return result;
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return default(Vector2Int);
		}
	}
}
