using UnityEngine;

public class ShopOpeningSignComponent : MonoBehaviour
{
	[SerializeField]
	private string localizationKeyInvalidNeedProducts;

	[SerializeField]
	private string localizationKeyInvalidProductsMissingFlavours;

	[SerializeField]
	private string localizationKeyInvalidTutorial;

	[SerializeField]
	private string localizationKeyInvalidOpeningTime;

	[SerializeField]
	private string soundFlip;

	[SerializeField]
	private string soundOnEndOfDay;

	[SerializeField]
	private string soundDoorBell;

	private bool closedForTheDay;

	private bool open;

	private TweenPlayer entranceDoor;

	private void Start()
	{
		WorldTime.instance.OnEndOfWorkDay.AddListener(delegate
		{
			CloseShopOnEndOfWorkday();
		});
		WorldTime.instance.OnBeginDay.AddListener(delegate
		{
			closedForTheDay = false;
			SetEntranceDoor();
		});
	}

	private void ParentToEntrance()
	{
		entranceDoor = CafeShopManager.GetNearestEntranceDoor(base.transform.position);
		if (entranceDoor != null)
		{
			base.transform.parent = entranceDoor.GetTarget();
		}
	}

	private void CloseShopOnEndOfWorkday()
	{
		CloseShop();
		closedForTheDay = true;
		SoundManager.PlaySoundOnce(soundOnEndOfDay);
	}

	public void OnInteraction(CharacterControllerComponent character)
	{
		if (closedForTheDay)
		{
			PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyInvalidOpeningTime);
		}
		else if (TutorialManager.GetLockByTutorial())
		{
			PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyInvalidTutorial);
		}
		else if (!CloseShop())
		{
			OpenShop();
		}
	}

	private bool CloseShop()
	{
		if (CafeShopManager.IsCafeOpen())
		{
			open = false;
			CafeShopManager.CloseShop();
			FlipSign();
			SoundManager.PlaySoundOnce(soundDoorBell);
			SetEntranceDoor();
			return true;
		}
		return false;
	}

	private bool OpenShop()
	{
		if (ProductManager.GetSellingProductList().Count == 0)
		{
			PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyInvalidNeedProducts);
			return false;
		}
		if (!ProductManager.AreAllSellingProductsValid())
		{
			PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyInvalidProductsMissingFlavours);
			return false;
		}
		if (!CafeShopManager.IsCafeOpen())
		{
			open = true;
			CafeShopManager.OpenShop();
			FlipSign();
			SoundManager.PlaySoundOnce(soundDoorBell);
			TutorialManager.TryCheckSectionChecklistOption("OpenCafe", TutorialManager.TutorialState.RunCafe);
			WorldTime.ResumeSimulation();
			return true;
		}
		return false;
	}

	private void FlipSign()
	{
		SoundManager.PlaySoundOnce(soundFlip);
		TweenerManager.TweenRotation("FlipSign", base.transform, base.transform.rotation, Quaternion.Euler(base.transform.eulerAngles + new Vector3(0f, 180f, 0f)), 0.25f, TweenerManager.GetDefaultEaseCurve());
	}

	private void SetEntranceDoor()
	{
		if (open)
		{
			CafeShopManager.OpenEntranceDoor();
		}
		else
		{
			CafeShopManager.CloseEntranceDoor();
		}
	}
}
