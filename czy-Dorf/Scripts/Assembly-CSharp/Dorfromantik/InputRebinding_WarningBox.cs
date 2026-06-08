using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Dorfromantik
{
	public class InputRebinding_WarningBox : MonoBehaviour
	{
		[SerializeField]
		private Transform entryContainer;

		[SerializeField]
		private TextMeshProUGUI entryPrefab;

		private List<TextMeshProUGUI> currentEntries = new List<TextMeshProUGUI>();

		public void ResetEntries()
		{
			foreach (TextMeshProUGUI currentEntry in currentEntries)
			{
				Object.Destroy(currentEntry.gameObject);
			}
			currentEntries.Clear();
		}

		public void AddEntry(string localizationKey)
		{
			Debug.Log("Add Entry: " + localizationKey);
			TextMeshProUGUI textMeshProUGUI = Object.Instantiate(entryPrefab, entryContainer);
			textMeshProUGUI.text = "- " + LocalizationManager.Instance.GetLocalizedValue(localizationKey, useFallbackText: true);
			currentEntries.Add(textMeshProUGUI);
		}
	}
}
