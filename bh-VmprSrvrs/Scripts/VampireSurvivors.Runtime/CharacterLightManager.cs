using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CharacterLightManager : MonoBehaviour
{
	[SerializeField]
	private Light2D characterLight;

	[SerializeField]
	[Tooltip("This should be set to the intensity of the Map's Global Light, found in the Map's prefab")]
	private float mapGlobalLightIntensity;

	public bool FixedIntensity;

	public Light2D CharacterLight => null;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
