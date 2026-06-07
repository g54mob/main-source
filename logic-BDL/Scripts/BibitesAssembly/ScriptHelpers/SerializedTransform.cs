using System;
using UnityEngine;

namespace ScriptHelpers
{
	[Serializable]
	public class SerializedTransform
	{
		public float[] position = new float[2];

		public float rotation;

		public float scale;

		public SerializedTransform()
		{
		}

		public SerializedTransform(Transform transform)
		{
			Vector3 localPosition = transform.localPosition;
			position[0] = localPosition.x;
			position[1] = localPosition.y;
			rotation = transform.localRotation.eulerAngles.z;
			scale = transform.localScale.x;
		}
	}
}
