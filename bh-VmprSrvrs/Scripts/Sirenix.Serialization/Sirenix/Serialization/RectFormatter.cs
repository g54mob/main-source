using UnityEngine;

namespace Sirenix.Serialization
{
	public class RectFormatter : MinimalBaseFormatter<Rect>
	{
		private static readonly Serializer<float> FloatSerializer;

		protected override void Read(ref Rect value, IDataReader reader)
		{
		}

		protected override void Write(ref Rect value, IDataWriter writer)
		{
		}
	}
}
