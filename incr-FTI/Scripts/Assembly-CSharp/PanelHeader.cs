using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelHeader : MonoBehaviour
{
	public Image iconImage;

	public TextMeshProUGUI primaryLabel;

	public TextMeshProUGUI countLabel;

	public TextFlashAnimation countAnimation;

	public void Initialize()
	{
		countAnimation = new TextFlashAnimation(countLabel);
	}

	public void UpdateDynamicDisplay()
	{
		countAnimation.UpdateAnimation();
	}

	public void AnimateCount()
	{
		countAnimation.Run();
	}
}
