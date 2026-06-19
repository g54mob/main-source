using TMPro;
using UnityEngine;

public class AdventureResultsPanel : MonoBehaviour
{
	public GameObject rewardHolderPrefab;

	public Transform rewardHolderParentTransform;

	public AdventureGUI guiRef;

	public TextMeshProUGUI flavorText;

	public TextScaleInOnLoad rewardsTitleTextLoader;

	public GameObject flavorTextScreen;

	public GameObject rewardsScreen;

	private AdventureResults resultsRef;

	public void DisplayResults(AdventureResults results)
	{
		resultsRef = results;
		ShowFlavorTextScreen();
		flavorText.text = results.flavorText;
		flavorText.GetComponent<TextScaleInOnLoad>().RequestScaleIn();
	}

	public void ShowFlavorTextScreen()
	{
		rewardsScreen.SetActive(value: false);
		flavorTextScreen.SetActive(value: true);
	}

	public void ShowRewardsScreen()
	{
		rewardsScreen.SetActive(value: true);
		flavorTextScreen.SetActive(value: false);
		FillRewards();
		rewardsTitleTextLoader.RequestScaleIn();
	}

	private void FillRewards()
	{
		for (int i = 0; i < resultsRef.unlockedObjects.Count; i++)
		{
			GameObject obj = Object.Instantiate(rewardHolderPrefab);
			obj.transform.SetParent(rewardHolderParentTransform);
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localScale = Vector3.one;
			obj.GetComponent<AdventureRewardHolder>().PopulateHolder(resultsRef.unlockedObjects[i]);
		}
	}
}
