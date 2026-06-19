using UnityEngine;
using UnityEngine.UI;

public class FloraOccurance : MonoBehaviour
{
	public Image mainIconRenderer;

	public GameObject undiscoveredIcon;

	public GameObject discoveryIndicator;

	public void SetOccurance(Sprite spriteRef, bool discovered, bool newDiscovery)
	{
		mainIconRenderer.sprite = spriteRef;
		discoveryIndicator.SetActive(newDiscovery);
		mainIconRenderer.enabled = discovered;
		undiscoveredIcon.SetActive(!discovered);
	}
}
