using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DesktopIconController : ComputerOSUIComponent
{
	public DesktopApp desktop;

	public CruncherAppPreset preset;

	public RectTransform rect;

	public Image icon;

	public TextMeshProUGUI iconText;

	public void Setup(DesktopApp newDesktop, CruncherAppPreset newApp)
	{
	}

	public override void OnLeftClick()
	{
	}
}
