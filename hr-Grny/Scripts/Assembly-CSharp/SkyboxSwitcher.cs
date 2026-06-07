using UnityEngine;

public class SkyboxSwitcher : MonoBehaviour
{
	[Header("Skybox Materials")]
	[Tooltip("The default, non-themed Skybox Material.")]
	[SerializeField]
	private Material defaultSkybox;

	[Tooltip("The Halloween-themed Skybox Material.")]
	[SerializeField]
	private Material halloweenSkybox;

	[Tooltip("The Nightmare-themed Skybox Material.")]
	[SerializeField]
	private Material nightmareSkybox;

	[Tooltip("The Christmas-themed Skybox Material.")]
	[SerializeField]
	private Material christmasSkybox;

	private const string HALLOWEEN_KEY = "HalloweenOnOff";

	private const string NIGHTMARE_KEY = "NightMareOnOff";

	private const string CHRISTMAS_KEY = "ChristmasOnOff";

	private void Start()
	{
	}
}
