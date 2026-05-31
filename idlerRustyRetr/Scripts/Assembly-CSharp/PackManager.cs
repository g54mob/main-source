using System.Collections.Generic;
using UnityEngine;

public class PackManager : MonoBehaviour
{
	public Transform[] newSeedsParent;

	public List<NewSeedCard> newSeedPacks;

	public NewPackCard basicPack;

	public NewPackCard rarePack;

	public NewPackCard epicPack;

	public NewPackCard legendPack;

	public NewSeedCard seedCardPrefab;

	private bool checkIfOtherPackIsActive(NewPackCard thisPack)
	{
		if (basicPack.gameObject.activeInHierarchy && thisPack != basicPack)
		{
			return true;
		}
		if (rarePack.gameObject.activeInHierarchy && thisPack != rarePack)
		{
			return true;
		}
		if (epicPack.gameObject.activeInHierarchy && thisPack != epicPack)
		{
			return true;
		}
		if (legendPack.gameObject.activeInHierarchy && thisPack != legendPack)
		{
			return true;
		}
		return false;
	}

	public void BuyBasicPack()
	{
		BuyPack(basicPack, 40);
	}

	public void BuyRarePack()
	{
		BuyPack(rarePack, 200);
	}

	public void BuyEpicPack()
	{
		BuyPack(epicPack, 450);
	}

	public void BuyLegendPack()
	{
		BuyPack(legendPack, 750);
	}

	private void BuyPack(NewPackCard pack, int price)
	{
		TooltipSystem.HideIcontip();
		if (!checkIfOtherPackIsActive(pack) && Inventory.ins.spareParts >= price)
		{
			Inventory.ins.AddSpareParts(-price);
			if (pack.quantity <= 0)
			{
				pack.gameObject.SetActive(value: true);
			}
			else
			{
				pack.VisualBump();
			}
			pack.UpdateQuantityTo(pack.quantity + 1);
		}
	}
}
