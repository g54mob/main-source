using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace PajamaLlama.Serialization
{
	public class Vector2SerializationSurrogate : ISerializationSurrogate
	{
		public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
		{
			Vector2 vector = (Vector2)obj;
			info.AddValue("x", vector.x);
			info.AddValue("y", vector.y);
		}

		public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
		{
			Vector2 vector = (Vector2)obj;
			Type typeFromHandle = typeof(float);
			vector.x = (float)info.GetValue("x", typeFromHandle);
			vector.y = (float)info.GetValue("y", typeFromHandle);
			obj = vector;
			return vector;
		}
	}
}
