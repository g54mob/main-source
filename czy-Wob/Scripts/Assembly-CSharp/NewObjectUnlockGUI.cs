using TMPro;
using UnityEngine;

public class NewObjectUnlockGUI : MonoBehaviour
{
	public GameObject previewHolder;

	public TextMeshPro itemNameText;

	public TextMeshPro itemDescriptionText;

	public void SetUnlockedObject(InventoryItem item)
	{
	}

	public void SetUnlockedObject(Researchable researchRef)
	{
	}

	public void OnOkButtonClicked()
	{
		Object.Destroy(base.transform.root.gameObject);
	}
}
