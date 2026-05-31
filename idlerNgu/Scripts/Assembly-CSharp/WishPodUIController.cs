using UnityEngine;
using UnityEngine.UI;

public class WishPodUIController : MonoBehaviour
{
	public Character character;

	public HoverTooltip tooltip;

	public Image notificationIcon;

	public Image wishIcon;

	public Image wishBorder;

	public GameObject wishPod;

	public Slider wishSlider;

	public int id;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void updatePod()
	{
		if (character.menuID == 53)
		{
			if (invalidID())
			{
				wishPod.SetActive(value: false);
				return;
			}
			wishPod.SetActive(value: true);
			updateNotifications();
			updateIcon();
			updateBar();
		}
	}

	public void updateNotifications()
	{
		if (character.menuID != 53 || invalidID())
		{
			return;
		}
		if (character.wishes.wishes[id].energy > 0 && character.wishes.wishes[id].magic > 0 && character.wishes.wishes[id].res3 > 0)
		{
			notificationIcon.gameObject.SetActive(value: true);
			if (notificationIcon.sprite != character.wishesController.wishOnIcon)
			{
				notificationIcon.sprite = character.wishesController.wishOnIcon;
			}
		}
		else if (character.wishes.wishes[id].energy > 0 || character.wishes.wishes[id].magic > 0 || character.wishes.wishes[id].res3 > 0)
		{
			notificationIcon.gameObject.SetActive(value: true);
			if (notificationIcon.sprite != character.wishesController.wishWarningIcon)
			{
				notificationIcon.sprite = character.wishesController.wishWarningIcon;
			}
		}
		else
		{
			notificationIcon.gameObject.SetActive(value: false);
		}
	}

	public bool invalidID()
	{
		if (id >= 0)
		{
			return id >= character.wishes.wishes.Count;
		}
		return true;
	}

	public void updateIcon()
	{
		if (character.menuID != 53 || invalidID())
		{
			return;
		}
		if (invalidID())
		{
			wishPod.SetActive(value: false);
			return;
		}
		wishIcon.sprite = character.wishesController.properties[id].wishSprite;
		if (id == character.wishesController.curSelectedWish)
		{
			if (wishBorder.sprite != character.wishesController.greenBorder)
			{
				wishBorder.sprite = character.wishesController.greenBorder;
			}
			wishIcon.color = Color.white;
		}
		else if (character.wishes.wishes[id].level == 0)
		{
			if (wishBorder.sprite != character.wishesController.dimBorder)
			{
				wishBorder.sprite = character.wishesController.dimBorder;
			}
			wishIcon.color = new Color(0.4f, 0.4f, 0.4f);
		}
		else if (character.wishes.wishes[id].level >= character.wishesController.maxWishLevel(id))
		{
			if (wishBorder.sprite != character.wishesController.goldBorder)
			{
				wishBorder.sprite = character.wishesController.goldBorder;
			}
			wishIcon.color = Color.white;
		}
		else
		{
			if (wishBorder.sprite != character.wishesController.whiteBorder)
			{
				wishBorder.sprite = character.wishesController.whiteBorder;
			}
			wishIcon.color = Color.white;
		}
	}

	public void updateBar()
	{
		if (character.menuID == 53 && !invalidID())
		{
			if (character.wishes.wishes[id].level >= character.wishesController.maxWishLevel(id))
			{
				wishSlider.value = 1f;
			}
			else
			{
				wishSlider.value = character.wishes.wishes[id].progress;
			}
		}
	}

	public void enterWishTooltip()
	{
		InvokeRepeating("startWishTooltip", 0f, 0.1f);
	}

	public void startWishTooltip()
	{
		character.wishesController.showWishTooltip(id);
	}

	public void exitWishTooltip()
	{
		CancelInvoke("startWishTooltip");
		tooltip.hideTooltip();
	}

	public void selectThisWish()
	{
		character.wishesController.selectNewWish(id);
	}
}
