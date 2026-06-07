using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SingleJournalPlantUI : MonoBehaviour
{
	[SerializeField]
	private Image plantImage;

	[SerializeField]
	private TextMeshProUGUI plantName;

	[SerializeField]
	private Image newNotifyer;

	public void UpdateVisual(ObjectSO objectSO, bool newInCollection)
	{
		plantImage.sprite = objectSO.journalSprite;
		plantName.text = objectSO.objectName.ToString();
		newNotifyer.gameObject.SetActive(value: false);
		newNotifyer.gameObject.SetActive(newInCollection);
	}
}
