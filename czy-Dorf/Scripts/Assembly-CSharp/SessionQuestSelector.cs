using UnityEngine;
using UnityEngine.Serialization;

public class SessionQuestSelector : MonoBehaviour
{
	[FormerlySerializedAs("activeImage")]
	[SerializeField]
	private GameObject selectedImage;

	[SerializeField]
	private GameObject passiveSelectedImage;

	private SessionQuestMenuCard sessionQuestMenuCard;

	public void Setup(SessionQuestMenuCard menuCard)
	{
		sessionQuestMenuCard = menuCard;
	}

	public void SetSelected(bool newSelected)
	{
		selectedImage.SetActive(newSelected);
	}
}
