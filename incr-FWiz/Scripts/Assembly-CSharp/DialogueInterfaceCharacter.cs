using OUSystems.Basics.Effects;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class DialogueInterfaceCharacter : MonoBehaviour
{
	private DialogueLine _currentLine;

	[SerializeField]
	private TextMeshProUGUI _titleTextMesh;

	[SerializeField]
	private Image _image;

	[SerializeField]
	private ShakeReceiver _shakeReciever;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnLocaleChanged(Locale newLocale)
	{
	}

	public void HandleLine(DialogueLine line)
	{
	}

	public void UpdateTitleText()
	{
	}
}
