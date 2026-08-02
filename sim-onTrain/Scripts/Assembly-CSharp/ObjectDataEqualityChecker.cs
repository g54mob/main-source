using UnityEngine;

public class ObjectDataEqualityChecker : MonoBehaviour
{
	public CollectableItemData itemData;

	public GameObject dataObject;

	public Collider interactionCollider;

	public bool IsEqual(CollectableItemData collectableItemData)
	{
		return itemData == collectableItemData;
	}

	public void OpenObject()
	{
		dataObject.SetActive(value: true);
		if (interactionCollider != null)
		{
			interactionCollider.enabled = true;
		}
	}

	public void CloseObject()
	{
		dataObject.SetActive(value: false);
		if (interactionCollider != null)
		{
			interactionCollider.enabled = false;
		}
	}
}
