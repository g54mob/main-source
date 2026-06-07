using System.Collections;
using TMPro;
using UnityEngine;

public class RevealText : MonoBehaviour
{
	public TextMeshProUGUI text;

	public string key;

	private void Start()
	{
		if (key != null)
		{
			ChangeText(key);
		}
	}

	private void OnEnable()
	{
		if (key != null)
		{
			ChangeText(key);
		}
	}

	public void ChangeText(string txt)
	{
		StartCoroutine(RevealText_(txt));
	}

	private IEnumerator RevealText_(string txt)
	{
		text.text = JSONAccess.Instance.GetMiscText("RevealText", txt);
		text.ForceMeshUpdate();
		int totalVisibleCharacters = text.textInfo.characterCount;
		int counter = 0;
		while (true)
		{
			int num = counter % (totalVisibleCharacters + 1);
			text.maxVisibleCharacters = num;
			if (num >= totalVisibleCharacters)
			{
				break;
			}
			counter++;
			yield return new WaitForSeconds(0.03f);
		}
	}
}
