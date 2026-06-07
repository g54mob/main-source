using System;
using System.Collections.Generic;
using Ludiq.FullSerializer;
using UnityEngine;

namespace Ludiq
{
	public class Ray2DConverter : fsDirectConverter<Ray2D>
	{
		protected override fsResult DoSerialize(Ray2D model, Dictionary<string, fsData> serialized)
		{
			fsResult success = fsResult.Success;
			success += SerializeMember(serialized, null, "origin", model.origin);
			return success + SerializeMember(serialized, null, "direction", model.direction);
		}

		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref Ray2D model)
		{
			fsResult success = fsResult.Success;
			Vector2 value = model.origin;
			success += DeserializeMember<Vector2>(data, null, "origin", out value);
			model.origin = value;
			Vector2 value2 = model.direction;
			success += DeserializeMember<Vector2>(data, null, "direction", out value2);
			model.direction = value2;
			return success;
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return default(Ray2D);
		}
	}
}
