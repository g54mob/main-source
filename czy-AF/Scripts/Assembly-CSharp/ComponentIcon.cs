using UnityEngine;
using UnityEngine.UI;

public class ComponentIcon : MonoBehaviour
{
	public RawImage rawImage;

	private void Start()
	{
		ComponentBase component = GetComponent<ComponentBase>();
		if (component.data["icon"] == null)
		{
			rawImage.enabled = false;
		}
		rawImage.texture = Resources.Load<Texture>("Interface/Icons Next/" + component.data["icon"]);
	}
}
