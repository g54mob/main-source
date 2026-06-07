using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CultistPanel : MonoBehaviour
{
	public ShopPanelIdentity shopIdentity;

	public TMP_Text itemNameText;

	public TMP_Text descriptionLabel;

	public Button summonButton;

	public TMP_Text summonButton_Text;

	[Header("Progress Bar")]
	public Image progress_FillBar;

	private void OnEnable()
	{
		ForceUpdatePanel();
	}

	private void FixedUpdate()
	{
	}

	public void ForceUpdatePanel()
	{
	}

	private bool HideBecauseWeHaventGrownAnyBerriesOfThisTypeYet()
	{
		if (shopIdentity == ShopPanelIdentity.cultist_BlueBerry)
		{
			if (PlayerStats.Singleton.berryTotal_Blueberry <= 0)
			{
				return true;
			}
		}
		else if (shopIdentity == ShopPanelIdentity.cultist_Raspberry)
		{
			if (PlayerStats.Singleton.berryTotal_Raspberry <= 0)
			{
				return true;
			}
		}
		else if (shopIdentity == ShopPanelIdentity.cultist_Strawberry)
		{
			if (PlayerStats.Singleton.berryTotal_Strawberry <= 0)
			{
				return true;
			}
		}
		else if (shopIdentity == ShopPanelIdentity.cultist_Kiwi)
		{
			if (PlayerStats.Singleton.berryTotal_Kiwi <= 0)
			{
				return true;
			}
		}
		else if (shopIdentity == ShopPanelIdentity.cultist_Plum)
		{
			if (PlayerStats.Singleton.berryTotal_Plum <= 0)
			{
				return true;
			}
		}
		else if (shopIdentity == ShopPanelIdentity.cultist_Apple)
		{
			if (PlayerStats.Singleton.berryTotal_Apple <= 0)
			{
				return true;
			}
		}
		else if (shopIdentity == ShopPanelIdentity.cultist_Pear)
		{
			if (PlayerStats.Singleton.berryTotal_Pear <= 0)
			{
				return true;
			}
		}
		else if (shopIdentity == ShopPanelIdentity.cultist_Peach)
		{
			if (PlayerStats.Singleton.berryTotal_Peach <= 0)
			{
				return true;
			}
		}
		else if (shopIdentity == ShopPanelIdentity.cultist_Banana)
		{
			if (PlayerStats.Singleton.berryTotal_Banana <= 0)
			{
				return true;
			}
		}
		else if (shopIdentity == ShopPanelIdentity.cultist_Pineapple)
		{
			if (PlayerStats.Singleton.berryTotal_Pineapple <= 0)
			{
				return true;
			}
		}
		else if (shopIdentity == ShopPanelIdentity.cultist_Watermelon)
		{
			if (PlayerStats.Singleton.berryTotal_Watermelon <= 0)
			{
				return true;
			}
		}
		else if (shopIdentity == ShopPanelIdentity.cultist_Pumpkin && PlayerStats.Singleton.berryTotal_Pumpkin <= 0)
		{
			return true;
		}
		return false;
	}
}
