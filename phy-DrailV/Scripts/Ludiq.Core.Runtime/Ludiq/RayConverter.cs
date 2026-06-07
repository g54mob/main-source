using System;
using System.Collections.Generic;
using Ludiq.FullSerializer;
using UnityEngine;

namespace Ludiq
{
	public class RayConverter : fsDirectConverter<Ray>
	{
		protected override fsResult DoSerialize(Ray model, Dictionary<string, fsData> serialized)
		{
			fsResult success = fsResult.Success;
			success += SerializeMember(serialized, null, "origin", model.origin);
			return success + SerializeMember(serialized, null, "direction", model.direction);
		}

		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref Ray model)
		{
			fsResult success = fsResult.Success;
			Vector3 value = model.origin;
			success += DeserializeMember<Vector3>(data, null, "origin", out value);
			model.origin = value;
			Vector3 value2 = model.direction;
			success += DeserializeMember<Vector3>(data, null, "direction", out value2);
			model.direction = value2;
			return success;
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return default(Ray);
		}
	}
}
