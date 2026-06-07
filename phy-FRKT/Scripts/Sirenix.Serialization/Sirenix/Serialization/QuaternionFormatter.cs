using UnityEngine;

namespace Sirenix.Serialization
{
	public class QuaternionFormatter : MinimalBaseFormatter<Quaternion>
	{
		private static readonly Serializer<float> FloatSerializer;

		protected override void Read(ref Quaternion value, IDataReader reader)
		{
		}

		protected override void Write(ref Quaternion value, IDataWriter writer)
		{
		}
	}
}
