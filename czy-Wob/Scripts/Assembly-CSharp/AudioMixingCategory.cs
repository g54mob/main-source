using UnityEngine;

public class AudioMixingCategory : MonoBehaviour
{
	public AudioMixingApplyButton buttonRef;

	public GameObject activeIndicator;

	private string categoryID;

	private void Awake()
	{
		SetPlayingStatus(val: false);
	}

	public string GetCategoryID()
	{
		return categoryID;
	}

	public void SetButtonInfo(string newCategoryID)
	{
		categoryID = newCategoryID;
		buttonRef.SetInfo(newCategoryID);
	}

	public void SetPlayingStatus(bool val)
	{
		activeIndicator.SetActive(val);
	}
}
