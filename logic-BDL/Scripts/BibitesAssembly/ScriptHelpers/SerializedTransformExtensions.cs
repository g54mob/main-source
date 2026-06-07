using UnityEngine;

namespace ScriptHelpers
{
	public static class SerializedTransformExtensions
	{
		public static void DeserializeTransform(this SerializedTransform serializedTransform, Transform transform)
		{
			transform.localPosition = new Vector3(serializedTransform.position[0], serializedTransform.position[1], 0f);
			transform.localRotation = Quaternion.Euler(0f, 0f, serializedTransform.rotation);
			transform.localScale = Vector3.one * serializedTransform.scale;
		}
	}
}
