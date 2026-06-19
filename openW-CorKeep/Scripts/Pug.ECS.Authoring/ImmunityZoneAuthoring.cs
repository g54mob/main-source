using System;
using NaughtyAttributes;
using Unity.Mathematics;
using UnityEngine;

public class ImmunityZoneAuthoring : MonoBehaviour
{
	public float radius;

	public int2 tileOffset;

	public bool useRectangularBounds;

	[AllowNesting]
	[Header("Rectangle size (affects both sides equally). Use even values.")]
	[ShowIf("useRectangularBounds")]
	public int rectangularWidth;

	[AllowNesting]
	[ShowIf("useRectangularBounds")]
	public int rectangularHeight;

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		if (useRectangularBounds)
		{
			Vector3 vector = base.transform.position + new Vector3(tileOffset.x, 0f, tileOffset.y);
			Vector3 vector2 = new Vector3(0.5f + (float)rectangularWidth, 0f, 0f);
			Vector3 vector3 = new Vector3(0f, 0f, 0.5f + (float)rectangularHeight);
			Vector3 vector4 = vector + vector2 + vector3;
			Vector3 vector5 = vector - vector2 + vector3;
			Vector3 vector6 = vector - vector2 - vector3;
			Vector3 vector7 = vector + vector2 - vector3;
			Gizmos.DrawLine(vector4, vector5);
			Gizmos.DrawLine(vector5, vector6);
			Gizmos.DrawLine(vector6, vector7);
			Gizmos.DrawLine(vector7, vector4);
		}
		else
		{
			Vector3 vector8 = base.transform.position + new Vector3(tileOffset.x, 0f, tileOffset.y);
			for (int i = 0; i < 32; i++)
			{
				float f = (float)i / 32f * 2f * MathF.PI;
				float f2 = (float)(i + 1) / 32f * 2f * MathF.PI;
				Vector3 vector9 = vector8 + new Vector3(Mathf.Cos(f), 0f, Mathf.Sin(f)) * radius;
				Vector3 to = vector8 + new Vector3(Mathf.Cos(f2), 0f, Mathf.Sin(f2)) * radius;
				Gizmos.DrawLine(vector9, to);
			}
		}
	}
}
