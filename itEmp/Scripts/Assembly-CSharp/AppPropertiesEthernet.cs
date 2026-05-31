using TMPro;
using UnityEngine;

public class AppPropertiesEthernet : MonoBehaviour
{
	[Header("Component Default")]
	public AppMovementFucus movementFucus;

	public WindowAppMinimalizeAnimation minimalizeAnimation;

	public AppIpV4Config appIpV4Config;

	[Header("Component")]
	public AppBase AppBase;

	[HideInInspector]
	public bool isOpen;

	public TextMeshProUGUI DescriptionText;

	public TextMeshProUGUI PropertiesColorText;

	public string[] descriptionProtocol;

	public int chooseInfo;

	public void OpenApp()
	{
	}

	public void CloseApp()
	{
	}

	public void ChangeDataInWindow(int click)
	{
	}

	public void GotoSetIPV4()
	{
	}
}
