using System.IO;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	public static class BinaryReaderExtensions
	{
		public static Vector2 ReadVector2(this BinaryReader reader)
		{
			float x = reader.ReadSingle();
			float y = reader.ReadSingle();
			return new Vector2(x, y);
		}

		public static Vector3 ReadVector3(this BinaryReader reader)
		{
			float x = reader.ReadSingle();
			float y = reader.ReadSingle();
			float z = reader.ReadSingle();
			return new Vector3(x, y, z);
		}

		public static void Write(this BinaryWriter writer, Vector3 vector)
		{
			writer.Write(vector.x);
			writer.Write(vector.y);
			writer.Write(vector.z);
		}

		public static void Write(this BinaryWriter writer, Vector2 vector)
		{
			writer.Write(vector.x);
			writer.Write(vector.y);
		}

		public static Color ReadColor(this BinaryReader reader)
		{
			float r = reader.ReadSingle();
			float g = reader.ReadSingle();
			float b = reader.ReadSingle();
			float a = reader.ReadSingle();
			return new Color(r, g, b, a);
		}

		public static void Write(this BinaryWriter writer, Color color)
		{
			writer.Write(color.r);
			writer.Write(color.g);
			writer.Write(color.b);
			writer.Write(color.a);
		}
	}
}
