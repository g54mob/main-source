using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AdventureRewardHolder : MonoBehaviour
{
	public Image rewardIcon;

	public TextMeshProUGUI rewardName;

	private void OnEnable()
	{
		Inchworm globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		rewardIcon.transform.parent.transform.localScale = Vector3.zero;
		globalComponent.RequestEaseToScale(rewardIcon.transform.parent.gameObject, Vector3.one, 1f, Inchworm.EaseStyle.ElasticOut, null, Inchworm.EasePriority.Normal, 0.25f);
	}

	private void OnDisable()
	{
		Object.Destroy(base.gameObject);
	}

	public void PopulateHolder(Researchable rewardRef)
	{
		if (rewardRef.roomCustomizationObjectUnlock != null)
		{
			rewardIcon.sprite = rewardRef.roomCustomizationObjectUnlock.icon;
			rewardName.text = rewardRef.roomCustomizationObjectUnlock.GetName();
		}
		else if (rewardRef.inventoryItemUnlock != null)
		{
			rewardIcon.sprite = rewardRef.inventoryItemUnlock.icon;
			rewardName.text = rewardRef.inventoryItemUnlock.itemNameLocalized;
		}
	}
}
