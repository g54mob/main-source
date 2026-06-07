using UnityEngine;

[AddComponentMenu("Wwise/Spatial Audio/AkRadialEmitter")]
[RequireComponent(typeof(AkGameObj))]
[DisallowMultipleComponent]
public class AkRadialEmitter : MonoBehaviour
{
	[Tooltip("Define the outer radius around each sound position to simulate a radial sound source. If the listener is outside the outer radius, the spread is defined by the area that the sphere takes in the listener field of view. When the listener intersects the outer radius, the spread is exactly 50%. When the listener is in between the inner and outer radius, the spread interpolates linearly from 50% to 100%.")]
	public float outerRadius;

	[Tooltip("Define an inner radius around each sound position to simulate a radial sound source. If the listener is inside the inner radius, the spread is 100%.")]
	public float innerRadius;

	private float previousOuterRadius;

	private float previousInnerRadius;

	public void SetGameObjectOuterRadius(float in_outerRadius)
	{
	}

	public void SetGameObjectInnerRadius(float in_innerRadius)
	{
	}

	public void SetGameObjectRadius(float in_outerRadius, float in_innerRadius)
	{
	}

	public void SetGameObjectRadius()
	{
	}

	public void SetGameObjectRadius(GameObject in_gameObject)
	{
	}

	private void OnEnable()
	{
	}
}
