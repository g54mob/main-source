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

	public void SetGameObjectOuterRadius(float in_outerRadius)
	{
		AkSoundEngine.SetGameObjectRadius(AkSoundEngine.GetAkGameObjectID(base.gameObject), in_outerRadius, innerRadius);
	}

	public void SetGameObjectInnerRadius(float in_innerRadius)
	{
		AkSoundEngine.SetGameObjectRadius(AkSoundEngine.GetAkGameObjectID(base.gameObject), outerRadius, in_innerRadius);
	}

	public void SetGameObjectRadius(float in_outerRadius, float in_innerRadius)
	{
		AkSoundEngine.SetGameObjectRadius(AkSoundEngine.GetAkGameObjectID(base.gameObject), in_outerRadius, in_innerRadius);
	}

	public void SetGameObjectRadius()
	{
		AkSoundEngine.SetGameObjectRadius(AkSoundEngine.GetAkGameObjectID(base.gameObject), outerRadius, innerRadius);
	}

	public void SetGameObjectRadius(GameObject in_gameObject)
	{
		AkSoundEngine.SetGameObjectRadius(AkSoundEngine.GetAkGameObjectID(in_gameObject), outerRadius, innerRadius);
	}

	private void OnEnable()
	{
		SetGameObjectRadius();
	}
}
