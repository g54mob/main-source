using Sirenix.Serialization;
using UnityEngine;

namespace OdinSerializer
{
	public class RectIntFormatter : MinimalBaseFormatter<RectInt>
	{
		private static readonly Serializer<int> IntSerializer;

		protected override void Read(ref RectInt value, IDataReader reader)
		{
		}

		protected override void Write(ref RectInt value, IDataWriter writer)
		{
		}
	}
}
