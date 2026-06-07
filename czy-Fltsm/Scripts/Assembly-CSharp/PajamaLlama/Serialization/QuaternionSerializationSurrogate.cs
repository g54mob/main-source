using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace PajamaLlama.Serialization
{
	public class QuaternionSerializationSurrogate : ISerializationSurrogate
	{
		public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
		{
			Quaternion quaternion = (Quaternion)obj;
			info.AddValue("w", quaternion.w);
			info.AddValue("x", quaternion.x);
			info.AddValue("y", quaternion.y);
			info.AddValue("z", quaternion.z);
		}

		public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
		{
			Quaternion quaternion = (Quaternion)obj;
			Type typeFromHandle = typeof(float);
			quaternion.w = (float)info.GetValue("w", typeFromHandle);
			quaternion.x = (float)info.GetValue("x", typeFromHandle);
			quaternion.y = (float)info.GetValue("y", typeFromHandle);
			quaternion.z = (float)info.GetValue("z", typeFromHandle);
			obj = quaternion;
			return quaternion;
		}
	}
}
