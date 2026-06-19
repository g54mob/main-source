using UnityEngine;
using UnityEngine.UI;

public class DispenserFloraDisplay : MonoBehaviour
{
	public GutFloraResource floraRef;

	public FoodDispensorGUIController dispenserGUIRef;

	private bool unlocked;

	public void OnHoverStart()
	{
		dispenserGUIRef.OnFloraHoverStart(floraRef, unlocked);
	}

	public void ActivateDisplay(GutFloraResource floraType, bool discovered)
	{
		base.gameObject.SetActive(value: true);
		floraRef = floraType;
		Image component = GetComponent<Image>();
		component.sprite = floraRef.gutFloraPreviewSprite;
		unlocked = discovered;
		if (discovered)
		{
			component.color = Color.white;
		}
		else
		{
			component.color = Color.black;
		}
	}

	public void DeactivateDisplay()
	{
		base.gameObject.SetActive(value: false);
	}
}
