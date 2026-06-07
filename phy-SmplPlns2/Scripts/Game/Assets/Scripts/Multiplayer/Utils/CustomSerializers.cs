using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.Utils
{
	public static class CustomSerializers
	{
		public static Vector3d ReadVector3d(this Reader reader)
		{
			return new Vector3d
			{
				x = reader.ReadDouble(),
				y = reader.ReadDouble(),
				z = reader.ReadDouble()
			};
		}

		public static void WriteVector3d(this Writer writer, Vector3d value)
		{
			writer.WriteDouble(value.x);
			writer.WriteDouble(value.y);
			writer.WriteDouble(value.z);
		}
	}
}
