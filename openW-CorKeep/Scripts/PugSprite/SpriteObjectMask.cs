using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class SpriteObjectMask : MonoBehaviour
{
	public const int MAX_MASK_CHANNELS = 32;

	public static List<SpriteObjectMask> instances = new List<SpriteObjectMask>();

	[Range(0f, 31f)]
	public int channel;

	public float width = 1f;

	public float height = 1f;

	public Matrix4x4 matrix => Matrix4x4.TRS(base.transform.position, base.transform.rotation, new Vector3(base.transform.localScale.x * width, base.transform.localScale.y * height, 1f));

	private void OnEnable()
	{
		instances.Add(this);
	}

	private void OnDisable()
	{
		instances.Remove(this);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = new Color(1f, 1f, 1f, 0.1f);
		Gizmos.matrix = matrix;
		Gizmos.DrawWireCube(Vector3.zero, new Vector3(1f, 1f, 0f));
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.matrix = matrix;
		Gizmos.DrawWireCube(Vector3.zero, new Vector3(1f, 1f, 0f));
	}
}
