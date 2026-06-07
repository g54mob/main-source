using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Light))]
public class InteractableLight : MonoBehaviour
{
	private Light light;

	[SerializeField]
	private Image billboardImage;

	[SerializeField]
	private InteractableLightType lightType;

	private void Start()
	{
		light = GetComponent<Light>();
		LightsOut();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			switch (lightType)
			{
			case InteractableLightType.Billboard:
				billboardImage.enabled = true;
				break;
			case InteractableLightType.Light:
				light.enabled = true;
				break;
			case InteractableLightType.Both:
				billboardImage.enabled = true;
				light.enabled = true;
				break;
			}
			MonoBehaviour.print("Light ON");
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			LightsOut();
			MonoBehaviour.print("Light OFF");
		}
	}

	private void LightsOut()
	{
		billboardImage.enabled = false;
		light.enabled = false;
	}
}
