using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace PajamaLlama.Serialization
{
	public class Vector3SerializationSurrogate : ISerializationSurrogate
	{
		public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
		{
			Vector3 vector = (Vector3)obj;
			info.AddValue("x", vector.x);
			info.AddValue("y", vector.y);
			info.AddValue("z", vector.z);
		}

		public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
		{
			Vector3 vector = (Vector3)obj;
			Type typeFromHandle = typeof(float);
			vector.x = (float)info.GetValue("x", typeFromHandle);
			vector.y = (float)info.GetValue("y", typeFromHandle);
			vector.z = (float)info.GetValue("z", typeFromHandle);
			obj = vector;
			return vector;
		}
	}
}
