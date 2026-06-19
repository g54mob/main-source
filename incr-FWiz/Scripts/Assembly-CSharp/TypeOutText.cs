using FMODUnity;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class TypeOutText : MonoBehaviour
{
	private LocalizedString _activeLocalizedString;

	private Coroutine _textCoroutine;

	[SerializeField]
	private TextMeshProUGUI _textMesh;

	public EventReference WriteSound;

	public void SetLocalisedTitle(LocalizedString localisedString)
	{
	}

	public void UpdateText(string text)
	{
	}

	private void OnDestroy()
	{
	}
}
