using System.Runtime.Serialization;
using UnityEngine;

namespace PajamaLlama.Serialization
{
	public class RectSerializationSurrogate : ISerializationSurrogate
	{
		public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
		{
			Rect rect = (Rect)obj;
			info.AddValue("x", rect.x);
			info.AddValue("y", rect.y);
			info.AddValue("w", rect.width);
			info.AddValue("h", rect.height);
		}

		public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
		{
			Rect rect = new Rect(info.GetSingle("x"), info.GetSingle("y"), info.GetSingle("w"), info.GetSingle("h"));
			obj = rect;
			return rect;
		}
	}
}
