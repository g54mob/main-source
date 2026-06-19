using UnityEngine;
using UnityEngine.UI;

public class PlacementModeTab : MonoBehaviour
{
	public CustomizationType tabType;

	public PlacementModeGUI guiRef;

	public Color mousedColor;

	public Color activeColor;

	public Color defaultColor;

	public Image tabImage;

	private bool activeStatus;

	private float defaultXPos;

	private float activeXPos = 40f;

	private void Update()
	{
		if (activeStatus && tabImage.color != activeColor)
		{
			tabImage.color = activeColor;
		}
		if (!activeStatus && tabImage.color != defaultColor)
		{
			tabImage.color = defaultColor;
		}
	}

	public void OnClick()
	{
		guiRef.SetActiveTab(this);
	}

	public void SetActive()
	{
		activeStatus = true;
		tabImage.color = activeColor;
		base.transform.localPosition = new Vector3(activeXPos, base.transform.localPosition.y, base.transform.localPosition.z);
	}

	public void SetInactive()
	{
		activeStatus = false;
		tabImage.color = defaultColor;
		base.transform.localPosition = new Vector3(defaultXPos, base.transform.localPosition.y, base.transform.localPosition.z);
	}

	public void OnMouseStay()
	{
		tabImage.color = mousedColor;
	}
}
