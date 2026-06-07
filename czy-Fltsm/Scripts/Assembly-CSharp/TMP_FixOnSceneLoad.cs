using System.Collections;
using TMPro;
using UnityEngine;

public class TMP_FixOnSceneLoad : MonoBehaviour
{
	private void Start()
	{
		StartCoroutine(FixBlurryText());
	}

	private IEnumerator FixBlurryText()
	{
		yield return null;
		yield return new WaitForEndOfFrame();
		yield return new WaitForEndOfFrame();
		Canvas.ForceUpdateCanvases();
		TMP_Text[] componentsInChildren = GetComponentsInChildren<TMP_Text>(includeInactive: true);
		foreach (TMP_Text tMP_Text in componentsInChildren)
		{
			if (tMP_Text != null)
			{
				tMP_Text.ForceMeshUpdate(ignoreActiveState: true);
			}
		}
	}
}
