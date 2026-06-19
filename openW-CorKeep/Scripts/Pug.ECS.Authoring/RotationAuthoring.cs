using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
public class RotationAuthoring : MonoBehaviour
{
	public float3 initialDirection = new float3(0f, 0f, -1f);

	public bool rotatePhysics;

	public int rotationIconOffset;
}
