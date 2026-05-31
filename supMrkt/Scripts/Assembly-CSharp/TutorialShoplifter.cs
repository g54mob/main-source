using UnityEngine;

public class TutorialShoplifter : Shoplifter
{
	private ShoplifterTutorialCustomer m_ShoplifterTutorialCustomer;

	public ShoplifterTutorialCustomer ShoplifterTutorialCustomer
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	protected override void CheckVisibility()
	{
	}

	public override void Initialize(Animator animator, RuntimeAnimatorController animatorController)
	{
	}

	public override void SpawnSpeech()
	{
	}
}
