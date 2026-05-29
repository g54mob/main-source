using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NGUResolutions : MonoBehaviour
{
	public Character character;

	public ConfirmationBox box;

	public GameObject top;

	public HoverTooltip tooltip;

	private UnityAction yesAction;

	private UnityAction noAction;

	public Button bigResButton;

	private int resID;

	public bool midChange;

	public void Start()
	{
		if (character.platform == platform.Kong || character.platform == platform.AG)
		{
			bigResButton.gameObject.SetActive(value: false);
		}
		else
		{
			bigResButton.gameObject.SetActive(value: false);
			if (Display.main.systemWidth >= 2880 && Display.main.systemHeight >= 1800)
			{
				bigResButton.gameObject.SetActive(value: true);
			}
		}
		noAction = revertResolution;
		yesAction = setResID;
		setResID();
	}

	public void resolution640x400()
	{
		if (Application.platform == RuntimePlatform.WindowsPlayer)
		{
			Screen.SetResolution(640, 400, fullscreen: false);
			top.transform.localPosition = new Vector3(-393f, 0f);
		}
		else
		{
			tooltip.showTooltip("Sorry, you can't change the window size on Armor. Well you COULD maybe, if I was a better programmer. This is getting awkward.", 2f);
		}
	}

	public void resolution960x600()
	{
		if (Application.platform == RuntimePlatform.WindowsPlayer)
		{
			Screen.SetResolution(960, 600, fullscreen: false);
			top.transform.localPosition = new Vector3(-393f, 0f);
		}
		else if (character.platform == platform.Kong)
		{
			Screen.SetResolution(960, 600, fullscreen: false);
			Application.ExternalEval("kongregate.services.resizeGame(960,600);");
		}
		else
		{
			tooltip.showTooltip("Sorry, you can't change the window size on Armor. Well you COULD maybe, if I was a better programmer. This is getting awkward.", 2f);
		}
	}

	public void resolution1280x800()
	{
		if (Application.platform == RuntimePlatform.WindowsPlayer)
		{
			Screen.SetResolution(1280, 800, fullscreen: false);
			top.transform.localPosition = new Vector3(-393f, 0f);
		}
		else if (character.platform == platform.Kong)
		{
			Application.ExternalEval("kongregate.services.resizeGame(1280,800);");
			Screen.SetResolution(1280, 800, fullscreen: false);
		}
		else
		{
			tooltip.showTooltip("Sorry, you can't change the window size on Armor. Well you COULD maybe, if I was a better programmer. This is getting awkward.", 2f);
		}
	}

	public void resolution1440x900()
	{
		if (Application.platform == RuntimePlatform.WindowsPlayer)
		{
			Screen.SetResolution(1440, 900, fullscreen: false);
			top.transform.localPosition = new Vector3(-393f, 0f);
		}
		else if (character.platform == platform.Kong)
		{
			Application.ExternalEval("kongregate.services.resizeGame(1440,900);");
			Screen.SetResolution(1440, 900, fullscreen: false);
		}
		else
		{
			tooltip.showTooltip("Sorry, you can't change the window size on Armor. Well you COULD maybe, if I was a better programmer. This is getting awkward.", 2f);
		}
	}

	public void resolution1680x1050()
	{
		if (Application.platform == RuntimePlatform.WindowsPlayer)
		{
			Screen.SetResolution(1680, 1050, fullscreen: false);
			top.transform.localPosition = new Vector3(-393f, 0f);
		}
		else if (character.platform == platform.Kong)
		{
			Application.ExternalEval("kongregate.services.resizeGame(1680,1050);");
			Screen.SetResolution(1680, 1050, fullscreen: false);
		}
		else
		{
			tooltip.showTooltip("Sorry, you can't change the window size on Armor. Well you COULD maybe, if I was a better programmer. This is getting awkward.", 2f);
		}
	}

	public void resolution2880x1800()
	{
		if (Application.platform == RuntimePlatform.WindowsPlayer)
		{
			Screen.SetResolution(2880, 1800, fullscreen: false);
			top.transform.localPosition = new Vector3(-393f, 0f);
			Invoke("revertResolution", 10f);
			midChange = true;
			box.displayBox("Are you sure you want this huge resolution? No input will revert the resolution in 10 seconds", yesAction, noAction);
		}
		else
		{
			tooltip.showTooltip("Sorry, you can't change to this size on a Browser. Well you COULD maybe, if I was a better programmer. This is getting awkward.", 2f);
		}
	}

	public void revertResolution()
	{
		CancelInvoke("revertResolution");
		midChange = false;
		box.closeBox();
		switch (resID)
		{
		case 0:
			Screen.SetResolution(2880, 1800, fullscreen: false);
			break;
		case 1:
			Screen.SetResolution(1680, 1050, fullscreen: false);
			break;
		case 2:
			Screen.SetResolution(1440, 900, fullscreen: false);
			break;
		case 3:
			Screen.SetResolution(1280, 800, fullscreen: false);
			break;
		case 4:
			Screen.SetResolution(960, 600, fullscreen: false);
			break;
		case 5:
			Screen.SetResolution(640, 400, fullscreen: false);
			break;
		default:
			Screen.SetResolution(960, 600, fullscreen: false);
			break;
		}
	}

	public void funkyResolutionsTooltip()
	{
		if (character.platform == platform.Kong)
		{
			character.tooltip.showOverrideTooltip("<b>WARNING: This is kind of experimental. Enjoy.</b>");
		}
	}

	public void hideFunkyResolutionsTooltip()
	{
		character.tooltip.hideTooltip();
	}

	public void setResID()
	{
		CancelInvoke("revertResolution");
		if (Screen.currentResolution.height >= 1800)
		{
			resID = 0;
		}
		else if (Screen.currentResolution.height >= 1050)
		{
			resID = 1;
		}
		else if (Screen.currentResolution.height >= 900)
		{
			resID = 2;
		}
		else if (Screen.currentResolution.height >= 800)
		{
			resID = 3;
		}
		else if (Screen.currentResolution.height >= 600)
		{
			resID = 4;
		}
		else if (Screen.currentResolution.height >= 400)
		{
			resID = 5;
		}
	}
}
