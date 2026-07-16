using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ChatBubbleText : MonoBehaviour
{
	private TextMeshPro text;

	private static System.Random random = new System.Random();

	private string[] dialogueKeys = new string[19]
	{
		"Dialogue1", "Dialogue2", "Dialogue3", "Dialogue4", "Dialogue5", "Dialogue6", "Dialogue7", "Dialogue8", "Dialogue9", "Dialogue10",
		"Dialogue11", "Dialogue12", "Dialogue13", "Dialogue14", "Dialogue15", "Dialogue16", "Dialogue17", "Dialogue18", "Dialogue19"
	};

	private const string tableName = "LocalizationTable";

	private void Awake()
	{
		text = GetComponent<TextMeshPro>();
	}

	private void OnEnable()
	{
		StartCoroutine(SetLocalizedText());
	}

	private IEnumerator SetLocalizedText()
	{
		yield return LocalizationSettings.InitializationOperation;
		string text = dialogueKeys[random.Next(dialogueKeys.Length)];
		LocalizedString localizedString = new LocalizedString
		{
			TableReference = "LocalizationTable",
			TableEntryReference = text
		};
		AsyncOperationHandle<string> stringOp = localizedString.GetLocalizedStringAsync();
		yield return stringOp;
		this.text.SetText(stringOp.Result);
	}
}
