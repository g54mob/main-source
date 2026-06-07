using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenPopUpHelper : MonoBehaviour
{
	public const string SHOW_ONCE_IDENTIFIER_PREFIX = "PopupShown_";

	private int currentIndex;

	public List<BeforeGamePopUp> popUpOrder = new List<BeforeGamePopUp>();

	public void PopNext()
	{
		StartCoroutine(DelayedPopUp());
	}

	private IEnumerator DelayedPopUp()
	{
		yield return null;
		try
		{
			if (currentIndex >= popUpOrder.Count)
			{
				yield break;
			}
			bool flag = true;
			if (popUpOrder[currentIndex].onlyShowOnce)
			{
				if (PlayerPrefs.GetInt("PopupShown_" + popUpOrder[currentIndex].identifier) != 0)
				{
					flag = false;
				}
				else
				{
					PlayerPrefs.SetInt("PopupShown_" + popUpOrder[currentIndex].identifier, 1);
				}
			}
			if (flag && popUpOrder[currentIndex].showInFullVersion)
			{
				UIFrameManager.instance.ChangeActiveFrameKeepOldVisible(popUpOrder[currentIndex].uiFrame);
			}
			currentIndex++;
		}
		catch
		{
			Debug.Log("There was a problem with the pop-ups in TitleScreenPopUpHelper.cs");
		}
	}
}
