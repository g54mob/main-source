using UnityEngine;

namespace ScriptHelpers
{
	public class OldSerializedTransform
	{
		public float[] Position = new float[3];

		public float[] Rotation = new float[4];

		public float[] Scale = new float[3];

		public SerializedTransform ToNew()
		{
			SerializedTransform serializedTransform = new SerializedTransform();
			serializedTransform.position = new float[2]
			{
				Position[0],
				Position[1]
			};
			serializedTransform.rotation = new Quaternion(Rotation[0], Rotation[1], Rotation[2], Rotation[3]).eulerAngles.z;
			serializedTransform.scale = Scale[0];
			return serializedTransform;
		}
	}
}
