using AK.Wwise;
using UnityEngine;

[AddComponentMenu("Wwise/Spatial Audio/AkEarlyReflections")]
[RequireComponent(typeof(AkGameObj))]
[DisallowMultipleComponent]
public class AkEarlyReflections : MonoBehaviour
{
	[Tooltip("The early reflections auxiliary bus for all sounds playing on this particular game object. The early reflection auxiliary bus specified in the authoring tool has precedence.")]
	public AuxBus reflectionsAuxBus;

	[Range(0f, 1f)]
	[Tooltip("The early reflections send volume for all sounds playing on this particular game object. It is combined with the early reflections volume specified in the authoring tool.")]
	public float reflectionsVolume;

	private void OnEnable()
	{
	}

	public void SetEarlyReflectionsVolume(float volume)
	{
	}
}
