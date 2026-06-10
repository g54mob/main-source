using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CruncherSurveillanceActorEntry : MonoBehaviour
{
	[Header("Components")]
	public RectTransform rect;

	public RawImage headshotImg;

	public bool loadedHeadshot;

	public ComputerOSUIComponent component;

	public RectTransform namePopup;

	public TextMeshProUGUI popupText;

	public SurveillanceApp appParent;

	public Human human;

	public bool isOver;

	public void Setup(SurveillanceApp newParent, Human newHuman)
	{
	}

	public void LoadHeadshot()
	{
	}

	public void SetOnOver(bool val, bool forceUpdate = false)
	{
	}

	public void UpdateText()
	{
	}

	public void Press()
	{
	}
}
