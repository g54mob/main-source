using UnityEngine;
using UnityEngine.Serialization;

public class TutorialShoplifterAnimationEventListener : MonoBehaviour
{
	[FormerlySerializedAs("m_TutorialShoplifter")]
	[SerializeField]
	private ShoplifterTutorialCustomer m_ShoplifterTutorialCustomer;

	public void HoldItem()
	{
	}

	public void ReleaseItem()
	{
	}

	public void AnimationFinished()
	{
	}
}
