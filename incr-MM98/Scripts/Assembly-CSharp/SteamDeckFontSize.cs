using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class SteamDeckFontSize : MonoBehaviour
{
	[SerializeField]
	private int relativeFontSizeChange;

	private void Awake()
	{
		if (SteamManager.Input.IsSteamDeck())
		{
			GetComponent<TMP_Text>().fontSize += relativeFontSizeChange;
		}
	}
}
